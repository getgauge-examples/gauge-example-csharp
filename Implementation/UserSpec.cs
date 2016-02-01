using Gauge.CSharp.Lib.Attribute;
using Gauge.Example.Implementation.Pages;

namespace Gauge.Example.Implementation
{
    public class UserSpec
    {
        [Step("On signup page")]
        public void OnSignupPage()
        {
            DriverFactory.Driver.Navigate().GoToUrl(SignupPage.SignUpUrl);
        }

        [Step("Fill in and send registration form")]
        public void Register()
        {
            var signupPage = new SignupPage();
            signupPage.RegisterNewUser();
        }
    }
}