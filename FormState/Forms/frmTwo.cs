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
  public partial class frmTwo : frmBase
  {
    public frmTwo()
    {
      InitializeComponent();
    }

    private void button1_Click(object sender, EventArgs e)
    {
      //StateMachine<frmBase>.Instance().Navigate("frmThree");
      StateMachine.Instance().Navigate("frmThree");
    }

    private void button2_Click(object sender, EventArgs e)
    {
      //StateMachine<frmBase>.Instance().Navigate("frmFour");
      StateMachine.Instance().Navigate("frmFour");
    }

    private void frmTwo_Activated(object sender, EventArgs e)
    {
      bool enabled = !StateMachine.Instance().CanGoForward;
      button1.Enabled = enabled;
      button2.Enabled = enabled;
    }
  }
}
