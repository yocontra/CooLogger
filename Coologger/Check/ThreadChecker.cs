using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace Coologger.Check
{
    internal class ThreadChecker
    {
        public static void CheckThreads()
        {
            if (Global.BeatThread == null)
            {
                Environment.Exit(1337);
            }
            switch (Global.BeatThread.ThreadState)
            {
                case ThreadState.Unstarted:
                case ThreadState.Aborted:
                case ThreadState.Stopped:
                case ThreadState.Suspended:
                    Environment.Exit(9001);
                    break;
            }
            Thread.Sleep(1500);
        }
    }
}