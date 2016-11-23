using System;
using System.Threading;
using System.Web;
using Newtonsoft.Json;

namespace Skin.Framework.Logging
{
    public class ProcessInformation
    {
        private const string SlotName = "ProcessInformation";

        public ProcessInformation(string applicationName)
        {
            ApplicationName = applicationName;
            RequestId = ShortGuid.NewGuid();
            MachineName = System.Environment.MachineName;
            if (Current == null) Store(this);
        }


        public string ApplicationName { get; set; }

        public string Environment { get; set; }

        public string Flavour { get; set; }

        public string RequestId { get; private set; }

        public string SessionId { get; set; }

        public string MachineName { get; private set; }

        public string Organisation { get; set; }

        public string Username { get; set; }

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
