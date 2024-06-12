using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

namespace Draw.src.Model
{
    internal class EllipseShape : Shape
    {
        #region Constructor

        public EllipseShape(PointF startPoint, PointF endPoint): base(startPoint, endPoint)
        {
            StartPoint = startPoint;
            EndPoint = endPoint;
            FillColor = Color.Red;
            FillOpacity = 255;
        }

        public EllipseShape(PointF startPoint, float height, float width)
        {
            Location = startPoint;
            Height = height;
            Width = width;
        }

        public EllipseShape()
        {
            FillColor = Color.White;
            FillOpacity = 255;
        }

        #endregion

        public override bool Contains(PointF point)
        {
            PointF[] points = { point };
            Matrix.TransformPoints(points);
            float cx = base.Location.X + Math.Abs(Width) / 2;
            float cy = base.Location.Y + Math.Abs(Height) / 2;
            float rx = Math.Abs(Width) / 2;
            float ry = Math.Abs(Height) / 2;
            float sth = (points[0].X - cx) / rx;
            float sth2 = (points[0].Y - cy)/ ry;
            float left = sth*sth;
            float right = sth2*sth2;
            float result = (left + right);
            return result <= 1 ? true: false;
            
        }
        public override void DrawSelf(Graphics grfx)
        {
            base.DrawSelf(grfx);

            grfx.FillEllipse(new SolidBrush(FillColor), Location.X, Location.Y, Math.Abs(Width), Math.Abs(Height));
            grfx.DrawEllipse(Pens.Black, Location.X, Location.Y, Math.Abs(Width), Math.Abs(Height));
        }
        
    }
}
