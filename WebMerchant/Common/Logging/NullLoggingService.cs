using System;
using WebMerchant.InternetAcquiring.Contracts.Logging;

namespace WebMerchant.InternetAcquiring.Concrete.Logging
{
    public class NullLoggingService : LoggingService
    {
        public override bool IsDebugEnabled { get; } = false;
        public override bool IsErrorEnabled { get; } = false;
        public override bool IsFatalEnabled { get; } = false;
        public override bool IsInfoEnabled { get; } = false;
        public override bool IsTraceEnabled { get; } = false;
        public override bool IsWarnEnabled { get; } = false;

        public override void Debug(Exception exception) { }

        public override void Debug(string format,
                                   string method = null,
                                   int line = 0,
                                   string file = null,
                                   params object[] args) { }

        public override void Debug(Exception exception,
                                   string format,
                                   string method = null,
                                   int line = 0,
                                   string file = null,
                                   params object[] args) { }

        public override void Error(Exception exception) { }

        public override void Error(string format,
                                   string method = null,
                                   int line = 0,
                                   string file = null,
                                   params object[] args) { }

        public override void Error(Exception exception,
                                   string format,
                                   string method = null,
                                   int line = 0,
                                   string file = null,
                                   params object[] args) { }

        public override void Fatal(Exception exception) { }

        public override void Fatal(string format,
                                   string method = null,
                                   int line = 0,
                                   string file = null,
                                   params object[] args) { }

        public override void Fatal(Exception exception,
                                   string format,
                                   string method = null,
                                   int line = 0,
                                   string file = null,
                                   params object[] args) { }

        public override void Info(Exception exception) { }

        public override void Info(string format,
                                  string method = null,
                                  int line = 0,
                                  string file = null,
                                  params object[] args) { }

        public override void Info(Exception exception,
                                  string format,
                                  string method = null,
                                  int line = 0,
                                  string file = null,
                                  params object[] args) { }

        public override void Trace(Exception exception) { }

        public override void Trace(string format,
                                   string method = null,
                                   int line = 0,
                                   string file = null,
                                   params object[] args) { }

        public override void Trace(Exception exception,
                                   string format,
                                   string method = null,
                                   int line = 0,
                                   string file = null,
                                   params object[] args) { }

        public override void Warn(Exception exception) { }

        public override void Warn(string format,
                                  string method = null,
                                  int line = 0,
                                  string file = null,
                                  params object[] args) { }

        public override void Warn(Exception exception,
                                  string format,
                                  string method = null,
                                  int line = 0,
                                  string file = null,
                                  params object[] args) { }
    }
}