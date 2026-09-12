namespace DynamicMaze2
{
    partial class Form1
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
            this.components = new System.ComponentModel.Container();
            this.txtHeight = new System.Windows.Forms.TextBox();
            this.txtWidth = new System.Windows.Forms.TextBox();
            this.mazeArea = new System.Windows.Forms.PictureBox();
            this.btnCreate = new System.Windows.Forms.Button();
            this.pathDrawTimer = new System.Windows.Forms.Timer(this.components);
            this.timer2 = new System.Windows.Forms.Timer(this.components);
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.rbBFS = new System.Windows.Forms.RadioButton();
            this.rbDFS = new System.Windows.Forms.RadioButton();
            ((System.ComponentModel.ISupportInitialize)(this.mazeArea)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtHeight
            // 
            this.txtHeight.Location = new System.Drawing.Point(176, 100);
            this.txtHeight.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtHeight.Name = "txtHeight";
            this.txtHeight.Size = new System.Drawing.Size(148, 26);
            this.txtHeight.TabIndex = 0;
            // 
            // txtWidth
            // 
            this.txtWidth.Location = new System.Drawing.Point(176, 45);
            this.txtWidth.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtWidth.Name = "txtWidth";
            this.txtWidth.Size = new System.Drawing.Size(148, 26);
            this.txtWidth.TabIndex = 1;
            // 
            // mazeArea
            // 
            this.mazeArea.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.mazeArea.Location = new System.Drawing.Point(125, 254);
            this.mazeArea.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.mazeArea.Name = "mazeArea";
            this.mazeArea.Size = new System.Drawing.Size(1134, 675);
            this.mazeArea.TabIndex = 2;
            this.mazeArea.TabStop = false;
            // 
            // btnCreate
            // 
            this.btnCreate.ForeColor = System.Drawing.SystemColors.WindowFrame;
            this.btnCreate.Location = new System.Drawing.Point(115, 149);
            this.btnCreate.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnCreate.Name = "btnCreate";
            this.btnCreate.Size = new System.Drawing.Size(209, 38);
            this.btnCreate.TabIndex = 3;
            this.btnCreate.Text = "Generate Random Maze";
            this.btnCreate.UseVisualStyleBackColor = true;
            this.btnCreate.Click += new System.EventHandler(this.btnCreate_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.txtWidth);
            this.groupBox1.Controls.Add(this.btnCreate);
            this.groupBox1.Controls.Add(this.txtHeight);
            this.groupBox1.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.groupBox1.Location = new System.Drawing.Point(366, 30);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.groupBox1.Size = new System.Drawing.Size(360, 196);
            this.groupBox1.TabIndex = 6;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Maze Generation";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(20, 100);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(127, 20);
            this.label2.TabIndex = 3;
            this.label2.Text = "Number of Rows";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(20, 51);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(149, 20);
            this.label1.TabIndex = 2;
            this.label1.Text = "Number of Columns";
            // 
            // groupBox2
            // 
            this.groupBox2.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.groupBox2.Controls.Add(this.rbBFS);
            this.groupBox2.Controls.Add(this.rbDFS);
            this.groupBox2.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.groupBox2.Location = new System.Drawing.Point(770, 41);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.groupBox2.Size = new System.Drawing.Size(297, 185);
            this.groupBox2.TabIndex = 7;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Maze Traversal";
            // 
            // rbBFS
            // 
            this.rbBFS.AutoSize = true;
            this.rbBFS.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.rbBFS.Location = new System.Drawing.Point(44, 100);
            this.rbBFS.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.rbBFS.Name = "rbBFS";
            this.rbBFS.Size = new System.Drawing.Size(181, 24);
            this.rbBFS.TabIndex = 1;
            this.rbBFS.TabStop = true;
            this.rbBFS.Text = "Breadth First Search";
            this.rbBFS.UseVisualStyleBackColor = true;
            this.rbBFS.Click += new System.EventHandler(this.rbBFS_Click);
            // 
            // rbDFS
            // 
            this.rbDFS.AutoSize = true;
            this.rbDFS.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.rbDFS.Location = new System.Drawing.Point(44, 56);
            this.rbDFS.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.rbDFS.Name = "rbDFS";
            this.rbDFS.Size = new System.Drawing.Size(168, 24);
            this.rbDFS.TabIndex = 0;
            this.rbDFS.TabStop = true;
            this.rbDFS.Text = "Depth First Search";
            this.rbDFS.UseVisualStyleBackColor = true;
            this.rbDFS.CheckedChanged += new System.EventHandler(this.rbDFS_CheckedChanged);
            this.rbDFS.Click += new System.EventHandler(this.rbDFS_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.ClientSize = new System.Drawing.Size(1272, 840);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.mazeArea);
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "Form1";
            this.Text = "MazeTraversal";
            ((System.ComponentModel.ISupportInitialize)(this.mazeArea)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TextBox txtHeight;
        private System.Windows.Forms.TextBox txtWidth;
        private System.Windows.Forms.PictureBox mazeArea;
        private System.Windows.Forms.Button btnCreate;
        private System.Windows.Forms.Timer pathDrawTimer;
        private System.Windows.Forms.Timer timer2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.RadioButton rbBFS;
        private System.Windows.Forms.RadioButton rbDFS;
    }
}

