namespace GUI {
    partial class MainForm {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            this.components = new System.ComponentModel.Container();
            dotnetCHARTING.WinForms.Annotation annotation1 = new dotnetCHARTING.WinForms.Annotation();
            dotnetCHARTING.WinForms.BoxHeaderOptions boxHeaderOptions1 = new dotnetCHARTING.WinForms.BoxHeaderOptions();
            dotnetCHARTING.WinForms.BoxHeaderOptions boxHeaderOptions2 = new dotnetCHARTING.WinForms.BoxHeaderOptions();
            dotnetCHARTING.WinForms.BoxHeaderOptions boxHeaderOptions3 = new dotnetCHARTING.WinForms.BoxHeaderOptions();
            dotnetCHARTING.WinForms.View3D view3D1 = new dotnetCHARTING.WinForms.View3D();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.tslDate = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.tsbOpen = new System.Windows.Forms.ToolStripButton();
            this.tsbCount = new System.Windows.Forms.ToolStripButton();
            this.tsbSize = new System.Windows.Forms.ToolStripButton();
            this.tslCategories = new System.Windows.Forms.ToolStripLabel();
            this.tscbCategories = new System.Windows.Forms.ToolStripComboBox();
            this.tsbAbout = new System.Windows.Forms.ToolStripButton();
            this.panel1 = new System.Windows.Forms.Panel();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.tvDirectories = new System.Windows.Forms.TreeView();
            this.chart1 = new dotnetCHARTING.WinForms.Chart();
            this.statusStrip1.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).BeginInit();
            this.SuspendLayout();
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tslDate});
            this.statusStrip1.Location = new System.Drawing.Point(0, 557);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(849, 22);
            this.statusStrip1.TabIndex = 1;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // tslDate
            // 
            this.tslDate.Name = "tslDate";
            this.tslDate.Size = new System.Drawing.Size(87, 17);
            this.tslDate.Text = "Directory date: ";
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsbOpen,
            this.tsbCount,
            this.tsbSize,
            this.tslCategories,
            this.tscbCategories,
            this.tsbAbout});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(849, 25);
            this.toolStrip1.TabIndex = 2;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // tsbOpen
            // 
            this.tsbOpen.Image = global::GUI.Properties.Resources.directory_opened;
            this.tsbOpen.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbOpen.Name = "tsbOpen";
            this.tsbOpen.Size = new System.Drawing.Size(56, 22);
            this.tsbOpen.Text = "Open";
            this.tsbOpen.ToolTipText = "Open a directory tree";
            this.tsbOpen.Click += new System.EventHandler(this.tsbOpen_Click);
            // 
            // tsbCount
            // 
            this.tsbCount.Checked = true;
            this.tsbCount.CheckOnClick = true;
            this.tsbCount.CheckState = System.Windows.Forms.CheckState.Checked;
            this.tsbCount.Image = global::GUI.Properties.Resources.number;
            this.tsbCount.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbCount.Name = "tsbCount";
            this.tsbCount.Size = new System.Drawing.Size(60, 22);
            this.tsbCount.Text = "Count";
            this.tsbCount.ToolTipText = "Show file counts in pie chart";
            this.tsbCount.Click += new System.EventHandler(this.tsbCount_Click);
            // 
            // tsbSize
            // 
            this.tsbSize.CheckOnClick = true;
            this.tsbSize.Image = global::GUI.Properties.Resources.size;
            this.tsbSize.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbSize.Name = "tsbSize";
            this.tsbSize.Size = new System.Drawing.Size(47, 22);
            this.tsbSize.Text = "Size";
            this.tsbSize.ToolTipText = "Show file sizes in pie chart";
            this.tsbSize.Click += new System.EventHandler(this.tsbSize_Click);
            // 
            // tslCategories
            // 
            this.tslCategories.Name = "tslCategories";
            this.tslCategories.Size = new System.Drawing.Size(69, 22);
            this.tslCategories.Text = "Categories: ";
            this.tslCategories.ToolTipText = "Select a category to group the results";
            // 
            // tscbCategories
            // 
            this.tscbCategories.Name = "tscbCategories";
            this.tscbCategories.Size = new System.Drawing.Size(121, 25);
            this.tscbCategories.ToolTipText = "Available categories";
            this.tscbCategories.SelectedIndexChanged += new System.EventHandler(this.tscbCategories_SelectedIndexChanged);
            // 
            // tsbAbout
            // 
            this.tsbAbout.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.tsbAbout.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbAbout.Image = global::GUI.Properties.Resources.about;
            this.tsbAbout.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbAbout.Name = "tsbAbout";
            this.tsbAbout.Size = new System.Drawing.Size(23, 22);
            this.tsbAbout.Text = "About";
            this.tsbAbout.Click += new System.EventHandler(this.toolStripButton1_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.splitContainer1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 25);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(849, 532);
            this.panel1.TabIndex = 3;
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.tvDirectories);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.chart1);
            this.splitContainer1.Size = new System.Drawing.Size(849, 532);
            this.splitContainer1.SplitterDistance = 281;
            this.splitContainer1.TabIndex = 1;
            // 
            // tvDirectories
            // 
            this.tvDirectories.AllowDrop = true;
            this.tvDirectories.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tvDirectories.Location = new System.Drawing.Point(0, 0);
            this.tvDirectories.Name = "tvDirectories";
            this.tvDirectories.Size = new System.Drawing.Size(281, 532);
            this.tvDirectories.TabIndex = 0;
            this.tvDirectories.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.tvDirectories_AfterSelect);
            this.tvDirectories.NodeMouseClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.tvDirectories_NodeMouseClick);
            this.tvDirectories.DragDrop += new System.Windows.Forms.DragEventHandler(this.tvDirectories_DragDrop);
            this.tvDirectories.DragEnter += new System.Windows.Forms.DragEventHandler(this.tvDirectories_DragEnter);
            this.tvDirectories.DoubleClick += new System.EventHandler(this.tvDirectories_DoubleClick);
            // 
            // chart1
            // 
            this.chart1.Background.Color = System.Drawing.Color.White;
            annotation1.Background.Color = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(219)))));
            annotation1.Background.ShadingEffectMode = dotnetCHARTING.WinForms.ShadingEffectMode.Default;
            annotation1.DynamicSize = true;
            boxHeaderOptions1.Background.Color = System.Drawing.Color.White;
            boxHeaderOptions1.Label.Alignment = System.Drawing.StringAlignment.Center;
            boxHeaderOptions1.Line.Color = System.Drawing.Color.Gray;
            boxHeaderOptions1.Shadow.Color = System.Drawing.Color.Transparent;
            annotation1.Header = boxHeaderOptions1;
            annotation1.InteriorLine.Color = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            annotation1.Line.Color = System.Drawing.Color.Gray;
            annotation1.Orientation = dotnetCHARTING.WinForms.Orientation.TopRight;
            annotation1.Padding = 4;
            annotation1.Shadow.Color = System.Drawing.Color.FromArgb(((int)(((byte)(180)))), ((int)(((byte)(100)))), ((int)(((byte)(100)))), ((int)(((byte)(100)))));
            annotation1.Shadow.Depth = 1;
            annotation1.Shadow.ExpandBy = 2F;
            annotation1.Shadow.Visible = false;
            annotation1.Size = new System.Drawing.Size(563, 531);
            annotation1.Visible = true;
            this.chart1.Box = annotation1;
            this.chart1.ChartArea.Background.Color = System.Drawing.Color.FromArgb(((int)(((byte)(232)))), ((int)(((byte)(235)))), ((int)(((byte)(238)))));
            this.chart1.ChartArea.CornerTopLeft = dotnetCHARTING.WinForms.BoxCorner.Square;
            this.chart1.ChartArea.DefaultElement.DefaultSubValue.Line.Color = System.Drawing.Color.FromArgb(((int)(((byte)(93)))), ((int)(((byte)(28)))), ((int)(((byte)(59)))));
            this.chart1.ChartArea.DefaultElement.DefaultSubValue.Visible = true;
            this.chart1.ChartArea.DefaultElement.LegendEntry.DividerLine.Color = System.Drawing.Color.Empty;
            this.chart1.ChartArea.DefaultElement.SmartLabel.Color = System.Drawing.Color.Empty;
            this.chart1.ChartArea.InteriorLine.Color = System.Drawing.Color.LightGray;
            this.chart1.ChartArea.Label.Font = new System.Drawing.Font("Tahoma", 8F);
            this.chart1.ChartArea.LegendBox.Background.Color = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(219)))));
            this.chart1.ChartArea.LegendBox.CornerBottomRight = dotnetCHARTING.WinForms.BoxCorner.Cut;
            this.chart1.ChartArea.LegendBox.DefaultEntry.DividerLine.Color = System.Drawing.Color.Empty;
            boxHeaderOptions2.Background.Color = System.Drawing.Color.White;
            boxHeaderOptions2.Label.Alignment = System.Drawing.StringAlignment.Center;
            boxHeaderOptions2.Line.Color = System.Drawing.Color.Gray;
            boxHeaderOptions2.Shadow.Color = System.Drawing.Color.Transparent;
            this.chart1.ChartArea.LegendBox.Header = boxHeaderOptions2;
            this.chart1.ChartArea.LegendBox.HeaderEntry.DividerLine.Color = System.Drawing.Color.Gray;
            this.chart1.ChartArea.LegendBox.HeaderEntry.Name = "Name";
            this.chart1.ChartArea.LegendBox.HeaderEntry.SortOrder = -1;
            this.chart1.ChartArea.LegendBox.HeaderEntry.Value = "Value";
            this.chart1.ChartArea.LegendBox.HeaderEntry.Visible = false;
            this.chart1.ChartArea.LegendBox.InteriorLine.Color = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.chart1.ChartArea.LegendBox.LabelStyle.Font = new System.Drawing.Font("Trebuchet MS", 8F);
            this.chart1.ChartArea.LegendBox.Line.Color = System.Drawing.Color.Gray;
            this.chart1.ChartArea.LegendBox.Padding = 4;
            this.chart1.ChartArea.LegendBox.Position = dotnetCHARTING.WinForms.LegendBoxPosition.Top;
            this.chart1.ChartArea.LegendBox.Shadow.ExpandBy = 2F;
            this.chart1.ChartArea.LegendBox.Visible = true;
            this.chart1.ChartArea.Line.Color = System.Drawing.Color.Gray;
            this.chart1.ChartArea.Shadow.Color = System.Drawing.Color.FromArgb(((int)(((byte)(180)))), ((int)(((byte)(100)))), ((int)(((byte)(100)))), ((int)(((byte)(100)))));
            this.chart1.ChartArea.Shadow.Depth = 1;
            this.chart1.ChartArea.Shadow.ExpandBy = 2F;
            this.chart1.ChartArea.StartDateOfYear = new System.DateTime(((long)(0)));
            this.chart1.ChartArea.TitleBox.Background.Color = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(219)))));
            boxHeaderOptions3.Background.Color = System.Drawing.Color.White;
            boxHeaderOptions3.Label.Alignment = System.Drawing.StringAlignment.Center;
            boxHeaderOptions3.Line.Color = System.Drawing.Color.Gray;
            boxHeaderOptions3.Shadow.Color = System.Drawing.Color.Transparent;
            this.chart1.ChartArea.TitleBox.Header = boxHeaderOptions3;
            this.chart1.ChartArea.TitleBox.InteriorLine.Color = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.chart1.ChartArea.TitleBox.Label.Color = System.Drawing.Color.FromArgb(((int)(((byte)(97)))), ((int)(((byte)(45)))), ((int)(((byte)(38)))));
            this.chart1.ChartArea.TitleBox.Label.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.chart1.ChartArea.TitleBox.Label.LineAlignment = System.Drawing.StringAlignment.Center;
            this.chart1.ChartArea.TitleBox.Line.Color = System.Drawing.Color.Gray;
            this.chart1.ChartArea.TitleBox.Shadow.ExpandBy = 2F;
            this.chart1.ChartArea.TitleBox.Visible = true;
            this.chart1.ChartArea.XAxis.DefaultTick.GridLine.Color = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(230)))), ((int)(((byte)(230)))));
            this.chart1.ChartArea.XAxis.DefaultTick.Line.Length = 3;
            this.chart1.ChartArea.XAxis.MinorTimeIntervalAdvanced.Start = new System.DateTime(((long)(0)));
            this.chart1.ChartArea.XAxis.MinorTimeIntervalAdvanced.Unit = dotnetCHARTING.WinForms.TimeInterval.None;
            this.chart1.ChartArea.XAxis.ScaleBreakLine.Color = System.Drawing.Color.Gray;
            this.chart1.ChartArea.XAxis.TimeIntervalAdvanced.Start = new System.DateTime(((long)(0)));
            this.chart1.ChartArea.XAxis.TimeIntervalAdvanced.Unit = dotnetCHARTING.WinForms.TimeInterval.Months;
            this.chart1.ChartArea.XAxis.ZeroTick.GridLine.Color = System.Drawing.Color.Red;
            this.chart1.ChartArea.XAxis.ZeroTick.Line.Length = 3;
            this.chart1.ChartArea.YAxis.DefaultTick.GridLine.Color = System.Drawing.Color.FromArgb(((int)(((byte)(198)))), ((int)(((byte)(198)))), ((int)(((byte)(198)))));
            this.chart1.ChartArea.YAxis.DefaultTick.Line.Length = 3;
            this.chart1.ChartArea.YAxis.ScaleBreakLine.Color = System.Drawing.Color.Gray;
            this.chart1.ChartArea.YAxis.TimeIntervalAdvanced.Start = new System.DateTime(((long)(0)));
            this.chart1.ChartArea.YAxis.TimeIntervalAdvanced.Unit = dotnetCHARTING.WinForms.TimeInterval.Months;
            this.chart1.ChartArea.YAxis.ZeroTick.GridLine.Color = System.Drawing.Color.Red;
            this.chart1.ChartArea.YAxis.ZeroTick.Line.Length = 3;
            this.chart1.DataGrid = null;
            this.chart1.DefaultElement.DefaultSubValue.Visible = true;
            this.chart1.DefaultElement.LegendEntry.DividerLine.Color = System.Drawing.Color.Empty;
            this.chart1.DefaultShadow.ExpandBy = 2F;
            this.chart1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.chart1.LegacyMode = false;
            this.chart1.Location = new System.Drawing.Point(0, 0);
            this.chart1.Name = "chart1";
            this.chart1.NoDataLabel.Text = "No Data";
            this.chart1.Size = new System.Drawing.Size(564, 532);
            this.chart1.StartDateOfYear = new System.DateTime(((long)(0)));
            this.chart1.TabIndex = 1;
            this.chart1.TempDirectory = "C:\\Documents and Settings\\pcartgrandjean\\Local Settings\\Temp\\";
            this.chart1.Type = dotnetCHARTING.WinForms.ChartType.Pie;
            this.chart1.Use3D = true;
            this.chart1.View3D = view3D1;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(849, 579);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.statusStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "MainForm";
            this.Text = "FileExtensions";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel tslDate;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton tsbOpen;
        private System.Windows.Forms.ToolStripButton tsbCount;
        private System.Windows.Forms.ToolStripButton tsbSize;
        private System.Windows.Forms.ToolStripLabel tslCategories;
        private System.Windows.Forms.ToolStripComboBox tscbCategories;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.TreeView tvDirectories;
        private dotnetCHARTING.WinForms.Chart chart1;
        private System.Windows.Forms.ToolStripButton tsbAbout;
    }
}

