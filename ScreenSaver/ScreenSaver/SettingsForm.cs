using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Xml.Serialization;

namespace ScreenSaver
{
    public partial class SettingsForm : Form
    {
        public List<System.Windows.Forms.TabPage> tabPages = new List<System.Windows.Forms.TabPage>();
        public List<ClockSettings> clockSettings = new List<ClockSettings>();

        public SettingsForm()
        {
            InitializeComponent();
            UpdateControls();
        }

        private void SettingsForm_Load(object sender, EventArgs e)
        {
            UpdateSettings();
        }

        private void multiMonitorChxBox_CheckedChanged(object sender, EventArgs e)
        {
            UpdateSettings();
        }

        public void UpdateSettings()
        {
            ClearTabs();
            if (multiMonitorChxBox.Checked)
            {
                LoadMonitors();
            }
            else
            {
                OneMonitor();
            }
        }

        public void ClearTabs()
        {
            clockSettings.Clear();
            tabControl1.Controls.Clear();
            tabPages.Clear();
        }

        public void LoadMonitors()
        {
            int index = 0;
            foreach (Screen screen in Screen.AllScreens)
            {
                ClockSettings clockSet = new ClockSettings();
                int id = clockSet.tabScreen.Controls.IndexOfKey("tbResolution");
                clockSet.tabScreen.Controls[id].Text = screen.Bounds.Width + " x " + screen.Bounds.Height;

                clockSettings.Add(clockSet);
                TabPage tabPage = new TabPage();
                tabPage.Location = new Point(4, 22);
                tabPage.Name = "tabPage" + index;
                tabPage.Padding = new Padding(3);
                tabPage.Size = new Size(435, 203);
                tabPage.TabIndex = index;
                tabPage.Text = screen.DeviceName.Replace("\\\\.\\", string.Empty);
                tabPage.UseVisualStyleBackColor = true;
                tabPage.Controls.Add(clockSettings[index]);
                tabPages.Add(tabPage);
                tabControl1.Controls.Add(tabPages[index]);
                index++;
            }
        }

        public void OneMonitor()
        {
            ClockSettings clockSet = new ClockSettings();
            clockSettings.Add(clockSet);
            TabPage tabPage = new TabPage();
            tabPage.Location = new Point(4, 22);
            tabPage.Name = "tabPage0";
            tabPage.Padding = new Padding(3);
            tabPage.Size = new Size(435, 203);
            tabPage.TabIndex = 0;
            tabPage.Text = "The same configuration for all monitors";
            tabPage.UseVisualStyleBackColor = true;
            tabPage.Controls.Add(clockSettings[0]);
            tabPages.Add(tabPage);
            tabControl1.Controls.Add(tabPages[0]);
        }

        private void trSettingsOpacity_Scroll(object sender, EventArgs e)
        {
            Settings.data.settingsOpacity = ((TrackBar)sender).Value;
            UpdateControls();
        }

        private void tbSettingsOpacity_Validated(object sender, EventArgs e)
        {
            Settings.data.settingsOpacity = Validate(ref sender, 10, 100, 100);
        }

        private double Validate(ref object o, double min, double max, double def)
        {
            try
            {
                if (Convert.ToDouble(((TextBox)o).Text) >= min && Convert.ToDouble(((TextBox)o).Text) <= max)
                {
                    return Convert.ToDouble(((TextBox)o).Text);
                }
                else
                {
                    ((TextBox)o).Text = def.ToString();
                    return def;
                }
            }
            catch (Exception ex)
            {
                ((TextBox)o).Text = def.ToString();
                return def;
            }
        }

        private void UpdateControls()
        {
            tbSettingsOpacity.Text = Settings.data.settingsOpacity.ToString();
            trSettingsOpacity.Value = (int)Settings.data.settingsOpacity;
            this.Opacity = Settings.data.settingsOpacity / 100;
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            SaveToXML();
        }

        public void SaveToXML()
        {
            try
            {
                if (!Directory.Exists(Path.GetDirectoryName(Settings.settingsFile)))
                {
                    Directory.CreateDirectory(Path.GetDirectoryName(Settings.settingsFile));
                }
                XmlSerializer serial = new XmlSerializer(typeof(SettingsData));
                FileStream fs = new FileStream(Settings.settingsFile, FileMode.Create);
                TextWriter writer = new StreamWriter(fs, new UTF8Encoding());
                SettingsData settingsData = Settings.GetCurrentConfiguration();
                serial.Serialize(writer, settingsData);
                writer.Close();
            }
            catch (Exception ex)
            {
                // log
            }
        }

    }
}
