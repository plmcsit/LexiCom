namespace LexiCom
{
    partial class LexiCom
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
            this.LexGrid = new System.Windows.Forms.DataGridView();
            this.id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Lexeme_col = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Token_col = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Output = new System.Windows.Forms.RichTextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.LexPanel = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.LexButton = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.LexBtn = new System.Windows.Forms.Button();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.Code = new Lexicom.WinForms.RichTextBoxEx();
            ((System.ComponentModel.ISupportInitialize)(this.LexGrid)).BeginInit();
            this.LexPanel.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // LexGrid
            // 
            this.LexGrid.AllowUserToAddRows = false;
            this.LexGrid.AllowUserToDeleteRows = false;
            this.LexGrid.AllowUserToResizeColumns = false;
            this.LexGrid.AllowUserToResizeRows = false;
            this.LexGrid.BackgroundColor = System.Drawing.SystemColors.ControlLightLight;
            this.LexGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.LexGrid.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.id,
            this.Lexeme_col,
            this.Token_col});
            this.LexGrid.GridColor = System.Drawing.SystemColors.ButtonHighlight;
            this.LexGrid.Location = new System.Drawing.Point(3, 27);
            this.LexGrid.Name = "LexGrid";
            this.LexGrid.ReadOnly = true;
            this.LexGrid.RowHeadersVisible = false;
            this.LexGrid.Size = new System.Drawing.Size(237, 449);
            this.LexGrid.TabIndex = 1;
            // 
            // id
            // 
            this.id.HeaderText = "ID";
            this.id.Name = "id";
            this.id.ReadOnly = true;
            this.id.Width = 30;
            // 
            // Lexeme_col
            // 
            this.Lexeme_col.HeaderText = "Lexeme";
            this.Lexeme_col.Name = "Lexeme_col";
            this.Lexeme_col.ReadOnly = true;
            // 
            // Token_col
            // 
            this.Token_col.HeaderText = "Token";
            this.Token_col.Name = "Token_col";
            this.Token_col.ReadOnly = true;
            // 
            // Output
            // 
            this.Output.BackColor = System.Drawing.SystemColors.ControlText;
            this.Output.Font = new System.Drawing.Font("Lucida Console", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Output.ForeColor = System.Drawing.Color.Lime;
            this.Output.Location = new System.Drawing.Point(12, 446);
            this.Output.Name = "Output";
            this.Output.ReadOnly = true;
            this.Output.Size = new System.Drawing.Size(691, 120);
            this.Output.TabIndex = 3;
            this.Output.Text = "";
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.DarkCyan;
            this.label1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.label1.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label1.Location = new System.Drawing.Point(0, 571);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(729, 22);
            this.label1.TabIndex = 4;
            this.label1.Text = "version 0.1 (Beta Version)";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label2
            // 
            this.label2.BackColor = System.Drawing.Color.DarkCyan;
            this.label2.Dock = System.Windows.Forms.DockStyle.Top;
            this.label2.Font = new System.Drawing.Font("Code Bold", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(77)));
            this.label2.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label2.Location = new System.Drawing.Point(0, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(729, 45);
            this.label2.TabIndex = 5;
            this.label2.Text = "LexiCom (Lexis Compiler)";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // LexPanel
            // 
            this.LexPanel.Controls.Add(this.label3);
            this.LexPanel.Controls.Add(this.LexGrid);
            this.LexPanel.Location = new System.Drawing.Point(743, 87);
            this.LexPanel.Name = "LexPanel";
            this.LexPanel.Size = new System.Drawing.Size(245, 479);
            this.LexPanel.TabIndex = 9;
            // 
            // label3
            // 
            this.label3.BackColor = System.Drawing.Color.DarkCyan;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.label3.Location = new System.Drawing.Point(4, 3);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(236, 21);
            this.label3.TabIndex = 2;
            this.label3.Text = "LEXICAL ANALYZER";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // LexButton
            // 
            this.LexButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.LexButton.Image = global::LexiCom.Properties.Resources.start5;
            this.LexButton.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.LexButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.LexButton.Name = "LexButton";
            this.LexButton.Size = new System.Drawing.Size(73, 36);
            this.LexButton.Text = "Start";
            this.LexButton.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.LexButton.Click += new System.EventHandler(this.LexButton_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 39);
            // 
            // toolStrip1
            // 
            this.toolStrip1.AutoSize = false;
            this.toolStrip1.BackColor = System.Drawing.SystemColors.ControlLight;
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.LexButton,
            this.toolStripSeparator1});
            this.toolStrip1.Location = new System.Drawing.Point(0, 45);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(729, 39);
            this.toolStrip1.TabIndex = 8;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // LexBtn
            // 
            this.LexBtn.BackColor = System.Drawing.Color.DarkCyan;
            this.LexBtn.FlatAppearance.BorderSize = 0;
            this.LexBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.LexBtn.Font = new System.Drawing.Font("Code Bold", 10F, System.Drawing.FontStyle.Bold);
            this.LexBtn.ForeColor = System.Drawing.SystemColors.Control;
            this.LexBtn.Location = new System.Drawing.Point(708, 86);
            this.LexBtn.Name = "LexBtn";
            this.LexBtn.Size = new System.Drawing.Size(21, 118);
            this.LexBtn.TabIndex = 10;
            this.LexBtn.Text = "LEXICAL";
            this.LexBtn.UseVisualStyleBackColor = false;
            this.LexBtn.Click += new System.EventHandler(this.LexBtn_Click);
            // 
            // toolTip1
            // 
            this.toolTip1.IsBalloon = true;
            this.toolTip1.ToolTipTitle = "Execute Program";
            // 
            // Code
            // 
            this.Code.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Code.Location = new System.Drawing.Point(12, 87);
            this.Code.Name = "Code";
            this.Code.NumberAlignment = System.Drawing.StringAlignment.Near;
            this.Code.NumberBackground1 = System.Drawing.SystemColors.ControlLightLight;
            this.Code.NumberBackground2 = System.Drawing.SystemColors.ActiveCaption;
            this.Code.NumberBorder = System.Drawing.SystemColors.ActiveCaption;
            this.Code.NumberBorderThickness = 0F;
            this.Code.NumberColor = System.Drawing.Color.DarkCyan;
            this.Code.NumberFont = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Code.NumberLeadingZeroes = false;
            this.Code.NumberLineCounting = Lexicom.WinForms.RichTextBoxEx.LineCounting.CRLF;
            this.Code.NumberPadding = 2;
            this.Code.ShowLineNumbers = true;
            this.Code.Size = new System.Drawing.Size(691, 353);
            this.Code.TabIndex = 6;
            this.Code.Text = "";
            // 
            // LexiCom
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(729, 593);
            this.Controls.Add(this.LexBtn);
            this.Controls.Add(this.LexPanel);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.Code);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.Output);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.Name = "LexiCom";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            ((System.ComponentModel.ISupportInitialize)(this.LexGrid)).EndInit();
            this.LexPanel.ResumeLayout(false);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.DataGridView LexGrid;
        private System.Windows.Forms.RichTextBox Output;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridViewTextBoxColumn id;
        private System.Windows.Forms.DataGridViewTextBoxColumn Lexeme_col;
        private System.Windows.Forms.DataGridViewTextBoxColumn Token_col;
        private Lexicom.WinForms.RichTextBoxEx Code;
        private System.Windows.Forms.Panel LexPanel;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ToolStripButton LexButton;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.Button LexBtn;
        private System.Windows.Forms.ToolTip toolTip1;
    }
}

