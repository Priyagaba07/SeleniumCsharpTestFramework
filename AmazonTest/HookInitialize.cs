using AmazonTestFramework.Base;
using AmazonTestFramework.Extensions;
using AventStack.ExtentReports;
using AventStack.ExtentReports.Gherkin.Model;
using AventStack.ExtentReports.Reporter;
using System;
using System.IO;
using TechTalk.SpecFlow;

namespace AmazonTest
{
    [Binding]
    public class HookInitialize : TestInitializeHook
    {

        private static ExtentTest featureName;
        private static ExtentTest scenario;
        private static ExtentReports extent;
        public new readonly DriverContext _driverConfig;
        private readonly FeatureContext _featureContext;
        private readonly ScenarioContext _scenarioContext;


        public HookInitialize(DriverContext driverConfig, FeatureContext featureContext, ScenarioContext scenarioContext) :base(driverConfig)
        {
            _driverConfig = driverConfig;
            _featureContext = featureContext;
            _scenarioContext = scenarioContext;
        }

        [BeforeTestRun]
        public static void TestStart()
        {

            var curDir = AppDomain.CurrentDomain.BaseDirectory.ToString();
            curDir = Path.GetFullPath(curDir + "../../..");
            string strFileName = curDir + "/AmazonTest/ExtenReport/ExtentReport.html";
            Console.WriteLine(strFileName);
            var htmlReporter = new ExtentHtmlReporter(strFileName);
           // htmlReporter.LoadConfig.Theme = AventStack.ExtentReports.Reporter.Configuration.Theme.Dark;
            extent = new ExtentReports();
            extent.AttachReporter(htmlReporter);
           
        }

        [AfterTestRun]
      public  static void TearDownReport()
        {
            extent.Flush();
            
        }

        /*[BeforeFeature]
        public  static void Beforefeature()
        {
            
            featureName = extent.CreateTest<Feature>(_featureContext.FeatureInfo.Title);
        }*/

        [AfterStep]
        public void InsertTestingSteps()
        {
            var stepName = _scenarioContext.StepContext.StepInfo.Text;
            var featureName = _featureContext.FeatureInfo.Title;
            var scenarioName = _scenarioContext.ScenarioInfo.Title;

          

            var stepType = _scenarioContext.StepContext.StepInfo.StepDefinitionType.ToString();

            if (_scenarioContext.TestError == null)
            {
                if (stepType == "Given")
                {
                    string path = WebElementExtensions.CapturePassScreenshot(_driverConfig.Driver, stepName);
                    scenario.CreateNode<Given>(_scenarioContext.StepContext.StepInfo.Text).AddScreenCaptureFromPath(WebElementExtensions.CapturePassScreenshot(_driverConfig.Driver, stepName));
                    scenario.AddScreenCaptureFromPath(path);
                    Console.WriteLine(scenario);
                }

                else if (stepType == "When")
                    scenario.CreateNode<When>(_scenarioContext.StepContext.StepInfo.Text);
                else if (stepType == "Then")
                    scenario.CreateNode<Then>(_scenarioContext.StepContext.StepInfo.Text);
                else if (stepType == "And")
                    scenario.CreateNode<And>(_scenarioContext.StepContext.StepInfo.Text);
            }
            else if (_scenarioContext.TestError != null)
            {
                if (stepType == "Given")
                    scenario.CreateNode<Given>(_scenarioContext.StepContext.StepInfo.Text).Fail(_scenarioContext.TestError.InnerException);
                
                else if (stepType == "When")
                    scenario.CreateNode<When>(_scenarioContext.StepContext.StepInfo.Text).Fail(_scenarioContext.TestError.InnerException);
                else if (stepType == "Then")
                    scenario.CreateNode<Then>(_scenarioContext.StepContext.StepInfo.Text).Fail(_scenarioContext.TestError.Message).AddScreenCaptureFromPath(WebElementExtensions.CaptureFailedScreenshot(_driverConfig.Driver, stepName));
            }
        }

    

        [BeforeScenario]
        public void BeforeSceanrio()
        {
            InitializeSetting();

            //Get feature Name
            featureName = extent.CreateTest<Feature>(_featureContext.FeatureInfo.Title);

            //Create dynamic scenario name
            scenario = featureName.CreateNode<Scenario>(_scenarioContext.ScenarioInfo.Title);
        }


        [AfterScenario]
        public void AfterSceanrio()
        {
            // DriverContext.Driver.Quit();
            _driverConfig.Driver.Quit();
        }





    }
}
