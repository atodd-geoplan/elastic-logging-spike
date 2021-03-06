﻿using System;
using Skin.Framework.Logging;

namespace SerilogSpike
{
    internal class LoggingExample
    {

        internal LoggingExample()
        {
            
            using (var logger = new SerilogLogProvider())
            {
                var time = DateTime.UtcNow;
                logger.Info("Starting the logging test app.");
            }
        }
    }
}
