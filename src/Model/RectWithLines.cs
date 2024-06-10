using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Draw.src.Model
{
    internal class RectWithLines : Shape
    {
        #region Constructor

        public RectWithLines(RectangleF rect)
        {
        }
        public RectWithLines(RectangleF rect, int fillOpacity)
        {
            this.FillOpacity = fillOpacity;
        }

        public RectWithLines(RectangleShape rectangle) : base(rectangle)
        {
        }

        #endregion
        public override bool Contains(PointF point)
        {
            if (base.Contains(point))
                // Проверка дали е в обекта само, ако точката е в обхващащия правоъгълник.
                // В случая на правоъгълник - директно връщаме true
                return true;
            else
                // Ако не е в обхващащия правоъгълник, то неможе да е в обекта и => false
                return false;
        }
        public override void DrawSelf(Graphics grfx)
        {
            base.DrawSelf(grfx);

            Color color = Color.FromArgb(FillOpacity, FillColor);
            grfx.FillRectangle(new SolidBrush(Color.Cyan), Location.X, Location.Y, Width, Height);
            grfx.DrawLine(new Pen(Color.Red, 15), Location.X, Location.Y + 50, Location.X + Width, Location.Y + 50);
            grfx.DrawLine(new Pen(Color.Green, 15), Location.X, Location.Y + 150, Location.X + Width, Location.Y + 150);
            grfx.DrawLine(new Pen(Color.Blue, 15), Location.X, Location.Y + 250, Location.X + Width, Location.Y + 250);

            color = Color.FromArgb(OutlineOpacity, OutlineColor);
            grfx.DrawRectangle(new Pen(color, OutlineWidth), Location.X, Location.Y, this.Width, this.Height);
        }
    }
}
