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
        private readonly ScenarioContext _scenarioContext;

        public Hooks(IObjectContainer container, ScenarioContext scenarioContext)
        {
            _container = container;
            _scenarioContext = scenarioContext;
        }
        
        [BeforeScenario]
        public void FirstBeforeScenario()
        {
            //TODO: implement homeic that has to run before executing each scenario
            if (_scenarioContext.ScenarioInfo.Tags != null && _scenarioContext.ScenarioInfo.Tags.Contains("api"))
                return;

            IWebDriver driver = new ChromeDriver();
            driver.Manage().Window.Maximize();

            _container.RegisterInstanceAs<IWebDriver>(driver);
        }

        [AfterScenario]
        public void AfterScenario()
        {
            //TODO: implement homeic that has to run after executing each scenario
            if (_scenarioContext.ScenarioInfo.Tags != null && _scenarioContext.ScenarioInfo.Tags.Contains("api"))
                return;

            var driver =_container.Resolve<IWebDriver>();
            if(driver != null)
            {
                driver.Quit();

            }
        }
    }
}