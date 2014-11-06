namespace FormState
{
  partial class frmBase
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
      this.btnGo = new System.Windows.Forms.Button();
      this.SuspendLayout();
      // 
      // btnGo
      // 
      this.btnGo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
      this.btnGo.Location = new System.Drawing.Point(205, 12);
      this.btnGo.Name = "btnGo";
      this.btnGo.Size = new System.Drawing.Size(75, 23);
      this.btnGo.TabIndex = 0;
      this.btnGo.Text = "About";
      this.btnGo.UseVisualStyleBackColor = true;
      this.btnGo.Click += new System.EventHandler(this.btnGo_Click);
      // 
      // frmBase
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.BackColor = System.Drawing.SystemColors.Window;
      this.ClientSize = new System.Drawing.Size(292, 266);
      this.Controls.Add(this.btnGo);
      this.Name = "frmBase";
      this.Text = "Base - Should never see";
      this.Shown += new System.EventHandler(this.frmBase_Shown);
      this.Activated += new System.EventHandler(this.frmBase_Activated);
      this.ResumeLayout(false);

    }

    #endregion

    private System.Windows.Forms.Button btnGo;
  }
}