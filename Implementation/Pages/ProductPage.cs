using System.Collections.Generic;
using Gauge.CSharp.Lib;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace Gauge.Example.Implementation.Pages
{
    public class ProductPage : BasePage
    {
        [FindsBy(How = How.CssSelector, Using = "#main_content table tbody tr:nth-child(1) td")]
        public IWebElement Id;

        [FindsBy(How = How.CssSelector, Using = "#main_content table tbody tr:nth-child(2) td")]
        public IWebElement Title;

        [FindsBy(How = How.CssSelector, Using = "#main_content table tbody tr:nth-child(3) td")]
        public IWebElement Description;

        [FindsBy(How = How.CssSelector, Using = "#main_content table tbody tr:nth-child(4) td")]
        public IWebElement Author;

        [FindsBy(How = How.CssSelector, Using = "#main_content table tbody tr:nth-child(5) td")]
        public IWebElement Price;

        [FindsBy(How = How.CssSelector, Using = "#titlebar_right div.action_items span.action_item:nth-child(2) a")]
        public IWebElement DeleteButton;

        public void VerifyAuthor(string name) {
            VerifyProductAttribute("Author", name);
        }

        public void Delete() {
            DeleteButton.Click();
            try
            {
                DriverFactory.Driver.SwitchTo().Alert().Accept();
            }
            catch (NoAlertPresentException)
            {
                //headless, no alerts
            }
        }

        public void VerifyProductAttribute(string attributeName, string value)
        {
            var field = GetElement(attributeName);
            Assert.NotNull(field, string.Format("Element does not exist: {0}", attributeName));
            Assert.AreEqual(value, field.Text);
        }

        public void SaveCurrentProductId()
        {
            DataStoreFactory.ScenarioDataStore.Add("productId", Id.Text);
        }
    }
}