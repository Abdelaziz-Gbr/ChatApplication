using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ChatApplication
{
    internal static class Program
    {
        static private Server server;
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new ChatApplication_Server());
        }

        public static Server GetServer() 
        {
            if(server == null)
                server = new Server();
            return server;
        }
    }
}
