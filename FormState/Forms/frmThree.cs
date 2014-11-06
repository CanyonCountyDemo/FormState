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
  public partial class frmThree : frmBase
  {
    public frmThree()
    {
      InitializeComponent();
    }

    private void button1_Click(object sender, EventArgs e)
    {
      MessageBox.Show("Yeah! You got here!");
    }

    private void button2_Click(object sender, EventArgs e)
    {
      StateMachine.Instance().Navigate("Two");
    }

    private void frmThree_Activated(object sender, EventArgs e)
    {
      button2.Enabled = !StateMachine.Instance().CanGoForward;
    }
  }
}
