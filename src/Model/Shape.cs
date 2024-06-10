using Draw.src.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace Draw
{
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
        private int fillOpacity;
		public virtual int FillOpacity
		{
			get { return fillOpacity; }
			set { fillOpacity = value; }
		}
		public Color outlineColor;
		public virtual Color OutlineColor
		{
			get { return outlineColor; }
			set { outlineColor = value; }
		}
		private int outlineOpacity;
		public virtual int OutlineOpacity
		{
			get { return outlineOpacity; }
			set { outlineOpacity = value; }
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
		//redundant but functionality still there.....can't remove rn
        private int groupId;
        public int GroupId 
        {
            get { return groupId; }
            set { groupId = value; }
        }
		private bool hasBeenInteractedWith;
		public bool HasBeenInteractedWith
		{
			get { return hasBeenInteractedWith; }
			set { hasBeenInteractedWith = value; }
		}
		public Matrix matrixTransformation = new Matrix(); 
		public Matrix MatrixTransformation
        {
            get { return matrixTransformation; }
            set { matrixTransformation = value; }
        }
        #endregion
        public virtual bool Contains(PointF point)
		{
			RectangleF rect = new RectangleF(Location.X, Location.Y, Width, Height);
			return rect.Contains(point.X, point.Y);
		}
		public virtual bool OutlineContainsPoint(PointF point)
		{
			if (new RectangleF(Location.X - 3, Location.Y - 3, 5, 5).Contains(point))
			{
				CurrentSelectedSide = SelectedSide.TopLeftCorner;
				return true;
			}
			else if (new RectangleF(Location.X + Width, Location.Y - 3, 5, 5).Contains(point))
			{
				CurrentSelectedSide = SelectedSide.TopRightCorner;
				return true;
			}
			else if (new RectangleF(Location.X - 3, Location.Y + Height, 5, 5).Contains(point))
			{
				CurrentSelectedSide = SelectedSide.BottomLeftCorner;
				return true;
			}
			else if (new RectangleF(Location.X + Width, Location.Y + Height, 5, 5).Contains(point))
			{
				CurrentSelectedSide = SelectedSide.BottomRightCorner;
				return true;
			}
			//daskjdfashfjsahfasf
			else if (new RectangleF(StartPoint.X, Height > 0 ? StartPoint.Y : (StartPoint.Y + Height), 5, Math.Abs(Height)).Contains(point))
			{
				CurrentSelectedSide = SelectedSide.Left;
				return true;
			}
			else if (new RectangleF(EndPoint.X, Height > 0 ? (EndPoint.Y - Height) : EndPoint.Y, 5, Math.Abs(Height)).Contains(point))
			{
				CurrentSelectedSide = SelectedSide.Right;
				return true;
			}
			//dsajkgfshjafgjhasgfa
			else if (new RectangleF(Width > 0 ? StartPoint.X: StartPoint.X + Width, StartPoint.Y - 3, Math.Abs(Width), 5).Contains(point))
			{
				CurrentSelectedSide = SelectedSide.Top;
				return true;
			}
			else if (new RectangleF(Width > 0 ? EndPoint.X - Width : EndPoint.X, EndPoint.Y, Math.Abs(Width), 5).Contains(point))
			{
				CurrentSelectedSide = SelectedSide.Bottom;
				return true;
			}

            return false;
		}
		//ensures that the start point and end point are diagonally oposite to each other with start point being at top left
		public virtual void FixPoints() 
		{
			PointF temp = startPoint;
			startPoint = new PointF(startPoint.X < endPoint.X ? startPoint.X : endPoint.X,
									startPoint.Y < endPoint.Y ? startPoint.Y : endPoint.Y);
            endPoint = new PointF(temp.X > endPoint.X ? temp.X : endPoint.X,
                                    temp.Y > endPoint.Y ? temp.Y : endPoint.Y);
        }
        public virtual void DrawSelf(Graphics grfx)
		{
			// shape.Rectangle.Inflate(shape.BorderWidth, shape.BorderWidth);
			grfx.Transform = MatrixTransformation;

            Width = EndPoint.X - StartPoint.X;
            Height = EndPoint.Y - StartPoint.Y;
            Location = new PointF(StartPoint.X < EndPoint.X ? StartPoint.X : EndPoint.X,
                                 StartPoint.Y < EndPoint.Y ? StartPoint.Y : EndPoint.Y);
            if (isSelected)
            {
                grfx.DrawRectangle(new Pen(Color.Black, 5), this.Location.X - 3, this.Location.Y - 3, Math.Abs(Width) + 6, Math.Abs(Height ) + 6);
            }          
			grfx.FillRectangle(Brushes.Blue, Width > 0 ? (EndPoint.X - Width) : EndPoint.X, EndPoint.Y, Math.Abs(Width), 5);
			grfx.FillRectangle(Brushes.Green, Width > 0 ? StartPoint.X : (StartPoint.X + Width), StartPoint.Y, Math.Abs(Width), 5);
			grfx.FillRectangle(Brushes.Yellow, StartPoint.X, Height > 0 ? StartPoint.Y : (StartPoint.Y + Height), 5, Math.Abs(Height));
			grfx.FillRectangle(Brushes.Magenta, EndPoint.X, Height > 0 ? (EndPoint.Y - Height): EndPoint.Y, 5, Math.Abs(Height));
		}
    }
}
