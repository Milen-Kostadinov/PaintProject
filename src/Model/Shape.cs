using Draw.src.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace Draw
{
    [Serializable]
    public abstract class Shape
	{
		#region Constructors

		public Shape()
		{
		}
		public Shape(PointF startPoint, PointF endPoint)
		{
            Width = (float)Math.Abs(startPoint.X - endPoint.X);
			Height = (float)Math.Abs(startPoint.Y - endPoint.Y);
			Location = new PointF(startPoint.X < endPoint.X ? startPoint.X : endPoint.X,
									startPoint.Y < endPoint.Y ? startPoint.Y : endPoint.Y);
        }

		public Shape(Shape shape)
		{
			this.Height = shape.Height;
			this.Width = shape.Width;
			this.Location = shape.Location;

			this.FillColor = shape.FillColor;
        }
		#endregion
		#region Properties
		private float width;
		public virtual float Width {
			get { return width; }
			set { width = value; }
		}
		private float height;
		public virtual float Height {
			get { return height; }
			set { height = value; }
		}
		private PointF location;
		public virtual PointF Location {
			get { return location; }
			set { location = value; }
		}
		private Color fillColor;
		public virtual Color FillColor {
			get { return fillColor; }
			set { fillColor = value; }
		}
		private PointF startPoint;
		public PointF StartPoint
		{ 
			get { return startPoint; }
			set { startPoint = value; }
		}
		private PointF endPoint;
        public PointF EndPoint
        {
            get { return endPoint; }
            set { endPoint = value; }
        }
        private PointF rotationPoint;
        public PointF RotationPoint
        {
            get { return rotationPoint; }
            set { rotationPoint = value; }
        }
        private int opacity = 255;
		public virtual int Opacity
		{
			get { return opacity; }
			set { opacity = value; }
		}
		private Color outlineColor;
		public virtual Color OutlineColor
		{

            get { return outlineColor; }
			set { outlineColor = value; }
		}
		private int outlineWidth;
		public virtual int OutlineWidth
		{
			get { return outlineWidth; }
			set { outlineWidth = value; }
        }
        private SelectedSide currentSelectedSide;
        public SelectedSide CurrentSelectedSide
        {
            get { return currentSelectedSide; }
            set { this.currentSelectedSide = value; }
        }
        private bool isSelected;
        public bool IsSelected 
        {
            get { return isSelected; }
            set { isSelected = value; }
        }
		private bool hasBeenInteractedWith;
		public bool HasBeenInteractedWith
		{
			get { return hasBeenInteractedWith; }
			set { hasBeenInteractedWith = value; }
        }
        [NonSerialized]
        private Matrix matrix = new Matrix(); 
		public Matrix Matrix
        {
            get { return matrix; }
            set { matrix = value; }
        }
		private float lastRotationAngle;
		public float LastRotationAngle 
		{
			get { return lastRotationAngle; }
			set { lastRotationAngle = value; }
		}
        #endregion
        public virtual bool Contains(PointF point)
		{
            return new RectangleF(Location.X, Location.Y, Math.Abs(Width), Math.Abs(Height)).Contains(point);
		}
		public virtual bool OutlineContainsPoint(PointF point)
        {
            if (new RectangleF(Width > 0 ? StartPoint.X - 5 : StartPoint.X, Height > 0 ? StartPoint.Y - 5 : StartPoint.Y, 5, 5).Contains(point))
			{
				CurrentSelectedSide = SelectedSide.TopLeftCorner;
				return true;
			}
			else if (new RectangleF(Width > 0 ? EndPoint.X : EndPoint.X - 5, Height > 0 ? StartPoint.Y - 5 : StartPoint.Y, 5, 5).Contains(point))
			{
				CurrentSelectedSide = SelectedSide.TopRightCorner;
				return true;
			}
			else if (new RectangleF(Width > 0 ? StartPoint.X - 5 : StartPoint.X, Height > 0 ? EndPoint.Y : EndPoint.Y - 5, 5, 5).Contains(point))
			{
				CurrentSelectedSide = SelectedSide.BottomLeftCorner;
				return true;
			}
			else if (new RectangleF(Width > 0 ? EndPoint.X : EndPoint.X - 5, Height > 0 ? EndPoint.Y : EndPoint.Y - 5, 5, 5).Contains(point))
			{
				CurrentSelectedSide = SelectedSide.BottomRightCorner;
				return true;
			}
			else if (new RectangleF(Width > 0 ? StartPoint.X - 5 : StartPoint.X, Height > 0 ? StartPoint.Y : (StartPoint.Y + Height), 5, Math.Abs(Height)).Contains(point))
			{
				CurrentSelectedSide = SelectedSide.Left;
				return true;
			}
			else if (new RectangleF(Width > 0 ? EndPoint.X : EndPoint.X - 5, Height > 0 ? (EndPoint.Y - Height) : EndPoint.Y, 5, Math.Abs(Height)).Contains(point))
			{
				CurrentSelectedSide = SelectedSide.Right;
				return true;
			}
			else if (new RectangleF(Width > 0 ? StartPoint.X : (StartPoint.X + Width), Height > 0 ? StartPoint.Y - 5 : StartPoint.Y, Math.Abs(Width), 5).Contains(point))
			{
				CurrentSelectedSide = SelectedSide.Top;
				return true;
			}
			else if (new RectangleF(Width > 0 ? (EndPoint.X - Width) : EndPoint.X, Height > 0 ? EndPoint.Y : EndPoint.Y - 5, Math.Abs(Width), 5).Contains(point))
			{
				CurrentSelectedSide = SelectedSide.Bottom;
				return true;
			}

            return false;
		}
		public virtual bool RotationRectContains(PointF point) 
		{
            return new RectangleF(Location.X + Math.Abs(Width) / 2 - 2, Location.Y - 23, 7, 7).Contains(point);		
		}
		public virtual List<Shape> GetShapes() 
		{
			return null;
		}
        public virtual void DrawSelf(Graphics grfx)
		{
			// shape.Rectangle.Inflate(shape.BorderWidth, shape.BorderWidth);
			//Rotate(LastRotationAngle);
			if (matrix == null)
			{
				RotationPoint = new PointF(Location.X + Math.Abs(Width) / 2, Location.Y + Math.Abs(Height) / 2);
				matrix = new Matrix();
				matrix.RotateAt(lastRotationAngle, RotationPoint);
			}
			grfx.Transform = matrix;

            Width = EndPoint.X - StartPoint.X;
            Height = EndPoint.Y - StartPoint.Y;
            Location = new PointF(StartPoint.X < EndPoint.X ? StartPoint.X : EndPoint.X,
                                 StartPoint.Y < EndPoint.Y ? StartPoint.Y : EndPoint.Y);
            if (isSelected)
            {
                grfx.DrawRectangle(new Pen(Color.Black, 3), this.Location.X - 2, this.Location.Y - 2, Math.Abs(Width) + 4, Math.Abs(Height ) + 4);
				grfx.FillRectangle(Brushes.Black, Location.X + Math.Abs(Width) / 2, Location.Y - 20, 3, 20);
				grfx.FillRectangle(Brushes.Black, Location.X + Math.Abs(Width) / 2 - 2, Location.Y - 23, 7, 7);
            }
           /* //bottom
            grfx.FillRectangle(Brushes.Blue, Width > 0 ? (EndPoint.X - Width) : EndPoint.X, Height > 0 ? EndPoint.Y : EndPoint.Y - 5, Math.Abs(Width), 5);
			//top
			grfx.FillRectangle(Brushes.Green, Width > 0 ? StartPoint.X : (StartPoint.X + Width), Height > 0 ? StartPoint.Y - 5 : StartPoint.Y, Math.Abs(Width), 5);
			//left
			grfx.FillRectangle(Brushes.Yellow, Width > 0 ? StartPoint.X - 5 : StartPoint.X, Height > 0 ? StartPoint.Y : (StartPoint.Y + Height), 5, Math.Abs(Height));
			//right
			grfx.FillRectangle(Brushes.Magenta, Width > 0 ? EndPoint.X : EndPoint.X - 5, Height > 0 ? (EndPoint.Y - Height) : EndPoint.Y, 5, Math.Abs(Height));
			//top left
			grfx.FillRectangle(Brushes.Azure, Width > 0 ? StartPoint.X - 5 : StartPoint.X, Height > 0 ? StartPoint.Y - 5 : StartPoint.Y, 5, 5);
			//top right
			grfx.FillRectangle(Brushes.Brown, Width > 0 ? EndPoint.X : EndPoint.X - 5, Height > 0 ? StartPoint.Y - 5 : StartPoint.Y, 5, 5);
			//bottom left
			grfx.FillRectangle(Brushes.Gray, Width > 0 ? StartPoint.X - 5 : StartPoint.X, Height > 0 ? EndPoint.Y : EndPoint.Y - 5, 5, 5);
			//bottom right
			grfx.FillRectangle(Brushes.Tomato, Width > 0 ? EndPoint.X : EndPoint.X - 5, Height > 0 ? EndPoint.Y : EndPoint.Y - 5, 5, 5);*/
		}
    }
}
