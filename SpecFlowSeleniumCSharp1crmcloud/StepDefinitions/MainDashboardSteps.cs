using OpenQA.Selenium;
using SpecFlowSeleniumCSharp1crmcloud.Drivers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpecFlowSeleniumCSharp1crmcloud.StepDefinitions
{
    internal class MainDashboardSteps
    {

        IWebDriver driver;

        private readonly ScenarioContext _scenarioContext;

        public MainDashboardSteps(ScenarioContext scenarioContext)
        {
            _scenarioContext = scenarioContext;
            driver = _scenarioContext.Get<SeleniumDriver>("SeleniumDriver").Get();
        }

        [Then(@"I navigate to Sales & Marketing - Contacts")]
        public void ThenINavigateToSalesMarketing_Contacts()
        {
            throw new PendingStepException();
        }


    }
}
