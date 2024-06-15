using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using static System.Collections.Specialized.BitVector32;

namespace Draw.src.Model
{
    [Serializable]
    internal class EllipseShape : Shape
    {
        #region Constructor

        public EllipseShape(PointF startPoint, PointF endPoint): base(startPoint, endPoint)
        {
            StartPoint = startPoint;
            EndPoint = endPoint;
        }

        public EllipseShape(PointF startPoint, float height, float width)
        {
            Location = startPoint;
            Height = height;
            Width = width;
        }

        public EllipseShape()
        {
        }

        #endregion

        public override bool Contains(PointF point)
        {
            /*PointF[] points = { point };
            Matrix.TransformPoints(points);*/
            float cx = base.Location.X + Math.Abs(Width) / 2;
            float cy = base.Location.Y + Math.Abs(Height) / 2;
            float rx = Math.Abs(Width) / 2;
            float ry = Math.Abs(Height) / 2;
            float sth = (point.X - cx) / rx;
            float sth2 = (point.Y - cy)/ ry;
            float left = sth*sth;
            float right = sth2*sth2;
            float result = (left + right);
            return result <= 1 ? true: false;
            
        }
        public override void DrawSelf(Graphics grfx)
        {
            base.DrawSelf(grfx);

            Color color = Color.FromArgb(Opacity, FillColor);
            grfx.FillEllipse(new SolidBrush(color), Location.X, Location.Y, Math.Abs(Width), Math.Abs(Height));
            color = Color.FromArgb(Opacity, OutlineColor);
            grfx.DrawEllipse(new Pen(color, OutlineWidth), Location.X, Location.Y, Math.Abs(Width), Math.Abs(Height));
        }
        
    }
}
