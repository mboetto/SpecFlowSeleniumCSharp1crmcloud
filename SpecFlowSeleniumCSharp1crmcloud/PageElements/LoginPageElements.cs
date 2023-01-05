using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpecFlowSeleniumCSharp1crmcloud.PageElements
{
    class LoginPageElements
    {

        public By UserInputBox = By.Id("login_user");

        public By PswInputBox = By.Id("login_pass");

        public By LanguageInputBox = By.Id("login_lang");

        public By LoginBtn = By.Id("login_button");


    }
}
