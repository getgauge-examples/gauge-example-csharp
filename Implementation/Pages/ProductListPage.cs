using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace Gauge.Example.Implementation.Pages
{
    public class ProductListPage : BasePage
    {
        public static string ProductsUrl = string.Concat(AdminUrl, "products/");

        [FindsBy(How = How.Id, Using = "q_title")]
        public IWebElement Title;

        [FindsBy(How = How.CssSelector, Using = "input[name='commit']")]
        public IWebElement SubmitButton;

        [FindsBy(How = How.CssSelector, Using = "#main_content table tbody tr:nth-child(1) td.product a")]
        public IWebElement FirstProduct;
        
        public void Search(string name) {
            Title.SendKeys(name);
            SubmitButton.Click();
        }

        public void OpenFirstProduct() {
            FirstProduct.Click();
        }
    }
}