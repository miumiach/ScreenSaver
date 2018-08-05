using System;
using System.Windows;
using System.Windows.Interop;
using System.Windows.Forms;
using System.Drawing;

namespace WaveSim
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : System.Windows.Application
    {
        // Used to host WPF content in preview mode, attach HwndSource to parent Win32 window.
        private HwndSource winWPFContent;
        private ScreenForm screenForm;

        private void Application_Startup(object sender, StartupEventArgs e)
        {
            if (e.Args[0].ToLower().StartsWith("/p"))         
            {
                Int32 previewHandle = Convert.ToInt32(e.Args[1]);
                IntPtr pPreviewHnd = new IntPtr(previewHandle);

                RECT lpRect = new RECT();
                bool bGetRect = Win32API.GetClientRect(pPreviewHnd, out lpRect);
                
                HwndSourceParameters sourceParams = new HwndSourceParameters("sourceParams");

                sourceParams.PositionX = 0;
                sourceParams.PositionY = 0;
                sourceParams.Width = lpRect.Right - lpRect.Left;
                sourceParams.Height = lpRect.Bottom - lpRect.Top;
                sourceParams.ParentWindow = pPreviewHnd;
                sourceParams.WindowStyle = (int)(WindowStyles.WS_VISIBLE | WindowStyles.WS_CHILD | WindowStyles.WS_CLIPCHILDREN);
                sourceParams.AdjustSizingForNonClientArea = false;
                

                winWPFContent = new HwndSource(sourceParams);
                winWPFContent.Disposed += new EventHandler(winWPFContent_Disposed);

                Rectangle screenBounds = new Rectangle(sourceParams.PositionX, sourceParams.PositionY, sourceParams.Width, sourceParams.Height);
                screenForm = new ScreenForm(screenBounds, true);
                screenForm.Draw();
                winWPFContent.RootVisual = screenForm.canvas;

            }

            // Normal screensaver mode.  Either screen saver kicked in normally,
            // or was launched from Preview button
            else if (e.Args[0].ToLower().StartsWith("/s"))      
            {
                ShowScreenSaver();
            }

            // Config mode, launched from Settings button in screen saver dialog
            else if (e.Args[0].ToLower().StartsWith("/c"))      
            {
                SettingsWindow settingsWindow = new SettingsWindow();
                settingsWindow.Show();
            }

            // If not running in one of the sanctioned modes, shut down the app
            // immediately (because we don't have a GUI).
            else
            {
                System.Windows.Application.Current.Shutdown();
            }
        }

        public void ShowScreenSaver()
        {
            foreach (Screen screen in Screen.AllScreens)
            {
                ScreenForm screenForm = new ScreenForm(screen.Bounds, false);
                screenForm.Draw();
                screenForm.Show();
            }
        }

        /// <summary>
        /// Event that triggers when parent window is disposed--used when doing
        /// screen saver preview, so that we know when to exit.  If we didn't 
        /// do this, Task Manager would get a new .scr instance every time
        /// we opened Screen Saver dialog or switched dropdown to this saver.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void winWPFContent_Disposed(object sender, EventArgs e)
        {
            screenForm.Close();
//            Application.Current.Shutdown();
        }
    }
}
