﻿namespace FormState
{
  partial class frmLogin
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
      this.button1 = new System.Windows.Forms.Button();
      this.label1 = new System.Windows.Forms.Label();
      this.button2 = new System.Windows.Forms.Button();
      this.button3 = new System.Windows.Forms.Button();
      this.cbExcept = new System.Windows.Forms.CheckBox();
      this.SuspendLayout();
      // 
      // button1
      // 
      this.button1.Location = new System.Drawing.Point(34, 41);
      this.button1.Name = "button1";
      this.button1.Size = new System.Drawing.Size(234, 137);
      this.button1.TabIndex = 0;
      this.button1.Text = "Goto form 2";
      this.button1.UseVisualStyleBackColor = true;
      this.button1.Click += new System.EventHandler(this.button1_Click);
      // 
      // label1
      // 
      this.label1.AutoSize = true;
      this.label1.Location = new System.Drawing.Point(34, 194);
      this.label1.Name = "label1";
      this.label1.Size = new System.Drawing.Size(110, 13);
      this.label1.TabIndex = 1;
      this.label1.Text = "This is the Login Form";
      // 
      // button2
      // 
      this.button2.Location = new System.Drawing.Point(37, 231);
      this.button2.Name = "button2";
      this.button2.Size = new System.Drawing.Size(75, 23);
      this.button2.TabIndex = 2;
      this.button2.Text = "About";
      this.button2.UseVisualStyleBackColor = true;
      this.button2.Click += new System.EventHandler(this.button2_Click);
      // 
      // button3
      // 
      this.button3.Location = new System.Drawing.Point(118, 231);
      this.button3.Name = "button3";
      this.button3.Size = new System.Drawing.Size(75, 23);
      this.button3.TabIndex = 3;
      this.button3.Text = "Workflow";
      this.button3.UseVisualStyleBackColor = true;
      this.button3.Click += new System.EventHandler(this.button3_Click);
      // 
      // cbExcept
      // 
      this.cbExcept.AutoSize = true;
      this.cbExcept.Checked = true;
      this.cbExcept.CheckState = System.Windows.Forms.CheckState.Checked;
      this.cbExcept.Location = new System.Drawing.Point(200, 236);
      this.cbExcept.Name = "cbExcept";
      this.cbExcept.Size = new System.Drawing.Size(73, 17);
      this.cbExcept.TabIndex = 4;
      this.cbExcept.Text = "Exception";
      this.cbExcept.UseVisualStyleBackColor = true;
      this.cbExcept.CheckedChanged += new System.EventHandler(this.cbExcept_CheckedChanged);
      // 
      // frmLogin
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(292, 266);
      this.Controls.Add(this.cbExcept);
      this.Controls.Add(this.button3);
      this.Controls.Add(this.button2);
      this.Controls.Add(this.label1);
      this.Controls.Add(this.button1);
      this.Name = "frmLogin";
      this.Text = "Login";
      this.Activated += new System.EventHandler(this.frmLogin_Activated);
      this.Controls.SetChildIndex(this.button1, 0);
      this.Controls.SetChildIndex(this.label1, 0);
      this.Controls.SetChildIndex(this.button2, 0);
      this.Controls.SetChildIndex(this.button3, 0);
      this.Controls.SetChildIndex(this.cbExcept, 0);
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion

    private System.Windows.Forms.Button button1;
    private System.Windows.Forms.Label label1;
    private System.Windows.Forms.Button button2;
    private System.Windows.Forms.Button button3;
    private System.Windows.Forms.CheckBox cbExcept;
  }
}