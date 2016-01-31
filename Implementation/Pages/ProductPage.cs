using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace Gauge.Example.Implementation.Pages
{
    public class ProductPage : BasePage
    {
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
            DriverFactory.Driver.SwitchTo().Alert().Accept();
        }

        public void VerifyProductAttribute(string attributeName, string value)
        {
            var field = GetField(attributeName);
            Assert.NotNull(field, string.Format("Element does not exist: {0}", attributeName));
            Assert.AreEqual(value, field.Text);
        }

        private IWebElement GetField(string name)
        {
            switch (name.ToLower())
            {
                case "author":
                    return Author;
                case "title":
                    return Title;
                case "description":
                    return Description;
                case "price":
                    return Price;
                default:
                    return null;
            }
        }
    }
}