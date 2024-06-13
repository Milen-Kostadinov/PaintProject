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
            PointF[] points = { new PointF(Location.X + Width * (float)0.5, Location.Y),
                new PointF(Location.X, Location.Y + Height * (float)0.5),
                new PointF(Location.X + Width * (float)0.5, Location.Y + Height),
                new PointF(Location.X + Width, Location.Y + Height * (float)0.5)};
            Color color = Color.FromArgb(FillOpacity, FillColor);
            grfx.FillPolygon(new SolidBrush(Color.AliceBlue), points);
        }
    }
}

