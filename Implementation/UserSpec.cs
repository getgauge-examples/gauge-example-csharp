using System;
using Gauge.CSharp.Lib.Attribute;
using Gauge.Example.Implementation.Pages;

namespace Gauge.Example.Implementation
{
    public class UserSpec
    {
        [Step("On signup page")]
        public void OnSignupPage()
        {
            DriverFactory.Driver.Visit(SignupPage.SignUpUrl);
            if (string.CompareOrdinal("true", Environment.GetEnvironmentVariable("SIMULATE_FAILURE") ?? string.Empty) ==0)
            {
                throw new Exception("Dummy exception to take screenshot");
            }
        }

        [Step("Fill in and send registration form")]
        public void Register()
        {
            var signupPage = new SignupPage();
            signupPage.RegisterNewUser();
        }
    }
}