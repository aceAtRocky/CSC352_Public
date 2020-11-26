using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PLINQExample
{
    public class Class1
    {

        public static void PerformTask(int seconds)
        {
            System.Threading.Thread.Sleep(seconds * 1000);
        }
    }
}
