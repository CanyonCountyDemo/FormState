using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;

namespace CC.Common.Utils
{
  public class CCTimer
  {
    private Stopwatch _stopwatch;
    private bool _justTime;

    public void Start()
    {
      _stopwatch = new Stopwatch();
      _stopwatch.Start();
      _justTime = false;
    }

    public string Stop()
    {
      _stopwatch.Stop();
      TimeSpan ts = _stopwatch.Elapsed;
      string elapsedTime = String.Format("{0:00}:{1:00}:{2:00}.{3:00}",
          ts.Hours, ts.Minutes, ts.Seconds,
          ts.Milliseconds / 10);

      String res = String.Format("{0}", elapsedTime);
      if (!_justTime)
        res = "Time taken : " + res;
      //return String.Format("Time taken : {0}", elapsedTime);
      return res;
    }

    public string Stop(bool justTime)
    {
      _justTime = justTime;
      return Stop();
    }
  }
}
