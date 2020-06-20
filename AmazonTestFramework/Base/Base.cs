using System;
using System.Collections.Generic;
using System.Text;
using TechTalk.SpecFlow;

namespace AmazonTestFramework.Base
{
    public class Base
    {

        public readonly DriverContext _driverConfig;

        public Base (DriverContext driverConfig)
        {
            _driverConfig = driverConfig;
        }
        
        /*public BasePage CurrentPage {
            get
            {
                return (BasePage)ScenarioContext.Current["currentPage"];
            }
            set
            {
                ScenarioContext.Current["currentPage"] = value;
            }
        
        }*/

        protected TPage GetInstance<TPage>() where TPage : BasePage, new()
        {
            return (TPage)Activator.CreateInstance(typeof(TPage));
        }

        public TPage As<TPage>() where TPage : BasePage
        {
            return (TPage)this;
        }

    }
}
