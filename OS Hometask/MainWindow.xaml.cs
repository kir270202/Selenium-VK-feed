using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace OS_Hometask
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            ChromeOptions chromeOptions = new ChromeOptions();
            chromeOptions.AddArgument(@"user-data-dir=C:\Users\User\AppData\Local\Google\Chrome\User Data");
            ChromeDriver chromeDriver = new ChromeDriver(chromeOptions);
            chromeDriver.Navigate().GoToUrl("https://vk.com/feed");
            IWebElement Parent = chromeDriver.FindElementById("feed_rows");
            if (Parent == null)
                return;
            List<VkNews> vkNewsList = new List<VkNews>();
            List<IWebElement> webElementsDiv = Parent.FindElements(By.TagName("div")).ToList();
            foreach (var item in webElementsDiv)
            {
                if (!item.Displayed)
                    continue;
                if (item.GetAttribute("class") == null)
                    continue;
                if (!item.GetAttribute("class").ToString().Trim().Equals("feed_row"))
                    continue;
                IWebElement DivId = item.FindElement(By.TagName("div"));
                string IdNews = string.Empty;
                if (DivId.GetAttribute("id") != null)
                    IdNews = DivId.GetAttribute("id").ToString();
                if (String.IsNullOrEmpty(IdNews))
                    continue;
                DateTime dateTime = DateTime.Now;
                List<IWebElement> webElementsSpan = item.FindElements(By.TagName("span")).ToList();
                foreach (var itemSpan in webElementsSpan)
                {
                    if (!itemSpan.Displayed)
                        continue;
                    if (itemSpan.GetAttribute("time") == null)
                        continue;
                    dateTime = new DateTime(1970, 1, 1, 0, 0, 0).AddSeconds(Double.Parse(itemSpan.GetAttribute("time").ToString())).AddHours(3);
                }
                VkNews vkNews = new VkNews()
                {
                    Text = item.Text,
                    Id = IdNews,
                    PublicationTime = dateTime
                };
                vkNewsList.Add(vkNews);
              /*  break;*/
            }
            JsonWorker jsonWorker = new JsonWorker();
            jsonWorker.setDataInJson(vkNewsList.ToArray(), "File1");
            MessageBox.Show(vkNewsList.Count.ToString());
        }
    }
}
