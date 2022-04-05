using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ServiciosAplicacion.Utilidades.Loggin
{
    public interface Ilogger
    {
        void LogException(Exception exception);
        void LogError(string message);
        void LogWarningMessage(string message);
        void LogInfoMessage(string message);
    }
}