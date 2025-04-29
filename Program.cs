using System;
using System.Windows.Forms;

namespace InventoryManagementApp
{
    static class Program
    {
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new LoginForm());

        }

        public static class Session
        {
            public static int CurrentUserId { get; set; }
            public static string CurrentUsername { get; set; } 
        }

    }
}
