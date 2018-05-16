using LG.LMS.TestesDeInterface.Infraestrutura;
using LG.LMS.TestesDeInterface.PageModel.Administracao;
using LG.LMS.TestesDeInterface.PageModel.Portal;
using NUnit.Framework;

namespace LG.LMS.TestesDeInterface.Testes.Administracao
{
    [TestFixture(Category = "Administracao")]
    public class TestesDeAdministracao : TestesDeInterfaceBase
    {
        private AdministracaoUI _adminUI;

        [TestFixtureSetUp]
        public void FixtureSetUp()
        {
            var portalUI = new PortalUI(ComponenteDeTela);
            portalUI.InicializarElementos();

            _adminUI = new AdministracaoUI(ComponenteDeTela, portalUI);
            _adminUI.AbrirFuncionalidade();
        }

        [Test]
        public void TestaCT0001TelaInicial()
        {
            contexto.AdicioneCenario("Administracao");

            _adminUI.Inicio.Click();
            SalvarScreenshotFuncionalidadeEComparar("Inicio");
        }

        [Test]
        public void TestaCT0002TelaInicialQuestoesCertificadas()
        {
            contexto.AdicioneCenario("QuestoesCertificadas");

            _adminUI.CliqueQuestoesCertificadas();
            SalvarScreenshotFuncionalidadeEComparar("Inicio");
        }

        protected override ContextoDeTeste CrieContextoDeTeste()
        {
            return new ContextoDeTeste("Administracao", string.Empty, string.Empty);
        }
    }
}
