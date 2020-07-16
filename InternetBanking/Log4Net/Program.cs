using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Log4Net
{
    class Program
    {
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        static void Main(string[] args)
        {

            log.Info("Esto es un mensaje de informacion");
            log.Error("Esto es un mensaje de error");
            log.Debug("Esto es un mensaje de Debug");
            Console.ReadKey();


        }
    }
}
