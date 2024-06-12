﻿using Draw.src.Model;
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
        private static int iD;

        #endregion
        public void AddRandomRectangle()
        {
            Random rnd = new Random();
            int x = rnd.Next(100, 1000);
            int y = rnd.Next(100, 600);

            //RectangleShape rect = new RectangleShape(new Rectangle(x,y,100,200), 255);
            //rect.FillColor = Color.White;

            //ShapeList.Add(rect);
        }

        public void AddRandomEllipse()
        {
            Random rnd = new Random();
            int x = rnd.Next(100, 1000);
            int y = rnd.Next(100, 600);
            //EllipseShape ellipse = new EllipseShape(x, y);
            //ellipse.FillColor = Color.YellowGreen;

            //ShapeList.Add(ellipse);
        }

        public void AddRandomSquare()
        {
            Random rnd = new Random();
            int x = rnd.Next(100, 1000);
            int y = rnd.Next(100, 600);

            SquareShape square = new SquareShape(new Rectangle(x, y, 100, 100));
            square.FillColor = Color.Turquoise;

            ShapeList.Add(square);
        }
        public void AddRandomLine()
        {
            Random rnd = new Random();
            PointF startPoint = new PointF(rnd.Next(100, 1000), rnd.Next(100, 600));
            PointF endPoint = new PointF(rnd.Next(100, 1000), rnd.Next(100, 600));

            LineShape line = new LineShape(startPoint, endPoint); // Използваме конструктора с две точки за създаване на линията
            line.FillColor = Color.Red;

            ShapeList.Add(line);
        }
        public Shape ContainsPoint(PointF point)
        {
            for (int i = ShapeList.Count - 1; i >= 0; i--)
            {
                if (ShapeList[i].Contains(point) /*|| ShapeList[i].OutlineContainsPoint(point) || ShapeList[i].RotationRectContains(point)*/)
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
                if (ShapeList[i].OutlineContainsPoint(point))
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
            Console.WriteLine(points[0] + " " + points[1]);*/


            /*PointF[] points = { point, lastLocation };
            shape.Matrix.TransformPoints(points);*/

            /*shape.StartPoint = new PointF(shape.StartPoint.X + Math.Abs(points[0].X) - Math.Abs(points[1].X),
                                        shape.StartPoint.Y + Math.Abs(points[0].Y) - Math.Abs(points[1].Y));
            shape.EndPoint = new PointF(shape.EndPoint.X + Math.Abs(points[0].X) - Math.Abs(points[1].X),
                                        shape.EndPoint.Y + Math.Abs(points[0].Y) - Math.Abs(points[1].Y));*/

            shape.StartPoint = new PointF(shape.StartPoint.X + point.X - lastLocation.X,
                                        shape.StartPoint.Y + point.Y - lastLocation.Y);
            shape.EndPoint = new PointF(shape.EndPoint.X + point.X - lastLocation.X,
                                        shape.EndPoint.Y + point.Y - lastLocation.Y);
            RotateShape(Selection, shape.LastRotationAngle);
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
                    shapes.Add(shape);
                }
            }
            GroupShape group = new GroupShape(shapes);
            if(shapes.Count > 0)
            {
                ShapeList.Add(group);
            }

            foreach (Shape shape in shapes)
            {
                ShapeList.Remove(shape);
            }
            return group;
        }
    }
}
