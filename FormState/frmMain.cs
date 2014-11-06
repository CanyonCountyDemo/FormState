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
    frmHelp help;

    public frmMain()
    {
      InitializeComponent();
      // Generic class works, but too much typing
      //StateMachine<frmBase> sm = StateMachine<frmBase>.Instance(this);
      
      help = new frmHelp();
      help.TopLevel = false;
      help.FormBorderStyle = FormBorderStyle.None;
      pnlRight.Controls.Add(help);
      //help.Parent = pnlRight;
      help.Dock = DockStyle.Fill;

      StateMachine sm = StateMachine.Instance(this, help);
      // Add all forms that decend from frmBase
      sm.AddForms(typeof(frmBase));
      // Add other forms that don't
      sm.AddForm("About", new frmAbout());
      // Start out on the Login form
      sm.Navigate("frmLogin");
    }

    private void toolStripButton1_Click(object sender, EventArgs e)
    {
      pnlRight.Visible = !pnlRight.Visible;
      if (pnlRight.Visible)
      {
        help.Navigate(ActiveMdiChild.Text);
        help.Show();
      }
    }
  }
}
