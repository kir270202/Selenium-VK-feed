using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace OS_Hometask
{
    class NetWork
    {
        public void InputText(ChromeDriver chromeDriver, String element, string value)
        {
            List<IWebElement> webElements = chromeDriver.FindElementsById(element).ToList();
            foreach (var item in webElements)
            {
                if (!item.Displayed)
                    continue;
                item.SendKeys(value);
            }

        }
        public void InputBirthday(ChromeDriver chromeDriver, string Birth, string value)
        {
            List<IWebElement> webElements = chromeDriver.FindElementsByTagName("div").ToList();
            foreach (var item in webElements)
            {
                if (!item.Displayed)
                    continue;
                if (item.GetAttribute("data-test-id") == null)
                    continue;
                if (!item.GetAttribute("data-test-id").ToString().Equals(Birth))
                    continue;
                item.Click();
                break;
            }
            string HTML = chromeDriver.PageSource;
            webElements = chromeDriver.FindElementsById(value).ToList();
            foreach (var item in webElements)
            {
                if (!item.Displayed)
                    continue;
                item.Click();
                break;
            }
        }
    }
}
