using System;
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
        internal class GroupShape : Shape
        {
            List<Shape> shapes = new List<Shape>();
            List<float> proportions = new List<float>();

            public GroupShape(List<Shape> shapes)
            {
                this.shapes = shapes;
                Console.WriteLine(shapes.Count);
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
                    float proportion = (shape.StartPoint.X - StartPoint.X) / Width;
                    proportions.Add(proportion);
                    proportion = (shape.StartPoint.Y - StartPoint.Y) / Height;
                    proportions.Add(proportion);
                    proportion = (EndPoint.X - shape.EndPoint.X) / Width;
                    proportions.Add(proportion);
                    proportion = ( EndPoint.Y - shape.EndPoint.Y) / Height;
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
            public override void DrawSelf(Graphics grfx)
            {
                /*Console.WriteLine("Start: " + StartPoint.ToString());
                Console.WriteLine("End: " + EndPoint.ToString());*/
                base.DrawSelf(grfx);
                for (int i = 0; i < shapes.Count; i++) 
                {
                    shapes.ElementAt(i).StartPoint = new PointF(StartPoint.X + Width * proportions[i*4], StartPoint.Y + Height * proportions[i*4 + 1]);
                    shapes.ElementAt(i).EndPoint = new PointF(EndPoint.X - Width * proportions[i*4 + 2], EndPoint.Y - Height * proportions[i*4 + 3]);
                    shapes.ElementAt(i).DrawSelf(grfx);
                }
                grfx.DrawRectangle(Pens.Black, Location.X, Location.Y, Math.Abs(Width), Math.Abs(Height));
            }
        }
    }

}
