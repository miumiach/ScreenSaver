using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Media3D;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;
using System.Drawing;

namespace WaveSim
{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class ScreenForm : Window
    {
        private bool previewMode;
        // Raindrop parameters, from .xml settings file
        private RaindropSettings _settings;
        
        public ScreenForm(System.Drawing.Rectangle screenBounds, bool previewMode)
        {
            InitializeComponent();
            this.previewMode = previewMode;

            // ShowInTaskbar="False" ResizeMode="NoResize" WindowStyle="None"

            this.WindowStyle = WindowStyle.None;
            this.ResizeMode = ResizeMode.NoResize;
            this.ShowInTaskbar = false;
            this.Topmost = true;

            this.Left = screenBounds.X;
            this.Top = screenBounds.Y;
            this.Width = screenBounds.Width;
            this.Height = screenBounds.Height;            
            

            // Read in settings from .xml file
            _settings = RaindropSettings.Load(RaindropSettings.SettingsFile);
        }

        public void Draw()
        {
            // Create a red Ellipse.
            Ellipse myEllipse = new Ellipse();
            SolidColorBrush mySolidColorBrush = new SolidColorBrush();
            mySolidColorBrush.Color = System.Windows.Media.Color.FromArgb(255, 255, 255, 0);
            myEllipse.Fill = mySolidColorBrush;
            myEllipse.StrokeThickness = 2;
            myEllipse.Stroke = System.Windows.Media.Brushes.Black;
            if (!previewMode)
            {
                myEllipse.Width = this.Width;
                myEllipse.Height = this.Height;
            }
            else
            {
                myEllipse.Width = this.Width - 38;
                myEllipse.Height = this.Height - 28;
            }
            canvas.Children.Add(myEllipse);
        }

        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void Window_KeyDown(object sender, KeyEventArgs e)
        {
            Application.Current.Shutdown();
        }
    }
}
