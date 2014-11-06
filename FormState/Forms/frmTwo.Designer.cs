namespace FormState
{
  partial class frmTwo
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
      this.SuspendLayout();
      // 
      // button1
      // 
      this.button1.Location = new System.Drawing.Point(28, 38);
      this.button1.Name = "button1";
      this.button1.Size = new System.Drawing.Size(208, 144);
      this.button1.TabIndex = 0;
      this.button1.Text = "GoTo Form 3";
      this.button1.UseVisualStyleBackColor = true;
      this.button1.Click += new System.EventHandler(this.button1_Click);
      // 
      // label1
      // 
      this.label1.AutoSize = true;
      this.label1.Location = new System.Drawing.Point(28, 189);
      this.label1.Name = "label1";
      this.label1.Size = new System.Drawing.Size(192, 13);
      this.label1.TabIndex = 1;
      this.label1.Text = "This is form 2 - You have a choice here";
      // 
      // button2
      // 
      this.button2.Location = new System.Drawing.Point(242, 38);
      this.button2.Name = "button2";
      this.button2.Size = new System.Drawing.Size(208, 144);
      this.button2.TabIndex = 2;
      this.button2.Text = "GoTo Form 4";
      this.button2.UseVisualStyleBackColor = true;
      this.button2.Click += new System.EventHandler(this.button2_Click);
      // 
      // frmTwo
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(292, 266);
      this.Controls.Add(this.button2);
      this.Controls.Add(this.label1);
      this.Controls.Add(this.button1);
      this.Name = "frmTwo";
      this.Text = "Form 2";
      this.Controls.SetChildIndex(this.button1, 0);
      this.Controls.SetChildIndex(this.label1, 0);
      this.Controls.SetChildIndex(this.button2, 0);
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion

    private System.Windows.Forms.Button button1;
    private System.Windows.Forms.Label label1;
    private System.Windows.Forms.Button button2;
  }
}