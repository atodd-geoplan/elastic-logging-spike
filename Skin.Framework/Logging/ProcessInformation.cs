using System;
using System.Threading;
using System.Web;
using Nest;
using Newtonsoft.Json;

namespace Skin.Framework.Logging
{
    public class ProcessInformation
    {
        private const string SlotName = "ProcessInformation";

        public ProcessInformation(string applicationName)
        {
            app = applicationName;
            rid = ShortGuid.NewGuid();
            host = System.Environment.MachineName;
            if (Current == null) Store(this);
        }

        public string app { get; set; }

        public string env { get; set; }

        public string rid { get; private set; }

        public string sid { get; set; }

        public string host { get; set; }

        public string org { get; set; }

        public string user { get; set; }

        // we do not want this logged on every log (given every log entry is timestamped), so make it a method
        private readonly DateTime startTime = DateTime.UtcNow;
        public DateTime GetProcessStartTime()
        {
            return startTime;
        }

        public static void New(string applicationName)
        {
            new ProcessInformation(applicationName);
        }

        public static ProcessInformation Current =>
        ((HttpContext.Current == null
            ? Thread.GetData(Thread.GetNamedDataSlot(SlotName))
            : HttpContext.Current.Items[SlotName]) as ProcessInformation);

        private static void Store(ProcessInformation info)
        {
            if (HttpContext.Current == null)
                Thread.SetData(Thread.GetNamedDataSlot(SlotName), info);
            else HttpContext.Current.Items.Add(SlotName, info);
        }


        public static void FromString(string pi)
        {
            if (string.IsNullOrEmpty(pi))
            {
                New(null);
                return;
            }
            JsonConvert.DeserializeObject<ProcessInformation>(pi);
        }
    }
}
