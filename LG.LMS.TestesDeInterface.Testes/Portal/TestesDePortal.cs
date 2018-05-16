using LG.LMS.TestesDeInterface.Infraestrutura;
using LG.LMS.TestesDeInterface.PageModel.Portal;
using NUnit.Framework;
using OpenQA.Selenium;

namespace LG.LMS.TestesDeInterface.Testes.Portal
{
    [TestFixture(Category = "Portal")]
    public class TestesDePortal : TestesDeInterfaceBase
    {
        private PortalUI _portalUI;

        [TestFixtureSetUp]
        public void FixtureSetUp()
        {
            _portalUI = new PortalUI(ComponenteDeTela);
            _portalUI.AbrirFuncionalidade();
        }

        [Test]
        public void TestaCT0001TelaInicialHome()
        {
            contexto.AdicioneCenario("Home");

            _portalUI.Home.Click();

            AguardePainelDeFuncionalidade();
            ComponenteDeTela.Espera.AguardeElementoVisivel(By.CssSelector("#carrossel-wrapper"));
            ComponenteDeTela.Espera.AguardeElementoVisivel(By.CssSelector("#home-gallery"));
            ComponenteDeTela.Espera.AguardeElementoVisivel(By.CssSelector("#main-gallery"));
            ComponenteDeTela.Espera.AguardeElementoVisivel(By.CssSelector("#sidebanners-container"));

            ComponenteDeTela.Espera.AguardeElementoVisivel(By.CssSelector("#calendario-geral"));
            ComponenteDeTela.Espera.AguardeElementoVisivel(By.CssSelector("#eguru_widget-atividades"));

            ComponenteDeTela.Espera.AguardeElementoVisivel(By.CssSelector(".cards-novidades"));
            ComponenteDeTela.Espera.AguardeElementoVisivel(By.CssSelector("#listagem-novidades"));

            ComponenteDeTela.Espera.AguardeElementoVisivel(By.CssSelector(".quiz-assuntos"));
            ComponenteDeTela.Espera.AguardeElementoVisivel(By.CssSelector("#quiz"));
            ComponenteDeTela.Espera.AguardeElementoVisivel(By.CssSelector("#assuntos"));
            ComponenteDeTela.Espera.AguardeIntervaloDeTempo(2);

            SalvarScreenshotEspecifico(contexto, "Carrossel", "#carrossel-wrapper");
            SalvarScreenshotEspecifico(contexto, "Calendario", "#calendario-geral");

            SalvarScreenshotEspecifico(contexto, "Novidades", ".cards-novidades");
            SalvarScreenshotEspecifico(contexto, "Assuntos", ".quiz-assuntos");

            SalvarScreenshotFuncionalidade("Home");

            CompararScreenshot();
        }

        [Test]
        public void TestaCT0002TelaInicialEscolas()
        {
            contexto.AdicioneCenario("Escolas");

            _portalUI.Escolas.Click();

            AguardePainelDeFuncionalidade();
            ComponenteDeTela.Espera.AguardeElementoVisivel(By.CssSelector("#listagem-escolas"));
            ComponenteDeTela.Espera.AguardeIntervaloDeTempo(2);

            SalvarScreenshotFuncionalidadeEComparar("Inicio");
        }

        [Test]
        public void TestaCT0003TelaInicialOficinas()
        {
            contexto.AdicioneCenario("Oficinas");

            _portalUI.Oficinas.Click();

            AguardePainelDeFuncionalidade();
            ComponenteDeTela.Espera.AguardeElementoVisivel(By.CssSelector("#subcategorias"));
            ComponenteDeTela.Espera.AguardeElementoVisivel(By.CssSelector("#listagem"));
            ComponenteDeTela.Espera.AguardeElementoVisivel(By.CssSelector("#carregar-mais"));
            ComponenteDeTela.Espera.AguardeElementoVisivel(By.CssSelector("[data-id='1975']"));
            ComponenteDeTela.Espera.AguardeIntervaloDeTempo(2);

            SalvarScreenshotFuncionalidadeEComparar("Inicio");
        }

        [Test]
        public void TestaCT0004TelaInicialInstitucional()
        {
            contexto.AdicioneCenario("Institucional");

            _portalUI.Institucional.Click();

            AguardePainelDeFuncionalidade();
            ComponenteDeTela.Espera.AguardeElementoVisivel(By.CssSelector("#institucional"));
            ComponenteDeTela.Espera.AguardeIntervaloDeTempo(2);

            SalvarScreenshotFuncionalidadeEComparar("Inicio");
        }

        [Test]
        public void TestaCT0005TelaInicialTutoria()
        {
            contexto.AdicioneCenario("Tutoria");

            _portalUI.Tutoria.Click();

            AguardePainelDeFuncionalidade();
            ComponenteDeTela.Espera.AguardeElementoVisivel(By.CssSelector("#listagem-cursos"));
            ComponenteDeTela.Espera.AguardeIntervaloDeTempo(2);

            SalvarScreenshotFuncionalidadeEComparar("Inicio");
        }

        [Test]
        public void TestaCT0006TelaInicialAdministracao()
        {
            contexto.AdicioneCenario("Administracao");

            _portalUI.Admin.Click();

            AguardePainelDeFuncionalidade();
            ComponenteDeTela.Espera.AguardeElementoVisivel(By.CssSelector("#relatorios"));
            ComponenteDeTela.Espera.AguardeIntervaloDeTempo(2);

            SalvarScreenshotEspecifico(contexto, "Cabecalho", ".body-wrapper > header");
            SalvarScreenshotEspecifico(contexto, "Menu", ".body-wrapper > nav");
            SalvarScreenshotFuncionalidade("Inicio");

            CompararScreenshot();
        }

        protected override Infraestrutura.ContextoDeTeste CrieContextoDeTeste()
        {
            return new ContextoDeTeste("Portal", string.Empty, string.Empty);
        }

        private void ExecuteTeste(string cenario, IWebElement elemento, string cssSeletorAguardeElemento)
        {
            contexto.AdicioneCenario(cenario);

            elemento.Click();
            AguardePainelDeFuncionalidade();
            ComponenteDeTela.Espera.AguardeElementoVisivel(By.CssSelector(cssSeletorAguardeElemento));
            ComponenteDeTela.Espera.AguardeIntervaloDeTempo(2);

            SalvarScreenshotFuncionalidadeEComparar("Inicio");
        }
    }
}
