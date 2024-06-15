using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;

namespace Draw.src.Model
{
    [Serializable]
    internal class ArrowShape : Shape
    {
        private PointF[] points;
        #region Constructor
        public ArrowShape()
        {
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
            PointF[] points1 = { new PointF(StartPoint.X + Width * 0.55f, StartPoint.Y),
                new PointF(StartPoint.X + Width * 0.55f, StartPoint.Y + Height * 0.25f),
                new PointF(StartPoint.X, StartPoint.Y + Height * 0.25f),
                new PointF(StartPoint.X, StartPoint.Y + Height * 0.75f),
                new PointF(StartPoint.X + Width * 0.55f, StartPoint.Y + Height * 0.75f),
                new PointF(StartPoint.X + Width * 0.55f, StartPoint.Y + Height),
                new PointF(StartPoint.X + Width, StartPoint.Y + Height * 0.5f)
            };
            points = points1;
        }
        public override void DrawSelf(Graphics grfx)
        {
            base.DrawSelf(grfx);
            CalcPoints();
            Color color = Color.FromArgb(Opacity, FillColor);
            grfx.FillPolygon(new SolidBrush(color), points);
            color = Color.FromArgb(Opacity, OutlineColor);
            grfx.DrawPolygon(new Pen(color, OutlineWidth), points);
        }
    }
}

