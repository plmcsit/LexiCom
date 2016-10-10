// Copyright 2008 ESRI
// 
// All rights reserved under the copyright laws of the United States
// and applicable international laws, treaties, and conventions.
// 
// You may freely redistribute and use this sample code, with or
// without modification, provided you include the original copyright
// notice and use restrictions.
// 
// See use restrictions at <your ArcGIS install location>/developerkit/userestrictions.txt.
// 

namespace SimpleEditorCS
{
  partial class SimpleEditorForm
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
      this.lblTitle = new System.Windows.Forms.Label();
      this.txtTitle = new System.Windows.Forms.TextBox();
      this.lblAbstract = new System.Windows.Forms.Label();
      this.txtAbstract = new System.Windows.Forms.TextBox();
      this.cmdCancel = new System.Windows.Forms.Button();
      this.cmdOkay = new System.Windows.Forms.Button();
      this.SuspendLayout();
      // 
      // lblTitle
      // 
      this.lblTitle.AutoSize = true;
      this.lblTitle.Location = new System.Drawing.Point(13, 13);
      this.lblTitle.Name = "lblTitle";
      this.lblTitle.Size = new System.Drawing.Size(154, 13);
      this.lblTitle.TabIndex = 0;
      this.lblTitle.Text = "What is the title of the dataset?";
      // 
      // txtTitle
      // 
      this.txtTitle.Location = new System.Drawing.Point(12, 30);
      this.txtTitle.Name = "txtTitle";
      this.txtTitle.Size = new System.Drawing.Size(320, 20);
      this.txtTitle.TabIndex = 1;
      // 
      // lblAbstract
      // 
      this.lblAbstract.AutoSize = true;
      this.lblAbstract.Location = new System.Drawing.Point(13, 57);
      this.lblAbstract.Name = "lblAbstract";
      this.lblAbstract.Size = new System.Drawing.Size(243, 13);
      this.lblAbstract.TabIndex = 2;
      this.lblAbstract.Text = "Please provide an abstract describing the dataset:";
      // 
      // txtAbstract
      // 
      this.txtAbstract.Location = new System.Drawing.Point(12, 74);
      this.txtAbstract.Multiline = true;
      this.txtAbstract.Name = "txtAbstract";
      this.txtAbstract.Size = new System.Drawing.Size(320, 188);
      this.txtAbstract.TabIndex = 3;
      // 
      // cmdCancel
      // 
      this.cmdCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
      this.cmdCancel.Location = new System.Drawing.Point(257, 269);
      this.cmdCancel.Name = "cmdCancel";
      this.cmdCancel.Size = new System.Drawing.Size(75, 23);
      this.cmdCancel.TabIndex = 4;
      this.cmdCancel.Text = "Cancel";
      this.cmdCancel.UseVisualStyleBackColor = true;
      // 
      // cmdOkay
      // 
      this.cmdOkay.DialogResult = System.Windows.Forms.DialogResult.OK;
      this.cmdOkay.Location = new System.Drawing.Point(176, 269);
      this.cmdOkay.Name = "cmdOkay";
      this.cmdOkay.Size = new System.Drawing.Size(75, 23);
      this.cmdOkay.TabIndex = 5;
      this.cmdOkay.Text = "OK";
      this.cmdOkay.UseVisualStyleBackColor = true;
      // 
      // SimpleEditorForm
      // 
      this.AcceptButton = this.cmdOkay;
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.CancelButton = this.cmdCancel;
      this.ClientSize = new System.Drawing.Size(344, 302);
      this.ControlBox = false;
      this.Controls.Add(this.cmdOkay);
      this.Controls.Add(this.cmdCancel);
      this.Controls.Add(this.txtAbstract);
      this.Controls.Add(this.lblAbstract);
      this.Controls.Add(this.txtTitle);
      this.Controls.Add(this.lblTitle);
      this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
      this.Name = "SimpleEditorForm";
      this.Text = "A Simple Editor";
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion

    private System.Windows.Forms.Label lblTitle;
    private System.Windows.Forms.TextBox txtTitle;
    private System.Windows.Forms.Label lblAbstract;
    private System.Windows.Forms.TextBox txtAbstract;
    private System.Windows.Forms.Button cmdCancel;
    private System.Windows.Forms.Button cmdOkay;
  }
}