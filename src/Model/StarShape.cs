using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Draw.src.Model
{
    internal class StarShape : Shape
    {
        #region Constructor
        public StarShape()
        {
            FillColor = Color.White;
            FillOpacity = 100;
        }

        #endregion
        public override bool Contains(PointF point)
        {
            if (base.Contains(point))
                return true;
            else
                return false;
        }
        public override void DrawSelf(Graphics grfx)
        {
            base.DrawSelf(grfx);
            PointF[] points = { new PointF(Location.X  + Width * (float)0.5, Location.Y), new PointF(Location.X, Location.Y + Location.Y * (float)0.5)};

            Color color = Color.FromArgb(FillOpacity, FillColor);
            grfx.FillPolygon(new SolidBrush(color), points);

            color = Color.FromArgb(OutlineOpacity, OutlineColor);
            grfx.DrawRectangle(new Pen(color, OutlineWidth), Location.X, Location.Y, this.Width, this.Height);

        }
    }
}

