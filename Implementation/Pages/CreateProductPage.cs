using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace Gauge.Example.Implementation.Pages
{
    public class CreateProductPage : BasePage
    {
        public static string NewProductUrl = string.Concat(AdminUrl,"products/new/");

        [FindsBy(How = How.Id, Using = "product_title")]
        public IWebElement ProductTitle;

        [FindsBy(How = How.Id, Using = "product_description")]
        public IWebElement ProductDescription;

        [FindsBy(How = How.Id, Using = "product_author")]
        public IWebElement ProductAuthor;

        [FindsBy(How = How.Id, Using = "product_price")]
        public IWebElement ProductPrice;

        [FindsBy(How = How.CssSelector, Using = "#product_submit_action input[name=commit]")]
        public IWebElement ProductSubmit;

        [FindsBy(How = How.Id, Using = "product_image_file_name")]
        public IWebElement ProductImageFileName;

        public void Create(string title, string desc, string author, string price)
        {
            ProductTitle.SendKeys(title);
            ProductDescription.SendKeys(desc);
            ProductAuthor.SendKeys(author);
            ProductPrice.SendKeys(price);
            ProductImageFileName.SendKeys("not available");
            ProductSubmit.Click();
        }

    }
}