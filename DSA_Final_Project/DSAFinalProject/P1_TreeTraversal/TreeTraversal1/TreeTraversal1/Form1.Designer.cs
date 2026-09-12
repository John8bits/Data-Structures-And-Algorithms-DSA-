namespace TreeTraversal1
{
    partial class frmTreeTraversal
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.graphingArea = new System.Windows.Forms.PictureBox();
            this.chkboxDirected = new System.Windows.Forms.CheckBox();
            this.label3 = new System.Windows.Forms.Label();
            this.rbBFS = new System.Windows.Forms.RadioButton();
            this.rbDFS = new System.Windows.Forms.RadioButton();
            this.label4 = new System.Windows.Forms.Label();
            this.txtSearchPath = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.rbUniformCost = new System.Windows.Forms.RadioButton();
            this.rbAStar = new System.Windows.Forms.RadioButton();
            this.cmbEndSPNode = new System.Windows.Forms.ComboBox();
            this.label9 = new System.Windows.Forms.Label();
            this.rbDijkstra = new System.Windows.Forms.RadioButton();
            this.cmbStartSPNode = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.rbLetter = new System.Windows.Forms.RadioButton();
            this.rbNum = new System.Windows.Forms.RadioButton();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fILEToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.newToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.loadToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exportGraphToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openGraphDialog = new System.Windows.Forms.OpenFileDialog();
            this.saveGraphDialog = new System.Windows.Forms.SaveFileDialog();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.label10 = new System.Windows.Forms.Label();
            this.rbKruskal = new System.Windows.Forms.RadioButton();
            this.rbPrims = new System.Windows.Forms.RadioButton();
            this.label2 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label14 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.graphingArea)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // graphingArea
            // 
            this.graphingArea.BackColor = System.Drawing.Color.LightSlateGray;
            this.graphingArea.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.graphingArea.Location = new System.Drawing.Point(18, 86);
            this.graphingArea.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.graphingArea.Name = "graphingArea";
            this.graphingArea.Size = new System.Drawing.Size(1056, 596);
            this.graphingArea.TabIndex = 0;
            this.graphingArea.TabStop = false;
            this.graphingArea.MouseClick += new System.Windows.Forms.MouseEventHandler(this.graphingAreaMouseClicked);
            // 
            // chkboxDirected
            // 
            this.chkboxDirected.AutoSize = true;
            this.chkboxDirected.Location = new System.Drawing.Point(189, 18);
            this.chkboxDirected.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.chkboxDirected.Name = "chkboxDirected";
            this.chkboxDirected.Size = new System.Drawing.Size(22, 21);
            this.chkboxDirected.TabIndex = 6;
            this.chkboxDirected.UseVisualStyleBackColor = true;
            this.chkboxDirected.CheckedChanged += new System.EventHandler(this.chkboxDirected_CheckedChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(15, 14);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(157, 25);
            this.label3.TabIndex = 7;
            this.label3.Text = "Directed Graph";
            // 
            // rbBFS
            // 
            this.rbBFS.AutoSize = true;
            this.rbBFS.Location = new System.Drawing.Point(28, 97);
            this.rbBFS.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.rbBFS.Name = "rbBFS";
            this.rbBFS.Size = new System.Drawing.Size(235, 29);
            this.rbBFS.TabIndex = 1;
            this.rbBFS.TabStop = true;
            this.rbBFS.Text = "Breadth First Search";
            this.rbBFS.UseVisualStyleBackColor = true;
            this.rbBFS.MouseClick += new System.Windows.Forms.MouseEventHandler(this.rbBFS_CheckedChanged);
            // 
            // rbDFS
            // 
            this.rbDFS.AutoSize = true;
            this.rbDFS.Location = new System.Drawing.Point(28, 63);
            this.rbDFS.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.rbDFS.Name = "rbDFS";
            this.rbDFS.Size = new System.Drawing.Size(217, 29);
            this.rbDFS.TabIndex = 0;
            this.rbDFS.TabStop = true;
            this.rbDFS.Text = "Depth First Search";
            this.rbDFS.UseVisualStyleBackColor = true;
            this.rbDFS.MouseClick += new System.Windows.Forms.MouseEventHandler(this.rbDFS_CheckedChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(609, 16);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(131, 25);
            this.label4.TabIndex = 7;
            this.label4.Text = "Search Path";
            // 
            // txtSearchPath
            // 
            this.txtSearchPath.Enabled = false;
            this.txtSearchPath.Location = new System.Drawing.Point(748, 14);
            this.txtSearchPath.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtSearchPath.Name = "txtSearchPath";
            this.txtSearchPath.Size = new System.Drawing.Size(294, 30);
            this.txtSearchPath.TabIndex = 8;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(14, 52);
            this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(187, 25);
            this.label7.TabIndex = 10;
            this.label7.Text = "GRAPHING AREA";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(1140, 52);
            this.label8.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(232, 25);
            this.label8.TabIndex = 11;
            this.label8.Text = "ADJACENCY MATRIX";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.label13.Location = new System.Drawing.Point(738, 43);
            this.label13.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(205, 29);
            this.label13.TabIndex = 16;
            this.label13.Text = "Heuristic Search";
            // 
            // rbUniformCost
            // 
            this.rbUniformCost.AutoSize = true;
            this.rbUniformCost.Location = new System.Drawing.Point(768, 106);
            this.rbUniformCost.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.rbUniformCost.Name = "rbUniformCost";
            this.rbUniformCost.Size = new System.Drawing.Size(162, 29);
            this.rbUniformCost.TabIndex = 14;
            this.rbUniformCost.TabStop = true;
            this.rbUniformCost.Text = "Uniform Cost";
            this.rbUniformCost.UseVisualStyleBackColor = true;
            this.rbUniformCost.CheckedChanged += new System.EventHandler(this.rbUniformCost_CheckedChanged);
            // 
            // rbAStar
            // 
            this.rbAStar.AutoSize = true;
            this.rbAStar.Location = new System.Drawing.Point(768, 135);
            this.rbAStar.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.rbAStar.Name = "rbAStar";
            this.rbAStar.Size = new System.Drawing.Size(67, 29);
            this.rbAStar.TabIndex = 13;
            this.rbAStar.TabStop = true;
            this.rbAStar.Text = "A* ";
            this.rbAStar.UseVisualStyleBackColor = true;
            this.rbAStar.CheckedChanged += new System.EventHandler(this.rbAStar_CheckedChanged);
            this.rbAStar.MouseClick += new System.Windows.Forms.MouseEventHandler(this.rbAStar_CheckedChanged);
            // 
            // cmbEndSPNode
            // 
            this.cmbEndSPNode.FormattingEnabled = true;
            this.cmbEndSPNode.Location = new System.Drawing.Point(400, 692);
            this.cmbEndSPNode.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.cmbEndSPNode.Name = "cmbEndSPNode";
            this.cmbEndSPNode.Size = new System.Drawing.Size(122, 28);
            this.cmbEndSPNode.TabIndex = 12;
            this.cmbEndSPNode.SelectedIndexChanged += new System.EventHandler(this.cmbEndSPNode_SelectedIndexChanged);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.label9.Location = new System.Drawing.Point(284, 695);
            this.label9.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(105, 22);
            this.label9.TabIndex = 10;
            this.label9.Text = "Goal Node";
            // 
            // rbDijkstra
            // 
            this.rbDijkstra.AutoSize = true;
            this.rbDijkstra.Location = new System.Drawing.Point(768, 77);
            this.rbDijkstra.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.rbDijkstra.Name = "rbDijkstra";
            this.rbDijkstra.Size = new System.Drawing.Size(109, 29);
            this.rbDijkstra.TabIndex = 2;
            this.rbDijkstra.TabStop = true;
            this.rbDijkstra.Text = "Dijkstra";
            this.rbDijkstra.UseVisualStyleBackColor = true;
            this.rbDijkstra.CheckedChanged += new System.EventHandler(this.rbDijkstra_CheckedChanged);
            // 
            // cmbStartSPNode
            // 
            this.cmbStartSPNode.FormattingEnabled = true;
            this.cmbStartSPNode.Location = new System.Drawing.Point(138, 692);
            this.cmbStartSPNode.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.cmbStartSPNode.Name = "cmbStartSPNode";
            this.cmbStartSPNode.Size = new System.Drawing.Size(122, 28);
            this.cmbStartSPNode.TabIndex = 11;
            this.cmbStartSPNode.SelectedIndexChanged += new System.EventHandler(this.cmbStartSPNode_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(24, 695);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(106, 22);
            this.label1.TabIndex = 8;
            this.label1.Text = "Start Node";
            // 
            // rbLetter
            // 
            this.rbLetter.AutoSize = true;
            this.rbLetter.Location = new System.Drawing.Point(492, 14);
            this.rbLetter.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.rbLetter.Name = "rbLetter";
            this.rbLetter.Size = new System.Drawing.Size(92, 29);
            this.rbLetter.TabIndex = 4;
            this.rbLetter.Text = "Letter";
            this.rbLetter.UseVisualStyleBackColor = true;
            this.rbLetter.Click += new System.EventHandler(this.rbLetter_Click);
            // 
            // rbNum
            // 
            this.rbNum.AutoSize = true;
            this.rbNum.Checked = true;
            this.rbNum.Location = new System.Drawing.Point(372, 12);
            this.rbNum.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.rbNum.Name = "rbNum";
            this.rbNum.Size = new System.Drawing.Size(112, 29);
            this.rbNum.TabIndex = 3;
            this.rbNum.TabStop = true;
            this.rbNum.Text = "Number";
            this.rbNum.UseVisualStyleBackColor = true;
            this.rbNum.Click += new System.EventHandler(this.rbNum_Click);
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.Color.PowderBlue;
            this.menuStrip1.GripMargin = new System.Windows.Forms.Padding(2, 2, 0, 2);
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fILEToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(6, 3, 0, 3);
            this.menuStrip1.Size = new System.Drawing.Size(1540, 35);
            this.menuStrip1.TabIndex = 14;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fILEToolStripMenuItem
            // 
            this.fILEToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newToolStripMenuItem,
            this.loadToolStripMenuItem,
            this.exportGraphToolStripMenuItem,
            this.exitToolStripMenuItem});
            this.fILEToolStripMenuItem.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.749999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.fILEToolStripMenuItem.Name = "fILEToolStripMenuItem";
            this.fILEToolStripMenuItem.Size = new System.Drawing.Size(69, 29);
            this.fILEToolStripMenuItem.Text = "FILE";
            // 
            // newToolStripMenuItem
            // 
            this.newToolStripMenuItem.Name = "newToolStripMenuItem";
            this.newToolStripMenuItem.Size = new System.Drawing.Size(229, 34);
            this.newToolStripMenuItem.Text = "New Graph";
            this.newToolStripMenuItem.Click += new System.EventHandler(this.newToolStripMenuItem_Click);
            // 
            // loadToolStripMenuItem
            // 
            this.loadToolStripMenuItem.Name = "loadToolStripMenuItem";
            this.loadToolStripMenuItem.Size = new System.Drawing.Size(229, 34);
            this.loadToolStripMenuItem.Text = "Import Graph";
            this.loadToolStripMenuItem.Click += new System.EventHandler(this.loadToolStripMenuItem_Click);
            // 
            // exportGraphToolStripMenuItem
            // 
            this.exportGraphToolStripMenuItem.Name = "exportGraphToolStripMenuItem";
            this.exportGraphToolStripMenuItem.Size = new System.Drawing.Size(229, 34);
            this.exportGraphToolStripMenuItem.Text = "Export Graph";
            this.exportGraphToolStripMenuItem.Click += new System.EventHandler(this.exportGraphToolStripMenuItem_Click);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(229, 34);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // openGraphDialog
            // 
            this.openGraphDialog.FileName = "openFileDialog1";
            this.openGraphDialog.FileOk += new System.ComponentModel.CancelEventHandler(this.openGraphDialog_FileOk);
            // 
            // saveGraphDialog
            // 
            this.saveGraphDialog.FileOk += new System.ComponentModel.CancelEventHandler(this.saveGraphDialog_FileOk);
            // 
            // listBox1
            // 
            this.listBox1.BackColor = System.Drawing.Color.LightSteelBlue;
            this.listBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.listBox1.FormattingEnabled = true;
            this.listBox1.ItemHeight = 29;
            this.listBox1.Location = new System.Drawing.Point(1145, 725);
            this.listBox1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(327, 265);
            this.listBox1.TabIndex = 15;
            this.listBox1.Visible = false;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(1203, 682);
            this.label10.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(204, 25);
            this.label10.TabIndex = 16;
            this.label10.Text = "HEURISTIC VALUE";
            this.label10.Visible = false;
            // 
            // rbKruskal
            // 
            this.rbKruskal.AutoSize = true;
            this.rbKruskal.Location = new System.Drawing.Point(380, 91);
            this.rbKruskal.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.rbKruskal.Name = "rbKruskal";
            this.rbKruskal.Size = new System.Drawing.Size(223, 29);
            this.rbKruskal.TabIndex = 1;
            this.rbKruskal.TabStop = true;
            this.rbKruskal.Text = "Kruskal\'s Algorithm";
            this.rbKruskal.UseVisualStyleBackColor = true;
            this.rbKruskal.MouseClick += new System.Windows.Forms.MouseEventHandler(this.rbKruskal_CheckedChanged);
            // 
            // rbPrims
            // 
            this.rbPrims.AutoSize = true;
            this.rbPrims.Location = new System.Drawing.Point(380, 57);
            this.rbPrims.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.rbPrims.Name = "rbPrims";
            this.rbPrims.Size = new System.Drawing.Size(193, 29);
            this.rbPrims.TabIndex = 0;
            this.rbPrims.TabStop = true;
            this.rbPrims.Text = "Prim\'s Algorithm";
            this.rbPrims.UseVisualStyleBackColor = true;
            this.rbPrims.MouseClick += new System.Windows.Forms.MouseEventHandler(this.rbPrims_CheckedChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(219, 15);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(129, 25);
            this.label2.TabIndex = 8;
            this.label2.Text = "Node Label:";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Gold;
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.rbLetter);
            this.panel1.Controls.Add(this.chkboxDirected);
            this.panel1.Controls.Add(this.rbNum);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.txtSearchPath);
            this.panel1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.749999F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panel1.Location = new System.Drawing.Point(19, 733);
            this.panel1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1050, 57);
            this.panel1.TabIndex = 18;
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.LightSteelBlue;
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.label14);
            this.panel2.Controls.Add(this.label11);
            this.panel2.Controls.Add(this.label5);
            this.panel2.Controls.Add(this.rbBFS);
            this.panel2.Controls.Add(this.rbKruskal);
            this.panel2.Controls.Add(this.rbDFS);
            this.panel2.Controls.Add(this.rbPrims);
            this.panel2.Controls.Add(this.label13);
            this.panel2.Controls.Add(this.rbUniformCost);
            this.panel2.Controls.Add(this.rbAStar);
            this.panel2.Controls.Add(this.rbDijkstra);
            this.panel2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panel2.Location = new System.Drawing.Point(19, 801);
            this.panel2.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1050, 189);
            this.panel2.TabIndex = 20;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(705, 18);
            this.label14.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(271, 25);
            this.label14.TabIndex = 23;
            this.label14.Text = "SEARCHING ALGORITHM";
            this.label14.Click += new System.EventHandler(this.label14_Click);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(328, 18);
            this.label11.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(287, 25);
            this.label11.TabIndex = 22;
            this.label11.Text = "MINIMUM SPANNING TREE";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(14, 18);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(217, 25);
            this.label5.TabIndex = 20;
            this.label5.Text = "TREE TRAVERSALS";
            // 
            // frmTreeTraversal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DeepSkyBlue;
            this.ClientSize = new System.Drawing.Size(1540, 1050);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.listBox1);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.cmbStartSPNode);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.graphingArea);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.cmbEndSPNode);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label9);
            this.MainMenuStrip = this.menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "frmTreeTraversal";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.frmTreeTraversal_Load);
            this.VisibleChanged += new System.EventHandler(this.rbAStar_CheckedChanged);
            ((System.ComponentModel.ISupportInitialize)(this.graphingArea)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox graphingArea;
        private System.Windows.Forms.CheckBox chkboxDirected;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.RadioButton rbBFS;
        private System.Windows.Forms.RadioButton rbDFS;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtSearchPath;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cmbEndSPNode;
        private System.Windows.Forms.ComboBox cmbStartSPNode;
        private System.Windows.Forms.RadioButton rbLetter;
        private System.Windows.Forms.RadioButton rbNum;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fILEToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem newToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem loadToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exportGraphToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.OpenFileDialog openGraphDialog;
        private System.Windows.Forms.SaveFileDialog saveGraphDialog;
        private System.Windows.Forms.RadioButton rbAStar;
        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.RadioButton rbKruskal;
        private System.Windows.Forms.RadioButton rbPrims;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.RadioButton rbUniformCost;
        private System.Windows.Forms.RadioButton rbDijkstra;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label5;
    }
}
