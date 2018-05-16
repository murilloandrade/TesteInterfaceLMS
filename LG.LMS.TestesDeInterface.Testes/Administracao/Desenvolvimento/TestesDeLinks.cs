//-----------------------------------------------------------------------
// <copyright file="TestesDeLinks.cs" company="LG Sistemas">
//     Copyright © LG Sistemas. All rights reserved.
//     TODOS OS DIREITOS RESERVADOS.
// </copyright>
//-----------------------------------------------------------------------

using LG.LMS.TestesDeInterface.Infraestrutura;
using LG.LMS.TestesDeInterface.PageModel.Administracao;
using LG.LMS.TestesDeInterface.PageModel.Administracao.Desenvolvimento.Links;
using LG.LMS.TestesDeInterface.PageModel.Portal;
using NUnit.Framework;

namespace LG.LMS.TestesDeInterface.Testes.Administracao.Desenvolvimento
{
    [TestFixture(Category = "Aministracao")]
    public class TestesDeLinks : TestesDeInterfaceBase
    {
        private LinksInicioUI _linksInicioUI;
        private LinksModel _modelParaCadastro;
        private LinksModel _modelParaAtualizacao;

        [TestFixtureSetUp]
        public void FixtureSetUp()
        {
            var portalUI = new PortalUI(ComponenteDeTela);
            portalUI.InicializarElementos();

            var adminUI = new AdministracaoUI(ComponenteDeTela, portalUI);
            adminUI.InicializarElementos();

            _linksInicioUI = new LinksInicioUI(ComponenteDeTela, adminUI);
            _linksInicioUI.AbrirFuncionalidade();

            _modelParaCadastro = CrieLinkParaCadastro();
            _modelParaAtualizacao = CrieLinkParaAtualizacao();
        }

        [Test]
        public void TestaCT0001CadastroDeLink()
        {
            contexto.AdicioneCenario("Cadastro");

            SalvarScreenshotFuncionalidade("Inicio");

            _linksInicioUI.CliqueCadastrar();
            SalvarScreenshotFuncionalidade("Novo");

            var linksEdicaoUI = new LinksEdicaoUI(ComponenteDeTela);
            linksEdicaoUI.InicializarElementos();
            linksEdicaoUI.PreencheCampoNaTela(_modelParaCadastro);

            SalvarScreenshotFuncionalidade("DadosPreenchidos");

            linksEdicaoUI.CliqueSalvar();
            SalvarScreenshotEspecifico(contexto, "MensagemDeConfirmacao", "#popup_container");

            linksEdicaoUI.CliqueConfirmar();

            linksEdicaoUI.CliqueCancelar();
            SalvarScreenshotFuncionalidade("LinkCadastrado");

            CompararScreenshot();
        }

        [Test]
        public void TestaCT0002AtualizacaoDeLink()
        {
            contexto.AdicioneCenario("Atualizacao");

            SalvarScreenshotFuncionalidade("Inicio");

            _linksInicioUI.CliqueEditar();

            ComponenteDeTela.Espera.AguardeIntervaloDeTempo(1);

            SalvarScreenshotFuncionalidade("Edicao");

            var linksEdicaoUI = new LinksEdicaoUI(ComponenteDeTela);
            linksEdicaoUI.InicializarElementos();
            linksEdicaoUI.PreencheCampoNaTela(_modelParaAtualizacao);
            ComponenteDeTela.Espera.AguardeIntervaloDeTempo(1);

            SalvarScreenshotFuncionalidade("DadosAtualizado");

            linksEdicaoUI.CliqueSalvar();
            SalvarScreenshotEspecifico(contexto, "MensagemDeConfirmacao", "#popup_container");

            linksEdicaoUI.CliqueConfirmar();

            linksEdicaoUI.CliqueCancelar();
            SalvarScreenshotFuncionalidade("LinkAtualizado");

            CompararScreenshot();
        }

        [Test]
        public void TestaCT0003ExclusaoDeLink()
        {
            contexto.AdicioneCenario("Exclusao");

            SalvarScreenshotFuncionalidade("Inicio");

            _linksInicioUI.CliqueExcluir();
            _linksInicioUI.CliqueConfirmar();

            SalvarScreenshotEspecifico(contexto, "MensagemDeConfirmacao", "#popup_container");

            _linksInicioUI.CliqueConfirmar();
            SalvarScreenshotFuncionalidade("LinkExcluido");

            CompararScreenshot();
        }

        protected override ContextoDeTeste CrieContextoDeTeste()
        {
            return new ContextoDeTeste("Administracao", "Desenvolvimento", "Links");
        }

        private LinksModel CrieLinkParaCadastro()
        {
            var link = new LinksModel
            {
                Titulo = "Cadastro",
                Descricao = "Cadastro",
                Link = "https://jenkins.e-guru.com.br/BS/mattosfilho_bs_ci/User"
            };

            return link;
        }

        private LinksModel CrieLinkParaAtualizacao()
        {
            var link = new LinksModel
            {
                Titulo = "Atualizacao",
                Descricao = "Atualizacao"
            };

            return link;
        }

    }
}
