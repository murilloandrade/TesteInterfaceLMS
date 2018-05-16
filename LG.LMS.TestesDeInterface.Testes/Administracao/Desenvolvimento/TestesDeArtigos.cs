//-----------------------------------------------------------------------
// <copyright file="TestesDeArtigos.cs" company="LG Sistemas">
//     Copyright © LG Sistemas. All rights reserved.
//     TODOS OS DIREITOS RESERVADOS.
// </copyright>
//-----------------------------------------------------------------------

using LG.LMS.TestesDeInterface.Infraestrutura;
using LG.LMS.TestesDeInterface.PageModel.Administracao;
using LG.LMS.TestesDeInterface.PageModel.Administracao.Desenvolvimento.Artigos;
using LG.LMS.TestesDeInterface.PageModel.Portal;
using NUnit.Framework;

namespace LG.LMS.TestesDeInterface.Testes.Administracao.Desenvolvimento
{
    [TestFixture(Category = "Aministracao")]
    public class TestesDeArtigos : TestesDeInterfaceBase
    {
        private ArtigosInicioUI _artigosInicioUI;
        private ArtigosModel _modelParaCadastro;
        private ArtigosModel _modelParaAtualizacao;

        [TestFixtureSetUp]
        public void FixtureSetUp()
        {
            var portalUI = new PortalUI(ComponenteDeTela);
            portalUI.InicializarElementos();

            var adminUI = new AdministracaoUI(ComponenteDeTela, portalUI);
            adminUI.InicializarElementos();

            _artigosInicioUI = new ArtigosInicioUI(ComponenteDeTela, adminUI);
            _artigosInicioUI.AbrirFuncionalidade();

            _modelParaCadastro = CrieArtigoParaCadastro();
            _modelParaAtualizacao = CrieArtigoParaAtualizacao();
        }

        [Test]
        public void TestaCT0001CadastroDeArtigo()
        {
            contexto.AdicioneCenario("Cadastro");

            SalvarScreenshotFuncionalidade("Inicio");

            _artigosInicioUI.CliqueCadastrar();
            SalvarScreenshotFuncionalidade("Novo");

            var artigosEdicaoUI = new ArtigosEdicaoUI(ComponenteDeTela);
            artigosEdicaoUI.InicializarElementos();
            artigosEdicaoUI.PreencheCampoNaTela(_modelParaCadastro);

            SalvarScreenshotFuncionalidade("DadosPreenchidos");

            artigosEdicaoUI.CliqueSalvar();

            artigosEdicaoUI.CliqueCancelar();
            SalvarScreenshotFuncionalidade("ArtigoCadastrado");

            CompararScreenshot();
        }

        [Test]
        public void TestaCT0002AtualizacaoDeArtigo()
        {
            contexto.AdicioneCenario("Atualizacao");

            SalvarScreenshotFuncionalidade("Inicio");

            _artigosInicioUI.CliqueEditar();

            ComponenteDeTela.Espera.AguardeIntervaloDeTempo(1);

            SalvarScreenshotFuncionalidade("Edicao");

            var artigosEdicaoUI = new ArtigosEdicaoUI(ComponenteDeTela);
            artigosEdicaoUI.InicializarElementos();
            artigosEdicaoUI.PreencheCampoNaTela(_modelParaAtualizacao);
            ComponenteDeTela.Espera.AguardeIntervaloDeTempo(1);

            SalvarScreenshotFuncionalidade("DadosAtualizado");

            artigosEdicaoUI.CliqueSalvar();

            artigosEdicaoUI.CliqueCancelar();
            SalvarScreenshotFuncionalidade("ArtigoAtualizado");

            CompararScreenshot();
        }

        [Test]
        public void TestaCT0003ExclusaoDeArtigo()
        {
            contexto.AdicioneCenario("Exclusao");

            SalvarScreenshotFuncionalidade("Inicio");

            _artigosInicioUI.CliqueExcluir();
            _artigosInicioUI.CliqueConfirmar();

            SalvarScreenshotEspecifico(contexto, "MensagemDeConfirmacao", "#popup_container");

            _artigosInicioUI.CliqueConfirmar();
            SalvarScreenshotFuncionalidade("ArtigoExcluido");

            CompararScreenshot();
        }

        protected override ContextoDeTeste CrieContextoDeTeste()
        {
            return new ContextoDeTeste("Administracao", "Desenvolvimento", "Artigos");
        }

        private ArtigosModel CrieArtigoParaCadastro()
        {
            var artigo = new ArtigosModel
            {
                Titulo = "Titulo Cadastro",
                Chamada = "Chamada Cadastro",
                Descricao = "Descricao Cadastro"
            };

            return artigo;
        }

        private ArtigosModel CrieArtigoParaAtualizacao()
        {
            var artigo = new ArtigosModel
            {
                Titulo = "Titulo Atualizacao",
                Chamada = "Chamada Atualizacao",
                Descricao = "Descricao Atualizacao"
            };

            return artigo;
        }

    }
}
