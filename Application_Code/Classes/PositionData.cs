using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Application_Code
{
    public class PositionData
    {
        private string file;
        private string daySession;
        private string timeSession;
        private string line1;
        private string line2;
        private string line3;
        private string line4;
        private string line5;
        private string link;


        public string File
        {
            get { return file; }
            set { file = value; }
        }

        public string DaySession
        {
            get { return daySession; }
            set { daySession = value; }
        }

        public string TimeSession
        {
            get { return timeSession; }
            set { timeSession = value; }
        }

        public string Line1
        {
            get { return line1; }
            set { line1 = value; }
        }

        public string Line2
        {
            get { return line2; }
            set { line2 = value; }
        }

        public string Line3
        {
            get { return line3; }
            set { line3 = value; }
        }

        public string Line4
        {
            get { return line4; }
            set { line4 = value; }
        }
        public string Line5
        {
            get { return line5; }
            set { line5 = value; }
        }

        public string Link
        {
            get { return link; }
            set { link = value; }
        }
    }
}