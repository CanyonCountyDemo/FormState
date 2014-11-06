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
  public partial class frmBase : Form
  {
    public frmBase()
    {
      InitializeComponent();
    }

    public override string ToString()
    {
      return Name;
    }

    private void btnGo_Click(object sender, EventArgs e)
    {
      // Since the StateMachine is a static singleton
      // we can do this on all forms and everyone gets it
      StateMachine.Instance().Navigate("About");
    }

    private void frmBase_Shown(object sender, EventArgs e)
    {
      // This gets called only once
      //StateMachine.Instance().SetStatus(Text += " - Shown");
    }

    private void frmBase_Activated(object sender, EventArgs e)
    {
      // This gets called every time it's activated
      //StateMachine.Instance().SetStatus(Text += " - Activated");
      btnNext.Enabled = StateMachine.Instance().CanGoForward;
    }

    private void btnNext_Click(object sender, EventArgs e)
    {
      StateMachine.Instance().NextForm();
    }
  }
}
