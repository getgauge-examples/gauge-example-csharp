using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace Gauge.Example.Implementation.Pages
{
    public class EditProjectPage : BasePage
    {
        public static string EditProductUrl(string productId)
        {
            return string.Format("{0}/products/{1}/edit", AdminUrl, productId);
        }

        [FindsBy(How = How.Id, Using = "product_title")]
        public IWebElement Title;

        [FindsBy(How = How.Id, Using = "product_description")]
        public IWebElement Description;

        [FindsBy(How = How.Id, Using = "product_author")]
        public IWebElement Author;

        [FindsBy(How = How.Id, Using = "product_price")]
        public IWebElement Price;

        [FindsBy(How = How.Id, Using = "product_featured")]
        public IWebElement Featured;

        [FindsBy(How = How.Id, Using = "product_image_file_name")]
        public IWebElement ImageFileName;

        [FindsBy(How = How.CssSelector, Using = "#product_submit_action input[name=commit]")]
        public IWebElement Commit;

        public void SaveProduct()
        {
            Commit.Click();
        }

        public void UpdateProductValue(string specifier, string newValue)
        {
            var webElement = GetElement(specifier);
            ClearAndSetValue(webElement, newValue);
        }
    }
}