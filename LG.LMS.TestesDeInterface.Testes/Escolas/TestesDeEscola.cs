using LG.LMS.TestesDeInterface.Infraestrutura;
using LG.LMS.TestesDeInterface.PageModel.Escolas;
using LG.LMS.TestesDeInterface.PageModel.Portal;
using NUnit.Framework;
using OpenQA.Selenium;

namespace LG.LMS.TestesDeInterface.Testes.Escolas
{
    [TestFixture(Category = "Escolas")]
    public class TestesDeEscola : TestesDeInterfaceBase
    {
        private EscolaUI _escolaUI;

        [TestFixtureSetUp]
        public void FixtureSetUp()
        {
            var portalUI = new PortalUI(ComponenteDeTela);
            portalUI.InicializarElementos();

            _escolaUI = new EscolaUI(ComponenteDeTela, portalUI);
            _escolaUI.AbrirFuncionalidade();
        }

        [Test]
        public void TestaCT0001TelaInicialEscola()
        {
            contexto.AdicioneCenario("Escolas");

            _escolaUI.Escola.Click();

            ComponenteDeTela.Espera.AguardeElementoVisivel(By.Id("listagem"));

            SalvarScreenshotEspecifico(contexto, "Listagem", "#listagem");
            CompararScreenshot();
        }

        [Test]
        public void TestaCT0002TelaInicialTodasAsTrilhas()
        {
            ExecuteCenarioTelaInicialTrilhas("TodasAsTrilhas", _escolaUI.TodasAsTrilhas);
        }

        [Test]
        public void TestaCT0003TelaInicialMinhasTrilhas()
        {
            ExecuteCenarioTelaInicialTrilhas("MinhasTrilhas", _escolaUI.MinhasTrilhas);
        }

        protected override Infraestrutura.ContextoDeTeste CrieContextoDeTeste()
        {
            return new ContextoDeTeste("Escolas", string.Empty, string.Empty);
        }

        private void ExecuteCenarioTelaInicialTrilhas(string cenario, IWebElement elemento)
        {
            contexto.AdicioneCenario(cenario);

            elemento.Click();

            ComponenteDeTela.Espera.AguardeElementoVisivel(By.Id("trilhas-listagem"));

            SalvarScreenshotEspecifico(contexto, "Listagem", "section > .row");
            CompararScreenshot();
        }
    }
}
