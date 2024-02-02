using System;
using System.Drawing;
using System.Windows.Forms;

namespace ScreenSaver
{
    public partial class ClockSettings : UserControl
    {
        public ScreenForm sf;

        public ClockSettings()
        {
            InitializeComponent();
            SetStyle(ControlStyles.SupportsTransparentBackColor, true);
            UpdateControls();
            Cursor.Show();
        }

        public ClockSettings(ScreenForm sf)
        {
            InitializeComponent();
            SetStyle(ControlStyles.SupportsTransparentBackColor, true);
            UpdateControls();
            Cursor.Show();
            this.sf = sf;
        }

        private void UpdateControls()
        {
            cbHourElements.Checked = Settings.data.hourElementsEnabled;
            cbMinuteElements.Checked = Settings.data.minuteElementsEnabled;
            cbShorterHand.Checked = Settings.data.shorterHandEnabled;
            cbLongerHand.Checked = Settings.data.longerHandEnabled;
            cbSecondsHand.Checked = Settings.data.secondsHandEnabled;
            cbCover.Checked = Settings.data.coverEnabled;

            button1.BackColor = Color.FromArgb(Settings.data.hourElementsColor);
            button6.BackColor = Color.FromArgb(Settings.data.minuteElementsColor);
            button3.BackColor = Color.FromArgb(Settings.data.shorterHandColor);
            button4.BackColor = Color.FromArgb(Settings.data.longerHandColor);
            button5.BackColor = Color.FromArgb(Settings.data.secondsHandColor);
            button7.BackColor = Color.FromArgb(Settings.data.coverColor);
            button2.BackColor = Color.FromArgb(Settings.data.backgroundColor);
            tbScreenOpacity.Text = Settings.data.screenOpacity.ToString();

            tbHourElementsOffset.Text = Settings.data.hourElementsOffset.ToString();
            tbMinuteElementsOffset.Text = Settings.data.minuteElementsOffset.ToString();
            tbShorterHandOffset.Text = Settings.data.shorterHandOffset.ToString();
            tbLongerHandOffset.Text = Settings.data.longerHandOffset.ToString();
            tbSecondsHandOffset.Text = Settings.data.secondsHandOffset.ToString();

            tbHourElementsLen.Text = Settings.data.hourElementsLength.ToString();
            tbMinuteElementsLen.Text = Settings.data.minuteElementsLength.ToString();
            tbShorterHandLen.Text = Settings.data.shorterHandLength.ToString();
            tbLongerHandLen.Text = Settings.data.longerHandLength.ToString();
            tbSecondsHandLen.Text = Settings.data.secondsHandLength.ToString();

            tbHourElementsSize.Text = Settings.data.hourElementsSize.ToString();
            tbMinuteElementsSize.Text = Settings.data.minuteElementsSize.ToString();
            tbShorterHandSize.Text = Settings.data.shorterHandSize.ToString();
            tbLongerHandSize.Text = Settings.data.longerHandSize.ToString();
            tbSecondsHandSize.Text = Settings.data.secondsHandSize.ToString();
            tbCoverLength.Text = Settings.data.coverLength.ToString();

            cmbHourElementsType.SelectedItem = Settings.data.hourElementsType;
            cmbMinuteElementsType.SelectedItem = Settings.data.minuteElementsType;
            cmbShorterHandType.SelectedItem = Settings.data.shorterHandType;
            cmbLongerHandType.SelectedItem = Settings.data.longerHandType;
            cmbSecondsHandType.SelectedItem = Settings.data.secondsHandType;
            cmbCoverType.SelectedItem = Settings.data.coverType;
            cmbBackgroundType.SelectedItem = Settings.data.backgroundType;

            tbHourElementsImg.Text = Settings.data.hourElementsImgName;
            tbShorterHandImg.Text = Settings.data.shorterHandImgName;
            tbLongerHandImg.Text = Settings.data.longerHandImgName;
            tbMinuteElementsImg.Text = Settings.data.minuteElementsImgName;
            tbSecondsHandImg.Text = Settings.data.secondsHandImgName;
            tbCoverImg.Text = Settings.data.coverImgName;
            tbBackgroundImg.Text = Settings.data.backgroundImgName;

            tbScreenOpacity.Text = Settings.data.screenOpacity.ToString();
            trScreenOpacity.Value = (int)Settings.data.screenOpacity;

            cbSwapElementsOrder.Checked = Settings.data.swapElementsOrderEnabled;

            // CONTROLS' LOGIC

            if (Settings.data.hourElementsType == "Circle")
            {
                tbHourElementsSize.Enabled = false;
                tbHourElementsSize.Text = "";
            }
            else
            {
                tbHourElementsSize.Enabled = true;
            }

            if (Settings.data.minuteElementsType == "Circle")
            {
                tbMinuteElementsSize.Enabled = false;
                tbMinuteElementsSize.Text = "";
            }
            else
            {
                tbMinuteElementsSize.Enabled = true;
            }


            if (Settings.data.backgroundType == "Solid")
            {
                btnBackgroundImg.Enabled = false;
                tbBackgroundImg.Enabled = false;
                tbBackgroundImg.Text = "";
            }
            else
            {
                btnBackgroundImg.Enabled = true;
                tbBackgroundImg.Enabled = true;
            }
        }

        #region VALIDATE METHODS

        private double Validate(ref object o)
        {
            try
            {
                return Convert.ToDouble(((TextBox)o).Text);
            }
            catch (Exception ex)
            {
                ((TextBox)o).Text = "0";
                return 0;
            }
        }

        #endregion

        #region EVENTS

        private void cbHourElements_CheckedChanged(object sender, EventArgs e)
        {
            Settings.data.hourElementsEnabled = ((CheckBox)(sender)).Checked;
        }

        private void cbMinuteElements_CheckedChanged(object sender, EventArgs e)
        {
            Settings.data.minuteElementsEnabled = ((CheckBox)(sender)).Checked;
        }

        private void cbShorterHand_CheckedChanged(object sender, EventArgs e)
        {
            Settings.data.shorterHandEnabled = ((CheckBox)(sender)).Checked;
        }

        private void cbLongerHand_CheckedChanged(object sender, EventArgs e)
        {
            Settings.data.longerHandEnabled = ((CheckBox)(sender)).Checked;
        }

        private void cbSecondsHand_CheckedChanged(object sender, EventArgs e)
        {
            Settings.data.secondsHandEnabled = ((CheckBox)(sender)).Checked;
        }

        private void cbCover_CheckedChanged(object sender, EventArgs e)
        {
            Settings.data.coverEnabled = ((CheckBox)(sender)).Checked;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (colorDialog1.ShowDialog() == DialogResult.OK)
            {
                Settings.data.hourElementsColor = colorDialog1.Color.ToArgb();
                ((Button)sender).BackColor = colorDialog1.Color;
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            if (colorDialog1.ShowDialog() == DialogResult.OK)
            {
                Settings.data.minuteElementsColor = colorDialog1.Color.ToArgb();
                ((Button)sender).BackColor = colorDialog1.Color;
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (colorDialog1.ShowDialog() == DialogResult.OK)
            {
                Settings.data.shorterHandColor = colorDialog1.Color.ToArgb();
                ((Button)sender).BackColor = colorDialog1.Color;
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (colorDialog1.ShowDialog() == DialogResult.OK)
            {
                Settings.data.longerHandColor = colorDialog1.Color.ToArgb();
                ((Button)sender).BackColor = colorDialog1.Color;
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (colorDialog1.ShowDialog() == DialogResult.OK)
            {
                Settings.data.secondsHandColor = colorDialog1.Color.ToArgb();
                ((Button)sender).BackColor = colorDialog1.Color;
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            if (colorDialog1.ShowDialog() == DialogResult.OK)
            {
                Settings.data.coverColor = colorDialog1.Color.ToArgb();
                ((Button)sender).BackColor = colorDialog1.Color;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (colorDialog1.ShowDialog() == DialogResult.OK)
            {
                Settings.data.backgroundColor = colorDialog1.Color.ToArgb();
                ((Button)sender).BackColor = colorDialog1.Color;
            }
        }

        private void tbScreenOpacity_Validated(object sender, EventArgs e)
        {
            Settings.data.screenOpacity = Validate(ref sender, 10, 100, 100);
            UpdateControls();
        }

        private void tbHourElementsLen_Validated(object sender, EventArgs e)
        {
            Settings.data.hourElementsLength = Validate(ref sender);
        }

        private void tbMinuteElementsLen_Validated(object sender, EventArgs e)
        {
            Settings.data.minuteElementsLength = Validate(ref sender);
        }

        private void tbShorterHandLen_Validated(object sender, EventArgs e)
        {
            Settings.data.shorterHandLength = Validate(ref sender);
        }

        private void tbLongerHandLen_Validated(object sender, EventArgs e)
        {
            Settings.data.longerHandLength = Validate(ref sender);
        }

        private void tbSecondsHandLen_Validated(object sender, EventArgs e)
        {
            Settings.data.secondsHandLength = Validate(ref sender);
        }

        private void tbCoverLength_Validated(object sender, EventArgs e)
        {
            Settings.data.coverLength = Validate(ref sender);
        }

        private void tbHourElementsOffset_Validated(object sender, EventArgs e)
        {
            Settings.data.hourElementsOffset = Validate(ref sender);
        }

        private void tbMinuteElementsOffset_Validated(object sender, EventArgs e)
        {
            Settings.data.minuteElementsOffset = Validate(ref sender);
        }

        private void tbShorterHandOffset_Validated(object sender, EventArgs e)
        {
            Settings.data.shorterHandOffset = Validate(ref sender);
        }

        private void tbLongerHandOffset_Validated(object sender, EventArgs e)
        {
            Settings.data.longerHandOffset = Validate(ref sender);
        }

        private void tbSecondsHandOffset_Validated(object sender, EventArgs e)
        {
            Settings.data.secondsHandOffset = Validate(ref sender);
        }

        private void tbHourElementsSize_Validated(object sender, EventArgs e)
        {
            Settings.data.hourElementsSize = Validate(ref sender);
        }

        private void tbMinuteElementsSize_Validated(object sender, EventArgs e)
        {
            Settings.data.minuteElementsSize = Validate(ref sender);
        }

        private void tbShorterHandSize_Validated(object sender, EventArgs e)
        {
            Settings.data.shorterHandSize = Validate(ref sender);
        }

        private void tbLongerHandSize_Validated(object sender, EventArgs e)
        {
            Settings.data.longerHandSize = Validate(ref sender);
        }

        private void tbSecondsHandSize_Validated(object sender, EventArgs e)
        {
            Settings.data.secondsHandSize = Validate(ref sender);
        }

        private void cmbHourElementsType_SelectedIndexChanged(object sender, EventArgs e)
        {
            Settings.data.hourElementsType = (string)((ComboBox)sender).SelectedItem;
            UpdateControls();
        }

        private void cmbMinuteElementsType_SelectedIndexChanged(object sender, EventArgs e)
        {
            Settings.data.minuteElementsType = (string)((ComboBox)sender).SelectedItem;
            UpdateControls();
        }

        private void cmbShorterHandType_SelectedIndexChanged(object sender, EventArgs e)
        {
            Settings.data.shorterHandType = (string)((ComboBox)sender).SelectedItem;
            UpdateControls();
        }

        private void cmbLongerHandType_SelectedIndexChanged(object sender, EventArgs e)
        {
            Settings.data.longerHandType = (string)((ComboBox)sender).SelectedItem;
            UpdateControls();
        }

        private void cmbBackgroundType_SelectedIndexChanged(object sender, EventArgs e)
        {
            Settings.data.backgroundType = (string)((ComboBox)sender).SelectedItem;
            UpdateControls();
        }

        private void cbSwapElementsOrder_CheckedChanged(object sender, EventArgs e)
        {
            Settings.data.swapElementsOrderEnabled = ((CheckBox)(sender)).Checked;
        }

        #endregion

        private void btnBackgroundImg_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() != DialogResult.Cancel)
            {
                if (openFileDialog1.FileName != null && openFileDialog1.FileName != String.Empty)
                {
                    Settings.data.backgroundImgName = openFileDialog1.FileName;
                    UpdateControls();
                    sf.loadBackgroundImg(Settings.data.backgroundImgName);
                }
            }
        }

        private void tbBackgroundImg_Validated(object sender, EventArgs e)
        {
            Settings.data.backgroundImgName = ((TextBox)sender).Text;
            sf.loadBackgroundImg(Settings.data.backgroundImgName);
        }

        private void btnShorterHandImg_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() != DialogResult.Cancel)
            {
                if (openFileDialog1.FileName != null && openFileDialog1.FileName != String.Empty)
                {
                    Settings.data.shorterHandImgName = openFileDialog1.FileName;
                    UpdateControls();
                    sf.loadShorterHandImage(Settings.data.shorterHandImgName);
                }
            }
        }

        private void tbShorterHandImg_Validated(object sender, EventArgs e)
        {
            Settings.data.shorterHandImgName = ((TextBox)sender).Text;
            sf.loadShorterHandImage(Settings.data.shorterHandImgName);
        }

        private void btnLongerHandImg_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() != DialogResult.Cancel)
            {
                if (openFileDialog1.FileName != null && openFileDialog1.FileName != String.Empty)
                {
                    Settings.data.longerHandImgName = openFileDialog1.FileName;
                    UpdateControls();
                    sf.loadLongerHandImage(Settings.data.longerHandImgName);
                }
            }
        }

        private void tbLongerHandImg_Validated(object sender, EventArgs e)
        {
            Settings.data.longerHandImgName = ((TextBox)sender).Text;
            sf.loadLongerHandImage(Settings.data.longerHandImgName);
        }

        private void trScreenOpacity_Scroll(object sender, EventArgs e)
        {
            Settings.data.screenOpacity = ((TrackBar)sender).Value;
            UpdateControls();
        }

        private void trSettingsOpacity_Scroll(object sender, EventArgs e)
        {
            Settings.data.settingsOpacity = ((TrackBar)sender).Value;
            UpdateControls();
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

    }

}
