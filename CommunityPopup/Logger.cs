using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommunityPopup
{
    public static class Logger
    {
        public static void WriteLine(string message)
        {
#if WINDOWS
            Debug.WriteLine(message);
#else
            Console.WriteLine(message);
#endif
        }
    }
}
