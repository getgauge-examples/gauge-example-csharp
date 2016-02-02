using System;
using Gauge.CSharp.Lib;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace Gauge.Example.Implementation.Pages
{
    public class SignupPage : BasePage
    {
        public static readonly string SignUpUrl = string.Format("{0}signup", BaseUrl);

        [FindsBy(How = How.Id, Using = "user_username")]
        public IWebElement Username;

        [FindsBy(How = How.Id, Using = "user_email")]
        public IWebElement Email;

        [FindsBy(How = How.Id, Using = "user_password")]
        public IWebElement Password;

        [FindsBy(How = How.Id, Using = "user_password_confirmation")]
        public IWebElement PasswordConfirmation;

        [FindsBy(How = How.CssSelector, Using = "#new_user input[name=commit]")]
        public IWebElement Commit;

        public void RegisterNewUser()
        {
            var userName = string.Format("User_{0}", DateTime.Now.ToFileTime());
            ClearAndSetValue(Username, userName);
            ClearAndSetValue(Email, string.Format("{0}@example.com", userName));
            ClearAndSetValue(Password, "Password");
            ClearAndSetValue(PasswordConfirmation, "Password");
            Commit.Click();
            DataStoreFactory.ScenarioDataStore.Add("current_user", userName);
        }
    }
}