using System;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using System.Drawing.Drawing2D;

namespace ScreenSaver
{
    public partial class ScreenForm : Form
    {
        #region OLD API
        [DllImport("user32.dll")]
        static extern IntPtr SetParent(IntPtr hWndChild, IntPtr hWndNewParent);

        [DllImport("user32.dll")]
        static extern int SetWindowLong(IntPtr hWnd, int nIndex, IntPtr dwNewLong);

        [DllImport("user32.dll", SetLastError = true)]
        static extern int GetWindowLong(IntPtr hWnd, int nIndex);

        [DllImport("user32.dll")]
        static extern bool GetClientRect(IntPtr hWnd, out Rectangle lpRect);
        #endregion 
        
        Graphics gf;
        Bitmap backgroundBitmap;
        Bitmap shorterHandBitmap;
        Bitmap longerHandBitmap;

        public bool previewMode = false;
        private Point mouseLocation;
        private bool transparentAllowed;

        private int seconds = -1;

        public ClockFace cf;

        private string deviceName;

        #region ScreenSaver contructors

        public ScreenForm(Rectangle screenBounds, string deviceName, bool transparentAllowed)
        {
            InitializeComponent();
            this.transparentAllowed = transparentAllowed;
            SetStyle(System.Windows.Forms.ControlStyles.SupportsTransparentBackColor, true);
            
            this.Bounds = screenBounds;
            this.deviceName = deviceName;

            this.SetStyle(
                ControlStyles.UserPaint |
                ControlStyles.AllPaintingInWmPaint |
                ControlStyles.OptimizedDoubleBuffer, true);


            backgroundBitmap = new Bitmap(Bounds.Width, Bounds.Height);
            gf = Graphics.FromImage(backgroundBitmap);

        }

        public ScreenForm(IntPtr PreviewWndHandle, bool transparentAllowed)
        {
            InitializeComponent();
            this.transparentAllowed = transparentAllowed;

            // Set the preview window as the parent of this window  
            SetParent(this.Handle, PreviewWndHandle);

            // Make this a child window so it will close when the parent dialog closes  

            // GWL_STYLE = -16, WS_CHILD = 0x40000000  
            SetWindowLong(this.Handle, -16, new IntPtr(GetWindowLong(this.Handle, -16) | 0x40000000));

            // Place our window inside the parent  
            Rectangle ParentRect;
            GetClientRect(PreviewWndHandle, out ParentRect);
            Size = ParentRect.Size;
            Location = new Point(0, 0);

            previewMode = true;

            this.SetStyle(
                ControlStyles.UserPaint |
                ControlStyles.AllPaintingInWmPaint |
                ControlStyles.OptimizedDoubleBuffer, true);

        }

        #endregion

        private void ScreenSaverForm_Load(object sender, EventArgs e)
        {
            //Cursor.Hide();

            tiktak.Interval = 10;
            tiktak.Tick += new EventHandler(tiktak_Tick);
            tiktak.Start();

            //Settings.data.LoadSettings();

            loadBackgroundImg(Settings.data.backgroundImgName);
            loadShorterHandImage(Settings.data.shorterHandImgName);
            loadLongerHandImage(Settings.data.longerHandImgName);

            cf = new ClockFace(Bounds.Width, Bounds.Height, shorterHandBitmap, longerHandBitmap); // ???
        }

        protected override void OnPaint(PaintEventArgs pe)
        {
            gf = pe.Graphics;
            //gf = this.CreateGraphics();

            gf.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;
            gf.CompositingQuality = CompositingQuality.HighQuality;
            gf.SmoothingMode = SmoothingMode.HighQuality;
            gf.PixelOffsetMode = PixelOffsetMode.HighQuality;

            BackColor = Color.FromArgb(Settings.data.backgroundColor);

            if (transparentAllowed)
            {
                Opacity = Settings.data.screenOpacity / 100;
            }

            if (Settings.data.backgroundType == "Image")
            {
                if (backgroundBitmap != null)
                {
                    this.BackgroundImageLayout = ImageLayout.Zoom;
                    this.BackgroundImage = backgroundBitmap;
                }
            }
            else
            {
                this.BackgroundImage = null;
            }

            cf.Draw(gf);

            DrawText(gf);

            base.OnPaint(pe);
        }

        private void tiktak_Tick(object sender, System.EventArgs e)
        {
            if (DateTime.Now.Second != seconds)
            {
                this.Refresh();
                seconds = DateTime.Now.Second;
            }
        }

        private void DrawText(Graphics gf)
        {
            gf.DrawString(deviceName + " " + Bounds.Width + " x " + Bounds.Height,
                          new Font(FontFamily.GenericSansSerif, Utils.PY(1.5, Bounds.Height), FontStyle.Regular),
                          new SolidBrush(Color.White), 10, 10);
        }

        #region IMAGES LOADING

        public Bitmap loadImage(string imageName)
        {
            if (imageName != String.Empty)
            {
                try
                {
                    Image image;
                    image = Image.FromFile(imageName);
                    if (image != null)
                    {
                        Bitmap result = new Bitmap(image);
                        image.Dispose();
                        return result;
                    }
                }
                catch (Exception)
                {
                    MessageBox.Show("Error during loading image " + imageName, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return null;
                }
            }
            else
            {
                return null;
            }
            return null;
        }

        public void loadBackgroundImg(string imageName)
        {
            backgroundBitmap = loadImage(imageName);
            BackgroundImage = backgroundBitmap;
        }

        public void loadShorterHandImage(string imageName)
        {
            shorterHandBitmap = loadImage(imageName);
        }

        public void loadLongerHandImage(string imageName)
        {
            longerHandBitmap = loadImage(imageName);
        }

        #endregion

        #region Event handlers

        private void ScreenSaverForm_MouseMove(object sender, MouseEventArgs e)
        {
            if (!previewMode)
            {
                if (!mouseLocation.IsEmpty)
                {
                    // Terminate if mouse is moved a significant distance
                    if (Math.Abs(mouseLocation.X - e.X) > 10 ||
                        Math.Abs(mouseLocation.Y - e.Y) > 10)
                        Application.Exit();
                }

                // Update current mouse location  
                mouseLocation = e.Location;
            }
        }

        private void ScreenSaverForm_MouseClick(object sender, MouseEventArgs e)
        {
            if (!previewMode)
            {
                Application.Exit();
            }
        }

        private void ScreenSaverForm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Modifiers == Keys.Control)
            {
                previewMode = true;
                SettingsForm settingsForm = new SettingsForm();
                settingsForm.ShowDialog();
                previewMode = false;
                Cursor.Hide();
                mouseLocation = MousePosition;

                return;
            }

            if (!previewMode)            
            {
                Application.Exit();
            }
        }

        #endregion

    }
}
