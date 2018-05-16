using LG.LMS.TestesDeInterface.Infraestrutura;
using LG.LMS.TestesDeInterface.PageModel.Administracao;
using LG.LMS.TestesDeInterface.PageModel.Administracao.Plataforma.GestaoItemDeDespesa;
using LG.LMS.TestesDeInterface.PageModel.Portal;
using NUnit.Framework;

namespace LG.LMS.TestesDeInterface.Testes.Administracao.Plataforma
{
    [TestFixture(Category = "Administracao")]
    public class TestesDeGestaoItemDeDespesa : TestesDeInterfaceBase
    {
        private GestaoDeDespesaInicioUI _gestaoDeDespesaInicioUI;
        private GestaoDeDespesaModel _modelParaCadastro;
        private GestaoDeDespesaModel _modelParaAtualizacao;

        [TestFixtureSetUp]
        public void FixtureSetUp()
        {
            var portalUI = new PortalUI(ComponenteDeTela);
            portalUI.InicializarElementos();

            var adminUI = new AdministracaoUI(ComponenteDeTela, portalUI);
            adminUI.InicializarElementos();

            _gestaoDeDespesaInicioUI = new GestaoDeDespesaInicioUI(ComponenteDeTela, adminUI);
            _gestaoDeDespesaInicioUI.AbrirFuncionalidade();

            _modelParaCadastro = CrieGestaoDeDespesa("Notebook");
            _modelParaAtualizacao = CrieGestaoDeDespesa("Impressora");
        }

        [Test]
        public void TestaCT0001CadastroDeDespesa()
        {
            contexto.AdicioneCenario("Cadastro");

            SalvarScreenshotFuncionalidade("Inicio");

            _gestaoDeDespesaInicioUI.BotaoNovo.Click();
            SalvarScreenshotFuncionalidade("Novo");

            var gestaoDeDespesaEdicaoUI = new GestaoDeDespesaEdicaoUI(ComponenteDeTela);
            gestaoDeDespesaEdicaoUI.InicializarElementos();
            gestaoDeDespesaEdicaoUI.PreencheCampoNaTela(_modelParaCadastro);

            SalvarScreenshotFuncionalidade("DadosPreenchidos");

            gestaoDeDespesaEdicaoUI.BotaoSalvar.Click();
            SalvarScreenshotEspecifico(contexto, "MensagemDeConfirmacao", "#popup_container");

            gestaoDeDespesaEdicaoUI.ClickConfirmar();
            SalvarScreenshotFuncionalidade("DespesaCadastrada");

            CompararScreenshot();
        }

        [Test]
        public void TestaCT0002AtualizacaoDeDespesa()
        {
            contexto.AdicioneCenario("Atualizacao");

            SalvarScreenshotFuncionalidade("Inicio");

            _gestaoDeDespesaInicioUI.CliqueEditar(_modelParaCadastro.Titulo);
            SalvarScreenshotFuncionalidade("Edicao");

            var gestaoDeDespesaEdicaoUI = new GestaoDeDespesaEdicaoUI(ComponenteDeTela);
            gestaoDeDespesaEdicaoUI.InicializarElementos();
            gestaoDeDespesaEdicaoUI.PreencheCampoNaTela(_modelParaAtualizacao);

            SalvarScreenshotFuncionalidade("DadosAtualizado");

            gestaoDeDespesaEdicaoUI.BotaoSalvar.Click();
            SalvarScreenshotEspecifico(contexto, "MensagemDeConfirmacao", "#popup_container");

            gestaoDeDespesaEdicaoUI.ClickConfirmar();
            SalvarScreenshotFuncionalidade("DespesaAtualizada");

            CompararScreenshot();
        }

        [Test]
        public void TestaCT0003ExclusaoDeDespesa()
        {
            contexto.AdicioneCenario("Exclusao");

            SalvarScreenshotFuncionalidade("Inicio");

            _gestaoDeDespesaInicioUI.CliqueExcluir(_modelParaAtualizacao.Titulo);
            SalvarScreenshotEspecifico(contexto, "MensagemDeConfirmacao", "#popup_container");

            _gestaoDeDespesaInicioUI.ClickConfirmar();
            SalvarScreenshotFuncionalidade("DespesaExcluida");

            CompararScreenshot();
        }

        protected override ContextoDeTeste CrieContextoDeTeste()
        {
            return new ContextoDeTeste("Administracao", "Plataforma", "GestaoDeItemDeDespesa");
        }

        private GestaoDeDespesaModel CrieGestaoDeDespesa(string titulo)
        {
            var gestaoDeDespesa = new GestaoDeDespesaModel
            {
                Titulo = titulo
            };

            return gestaoDeDespesa;
        }
    }
}
