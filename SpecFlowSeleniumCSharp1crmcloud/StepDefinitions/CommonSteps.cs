using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using SpecFlowSeleniumCSharp1crmcloud.Drivers;
using System;
using System.Collections;
using TechTalk.SpecFlow;

namespace SpecFlowSeleniumCSharp1crmcloud.StepDefinitions
{
    [Binding]
    public class CommonSteps
    {
        IWebDriver driver;

        WebDriverWait wait;

        private readonly ScenarioContext _scenarioContext;

        public CommonSteps(ScenarioContext scenarioContext)
        {
            _scenarioContext = scenarioContext;
        }

        //ELEMENTS

        //LoginPage

        public By UserInputBox_by = By.Id("login_user");

        public By PswInputBox_by = By.Id("login_pass");

        public By LangDropDwn_by = By.Id("login_lang");

        public By LoginBtn_by = By.Id("login_button");

        //Common

        public By ContactsSectionBtn_by = By.XPath("//a[contains(text(), 'Contacts')]");

        public By SearchBox_by = By.Id("filter_text");

        //Scenario1

        public By SalesAndMarketingSectionBtn_by = By.XPath("(//div[contains(text(), 'Sales & Marketing')])[1]");

        public By SearchFirstResult_by = By.XPath("(//div[contains(@class, 'option-cell input-label')])[1]");

        public By CreateBtn_by = By.XPath("(//span[contains(text(), 'Create') and contains(@class, 'input-label')])[1]");

        public By FirstNameInputBox_by = By.Id("DetailFormfirst_name-input");

        public By LastNameInputBox_by = By.Id("DetailFormlast_name-input");

        public By CategoryDropDwn_by = By.Id("DetailFormcategories-input");

        public By CategoryCustomersOption_by = By.XPath("//div[contains(text(), 'Customers') and contains(@class, 'option-cell input-label')]");

        public By CategorySuppliersOption_by = By.XPath("//div[contains(text(), 'Suppliers') and contains(@class, 'option-cell input-label')]");

        public By BusinessRoleDropDwn_by = By.Id("DetailFormbusiness_role-input");

        public By BusinessRoleSalesOption_by = By.XPath("//div[contains(text(), 'Sales') and contains(@class, 'option-cell input-label')]");

        public By SaveBtn_by = By.Id("DetailForm_save2-label");

        public By ContactName_by = By.Id("_form_header");

        public By ContactCategory_by = By.XPath("//p[contains(@class, 'form-label') and contains(text(), 'Category')]/..");

        public By ContactBusinessRole_by = By.XPath("//p[contains(@class, 'form-label') and contains(text(), 'Business Role')]/following-sibling::div");

        public By DeleteContactBtn_by = By.Id("DetailForm_delete-label");

        //Scenario2

        public By ReportAndSettingsSectionBtn_by = By.XPath("(//div[contains(text(), 'Reports & Settings')])[1]");

        public By ReportsSectionBtn_by = By.XPath("(//a[contains(text(), ' Reports')])[2]");

        public By RunReportBtn_by = By.XPath("//span[contains(@class, 'input-label') and contains(text(), 'Run Report')]");

        public By ReportFirstResultRow_by = By.XPath("(//tr[contains(@class, 'listViewRow oddListRowS1')])[1]");

        //Scenario3

        public By ActivityLogSectionBtn_by = By.XPath("//a[contains(text(), ' Activity Log')]");

        public By LogRowChecksList_by = By.XPath("(//a[contains(@class, 'listViewExtLink')])/../../../td/div/input");

        public By ActionsBtn_by = By.XPath("(//button[contains(@class, 'input-button menu-source')])[1]");

        public By DeleteOptionBtn_by = By.XPath("//div[contains(@class, 'option-cell input-label') and contains(text(), 'Delete')]");

        private ArrayList selected_elem_values;

        //UTILS

        public IWebElement Check(By elem_by)
        {
            IWebElement elem_checked = wait.Until(ExpectedConditions.ElementIsVisible(elem_by));
            return elem_checked;
        }

        public IWebElement HooverOn(By elem_by)
        {
            Actions action = new Actions(driver);
            IWebElement elem_to_hoover = Check(elem_by);
            action.MoveToElement(elem_to_hoover).Perform();
            return elem_to_hoover;
        }

        public void CheckAndCLick(By elem_by)
        {
            IWebElement elem_to_click = HooverOn(elem_by);
            elem_to_click = wait.Until(ExpectedConditions.ElementToBeClickable(elem_to_click));
            Thread.Sleep(500);
            elem_to_click.Click();
        }

        public void Fill(By elem_by, String content)
        {
            IWebElement InputBox = Check(elem_by);
            Thread.Sleep(500);
            InputBox.SendKeys(content);
        }

        public void SelectFromDropDown(By elem_by, String value)
        {
            SelectElement LangDropDwn = new SelectElement(Check(elem_by));
            LangDropDwn.SelectByValue(value);
        }

        public Boolean CheckIfContains(By elem_by, String value)
        {
            IWebElement elem_to_check = HooverOn(elem_by);
            return elem_to_check.Text.Contains(value);
        }

        public bool TryFindElement(By elem_by)
        {
            try
            {
                IWebElement elem_found = driver.FindElement(elem_by);
            }
            catch (NoSuchElementException ex)
            {
                return false;
            }
            return true;
        }

        public void MultipleCheckAndClick(By elem_by, int elem_num)
        {
            IList<IWebElement> elements = driver.FindElements(elem_by);
            Actions action = new Actions(driver);
            IWebElement elem_to_click;
            selected_elem_values = new ArrayList();
            for (int i = 0; i < elem_num; i++)
            {
                action.MoveToElement(elements[i]).Perform();
                selected_elem_values.Add(elements[i].GetAttribute("value"));
                elements[i].Click();
                Thread.Sleep(500);
            }
        }

        //STEPS

        //LoginPage

        [Given(@"I navigate to crmcloud")]
        public void GivenINavigateToCrmcloud()
        {
            driver = _scenarioContext.Get<SeleniumDriver>("SeleniumDriver").Setup();

            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(30));

            driver.Url = "https://demo.1crmcloud.com";

        }

        [Then(@"I wait (.*) seconds")]
        public void ThenIWaitSeconds(int seconds)
        {
            Thread.Sleep(seconds * 1000);
            return;
        }

        [Then(@"I login as admin")]
        public void ThenILoginAsAdmin()
        {
            Fill(UserInputBox_by, "admin");
            Fill(PswInputBox_by, "admin");

            SelectFromDropDown(LangDropDwn_by, "en_us");
            CheckAndCLick(LoginBtn_by);
            Thread.Sleep(3000);
        }

        //Common

        [Then(@"I search '(.*)'")]
        public void ThenISearch(string search_target)
        {
            Fill(SearchBox_by, search_target);
            Thread.Sleep(3000);
            CheckAndCLick(SearchFirstResult_by);
            Thread.Sleep(1000);
        }

        //Scenario1

        [Then(@"I navigate to Sales & Marketing - Contacts")]
        public void ThenINavigateToSalesMarketing_Contacts()
        {
            HooverOn(SalesAndMarketingSectionBtn_by);
            CheckAndCLick(ContactsSectionBtn_by);
            Thread.Sleep(10000);
        }

        [Then(@"I create a new contact")]
        public void ThenICreateANewContact()
        {
            CheckAndCLick(CreateBtn_by);
            Fill(FirstNameInputBox_by, "TestFN");
            Fill(LastNameInputBox_by, "TestLN");
            CheckAndCLick(CategoryDropDwn_by);
            CheckAndCLick(CategoryCustomersOption_by);
            CheckAndCLick(CategoryDropDwn_by);
            CheckAndCLick(CategorySuppliersOption_by);
            CheckAndCLick(BusinessRoleDropDwn_by);
            CheckAndCLick(BusinessRoleSalesOption_by);
            CheckAndCLick(SaveBtn_by);

            Thread.Sleep(5000);
        }

        [Then(@"I check the contact data are correct")]
        public void ThenICheckTheContactDataAreCorrect()
        {
            Assert.True(CheckIfContains(ContactName_by, "TestFN TestLN"));
            Assert.True(CheckIfContains(ContactCategory_by, "Customers, Suppliers"));
            Assert.True(CheckIfContains(ContactBusinessRole_by, "Sales"));
        }

        [Then(@"I delete the contact")]
        public void ThenIDeleteTheContact()
        {
            CheckAndCLick(DeleteContactBtn_by);
            Thread.Sleep(500);
            driver.SwitchTo().Alert().Accept();
            Thread.Sleep(5000);
        }

        [Then(@"I search the test contact and if found I delete the contact")]
        public void ThenISearchTheTestContactAndIfFoundIDeleteTheContact()
        {
            Fill(SearchBox_by, "TestFN TestLN");
            Thread.Sleep(3000);
            if (TryFindElement(SearchFirstResult_by))
            {
                CheckAndCLick(SearchFirstResult_by);
                Thread.Sleep(1000);
                ThenIDeleteTheContact();
            }
            else
            {
                CheckAndCLick(SearchBox_by);
            }
        }

        [Then(@"I search the test contact")]
        public void ThenISearchTheTestContact()
        {
            ThenISearch("TestFN TestLN");
        }

        //Scenario2

        [Then(@"I navigate to Reports & Settings - Reports")]
        public void ThenINavigateToReportsSettings_Reports()
        {
            HooverOn(ReportAndSettingsSectionBtn_by);
            CheckAndCLick(ReportsSectionBtn_by);
            Thread.Sleep(10000);
        }

        [Then(@"I run report and verify that some results were returned")]
        public void ThenIRunReportAndVerifyThatSomeResultsWereReturned()
        {
            Thread.Sleep(10000);
            CheckAndCLick(RunReportBtn_by);
            Thread.Sleep(10000);
            Check(ReportFirstResultRow_by);
        }

        //Scenario3

        [Then(@"I navigate to Reports & Settings - Activity Log")]
        public void ThenINavigateToReportsSettings_ActivityLog()
        {
            HooverOn(ReportAndSettingsSectionBtn_by);
            CheckAndCLick(ActivityLogSectionBtn_by);
            Thread.Sleep(10000);
        }

        [Then(@"I select first (.*) items in the table")]
        public void ThenISelectFirstItemsInTheTable(int item_num)
        {
            MultipleCheckAndClick(LogRowChecksList_by, item_num);
        }

        [Then(@"I click Actions - Delete")]
        public void ThenIClickActions_Delete()
        {
            CheckAndCLick(ActionsBtn_by);
            CheckAndCLick(DeleteOptionBtn_by);
            Thread.Sleep(500);
            driver.SwitchTo().Alert().Accept();
            Thread.Sleep(10000);
        }

        [Then(@"I verify that items were deleted")]
        public void ThenIVerifyThatItemsWereDeleted()
        {
            IList<IWebElement> elements = driver.FindElements(LogRowChecksList_by);
            for (int i = 0; i < selected_elem_values.Count; i++)
            {
                for (int j = 0; j < selected_elem_values.Count; j++)
                {
                    Assert.False(elements[i].GetAttribute("value").Equals(selected_elem_values[j]));
                }
            }
        }
    }
}
