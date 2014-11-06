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
  public partial class frmLogin : frmBase
  {
    public frmLogin()
    {
      InitializeComponent();
    }

    private void button1_Click(object sender, EventArgs e)
    {
      //StateMachine<frmBase>.Instance().Navigate("frmTwo");
      StateMachine.Instance().Navigate("frmTwo");
    }

    private void button2_Click(object sender, EventArgs e)
    {
      // This should NOT create a new frmAbout
      StateMachine.Instance().Navigate("frmAbout");
    }
  }
}
