using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Drawing;
using Microsoft.Win32;
using System.Xml.Serialization;

namespace ScreenSaver
{
    public static class Settings
    {
        public const string settingsFile = @"C:\Program Files\ScreenSaver\Settings.xml";
        public static SettingsData data = new SettingsData();
        public static SettingsData defaults = new SettingsData();

        static Settings()
        {
            LoadFromXML();
        }

        public static void LoadDefaults()
        {
            data.hourElementsEnabled = defaults.hourElementsEnabled;
            data.minuteElementsEnabled = defaults.minuteElementsEnabled;
            data.shorterHandEnabled = defaults.shorterHandEnabled;
            data.longerHandEnabled = defaults.longerHandEnabled;
            data.secondsHandEnabled = defaults.secondsHandEnabled;
            data.coverEnabled = defaults.coverEnabled;

            data.hourElementsColor = defaults.hourElementsColor;
            data.minuteElementsColor = defaults.minuteElementsColor;
            data.shorterHandColor = defaults.shorterHandColor;
            data.longerHandColor = defaults.longerHandColor;
            data.secondsHandColor = defaults.secondsHandColor;
            data.coverColor = defaults.coverColor;
            data.backgroundColor = defaults.backgroundColor;
            data.screenOpacity = defaults.screenOpacity;
            data.settingsOpacity = defaults.settingsOpacity;

            data.hourElementsLength = defaults.hourElementsLength;
            data.minuteElementsLength = defaults.minuteElementsLength;
            data.shorterHandLength = defaults.shorterHandLength;
            data.longerHandLength = defaults.longerHandLength;
            data.secondsHandLength = defaults.secondsHandLength;
            data.coverLength = defaults.coverLength;

            data.hourElementsSize = defaults.hourElementsSize;
            data.minuteElementsSize = defaults.minuteElementsSize;
            data.shorterHandSize = defaults.shorterHandSize;
            data.longerHandSize = defaults.longerHandSize;
            data.secondsHandSize = defaults.secondsHandSize;

            data.hourElementsOffset = defaults.hourElementsOffset;
            data.minuteElementsOffset = defaults.minuteElementsOffset;
            data.shorterHandOffset = defaults.shorterHandOffset;
            data.longerHandOffset = defaults.longerHandOffset;
            data.secondsHandOffset = defaults.secondsHandOffset;

            data.hourElementsType = defaults.hourElementsType;
            data.minuteElementsType = defaults.minuteElementsType;
            data.shorterHandType = defaults.shorterHandType;
            data.longerHandType = defaults.longerHandType;
            data.secondsHandType = defaults.secondsHandType;
            data.coverType = defaults.coverType;
            data.backgroundType = defaults.backgroundType;

            data.hourElementsImgName = defaults.hourElementsImgName;
            data.minuteElementsImgName = defaults.minuteElementsImgName;
            data.shorterHandImgName = defaults.shorterHandImgName;
            data.longerHandImgName = defaults.longerHandImgName;
            data.secondsHandImgName = defaults.secondsHandImgName;
            data.coverImgName = defaults.coverImgName;
            data.backgroundImgName = defaults.backgroundImgName;

            data.swapElementsOrderEnabled = defaults.swapElementsOrderEnabled;
        }

        public static void LoadFromXML()
        {
            SettingsData settingsData = null;
            try
            {
                if (File.Exists(Settings.settingsFile))
                {
                    FileStream fs = new FileStream(Settings.settingsFile, FileMode.OpenOrCreate);
                    TextReader reader = new StreamReader(fs);
                    XmlSerializer xmlSerializer = new XmlSerializer(typeof(SettingsData));
                    settingsData = (SettingsData)xmlSerializer.Deserialize(reader);
                    reader.Close();
                    Settings.LoadConfiguration(settingsData);
                }
                else
                {
                    // Log
                }
            }
            catch (Exception ex)
            {
                // log
            }
        }

        public static void LoadConfiguration(SettingsData settingsData)
        {
            Settings.data.hourElementsEnabled = settingsData.hourElementsEnabled;
            Settings.data.minuteElementsEnabled = settingsData.minuteElementsEnabled;
            Settings.data.shorterHandEnabled = settingsData.shorterHandEnabled;
            Settings.data.longerHandEnabled = settingsData.longerHandEnabled;
            Settings.data.secondsHandEnabled = settingsData.secondsHandEnabled;
            Settings.data.coverEnabled = settingsData.coverEnabled;

            Settings.data.hourElementsColor = settingsData.hourElementsColor;
            Settings.data.minuteElementsColor = settingsData.minuteElementsColor;
            Settings.data.shorterHandColor = settingsData.shorterHandColor;
            Settings.data.longerHandColor = settingsData.longerHandColor;
            Settings.data.secondsHandColor = settingsData.secondsHandColor;
            Settings.data.coverColor = settingsData.coverColor;
            Settings.data.backgroundColor = settingsData.backgroundColor;
            Settings.data.screenOpacity = settingsData.screenOpacity;
            Settings.data.settingsOpacity = settingsData.settingsOpacity;

            Settings.data.hourElementsLength = settingsData.hourElementsLength;
            Settings.data.minuteElementsLength = settingsData.minuteElementsLength;
            Settings.data.shorterHandLength = settingsData.shorterHandLength;
            Settings.data.longerHandLength = settingsData.longerHandLength;
            Settings.data.secondsHandLength = settingsData.secondsHandLength;
            Settings.data.coverLength = settingsData.coverLength;

            Settings.data.hourElementsSize = settingsData.hourElementsSize;
            Settings.data.minuteElementsSize = settingsData.minuteElementsSize;
            Settings.data.shorterHandSize = settingsData.shorterHandSize;
            Settings.data.longerHandSize = settingsData.longerHandSize;
            Settings.data.secondsHandSize = settingsData.secondsHandSize;

            Settings.data.hourElementsOffset = settingsData.hourElementsOffset;
            Settings.data.minuteElementsOffset = settingsData.minuteElementsOffset;
            Settings.data.shorterHandOffset = settingsData.shorterHandOffset;
            Settings.data.longerHandOffset = settingsData.longerHandOffset;
            Settings.data.secondsHandOffset = settingsData.secondsHandOffset;

            Settings.data.hourElementsType = settingsData.hourElementsType;
            Settings.data.minuteElementsType = settingsData.minuteElementsType;
            Settings.data.shorterHandType = settingsData.shorterHandType;
            Settings.data.longerHandType = settingsData.longerHandType;
            Settings.data.secondsHandType = settingsData.secondsHandType;
            Settings.data.coverType = settingsData.coverType;
            Settings.data.backgroundType = settingsData.backgroundType;

            Settings.data.hourElementsImgName = settingsData.hourElementsImgName;
            Settings.data.minuteElementsImgName = settingsData.minuteElementsImgName;
            Settings.data.shorterHandImgName = settingsData.shorterHandImgName;
            Settings.data.longerHandImgName = settingsData.longerHandImgName;
            Settings.data.secondsHandImgName = settingsData.secondsHandImgName;
            Settings.data.coverImgName = settingsData.coverImgName;
            Settings.data.backgroundImgName = settingsData.backgroundImgName;

            Settings.data.swapElementsOrderEnabled = settingsData.swapElementsOrderEnabled;
        }

        public static SettingsData GetCurrentConfiguration()
        {
            SettingsData settingsData = new SettingsData();

            settingsData.hourElementsEnabled = Settings.data.hourElementsEnabled;
            settingsData.minuteElementsEnabled = Settings.data.minuteElementsEnabled;
            settingsData.shorterHandEnabled = Settings.data.shorterHandEnabled;
            settingsData.longerHandEnabled = Settings.data.longerHandEnabled;
            settingsData.secondsHandEnabled = Settings.data.secondsHandEnabled;
            settingsData.coverEnabled = Settings.data.coverEnabled;

            settingsData.hourElementsColor = Settings.data.hourElementsColor;
            settingsData.minuteElementsColor = Settings.data.minuteElementsColor;
            settingsData.shorterHandColor = Settings.data.shorterHandColor;
            settingsData.longerHandColor = Settings.data.longerHandColor;
            settingsData.secondsHandColor = Settings.data.secondsHandColor;
            settingsData.coverColor = Settings.data.coverColor;
            settingsData.backgroundColor = Settings.data.backgroundColor;
            settingsData.screenOpacity = Settings.data.screenOpacity;
            settingsData.settingsOpacity = Settings.data.settingsOpacity;

            settingsData.hourElementsLength = Settings.data.hourElementsLength;
            settingsData.minuteElementsLength = Settings.data.minuteElementsLength;
            settingsData.shorterHandLength = Settings.data.shorterHandLength;
            settingsData.longerHandLength = Settings.data.longerHandLength;
            settingsData.secondsHandLength = Settings.data.secondsHandLength;
            settingsData.coverLength = Settings.data.coverLength;

            settingsData.hourElementsSize = Settings.data.hourElementsSize;
            settingsData.minuteElementsSize = Settings.data.minuteElementsSize;
            settingsData.shorterHandSize = Settings.data.shorterHandSize;
            settingsData.longerHandSize = Settings.data.longerHandSize;
            settingsData.secondsHandSize = Settings.data.secondsHandSize;

            settingsData.hourElementsOffset = Settings.data.hourElementsOffset;
            settingsData.minuteElementsOffset = Settings.data.minuteElementsOffset;
            settingsData.shorterHandOffset = Settings.data.shorterHandOffset;
            settingsData.longerHandOffset = Settings.data.longerHandOffset;
            settingsData.secondsHandOffset = Settings.data.secondsHandOffset;

            settingsData.hourElementsType = Settings.data.hourElementsType;
            settingsData.minuteElementsType = Settings.data.minuteElementsType;
            settingsData.shorterHandType = Settings.data.shorterHandType;
            settingsData.longerHandType = Settings.data.longerHandType;
            settingsData.secondsHandType = Settings.data.secondsHandType;
            settingsData.coverType = Settings.data.coverType;
            settingsData.backgroundType = Settings.data.backgroundType;

            settingsData.hourElementsImgName = Settings.data.hourElementsImgName;
            settingsData.minuteElementsImgName = Settings.data.minuteElementsImgName;
            settingsData.shorterHandImgName = Settings.data.shorterHandImgName;
            settingsData.longerHandImgName = Settings.data.longerHandImgName;
            settingsData.secondsHandImgName = Settings.data.secondsHandImgName;
            settingsData.coverImgName = Settings.data.coverImgName;
            settingsData.backgroundImgName = Settings.data.backgroundImgName;

            settingsData.swapElementsOrderEnabled = Settings.data.swapElementsOrderEnabled;

            return settingsData;
        }

    }
}

