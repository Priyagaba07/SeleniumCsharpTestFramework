using AmazonTest.Pages;
using AmazonTestFramework.Base;
using AmazonTestFramework.Extensions;
using TechTalk.SpecFlow;

namespace AmazonTest.Steps
{
[Binding]
    public class SearchBookFilterSteps :BaseStep

    {
        public readonly DriverContext _driverConfig;
        public SearchBookFilterSteps(DriverContext driverConfig) : base(driverConfig)
        {
            _driverConfig = driverConfig;
        }

        [Given(@"I have navigated to Amazon Home Page")]
        public void GivenIHaveNavigatedToAmazonHomePage()
        {
            NavigateSite();
            _driverConfig.CurrentPage = new HomePage(_driverConfig);        
         
        }

        [Given(@"I see application opened")]
        public void GivenISeeApplicationOpened()
        {
            _driverConfig.CurrentPage = _driverConfig.CurrentPage.As<HomePage>().CheckIfHomePageExist();
        }


        [When(@"I selected the Book Filter Option")]
        public void WhenISelectedTheBookFilterOption()
        {
            _driverConfig.CurrentPage.As<SearchByCategoryPage>().SelectBookFilter();
     
        }

        [When(@"I entered the BookName")]
        public void WhenIEnteredTheBookName()
        {
            _driverConfig.CurrentPage.As<SearchByCategoryPage>().EnterBookName();
           
        }

        [When(@"I clicked the Go Button")]
        public void WhenIClickedTheGoButton()
        {
            _driverConfig.CurrentPage = _driverConfig.CurrentPage.As<SearchByCategoryPage>().ClickGoButton();
        
        }

        [Then(@"List of searched Book is visible")]
        public void ThenListOfSearchedBookIsVisible()
        {
            _driverConfig.CurrentPage.As<BookListPage>().CheckSearchedBookListIsOpen();
          
        }

    }
}
