//-----------------------------------------------------------------------
// <copyright file="ComponenteDeTela.cs" company="LG Sistemas">
//     Copyright © LG Sistemas. All rights reserved.
//     TODOS OS DIREITOS RESERVADOS.
// </copyright>
//-----------------------------------------------------------------------

using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.Globalization;
using System.IO;
using System.Linq;
using ImageMagick;
using LG.LMS.TestesDeInterface.Infraestrutura.Acoes;
using LG.LMS.TestesDeInterface.Infraestrutura.Enumeradores;
using LG.LMS.TestesDeInterface.Infraestrutura.Interfaces;
using LG.LMS.TestesDeInterface.Infraestrutura.Utilitarios;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.PhantomJS;
using OpenQA.Selenium.Support.UI;

namespace LG.LMS.TestesDeInterface.Infraestrutura
{
    /// <summary>
    /// Componente de tela para testes de interface.
    /// </summary>
    public sealed class ComponenteDeTela : IDisposable
    {
        #region "ATRIBUTOS PRIVADOS"

        private readonly IAcoesDeScript _acoesDeScript;
        private readonly IAcoesDeEspera _acoesDeEspera;
        private readonly IAcoesDeTeclado _acoesDeTeclado;
        private readonly IAcoesDeMouse _acoesDeMouse;
        private readonly IAcoesDeDocument _acoesDeDocument;

        ////private readonly Size _resolucao = new Size(1440, 900);
        ////private readonly Size _resolucao = new Size(1920, 1080);

        // configuração padrão recomendado por https://devoloper.google.com
        private readonly Size _resolucao = new Size(1280, 1696);

        private IWebDriver _webDriver;
        private IWait<IWebDriver> _wait;

        #endregion

        #region "CONSTRUTOR"

        public ComponenteDeTela(ConfiguracaoDeTela configuracaoDeTela)
        {
            ConfiguracaoDeTela = configuracaoDeTela;
            _webDriver = CrieWebDriver(ConfiguracaoDeTela);
            _acoesDeScript = new AcoesDeScript(this);
            _acoesDeEspera = new AcoesDeEspera(this);
            _acoesDeTeclado = new AcoesDeTeclado(this);
            _acoesDeMouse = new AcoesDeMouse(this);
            _acoesDeDocument = new AcoesDeDocument(this);

            _wait = new WebDriverWaitCustomizado(this, ConfiguracaoDeTela.Timeout);

            DefinaTimeoutsImplicitos();
        }

        #endregion

        #region "PROPRIEDADES"

        /// <summary>
        /// Obtém ou define a configuração de tela.
        /// </summary>
        /// <value>
        /// A configuração de tela.
        /// </value>
        public ConfiguracaoDeTela ConfiguracaoDeTela { get; private set; }

        /// <summary>
        /// Obtém componente WebDriver.
        /// </summary>
        /// <value>
        /// O web driver.
        /// </value>
        public IWebDriver WebDriver
        {
            get { return _webDriver; }
        }

        /// <summary>
        /// Obtém o screenshot do Webdriver. 
        /// </summary>
        /// <value>Screenshot webdriver.</value>
        public ITakesScreenshot Screenshot
        {
            get
            {
                return (ITakesScreenshot)WebDriver;
            }
        }

        /// <summary>
        /// Obtém componente Wait.
        /// </summary>
        /// <value>
        /// O componente Wait.
        /// </value>
        public IWait<IWebDriver> Wait
        {
            get { return _wait; }
        }

        /// <summary>
        /// Obtém ou define ações de scripts.
        /// </summary>
        /// <value>
        /// Ações de scripts.
        /// </value>
        public IAcoesDeScript Script
        {
            get
            {
                return _acoesDeScript;
            }
        }

        /// <summary>
        /// Obtém ou define ações de espera.
        /// </summary>
        /// <value>
        /// Ações de espera.
        /// </value>
        public IAcoesDeEspera Espera
        {
            get
            {
                return _acoesDeEspera;
            }
        }

        /// <summary>
        /// Obtém ou define ações de teclado.
        /// </summary>
        /// <value>
        /// Ações de teclado.
        /// </value>
        public IAcoesDeTeclado Teclado
        {
            get
            {
                return _acoesDeTeclado;
            }
        }

        /// <summary>
        /// Obtém ou define ações de mouse.
        /// </summary>
        /// <value>
        /// Ações de mouse.
        /// </value>
        public IAcoesDeMouse Mouse
        {
            get
            {
                return _acoesDeMouse;
            }
        }

        /// <summary>
        /// Obtém ou define ações de document.
        /// </summary>
        /// <value>
        /// Ações de document.
        /// </value>
        public IAcoesDeDocument Document
        {
            get
            {
                return _acoesDeDocument;
            }
        }

        #endregion

        #region "MÉTODOS PUBLICO"

        /// <summary>
        /// Abrir a URL.
        /// </summary>
        /// <param name="url">A URL do produto.</param>
        public void AbrirUrl(string url)
        {
            var uri = new Uri(url);
            WebDriver.Navigate().GoToUrl(uri);
        }

        /// <summary>
        /// Abrir a tela inicial da aplicação.
        /// </summary>
        public void AbrirTelaDeAplicacao()
        {
            var url = new Uri(ConfiguracaoDeTela.UrlAplicacao);
            WebDriver.Navigate().GoToUrl(url);
            Espera.AguardePaginaCarregada();
        }

        /// <summary>
        /// Abrir a tela inicial do login.
        /// </summary>
        public void AbrirTelaDeLogin()
        {
            var url = new Uri(ConfiguracaoDeTela.UrlLogin);
            WebDriver.Navigate().GoToUrl(url);
            Espera.AguardePaginaCarregada();
        }

        /// <summary>
        /// Crie o webdriver.
        /// </summary>
        public void CrieWebDriver()
        {
            _webDriver = CrieWebDriver(ConfiguracaoDeTela);
        }

        /// <summary>
        /// Salva o screenshot da tela.
        /// O nome do arquivo segue o padrão:
        ///      "NomeDoCenarioDeTeste.Numeracao.NomeDoArquivo.Browser.Atual.png".
        /// </summary>
        /// <param name="nomeDoArquivo">O nome do arquivo.</param>
        /// <param name="diretorioDeImagens">O diretório de imagens.</param>
        /// <param name="contexto">O contexto de teste.</param>
        public void SalvarScreenshot(string nomeDoArquivo, string diretorioDeImagens, ContextoDeTeste contexto)
        {
            SalvarScreenshot(
                nomeDoArquivo,
                diretorioDeImagens,
                contexto,
                diretorio =>
                {
                    var screenshot = Screenshot.GetScreenshot();
                    screenshot.SaveAsFile(diretorio, ImageFormat.Png);
                });
        }

        /// <summary>
        /// Salva o screenshot da tela do elemento específico.
        /// O nome do arquivo segue o padrão:
        ///      "NomeDoCenarioDeTeste.Numeracao.NomeDoArquivo.Browser.Atual.png".
        /// </summary>
        /// <param name="nomeDoArquivo">O nome do arquivo.</param>
        /// <param name="diretorioDeImagens">O diretório de imagens.</param>
        /// <param name="contexto">O contexto de teste.</param>
        /// <param name="cssSeletor">O css seletor do elemento para tirar o screenshot.</param>
        public void SalvarScreenshotEspecifico(string nomeDoArquivo, string diretorioDeImagens, ContextoDeTeste contexto, string cssSeletor)
        {
            var seletor = By.CssSelector(cssSeletor);
            var el = WebDriver.FindElement(seletor);
            var area = new Rectangle(el.Location, el.Size);

            SalvarScreenshotEspecifico(nomeDoArquivo, diretorioDeImagens, contexto, area);
        }

        /// <summary>
        /// Salva o screenshot da tela co tamanho específico.
        /// O nome do arquivo segue o padrão:
        ///      "NomeDoCenarioDeTeste.Numeracao.NomeDoArquivo.Browser.Atual.png".
        /// </summary>
        /// <param name="nomeDoArquivo">O nome do arquivo.</param>
        /// <param name="diretorioDeImagens">O diretório de imagens.</param>
        /// <param name="contexto">O contexto de teste.</param>
        /// <param name="area">O tamanho da área a ser tirado o screenshot.</param>
        public void SalvarScreenshotEspecifico(string nomeDoArquivo, string diretorioDeImagens, ContextoDeTeste contexto, Rectangle area)
        {
            //// Ficar atento ao tamanho da imagem original com o tamanho área de clonagem.

            SalvarScreenshot(
                nomeDoArquivo,
                diretorioDeImagens,
                contexto,
                diretorio =>
                {
                    var screenshot = Screenshot.GetScreenshot();

                    using (var imagemOriginal = new Bitmap(new MemoryStream(screenshot.AsByteArray)))
                    using (var novaImagem = new Bitmap(area.Width, area.Height))
                    using (var grafico = Graphics.FromImage(novaImagem))
                    {
                        grafico.DrawImage(imagemOriginal, new Rectangle(0, 0, novaImagem.Width, novaImagem.Height), area, GraphicsUnit.Pixel);
                        novaImagem.Save(diretorio, ImageFormat.Png);
                    }
                });
        }

        /// <summary>
        /// Salva o screenshot da tela no diretório de erros.
        /// </summary>
        /// <param name="nomeDoArquivo">O nome do arquivo.</param>
        public void SalvarScreenshotErro(string nomeDoArquivo)
        {
            if (!ScreenshotHabilitado())
            {
                return;
            }

            if (!Directory.Exists(LogDeErros.DIRETORIO_SCREENSHOTS_ERROS))
            {
                Directory.CreateDirectory(LogDeErros.DIRETORIO_SCREENSHOTS_ERROS);
            }

            var arquivo = string.Format(
                CultureInfo.InvariantCulture,
                "{0}{1}_{2}.png",
                LogDeErros.DIRETORIO_SCREENSHOTS_ERROS,
                nomeDoArquivo,
                DateTime.Now.ToString("yyyy-MM-dd_HH-mm-ss", CultureInfo.InvariantCulture));

            var screenshot = Screenshot.GetScreenshot();
            screenshot.SaveAsFile(arquivo, ImageFormat.Png);
        }

        /// <summary>
        /// Compare as imagens do diretório.
        /// </summary>
        /// <param name="contexto">O contexto de cenários de testes.</param>
        /// <param name="diretorioDeImagens">O diretório de imagens.</param>
        public void CompararScreenshot(ContextoDeTeste contexto, string diretorioDeImagens)
        {
            var sufixoBuscado = string.Concat(contexto.CenarioAtual, "*.atual.png");

            CompararScreenshot(diretorioDeImagens, sufixoBuscado);
        }

        /// <summary>
        /// Compare as imagens do diretório.
        /// </summary>
        /// <param name="diretorioDeImagens">O diretório de imagens.</param>
        public void CompararScreenshot(string diretorioDeImagens)
        {
            CompararScreenshot(diretorioDeImagens, "*.atual.png");
        }

        /// <summary>
        /// Redirecione iframe.
        /// </summary>
        /// <param name="cssSeletorIframe">O css seletor iframe.</param>
        public void RedirecioneIFrame(string cssSeletorIframe)
        {
            try
            {
                var iframe = WebDriver.FindElement(By.CssSelector(cssSeletorIframe));
                if (iframe != null)
                {
                    WebDriver.SwitchTo().Frame(iframe);
                }
            }
            catch (Exception e)
            {
                throw new WebDriverException(e.Message);
            }
        }

        /// <summary>
        /// Tratar a limpeza de componentes do webdriver.
        /// </summary>
        public void Dispose()
        {
            if (_webDriver != null)
            {
                _webDriver.Quit();
                _webDriver.Dispose();
            }
        }

        #endregion

        #region "MÉTODOS DE APOIO"

        private IWebDriver CrieWebDriver(ConfiguracaoDeTela configuracaoDeTela)
        {
            switch (configuracaoDeTela.Browser)
            {
                case EnumBrowsers.CHROME:
                    return CrieDriverChrome(configuracaoDeTela);

                case EnumBrowsers.CHROME_HEADLESS:
                    return CrieDriverChrome(configuracaoDeTela, "--headless", "--disable-gpu", "--hide-scrollbars", "--no-sandbox");

                case EnumBrowsers.PHANTOMJS:
                    return CrieDriverPhantomJS(configuracaoDeTela);

                case EnumBrowsers.IE:
                    new NotImplementedException("Browser não implementado.");
                    return null;

                case EnumBrowsers.FIREFOX:
                    new NotImplementedException("Browser não implementado.");
                    return null;

                default:
                    throw new ArgumentException(string.Concat("O browser ", configuracaoDeTela.Browser.ToString(), " não é suportado pelos testes de interface gráfica."));
            }
        }

        private ChromeDriver CrieDriverChrome(ConfiguracaoDeTela configuracaoDeTela, params string[] argumentos)
        {
            var options = CrieChromeOptions(argumentos);

            var driverChrome = new ChromeDriver(configuracaoDeTela.PastaDeBinarios, options);
         
            ////driverChrome.Manage().Window.Maximize();
            driverChrome.Manage().Window.Size = _resolucao;

            return driverChrome;
        }

        private ChromeOptions CrieChromeOptions(params string[] parametros)
        {
            var args = new[] { "allow-running-insecure-content", "ignore-certificate-errors" };
            var argumentos = args.Concat(parametros);

            var options = new ChromeOptions();
            options.AddArguments(argumentos);

            return options;
        }

        private PhantomJSDriver CrieDriverPhantomJS(ConfiguracaoDeTela configuracaoDeTela)
        {
            var options = new PhantomJSOptions();
            options.AddAdditionalCapability("takesScreenshot", false);

            var service = PhantomJSDriverService.CreateDefaultService(configuracaoDeTela.PastaDeBinarios);
            service.IgnoreSslErrors = true;
            service.ProxyType = configuracaoDeTela.ProxyType;
            service.SslProtocol = "any";

            var driverPhantomJS = new PhantomJSDriver(service, options);
            ////driverPhantomJS.Manage().Window.Maximize();
            driverPhantomJS.Manage().Window.Size = _resolucao;

            return driverPhantomJS;
        }

        private void DefinaTimeoutsImplicitos()
        {
            WebDriver.Manage().Timeouts().SetPageLoadTimeout(ConfiguracaoDeTela.Timeout);
            WebDriver.Manage().Timeouts().SetScriptTimeout(ConfiguracaoDeTela.Timeout);
            WebDriver.Manage().Timeouts().ImplicitlyWait(ConfiguracaoDeTela.Timeout);
        }

        private string ObtenhaSufixoBrowser()
        {
            switch (ConfiguracaoDeTela.Browser)
            {
                case EnumBrowsers.CHROME:
                    return "ch";

                case EnumBrowsers.CHROME_HEADLESS:
                    return "hl";

                case EnumBrowsers.PHANTOMJS:
                    return "ph";

                case EnumBrowsers.IE:
                    return "ie";

                case EnumBrowsers.FIREFOX:
                    return "ff";

                default:
                    return ConfiguracaoDeTela.Browser.ToString();
            }
        }

        private void SalvarScreenshot(string nomeDoArquivo, string diretorioDeImagens, ContextoDeTeste contexto, Action<string> salveScreenshot)
        {
            if (!ScreenshotHabilitado())
            {
                return;
            }

            if (!Directory.Exists(diretorioDeImagens))
            {
                Directory.CreateDirectory(diretorioDeImagens);
            }

            var cenarioDeTeste = contexto.CenarioAtual;
            var screenshotCount = contexto.ObtenhaContador(cenarioDeTeste);

            ++screenshotCount;
            contexto.AtualizeContador(cenarioDeTeste, screenshotCount);

            var identificacaoDeCenario = screenshotCount.ToString("000", CultureInfo.InvariantCulture);
            var browser = ObtenhaSufixoBrowser();
            var tipoDeAmbiente = ConfiguracaoDeTela.TipoDeAmbiente.ToString().ToLower(CultureInfo.InvariantCulture);

            var caminhoDoArquivo = Path.Combine(diretorioDeImagens, string.Format(CultureInfo.InvariantCulture, "{0}.{1}.{2}.{3}.{4}.atual.png", cenarioDeTeste, identificacaoDeCenario, nomeDoArquivo, browser, tipoDeAmbiente));

            try
            {
                salveScreenshot(caminhoDoArquivo);
            }
            catch (Exception ex)
            {
                var mensagem = string.Concat("Não foi possível salvar a imagem do caso de teste '", cenarioDeTeste, " no caminho ", caminhoDoArquivo, "'.\n", ex.Message);
                throw new ArgumentException(mensagem);
            }
        }

        private void CompararScreenshot(string diretorioDeImagens, string sufixoBuscado)
        {
            if (!ScreenshotHabilitado())
            {
                return;
            }

            var numeroDeErros = 0;

            if (!Directory.Exists(diretorioDeImagens))
            {
                Assert.Fail("Diretório de imagens não existe.", diretorioDeImagens);
            }

            var arquivos = Directory.EnumerateFiles(diretorioDeImagens, sufixoBuscado);

            foreach (var nomeArquivo in arquivos)
            {
                var arquivoAtual = Path.Combine(diretorioDeImagens, nomeArquivo);
                var arquivoOrigem = arquivoAtual.Substring(0, arquivoAtual.Length - ".atual.png".Length) + ".baseline.png";
                var arquivoDiff = arquivoAtual.Substring(0, arquivoAtual.Length - ".atual.png".Length) + ".diff.png";

                if (!File.Exists(arquivoOrigem))
                {
                    if (ConfiguracaoDeTela.TipoDeAmbiente == EnumTipoDeAmbiente.VM)
                    {
                        arquivoOrigem = arquivoAtual.Substring(0, arquivoAtual.Length - ".atual.png".Length) + ".novo.png";
                    }

                    File.Move(arquivoAtual, arquivoOrigem);
                    continue;
                }

                using (var imagemOrigem = new MagickImage(arquivoOrigem))
                using (var imagemAtual = new MagickImage(arquivoAtual))
                using (var imagemDiferente = new MagickImage())
                {
                    var diferenca = imagemOrigem.Compare(imagemAtual, ErrorMetric.Absolute, imagemDiferente);

                    //// Verifica se existe diferença de imagem.
                    if (diferenca > 0)
                    {
                        numeroDeErros++;
                        imagemDiferente.Write(arquivoDiff);
                        continue;
                    }

                    File.Delete(arquivoDiff);
                    File.Delete(arquivoAtual);
                }
            }

            Assert.AreEqual(0, numeroDeErros, "Existem imagens diferente do esperado.");
        }

        private bool ScreenshotHabilitado()
        {
            //// Para os prints de tela será utilizado apenas no PhantomJs.
            //// Existem problemas ao utilizar outros navegadores por não tirar screenshot da tela inteira. 
            return ConfiguracaoDeTela.UtilizaScreenshot && (ConfiguracaoDeTela.Browser == EnumBrowsers.CHROME_HEADLESS || ConfiguracaoDeTela.Browser == EnumBrowsers.PHANTOMJS);
            ////return true;
        }

        #endregion
    }
}
