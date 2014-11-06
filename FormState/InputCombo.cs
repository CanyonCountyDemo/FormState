using System;
using System.Drawing;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;

namespace CC.Common.Utils
{
  public class InputCombo : System.Windows.Forms.Form
  {
    protected System.Windows.Forms.Button buttonOK;
    protected System.Windows.Forms.Button buttonCancel;
    protected System.Windows.Forms.Label labelPrompt;
    protected System.Windows.Forms.ComboBox comboBox;
    protected System.Windows.Forms.ErrorProvider errorProviderText;

    /// <summary>
    /// Required designer variable.
    /// </summary>
    private System.ComponentModel.Container components = null;

    /// <summary>
    /// Delegate used to validate the object
    /// </summary>
    private InputComboValidatingHandler _validator;

    private InputCombo()
    {
      //
      // Required for Windows Form Designer support
      //
      InitializeComponent();

      //
      // TODO: Add any constructor code after InitializeComponent call
      //
    }

    /// <summary>
    /// Clean up any resources being used.
    /// </summary>
    protected override void Dispose(bool disposing)
    {
      if (disposing)
      {
        if (components != null)
        {
          components.Dispose();
        }
      }
      base.Dispose(disposing);
    }

    #region Windows Form Designer generated code
    /// <summary>
    /// Required method for Designer support - do not modify
    /// the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent()
    {
      this.buttonOK = new System.Windows.Forms.Button();
      this.buttonCancel = new System.Windows.Forms.Button();
      this.comboBox = new System.Windows.Forms.ComboBox();
      this.labelPrompt = new System.Windows.Forms.Label();
      this.errorProviderText = new System.Windows.Forms.ErrorProvider();
      this.SuspendLayout();
      // 
      // buttonOK
      // 
      this.buttonOK.Anchor = (System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right);
      this.buttonOK.DialogResult = System.Windows.Forms.DialogResult.OK;
      this.buttonOK.Location = new System.Drawing.Point(288, 72);
      this.buttonOK.Name = "buttonOK";
      this.buttonOK.TabIndex = 2;
      this.buttonOK.Text = "OK";
      this.buttonOK.Click += new System.EventHandler(this.buttonOK_Click);
      // 
      // buttonCancel
      // 
      this.buttonCancel.Anchor = (System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right);
      this.buttonCancel.CausesValidation = false;
      this.buttonCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
      this.buttonCancel.Location = new System.Drawing.Point(376, 72);
      this.buttonCancel.Name = "buttonCancel";
      this.buttonCancel.TabIndex = 3;
      this.buttonCancel.Text = "Cancel";
      this.buttonCancel.Click += new System.EventHandler(this.buttonCancel_Click);
      // 
      // textBoxText
      // 
      this.comboBox.Location = new System.Drawing.Point(16, 32);
      this.comboBox.Name = "textBoxText";
      this.comboBox.Size = new System.Drawing.Size(416, 20);
      this.comboBox.TabIndex = 1;
      this.comboBox.Text = "";
      this.comboBox.DropDownStyle = ComboBoxStyle.DropDownList;
      this.comboBox.Validating += new System.ComponentModel.CancelEventHandler(this.comboBox_Validating);
      this.comboBox.TextChanged += new System.EventHandler(this.textBoxText_TextChanged);
      // 
      // labelPrompt
      // 
      this.labelPrompt.AutoSize = true;
      this.labelPrompt.Location = new System.Drawing.Point(15, 15);
      this.labelPrompt.Name = "labelPrompt";
      this.labelPrompt.Size = new System.Drawing.Size(39, 13);
      this.labelPrompt.TabIndex = 0;
      this.labelPrompt.Text = "prompt";
      // 
      // errorProviderText
      // 
      this.errorProviderText.DataMember = null;
      // 
      // InputCombo
      // 
      this.AcceptButton = this.buttonOK;
      this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
      this.CancelButton = this.buttonCancel;
      this.ClientSize = new System.Drawing.Size(464, 104);
      this.Controls.AddRange(new System.Windows.Forms.Control[] {
																		  this.labelPrompt,
																		  this.comboBox,
																		  this.buttonCancel,
																		  this.buttonOK});
      this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
      this.MaximizeBox = false;
      this.MinimizeBox = false;
      this.Name = "InputCombo";
      this.Text = "Title";
      this.ResumeLayout(false);

    }
    #endregion

    private void buttonCancel_Click(object sender, System.EventArgs e)
    {
      this.Validator = null;
      this.Close();
    }

    private void buttonOK_Click(object sender, System.EventArgs e)
    {
      this.Close();
    }

    /// <summary>
    /// Displays a prompt in a dialog box, waits for the user to input text or click a button.
    /// </summary>
    /// <param name="prompt">String expression displayed as the message in the dialog box</param>
    /// <param name="title">String expression displayed in the title bar of the dialog box</param>
    /// <param name="defaultResponse">String expression displayed in the text box as the default response</param>
    /// <param name="validator">Delegate used to validate the text</param>
    /// <param name="xpos">Numeric expression that specifies the distance of the left edge of the dialog box from the left edge of the screen.</param>
    /// <param name="ypos">Numeric expression that specifies the distance of the upper edge of the dialog box from the top of the screen</param>
    /// <returns>An InputComboResult object with the Text and the OK property set to true when OK was clicked.</returns>
    public static InputComboResult Show(string prompt, string title, string selectedItem, object[] items, InputComboValidatingHandler validator, int xpos, int ypos)
    {
      using (InputCombo form = new InputCombo())
      {
        form.labelPrompt.Text = prompt;
        form.Text = title;
        form.comboBox.Items.AddRange(items);
        if (selectedItem != null)
        {
          for (int i = 0; i < form.comboBox.Items.Count; i++)
          {
            if (form.comboBox.Items[i].ToString().Equals(selectedItem))
            {
              form.comboBox.SelectedIndex = i;
              break;
            }
          }
        }

        if (xpos >= 0 && ypos >= 0)
        {
          form.StartPosition = FormStartPosition.Manual;
          form.Left = xpos;
          form.Top = ypos;
        }
        else
        {
          form.StartPosition = FormStartPosition.CenterParent;
        }
        form.Validator = validator;

        DialogResult result = form.ShowDialog();

        InputComboResult retval = new InputComboResult();
        if (result == DialogResult.OK)
        {
          retval.Text = form.comboBox.Text;
          retval.SelectedIndex = form.comboBox.SelectedIndex;
          retval.Object = form.comboBox.SelectedItem;
          retval.OK = true;
        }
        return retval;
      }
    }

    /// <summary>
    /// Displays a prompt in a dialog box, waits for the user to input text or click a button.
    /// </summary>
    /// <param name="prompt">String expression displayed as the message in the dialog box</param>
    /// <param name="title">String expression displayed in the title bar of the dialog box</param>
    /// <param name="defaultResponse">String expression displayed in the text box as the default response</param>
    /// <param name="validator">Delegate used to validate the text</param>
    /// <returns>An InputComboResult object with the Text and the OK property set to true when OK was clicked.</returns>
    public static InputComboResult Show(string prompt, string title, string selectedItem, object[] items, InputComboValidatingHandler validator)
    {
      return Show(prompt, title, selectedItem, items, validator, -1, -1);
    }

    public static InputComboResult Show(string prompt, string title, string selectedItem, object[] items)
    {
      return Show(prompt, title, selectedItem, items, null);
    }

    /// <summary>
    /// Reset the ErrorProvider
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void textBoxText_TextChanged(object sender, System.EventArgs e)
    {
      errorProviderText.SetError(comboBox, "");
    }

    /// <summary>
    /// Validate the Text using the Validator
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void comboBox_Validating(object sender, System.ComponentModel.CancelEventArgs e)
    {
      if (Validator != null)
      {
        InputComboValidatingArgs args = new InputComboValidatingArgs();
        args.Text = comboBox.Text;
        args.SelectedIndex = comboBox.SelectedIndex;
        args.Object = comboBox.SelectedItem;
        Validator(this, args);
        if (args.Cancel)
        {
          e.Cancel = true;
          errorProviderText.SetError(comboBox, args.Message);
        }
      }
    }

    protected InputComboValidatingHandler Validator
    {
      get
      {
        return (this._validator);
      }
      set
      {
        this._validator = value;
      }
    }
  }

  /// <summary>
  /// Class used to store the result of an InputCombo.Show message.
  /// </summary>
  public class InputComboResult
  {
    public bool OK;
    public string Text;
    public object Object;
    public int SelectedIndex;
  }

  /// <summary>
  /// EventArgs used to Validate an InputCombo
  /// </summary>
  public class InputComboValidatingArgs : EventArgs
  {
    public string Text;
    public object Object;
    public int SelectedIndex;
    public string Message;
    public bool Cancel;
  }

  /// <summary>
  /// Delegate used to Validate an InputCombo
  /// </summary>
  public delegate void InputComboValidatingHandler(object sender, InputComboValidatingArgs e);

}
