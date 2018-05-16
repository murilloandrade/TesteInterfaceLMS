using System;
using System.Collections.Generic;
using System.IO;
using LG.LMS.TestesDeInterface.Infraestrutura;
using LG.LMS.TestesDeInterface.PageModel.Login;
using NUnit.Framework;
using OpenQA.Selenium;

namespace LG.LMS.TestesDeInterface.Testes.Login
{
    [TestFixture(Category = "Login")]
    public class TestesDeLogin
    {
        private ComponenteDeTela _componenteDeTela;
        private ContextoDeTeste _contexto;

        [TestFixtureSetUp]
        public void Inicializa()
        {
            var appConfig = string.Concat(AppDomain.CurrentDomain.BaseDirectory, @"\..\..\LG.LMS.TestesDeInterface.Testes\App.config");

            _componenteDeTela = FabricaDeComponenteDeTela.Crie(appConfig);
            _contexto = new ContextoDeTeste("Login", string.Empty, string.Empty);
        }

        [TestFixtureTearDown]
        public void Finaliza()
        {
            _componenteDeTela.Dispose();
        }

        [Test]
        public void TestaCT0001EfetueLogin()
        {
            _contexto.AdicioneCenario("Efetuar login");

            var login = new LoginUI(_componenteDeTela);

            login.AbrirFuncionalidade();
            _componenteDeTela.Espera.AguardeIntervaloDeTempo(1);
            SalvarScreenshot("TelaInicial");

            login.EfetueLogin("admin", "senha1234");

            _componenteDeTela.Espera.AguardeElementoVisivel(By.CssSelector("#container-principal"));
            _componenteDeTela.Espera.AguardeElementoVisivel(By.CssSelector(".main-header"));

            SalvarScreenshotEspecifico("PortalCabecalho", ".main-header");

            CompararScreenshot();
        }

        private void SalvarScreenshot(string nomeDoArquivo)
        {
            var diretorioDeImagens = CrieDiretorioDeImagens(_contexto);
            _componenteDeTela.SalvarScreenshot(nomeDoArquivo, diretorioDeImagens, _contexto);
        }

        private void SalvarScreenshotEspecifico(string nomeDoArquivo, string cssSeletor)
        {
            var diretorioDeImagens = CrieDiretorioDeImagens(_contexto);
            _componenteDeTela.SalvarScreenshotEspecifico(nomeDoArquivo, diretorioDeImagens, _contexto, cssSeletor);
        }

        private void CompararScreenshot()
        {
            var diretorioDeImagens = CrieDiretorioDeImagens(_contexto);
            _componenteDeTela.CompararScreenshot(_contexto, diretorioDeImagens);
        }

        protected string CrieDiretorioDeImagens(ContextoDeTeste contexto)
        {
            var diretorios = new List<string>
            {
                Environment.CurrentDirectory, 
                "../../Screenshots", 
                contexto.Projeto,
                contexto.Modulo,
                contexto.Funcionalidade
            };

            var diretorioDeImagens = Path.Combine(diretorios.ToArray());
            return diretorioDeImagens;
        }
    }
}
