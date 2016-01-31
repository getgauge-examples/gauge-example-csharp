using System;
using OpenQA.Selenium.Support.PageObjects;

namespace Gauge.Example.Implementation.Pages
{
    public abstract class BasePage
    {
        protected static readonly string Url = Environment.GetEnvironmentVariable("APP_ENDPOINT");
        protected static readonly string AdminUrl = string.Format("{0}admin/", Url);

        protected BasePage()
        {
            PageFactory.InitElements(DriverFactory.Driver, this);
        }
    }
}
