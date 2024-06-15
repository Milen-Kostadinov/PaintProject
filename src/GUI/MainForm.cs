using Draw.src.Model;
using Draw.src.Processors;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization;
using System.Windows.Forms;

namespace Draw
{
	public partial class MainForm : Form
	{
        int outlineWidth = 3;

        private DialogProcessor dialogProcessor = new DialogProcessor();
		
		public MainForm()
		{
			InitializeComponent();

            fillColor.BackColor = Color.White;
            outlineColor.BackColor = Color.Black;

            //
            // TODO: Add constructor code after the InitializeComponent() call.
            //
        }

		void ExitToolStripMenuItemClick(object sender, EventArgs e)
		{
			Close();
		}
		
		void ViewPortPaint(object sender, PaintEventArgs e)
		{
			dialogProcessor.ReDraw(sender, e);
		}
        void ViewPortMouseDown(object sender, System.Windows.Forms.MouseEventArgs e)
		{
            /*EllipseShape elipse = new EllipseShape(new PointF(200, 200), new PointF(300, 300));
            elipse.GroupId = 1;
            elipse.HasBeenInteractedWith = true;
            dialogProcessor.ShapeList.Add(elipse);*/
            viewPort.Invalidate();
            if (dialogProcessor.Selection != null && !dialogProcessor.Selection.HasBeenInteractedWith)
            {
                dialogProcessor.Selection.StartPoint = e.Location;
                dialogProcessor.Selection.EndPoint = e.Location;
                dialogProcessor.Selection.FillColor = fillColor.BackColor;
                dialogProcessor.Selection.OutlineColor = outlineColor.BackColor;
                dialogProcessor.Selection.OutlineWidth = outlineWidth;
                dialogProcessor.IsDrawing = true;
                return;
            }
            if (mouseButton.Checked) {
                if (dialogProcessor.Selection != null && dialogProcessor.Selection.RotationRectContains(dialogProcessor.RotatePointInShapePlane(e.Location, dialogProcessor.Selection)))
                {
                    dialogProcessor.Commands.Push(new Command(dialogProcessor.Selection, ShapeCloner.Clone(dialogProcessor.Selection), CommandsEnum.Rotate));
                    dialogProcessor.IsRotating = true;
                    return;
                }
                if (dialogProcessor.Selection != null && dialogProcessor.Selection.OutlineContainsPoint(dialogProcessor.RotatePointInShapePlane(e.Location, dialogProcessor.Selection))) 
				{
                    dialogProcessor.IsResizing = true;
                    return;
                }
                if ((dialogProcessor.ContainsPoint(e.Location) == null && dialogProcessor.Selection != null) || (dialogProcessor.ContainsPoint(e.Location) != dialogProcessor.Selection && dialogProcessor.Selection != null)) 
                {
                    dialogProcessor.Selection.IsSelected = false;
                }
                if ((dialogProcessor.ContainsPoint(e.Location) == null || (dialogProcessor.Selection != null && dialogProcessor.Selection != dialogProcessor.ContainsPoint(e.Location))) && dialogProcessor.Selection != null && dialogProcessor.Selection.GetType().Name.Equals("SelectionShape"))
                {
                    dialogProcessor.DisbandSelection();
                }
                dialogProcessor.Selection = dialogProcessor.ContainsPoint(e.Location);
                if(dialogProcessor.Selection == null)
                {
                    dialogProcessor.IsSelecting = true;
                    dialogProcessor.SelectionTool.StartPoint = e.Location;
                    dialogProcessor.SelectionTool.EndPoint = e.Location;
                    dialogProcessor.ShapeList.Add(dialogProcessor.SelectionTool);
                }
				if (dialogProcessor.Selection != null)
                {
                    trackBar1.Value = (int)Math.Round(dialogProcessor.Selection.Opacity / 2.55);
                    dialogProcessor.Selection.IsSelected = true;                  
					statusBar.Items[0].Text = "Последно действие: Селекция на примитив";
					dialogProcessor.IsDragging = true;
                    dialogProcessor.Commands.Push(new Command(dialogProcessor.Selection, ShapeCloner.Clone(dialogProcessor.Selection), CommandsEnum.Translate));
                    dialogProcessor.LastLocation = e.Location;
				}
            }
            if (paintBucket.Checked && dialogProcessor.ContainsPoint(e.Location) != null)
            {
                dialogProcessor.Commands.Push(new Command(dialogProcessor.Selection, ShapeCloner.Clone(dialogProcessor.Selection), CommandsEnum.ChangeColor));
                dialogProcessor.ContainsPoint(e.Location).FillColor = fillColor.BackColor;
                dialogProcessor.ContainsPoint(e.Location).OutlineColor = outlineColor.BackColor;
            }
            if (colorPickTool.Checked) 
            {
                outlineColor.BackColor = dialogProcessor.ContainsPoint(e.Location).OutlineColor;
                fillColor.BackColor = dialogProcessor.ContainsPoint(e.Location).FillColor;
            }
        }
        void ViewPortMouseMove(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            if (dialogProcessor.Selection != null && dialogProcessor.Selection.RotationRectContains(dialogProcessor.RotatePointInShapePlane(e.Location, dialogProcessor.Selection)))
            {
                Cursor = Cursors.Hand;
            }
            else
            {
                Cursor = Cursors.Default;
            }
            if (!dialogProcessor.IsResizing && dialogProcessor.Selection != null && dialogProcessor.Selection.OutlineContainsPoint(dialogProcessor.RotatePointInShapePlane(e.Location, dialogProcessor.Selection)))
            {
                changeCursor();
            }
            if (dialogProcessor.IsRotating)
            {
                dialogProcessor.RotateShape(dialogProcessor.Selection, dialogProcessor.CalcAngle(e.Location));
                viewPort.Invalidate();
            }
            if (dialogProcessor.IsDrawing)
            {
                dialogProcessor.Selection.EndPoint = e.Location;
                viewPort.Invalidate();
            }
			if (dialogProcessor.IsSelecting) 
			{
                dialogProcessor.SelectionTool.EndPoint = e.Location;
				dialogProcessor.SelectElements();
                viewPort.Invalidate();
            }
			if (dialogProcessor.IsResizing) 
			{
                changeCursor();
				dialogProcessor.ExpandInDirection(e.Location);
                viewPort.Invalidate();
            }
			else if (dialogProcessor.IsDragging) {
				if (dialogProcessor.Selection != null) statusBar.Items[0].Text = "Последно действие: Влачене";
				dialogProcessor.TranslateTo(e.Location);
                viewPort.Invalidate();
            }
        }

        public void changeCursor()
        {
            if (dialogProcessor.Selection.CurrentSelectedSide == SelectedSide.Left || dialogProcessor.Selection.CurrentSelectedSide == SelectedSide.Right)
            {
                Cursor.Current = Cursors.SizeWE;
            }
            if (dialogProcessor.Selection.CurrentSelectedSide == SelectedSide.Top || dialogProcessor.Selection.CurrentSelectedSide == SelectedSide.Bottom)
            {
                Cursor.Current = Cursors.SizeNS;
            }
            if (dialogProcessor.Selection.CurrentSelectedSide == SelectedSide.TopLeftCorner || dialogProcessor.Selection.CurrentSelectedSide == SelectedSide.BottomRightCorner)
            {
                Cursor.Current = Cursors.SizeNWSE;
            }
            if (dialogProcessor.Selection.CurrentSelectedSide == SelectedSide.TopRightCorner || dialogProcessor.Selection.CurrentSelectedSide == SelectedSide.BottomLeftCorner)
            {
                Cursor.Current = Cursors.SizeNESW;
            }

        }
		void ViewPortMouseUp(object sender, System.Windows.Forms.MouseEventArgs e)
		{
            if (dialogProcessor.IsDrawing)
            {
                dialogProcessor.Selection.EndPoint = e.Location;
                dialogProcessor.Selection.HasBeenInteractedWith = true;
                dialogProcessor.Selection.IsSelected = true;

                dialogProcessor.Commands.Push(new Command(dialogProcessor.Selection, ShapeCloner.Clone(dialogProcessor.Selection), CommandsEnum.Add));
            }
            if (dialogProcessor.IsSelecting)
            {
                dialogProcessor.Selection = dialogProcessor.CreateSelection();
				dialogProcessor.ShapeList.Remove(dialogProcessor.SelectionTool);
                viewPort.Invalidate();
            }
            if (dialogProcessor.IsResizing)
            {
                //dialogProcessor.Selection.FixPoints();
            }
            if (dialogProcessor.IsDragging)
            {
            }
            dialogProcessor.IsResizing = false;
			dialogProcessor.IsDragging = false;
            dialogProcessor.IsDrawing = false;
            dialogProcessor.IsRotating = false;
            dialogProcessor.IsSelecting = false;
            viewPort.Invalidate();
        }
        #region AddShapeButtons
        private void rectangleButton_Click(object sender, EventArgs e)
        {
            dialogProcessor.AddShape(ShapesEnum.Rectangle, fillColor.BackColor);
            statusBar.Items[0].Text = "Последно действие: Рисуване на правоъгълник";
        }
        #region addShape
        private void elipseButton_Click(object sender, EventArgs e)
        {
            dialogProcessor.AddShape(ShapesEnum.Ellipse, fillColor.BackColor);
        }
        private void sametriangleButton_Click(object sender, EventArgs e)
        {
            dialogProcessor.AddShape(ShapesEnum.IsoscelesTriangle, fillColor.BackColor);
        }
        private void rightTriangleButton_Click(object sender, EventArgs e)
        {
            dialogProcessor.AddShape(ShapesEnum.RrightTriangle, fillColor.BackColor);
        }
        private void diamondButton_Click(object sender, EventArgs e)
        {
            dialogProcessor.AddShape(ShapesEnum.Diamond, fillColor.BackColor);
        }
        private void lineButton_Click(object sender, EventArgs e)
        {
            dialogProcessor.AddShape(ShapesEnum.Line, fillColor.BackColor);
        }
        private void pentagonButton_Click(object sender, EventArgs e)
        {
            dialogProcessor.AddShape(ShapesEnum.Pentagon, fillColor.BackColor);
        }
        private void hexagonButton_Click(object sender, EventArgs e)
        {
            dialogProcessor.AddShape(ShapesEnum.Hexagon, fillColor.BackColor);
        }
        private void starButton_Click(object sender, EventArgs e)
        {
            dialogProcessor.AddShape(ShapesEnum.Star, fillColor.BackColor);
        }
        private void arrowButton_Click(object sender, EventArgs e)
        {
            dialogProcessor.AddShape(ShapesEnum.Arrow, fillColor.BackColor);
        }
        #endregion
        #endregion
        private void ChooseColor(object sender, EventArgs e)
        {
            ToolStripButton temp = (ToolStripButton)sender;
            temp.Checked = false;
            Enum.TryParse(temp.Name, out ColorsEnum color);
            outlineColor.BackColor = dialogProcessor.CreateColor(color);
        }
        private void ChooseFillColor(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                ToolStripButton temp = (ToolStripButton)sender;
                temp.Checked = false;
                Enum.TryParse(temp.Name, out ColorsEnum color);
                fillColor.BackColor = dialogProcessor.CreateColor(color);
            }
        }
        private void mouseButton_Click(object sender, EventArgs e)
        {
            mouseButton.Checked = true;
            paintBucket.Checked = false;
            colorPickTool.Checked = false;
        }

        private void paintBucket_Click(object sender, EventArgs e)
        {
            paintBucket.Checked = true;
            mouseButton.Checked = false;
            colorPickTool.Checked = false;
        }

        private void colorPickTool_Click(object sender, EventArgs e)
        {
            colorPickTool.Checked = true;
            mouseButton.Checked = false;
            paintBucket.Checked = false;
        }
        private void toolStripButton4_DropDownItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            outlineWidth = int.Parse(e.ClickedItem.Text.Substring(0,1));
        }
        private void viewPort_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control && e.KeyCode == Keys.C && dialogProcessor.Selection != null)
            {
                dialogProcessor.CopyShape = ShapeCloner.Clone(dialogProcessor.Selection);
                dialogProcessor.CopyShape.Matrix = dialogProcessor.Selection.Matrix.Clone();
                dialogProcessor.CopyShape.StartPoint = new PointF(dialogProcessor.CopyShape.StartPoint.X + 20, dialogProcessor.CopyShape.StartPoint.Y + 20);
                dialogProcessor.CopyShape.EndPoint = new PointF(dialogProcessor.CopyShape.EndPoint.X + 20, dialogProcessor.CopyShape.EndPoint.Y + 20);
            }
            if (e.Control && e.KeyCode == Keys.V && dialogProcessor.CopyShape != null)
            {
                if (dialogProcessor.Selection == dialogProcessor.CopyShape) return;
                dialogProcessor.Selection.IsSelected = false;
                dialogProcessor.Selection = dialogProcessor.CopyShape;
                dialogProcessor.Selection.IsSelected = true;
                dialogProcessor.ShapeList.Add(dialogProcessor.CopyShape);
                dialogProcessor.Commands.Push(new Command(dialogProcessor.Selection, ShapeCloner.Clone(dialogProcessor.Selection), CommandsEnum.Add));
                viewPort.Invalidate();
            }
            if (e.Control && e.KeyCode == Keys.Z && dialogProcessor.Commands.Count > 0)
            {
                dialogProcessor.ReverseCommand(dialogProcessor.Commands.Pop());
                viewPort.Invalidate();
            }
            if (dialogProcessor.Selection != null && e.KeyCode == Keys.Delete)
            {
                dialogProcessor.Commands.Push(new Command(dialogProcessor.Selection, ShapeCloner.Clone(dialogProcessor.Selection), CommandsEnum.Remove));
                dialogProcessor.ShapeList.Remove(dialogProcessor.Selection);
                dialogProcessor.Selection = null;
                viewPort.Invalidate();
            }
            if (dialogProcessor.Selection != null && dialogProcessor.Selection.GetType().Name.Equals("SelectionShape") && e.Control && e.KeyCode == Keys.G)
            {
                dialogProcessor.DisbandSelection();
                dialogProcessor.Selection = dialogProcessor.CreateGroup(dialogProcessor.Selection);
                viewPort.Invalidate();
            }
            if (dialogProcessor.Selection != null && dialogProcessor.Selection.GetType().Name.Equals("GroupShape") && e.Control && e.Shift && e.KeyCode == Keys.G)
            {
                dialogProcessor.DisbandGroup();
                viewPort.Invalidate();
            }
            if (e.Control && e.Shift && e.KeyCode == Keys.Tab)
            {
                dialogProcessor.DifSelectionMinus();
                viewPort.Invalidate();
                return;
            }
            if (e.Control && e.KeyCode == Keys.Tab)
            {
                dialogProcessor.DifSelectionPlus();
                viewPort.Invalidate();
            }
            if (e.Control && e.KeyCode == Keys.S)
            {
                using (SaveFileDialog sfd = new SaveFileDialog())
                {
                    sfd.Filter = "Data(*.data) | *.data | (*.*|*.*";

                    if (sfd.ShowDialog() == DialogResult.OK)
                    {
                        IFormatter formatter = new BinaryFormatter();

                        using (var fileStream = new FileStream(sfd.FileName, FileMode.Create))
                        {
                            formatter.Serialize(fileStream, dialogProcessor.ShapeList);
                            formatter.Serialize(fileStream, this.BackColor);
                        }
                    }
                    viewPort.Invalidate();
                }
            }
            if (e.Control && e.KeyCode == Keys.O)
            {
                using (OpenFileDialog ofd = new OpenFileDialog())
                {
                    if (ofd.ShowDialog() == DialogResult.OK)
                    {
                        IFormatter formatter = new BinaryFormatter();

                        using (var fileStream = new FileStream(ofd.FileName, FileMode.Open))
                        {
                            dialogProcessor.ShapeList = (List<Shape>)formatter.Deserialize(fileStream);
                        }
                    }
                }
                Invalidate();
            }
        }

        private void toolStripButton5_Click(object sender, EventArgs e)
        {
            if (dialogProcessor.Selection.GetType().Name.Equals("SelectionShape")) 
            {
                dialogProcessor.CreateGroup( dialogProcessor.Selection );
            }
        }
        private void colorPickTool_Click_1(object sender, EventArgs e)
        {
            if (dialogProcessor.Selection.GetType().Name.Equals("GroupShape"))
            {
                dialogProcessor.DisbandGroup();
            }
        }

        private void editToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void toolStripMenuItem4_Click(object sender, EventArgs e)
        {
            if (dialogProcessor.Selection != null)
            {
                dialogProcessor.Commands.Push(new Command(dialogProcessor.Selection, ShapeCloner.Clone(dialogProcessor.Selection), CommandsEnum.Remove));
                dialogProcessor.ShapeList.Remove(dialogProcessor.Selection);
            }
        }

        private void toolStripMenuItem5_Click(object sender, EventArgs e)
        {
            if (dialogProcessor.Selection != null)
            {
                dialogProcessor.CopyShape = ShapeCloner.Clone(dialogProcessor.Selection);
                dialogProcessor.CopyShape.Matrix = dialogProcessor.Selection.Matrix.Clone();
                dialogProcessor.CopyShape.StartPoint = new PointF(dialogProcessor.CopyShape.StartPoint.X + 20, dialogProcessor.CopyShape.StartPoint.Y + 20);
                dialogProcessor.CopyShape.EndPoint = new PointF(dialogProcessor.CopyShape.EndPoint.X + 20, dialogProcessor.CopyShape.EndPoint.Y + 20);
            } 
        }
        private void toolStripMenuItem6_Click(object sender, EventArgs e)
        {           
            if (dialogProcessor.CopyShape != null)
            {
                if (dialogProcessor.Selection == dialogProcessor.CopyShape) return;
                dialogProcessor.Selection.IsSelected = false;
                dialogProcessor.Selection = dialogProcessor.CopyShape;
                dialogProcessor.Selection.IsSelected = true;
                dialogProcessor.ShapeList.Add(dialogProcessor.CopyShape);
                dialogProcessor.Commands.Push(new Command(dialogProcessor.Selection, ShapeCloner.Clone(dialogProcessor.Selection), CommandsEnum.Add));
                viewPort.Invalidate();
            }
        }
        private void toolStripMenuItem7_Click(object sender, EventArgs e)
        {
            if (dialogProcessor.Commands.Count > 0)
            {
                dialogProcessor.ReverseCommand(dialogProcessor.Commands.Pop());
                viewPort.Invalidate();
            }
        }
        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (SaveFileDialog sfd = new SaveFileDialog())
            {
                sfd.Filter = "Data(*.data) | *.data | (*.*|*.*";

                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    IFormatter formatter = new BinaryFormatter();

                    using (var fileStream = new FileStream(sfd.FileName, FileMode.Create))
                    {
                        formatter.Serialize(fileStream, dialogProcessor.ShapeList);
                        formatter.Serialize(fileStream, this.BackColor);
                    }
                }
                viewPort.Invalidate();
            }
        }
        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog ofd = new OpenFileDialog())
            {
                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    IFormatter formatter = new BinaryFormatter();

                    using (var fileStream = new FileStream(ofd.FileName, FileMode.Open))
                    {
                        dialogProcessor.ShapeList = (List<Shape>)formatter.Deserialize(fileStream);
                    }
                }
            }
            viewPort.Invalidate();
        }
        private void trackBar1_ValueChanged(object sender, EventArgs e)
        {
            if (dialogProcessor.Selection != null)
            {
                TrackBar track = (TrackBar)sender;
                dialogProcessor.Selection.Opacity = (int)Math.Floor(track.Value * 2.55);
                viewPort.Invalidate();
            }
        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {

        }
    }
}
