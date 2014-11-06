using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Resources;
using System.Text.RegularExpressions;

namespace FormState
{
  public partial class frmHelp : Form
  {
    private string _help;
    private bool _meLoad;
    private string css = @"<head>
  <style type='text/css'>
    p{font-family:Verdania,Helvetica,Tahoma;font-size:10pt}
    p.error{font-size:15px;font-color:Red}
    p.small{font-size:8pt}
  </style>
</head>";

    public frmHelp()
    {
      InitializeComponent();
      _meLoad = true;
      webBrowser1.Navigate("about:blank");
      _meLoad = false;
    }

    public void Navigate(string help)
    {
      //label1.Text = "Loading help on " + help;
      HtmlDocument doc = webBrowser1.Document;
      doc.Write(string.Empty);
      _help = help;
      LoadHelp(false);
    }

    private void _LoadHelp()
    {
      //ResourceManager rm = new ResourceManager();
      System.Reflection.Assembly asm = System.Reflection.Assembly.GetExecutingAssembly();
      //MessageBox.Show(asm.GetName().Name);
      string name = asm.GetName().Name + ".Resources." + _help + ".txt";
      string text = "";
      System.IO.Stream s = asm.GetManifestResourceStream(name);
      if (s != null)
      {
        byte[] b = new byte[Convert.ToInt32(s.Length)];
        s.Read(b, 0, Convert.ToInt32(s.Length));
        text = System.Text.ASCIIEncoding.ASCII.GetString(b);
      }
      else
      {
        text = "<p style='color:red'>Cannot find help for page " + _help + "<br><br>Try EmbeddedResource</p>";
      }
      
      // Replace <head>*</head> with <head>CSS</head>
      string pattern = "<head.*?</head>"; // woot!
      Regex r = new Regex(pattern, RegexOptions.Compiled | RegexOptions.IgnoreCase | RegexOptions.Singleline);
      string rtext = r.Replace(text, css);
      _meLoad = true;
      webBrowser1.DocumentText = rtext + "<p class='small'>" + name + "</p>";
      _meLoad = false;
    }

    private void LoadHelp(bool force)
    {
      if (force)
      {
        _LoadHelp();
      }
      else
      {
        if (cbAuto.Checked)
        {
          _LoadHelp();
        }

      }
    }

    private void btnRefresh_Click(object sender, EventArgs e)
    {
      LoadHelp(true);
    }

    private void webBrowser1_Navigating(object sender, WebBrowserNavigatingEventArgs e)
    {
      if (!_meLoad)
      {
        if(!e.Url.ToString().Equals("about:blank"))
        {
          _help = e.Url.ToString().Replace("about:", "");
          _LoadHelp();
          e.Cancel = true;
        }
      }
    }
  }
}
