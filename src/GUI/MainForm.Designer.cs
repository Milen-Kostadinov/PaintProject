namespace Draw
{
	partial class MainForm
	{
		/// <summary>
		/// Designer variable used to keep track of non-visual components.
		/// </summary>
		private System.ComponentModel.IContainer components = null;
		
		/// <summary>
		/// Disposes resources used by the form.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing) {
				if (components != null) {
					components.Dispose();
				}
			}
			base.Dispose(disposing);
		}
		
		/// <summary>
		/// This method is required for Windows Forms designer support.
		/// Do not change the method contents inside the source code editor. The Forms designer might
		/// not be able to load this method if it was changed manually.
		/// </summary>
		private void InitializeComponent()
		{
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.mainMenu = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.editToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.imageToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.statusBar = new System.Windows.Forms.StatusStrip();
            this.currentStatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.speedMenu = new System.Windows.Forms.ToolStrip();
            this.pickUpSpeedButton = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton4 = new System.Windows.Forms.ToolStripButton();
            this.valueLabel = new System.Windows.Forms.ToolStripLabel();
            this.toolStripButton5 = new System.Windows.Forms.ToolStripButton();
            this.GroupButon = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton6 = new System.Windows.Forms.ToolStripButton();
            this.AddStarButton = new System.Windows.Forms.ToolStripButton();
            this.colorDialog1 = new System.Windows.Forms.ColorDialog();
            this.trackBar1 = new System.Windows.Forms.TrackBar();
            this.colorDialog2 = new System.Windows.Forms.ColorDialog();
            this.trackBar2 = new System.Windows.Forms.TrackBar();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.panel1 = new System.Windows.Forms.Panel();
            this.toolStrip3 = new System.Windows.Forms.ToolStrip();
            this.Black = new System.Windows.Forms.ToolStripButton();
            this.Gray = new System.Windows.Forms.ToolStripButton();
            this.Red = new System.Windows.Forms.ToolStripButton();
            this.Orange = new System.Windows.Forms.ToolStripButton();
            this.LightOrange = new System.Windows.Forms.ToolStripButton();
            this.Yellow = new System.Windows.Forms.ToolStripButton();
            this.Green = new System.Windows.Forms.ToolStripButton();
            this.LightBlue = new System.Windows.Forms.ToolStripButton();
            this.Blue = new System.Windows.Forms.ToolStripButton();
            this.Purple = new System.Windows.Forms.ToolStripButton();
            this.White = new System.Windows.Forms.ToolStripButton();
            this.LightGray = new System.Windows.Forms.ToolStripButton();
            this.Brown = new System.Windows.Forms.ToolStripButton();
            this.Pink = new System.Windows.Forms.ToolStripButton();
            this.Yellow2 = new System.Windows.Forms.ToolStripButton();
            this.Eggshell = new System.Windows.Forms.ToolStripButton();
            this.Lime = new System.Windows.Forms.ToolStripButton();
            this.PaleBlue = new System.Windows.Forms.ToolStripButton();
            this.LightPurple = new System.Windows.Forms.ToolStripButton();
            this.Cyan = new System.Windows.Forms.ToolStripButton();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.rectangleButton = new System.Windows.Forms.ToolStripButton();
            this.elipseButton = new System.Windows.Forms.ToolStripButton();
            this.sametriangleButton = new System.Windows.Forms.ToolStripButton();
            this.rightTriangleButton = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton1 = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton2 = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton3 = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton7 = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton8 = new System.Windows.Forms.ToolStripButton();
            this.arrowButton = new System.Windows.Forms.ToolStripButton();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.toolStrip2 = new System.Windows.Forms.ToolStrip();
            this.mouseButton = new System.Windows.Forms.ToolStripButton();
            this.paintBucket = new System.Windows.Forms.ToolStripButton();
            this.viewPort = new Draw.DoubleBufferedPanel();
            this.colorPickTool = new System.Windows.Forms.ToolStripButton();
            this.mainMenu.SuspendLayout();
            this.statusBar.SuspendLayout();
            this.speedMenu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar2)).BeginInit();
            this.panel1.SuspendLayout();
            this.toolStrip3.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.toolStrip2.SuspendLayout();
            this.SuspendLayout();
            // 
            // mainMenu
            // 
            this.mainMenu.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.mainMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.editToolStripMenuItem,
            this.imageToolStripMenuItem,
            this.helpToolStripMenuItem});
            this.mainMenu.Location = new System.Drawing.Point(0, 0);
            this.mainMenu.Name = "mainMenu";
            this.mainMenu.Padding = new System.Windows.Forms.Padding(4, 2, 0, 2);
            this.mainMenu.Size = new System.Drawing.Size(809, 24);
            this.mainMenu.TabIndex = 1;
            this.mainMenu.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(93, 22);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.ExitToolStripMenuItemClick);
            // 
            // editToolStripMenuItem
            // 
            this.editToolStripMenuItem.Name = "editToolStripMenuItem";
            this.editToolStripMenuItem.Size = new System.Drawing.Size(39, 20);
            this.editToolStripMenuItem.Text = "Edit";
            // 
            // imageToolStripMenuItem
            // 
            this.imageToolStripMenuItem.Name = "imageToolStripMenuItem";
            this.imageToolStripMenuItem.Size = new System.Drawing.Size(52, 20);
            this.imageToolStripMenuItem.Text = "Image";
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.aboutToolStripMenuItem});
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
            this.helpToolStripMenuItem.Text = "Help";
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(116, 22);
            this.aboutToolStripMenuItem.Text = "About...";
            // 
            // statusBar
            // 
            this.statusBar.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.statusBar.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.currentStatusLabel});
            this.statusBar.Location = new System.Drawing.Point(0, 401);
            this.statusBar.Name = "statusBar";
            this.statusBar.Size = new System.Drawing.Size(809, 22);
            this.statusBar.TabIndex = 2;
            this.statusBar.Text = "statusStrip1";
            // 
            // currentStatusLabel
            // 
            this.currentStatusLabel.Name = "currentStatusLabel";
            this.currentStatusLabel.Size = new System.Drawing.Size(0, 17);
            // 
            // speedMenu
            // 
            this.speedMenu.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.speedMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.pickUpSpeedButton,
            this.toolStripButton4,
            this.valueLabel,
            this.toolStripButton5,
            this.GroupButon,
            this.toolStripButton6,
            this.AddStarButton});
            this.speedMenu.Location = new System.Drawing.Point(0, 24);
            this.speedMenu.Name = "speedMenu";
            this.speedMenu.Size = new System.Drawing.Size(809, 27);
            this.speedMenu.TabIndex = 3;
            this.speedMenu.Text = "toolStrip1";
            // 
            // pickUpSpeedButton
            // 
            this.pickUpSpeedButton.Checked = true;
            this.pickUpSpeedButton.CheckOnClick = true;
            this.pickUpSpeedButton.CheckState = System.Windows.Forms.CheckState.Checked;
            this.pickUpSpeedButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.pickUpSpeedButton.Image = ((System.Drawing.Image)(resources.GetObject("pickUpSpeedButton.Image")));
            this.pickUpSpeedButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.pickUpSpeedButton.Name = "pickUpSpeedButton";
            this.pickUpSpeedButton.Size = new System.Drawing.Size(24, 24);
            this.pickUpSpeedButton.Text = "toolStripButton1";
            // 
            // toolStripButton4
            // 
            this.toolStripButton4.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton4.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton4.Image")));
            this.toolStripButton4.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton4.Name = "toolStripButton4";
            this.toolStripButton4.Size = new System.Drawing.Size(24, 24);
            this.toolStripButton4.Text = "toolStripButton4";
            this.toolStripButton4.Click += new System.EventHandler(this.toolStripButton4_Click);
            // 
            // valueLabel
            // 
            this.valueLabel.Name = "valueLabel";
            this.valueLabel.Size = new System.Drawing.Size(35, 24);
            this.valueLabel.Text = "Value";
            // 
            // toolStripButton5
            // 
            this.toolStripButton5.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton5.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton5.Image")));
            this.toolStripButton5.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton5.Name = "toolStripButton5";
            this.toolStripButton5.Size = new System.Drawing.Size(24, 24);
            this.toolStripButton5.Text = "toolStripButton5";
            this.toolStripButton5.Click += new System.EventHandler(this.toolStripButton5_Click);
            // 
            // GroupButon
            // 
            this.GroupButon.CheckOnClick = true;
            this.GroupButon.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.GroupButon.Image = ((System.Drawing.Image)(resources.GetObject("GroupButon.Image")));
            this.GroupButon.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.GroupButon.Name = "GroupButon";
            this.GroupButon.Size = new System.Drawing.Size(24, 24);
            this.GroupButon.Text = "toolStripButton7";
            this.GroupButon.ToolTipText = "Group Tool";
            // 
            // toolStripButton6
            // 
            this.toolStripButton6.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton6.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton6.Image")));
            this.toolStripButton6.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton6.Name = "toolStripButton6";
            this.toolStripButton6.Size = new System.Drawing.Size(24, 24);
            this.toolStripButton6.Text = "toolStripButton6";
            this.toolStripButton6.Click += new System.EventHandler(this.toolStripButton6_Click);
            // 
            // AddStarButton
            // 
            this.AddStarButton.Name = "AddStarButton";
            this.AddStarButton.Size = new System.Drawing.Size(23, 24);
            // 
            // trackBar1
            // 
            this.trackBar1.Location = new System.Drawing.Point(8, 57);
            this.trackBar1.Maximum = 255;
            this.trackBar1.Name = "trackBar1";
            this.trackBar1.Size = new System.Drawing.Size(255, 45);
            this.trackBar1.TabIndex = 5;
            this.trackBar1.Value = 100;
            this.trackBar1.ValueChanged += new System.EventHandler(this.trackBar1_ValueChanged_1);
            // 
            // trackBar2
            // 
            this.trackBar2.Location = new System.Drawing.Point(8, 91);
            this.trackBar2.Maximum = 255;
            this.trackBar2.Name = "trackBar2";
            this.trackBar2.Size = new System.Drawing.Size(255, 45);
            this.trackBar2.TabIndex = 6;
            this.trackBar2.Value = 180;
            this.trackBar2.ValueChanged += new System.EventHandler(this.trackBar2_ValueChanged);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.toolStrip3);
            this.panel1.Controls.Add(this.toolStrip2);
            this.panel1.Controls.Add(this.toolStrip1);
            this.panel1.Location = new System.Drawing.Point(11, 130);
            this.panel1.Margin = new System.Windows.Forms.Padding(2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1500, 63);
            this.panel1.TabIndex = 7;
            // 
            // toolStrip3
            // 
            this.toolStrip3.AutoSize = false;
            this.toolStrip3.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.toolStrip3.CanOverflow = false;
            this.toolStrip3.Dock = System.Windows.Forms.DockStyle.None;
            this.toolStrip3.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.toolStrip3.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.Black,
            this.Gray,
            this.Red,
            this.Orange,
            this.LightOrange,
            this.Yellow,
            this.Green,
            this.LightBlue,
            this.Blue,
            this.Purple,
            this.White,
            this.LightGray,
            this.Brown,
            this.Pink,
            this.Yellow2,
            this.Eggshell,
            this.Lime,
            this.PaleBlue,
            this.LightPurple,
            this.Cyan});
            this.toolStrip3.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.Flow;
            this.toolStrip3.Location = new System.Drawing.Point(511, 2);
            this.toolStrip3.Name = "toolStrip3";
            this.toolStrip3.Size = new System.Drawing.Size(244, 61);
            this.toolStrip3.TabIndex = 3;
            // 
            // Black
            // 
            this.Black.Checked = true;
            this.Black.CheckOnClick = true;
            this.Black.CheckState = System.Windows.Forms.CheckState.Checked;
            this.Black.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.Black.Image = ((System.Drawing.Image)(resources.GetObject("Black.Image")));
            this.Black.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.Black.Name = "Black";
            this.Black.Size = new System.Drawing.Size(24, 24);
            this.Black.Text = "toolStripButton9";
            this.Black.ToolTipText = "Black";
            this.Black.Click += new System.EventHandler(this.ChooseColor);
            // 
            // Gray
            // 
            this.Gray.CheckOnClick = true;
            this.Gray.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.Gray.Image = ((System.Drawing.Image)(resources.GetObject("Gray.Image")));
            this.Gray.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.Gray.Name = "Gray";
            this.Gray.Size = new System.Drawing.Size(24, 24);
            this.Gray.Text = "toolStripButton10";
            this.Gray.ToolTipText = "Gray";
            this.Gray.Click += new System.EventHandler(this.ChooseColor);
            // 
            // Red
            // 
            this.Red.CheckOnClick = true;
            this.Red.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.Red.Image = ((System.Drawing.Image)(resources.GetObject("Red.Image")));
            this.Red.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.Red.Name = "Red";
            this.Red.Size = new System.Drawing.Size(24, 24);
            this.Red.Text = "toolStripButton11";
            this.Red.ToolTipText = "Red";
            this.Red.Click += new System.EventHandler(this.ChooseColor);
            // 
            // Orange
            // 
            this.Orange.CheckOnClick = true;
            this.Orange.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.Orange.Image = ((System.Drawing.Image)(resources.GetObject("Orange.Image")));
            this.Orange.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.Orange.Name = "Orange";
            this.Orange.Size = new System.Drawing.Size(24, 24);
            this.Orange.Text = "toolStripButton12";
            this.Orange.ToolTipText = "Orange";
            this.Orange.Click += new System.EventHandler(this.ChooseColor);
            // 
            // LightOrange
            // 
            this.LightOrange.CheckOnClick = true;
            this.LightOrange.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.LightOrange.Image = ((System.Drawing.Image)(resources.GetObject("LightOrange.Image")));
            this.LightOrange.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.LightOrange.Name = "LightOrange";
            this.LightOrange.Size = new System.Drawing.Size(24, 24);
            this.LightOrange.Text = "toolStripButton13";
            this.LightOrange.ToolTipText = "LightOrange";
            this.LightOrange.Click += new System.EventHandler(this.ChooseColor);
            // 
            // Yellow
            // 
            this.Yellow.CheckOnClick = true;
            this.Yellow.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.Yellow.Image = ((System.Drawing.Image)(resources.GetObject("Yellow.Image")));
            this.Yellow.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.Yellow.Name = "Yellow";
            this.Yellow.Size = new System.Drawing.Size(24, 24);
            this.Yellow.Text = "toolStripButton15";
            this.Yellow.ToolTipText = "Yellow";
            this.Yellow.Click += new System.EventHandler(this.ChooseColor);
            // 
            // Green
            // 
            this.Green.CheckOnClick = true;
            this.Green.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.Green.Image = ((System.Drawing.Image)(resources.GetObject("Green.Image")));
            this.Green.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.Green.Name = "Green";
            this.Green.Size = new System.Drawing.Size(24, 24);
            this.Green.Text = "toolStripButton16";
            this.Green.ToolTipText = "Green";
            this.Green.Click += new System.EventHandler(this.ChooseColor);
            // 
            // LightBlue
            // 
            this.LightBlue.CheckOnClick = true;
            this.LightBlue.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.LightBlue.Image = ((System.Drawing.Image)(resources.GetObject("LightBlue.Image")));
            this.LightBlue.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.LightBlue.Name = "LightBlue";
            this.LightBlue.Size = new System.Drawing.Size(24, 24);
            this.LightBlue.Text = "toolStripButton17";
            this.LightBlue.ToolTipText = "LightBlue";
            this.LightBlue.Click += new System.EventHandler(this.ChooseColor);
            // 
            // Blue
            // 
            this.Blue.CheckOnClick = true;
            this.Blue.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.Blue.Image = ((System.Drawing.Image)(resources.GetObject("Blue.Image")));
            this.Blue.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.Blue.Name = "Blue";
            this.Blue.Size = new System.Drawing.Size(24, 24);
            this.Blue.Text = "toolStripButton18";
            this.Blue.ToolTipText = "Blue";
            this.Blue.Click += new System.EventHandler(this.ChooseColor);
            // 
            // Purple
            // 
            this.Purple.CheckOnClick = true;
            this.Purple.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.Purple.Image = ((System.Drawing.Image)(resources.GetObject("Purple.Image")));
            this.Purple.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.Purple.Name = "Purple";
            this.Purple.Size = new System.Drawing.Size(24, 24);
            this.Purple.Text = "toolStripButton19";
            this.Purple.ToolTipText = "Purple";
            this.Purple.Click += new System.EventHandler(this.ChooseColor);
            // 
            // White
            // 
            this.White.CheckOnClick = true;
            this.White.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.White.Image = ((System.Drawing.Image)(resources.GetObject("White.Image")));
            this.White.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.White.Name = "White";
            this.White.Size = new System.Drawing.Size(24, 24);
            this.White.Text = "toolStripButton20";
            this.White.ToolTipText = "White";
            this.White.Click += new System.EventHandler(this.ChooseColor);
            // 
            // LightGray
            // 
            this.LightGray.CheckOnClick = true;
            this.LightGray.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.LightGray.Image = ((System.Drawing.Image)(resources.GetObject("LightGray.Image")));
            this.LightGray.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.LightGray.Name = "LightGray";
            this.LightGray.Size = new System.Drawing.Size(24, 24);
            this.LightGray.Text = "toolStripButton21";
            this.LightGray.ToolTipText = "LightGray";
            this.LightGray.Click += new System.EventHandler(this.ChooseColor);
            // 
            // Brown
            // 
            this.Brown.CheckOnClick = true;
            this.Brown.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.Brown.Image = ((System.Drawing.Image)(resources.GetObject("Brown.Image")));
            this.Brown.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.Brown.Name = "Brown";
            this.Brown.Size = new System.Drawing.Size(24, 24);
            this.Brown.Text = "toolStripButton14";
            this.Brown.ToolTipText = "Brown";
            this.Brown.Click += new System.EventHandler(this.ChooseColor);
            // 
            // Pink
            // 
            this.Pink.CheckOnClick = true;
            this.Pink.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.Pink.Image = ((System.Drawing.Image)(resources.GetObject("Pink.Image")));
            this.Pink.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.Pink.Name = "Pink";
            this.Pink.Size = new System.Drawing.Size(24, 24);
            this.Pink.Text = "toolStripButton22";
            this.Pink.ToolTipText = "Pink";
            this.Pink.Click += new System.EventHandler(this.ChooseColor);
            // 
            // Yellow2
            // 
            this.Yellow2.CheckOnClick = true;
            this.Yellow2.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.Yellow2.Image = ((System.Drawing.Image)(resources.GetObject("Yellow2.Image")));
            this.Yellow2.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.Yellow2.Name = "Yellow2";
            this.Yellow2.Size = new System.Drawing.Size(24, 24);
            this.Yellow2.Text = "toolStripButton23";
            this.Yellow2.ToolTipText = "Yellow2";
            this.Yellow2.Click += new System.EventHandler(this.ChooseColor);
            // 
            // Eggshell
            // 
            this.Eggshell.CheckOnClick = true;
            this.Eggshell.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.Eggshell.Image = ((System.Drawing.Image)(resources.GetObject("Eggshell.Image")));
            this.Eggshell.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.Eggshell.Name = "Eggshell";
            this.Eggshell.Size = new System.Drawing.Size(24, 24);
            this.Eggshell.Text = "toolStripButton24";
            this.Eggshell.ToolTipText = "Eggshell";
            this.Eggshell.Click += new System.EventHandler(this.ChooseColor);
            // 
            // Lime
            // 
            this.Lime.CheckOnClick = true;
            this.Lime.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.Lime.Image = ((System.Drawing.Image)(resources.GetObject("Lime.Image")));
            this.Lime.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.Lime.Name = "Lime";
            this.Lime.Size = new System.Drawing.Size(24, 24);
            this.Lime.Text = "toolStripButton25";
            this.Lime.ToolTipText = "Lime";
            this.Lime.Click += new System.EventHandler(this.ChooseColor);
            // 
            // PaleBlue
            // 
            this.PaleBlue.CheckOnClick = true;
            this.PaleBlue.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.PaleBlue.Image = ((System.Drawing.Image)(resources.GetObject("PaleBlue.Image")));
            this.PaleBlue.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.PaleBlue.Name = "PaleBlue";
            this.PaleBlue.Size = new System.Drawing.Size(24, 24);
            this.PaleBlue.Text = "toolStripButton26";
            this.PaleBlue.ToolTipText = "PaleBlue";
            this.PaleBlue.Click += new System.EventHandler(this.ChooseColor);
            // 
            // LightPurple
            // 
            this.LightPurple.CheckOnClick = true;
            this.LightPurple.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.LightPurple.Image = ((System.Drawing.Image)(resources.GetObject("LightPurple.Image")));
            this.LightPurple.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.LightPurple.Name = "LightPurple";
            this.LightPurple.Size = new System.Drawing.Size(24, 24);
            this.LightPurple.Text = "toolStripButton27";
            this.LightPurple.ToolTipText = "LightPurple";
            this.LightPurple.Click += new System.EventHandler(this.ChooseColor);
            // 
            // Cyan
            // 
            this.Cyan.CheckOnClick = true;
            this.Cyan.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.Cyan.Image = ((System.Drawing.Image)(resources.GetObject("Cyan.Image")));
            this.Cyan.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.Cyan.Name = "Cyan";
            this.Cyan.Size = new System.Drawing.Size(24, 24);
            this.Cyan.Text = "toolStripButton28";
            this.Cyan.ToolTipText = "Cyan";
            this.Cyan.Click += new System.EventHandler(this.ChooseColor);
            // 
            // toolStrip1
            // 
            this.toolStrip1.AutoSize = false;
            this.toolStrip1.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.toolStrip1.CanOverflow = false;
            this.toolStrip1.Dock = System.Windows.Forms.DockStyle.None;
            this.toolStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.rectangleButton,
            this.elipseButton,
            this.sametriangleButton,
            this.rightTriangleButton,
            this.toolStripButton1,
            this.toolStripButton2,
            this.toolStripButton3,
            this.toolStripButton7,
            this.toolStripButton8,
            this.arrowButton});
            this.toolStrip1.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.Flow;
            this.toolStrip1.Location = new System.Drawing.Point(84, 2);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(131, 61);
            this.toolStrip1.TabIndex = 1;
            // 
            // rectangleButton
            // 
            this.rectangleButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.rectangleButton.Image = ((System.Drawing.Image)(resources.GetObject("rectangleButton.Image")));
            this.rectangleButton.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.rectangleButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.rectangleButton.Margin = new System.Windows.Forms.Padding(0);
            this.rectangleButton.Name = "rectangleButton";
            this.rectangleButton.Size = new System.Drawing.Size(25, 25);
            this.rectangleButton.Text = "Draws a rectangle";
            this.rectangleButton.Click += new System.EventHandler(this.rectangleButton_Click);
            // 
            // elipseButton
            // 
            this.elipseButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.elipseButton.Image = ((System.Drawing.Image)(resources.GetObject("elipseButton.Image")));
            this.elipseButton.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.elipseButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.elipseButton.Margin = new System.Windows.Forms.Padding(0);
            this.elipseButton.Name = "elipseButton";
            this.elipseButton.Size = new System.Drawing.Size(25, 25);
            this.elipseButton.Text = "Draws an elipse";
            this.elipseButton.Click += new System.EventHandler(this.elipseButton_Click);
            // 
            // sametriangleButton
            // 
            this.sametriangleButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.sametriangleButton.Image = ((System.Drawing.Image)(resources.GetObject("sametriangleButton.Image")));
            this.sametriangleButton.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.sametriangleButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.sametriangleButton.Margin = new System.Windows.Forms.Padding(0);
            this.sametriangleButton.Name = "sametriangleButton";
            this.sametriangleButton.Size = new System.Drawing.Size(25, 25);
            this.sametriangleButton.Text = "Draws a same triangle";
            this.sametriangleButton.Click += new System.EventHandler(this.sametriangleButton_Click);
            // 
            // rightTriangleButton
            // 
            this.rightTriangleButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.rightTriangleButton.Image = ((System.Drawing.Image)(resources.GetObject("rightTriangleButton.Image")));
            this.rightTriangleButton.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.rightTriangleButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.rightTriangleButton.Margin = new System.Windows.Forms.Padding(0);
            this.rightTriangleButton.Name = "rightTriangleButton";
            this.rightTriangleButton.Size = new System.Drawing.Size(25, 25);
            this.rightTriangleButton.Text = "Draws a right triangle";
            this.rightTriangleButton.Click += new System.EventHandler(this.rightTriangleButton_Click);
            // 
            // toolStripButton1
            // 
            this.toolStripButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton1.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton1.Image")));
            this.toolStripButton1.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.toolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton1.Margin = new System.Windows.Forms.Padding(0);
            this.toolStripButton1.Name = "toolStripButton1";
            this.toolStripButton1.Size = new System.Drawing.Size(25, 25);
            this.toolStripButton1.Text = "Draws a duamond";
            this.toolStripButton1.Click += new System.EventHandler(this.diamondButton_Click);
            // 
            // toolStripButton2
            // 
            this.toolStripButton2.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton2.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton2.Image")));
            this.toolStripButton2.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.toolStripButton2.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton2.Margin = new System.Windows.Forms.Padding(0);
            this.toolStripButton2.Name = "toolStripButton2";
            this.toolStripButton2.Size = new System.Drawing.Size(25, 25);
            this.toolStripButton2.Text = "Draws a line";
            this.toolStripButton2.Click += new System.EventHandler(this.lineButton_Click);
            // 
            // toolStripButton3
            // 
            this.toolStripButton3.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton3.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton3.Image")));
            this.toolStripButton3.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.toolStripButton3.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton3.Margin = new System.Windows.Forms.Padding(0);
            this.toolStripButton3.Name = "toolStripButton3";
            this.toolStripButton3.Size = new System.Drawing.Size(25, 25);
            this.toolStripButton3.Text = "Draws a pentagon";
            this.toolStripButton3.Click += new System.EventHandler(this.pentagonButton_Click);
            // 
            // toolStripButton7
            // 
            this.toolStripButton7.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton7.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton7.Image")));
            this.toolStripButton7.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.toolStripButton7.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton7.Margin = new System.Windows.Forms.Padding(0);
            this.toolStripButton7.Name = "toolStripButton7";
            this.toolStripButton7.Size = new System.Drawing.Size(25, 25);
            this.toolStripButton7.Text = "Draws a hexagon";
            this.toolStripButton7.Click += new System.EventHandler(this.hexagonButton_Click);
            // 
            // toolStripButton8
            // 
            this.toolStripButton8.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton8.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton8.Image")));
            this.toolStripButton8.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.toolStripButton8.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton8.Margin = new System.Windows.Forms.Padding(0);
            this.toolStripButton8.Name = "toolStripButton8";
            this.toolStripButton8.Size = new System.Drawing.Size(25, 25);
            this.toolStripButton8.Text = "Draws a star";
            this.toolStripButton8.Click += new System.EventHandler(this.starButton_Click);
            // 
            // arrowButton
            // 
            this.arrowButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.arrowButton.Image = ((System.Drawing.Image)(resources.GetObject("arrowButton.Image")));
            this.arrowButton.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.arrowButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.arrowButton.Margin = new System.Windows.Forms.Padding(0);
            this.arrowButton.Name = "arrowButton";
            this.arrowButton.Size = new System.Drawing.Size(25, 25);
            this.arrowButton.Text = "Draws an arrow";
            this.arrowButton.Click += new System.EventHandler(this.arrowButton_Click);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(61, 4);
            // 
            // toolStrip2
            // 
            this.toolStrip2.AutoSize = false;
            this.toolStrip2.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.toolStrip2.CanOverflow = false;
            this.toolStrip2.Dock = System.Windows.Forms.DockStyle.None;
            this.toolStrip2.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.toolStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mouseButton,
            this.paintBucket,
            this.colorPickTool});
            this.toolStrip2.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.Flow;
            this.toolStrip2.Location = new System.Drawing.Point(255, 2);
            this.toolStrip2.Name = "toolStrip2";
            this.toolStrip2.Size = new System.Drawing.Size(226, 63);
            this.toolStrip2.TabIndex = 6;
            // 
            // mouseButton
            // 
            this.mouseButton.Checked = true;
            this.mouseButton.CheckOnClick = true;
            this.mouseButton.CheckState = System.Windows.Forms.CheckState.Checked;
            this.mouseButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.mouseButton.Image = ((System.Drawing.Image)(resources.GetObject("mouseButton.Image")));
            this.mouseButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.mouseButton.Margin = new System.Windows.Forms.Padding(10, 15, 5, 15);
            this.mouseButton.Name = "mouseButton";
            this.mouseButton.Padding = new System.Windows.Forms.Padding(5);
            this.mouseButton.Size = new System.Drawing.Size(34, 34);
            this.mouseButton.Text = "toolStripButton9";
            this.mouseButton.ToolTipText = "Mouse tool";
            this.mouseButton.Click += new System.EventHandler(this.mouseButton_Click);
            // 
            // paintBucket
            // 
            this.paintBucket.CheckOnClick = true;
            this.paintBucket.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.paintBucket.Image = ((System.Drawing.Image)(resources.GetObject("paintBucket.Image")));
            this.paintBucket.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.paintBucket.Margin = new System.Windows.Forms.Padding(0, 15, 0, 5);
            this.paintBucket.Name = "paintBucket";
            this.paintBucket.Padding = new System.Windows.Forms.Padding(5);
            this.paintBucket.Size = new System.Drawing.Size(34, 34);
            this.paintBucket.Text = "toolStripButton10";
            this.paintBucket.ToolTipText = "Paint tool";
            this.paintBucket.Click += new System.EventHandler(this.paintBucket_Click);
            // 
            // viewPort
            // 
            this.viewPort.Dock = System.Windows.Forms.DockStyle.Fill;
            this.viewPort.Location = new System.Drawing.Point(0, 51);
            this.viewPort.Margin = new System.Windows.Forms.Padding(4);
            this.viewPort.Name = "viewPort";
            this.viewPort.Size = new System.Drawing.Size(809, 350);
            this.viewPort.TabIndex = 4;
            this.viewPort.Paint += new System.Windows.Forms.PaintEventHandler(this.ViewPortPaint);
            this.viewPort.KeyDown += new System.Windows.Forms.KeyEventHandler(this.viewPort_KeyDown);
            this.viewPort.MouseDown += new System.Windows.Forms.MouseEventHandler(this.ViewPortMouseDown);
            this.viewPort.MouseMove += new System.Windows.Forms.MouseEventHandler(this.ViewPortMouseMove);
            this.viewPort.MouseUp += new System.Windows.Forms.MouseEventHandler(this.ViewPortMouseUp);
            // 
            // colorPickTool
            // 
            this.colorPickTool.CheckOnClick = true;
            this.colorPickTool.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.colorPickTool.Image = ((System.Drawing.Image)(resources.GetObject("colorPickTool.Image")));
            this.colorPickTool.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.colorPickTool.Margin = new System.Windows.Forms.Padding(0, 15, 10, 15);
            this.colorPickTool.Name = "colorPickTool";
            this.colorPickTool.Padding = new System.Windows.Forms.Padding(5);
            this.colorPickTool.Size = new System.Drawing.Size(34, 34);
            this.colorPickTool.Text = "toolStripButton9";
            this.colorPickTool.ToolTipText = "Color pick tool";
            this.colorPickTool.Click += new System.EventHandler(this.colorPickTool_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(809, 423);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.trackBar2);
            this.Controls.Add(this.trackBar1);
            this.Controls.Add(this.viewPort);
            this.Controls.Add(this.speedMenu);
            this.Controls.Add(this.statusBar);
            this.Controls.Add(this.mainMenu);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.MainMenuStrip = this.mainMenu;
            this.Name = "MainForm";
            this.Text = "Draw";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.mainMenu.ResumeLayout(false);
            this.mainMenu.PerformLayout();
            this.statusBar.ResumeLayout(false);
            this.statusBar.PerformLayout();
            this.speedMenu.ResumeLayout(false);
            this.speedMenu.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar2)).EndInit();
            this.panel1.ResumeLayout(false);
            this.toolStrip3.ResumeLayout(false);
            this.toolStrip3.PerformLayout();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.toolStrip2.ResumeLayout(false);
            this.toolStrip2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

		}
		
		private System.Windows.Forms.ToolStripStatusLabel currentStatusLabel;
		private Draw.DoubleBufferedPanel viewPort;
		private System.Windows.Forms.ToolStripButton pickUpSpeedButton;
		private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem imageToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem editToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
		private System.Windows.Forms.ToolStrip speedMenu;
		private System.Windows.Forms.StatusStrip statusBar;
		private System.Windows.Forms.MenuStrip mainMenu;
        private System.Windows.Forms.ToolStripButton toolStripButton4;
        private System.Windows.Forms.ColorDialog colorDialog1;
        private System.Windows.Forms.ToolStripLabel valueLabel;
        private System.Windows.Forms.TrackBar trackBar1;
        private System.Windows.Forms.ToolStripButton toolStripButton5;
        private System.Windows.Forms.ColorDialog colorDialog2;
        private System.Windows.Forms.TrackBar trackBar2;
        private System.Windows.Forms.ToolStripButton GroupButon;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.ToolStripButton toolStripButton6;
        private System.Windows.Forms.ToolStripButton AddStarButton;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ToolStripButton rectangleButton;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton rightTriangleButton;
        private System.Windows.Forms.ToolStripButton elipseButton;
        private System.Windows.Forms.ToolStripButton sametriangleButton;
        private System.Windows.Forms.ToolStripButton arrowButton;
        private System.Windows.Forms.ToolStripButton toolStripButton1;
        private System.Windows.Forms.ToolStripButton toolStripButton2;
        private System.Windows.Forms.ToolStripButton toolStripButton3;
        private System.Windows.Forms.ToolStripButton toolStripButton7;
        private System.Windows.Forms.ToolStripButton toolStripButton8;
        private System.Windows.Forms.ToolStrip toolStrip3;
        private System.Windows.Forms.ToolStripButton Black;
        private System.Windows.Forms.ToolStripButton Gray;
        private System.Windows.Forms.ToolStripButton Red;
        private System.Windows.Forms.ToolStripButton Orange;
        private System.Windows.Forms.ToolStripButton LightOrange;
        private System.Windows.Forms.ToolStripButton Brown;
        private System.Windows.Forms.ToolStripButton Yellow;
        private System.Windows.Forms.ToolStripButton Green;
        private System.Windows.Forms.ToolStripButton Blue;
        private System.Windows.Forms.ToolStripButton Purple;
        private System.Windows.Forms.ToolStripButton White;
        private System.Windows.Forms.ToolStripButton LightGray;
        private System.Windows.Forms.ToolStripButton Pink;
        private System.Windows.Forms.ToolStripButton Yellow2;
        private System.Windows.Forms.ToolStripButton Eggshell;
        private System.Windows.Forms.ToolStripButton Lime;
        private System.Windows.Forms.ToolStripButton PaleBlue;
        private System.Windows.Forms.ToolStripButton LightPurple;
        private System.Windows.Forms.ToolStripButton Cyan;
        private System.Windows.Forms.ToolStripButton LightBlue;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStrip toolStrip2;
        private System.Windows.Forms.ToolStripButton mouseButton;
        private System.Windows.Forms.ToolStripButton paintBucket;
        private System.Windows.Forms.ToolStripButton colorPickTool;
    }
}
