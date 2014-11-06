namespace FormState
{
  partial class frmHelp
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
      this.webBrowser1 = new System.Windows.Forms.WebBrowser();
      this.panel1 = new System.Windows.Forms.Panel();
      this.btnRefresh = new System.Windows.Forms.Button();
      this.cbAuto = new System.Windows.Forms.CheckBox();
      this.panel1.SuspendLayout();
      this.SuspendLayout();
      // 
      // webBrowser1
      // 
      this.webBrowser1.Dock = System.Windows.Forms.DockStyle.Fill;
      this.webBrowser1.IsWebBrowserContextMenuEnabled = false;
      this.webBrowser1.Location = new System.Drawing.Point(0, 35);
      this.webBrowser1.MinimumSize = new System.Drawing.Size(20, 20);
      this.webBrowser1.Name = "webBrowser1";
      this.webBrowser1.Size = new System.Drawing.Size(292, 231);
      this.webBrowser1.TabIndex = 0;
      this.webBrowser1.Navigating += new System.Windows.Forms.WebBrowserNavigatingEventHandler(this.webBrowser1_Navigating);
      // 
      // panel1
      // 
      this.panel1.Controls.Add(this.btnRefresh);
      this.panel1.Controls.Add(this.cbAuto);
      this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
      this.panel1.Location = new System.Drawing.Point(0, 0);
      this.panel1.Name = "panel1";
      this.panel1.Size = new System.Drawing.Size(292, 35);
      this.panel1.TabIndex = 1;
      // 
      // btnRefresh
      // 
      this.btnRefresh.Location = new System.Drawing.Point(113, 4);
      this.btnRefresh.Name = "btnRefresh";
      this.btnRefresh.Size = new System.Drawing.Size(56, 23);
      this.btnRefresh.TabIndex = 1;
      this.btnRefresh.Text = "Refresh";
      this.btnRefresh.UseVisualStyleBackColor = true;
      this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
      // 
      // cbAuto
      // 
      this.cbAuto.AutoSize = true;
      this.cbAuto.Checked = true;
      this.cbAuto.CheckState = System.Windows.Forms.CheckState.Checked;
      this.cbAuto.Location = new System.Drawing.Point(12, 12);
      this.cbAuto.Name = "cbAuto";
      this.cbAuto.Size = new System.Drawing.Size(94, 17);
      this.cbAuto.TabIndex = 0;
      this.cbAuto.Text = "Auto Navigate";
      this.cbAuto.UseVisualStyleBackColor = true;
      // 
      // frmHelp
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(292, 266);
      this.Controls.Add(this.webBrowser1);
      this.Controls.Add(this.panel1);
      this.Name = "frmHelp";
      this.Text = "frmHelp";
      this.panel1.ResumeLayout(false);
      this.panel1.PerformLayout();
      this.ResumeLayout(false);

    }

    #endregion

    private System.Windows.Forms.WebBrowser webBrowser1;
    private System.Windows.Forms.Panel panel1;
    private System.Windows.Forms.CheckBox cbAuto;
    private System.Windows.Forms.Button btnRefresh;
  }
}