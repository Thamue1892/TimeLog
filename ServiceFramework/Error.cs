using System;
using NLog;

namespace ServiceFramework
{
    public class Error
    {
        public static Logger LogFileLogger = LogManager.GetCurrentClassLogger();
        public static Logger LogMailLogger = LogManager.GetLogger("MailAlert");


        public static bool DbLoggerError(string parameters, Exception capturedError)
        {
            bool Out = true;
            LogFileLogger?.Error(capturedError, parameters);
            return Out;
        }
    }
}