using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using NUnit.Framework;

namespace PLINQExample
{
    [TestFixture]
    class UnitTests
    {
        [Test]
        public void TestIt()
        {
            Stopwatch sw = Stopwatch.StartNew();
            Class1.PerformTask(5);
            Class1.PerformTask(10);
            Class1.PerformTask(15);
            sw.Stop();
            Console.WriteLine(sw.Elapsed.TotalSeconds);
        }

        [Test]
        public void TestIt_Parallel()
        {
            var tasks = new List<Action>()
            {
                () => Class1.PerformTask(5),
                () => Class1.PerformTask(10),
                () => Class1.PerformTask(15),
            };

            tasks.AsParallel().ForAll(action => action());
        }
    }
}
