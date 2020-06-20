﻿using AmazonTestFramework.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace AmazonTestFramework.Config
{
   public class Settings
    {
        public static int Timeout { get; set; }

        public static string IsReporting { get; set; }

        public static string TestType { get; set; }

        public static string AUT { get; set; }

        public static string Browser { get; set; }
        public static string BuildName { get; set; }

     

        

        public static string AppConnectionString { get; set; }

        public static string IsLog { get; set; }

        public static string LogPath { get; set; }
        public static string ScreenshotPassPath { get; set; }
        public static string ScreenshotFailPath { get; set; }

        private static bool _fileCreated = false;
        public static bool FileCreated
        {
            get
            {
                return _fileCreated;
            }
            set
            {
                _fileCreated = value;
            }
        }
    }
}
