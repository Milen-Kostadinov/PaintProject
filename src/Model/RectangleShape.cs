using System;
using System.Drawing;
using System.Net;

namespace Draw
{
	public class RectangleShape : Shape
	{
		#region Constructor
        public RectangleShape()
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

			Color color = Color.FromArgb(FillOpacity, FillColor);
            grfx.FillRectangle(new SolidBrush(color),Location.X, Location.Y, Math.Abs(Width), Math.Abs(Height));

			color = Color.FromArgb(OutlineOpacity, OutlineColor);
			grfx.DrawRectangle(new Pen(color, OutlineWidth),Location.X, Location.Y, this.Width, this.Height);
			
		}
	}
}
