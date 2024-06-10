using Draw.src.Model;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Draw.src.Processors
{
    public class GeometricProccesor : DisplayProcessor
    {
        public void ExpandInDirection(PointF point, Shape selection)
        {
            switch (selection.CurrentSelectedSide)
            {
                case SelectedSide.Left: selection.StartPoint = new PointF(point.X, selection.StartPoint.Y); break;
                case SelectedSide.Right: selection.EndPoint = new PointF(point.X, selection.EndPoint.Y); break;    
                case SelectedSide.Top: selection.StartPoint = new PointF (selection.StartPoint.X, point.Y); break;
                case SelectedSide.Bottom: selection.EndPoint = new PointF(selection.EndPoint.X, point.Y); break;
                case SelectedSide.TopLeftCorner: selection.StartPoint = point; break;
                case SelectedSide.BottomRightCorner: selection.EndPoint = point; break;
                case SelectedSide.TopRightCorner: selection.StartPoint = new PointF(selection.StartPoint.X, point.Y);
                                                    selection.EndPoint = new PointF(point.X, selection.EndPoint.Y); break;
                case SelectedSide.BottomLeftCorner: selection.StartPoint = new PointF(point.X, selection.StartPoint.Y);
                                                    selection.EndPoint = new PointF(selection.EndPoint.X, point.Y); break; 
                default: Console.WriteLine("Selected side is null"); break;
            }
        }
    }
}
