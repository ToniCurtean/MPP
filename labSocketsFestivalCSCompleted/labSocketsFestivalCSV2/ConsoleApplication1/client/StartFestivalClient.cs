using System;

using System.Windows.Forms;
using networking;
using services;

namespace client
{
    public class StartFestivalClient
    {
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            IFestivalServices server = new FestivalServerObjectProxy("127.0.0.1", 55556);
            FestivalClientCtrl ctrl = new FestivalClientCtrl(server);
            LoginWindow win = new LoginWindow(ctrl);
            Application.Run(win);
        }
    }
}