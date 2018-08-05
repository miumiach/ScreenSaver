using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace ScreenSaver
{
    public class SettingsData
    {
        public bool hourElementsEnabled;
        public bool minuteElementsEnabled;
        public bool shorterHandEnabled;
        public bool longerHandEnabled;
        public bool secondsHandEnabled;
        public bool coverEnabled;

        public int hourElementsColor;
        public int minuteElementsColor;
        public int shorterHandColor;
        public int longerHandColor;
        public int secondsHandColor;
        public int coverColor;
        public int backgroundColor;
        public double screenOpacity;

        public double hourElementsLength;
        public double minuteElementsLength;
        public double shorterHandLength;
        public double longerHandLength;
        public double secondsHandLength;
        public double coverLength;

        public double hourElementsSize;
        public double minuteElementsSize;
        public double shorterHandSize;
        public double longerHandSize;
        public double secondsHandSize;

        public double hourElementsOffset;
        public double minuteElementsOffset;
        public double shorterHandOffset;
        public double longerHandOffset;
        public double secondsHandOffset;

        public string hourElementsType;
        public string minuteElementsType;
        public string shorterHandType;
        public string longerHandType;
        public string secondsHandType;
        public string coverType;
        public string backgroundType;

        public string hourElementsImgName;
        public string minuteElementsImgName;
        public string shorterHandImgName;
        public string longerHandImgName;
        public string secondsHandImgName;
        public string coverImgName;
        public string backgroundImgName;

        public bool swapElementsOrderEnabled;

        public double settingsOpacity;

        public SettingsData()
        {
            hourElementsEnabled = true;
            minuteElementsEnabled = true;
            shorterHandEnabled = true;
            longerHandEnabled = true;
            secondsHandEnabled = true;
            coverEnabled = true;

            hourElementsColor = -16711872;
            minuteElementsColor = -16744193;
            shorterHandColor = -16711872;
            longerHandColor = -16744193;
            secondsHandColor = -65536;
            coverColor = -65536;
            backgroundColor = -16777216;
            screenOpacity = 100;

            hourElementsLength = 5;
            minuteElementsLength = 3;
            shorterHandLength = 35;
            longerHandLength = 50;
            secondsHandLength = 59;
            coverLength = 5;

            hourElementsSize = 3;
            minuteElementsSize = 1.25;
            shorterHandSize = 2;
            longerHandSize = 2;
            secondsHandSize = 1;

            hourElementsOffset = 44;
            minuteElementsOffset = 44;
            shorterHandOffset = -7;
            longerHandOffset = -10;
            secondsHandOffset = -15;

            hourElementsType = "Rectangle";
            minuteElementsType = "Rectangle";
            shorterHandType = "Rectangle";
            longerHandType = "Rectangle";
            secondsHandType = "Rectangle";
            coverType = "Circle";
            backgroundType = "Solid";

            hourElementsImgName = "";
            minuteElementsImgName = "";
            shorterHandImgName = "";
            longerHandImgName = "";
            secondsHandImgName = "";
            coverImgName = "";
            backgroundImgName = "";

            swapElementsOrderEnabled = false;

            settingsOpacity = 100;
        }

    }
}
