using Gauge.CSharp.Lib.Attribute;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;

namespace Gauge.Example.Implementation
{
    public class DriverFactory
    {

        public static IWebDriver Driver { get; private set; }

        [BeforeSuite]
        public void Setup() {
            Driver = new FirefoxDriver();
        }

        [AfterSuite]
        public void TearDown() {
            Driver.Close();
        }
    }
}
