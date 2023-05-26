using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using log4net.Config;
using log4net.Layout;

namespace lab4
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Uri configUri = new Uri("D:\\faculta\\anun2\\SEM2\\MPP\\laborator\\lab4c#\\lab4\\lab4");
            XmlConfigurator.Configure(configUri);
            //log4net.Debug("Test");
        }
    }
}
