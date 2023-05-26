using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace lab3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Uri configUri = new Uri("D:\\faculta\\anun2\\SEM2\\MPP\\laborator\\lab3c#\\lab3\\lab3\\log4net.config");
            log4net.Config.XmlConfigurator.Configure(configUri);
            logger.Debug("Test");
        }
    }
}
