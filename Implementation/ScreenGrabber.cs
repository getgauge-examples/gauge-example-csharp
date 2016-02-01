using System.Linq;
using Gauge.CSharp.Lib;
using OpenQA.Selenium;

namespace Gauge.Example.Implementation
{
    public class ScreenGrabber : IScreenGrabber
    {
        public byte[] TakeScreenShot()
        {
            var screenshot = DriverFactory.Driver as ITakesScreenshot;
            return screenshot == null ? Enumerable.Empty<byte>().ToArray() :  screenshot.GetScreenshot().AsByteArray;
        }
    }
}
