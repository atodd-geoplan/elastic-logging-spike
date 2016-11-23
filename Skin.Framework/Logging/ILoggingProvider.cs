using System;

namespace Skin.Framework.Logging
{
    public interface ILoggingProvider: IDisposable
    {
        void Debug(string format, params object[] values);
        void Info(string format, params object[] values);
        void Exception(Exception ex, string format, params object[] values);
    }
}
