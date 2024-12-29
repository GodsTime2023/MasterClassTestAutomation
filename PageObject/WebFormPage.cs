using MasterClassTestAutomation.Models;
using OpenQA.Selenium;

namespace MasterClassTestAutomation.PageObject
{
    public class WebFormPage
    {
        IWebDriver _driver;
        public WebFormPage(IWebDriver driver)
        {
            _driver = driver;
        }

        IReadOnlyCollection<IWebElement> listOfElements =>
                _driver.FindElements(By.XPath("//*[@class= 'form-control']"));

        IWebElement dropdown => _driver.FindElement(By.Name("my-select"));

        IWebElement slider => _driver.FindElement(By.Name("my-range"));


        public WebFormPage InteractWithElement(Num index, string value)
        {
            Thread.Sleep(1000);
            listOfElements.ElementAt((int)index).SendKeys(value);
            return this;
        }

        public WebFormPage InteractWithDropdown(string key)
        {
            Thread.Sleep(1000);
            dropdown.SendKeys(key);
            return this;
        }

        public WebFormPage InteractWithRange(int value)
        {
            Thread.Sleep(1000);
            IJavaScriptExecutor js = (IJavaScriptExecutor)_driver;
            js.ExecuteScript("$(arguments[0]).val(arguments[1]).change();", slider,
                value);
            return this;
        }
    }
}
