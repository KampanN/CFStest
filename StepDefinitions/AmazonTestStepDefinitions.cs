using CFStest;
using NUnit.Framework;
using NUnit.Framework.Internal;
using OpenQA.Selenium;
using OpenQA.Selenium.BiDi.Modules.BrowsingContext;
using OpenQA.Selenium.Chrome;
using Reqnroll;
using System.Text.RegularExpressions;

namespace CFStest.StepDefinitions
{
    [Binding]
    public sealed class AmazonTestStepDefinitions
    {
        private IWebDriver driver;
        private Home home;
    


        public AmazonTestStepDefinitions(IWebDriver driver)
        {
            this.driver = driver;
            this.home = new Home(driver);
        }
       
    

        [Given(@"open the browser and enter url")]
        public void GivenOpenTheBrowserAndEnterUrl()
        {
            this.home = new Home(driver);
            string urlvalue = "https://www.amazon.in/";
            driver.Navigate().GoToUrl(urlvalue);
        }

        [When(@"User is navigated to Amazon home page")]
        public void WhenUserIsNavigatedToAmazonHomePage()
        {

            Assert.IsTrue(home.IsAmazonHomePageContentDisplayed());

        }

        [Then(@"I Verify Key navigation elements are present")]
        public void ThenIVerifyKeyNavigationElementsArePresent()
        {

            Assert.IsTrue(home.IsSearchBoxDisplayed());
            Assert.IsTrue(home.IsSearchButtonDisplayed());
            Assert.IsTrue(home.IsLogoDisplayed());
            Assert.IsTrue(home.IsAccountListDisplayed());
            Assert.IsTrue(home.IsOrdersDisplayed()); 
            Assert.IsTrue(home.IsCartDisplayed());

        }
        
        [Then(@"I capture the screenshot")]
        public void ThenICaptureTheScreenshot()
        {

            home.IsScreenshotOfThePageCaptured();

        }
        
        [When(@"user search for (.*) in search box")]
        public void WhenUserSearchForInSearchBox(string product)
        {
            home.EnterProductInTheSearchBox(product);
        }

        
        [Then(@"I verify the searched product is displayed")]
        public void ThenIVerifyTheSearchedProductIsDisplayed()
        {

            Assert.IsTrue(home.IsSearchedProductDisplayed());

        }
       
        [When(@"I Click on All Menu icon")]
        public void WhenIClickOnAllMenuIcon()
        {

            home.ClickOnAllMenuIcon();

        }

        [Then(@"I Select Best Sellers category")]
        public void ThenISelectBestSellersCategory()
        {

            home.SelectBestSellersCategory();

        }
        
        [Then(@"I verify user is navigated to Best Sellers page")]
        public void ThenIVerifyUserIsNavigatedToBestSellersPage()
        {

            home.IsBestSellersPageDisplayed();

        }
        
    }
}
