using log4net;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;

namespace ServiciosAplicacion.Utilidades.Loggin
{
    
    [Serializable]
    public class Logger : Ilogger
    {

        private static ILog _log;
        static Logger()
        {
            _log = LogManager.GetLogger(typeof(Logger));
            GlobalContext.Properties["host"] = Environment.MachineName;
        }
        public Logger(Type logClass)
        {
            _log = LogManager.GetLogger(logClass);
        }

        #region ILogger Members
        public void LogException(Exception exception)
        {
            if (_log.IsErrorEnabled)
                _log.Error(string.Format(CultureInfo.InvariantCulture, "{0}", exception.Message), exception);
        }
        public void LogError(string message)
        {
            if (_log.IsErrorEnabled)
                _log.Error(string.Format(CultureInfo.InvariantCulture, "{0}", message));
        }
        public void LogWarningMessage(string message)
        {
            if (_log.IsWarnEnabled)
                _log.Warn(string.Format(CultureInfo.InvariantCulture, "{0}", message));
        }
        public void LogInfoMessage(string message)
        {
            if (_log.IsInfoEnabled)
                _log.Info(string.Format(CultureInfo.InvariantCulture, "{0}", message));
        }
        #endregion
       
    }
}