using System.Linq;
using Gauge.CSharp.Lib;
using Gauge.CSharp.Lib.Attribute;
using Gauge.Example.Implementation.Pages;

namespace Gauge.Example.Implementation
{
    public class CustomerSpec
    {
        private readonly CustomerPage _customerPage = new CustomerPage();

        [Step("On the customer page")]
        public void NavigateToCustomersPage() {
            DriverFactory.Driver.Visit(CustomerPage.CustomerUrl);
        }

        [Step("Search for customer <name>")]
        public void SearchUser(string username) {
            _customerPage.SearchUser(username);
        }

        [Step("The customer <name> is listed")]
        public void VerifyUserIsListed(string username) {
            _customerPage.VerifyUserListed(username);
        }

        [Step("Search for customers <table>")]
        public void VerifyCustomers(Table table)
        {
            foreach (var username in table.GetColumnValues("users"))
            {
                SearchUser(username);
                VerifyUserIsListed(username);
            }
        }

        [Step("Just registered customer is listed")]
        public void VerifyUserRegistered()
        {
            _customerPage.VerifyUserListed(DataStoreFactory.ScenarioDataStore.Get<string>("current_user"));
        }
    }
}
