using LG.LMS.TestesDeInterface.Infraestrutura;
using LG.LMS.TestesDeInterface.PageModel.Institucional;
using LG.LMS.TestesDeInterface.PageModel.Portal;
using NUnit.Framework;

namespace LG.LMS.TestesDeInterface.Testes.Institucional
{
    [TestFixture(Category = "Institucional")]
    public class TestesDeInstitucional : TestesDeInterfaceBase
    {
        private InstitucionalUI _institucionalUI;

        [TestFixtureSetUp]
        public void FixtureSetUp()
        {
            var portalUI = new PortalUI(ComponenteDeTela);
            portalUI.InicializarElementos();

            _institucionalUI = new InstitucionalUI(ComponenteDeTela, portalUI);
            _institucionalUI.AbrirFuncionalidade();
        }

        [Test]
        public void TestaCT0001TelaInicial()
        {
            contexto.AdicioneCenario("Institucional");

            SalvarScreenshotFuncionalidade("Inicio");
            SalvarScreenshotEspecifico(contexto, "Missao", ".well.well-cliente");

            _institucionalUI.Manifesto.Click();
            SalvarScreenshotEspecifico(contexto, "Manifesto", "#manifesto");

            _institucionalUI.GestaoPessoalDoConhecimento.Click();
            SalvarScreenshotEspecifico(contexto, "GestaoPessoalDoConhecimento", "#gestao");

            _institucionalUI.Principios.Click();
            SalvarScreenshotEspecifico(contexto, "Principios", "#principios");

            CompararScreenshot();
        }

        protected override ContextoDeTeste CrieContextoDeTeste()
        {
            return new ContextoDeTeste("Institucional", string.Empty, string.Empty);
        }
    }
}
