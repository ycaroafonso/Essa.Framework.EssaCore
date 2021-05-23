using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;
using System.IO;

namespace Essa.Framework.WebScraping
{
    public class WebScrapingUtil : IDisposable
    {
        public ChromeDriver ChromeDriver;
        WebDriverWait _wait;
        ChromeOptions _chromeOptions;


        public bool IsBrowserAberto { get; private set; } = false;

        public WebScrapingUtil(string diretorioCache)
        {

            _chromeOptions = new ChromeOptions();
            //chromeOptions.AddUserProfilePreference("download.default_directory", _diretorio);
            _chromeOptions.AddUserProfilePreference("profile.default_content_setting_values.images", 2);
            _chromeOptions.AddArgument(@"--user-data-dir=" + Path.GetFullPath(@"browsercache", diretorioCache));

        }

        public void Abrir()
        {
            ChromeDriver = new ChromeDriver(AppDomain.CurrentDomain.BaseDirectory, _chromeOptions);
            IsBrowserAberto = true;
            _wait = new WebDriverWait(ChromeDriver, TimeSpan.FromSeconds(60));
            //_chromeDriver.Manage().Window.Maximize();
        }

        public void Ir(string url)
        {
            ChromeDriver.Navigate().GoToUrl(url);
        }

        public bool Esperar(Func<IWebDriver, bool> condition)
        {
            return _wait.Until(condition);
        }

        public void Dispose()
        {
            ChromeDriver.Dispose();
            IsBrowserAberto = false;
        }
    }
}
