using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dal.Helpers
{
    public class InfoEventArgs : EventArgs
    {
        public InfoEventArgs(string message)
        {
            Message = message;
        }
        public string Message { get; private set; }
    }
}
