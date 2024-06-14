using Draw.src.Model;
using Draw.src.Processors;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace Draw
{
	public partial class MainForm : Form
	{
        ToolStripButton button;

        private DialogProcessor dialogProcessor = new DialogProcessor();
		
		public MainForm()
		{
			InitializeComponent();

            button = Black;

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
                Enum.TryParse(button.Name, out ColorsEnum color);
                dialogProcessor.Selection.FillColor = dialogProcessor.CreateColor(color);
                dialogProcessor.IsDrawing = true;
                return;
            }
            if (mouseButton.Checked) {
                if (dialogProcessor.Selection != null && dialogProcessor.Selection.RotationRectContains(dialogProcessor.RotatePointInShapePlane(e.Location, dialogProcessor.Selection))) 
                {
                    dialogProcessor.IsRotating = true;
                    return;
                }
                if (dialogProcessor.Selection != null && dialogProcessor.Selection.OutlineContainsPoint(dialogProcessor.RotatePointInShapePlane(e.Location, dialogProcessor.Selection))) 
				{
                    dialogProcessor.IsResizing = true;
                    return;
                }
                if ((dialogProcessor.ContainsPoint(e.Location) == null && dialogProcessor.Selection != null) || (dialogProcessor.ContainsPoint(e.Location) != dialogProcessor.Selection)) 
                {
                    dialogProcessor.Selection.IsSelected = false;
                }
                if (dialogProcessor.ContainsPoint(e.Location) == null && dialogProcessor.Selection.GetType().Name.Equals("SelectionShape"))
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
                    dialogProcessor.Selection.IsSelected = true;                  
					statusBar.Items[0].Text = "Последно действие: Селекция на примитив";
					dialogProcessor.IsDragging = true;
					dialogProcessor.LastLocation = e.Location;
				}
            }
            if (paintBucket.Checked && dialogProcessor.ContainsPoint(e.Location) != null)
            {
                Enum.TryParse(button.Name, out ColorsEnum color);
                dialogProcessor.ContainsPoint(e.Location).FillColor = dialogProcessor.CreateColor(color);
            }
            if (colorPickTool.Checked) 
            {
                foreach (ToolStripButton button in toolStrip3.Items) 
                {
                    Enum.TryParse(button.Name, out ColorsEnum color);
                    if ( dialogProcessor.CreateColor(color) == dialogProcessor.ContainsPoint(e.Location).FillColor) 
                    {
                        button.Checked = true;
                        this.button.Checked = false;
                        this.button = button;
                        colorPickTool.Checked = false;
                        paintBucket.Checked = true;
                    }
                }
            }
        }
        void ViewPortMouseMove(object sender, System.Windows.Forms.MouseEventArgs e)
		{
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
				dialogProcessor.ExpandInDirection(e.Location);
                viewPort.Invalidate();
            }
			else if (dialogProcessor.IsDragging) {
				if (dialogProcessor.Selection != null) statusBar.Items[0].Text = "Последно действие: Влачене";
				dialogProcessor.TranslateTo(e.Location);
                viewPort.Invalidate();
            }
        }

		void ViewPortMouseUp(object sender, System.Windows.Forms.MouseEventArgs e)
		{
            if (dialogProcessor.IsDrawing)
            {
                dialogProcessor.Selection.EndPoint = e.Location;
                dialogProcessor.Selection.HasBeenInteractedWith = true;
                dialogProcessor.Selection.IsSelected = true;
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
            Enum.TryParse(button.Name, out ColorsEnum color);
            dialogProcessor.AddShape(ShapesEnum.Rectangle, color);
            statusBar.Items[0].Text = "Последно действие: Рисуване на правоъгълник";
        }
        private void elipseButton_Click(object sender, EventArgs e)
        {
            Enum.TryParse(button.Name, out ColorsEnum color);
            dialogProcessor.AddShape(ShapesEnum.Ellipse, color);
        }
        private void sametriangleButton_Click(object sender, EventArgs e)
        {
            Enum.TryParse(button.Name, out ColorsEnum color);
            dialogProcessor.AddShape(ShapesEnum.IsoscelesTriangle, color);
        }
        private void rightTriangleButton_Click(object sender, EventArgs e)
        {
            Enum.TryParse(button.Name, out ColorsEnum color);
            dialogProcessor.AddShape(ShapesEnum.RrightTriangle, color);
        }
        private void diamondButton_Click(object sender, EventArgs e)
        {
            Enum.TryParse(button.Name, out ColorsEnum color);
            dialogProcessor.AddShape(ShapesEnum.Diamond, color);
        }
        private void lineButton_Click(object sender, EventArgs e)
        {
            Enum.TryParse(button.Name, out ColorsEnum color);
            dialogProcessor.AddShape(ShapesEnum.Line, color);
        }
        private void pentagonButton_Click(object sender, EventArgs e)
        {
            Enum.TryParse(button.Name, out ColorsEnum color);
            dialogProcessor.AddShape(ShapesEnum.Pentagon, color);
        }
        private void hexagonButton_Click(object sender, EventArgs e)
        {
            Enum.TryParse(button.Name, out ColorsEnum color);
            dialogProcessor.AddShape(ShapesEnum.Hexagon, color);
        }
        private void starButton_Click(object sender, EventArgs e)
        {
            Enum.TryParse(button.Name, out ColorsEnum color);
            dialogProcessor.AddShape(ShapesEnum.Star, color);
        }
        private void arrowButton_Click(object sender, EventArgs e)
        {
            Enum.TryParse(button.Name, out ColorsEnum color);
            dialogProcessor.AddShape(ShapesEnum.Arrow, color);
        }
        #endregion
        private void toolStripButton4_Click(object sender, EventArgs e)
        {
			DialogResult result = colorDialog1.ShowDialog();
			if (result == DialogResult.OK) 
			{
				if (dialogProcessor.Selection != null) 
				{
                    dialogProcessor.Selection.FillColor = colorDialog1.Color;
                }
				viewPort.Invalidate();
			}
        }
        private void trackBar1_ValueChanged_1(object sender, EventArgs e)
        {
            dialogProcessor.Selection.Opacity = trackBar1.Value;
            valueLabel.Text = trackBar1.Value.ToString();
            viewPort.Invalidate();
        }

        private void toolStripButton5_Click(object sender, EventArgs e)
        {
            DialogResult result = colorDialog2.ShowDialog();
            if (result == DialogResult.OK)
            {
                if (dialogProcessor.Selection != null)
                {
                    dialogProcessor.Selection.OutlineColor = colorDialog2.Color;
                }
                viewPort.Invalidate();
            }
        }

        private void trackBar2_ValueChanged(object sender, EventArgs e)
        {
            valueLabel.Text = trackBar2.Value.ToString();
            viewPort.Invalidate();
        }
        private void viewPort_KeyDown(object sender, KeyEventArgs e)
        {        
            if (e.Control && e.Shift &&  e.KeyCode == Keys.C)
            {
                Enum.TryParse(button.Name, out ColorsEnum color);
                dialogProcessor.AddShape(ShapesEnum.RrightTriangle, color);
                viewPort.Invalidate();
            }     
        }

        private void toolStripButton6_Click(object sender, EventArgs e)
        {
            DiamondShape star = new DiamondShape();
            dialogProcessor.ShapeList.Add(star);
            dialogProcessor.Selection = star;
            viewPort.Invalidate();
        }
        private void ChooseColor(object sender, EventArgs e)
        {
            ToolStripButton temp = (ToolStripButton)sender;
            if (temp.Name.Equals(button.Name)) { temp.Checked = true; return; }
            button.Checked = false;
            button = (ToolStripButton)sender;
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
    }
}
