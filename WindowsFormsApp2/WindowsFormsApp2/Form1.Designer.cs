
namespace WindowsFormsApp2
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
            this.yesTriangleToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.noTriangleToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.jPGToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.projectToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.elipsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.paintToolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.nopaintToolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.saveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.brushToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.lainToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.treugolToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.colorToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // yesTriangleToolStripMenuItem
            // 
            this.yesTriangleToolStripMenuItem.Name = "yesTriangleToolStripMenuItem";
            this.yesTriangleToolStripMenuItem.Size = new System.Drawing.Size(163, 22);
            this.yesTriangleToolStripMenuItem.Text = "закрашенные";
            this.yesTriangleToolStripMenuItem.Click += new System.EventHandler(this.yesTriangleToolStripMenuItem_Click);
            // 
            // noTriangleToolStripMenuItem
            // 
            this.noTriangleToolStripMenuItem.Name = "noTriangleToolStripMenuItem";
            this.noTriangleToolStripMenuItem.Size = new System.Drawing.Size(163, 22);
            this.noTriangleToolStripMenuItem.Text = "незакрашенные";
            this.noTriangleToolStripMenuItem.Click += new System.EventHandler(this.noTriangleToolStripMenuItem_Click);
            // 
            // jPGToolStripMenuItem
            // 
            this.jPGToolStripMenuItem.Name = "jPGToolStripMenuItem";
            this.jPGToolStripMenuItem.Size = new System.Drawing.Size(111, 22);
            this.jPGToolStripMenuItem.Text = "JPG";
            this.jPGToolStripMenuItem.Click += new System.EventHandler(this.jPGToolStripMenuItem_Click);
            // 
            // projectToolStripMenuItem
            // 
            this.projectToolStripMenuItem.Name = "projectToolStripMenuItem";
            this.projectToolStripMenuItem.Size = new System.Drawing.Size(111, 22);
            this.projectToolStripMenuItem.Text = "Project";
            // 
            // elipsToolStripMenuItem
            // 
            this.elipsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.paintToolStripMenuItem2,
            this.nopaintToolStripMenuItem2});
            this.elipsToolStripMenuItem.Name = "elipsToolStripMenuItem";
            this.elipsToolStripMenuItem.Size = new System.Drawing.Size(52, 20);
            this.elipsToolStripMenuItem.Text = "элипс";
            // 
            // paintToolStripMenuItem2
            // 
            this.paintToolStripMenuItem2.Name = "paintToolStripMenuItem2";
            this.paintToolStripMenuItem2.Size = new System.Drawing.Size(180, 22);
            this.paintToolStripMenuItem2.Text = "закрашенные";
            // 
            // nopaintToolStripMenuItem2
            // 
            this.nopaintToolStripMenuItem2.Name = "nopaintToolStripMenuItem2";
            this.nopaintToolStripMenuItem2.Size = new System.Drawing.Size(180, 22);
            this.nopaintToolStripMenuItem2.Text = "незакрашенные";
            // 
            // saveToolStripMenuItem
            // 
            this.saveToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.jPGToolStripMenuItem,
            this.projectToolStripMenuItem});
            this.saveToolStripMenuItem.Name = "saveToolStripMenuItem";
            this.saveToolStripMenuItem.Size = new System.Drawing.Size(76, 20);
            this.saveToolStripMenuItem.Text = "сохранить";
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.brushToolStripMenuItem,
            this.lainToolStripMenuItem,
            this.treugolToolStripMenuItem,
            this.elipsToolStripMenuItem,
            this.saveToolStripMenuItem,
            this.colorToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(800, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // brushToolStripMenuItem
            // 
            this.brushToolStripMenuItem.Name = "brushToolStripMenuItem";
            this.brushToolStripMenuItem.Size = new System.Drawing.Size(49, 20);
            this.brushToolStripMenuItem.Text = "кисть";
            this.brushToolStripMenuItem.Click += new System.EventHandler(this.brushToolStripMenuItem_Click);
            // 
            // lainToolStripMenuItem
            // 
            this.lainToolStripMenuItem.Name = "lainToolStripMenuItem";
            this.lainToolStripMenuItem.Size = new System.Drawing.Size(54, 20);
            this.lainToolStripMenuItem.Text = "линий";
            this.lainToolStripMenuItem.Click += new System.EventHandler(this.lainToolStripMenuItem_Click);
            // 
            // treugolToolStripMenuItem
            // 
            this.treugolToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.yesTriangleToolStripMenuItem,
            this.noTriangleToolStripMenuItem});
            this.treugolToolStripMenuItem.Name = "treugolToolStripMenuItem";
            this.treugolToolStripMenuItem.Size = new System.Drawing.Size(95, 20);
            this.treugolToolStripMenuItem.Text = "треугольники";
            // 
            // colorToolStripMenuItem
            // 
            this.colorToolStripMenuItem.Name = "colorToolStripMenuItem";
            this.colorToolStripMenuItem.Size = new System.Drawing.Size(45, 20);
            this.colorToolStripMenuItem.Text = "Цвет";
            this.colorToolStripMenuItem.Click += new System.EventHandler(this.colorToolStripMenuItem_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.Text = "Form1";
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.Form1_Paint);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Form1_MouseDown);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem brushToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem lainToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem treugolToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem yesTriangleToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem noTriangleToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem elipsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem paintToolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem nopaintToolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem saveToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem jPGToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem projectToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem colorToolStripMenuItem;
    }
}

