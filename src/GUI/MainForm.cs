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
        int outlineWidth = 3;

        private DialogProcessor dialogProcessor = new DialogProcessor();
		
		public MainForm()
		{
			InitializeComponent();

            button = White;
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
                if (dialogProcessor.ContainsPoint(e.Location) == null && dialogProcessor.Selection != null&& dialogProcessor.Selection.GetType().Name.Equals("SelectionShape"))
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
                dialogProcessor.ContainsPoint(e.Location).FillColor = fillColor.BackColor;
                dialogProcessor.ContainsPoint(e.Location).OutlineColor = outlineColor.BackColor;
            }
            if (colorPickTool.Checked) 
            {
                foreach (ToolStripButton button in toolStrip3.Items) 
                {
                    Enum.TryParse(button.Name, out ColorsEnum color);
                    if ( dialogProcessor.CreateColor(color) == dialogProcessor.ContainsPoint(e.Location).FillColor) 
                    {
                        outlineColor.BackColor = dialogProcessor.CreateColor(color);
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
            if (!dialogProcessor.IsResizing && dialogProcessor.Selection != null && dialogProcessor.Selection.OutlineContainsPoint(e.Location))
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
        private void viewPort_KeyDown(object sender, KeyEventArgs e)
        {        
            if (e.Control && e.Shift &&  e.KeyCode == Keys.C)
            {
                Enum.TryParse(button.Name, out ColorsEnum color);
                dialogProcessor.AddShape(ShapesEnum.RrightTriangle, color);
                viewPort.Invalidate();
            }     
        }
        private void ChooseColor(object sender, EventArgs e)
        {
            ToolStripButton temp = (ToolStripButton)sender;
            if (temp.Name.Equals(button.Name)) { temp.Checked = true; return; }
            button.Checked = false;
            Enum.TryParse(temp.Name, out ColorsEnum color);
            outlineColor.BackColor = dialogProcessor.CreateColor(color);
            button = temp;
            viewPort.Invalidate();
        }
        private void ChooseFillColor(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                ToolStripButton temp = (ToolStripButton)sender;
                Console.WriteLine(temp.Name);
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

        private void toolStrip4_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            var size = e.ClickedItem.Text;
            Console.WriteLine(size);
        }

        private void toolStripButton4_DropDownItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            outlineWidth = int.Parse(e.ClickedItem.Text.Substring(0,1));
        }
    }
}
