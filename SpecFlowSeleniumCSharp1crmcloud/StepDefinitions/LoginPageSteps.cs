using OpenQA.Selenium;
using SpecFlowSeleniumCSharp1crmcloud.Drivers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpecFlowSeleniumCSharp1crmcloud.StepDefinitions
{
    public sealed class LoginPageSteps
    {

        IWebDriver driver;

        private readonly ScenarioContext _scenarioContext;

        public LoginPageSteps(ScenarioContext scenarioContext)
        {
            _scenarioContext = scenarioContext;
        }

        public By UserInputBox_id = By.Id("login_user");

        public By PswInputBox_id = By.Id("login_pass");

        public By LanguageInputBox_id = By.Id("login_lang");

        public By LoginBtn_id = By.Id("login_button");

        [Given(@"I navigate to crmcloud")]
        public void GivenINavigateToCrmcloud()
        {
            driver = _scenarioContext.Get<SeleniumDriver>("SeleniumDriver").Setup();

            driver.Url = "https://demo.1crmcloud.com";

        }

        [Then(@"I wait (.*) seconds")]
        public void GivenIWaitSeconds(int seconds)
        {
            System.Threading.Thread.Sleep(seconds * 1000);
        }

        [Then(@"I check the presence of (.*)\.(.*)")]
        public void ThenICheckThePresenceOf(string page_class, string page_element)
        {


            throw new PendingStepException();
        }

        [Then(@"I login as admin")]
        public void ThenILoginAsAdmin()
        {
            IWebElement UserInputBox = driver.FindElement(UserInputBox_id);
            UserInputBox.SendKeys("admin");


        }


    }
}
