using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Draw.src.Processors
{
    public class SelectionTool: Shape
    {
        public SelectionTool()
        {
            HasBeenInteractedWith = true;
        }
        public bool Contains(Shape shape)
        {
            RectangleF rect = new RectangleF(StartPoint.X < EndPoint.X ? StartPoint.X : EndPoint.X,
                        StartPoint.Y < EndPoint.Y ? StartPoint.Y : EndPoint.Y,
                        Math.Abs(EndPoint.X - StartPoint.X),
                        Math.Abs(EndPoint.Y - StartPoint.Y));
            //check left wall
            if (rect.X < shape.Location.X && rect.X + rect.Width > shape.Location.X
                && (rect.Y > shape.Location.Y && rect.Y < shape.Location.Y + shape.Height
                || rect.Y + rect.Height > shape.Location.Y && rect.Y + rect.Height < shape.Location.Y + shape.Height))


            {
                return true;
            }
            //check right wall
            if (rect.X < shape.Location.X + shape.Width && rect.X + rect.Width > shape.Location.X + shape.Width
                && (rect.Y > shape.Location.Y && rect.Y < shape.Location.Y + shape.Height
                || rect.Y + rect.Height > shape.Location.Y && rect.Y + rect.Height < shape.Location.Y + shape.Height))
            {
                return true;
            }
            //check top wall
            if (rect.Y < shape.Location.Y && rect.Y + rect.Height > shape.Location.Y
                && (rect.X > shape.Location.X && rect.X < shape.Location.X + shape.Width
                || rect.X + rect.Width > shape.Location.X && rect.X + rect.Width < shape.Location.X + shape.Width))
            {
                return true;
            }
            //check bottom wall
            if (rect.Y < shape.Location.Y + shape.Height && rect.Y + rect.Height > shape.Location.Y + shape.Height
                && (rect.X > shape.Location.X && rect.X < shape.Location.X + shape.Width
                || rect.X + rect.Width > shape.Location.X && rect.X + rect.Width < shape.Location.X + shape.Width))
            {
                return true;
            }
            //catch edge case where shape is entirely in the Selection region
            if (rect.Contains(shape.Location))
            {
                return true;
            }
            return false;
        }
        public override void DrawSelf(Graphics grfx)
        {
            base.DrawSelf(grfx);
            grfx.DrawRectangle(new Pen(Color.Black, 2), Location.X, Location.Y, Math.Abs(Width), Math.Abs(Height));
        }
    }
}
