using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace Coop.Helper
{
    public class ThreadHelper
    {
        public static Thread ExecuteThread(Action action,bool join = false)
        {
            Thread thread= new Thread(()=>action(),1024*1024);
            thread.Start();
            if (join)
            {
                thread.Join();
            }
            return thread;
        }
    }
}
