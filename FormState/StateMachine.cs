using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Reflection;

namespace FormState
{
  // This will handle several things
  // Which form is active
  // Which form we came from
  // Creating forms, loading forms, showing forms
  public class StateMachineOld
  {
    // We're a singleton
    private static StateMachineOld instance = null;
    private static frmMain _owner;
    private static Dictionary<string, Form> _forms;
    private static Stack<Form> _stack;
    

    public StateMachineOld()
    {
      _forms = new Dictionary<string, Form>();
      _stack = new Stack<Form>();
    }

    public static StateMachineOld Instance(frmMain owner)
    {
      if (instance == null)
      {
        instance = new StateMachineOld();
        _owner = owner;
        _owner.tsBack.Click += new System.EventHandler(Back_Click);
      }
      return instance;
    }
    
    public static StateMachineOld Instance()
    {
      if (instance == null)
      {
        instance = new StateMachineOld();
      }
      if (_owner == null) throw new Exception("I need an owner, please call that instance first");
      return instance;
    }

    public void AddForm(string Name, Form frm)
    {
      // Make sure it's not already in the dictionary
      if (!_forms.Keys.Contains<string>(Name))
      {
        _forms.Add(Name, frm);
      }
    }

    public void Navigate(string Name)
    {
      if (_forms.Keys.Contains<string>(Name))
      {
        Form frm = _forms[Name];
        if (_owner.ActiveMdiChild != null)
          _stack.Push(_owner.ActiveMdiChild);
        Navigate(frm);
      }
      else
      {
        throw new Exception("State Machine: I don't know what " + Name + " is");
      }
    }

    private void Navigate(Form frm)
    {
      frm.MdiParent = _owner;
      frm.Dock = DockStyle.Fill;
      frm.FormBorderStyle = FormBorderStyle.None;
      frm.Show();
      frm.BringToFront();
      _owner.tsBack.Visible = CanGoBack();
    }

    private bool CanGoBack()
    {
      return _stack.Count > 0;
    }

    private static void Back_Click(object sender, EventArgs e)
    {
      Form frm = _stack.Pop();
      instance.Navigate(frm);
    }
  }

  public class StateMachine<T>
  {
    // We're a singleton
    private static StateMachine<T> instance = null;
    private static frmMain _owner;
    private static Dictionary<string, T> _forms;
    private static Stack<Form> _stack;


    public StateMachine()
    {
      _forms = new Dictionary<string, T>();
      _stack = new Stack<Form>();
    }

    public static StateMachine<T> Instance(frmMain owner)
    {
      if (instance == null)
      {
        instance = new StateMachine<T>();
        _owner = owner;
        _owner.tsBack.Click += new System.EventHandler(Back_Click);
      }
      return instance;
    }

    public static StateMachine<T> Instance()
    {
      if (instance == null)
      {
        instance = new StateMachine<T>();
      }
      if (_owner == null) throw new Exception("I need an owner, please call that instance first");
      return instance;
    }

    public void AddForm(string Name, T frm)
    {
      // Make sure it's not already in the dictionary
      if (!_forms.Keys.Contains<string>(Name))
      {
        _forms.Add(Name, frm);
      }
    }

    public void AddForms()
    {
      // Use reflection to add All forms but _owner
      Assembly assembly = Assembly.GetAssembly(typeof(T));
      Type[] types = assembly.GetTypes();
      foreach (Type type in types)
      {
        if (type.BaseType == typeof(T))
        {
          object obj = (T)Activator.CreateInstance(type);
          _forms.Add(obj.ToString(), (T)obj);
        }
      }
    }

    public void Navigate(string Name)
    {
      if (_forms.Keys.Contains<string>(Name))
      {
        T frm = _forms[Name];
        if (_owner.ActiveMdiChild != null)
          _stack.Push(_owner.ActiveMdiChild);
        Navigate((frm as Form));
      }
      else
      {
        throw new Exception("State Machine: I don't know what " + Name + " is");
      }
    }

    private void Navigate(Form frm)
    {
      //Form frm = Form(T);
      frm.MdiParent = _owner;
      frm.Dock = DockStyle.Fill;
      frm.FormBorderStyle = FormBorderStyle.None;
      frm.Show();
      frm.BringToFront();
      _owner.tsBack.Visible = CanGoBack();
    }

    private bool CanGoBack()
    {
      return _stack.Count > 0;
    }

    private static void Back_Click(object sender, EventArgs e)
    {
      Form frm = _stack.Pop();
      instance.Navigate(frm);
    }
  }

  public class StateMachineException : Exception 
  {
    public StateMachineException() : base() { }
    public StateMachineException(string message) : base(message) { }
  }

  public class StateMachine
  {
    // We're a singleton
    private static StateMachine instance = null;
    private static frmMain _owner;
    private static frmHelp _help;
    private static Dictionary<string, Form> _forms;
    private static Stack<Form> _stack;
    private static Stack<string> _next;
    public bool AutoCreateForms = true;
    public string FormPrefix = "frm";
    public bool ExceptionOnNullOrEmptyForm = true;

    public StateMachine()
    {
      _forms = new Dictionary<string, Form>();
      _stack = new Stack<Form>();
      _next = new Stack<string>();
    }
    
    public static StateMachine Instance(frmMain owner)
    {
      if (instance == null)
      {
        instance = new StateMachine();
        _owner = owner;
        _owner.IsMdiContainer = true; // Force this if they didn't
        _owner.tsBack.Click += new System.EventHandler(Back_Click);
      }
      return instance;
    }
    
    public static StateMachine Instance(frmMain owner, frmHelp help)
    {
      if (instance == null)
      {
        instance = new StateMachine();
        _owner = owner;
        _owner.tsBack.Click += new System.EventHandler(Back_Click);
        _help = help;
      }
      return instance;
    }

    public static StateMachine Instance()
    {
      if (instance == null)
      {
        instance = new StateMachine();
      }

      // Kill running the following code in the Visual Studio designer
      if (System.ComponentModel.LicenseManager.UsageMode != System.ComponentModel.LicenseUsageMode.Designtime)
        if (_owner == null) throw new StateMachineException("I need an owner, please call that instance first");
      
      return instance;
    }

    public void AddForm(string Name, Form frm)
    {
      // Make sure it's not already in the dictionary
      if (!_forms.Keys.Contains<string>(Name))
      {
        _forms.Add(Name, frm);
      }
    }

    public void AddForms(Type frm)
    {
      // Use reflection to add All forms but _owner
      Assembly assembly = Assembly.GetAssembly(frm);//.GetType());
      Type[] types = assembly.GetTypes();
      foreach (Type type in types)
      {
        if (type.BaseType == frm)//.GetType())
        {
          Form obj = (Form)Activator.CreateInstance(type);
          _forms.Add(obj.ToString(), obj);
        }
      }
    }

    private Form FindForm(string Name)
    {
      Assembly assembly = Assembly.GetExecutingAssembly();
      Type[] types = assembly.GetTypes();
      Form frm = null;
      foreach (Type type in types)
      {
        // If the type name is the name we passed in
        // OR the name we passed in pluss the FormPrefix
        // then that's the form we want
        if ((type.Name == Name) | (type.Name == FormPrefix + Name))
          frm = (Form)Activator.CreateInstance(type);
      }
      return frm;
    }

    public void Navigate(params string[] list)
    {
      // Push the items onto the stack in reverse order
      // so they pop off the stack the the order passed in
      foreach (string form in list.Reverse())
      {
        _next.Push(form);
      }

      Navigate(_next.Pop());
    }

    public void Navigate(string Name)
    {
      // You don't pass me anything, I don't do anything
      if (!String.IsNullOrEmpty(Name))
      {
        Form frm = null;
        if (_forms.Keys.Contains<string>(Name))
        {
          frm = _forms[Name];
          // Moved this to below so we can handle AutoCreateForms
          // This is now better/easier than Delphi and default .NET
          //if (_owner.ActiveMdiChild != null)
          //{
          //  _stack.Push(_owner.ActiveMdiChild);
          //  _owner.ActiveMdiChild.Hide();
          //}
          //Navigate(frm);
        }
        else if (_forms.Keys.Contains<string>(FormPrefix + Name))
        {
          frm = _forms[FormPrefix + Name];
        }
        else
        {
          if (AutoCreateForms)
          {
            frm = FindForm(Name);
            if (frm != null)
              AddForm(frm.Name, frm);
          }
        }

        if (frm != null)
        {
          if (_owner.ActiveMdiChild != null)
          {
            _stack.Push(_owner.ActiveMdiChild);
            _owner.ActiveMdiChild.Hide();
          }
          Navigate(frm);
        }
        else
        {
          throw new StateMachineException("State Machine: I don't know what " + Name + " is");
        }
      }
      else
      {
        if (ExceptionOnNullOrEmptyForm)
          throw new StateMachineException("State Machine: I was told to move to a null or empty form name");
      }
    }

    public void SetStatus(string msg)
    {
      _owner.statusLabel.Text = msg;
    }

    private void Navigate(Form frm)
    {
      //Form frm = Form(T);
      frm.MdiParent = _owner;
      frm.Dock = DockStyle.Fill;
      frm.FormBorderStyle = FormBorderStyle.None;
      frm.Show();
      frm.BringToFront();
      _owner.tsBack.Enabled = CanGoBack;
      if (_help != null) _help.Navigate(frm.Name.ToString());//.Text);
      SetStatus(frm.Text);
    }

    private bool CanGoBack
    {
      get
      {
        return _stack.Count > 0;
      }
    }

    private static void Back_Click(object sender, EventArgs e)
    {
      if (_stack.Count > 0)
      {
        Form frm = _stack.Pop();
        instance.Navigate(frm);
      }
    }

    public bool CanGoForward
    {
      get
      {
        //_owner.Text = _next.Count.ToString();
        return _next.Count > 0;
      }
    }

    public void NextForm()
    {
      if (_next.Count > 0)
      {
        string form = _next.Pop();
        if (!ExceptionOnNullOrEmptyForm)
        {
          while (String.IsNullOrEmpty(form))
          {
            form = _next.Pop();
            if (!CanGoForward) break;
          }
        }
        instance.Navigate(form);
      }
    }
  } 
}
