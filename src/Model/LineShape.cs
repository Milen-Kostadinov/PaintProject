using System;
using System.Drawing;

namespace Draw.src.Model
{
    internal class LineShape : Shape
    {
        public LineShape()
        {
            FillColor = Color.Red;
            FillOpacity = 255;
        }
        public override bool Contains(PointF point)
        {
            // Проста проверка дали точката е близо до линията
            return DistancePointToLine(point, Location, new PointF(Location.X + Width, Location.Y + Height)) <= 5;
        }

        public override void DrawSelf(Graphics grfx)
        {
            base.DrawSelf(grfx);
            // Рисуване на линията с правилните крайща
            grfx.DrawLine(new Pen(FillColor, 3), StartPoint, EndPoint);
        }

        private float DistancePointToLine(PointF point, PointF lineStart, PointF lineEnd)
        {
            // Изчисляване на разстоянието от точката до линията
            float dx = lineEnd.X - lineStart.X;
            float dy = lineEnd.Y - lineStart.Y;
            float lengthSquared = dx * dx + dy * dy;

            if (lengthSquared == 0)
                return (float)Math.Sqrt((point.X - lineStart.X) * (point.X - lineStart.X) + (point.Y - lineStart.Y) * (point.Y - lineStart.Y));

            float t = ((point.X - lineStart.X) * dx + (point.Y - lineStart.Y) * dy) / lengthSquared;
            t = Math.Max(0, Math.Min(1, t));
            float closestX = lineStart.X + t * dx;
            float closestY = lineStart.Y + t * dy;

            float distance = (float)Math.Sqrt((point.X - closestX) * (point.X - closestX) + (point.Y - closestY) * (point.Y - closestY));

            return distance;
        }
    }
}