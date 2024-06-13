using Draw.src.Model;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Draw.src.Processors
{
    public class GeometricProccesor : DisplayProcessor
    {
        public void ExpandInDirection(PointF point)
        {
            PointF[] points = { point };
            Matrix matrix = Selection.Matrix.Clone();
            matrix.Invert();
            matrix.TransformPoints(points);
            switch (Selection.CurrentSelectedSide)
            {
                case SelectedSide.Left: Selection.StartPoint = new PointF(points[0].X, Selection.StartPoint.Y); break;
                case SelectedSide.Right: Selection.EndPoint = new PointF(points[0].X, Selection.EndPoint.Y); break;    
                case SelectedSide.Top: Selection.StartPoint = new PointF (Selection.StartPoint.X, points[0].Y); break;
                case SelectedSide.Bottom: Selection.EndPoint = new PointF(Selection.EndPoint.X, points[0].Y); break;
                case SelectedSide.TopLeftCorner: Selection.StartPoint = points[0]; break;
                case SelectedSide.BottomRightCorner: Selection.EndPoint = points[0]; break;
                case SelectedSide.TopRightCorner: Selection.StartPoint = new PointF(Selection.StartPoint.X, points[0].Y);
                                                    Selection.EndPoint = new PointF(points[0].X, Selection.EndPoint.Y); break;
                case SelectedSide.BottomLeftCorner: Selection.StartPoint = new PointF(points[0].X, Selection.StartPoint.Y);
                                                    Selection.EndPoint = new PointF(Selection.EndPoint.X, points[0].Y); break; 
                default: Console.WriteLine("Selected side is null"); break;
            }
        }
        public float CalcAngle(PointF point)
        {
            return 180 - (float)(Math.Atan2(point.X - (Selection.Location.X + Math.Abs(Selection.Width) / 2), point.Y - (Selection.Location.Y + Math.Abs(Selection.Height) / 2)) * 180 / Math.PI);
        }
        public void RotateShape(Shape selection, float angle)
        {
            selection.Matrix.Reset();
            selection.RotationPoint = new PointF(selection.Location.X + Math.Abs(selection.Width) / 2, selection.Location.Y + Math.Abs(selection.Height) / 2);
            selection.Matrix.RotateAt(angle, new PointF(selection.Location.X + Math.Abs(selection.Width) / 2, selection.Location.Y + Math.Abs(selection.Height) / 2));
            selection.LastRotationAngle = angle;
        }
    }
}
