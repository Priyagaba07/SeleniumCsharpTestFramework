using AmazonTestFramework.Config;
using AmazonTestFramework.Helpers;
using System;
using System.Collections.Generic;
using System.Text;

namespace AmazonTestFramework.Base
{
   public abstract class BaseStep:Base
    {
        
        protected BaseStep(DriverContext driverConfig) : base(driverConfig)
        {
           
        }

        public virtual void NavigateSite()
        {
            _driverConfig.Driver.Navigate().GoToUrl(Settings.AUT);
            _driverConfig.Driver.Manage().Window.Maximize();
            _driverConfig.Driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);

        }
    }
}
