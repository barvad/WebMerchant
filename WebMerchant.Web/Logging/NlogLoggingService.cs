using System;
using System.Runtime.CompilerServices;
using NLog;
using WebMerchant.InternetAcquiring.Contracts.Logging;

namespace WebMerchant.Web.Logging
{
    public class NlogLoggingService : LoggingService
    {
        private const string LoggerName = "NLogLogger";
        private static readonly Logger Logger;

        static NlogLoggingService()
        {
            Logger = LogManager.GetLogger("NLogLogger");
        }


        public override bool IsDebugEnabled => Logger.IsDebugEnabled;
        public override bool IsErrorEnabled => Logger.IsErrorEnabled;
        public override bool IsFatalEnabled => Logger.IsFatalEnabled;
        public override bool IsInfoEnabled => Logger.IsInfoEnabled;
        public override bool IsTraceEnabled => Logger.IsTraceEnabled;
        public override bool IsWarnEnabled => Logger.IsWarnEnabled;

        public override void Debug(Exception exception, string format, [CallerMemberName]string method = null, [CallerLineNumber]int line = 0, [CallerFilePath]string file = null, params object[] args)
        {
            if (!IsDebugEnabled)
            {
                return;
            }
            var logEvent = GetLogEvent(LoggerName, LogLevel.Debug, exception, format, args);
            Logger.Log(typeof (NlogLoggingService), logEvent);
        }

        public override void Error(Exception exception, string format, [CallerMemberName]string method = null,[CallerLineNumber]int line= 0,[CallerFilePath]string file=null, params object[] args)
        {
            if (!IsErrorEnabled)
            {
                return;
            }
            var logEvent = GetLogEvent(LoggerName, LogLevel.Error, exception, format, args);
            Logger.Log(typeof (NlogLoggingService), logEvent);
        }

        public override void Fatal(Exception exception, string format, [CallerMemberName]string method = null,[CallerLineNumber]int line= 0,[CallerFilePath]string file=null, params object[] args)
        {
            if (!IsFatalEnabled)
            {
                return;
            }
            var logEvent = GetLogEvent(LoggerName, LogLevel.Fatal, exception, format, args);
            Logger.Log(typeof (NlogLoggingService), logEvent);
        }

        public override void Info(Exception exception, string format, [CallerMemberName]string method = null,[CallerLineNumber]int line= 0,[CallerFilePath]string file=null, params object[] args)
        {
            if (!IsInfoEnabled)
            {
                return;
            }
            var logEvent = GetLogEvent(LoggerName, LogLevel.Info, exception, format, args);
            Logger.Log(typeof (NlogLoggingService), logEvent);
        }

        public override void Trace(Exception exception, string format, [CallerMemberName]string method = null,[CallerLineNumber]int line= 0,[CallerFilePath]string file=null, params object[] args)
        {
            if (!IsTraceEnabled)
            {
                return;
            }
            var logEvent = GetLogEvent(LoggerName, LogLevel.Trace, exception, format, args);
            Logger.Log(typeof (NlogLoggingService), logEvent);
        }

        public override void Warn(Exception exception, string format, [CallerMemberName]string method = null,[CallerLineNumber]int line= 0,[CallerFilePath]string file=null, params object[] args)
        {
            if (!IsWarnEnabled)
            {
                return;
            }
            var logEvent = GetLogEvent(LoggerName, LogLevel.Warn, exception, format, args);
            Logger.Log(typeof (NlogLoggingService), logEvent);
        }

        public override void Debug(Exception exception)
        {
            Debug(exception, string.Empty);
        }

        public override void Error(Exception exception)
        {
            Error(exception, string.Empty);
        }

        public override void Fatal(Exception exception)
        {
            Fatal(exception, string.Empty);
        }

        public override void Info(Exception exception)
        {
            Info(exception, string.Empty);
        }

        public override void Trace(Exception exception)
        {
            Trace(exception, string.Empty);
        }

        public override void Warn(Exception exception)
        {
            Warn(exception, string.Empty);
        }


        private LogEventInfo GetLogEvent(string loggerName,
                                         LogLevel level,
                                         Exception exception,
                                         string format,
                                         object[] args)
        {
            var assemblyProp = string.Empty;
            var classProp = string.Empty;
            var methodProp = string.Empty;
            var messageProp = string.Empty;
            var innerMessageProp = string.Empty;
            
            var logEvent = new LogEventInfo
                (level, loggerName, string.Format(format, args));

            if (exception != null)
            {
                assemblyProp = exception.Source;
                classProp = exception.TargetSite?.DeclaringType?.FullName;
                methodProp = exception.TargetSite?.Name;
                messageProp = exception.Message;

                if (exception.InnerException != null)
                {
                    innerMessageProp = exception.InnerException.Message;
                }
            }

            logEvent.Properties["error-source"] = assemblyProp;
            logEvent.Properties["error-class"] = classProp;
            logEvent.Properties["error-method"] = methodProp;
            logEvent.Properties["error-message"] = messageProp;
            logEvent.Properties["inner-error-message"] = innerMessageProp;

            return logEvent;
        }


        public override void Debug(string format, [CallerMemberName]string method = null,[CallerLineNumber]int line= 0,[CallerFilePath]string file=null, params object[] args)
        {
            Logger.Debug(format, args);
        }

        public override void Error(string format, [CallerMemberName]string method = null,[CallerLineNumber]int line= 0,[CallerFilePath]string file=null, params object[] args)
        {
            Logger.Error(format, args);
        }

        public override void Fatal(string format, [CallerMemberName]string method = null,[CallerLineNumber]int line= 0,[CallerFilePath]string file=null, params object[] args)
        {
            Logger.Fatal(format, args);
        }

        public override void Info(string format, [CallerMemberName]string method = null,[CallerLineNumber]int line= 0,[CallerFilePath]string file=null, params object[] args)
        {
            Logger.Info(format, args);
        }

        public override void Trace(string format, [CallerMemberName]string method = null,[CallerLineNumber]int line= 0,[CallerFilePath]string file=null, params object[] args)
        {
            Logger.Trace(format, args);
        }

        public override void Warn(string format, [CallerMemberName]string method = null,[CallerLineNumber]int line= 0,[CallerFilePath]string file=null, params object[] args)
        {
            Logger.Warn(format, args);
        }
    }
}