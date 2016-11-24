using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Skin.Framework.Logging;

namespace SerilogSpike
{
    class Program
    {

        static void Main(string[] args)
        {
            var quitFlag = false;

            new ProcessInformation("TestLoggingConsoleApp");
            new LoggingExample();

            Console.WriteLine("Hit meh ...");
            Console.CancelKeyPress += delegate {
                quitFlag = true;
            };

            new LogGenerator().Generate();

            while (!quitFlag)
            {
                Thread.Sleep(1);
            }
            
        }
    }
}
