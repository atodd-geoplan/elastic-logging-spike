using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Elasticsearch.Net;
using Serilog.Events;
using Serilog.Sinks.Elasticsearch;

namespace Skin.Framework.Logging
{
    public class SkinElasticSearchJsonFormatter: DefaultJsonFormatter
    {
    //    private readonly bool inlineFields;

    //    /// <summary>
    //    /// Construct a <see cref="T:Serilog.Sinks.Elasticsearch.ElasticsearchJsonFormatter" />.
    //    /// </summary>
    //    /// <param name="omitEnclosingObject">If true, the properties of the event will be written to
    //    /// the output without enclosing braces. Otherwise, if false, each event will be written as a well-formed
    //    /// JSON object.</param>
    //    /// <param name="closingDelimiter">A string that will be written after each log event is formatted.
    //    /// If null, <see cref="P:System.Environment.NewLine" /> will be used. Ignored if <paramref name="omitEnclosingObject" />
    //    /// is true.</param>
    //    /// <param name="renderMessage">If true, the message will be rendered and written to the output as a
    //    /// property named RenderedMessage.</param>
    //    /// <param name="formatProvider">Supplies culture-specific formatting information, or null.</param>
    //    /// <param name="serializer">Inject a serializer to force objects to be serialized over being ToString()</param>
    //    /// <param name="inlineFields">When set to true values will be written at the root of the json document</param>
    //    public SkinElasticSearchJsonFormatter(bool omitEnclosingObject = false, string closingDelimiter = null, bool renderMessage = false, IFormatProvider formatProvider = null, IElasticsearchSerializer serializer = null, bool inlineFields = false)
    //  : base(omitEnclosingObject, closingDelimiter, renderMessage, formatProvider)
    //{

    //        this.inlineFields = inlineFields;
    //    }

    //    /// <summary>
    //    /// Writes out a json property with the specified value on output writer
    //    /// </summary>
    //    protected override void WriteJsonProperty(string name, object value, ref string precedingDelimiter, TextWriter output)
    //    {
    //        output.Write(precedingDelimiter);
    //        output.Write("\"");
    //        output.Write(name);
    //        output.Write("\":");
    //        WriteLiteral(value, output, false);
    //        precedingDelimiter = ",";
    //    }

    //    private void WriteLiteral(object value, TextWriter output, bool forceQuotation = false)
    //    {
    //        if (value == null)
    //        {
    //            output.Write("null");
    //        }
    //        else
    //        {
    //            Action<object, bool, TextWriter> action;
    //            if (this._literalWriters.TryGetValue(value.GetType(), out action))
    //                action(value, forceQuotation, output);
    //            else
    //                this.WriteLiteralValue(value, output);
    //        }
    //    }
    }
}
