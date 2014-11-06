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
  public partial class frmAbout : Form
  {
    public frmAbout()
    {
      InitializeComponent();
    }

    private void frmAbout_Shown(object sender, EventArgs e)
    {
      //StateMachine.Instance().SetStatus("About - Shown");
    }

    private void frmAbout_VisibleChanged(object sender, EventArgs e)
    {
      //StateMachine.Instance().SetStatus("About - Visible Changed");
    }

    private void frmAbout_Activated(object sender, EventArgs e)
    {
      //StateMachine.Instance().SetStatus("About - Activated");
    }
  }
}
