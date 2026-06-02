using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using Reqnroll;
using Reqnroll.BoDi;

namespace CFStest.Hooks
{
    [Binding]
    public sealed class Hooks
    {
        
        private readonly IObjectContainer _container;

        public Hooks(IObjectContainer container)
        {
            _container = container;
        }
        
        [BeforeScenario]
        public void FirstBeforeScenario()
        {
            //TODO: implement homeic that has to run before executing each scenario
            IWebDriver driver = new ChromeDriver();
            driver.Manage().Window.Maximize();

            _container.RegisterInstanceAs<IWebDriver>(driver);
        }

        [AfterScenario]
        public void AfterScenario()
        {
            //TODO: implement homeic that has to run after executing each scenario
            var driver =_container.Resolve<IWebDriver>();
            if(driver != null)
            {
                driver.Quit();

            }
        }
    }
}