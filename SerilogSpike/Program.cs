using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Skin.Framework.Logging;

namespace SerilogSpike
{
    class Program
    {
        static void Main(string[] args)
        {
            new ProcessInformation("TestLoggingConsoleApp");
            new LoggingExample();
            Console.WriteLine("Hit meh ...");
            Console.ReadLine();

            //appLifetime.ApplicationStopped.Register(Log.CloseAndFlush);
        }
    }
}
