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
		private DialogProcessor dialogProcessor = new DialogProcessor();
		
		public MainForm()
		{
			InitializeComponent();
			
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
		
		void DrawRectangleSpeedButtonClick(object sender, EventArgs e)
		{
            RectangleShape rect = new RectangleShape();
            dialogProcessor.ShapeList.Add(rect);
            dialogProcessor.Selection = rect;
            //drawRectangleSpeedButton.Checked = true;
			
			statusBar.Items[0].Text = "Последно действие: Рисуване на правоъгълник";
			
			viewPort.Invalidate();
        }
        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            EllipseShape elipse = new EllipseShape();
            dialogProcessor.ShapeList.Add(elipse);
            dialogProcessor.Selection = elipse;
            viewPort.Invalidate();
        }

        void ViewPortMouseDown(object sender, System.Windows.Forms.MouseEventArgs e)
		{
            EllipseShape elipse = new EllipseShape(new PointF(200, 200), new PointF(300, 300));
            elipse.GroupId = 1;
            elipse.HasBeenInteractedWith = true;
            dialogProcessor.ShapeList.Add(elipse);
            viewPort.Invalidate();
            if (dialogProcessor.Selection != null && !dialogProcessor.Selection.HasBeenInteractedWith)
            {
                dialogProcessor.Selection.StartPoint = e.Location;
                dialogProcessor.Selection.EndPoint = e.Location;
                dialogProcessor.IsDrawing = true;
                return;
            }
            if (pickUpSpeedButton.Checked) {
                if (dialogProcessor.Selection != null && dialogProcessor.Selection.RotationRectContains(e.Location)) 
                {
                    dialogProcessor.IsRotating = true;
                    return;
                }
                if (dialogProcessor.Selection != null && dialogProcessor.Selection.OutlineContainsPoint(e.Location)) 
				{
                    dialogProcessor.IsResizing = true;
                    return;
                }
                dialogProcessor.Selection = dialogProcessor.ContainsPoint(e.Location);
				if (dialogProcessor.Selection != null) {
                    dialogProcessor.Selection.IsSelected = true;                  
					statusBar.Items[0].Text = "Последно действие: Селекция на примитив";
					dialogProcessor.IsDragging = true;
					dialogProcessor.LastLocation = e.Location;
                    foreach (Shape shape in dialogProcessor.ShapeList)
                    {
                        if (shape.GroupId == dialogProcessor.Selection.GroupId)
                        {
                            shape.IsSelected = true;
                        }
                    }
                    viewPort.Invalidate();
				}
            }
			if (GroupButon.Checked) 
			{
				dialogProcessor.IsSelecting = true;
				dialogProcessor.SelectionTool.StartPoint = e.Location;
                dialogProcessor.ShapeList.Add(dialogProcessor.SelectionTool);
			}
            foreach (Shape shape in dialogProcessor.ShapeList)
            {
                if (dialogProcessor.Selection != null && shape.GroupId == dialogProcessor.Selection.GroupId)
                {
                    shape.IsSelected = true;
                }
                else
                {
                    shape.IsSelected = false;
                }
            }
        }

		void ViewPortMouseMove(object sender, System.Windows.Forms.MouseEventArgs e)
		{
            if (dialogProcessor.IsRotating)
            {
                dialogProcessor.Selection.Rotate(dialogProcessor.CalcAngle(e.Location));
            }
            if (dialogProcessor.IsDrawing)
            {
                dialogProcessor.Selection.EndPoint = e.Location;
            }
			if (dialogProcessor.IsSelecting) 
			{
                dialogProcessor.SelectionTool.EndPoint = e.Location;
				dialogProcessor.SelectElements();
            }
			if (dialogProcessor.IsResizing) 
			{
				dialogProcessor.ExpandInDirection(e.Location);
            }
			else if (dialogProcessor.IsDragging) {
				if (dialogProcessor.Selection != null) statusBar.Items[0].Text = "Последно действие: Влачене";
				dialogProcessor.TranslateTo(e.Location);
            }
            viewPort.Invalidate();
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
                dialogProcessor.CreateGroup();
				dialogProcessor.ShapeList.Remove(dialogProcessor.SelectionTool);
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
        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            dialogProcessor.AddRandomSquare();
            viewPort.Invalidate();
        }

        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            dialogProcessor.AddRandomLine();
            viewPort.Invalidate();
        }
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
            dialogProcessor.Selection.FillOpacity = trackBar1.Value;
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
            dialogProcessor.Selection.OutlineOpacity = trackBar2.Value;
            valueLabel.Text = trackBar2.Value.ToString();
            viewPort.Invalidate();
        }
        private void viewPort_KeyDown(object sender, KeyEventArgs e)
        {        
			Console.WriteLine(e.KeyCode);
            Console.WriteLine(e.KeyCode == Keys.ControlKey && e.KeyCode == Keys.C);
            if (e.Control && e.Shift &&  e.KeyCode == Keys.C)
            {
                dialogProcessor.AddRandomRectangle();
                viewPort.Invalidate();
            }     
        }

        private void toolStripButton6_Click(object sender, EventArgs e)
        {
            StarShape star = new StarShape();
            dialogProcessor.ShapeList.Add(star);
            dialogProcessor.Selection = star;
            viewPort.Invalidate();
        }
    }
}
