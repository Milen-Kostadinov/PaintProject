using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Draw.src.Model
{
    [Serializable]
    internal class SelectionShape : Shape
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
        private List<Shape> shapes = new List<Shape>();
        private List<Proportions> proportions = new List<Proportions>();

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
                if (shape.Matrix != null)
                {
                    PointF[] points = { point };
                    Matrix matrix = shape.Matrix.Clone();
                    matrix.Invert();
                    matrix.TransformPoints(points);
                    matrix.Dispose();
                    if (shape.OutlineContainsPoint(points[0]))
                    {
                        CurrentSelectedSide = shape.CurrentSelectedSide;
                        return true;
                    }
                }
            }
            return false;
        }
        public override bool RotationRectContains(PointF point)
        {
            foreach (Shape shape in shapes)
            {
                PointF[] points = { point };
                if (shape.Matrix != null)
                {
                    Matrix matrix = shape.Matrix.Clone();
                    matrix.Invert();
                    matrix.TransformPoints(points);
                    matrix.Dispose();
                    if (shape.RotationRectContains(points[0]))
                    {
                        return true;
                    }
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
            for (int i = 0; i < shapes.Count; i++)
            {
                shapes.ElementAt(i).StartPoint = new PointF(StartPoint.X + proportions[i].StartPointProportionHorizontal, StartPoint.Y + proportions[i].StartPointProportionVertical);
                shapes.ElementAt(i).EndPoint = new PointF(EndPoint.X - proportions[i].EndPointProportionHorizontal, EndPoint.Y - proportions[i].EndPointProportionVerical);
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
                shapes.ElementAt(i).IsSelected = true;
                shapes.ElementAt(i).DrawSelf(grfx);
                //Rotate(LastRotationAngle);
                //new PointF(Location.X + Math.Abs(Width) / 2, Location.Y + Math.Abs(Height) / 2)
            }
        }
    }
}
