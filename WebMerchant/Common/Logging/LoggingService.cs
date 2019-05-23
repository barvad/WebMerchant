using System;
using System.Runtime.CompilerServices;
using WebMerchant.InternetAcquiring.Concrete.Logging;

namespace WebMerchant.InternetAcquiring.Contracts.Logging
{
    public abstract class LoggingService
    {
        private static LoggingService _current;

        static LoggingService()
        {
            _current = new NullLoggingService();
        }

        public static LoggingService Current
        {
            get { return _current; }
            set
            {
                if (value == null)
                {
                    throw new ArgumentNullException(nameof(value));
                }
                _current = value;
            }
        }

        public abstract bool IsDebugEnabled { get; }
        public abstract bool IsErrorEnabled { get; }
        public abstract bool IsFatalEnabled { get; }
        public abstract bool IsInfoEnabled { get; }
        public abstract bool IsTraceEnabled { get; }
        public abstract bool IsWarnEnabled { get; }

        public abstract void Debug(Exception exception);
        public abstract void Debug(string format, [CallerMemberName]string method = null,[CallerLineNumber]int line= 0,[CallerFilePath]string file=null, params object[] args);
        public abstract void Debug(Exception exception, string format, [CallerMemberName]string method = null,[CallerLineNumber]int line= 0,[CallerFilePath]string file=null, params object[] args);
        public abstract void Error(Exception exception);
        public abstract void Error(string format, [CallerMemberName]string method = null,[CallerLineNumber]int line= 0,[CallerFilePath]string file=null, params object[] args);
        public abstract void Error(Exception exception, string format, [CallerMemberName]string method = null,[CallerLineNumber]int line= 0,[CallerFilePath]string file=null, params object[] args);
        public abstract void Fatal(Exception exception);
        public abstract void Fatal(string format, [CallerMemberName]string method = null,[CallerLineNumber]int line= 0,[CallerFilePath]string file=null, params object[] args);
        public abstract void Fatal(Exception exception, string format, [CallerMemberName]string method = null,[CallerLineNumber]int line= 0,[CallerFilePath]string file=null, params object[] args);
        public abstract void Info(Exception exception);
        public abstract void Info(string format, [CallerMemberName]string method = null,[CallerLineNumber]int line= 0,[CallerFilePath]string file=null, params object[] args);
        public abstract void Info(Exception exception, string format, [CallerMemberName]string method = null,[CallerLineNumber]int line= 0,[CallerFilePath]string file=null, params object[] args);
        public abstract void Trace(Exception exception);
        public abstract void Trace(string format, [CallerMemberName]string method = null,[CallerLineNumber]int line= 0,[CallerFilePath]string file=null, params object[] args);
        public abstract void Trace(Exception exception, string format, [CallerMemberName]string method = null,[CallerLineNumber]int line= 0,[CallerFilePath]string file=null, params object[] args);
        public abstract void Warn(Exception exception);
        public abstract void Warn(string format, [CallerMemberName]string method = null,[CallerLineNumber]int line= 0,[CallerFilePath]string file=null, params object[] args);
        public abstract void Warn(Exception exception, string format, [CallerMemberName]string method = null,[CallerLineNumber]int line= 0,[CallerFilePath]string file=null, params object[] args);
    }
}