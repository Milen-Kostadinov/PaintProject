﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Draw.src.Model
{
    using System;
    using System.Collections.Generic;
    using System.Drawing;
    using System.Drawing.Drawing2D;
    using System.Linq;
    using System.Text;

    namespace Draw.src.Model
    {
        [Serializable]
        internal class GroupShape : Shape
        {
            [Serializable]
            private class Proportions 
            {
                float startPointProportionHorizontal;
                float startPointProportionVertical;
                float endPointProportionHorizontal;
                float endPointProportionVertical;
                
                public float StartPointProportionHorizontal
                {
                    get { return startPointProportionHorizontal; }
                    set { startPointProportionHorizontal = value; }
                }
                public float StartPointProportionVertical
                {
                    get { return startPointProportionVertical; }
                    set { startPointProportionVertical = value; }
                }
                public float EndPointProportionHorizontal
                {
                    get { return endPointProportionHorizontal; }
                    set { endPointProportionHorizontal = value; }
                }
                public float EndPointProportionVerical
                {
                    get { return endPointProportionVertical; }
                    set { endPointProportionVertical = value; }
                }
                public Proportions() 
                {                    
                }
            }
            List<Shape> shapes = new List<Shape>();
            List<Proportions> proportions = new List<Proportions>();

            public GroupShape(List<Shape> shapes)
            {
                this.shapes = shapes;
                if (shapes.Count >= 1)
                {
                    StartPoint = shapes[0].Location;
                    EndPoint = shapes[0].Location;
                }
                foreach (Shape shape in shapes)
                {
                    shape.IsSelected = false;
                    if (shape.Location.X < StartPoint.X)
                    {
                        StartPoint = new PointF(shape.Location.X, StartPoint.Y);
                    }
                    if (shape.Location.Y < StartPoint.Y)
                    {
                        StartPoint = new PointF(StartPoint.X, shape.Location.Y);
                    }
                    if (shape.Location.X + shape.Width > EndPoint.X)
                    {
                        EndPoint = new PointF(shape.Location.X + shape.Width, EndPoint.Y);
                    }
                    if (shape.Location.Y + shape.Height > EndPoint.Y)
                    {
                        EndPoint = new PointF(EndPoint.X, shape.Location.Y + shape.Height);
                    }
                }
                Width = EndPoint.X - StartPoint.X;
                Height = EndPoint.Y - StartPoint.Y;
                foreach (Shape shape in shapes)
                {
                    Proportions proportion = new Proportions();                        
                    proportion.StartPointProportionHorizontal = (shape.StartPoint.X - StartPoint.X) / Width;
                    proportion.StartPointProportionVertical = (shape.StartPoint.Y - StartPoint.Y) / Height;
                    proportion.EndPointProportionHorizontal = (EndPoint.X - shape.EndPoint.X) / Width;
                    proportion.EndPointProportionVerical = ( EndPoint.Y - shape.EndPoint.Y) / Height;
                    proportions.Add(proportion);
                }
                Location = StartPoint;

                IsSelected = true;
                HasBeenInteractedWith = true;
            }
            public override bool Contains(PointF point)
            {
                if (new RectangleF(Location.X, Location.Y, Math.Abs(Width), Math.Abs(Height)).Contains(point))

                    return true;
                else
                    return false;
            }
            /* public override void Rotate(float angle)
             {
                 base.Rotate(angle);
                 foreach (Shape shape in shapes) 
                 {
                     shape.Matrix.RotateAt(angle - LastRotationAngle, new PointF(Location.X + Math.Abs(Width) / 2, Location.Y + Math.Abs(Height) / 2));
                 }
             }*/
            public override List<Shape> GetShapes()
            {
                return shapes;
            }
            public override void DrawSelf(Graphics grfx)
            {
                base.DrawSelf(grfx);
                for (int i = 0; i < shapes.Count; i++) 
                {
                    shapes.ElementAt(i).StartPoint = new PointF(StartPoint.X + Width * proportions[i].StartPointProportionHorizontal, StartPoint.Y + Height * proportions[i].StartPointProportionVertical);
                    shapes.ElementAt(i).EndPoint = new PointF(EndPoint.X - Width * proportions[i].EndPointProportionHorizontal, EndPoint.Y - Height * proportions[i].EndPointProportionVerical);
                    Color color;
                    if (OutlineColor != Color.Empty)
                    {
                        color = Color.FromArgb(Opacity, FillColor);
                        shapes.ElementAt(i).FillColor = color;
                    }
                    if (OutlineColor != Color.Empty)
                    {
                        color = Color.FromArgb(Opacity, OutlineColor);
                        shapes.ElementAt(i).OutlineColor = color;
                    }
                    shapes.ElementAt(i).RotationPoint = RotationPoint;
                    shapes.ElementAt(i).LastRotationAngle = this.LastRotationAngle;
                    if (shapes.ElementAt(i).Matrix == null)
                    {
                        shapes.ElementAt(i).Matrix = new Matrix();
                        shapes.ElementAt(i).Matrix.Reset();
                        shapes.ElementAt(i).Matrix.RotateAt(LastRotationAngle, RotationPoint);
                    }
                    else
                    {
                        shapes.ElementAt(i).Matrix.Reset();
                        shapes.ElementAt(i).Matrix.RotateAt(LastRotationAngle, RotationPoint);
                    }
                    shapes.ElementAt(i).DrawSelf(grfx);
                    //Rotate(LastRotationAngle);
                    //new PointF(Location.X + Math.Abs(Width) / 2, Location.Y + Math.Abs(Height) / 2)
                }
            }
        }
    }

}
