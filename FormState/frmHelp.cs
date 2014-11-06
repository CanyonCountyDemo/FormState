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
  public partial class frmHelp : Form
  {
    private string _help;

    public frmHelp()
    {
      InitializeComponent();
      webBrowser1.Navigate("about:blank");
    }

    public void Navigate(string help)
    {
      //label1.Text = "Loading help on " + help;
      HtmlDocument doc = webBrowser1.Document;
      doc.Write(string.Empty);
      _help = help;
      LoadHelp(false);
    }

    private void LoadHelp(bool force)
    {
      if (force)
      {
        webBrowser1.DocumentText = "<br><br><br><br><br>Loading help on " + _help;
      }
      else
      {
        if (cbAuto.Checked)
        {
          webBrowser1.DocumentText = "<br><br><br><br><br><br>Loading help on " + _help;
        }

      }
    }

    private void btnRefresh_Click(object sender, EventArgs e)
    {
      LoadHelp(true);
    }
  }
}
