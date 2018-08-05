using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace ScreenSaver
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main(string[] args)
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            if (args.Length > 0)
            {
                string firstArgument = args[0].ToLower().Trim();
                switch (firstArgument)
                {
                    case "/c": // Configuration mode
                        Application.Run(new SettingsForm());
                        break;
                    case "/p": // Preview mode
                        IntPtr previewWndHandle = new IntPtr(long.Parse(args[1]));
                        Application.Run(new ScreenForm(previewWndHandle, false));
                        break;
                    case "/s": // Full-screen mode
                        ShowScreenSaver();
                        Application.Run();
                        break;
                    default:
                        Application.Run(new SettingsForm());
                        break;
                }
            }
            else    // No arguments or more than one treat like /c  
            {
                Application.Run(new SettingsForm());
            }
        }

        public static void ShowScreenSaver()
        {
            foreach (Screen screen in Screen.AllScreens)
            {
                ScreenForm screenForm = new ScreenForm(screen.Bounds, screen.DeviceName, true);
                screenForm.Show();
            }
        } 

    }
}
