using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace Draw.src.Model
{
    internal class IsoscelesTriangleShape : Shape
    {
        private PointF[] points;
        #region Constructor
        public IsoscelesTriangleShape()
        {
            FillColor = Color.White;
            FillOpacity = 100;
        }

        #endregion
        public override bool Contains(PointF point)
        {
            if (base.Contains(point))
            {
                //contains formula for random polygons
                bool c = false;
                int i, j = 0;
                for (i = 0, j = points.Count() - 1; i < points.Count(); j = i++)
                {
                    if (((points[i].Y > point.Y) != (points[j].Y > point.Y)) &&
                     (point.X < (points[j].X - points[i].X) * (point.Y - points[i].Y) / (points[j].Y - points[i].Y) + points[i].X))
                        c = !c;
                }
                return c;
            }
            else
                return false;
        }
        private void CalcPoints()
        {
            PointF[] points1 = { new PointF(StartPoint.X + Width / 2, StartPoint.Y), new PointF(StartPoint.X, EndPoint.Y), EndPoint };
            points = points1;
        }
        public override void DrawSelf(Graphics grfx)
        {
            base.DrawSelf(grfx);
            CalcPoints();
            Color color = Color.FromArgb(FillOpacity, FillColor);
            grfx.FillPolygon(new SolidBrush(Color.AliceBlue), points);
        }
    }
}

