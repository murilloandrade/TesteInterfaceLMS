using LG.LMS.TestesDeInterface.Infraestrutura;
using LG.LMS.TestesDeInterface.PageModel.Escolas;
using LG.LMS.TestesDeInterface.PageModel.Portal;
using NUnit.Framework;

namespace LG.LMS.TestesDeInterface.Testes.Escolas
{
    [TestFixture(Category = "Escolas")]
    public class TestesDeTrilhas : TestesDeInterfaceBase
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
        public void TestaCT0001AcessarTrilhas()
        {
            contexto.AdicioneCenario("Trilhas");

            _escolaUI.AcessarPrimeiraTrilha();
            SalvarScreenshotFuncionalidade("Inicio");

            var trilhaUI = new TrilhaUI(ComponenteDeTela, _escolaUI);
            trilhaUI.ClickDetalhes();
            SalvarScreenshotFuncionalidade("Detalhes");

            var detalhesDaTrilhaUI = new DetalhesDaTrilhaUI(ComponenteDeTela);
            detalhesDaTrilhaUI.AcessarPrimeiroCurso();
            SalvarScreenshotFuncionalidade("DetalhesDoCurso");

            CompararScreenshot();
        }

        protected override ContextoDeTeste CrieContextoDeTeste()
        {
            return new ContextoDeTeste("Escolas", "Trilhas", string.Empty);
        }
    }
}
