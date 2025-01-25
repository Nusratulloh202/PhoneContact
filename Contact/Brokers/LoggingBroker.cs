using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contact.Brokers
{
    internal class LoggingBroker
    {
        public static void LogError(string message)
        {
            Console.WriteLine($"[XATO]:{message}");
        }
    }
}
