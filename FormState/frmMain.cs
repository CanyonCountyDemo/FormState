using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace FormState
{
  public partial class frmMain : Form
  {
    private frmHelp help;
    private int _holdWidth;

    public frmMain()
    {
      InitializeComponent();
      
      help = new frmHelp();
      help.TopLevel = false;
      help.FormBorderStyle = FormBorderStyle.None;
      pnlRight.Controls.Add(help);
      //help.Parent = pnlRight;
      help.Dock = DockStyle.Fill;
      _holdWidth = this.Width;

      // Generic class works, but too much typing
      //StateMachine<frmBase> sm = StateMachine<frmBase>.Instance(this);
      StateMachine sm = StateMachine.Instance(this, help);
      // If you navigate to a form that doesn't exist it will create it
      // UNLESS you specify that you do not want all forms AutoCreated
      //sm.AutoCreateForms = false;

      // For the real lazy, you can even specify a form prefix
      // it defaults to "frm" so you can navigate to your forms
      // by using Navigate("Login") or Navigate("frmLogin")
      //sm.FormPrefix = "frm";
      
      // Use the following code to create the forms when you want to
      // You might want to create a form on app load, during a splash screen
      // or at some other time. You can force that like so
      // This will even work with AutoCreateForms

      // Add all forms that decend from frmBase
      //sm.AddForms(typeof(frmBase));
      // Add other forms that don't
      //sm.AddForm("About", new frmAbout());
      //sm.AddForm("frmBase", new frmBase());
      
      
      // Start out on the Login form
      sm.Navigate("frmLogin");
    }

    private void SetWidth(int width)
    {
      Screen screen = Screen.FromControl(this);
      if (this.WindowState == FormWindowState.Normal)
        _holdWidth = this.Width;
      // I don't care about MY width, I care about the width I want to SET it to
      if ((this.Left + width/*this.Width*/) < screen.WorkingArea.Width)
        this.Width = width;
      else
        this.Width = screen.WorkingArea.Width - this.Left; // Closest usable width
    }

    private void toolStripButton1_Click(object sender, EventArgs e)
    {
      pnlRight.Visible = !pnlRight.Visible;
      if (pnlRight.Visible)
      {
        splitRight.Width = 3;
        SetWidth(this.Width + splitRight.Width + pnlRight.Width);
        help.Navigate(ActiveMdiChild.Name.ToString());
        help.Show();
      }
      else
      {
        SetWidth(_holdWidth);
        splitRight.Width = 1; // 0 is not an option - maybe mess with visibility
      }
    }

    private void toolStripButton2_Click(object sender, EventArgs e)
    {
      StateMachine.Instance().Navigate("frmBase");
    }
  }
}
