using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace Gauge.Example.Implementation
{
    public static class DriverExtensions
    {
        public static void Visit(this IWebDriver driver, string url)
        {
            driver.Navigate().GoToUrl(url);
            new WebDriverWait(driver, TimeSpan.FromSeconds(5)).Until(ExpectedConditions.ElementExists(By.TagName("body")));
        }
    }
}