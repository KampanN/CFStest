using NUnit.Framework;
using NUnit.Framework.Internal;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace CFStest
{
    
    public class Home 
    {
        private readonly IWebDriver _driver;
        private readonly By HomePageContent = By.XPath("//div[@id='pageContent']");
        private readonly By SearchBox = By.XPath("//input[@id='twotabsearchtextbox']");
        private readonly By SearchButton = By.XPath("//input[@id='nav-search-submit-button']");
        private readonly By Logo = By.XPath("//a[@id='nav-logo-sprites']");
        private readonly By AccountList = By.XPath("//div[@id='nav-link-accountList']");
        private readonly By Orders = By.XPath("//a[@id='nav-orders']");
        private readonly By Cart = By.XPath("//a[@id='nav-cart']");
        private readonly By SearchedProduct = By.XPath("//div[@class='s-main-slot s-result-list s-search-results sg-row']/div[3]//a/h2/span[contains(text(),'iPhone Air')]");
        private readonly By ToggleMenu = By.XPath("//a[@id='nav-hamburger-menu']");
        private readonly By BestSellersCategory = By.XPath("//a[@class='hmenu-item' and text()='Bestsellers']");
        private readonly By AmazonBestSellersPage = By.XPath("//h1[text()='Amazon Bestsellers']");
        public Home(IWebDriver driver)
        {
            _driver = driver;
        }
        
        public bool IsElementDisplayed(By locator, int timeoutSeconds = 5)
        {
            try
            {
                var wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(timeoutSeconds));
                IWebElement element = wait.Until(ExpectedConditions.ElementIsVisible(locator));
                ScrollToElement(element, _driver);
                return element != null && element.Displayed;
            }
            catch (WebDriverTimeoutException)
            {
                return false;
            }
            catch (NoSuchElementException)
            {
                return false;
            }
            
        }

        public string CaptureScreenshot(string fileNamePrefix = "screenshot", string folder = null)
        {
            try
            {
                if (!(_driver is ITakesScreenshot takesScreenshot))
                    return null;

                var screenshot = takesScreenshot.GetScreenshot();

                var outputDir = folder ?? Path.Combine(Directory.GetCurrentDirectory(), "screenshots");
                Directory.CreateDirectory(outputDir);

                var fileName = $"{fileNamePrefix}_{DateTime.Now:yyyyMMdd_HHmmssfff}.png";
                var fullPath = Path.Combine(outputDir, fileName);

                screenshot.SaveAsFile(fullPath);
                return fullPath;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"CaptureScreenshot failed: {ex.Message}");
                return null;
            }
        }

        public void ScrollToElement(IWebElement element, IWebDriver driver)
        {
            var js = (IJavaScriptExecutor)driver;
            js.ExecuteScript("arguments[0].scrollIntoView(true);", element);
        }

        public bool IsAmazonHomePageContentDisplayed()
        {
            return IsElementDisplayed(HomePageContent, 5);
        }
        
        public bool IsSearchBoxDisplayed()
        {
            return IsElementDisplayed(SearchBox, 5);
        }
        public bool IsSearchButtonDisplayed()
        {
            return IsElementDisplayed(SearchButton, 5);
        }

        public bool IsLogoDisplayed()
        {
            return IsElementDisplayed(Logo, 5);
        }
        public bool IsOrdersDisplayed()
        {
            return IsElementDisplayed(Orders, 5);
        }
        public bool IsAccountListDisplayed()
        {
            return IsElementDisplayed(AccountList, 5);
        }
        public bool IsCartDisplayed()
        {
            return IsElementDisplayed(Cart, 5);
        }
        
        public void IsScreenshotOfThePageCaptured()
        {
            
                // captures the screenshot
                var path = CaptureScreenshot("PageScreenShot");
                Console.WriteLine("Screenshot saved: " + path);

                // checks the file was written or not
                Assert.IsTrue(!string.IsNullOrEmpty(path) && File.Exists(path), $"Screenshot not found at {path}");
            
        }

        
        public void EnterProductInTheSearchBox(string product)
        {
            WebDriverWait wait1 = new WebDriverWait(_driver, TimeSpan.FromSeconds(5));

            IWebElement InputSearchBox = wait1.Until(ExpectedConditions.ElementIsVisible(SearchBox));

            InputSearchBox.SendKeys(product);

            IWebElement searchBtn = wait1.Until(ExpectedConditions.ElementToBeClickable(SearchButton));
            searchBtn.Click();
        }

        
        public bool IsSearchedProductDisplayed()
        {
            return IsElementDisplayed(SearchedProduct, 5);
        }
        
        public void ClickOnAllMenuIcon()
        {
            WebDriverWait wait1 = new WebDriverWait(_driver, TimeSpan.FromSeconds(5));
            IWebElement MenuIcon = wait1.Until(ExpectedConditions.ElementToBeClickable(ToggleMenu));
            MenuIcon.Click();
        }

        public void SelectBestSellersCategory()
        {
            WebDriverWait wait1 = new WebDriverWait(_driver, TimeSpan.FromSeconds(5));
            IWebElement BestSellerCategory = wait1.Until(ExpectedConditions.ElementToBeClickable(BestSellersCategory));
            BestSellerCategory.Click();
        }

        

        public bool IsBestSellersPageDisplayed()
        {
            return IsElementDisplayed(AmazonBestSellersPage, 5);
        }
       
    }
    }

