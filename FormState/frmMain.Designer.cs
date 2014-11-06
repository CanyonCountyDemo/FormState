namespace FormState
{
  partial class frmMain
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
      System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMain));
      this.tsMain = new System.Windows.Forms.ToolStrip();
      this.tsBack = new System.Windows.Forms.ToolStripButton();
      this.status = new System.Windows.Forms.StatusStrip();
      this.statusLabel = new System.Windows.Forms.ToolStripStatusLabel();
      this.pnlRight = new System.Windows.Forms.Panel();
      this.toolStripButton1 = new System.Windows.Forms.ToolStripButton();
      this.splitter1 = new System.Windows.Forms.Splitter();
      this.tsMain.SuspendLayout();
      this.status.SuspendLayout();
      this.SuspendLayout();
      // 
      // tsMain
      // 
      this.tsMain.BackColor = System.Drawing.SystemColors.Control;
      this.tsMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsBack,
            this.toolStripButton1});
      this.tsMain.Location = new System.Drawing.Point(0, 0);
      this.tsMain.Name = "tsMain";
      this.tsMain.Size = new System.Drawing.Size(596, 25);
      this.tsMain.TabIndex = 0;
      this.tsMain.Text = "toolStrip1";
      // 
      // tsBack
      // 
      this.tsBack.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
      this.tsBack.Image = ((System.Drawing.Image)(resources.GetObject("tsBack.Image")));
      this.tsBack.ImageTransparentColor = System.Drawing.Color.Magenta;
      this.tsBack.Name = "tsBack";
      this.tsBack.Size = new System.Drawing.Size(27, 22);
      this.tsBack.Text = "<--";
      // 
      // status
      // 
      this.status.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.statusLabel});
      this.status.Location = new System.Drawing.Point(0, 509);
      this.status.Name = "status";
      this.status.Size = new System.Drawing.Size(596, 22);
      this.status.TabIndex = 2;
      // 
      // statusLabel
      // 
      this.statusLabel.Name = "statusLabel";
      this.statusLabel.Size = new System.Drawing.Size(0, 17);
      // 
      // pnlRight
      // 
      this.pnlRight.Dock = System.Windows.Forms.DockStyle.Right;
      this.pnlRight.Location = new System.Drawing.Point(415, 25);
      this.pnlRight.Name = "pnlRight";
      this.pnlRight.Size = new System.Drawing.Size(181, 484);
      this.pnlRight.TabIndex = 3;
      this.pnlRight.Visible = false;
      // 
      // toolStripButton1
      // 
      this.toolStripButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
      this.toolStripButton1.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton1.Image")));
      this.toolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
      this.toolStripButton1.Name = "toolStripButton1";
      this.toolStripButton1.Size = new System.Drawing.Size(32, 22);
      this.toolStripButton1.Text = "Help";
      this.toolStripButton1.Click += new System.EventHandler(this.toolStripButton1_Click);
      // 
      // splitter1
      // 
      this.splitter1.Dock = System.Windows.Forms.DockStyle.Right;
      this.splitter1.Location = new System.Drawing.Point(412, 25);
      this.splitter1.Name = "splitter1";
      this.splitter1.Size = new System.Drawing.Size(3, 484);
      this.splitter1.TabIndex = 4;
      this.splitter1.TabStop = false;
      // 
      // frmMain
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(596, 531);
      this.Controls.Add(this.splitter1);
      this.Controls.Add(this.pnlRight);
      this.Controls.Add(this.status);
      this.Controls.Add(this.tsMain);
      this.IsMdiContainer = true;
      this.Name = "frmMain";
      this.Text = "My Application";
      this.tsMain.ResumeLayout(false);
      this.tsMain.PerformLayout();
      this.status.ResumeLayout(false);
      this.status.PerformLayout();
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion

    private System.Windows.Forms.ToolStrip tsMain;
    public System.Windows.Forms.ToolStripButton tsBack;
    public System.Windows.Forms.StatusStrip status;
    public System.Windows.Forms.ToolStripStatusLabel statusLabel;
    private System.Windows.Forms.ToolStripButton toolStripButton1;
    private System.Windows.Forms.Panel pnlRight;
    private System.Windows.Forms.Splitter splitter1;
  }
}

