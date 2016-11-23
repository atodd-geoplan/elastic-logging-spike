﻿using System;
using Destructurama;
using Elasticsearch.Net;
using Serilog;
using Serilog.Core;
using Serilog.Events;
using Serilog.Sinks.Elasticsearch;

namespace Skin.Framework.Logging
{
    public class SerilogLogProvider: ILoggingProvider
    {
        public SerilogLogProvider()
        {
            var config = new ConnectionConfiguration();
            config.BasicAuthentication("elastic", "3MHykIo61VAyAOBsVAPYhmem");
            var options =
                new ElasticsearchSinkOptions(new[]
                {
                    new Uri(
                        "http://elastic:3MHykIo61VAyAOBsVAPYhmem@58d386963d5662da10960b1de5145771.eu-west-1.aws.found.io:9200")
                });
                //{
                //    ModifyConnectionSettings = () => config
                //};

            var sink = new ElasticsearchSink(options);
         
            Log.Logger = new LoggerConfiguration()
                .Enrich.With<ProcessInfoEnricher>()
                .Destructure.UsingAttributes()
                .WriteTo.Sink(sink)

                //.WriteTo.Seq("http://localhost:5341")
            .CreateLogger();

        }

        private static SerilogLogProvider instance;
        public static SerilogLogProvider Instance
        {
            get
            {
                instance = instance ?? new SerilogLogProvider();
                return instance;
            }
        }

        public void Debug(string format, params object[] values)
        {
            throw new NotImplementedException();
        }

        public void Info(string format, params object[] values)
        {
            Log.Information(format, values);
        }

        public void Exception(Exception ex, string format, params object[] values)
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            Log.CloseAndFlush();
        }
    }

    class ProcessInfoEnricher : ILogEventEnricher
    {
        public void Enrich(LogEvent logEvent, ILogEventPropertyFactory propertyFactory)
        {
            logEvent.AddPropertyIfAbsent(propertyFactory.CreateProperty(
                    "ProcessInformation", ProcessInformation.Current, true));
        }
    }
}
