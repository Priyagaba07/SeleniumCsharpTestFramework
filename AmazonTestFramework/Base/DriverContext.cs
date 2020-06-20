using OpenQA.Selenium;
using OpenQA.Selenium.Remote;
using System;
using System.Collections.Generic;
using System.Text;

namespace AmazonTestFramework.Base
{
    public class DriverContext
    {

        public RemoteWebDriver Driver { get; set; }
        public BasePage CurrentPage { get; set; }
/*
        public readonly ParallelConfig _parallelConfig;

        public DriverContext(ParallelConfig parallelConfig)
        {
            _parallelConfig = parallelConfig;
        }*/
        /*private static IWebDriver _driver;
        public static IWebDriver Driver
        {
            get
            {
                return _driver;
            }
            set
            {
                _driver = value;
            }
        }*/
        // public static Browser Browser { get; set; }
    }
}
