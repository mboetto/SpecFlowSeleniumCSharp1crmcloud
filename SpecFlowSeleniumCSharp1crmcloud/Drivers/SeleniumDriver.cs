using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebDriverManager;
using WebDriverManager.DriverConfigs.Impl;

namespace SpecFlowSeleniumCSharp1crmcloud.Drivers
{
    public class SeleniumDriver
    {

        private IWebDriver driver;

        private readonly ScenarioContext _scenarioContext;

        public SeleniumDriver(ScenarioContext scenarioContext) => _scenarioContext = scenarioContext;

        public IWebDriver Setup()
        {

            new DriverManager().SetUpDriver(new ChromeConfig());

            ChromeOptions options = new ChromeOptions();

            options.AddArguments("--incognito");

            driver = new ChromeDriver(options);

            _scenarioContext.Set(driver, "WebDriver");

            driver.Manage().Window.Maximize();

            return driver;
        }

        public IWebDriver Get()
        {
            ArgumentNullException.ThrowIfNull(driver, "driver");
            return driver;
        }

    }  
}
