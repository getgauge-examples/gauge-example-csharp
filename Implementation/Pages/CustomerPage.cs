using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace Gauge.Example.Implementation.Pages
{
    public class CustomerPage : BasePage
    {
        public static string CustomerUrl = string.Concat(AdminUrl, "customers/");

        [FindsBy(How = How.Id, Using = "q_username")]
        public IWebElement Username;

        [FindsBy(How = How.CssSelector, Using = "#new_q .buttons input[name=commit]")]
        public IWebElement SubmitButton;
    
        [FindsBy(How= How.CssSelector, Using = "table#index_table_customers tbody tr:nth-child(1) td.col-username")]
        public IWebElement UsernameResult;
    
        public void SearchUser(string username) {
            ClearAndSetValue(Username, username);
            SubmitButton.Click();
        }

        public void VerifyUserListed(string username) {
            Assert.AreEqual(UsernameResult.Text, username);
        }
    }
}