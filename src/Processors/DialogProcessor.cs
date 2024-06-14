using Draw.src.Model;
using Draw.src.Model.Draw.src.Model;
using Draw.src.Processors;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace Draw
{
    /// <summary>
    /// Класът, който ще бъде използван при управляване на диалога.
    /// </summary>
    public class DialogProcessor : GeometricProccesor
    {
        #region Constructor

        public DialogProcessor()
        {
        }

        #endregion

        #region Properties
        private bool isDragging;
        public bool IsDragging
        {
            get { return isDragging; }
            set { isDragging = value; }
        }
        private bool isResizing;
        public bool IsResizing
        {
            get { return isResizing; }
            set { isResizing = value; }
        }
        private bool isRotating;
        public bool IsRotating
        {
            get { return isRotating; }
            set { isRotating = value; }
        }
        private bool isSelecting;
        public bool IsSelecting
        {
            get { return isSelecting; }
            set { isSelecting = value; }
        }
        private bool isDrawing;
        public bool IsDrawing
        {
            set { isDrawing = value; }
            get { return isDrawing; }
        }

        private PointF lastLocation;
        public PointF LastLocation
        {
            get { return lastLocation; }
            set { lastLocation = value; }
        }
        private SelectionTool selectionTool = new SelectionTool();
        public SelectionTool SelectionTool
        {
            get { return selectionTool; }
            set { selectionTool = value; }
        }
        #endregion
        public void AddShape(ShapesEnum shapeClass)
        {
            if (Selection != null) Selection.IsSelected = false;
            Shape shape;
            switch (shapeClass) 
            {
                case ShapesEnum.Star: shape = new StarShape(); break;
                case ShapesEnum.Arrow: shape = new ArrowShape(); break;
                case ShapesEnum.Rectangle: shape = new RectangleShape(); break;
                case ShapesEnum.Ellipse: shape = new EllipseShape(); break; 
                case ShapesEnum.Line: shape = new LineShape(); break;
                case ShapesEnum.IsoscelesTriangle: shape = new IsoscelesTriangleShape(); break;
                case ShapesEnum.RrightTriangle: shape = new RightTriangleShape(); break;
                case ShapesEnum.Hexagon: shape = new HexagonShape(); break;
                case ShapesEnum.Pentagon: shape = new PentagonShape(); break;
                case ShapesEnum.Diamond: shape = new DiamondShape(); break;
                default: shape = null; break;
            }
            ShapeList.Add(shape);
            Selection = shape;
        }
        public Shape ContainsPoint(PointF point)
        {
            for (int i = ShapeList.Count - 1; i >= 0; i--)
            {
                if (ShapeList[i].Contains(RotatePointInShapePlane(point, ShapeList[i])))
                {
                    ShapeList[i].FillColor = Color.Red;

                    return ShapeList[i];
                }
            }
            return null;
        }
        public bool OutlineContainsPoint(PointF point)
        {
            for (int i = 0; i < ShapeList.Count; i++)
            {
                if (ShapeList[i].OutlineContainsPoint(RotatePointInShapePlane(point, ShapeList[i])))
                {
                    return true;
                }
            }
            return false;
        }
        public void TranslateToPoint(PointF point, Shape shape)
        {
            /*Console.WriteLine(lastLocation + " " + point);
            PointF[] points = { point, lastLocation };
            Matrix matrix = new Matrix();
            matrix.Rotate(90);
            matrix.TransformPoints(points);
            Console.WriteLine(point + " " + points[1]);*/


            /*PointF[] points = { point, lastLocation };
            shape.Matrix.TransformPoints(points);*/

            /*shape.StartPoint = new PointF(shape.StartPoint.X + Math.Abs(point.X) - Math.Abs(points[1].X),
                                        shape.StartPoint.Y + Math.Abs(point.Y) - Math.Abs(points[1].Y));
            shape.EndPoint = new PointF(shape.EndPoint.X + Math.Abs(point.X) - Math.Abs(points[1].X),
                                        shape.EndPoint.Y + Math.Abs(point.Y) - Math.Abs(points[1].Y));*/

            RotateShape(Selection, shape.LastRotationAngle);
            shape.StartPoint = new PointF(shape.StartPoint.X + point.X - lastLocation.X,
                                        shape.StartPoint.Y + point.Y - lastLocation.Y);
            shape.EndPoint = new PointF(shape.EndPoint.X + point.X - lastLocation.X,
                                        shape.EndPoint.Y + point.Y - lastLocation.Y);
        }
        public void TranslateTo(PointF point)
        {
            TranslateToPoint(point, Selection);
            lastLocation = point;
        }
        public void SelectElements()
        {
            foreach (Shape shape in ShapeList)
            {
                shape.IsSelected = false;
                if (SelectionTool.Contains(shape) && shape != SelectionTool)
                {
                    shape.IsSelected = true;
                }
            }
        }
        public Shape CreateGroup()
        {
            List<Shape> shapes = new List<Shape>();

            foreach (Shape shape in ShapeList)
            {
                if (SelectionTool.Contains(shape) && shape != SelectionTool)
                {
                    shape.IsSelected = true;
                    shapes.Add(shape);
                }
            }
            GroupShape group = new GroupShape(shapes);
            if(shapes.Count > 1)
            {
                ShapeList.Add(group);
                foreach (Shape shape in shapes)
                {
                    ShapeList.Remove(shape);
                }
            }
            return group;
        }
        public Shape CreateSelection()
        {
            List<Shape> shapes = new List<Shape>();

            foreach (Shape shape in ShapeList)
            {
                if (SelectionTool.Contains(shape) && shape != SelectionTool)
                {
                    shape.IsSelected = true;
                    shapes.Add(shape);
                }
            }
            SelectionShape selection = new SelectionShape(shapes);
            if (shapes.Count > 1)
            {
                ShapeList.Add(selection);
                foreach (Shape shape in shapes)
                {
                    ShapeList.Remove(shape);
                }
            }
            return selection;
        }
        public void DisbandSelection() 
        {
            Selection.GetShapes().ForEach(shape => { ShapeList.Add(shape); shape.IsSelected = false; });
            ShapeList.Remove(Selection);
        }
        public PointF RotatePointInShapePlane(PointF point, Shape shape) 
        {
            PointF[] points = { point };
            Matrix matrix = shape.Matrix.Clone();
            matrix.Invert();
            matrix.TransformPoints(points);
            matrix.Dispose();
            return points[0];
        }
    }
}
