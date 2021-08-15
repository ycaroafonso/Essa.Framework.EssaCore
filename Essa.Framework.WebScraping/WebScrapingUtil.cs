using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;
using System.Drawing;
using System.IO;

namespace Essa.Framework.WebScraping
{
    public class WebScrapingUtil : IDisposable
    {
        public ChromeDriver ChromeDriver;
        WebDriverWait _wait;
        ChromeOptions _chromeOptions;


        public bool IsBrowserAberto { get; private set; } = false;

        public WebScrapingUtil(string diretorioCache, bool isDesabilitarImagens = true)
        {

            _chromeOptions = new ChromeOptions();
            //chromeOptions.AddUserProfilePreference("download.default_directory", _diretorio);
            if (isDesabilitarImagens)
                _chromeOptions.AddUserProfilePreference("profile.default_content_setting_values.images", 2);
            _chromeOptions.AddArgument(@"--user-data-dir=" + Path.GetFullPath(@"browsercache", diretorioCache));
        }

        public void SetBinary(string binaryLocalition)
        {
            //_chromeOptions.BinaryLocation = binaryLocalition;
            //_chromeOptions.AddArguments("--headless");
            //_chromeOptions.AddArguments("--no-sandbox");
            //_chromeOptions.AddArguments("--disable-dev-shm-usage");
        }





        bool _isRedimensionar = false;
        Size _size;
        public void Redimensionar(int w, int h)
        {
            _isRedimensionar = true;
            _size = new Size(w, h);
        }
        public void Maximizar()
        {
            ChromeDriver.Manage().Window.Maximize();
        }







        public string Html { get => ChromeDriver.PageSource; }




        public void SalvarPagina(string caminho)
        {
            File.WriteAllText(caminho, ChromeDriver.PageSource);
        }

        public void Abrir()
        {
            ChromeDriver = new ChromeDriver(@"G:\ycaro\EssaTecnologia\browsercache\_geral\chromedriver_win32\", _chromeOptions, TimeSpan.FromSeconds(180));

            if (_isRedimensionar)
                ChromeDriver.Manage().Window.Size = _size;

            IsBrowserAberto = true;
            _wait = new WebDriverWait(ChromeDriver, TimeSpan.FromSeconds(180));
            //_chromeDriver.Manage().Window.Maximize();
        }










        public void Ir(string url)
        {
            ChromeDriver.Navigate().GoToUrl(url);
        }








        public void Ir(string url, string arquivocachehtml, bool isatualizarcache)
        {
            if (isatualizarcache || !File.Exists(arquivocachehtml))
                IrAtualizarCache(url, arquivocachehtml);
            else
                Ir(arquivocachehtml);
        }


        public void IrAtualizarCache(string url, string arquivocachehtml)
        {
            Ir(url);

            File.WriteAllText(arquivocachehtml, ChromeDriver.PageSource);
        }








        public void Fechar()
        {
            ChromeDriver.Close();
            IsBrowserAberto = false;
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
