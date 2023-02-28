using System;
using System.Collections.Generic;
using System.Text;

namespace FSDH.Shared.LogService
{
   public interface ILogWritter
    {
        string LogWrite(string message, string type);

        string LogWarn(string message, string type);
    }
}
