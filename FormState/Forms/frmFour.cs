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
  public partial class frmFour : frmBase
  {
    public frmFour()
    {
      InitializeComponent();
    }

    private void button1_Click(object sender, EventArgs e)
    {
      //StateMachine<frmBase>.Instance().Navigate("frmThree");
      StateMachine.Instance().Navigate("frmThree");
    }

    private void frmFour_Activated(object sender, EventArgs e)
    {
      // I wanted to move this to the base form, but I don't know what buttons are for navigation
      button1.Enabled = !StateMachine.Instance().CanGoForward;
    }
  }
}
