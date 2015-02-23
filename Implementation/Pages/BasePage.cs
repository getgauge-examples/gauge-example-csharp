using OpenQA.Selenium.Support.PageObjects;

namespace Gauge.Example.Implementation.Pages
{
    public abstract class BasePage
    {
        protected const string Url = "https://activeadmin-demo.herokuapp.com/admin/";

        protected BasePage()
        {
            PageFactory.InitElements(DriverFactory.Driver, this);
        }
    }
}
