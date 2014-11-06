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

  public class StateMachine
  {
    // We're a singleton
    private static StateMachine instance = null;
    private static frmMain _owner;
    private static frmHelp _help;
    private static Dictionary<string, Form> _forms;
    private static Stack<Form> _stack;


    public StateMachine()
    {
      _forms = new Dictionary<string, Form>();
      _stack = new Stack<Form>();
    }
    
    public static StateMachine Instance(frmMain owner)
    {
      if (instance == null)
      {
        instance = new StateMachine();
        _owner = owner;
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

    public void Navigate(string Name)
    {
      if (_forms.Keys.Contains<string>(Name))
      {
        Form frm = _forms[Name];
        if (_owner.ActiveMdiChild != null)
        {
          _stack.Push(_owner.ActiveMdiChild);
          _owner.ActiveMdiChild.Hide();
        }
        Navigate(frm);
      }
      else
      {
        throw new Exception("State Machine: I don't know what " + Name + " is");
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
      _owner.tsBack.Visible = CanGoBack();
      if (_help != null) _help.Navigate(frm.Text);
      SetStatus(frm.Text);
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
}
