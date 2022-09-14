using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppFramework.Utility.ErrorLog
{
    public interface ILogError
    {
        public void WriteTextToFile(string functionName, string message, int errorCode, string stackTrace);
    }
}