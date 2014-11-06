using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using CC.Common.Utils;

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
      //listBox1.Items.Add("Working Area: " + Screen.GetWorkingArea(this).ToString());

      listBox1.Items.Clear();
      Rectangle current = Screen.GetWorkingArea(this);
      // For each screen, add the screen properties to a list box.
      foreach (Screen screen in System.Windows.Forms.Screen.AllScreens)
      {
        listBox1.Items.Add("Device Name: " + screen.DeviceName);
        listBox1.Items.Add("Bounds: " +
            screen.Bounds.ToString());
        listBox1.Items.Add("Type: " +
            screen.GetType().ToString());
        listBox1.Items.Add("Working Area: " +
            screen.WorkingArea.ToString());
        listBox1.Items.Add("Primary Screen: " +
            screen.Primary.ToString());

        listBox1.Items.Add("Active Screen: " + (current == screen.WorkingArea? "Yes":"No"));

        listBox1.Items.Add("");
      }
    }

    private void button1_Click(object sender, EventArgs e)
    {
      Crypto.Test();
      //InputBoxResult res = InputBox.Show("String to Encrypt", "Crypto", "Hello World");
      //if (res.OK)
      //{
      //  string str = res.Text;
      //  CCTimer timer = new CCTimer();
      //  timer.Start();
      //  String enc = Crypto.Encrypt(str, "ken");
      //  MessageBox.Show(enc + Environment.NewLine + timer.Stop());
      //  timer.Start();
      //  String dec = Crypto.Decrypt(enc, "joe");
      //  MessageBox.Show(dec + Environment.NewLine + timer.Stop());
      //}
    }
  }
}
