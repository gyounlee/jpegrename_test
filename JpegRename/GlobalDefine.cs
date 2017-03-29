using System;
using System.Collections.Generic;
using System.Text;

namespace JpegRename
{
    class GlobalDefine
    {
        public static string LOGDIR = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData) + "\\Log\\";
        public static string FILENAME = "JpegRename.log";
        public const string COPY_RIGHT_STR = "Copyright (c) 2007 SunnyWorld.";
        public const string EMAIL_ADDR_STR = "gyounlee@yahoo.ca";
        public const string WEB_ADDR_STR = "www.novemberstory.com";
        //public const string VER_STR = "1.1.2";
        //public const string BUILT_STR = "(July 10 2007)";
        public const string VER_STR = "1.1.4";
        public const string BUILT_STR = "(October 14 2013)";
    }
}
