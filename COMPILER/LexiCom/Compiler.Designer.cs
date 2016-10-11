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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.LexGrid = new System.Windows.Forms.DataGridView();
            this.id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Lexeme_col = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Token_col = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Attribute_col = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Output = new System.Windows.Forms.RichTextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.LexPanel = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.DataLexicalError = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.LexButton = new System.Windows.Forms.ToolStripButton();
            this.ClearButton = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripButton1 = new System.Windows.Forms.ToolStripDropDownButton();
            this.lecsicalAnalyzerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.syntax_mode = new System.Windows.Forms.ToolStripMenuItem();
            this.semantics_mode = new System.Windows.Forms.ToolStripMenuItem();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.DataSyntaxError = new System.Windows.Forms.DataGridView();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.Grid_Syntax = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn8 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel1 = new System.Windows.Forms.Panel();
            this.Code = new Lexicom.WinForms.RichTextBoxEx();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Line = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Col = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.LexGrid)).BeginInit();
            this.LexPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DataLexicalError)).BeginInit();
            this.toolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DataSyntaxError)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Grid_Syntax)).BeginInit();
            this.panel1.SuspendLayout();
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
            this.Token_col,
            this.Attribute_col});
            this.LexGrid.GridColor = System.Drawing.SystemColors.ButtonHighlight;
            this.LexGrid.Location = new System.Drawing.Point(3, 27);
            this.LexGrid.Name = "LexGrid";
            this.LexGrid.ReadOnly = true;
            this.LexGrid.RowHeadersVisible = false;
            this.LexGrid.Size = new System.Drawing.Size(340, 404);
            this.LexGrid.TabIndex = 1;
            this.LexGrid.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.LexGrid_CellContentClick);
            // 
            // id
            // 
            this.id.HeaderText = "ID";
            this.id.Name = "id";
            this.id.ReadOnly = true;
            this.id.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.id.Width = 30;
            // 
            // Lexeme_col
            // 
            this.Lexeme_col.HeaderText = "Lexeme";
            this.Lexeme_col.Name = "Lexeme_col";
            this.Lexeme_col.ReadOnly = true;
            this.Lexeme_col.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // Token_col
            // 
            this.Token_col.HeaderText = "Token";
            this.Token_col.Name = "Token_col";
            this.Token_col.ReadOnly = true;
            this.Token_col.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // Attribute_col
            // 
            this.Attribute_col.HeaderText = "Description";
            this.Attribute_col.Name = "Attribute_col";
            this.Attribute_col.ReadOnly = true;
            this.Attribute_col.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // Output
            // 
            this.Output.BackColor = System.Drawing.SystemColors.ControlText;
            this.Output.Font = new System.Drawing.Font("Lucida Console", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Output.ForeColor = System.Drawing.Color.Lime;
            this.Output.Location = new System.Drawing.Point(12, 549);
            this.Output.Name = "Output";
            this.Output.ReadOnly = true;
            this.Output.Size = new System.Drawing.Size(391, 97);
            this.Output.TabIndex = 3;
            this.Output.Text = "";
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.DarkCyan;
            this.label1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.label1.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label1.Location = new System.Drawing.Point(0, 651);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(1202, 22);
            this.label1.TabIndex = 4;
            this.label1.Text = "version 0.2 Build 6 (Beta Version)";
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
            this.label2.Size = new System.Drawing.Size(1202, 45);
            this.label2.TabIndex = 5;
            this.label2.Text = "LexiCom (Lexis Compiler)";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // LexPanel
            // 
            this.LexPanel.Controls.Add(this.label3);
            this.LexPanel.Controls.Add(this.LexGrid);
            this.LexPanel.Location = new System.Drawing.Point(498, 86);
            this.LexPanel.Name = "LexPanel";
            this.LexPanel.Size = new System.Drawing.Size(346, 438);
            this.LexPanel.TabIndex = 9;
            // 
            // label3
            // 
            this.label3.BackColor = System.Drawing.Color.DarkCyan;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.label3.Location = new System.Drawing.Point(4, 3);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(338, 21);
            this.label3.TabIndex = 2;
            this.label3.Text = "LEXICAL TABLE";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label6
            // 
            this.label6.BackColor = System.Drawing.Color.DarkCyan;
            this.label6.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.label6.Location = new System.Drawing.Point(410, 526);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(338, 21);
            this.label6.TabIndex = 4;
            this.label6.Text = "LEXICAL ERRORS";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // DataLexicalError
            // 
            this.DataLexicalError.AllowUserToAddRows = false;
            this.DataLexicalError.AllowUserToDeleteRows = false;
            this.DataLexicalError.AllowUserToResizeColumns = false;
            this.DataLexicalError.AllowUserToResizeRows = false;
            this.DataLexicalError.BackgroundColor = System.Drawing.SystemColors.ControlLightLight;
            this.DataLexicalError.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DataLexicalError.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn2,
            this.dataGridViewTextBoxColumn6});
            this.DataLexicalError.GridColor = System.Drawing.SystemColors.ButtonHighlight;
            this.DataLexicalError.Location = new System.Drawing.Point(408, 549);
            this.DataLexicalError.Name = "DataLexicalError";
            this.DataLexicalError.ReadOnly = true;
            this.DataLexicalError.RowHeadersVisible = false;
            this.DataLexicalError.Size = new System.Drawing.Size(340, 94);
            this.DataLexicalError.TabIndex = 3;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.HeaderText = "ID";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.ReadOnly = true;
            this.dataGridViewTextBoxColumn2.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.dataGridViewTextBoxColumn2.Width = 30;
            // 
            // dataGridViewTextBoxColumn6
            // 
            this.dataGridViewTextBoxColumn6.HeaderText = "Errors";
            this.dataGridViewTextBoxColumn6.Name = "dataGridViewTextBoxColumn6";
            this.dataGridViewTextBoxColumn6.ReadOnly = true;
            this.dataGridViewTextBoxColumn6.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.dataGridViewTextBoxColumn6.Width = 300;
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
            this.toolStripSeparator1,
            this.ClearButton,
            this.toolStripSeparator2,
            this.toolStripButton1});
            this.toolStrip1.Location = new System.Drawing.Point(0, 45);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(1202, 39);
            this.toolStrip1.TabIndex = 8;
            this.toolStrip1.Text = "Select Mode";
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
            // ClearButton
            // 
            this.ClearButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.ClearButton.Image = global::LexiCom.Properties.Resources.clear;
            this.ClearButton.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.ClearButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.ClearButton.Name = "ClearButton";
            this.ClearButton.Size = new System.Drawing.Size(73, 36);
            this.ClearButton.Text = "Clear Text Editor";
            this.ClearButton.Click += new System.EventHandler(this.ClearButton_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 39);
            // 
            // toolStripButton1
            // 
            this.toolStripButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lecsicalAnalyzerToolStripMenuItem,
            this.syntax_mode,
            this.semantics_mode});
            this.toolStripButton1.Image = global::LexiCom.Properties.Resources.mode;
            this.toolStripButton1.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.toolStripButton1.Name = "toolStripButton1";
            this.toolStripButton1.Size = new System.Drawing.Size(82, 36);
            this.toolStripButton1.Text = "Select Mode";
            // 
            // lecsicalAnalyzerToolStripMenuItem
            // 
            this.lecsicalAnalyzerToolStripMenuItem.Checked = true;
            this.lecsicalAnalyzerToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
            this.lecsicalAnalyzerToolStripMenuItem.Enabled = false;
            this.lecsicalAnalyzerToolStripMenuItem.Name = "lecsicalAnalyzerToolStripMenuItem";
            this.lecsicalAnalyzerToolStripMenuItem.Size = new System.Drawing.Size(176, 22);
            this.lecsicalAnalyzerToolStripMenuItem.Text = "Lecsical Analyzer";
            // 
            // syntax_mode
            // 
            this.syntax_mode.Checked = true;
            this.syntax_mode.CheckState = System.Windows.Forms.CheckState.Checked;
            this.syntax_mode.Name = "syntax_mode";
            this.syntax_mode.Size = new System.Drawing.Size(176, 22);
            this.syntax_mode.Text = "Syntax Analyzer";
            this.syntax_mode.Click += new System.EventHandler(this.syntaxAnalyzerToolStripMenuItem_Click);
            // 
            // semantics_mode
            // 
            this.semantics_mode.Checked = true;
            this.semantics_mode.CheckState = System.Windows.Forms.CheckState.Checked;
            this.semantics_mode.Name = "semantics_mode";
            this.semantics_mode.Size = new System.Drawing.Size(176, 22);
            this.semantics_mode.Text = "Semantics Analyzer";
            this.semantics_mode.Click += new System.EventHandler(this.semantics_mode_Click);
            // 
            // toolTip1
            // 
            this.toolTip1.IsBalloon = true;
            this.toolTip1.ToolTipTitle = "Execute Program";
            // 
            // DataSyntaxError
            // 
            this.DataSyntaxError.AllowUserToAddRows = false;
            this.DataSyntaxError.AllowUserToDeleteRows = false;
            this.DataSyntaxError.AllowUserToResizeColumns = false;
            this.DataSyntaxError.AllowUserToResizeRows = false;
            this.DataSyntaxError.BackgroundColor = System.Drawing.SystemColors.ControlLightLight;
            this.DataSyntaxError.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DataSyntaxError.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn1,
            this.Line,
            this.Col,
            this.dataGridViewTextBoxColumn4});
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.DataSyntaxError.DefaultCellStyle = dataGridViewCellStyle1;
            this.DataSyntaxError.GridColor = System.Drawing.SystemColors.ButtonHighlight;
            this.DataSyntaxError.Location = new System.Drawing.Point(753, 549);
            this.DataSyntaxError.Name = "DataSyntaxError";
            this.DataSyntaxError.RowHeadersVisible = false;
            this.DataSyntaxError.RowTemplate.Height = 50;
            this.DataSyntaxError.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.DataSyntaxError.Size = new System.Drawing.Size(438, 94);
            this.DataSyntaxError.TabIndex = 3;
            // 
            // label4
            // 
            this.label4.BackColor = System.Drawing.Color.DarkCyan;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.label4.Location = new System.Drawing.Point(753, 526);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(438, 21);
            this.label4.TabIndex = 4;
            this.label4.Text = "SYNTAX ERRORS";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label5
            // 
            this.label5.BackColor = System.Drawing.Color.DarkCyan;
            this.label5.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.label5.Location = new System.Drawing.Point(12, 526);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(391, 21);
            this.label5.TabIndex = 10;
            this.label5.Text = "RUNTIME OUTPUT";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label7
            // 
            this.label7.BackColor = System.Drawing.Color.DarkCyan;
            this.label7.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.label7.Location = new System.Drawing.Point(4, 3);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(338, 21);
            this.label7.TabIndex = 2;
            this.label7.Text = "SYNTAX TABLE";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // Grid_Syntax
            // 
            this.Grid_Syntax.AllowUserToAddRows = false;
            this.Grid_Syntax.AllowUserToDeleteRows = false;
            this.Grid_Syntax.AllowUserToResizeColumns = false;
            this.Grid_Syntax.AllowUserToResizeRows = false;
            this.Grid_Syntax.BackgroundColor = System.Drawing.SystemColors.ControlLightLight;
            this.Grid_Syntax.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.Grid_Syntax.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn3,
            this.dataGridViewTextBoxColumn5,
            this.dataGridViewTextBoxColumn7,
            this.dataGridViewTextBoxColumn8});
            this.Grid_Syntax.GridColor = System.Drawing.SystemColors.ButtonHighlight;
            this.Grid_Syntax.Location = new System.Drawing.Point(3, 27);
            this.Grid_Syntax.Name = "Grid_Syntax";
            this.Grid_Syntax.ReadOnly = true;
            this.Grid_Syntax.RowHeadersVisible = false;
            this.Grid_Syntax.Size = new System.Drawing.Size(340, 404);
            this.Grid_Syntax.TabIndex = 1;
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.HeaderText = "ID";
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            this.dataGridViewTextBoxColumn3.ReadOnly = true;
            this.dataGridViewTextBoxColumn3.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.dataGridViewTextBoxColumn3.Width = 30;
            // 
            // dataGridViewTextBoxColumn5
            // 
            this.dataGridViewTextBoxColumn5.HeaderText = "Production";
            this.dataGridViewTextBoxColumn5.Name = "dataGridViewTextBoxColumn5";
            this.dataGridViewTextBoxColumn5.ReadOnly = true;
            this.dataGridViewTextBoxColumn5.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.dataGridViewTextBoxColumn5.Width = 140;
            // 
            // dataGridViewTextBoxColumn7
            // 
            this.dataGridViewTextBoxColumn7.HeaderText = "->";
            this.dataGridViewTextBoxColumn7.Name = "dataGridViewTextBoxColumn7";
            this.dataGridViewTextBoxColumn7.ReadOnly = true;
            this.dataGridViewTextBoxColumn7.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.dataGridViewTextBoxColumn7.Width = 20;
            // 
            // dataGridViewTextBoxColumn8
            // 
            this.dataGridViewTextBoxColumn8.HeaderText = "Set";
            this.dataGridViewTextBoxColumn8.Name = "dataGridViewTextBoxColumn8";
            this.dataGridViewTextBoxColumn8.ReadOnly = true;
            this.dataGridViewTextBoxColumn8.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.dataGridViewTextBoxColumn8.Width = 140;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.label7);
            this.panel1.Controls.Add(this.Grid_Syntax);
            this.panel1.Location = new System.Drawing.Point(845, 86);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(346, 438);
            this.panel1.TabIndex = 11;
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
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
            this.Code.ShowLineNumbers = false;
            this.Code.Size = new System.Drawing.Size(483, 430);
            this.Code.TabIndex = 6;
            this.Code.Text = "";
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.HeaderText = "ID";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.ReadOnly = true;
            this.dataGridViewTextBoxColumn1.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.dataGridViewTextBoxColumn1.Width = 30;
            // 
            // Line
            // 
            this.Line.HeaderText = "Ln";
            this.Line.Name = "Line";
            this.Line.ReadOnly = true;
            this.Line.Width = 30;
            // 
            // Col
            // 
            this.Col.HeaderText = "Col";
            this.Col.Name = "Col";
            this.Col.ReadOnly = true;
            this.Col.Width = 30;
            // 
            // dataGridViewTextBoxColumn4
            // 
            this.dataGridViewTextBoxColumn4.HeaderText = "Errors";
            this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            this.dataGridViewTextBoxColumn4.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.dataGridViewTextBoxColumn4.Width = 330;
            // 
            // LexiCom
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1202, 673);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.DataLexicalError);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.DataSyntaxError);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.LexPanel);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.Code);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.Output);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.MinimumSize = new System.Drawing.Size(1079, 632);
            this.Name = "LexiCom";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            ((System.ComponentModel.ISupportInitialize)(this.LexGrid)).EndInit();
            this.LexPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.DataLexicalError)).EndInit();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DataSyntaxError)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Grid_Syntax)).EndInit();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.DataGridView LexGrid;
        private System.Windows.Forms.RichTextBox Output;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private Lexicom.WinForms.RichTextBoxEx Code;
        private System.Windows.Forms.Panel LexPanel;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ToolStripButton LexButton;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.ToolStripDropDownButton toolStripButton1;
        private System.Windows.Forms.ToolStripMenuItem lecsicalAnalyzerToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem syntax_mode;
        private System.Windows.Forms.DataGridViewTextBoxColumn id;
        private System.Windows.Forms.DataGridViewTextBoxColumn Lexeme_col;
        private System.Windows.Forms.DataGridViewTextBoxColumn Token_col;
        private System.Windows.Forms.DataGridViewTextBoxColumn Attribute_col;
        private System.Windows.Forms.ToolStripMenuItem semantics_mode;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DataGridView DataSyntaxError;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.DataGridView DataLexicalError;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn6;
        private System.Windows.Forms.ToolStripButton ClearButton;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.DataGridView Grid_Syntax;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn5;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn7;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn8;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Line;
        private System.Windows.Forms.DataGridViewTextBoxColumn Col;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
    }
}

