using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Draw.src.Model
{
    internal class SelectionShape : Shape
    {
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

        public SelectionShape(List<Shape> shapes)
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
                proportion.StartPointProportionHorizontal = (shape.StartPoint.X - StartPoint.X);
                proportion.StartPointProportionVertical = (shape.StartPoint.Y - StartPoint.Y);
                proportion.EndPointProportionHorizontal = (EndPoint.X - shape.EndPoint.X);
                proportion.EndPointProportionVerical = (EndPoint.Y - shape.EndPoint.Y);
                proportions.Add(proportion);
            }
            Location = StartPoint;

            IsSelected = true;
            HasBeenInteractedWith = true;
        }
        public override bool Contains(PointF point)
        {
            foreach (Shape shape in shapes) 
            {
                if (shape.Contains(point)) return true;
            }
            return false;
        }
        public override bool OutlineContainsPoint(PointF point)
        {
            foreach (Shape shape in shapes)
            {
                if (shape.OutlineContainsPoint(point)) 
                {
                    this.CurrentSelectedSide = shape.CurrentSelectedSide;
                    return true;
                } 
            }
            return false;
        }
        public override bool RotationRectContains(PointF point)
        {
            foreach (Shape shape in shapes)
            {
                if (shape.RotationRectContains(point))
                {
                    this.CurrentSelectedSide = shape.CurrentSelectedSide;
                    return true;
                }
            }
            return false;
        }
        public override List<Shape> GetShapes()
        {
            return shapes;
        }
        public override void DrawSelf(Graphics grfx)
        {
            Color color = Color.FromArgb(Opacity, FillColor);
            for (int i = 0; i < shapes.Count; i++)
            {
                shapes.ElementAt(i).StartPoint = new PointF(StartPoint.X + proportions[i].StartPointProportionHorizontal, StartPoint.Y + proportions[i].StartPointProportionVertical);
                shapes.ElementAt(i).EndPoint = new PointF(EndPoint.X - proportions[i].EndPointProportionHorizontal, EndPoint.Y - proportions[i].EndPointProportionVerical);
                shapes.ElementAt(i).FillColor = color;
                shapes.ElementAt(i).RotationPoint = new PointF(shapes.ElementAt(i).Location.X + shapes.ElementAt(i).Width / 2, shapes.ElementAt(i).Location.Y + shapes.ElementAt(i).Height / 2);
                shapes.ElementAt(i).LastRotationAngle = this.LastRotationAngle;
                shapes.ElementAt(i).IsSelected = true;
                shapes.ElementAt(i).Matrix.Reset();
                shapes.ElementAt(i).Matrix.RotateAt(LastRotationAngle, RotationPoint);
                shapes.ElementAt(i).DrawSelf(grfx);
                //Rotate(LastRotationAngle);
                //new PointF(Location.X + Math.Abs(Width) / 2, Location.Y + Math.Abs(Height) / 2)
            }
        }
    }
}
