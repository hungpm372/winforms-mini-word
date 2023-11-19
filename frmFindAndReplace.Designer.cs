namespace MiniWord_PhanMinhHưng
{
    partial class frmFindAndReplace
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmFindAndReplace));
            this.label1 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.tbFind = new System.Windows.Forms.TextBox();
            this.pnlReplace = new System.Windows.Forms.Panel();
            this.tbReplace = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.pnlButtons = new System.Windows.Forms.Panel();
            this.panel6 = new System.Windows.Forms.Panel();
            this.btnReplaceAll = new System.Windows.Forms.Button();
            this.panel5 = new System.Windows.Forms.Panel();
            this.btnReplace = new System.Windows.Forms.Button();
            this.panel4 = new System.Windows.Forms.Panel();
            this.btnFindNext = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.pnlReplace.SuspendLayout();
            this.pnlButtons.SuspendLayout();
            this.panel6.SuspendLayout();
            this.panel5.SuspendLayout();
            this.panel4.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Calibri", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(0, 10);
            this.label1.Margin = new System.Windows.Forms.Padding(0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(84, 21);
            this.label1.TabIndex = 0;
            this.label1.Text = "Find what:";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.tbFind);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Location = new System.Drawing.Point(12, 12);
            this.panel1.Margin = new System.Windows.Forms.Padding(0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(400, 41);
            this.panel1.TabIndex = 1;
            // 
            // tbFind
            // 
            this.tbFind.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbFind.Location = new System.Drawing.Point(138, 7);
            this.tbFind.Name = "tbFind";
            this.tbFind.Size = new System.Drawing.Size(262, 27);
            this.tbFind.TabIndex = 1;
            this.tbFind.TextChanged += new System.EventHandler(this.tbFind_TextChanged);
            // 
            // pnlReplace
            // 
            this.pnlReplace.Controls.Add(this.tbReplace);
            this.pnlReplace.Controls.Add(this.label2);
            this.pnlReplace.Location = new System.Drawing.Point(12, 53);
            this.pnlReplace.Margin = new System.Windows.Forms.Padding(0);
            this.pnlReplace.Name = "pnlReplace";
            this.pnlReplace.Size = new System.Drawing.Size(400, 41);
            this.pnlReplace.TabIndex = 2;
            // 
            // tbReplace
            // 
            this.tbReplace.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbReplace.Location = new System.Drawing.Point(138, 7);
            this.tbReplace.Name = "tbReplace";
            this.tbReplace.Size = new System.Drawing.Size(262, 27);
            this.tbReplace.TabIndex = 1;
            this.tbReplace.TextChanged += new System.EventHandler(this.tbReplace_TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Calibri", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(0, 10);
            this.label2.Margin = new System.Windows.Forms.Padding(0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(103, 21);
            this.label2.TabIndex = 0;
            this.label2.Text = "Replace with:";
            // 
            // pnlButtons
            // 
            this.pnlButtons.BackColor = System.Drawing.Color.White;
            this.pnlButtons.Controls.Add(this.panel6);
            this.pnlButtons.Controls.Add(this.panel5);
            this.pnlButtons.Controls.Add(this.panel4);
            this.pnlButtons.Location = new System.Drawing.Point(428, 12);
            this.pnlButtons.Margin = new System.Windows.Forms.Padding(0);
            this.pnlButtons.Name = "pnlButtons";
            this.pnlButtons.Size = new System.Drawing.Size(95, 120);
            this.pnlButtons.TabIndex = 3;
            // 
            // panel6
            // 
            this.panel6.Controls.Add(this.btnReplaceAll);
            this.panel6.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel6.Location = new System.Drawing.Point(0, 80);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(95, 40);
            this.panel6.TabIndex = 2;
            // 
            // btnReplaceAll
            // 
            this.btnReplaceAll.AutoSize = true;
            this.btnReplaceAll.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(245)))), ((int)(((byte)(252)))));
            this.btnReplaceAll.Enabled = false;
            this.btnReplaceAll.FlatAppearance.BorderColor = System.Drawing.Color.Red;
            this.btnReplaceAll.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnReplaceAll.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnReplaceAll.Location = new System.Drawing.Point(0, 5);
            this.btnReplaceAll.Name = "btnReplaceAll";
            this.btnReplaceAll.Size = new System.Drawing.Size(95, 30);
            this.btnReplaceAll.TabIndex = 0;
            this.btnReplaceAll.Text = "Replace All";
            this.btnReplaceAll.UseVisualStyleBackColor = false;
            this.btnReplaceAll.Click += new System.EventHandler(this.btnReplaceAll_Click);
            // 
            // panel5
            // 
            this.panel5.Controls.Add(this.btnReplace);
            this.panel5.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel5.Location = new System.Drawing.Point(0, 40);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(95, 40);
            this.panel5.TabIndex = 1;
            // 
            // btnReplace
            // 
            this.btnReplace.AutoSize = true;
            this.btnReplace.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(245)))), ((int)(((byte)(252)))));
            this.btnReplace.Enabled = false;
            this.btnReplace.FlatAppearance.BorderColor = System.Drawing.Color.Red;
            this.btnReplace.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnReplace.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnReplace.Location = new System.Drawing.Point(0, 5);
            this.btnReplace.Name = "btnReplace";
            this.btnReplace.Size = new System.Drawing.Size(95, 30);
            this.btnReplace.TabIndex = 0;
            this.btnReplace.Text = "Replace";
            this.btnReplace.UseVisualStyleBackColor = false;
            this.btnReplace.Click += new System.EventHandler(this.btnReplace_Click);
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.btnFindNext);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel4.Location = new System.Drawing.Point(0, 0);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(95, 40);
            this.panel4.TabIndex = 0;
            // 
            // btnFindNext
            // 
            this.btnFindNext.AutoSize = true;
            this.btnFindNext.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(245)))), ((int)(((byte)(252)))));
            this.btnFindNext.Enabled = false;
            this.btnFindNext.FlatAppearance.BorderColor = System.Drawing.Color.Red;
            this.btnFindNext.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnFindNext.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnFindNext.Location = new System.Drawing.Point(0, 5);
            this.btnFindNext.Name = "btnFindNext";
            this.btnFindNext.Size = new System.Drawing.Size(95, 30);
            this.btnFindNext.TabIndex = 0;
            this.btnFindNext.Text = "Find Next";
            this.btnFindNext.UseVisualStyleBackColor = false;
            this.btnFindNext.Click += new System.EventHandler(this.btnFindNext_Click);
            // 
            // frmFindAndReplace
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(541, 133);
            this.Controls.Add(this.pnlButtons);
            this.Controls.Add(this.pnlReplace);
            this.Controls.Add(this.panel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmFindAndReplace";
            this.Padding = new System.Windows.Forms.Padding(0, 0, 15, 10);
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmFindAndReplace";
            this.Load += new System.EventHandler(this.frmFindAndReplace_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.pnlReplace.ResumeLayout(false);
            this.pnlReplace.PerformLayout();
            this.pnlButtons.ResumeLayout(false);
            this.panel6.ResumeLayout(false);
            this.panel6.PerformLayout();
            this.panel5.ResumeLayout(false);
            this.panel5.PerformLayout();
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox tbFind;
        private System.Windows.Forms.Panel pnlReplace;
        private System.Windows.Forms.TextBox tbReplace;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel pnlButtons;
        private System.Windows.Forms.Panel panel6;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Button btnFindNext;
        private System.Windows.Forms.Button btnReplaceAll;
        private System.Windows.Forms.Button btnReplace;
    }
}