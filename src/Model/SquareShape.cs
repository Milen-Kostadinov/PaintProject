using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

namespace Draw.src.Model
{
    internal class SquareShape : Shape
    {
        #region Constructor

        public SquareShape(RectangleF rect)
        {
        }

        public SquareShape(SquareShape square) : base(square)
        {
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

            grfx.FillRectangle(new SolidBrush(FillColor), Location.X, Location.Y, this.Width, this.Height);
            grfx.DrawRectangle(Pens.Black, Location.X, Location.Y, this.Width, this.Height);

        }

    }
}
