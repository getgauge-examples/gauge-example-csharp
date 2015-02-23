using System.Linq;
using Gauge.CSharp.Lib;
using Gauge.CSharp.Lib.Attribute;
using Gauge.Example.Implementation.Pages;

namespace Gauge.Example.Implementation
{
    public class CustomerSpec
    {
        [Step("On the customer page")]
        public void NavigateToCustomersPage() {
            DriverFactory.Driver.Navigate().GoToUrl(CustomerPage.CustomerUrl);
        }

        [Step("Search for customer <name>")]
        public void SearchUser(string username) {
            new CustomerPage().SearchUser(username);
        }

        [Step("The customer <name> is listed")]
        public void VerifyUserIsListed(string username) {
            new CustomerPage().VerifyUserListed(username);
        }

        [Step("Search for customers <table>")]
        public void VerifyCustomers(Table table)
        {
            var rows = table.GetRows();
            foreach (var username in rows.Select(row => row[0]))
            {
                SearchUser(username);
                VerifyUserIsListed(username);
            }
        }
    }
}
