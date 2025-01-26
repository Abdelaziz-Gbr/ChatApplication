using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ChatApplicationUser
{
    internal static class Program
    {
        private static Connection connection = new Connection();
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new ChatWithUs_Client());
        }

        public static Connection GetConnection()
        {
            return connection;
        }
    }
}
