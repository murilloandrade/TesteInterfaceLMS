//-----------------------------------------------------------------------
// <copyright file="TestesDeArquivos.cs" company="LG Sistemas">
//     Copyright © LG Sistemas. All rights reserved.
//     TODOS OS DIREITOS RESERVADOS.
// </copyright>
//-----------------------------------------------------------------------

using LG.LMS.TestesDeInterface.Infraestrutura;
using LG.LMS.TestesDeInterface.PageModel.Administracao;
using LG.LMS.TestesDeInterface.PageModel.Administracao.Desenvolvimento.Arquivos;
using LG.LMS.TestesDeInterface.PageModel.Portal;
using NUnit.Framework;

namespace LG.LMS.TestesDeInterface.Testes.Administracao.Desenvolvimento
{
    [TestFixture(Category = "Aministracao")]
    public class TestesDeArquivos : TestesDeInterfaceBase
    {
        private ArquivosInicioUI _arquivosInicioUI;
        private ArquivosModel _modelParaCadastro; 
        private ArquivosModel _modelParaAtualizacao;

        [TestFixtureSetUp]
        public void FixtureSetUp()
        {
            var portalUI = new PortalUI(ComponenteDeTela);
            portalUI.InicializarElementos();

            var adminUI = new AdministracaoUI(ComponenteDeTela, portalUI);
            adminUI.InicializarElementos();

            _arquivosInicioUI = new ArquivosInicioUI(ComponenteDeTela, adminUI);
            _arquivosInicioUI.AbrirFuncionalidade();

            _modelParaCadastro = CrieArquivoParaCadastro();
            _modelParaAtualizacao = CrieArquivoParaAtualizacao();
        }

        [Test]
        public void TestaCT0001CadastroDeArquivo()
        {
            contexto.AdicioneCenario("Cadastro");

            SalvarScreenshotFuncionalidade("Inicio");

            _arquivosInicioUI.CliqueCadastrar();
            SalvarScreenshotFuncionalidade("Novo");

            var arquivosEdicaoUI = new ArquivosEdicaoUI(ComponenteDeTela);
            arquivosEdicaoUI.InicializarElementos();
            arquivosEdicaoUI.PreencheCampoNaTela(_modelParaCadastro);

            SalvarScreenshotFuncionalidade("DadosPreenchidos");

            arquivosEdicaoUI.CliqueSalvar();

            arquivosEdicaoUI.CliqueCancelar();

            EsperaPaginaCarregar();

            SalvarScreenshotFuncionalidade("ArquivoCadastrado");

            CompararScreenshot();
        }

        [Test]
        public void TestaCT0002AtualizacaoDeArquivo()
        {
            contexto.AdicioneCenario("Atualizacao");

            SalvarScreenshotFuncionalidade("Inicio");

            _arquivosInicioUI.CliqueEditar();

            ComponenteDeTela.Espera.AguardeIntervaloDeTempo(1);

            SalvarScreenshotFuncionalidade("Edicao");

            var arquivosEdicaoUI = new ArquivosEdicaoUI(ComponenteDeTela);
            arquivosEdicaoUI.InicializarElementos();
            arquivosEdicaoUI.PreencheCampoNaTela(_modelParaAtualizacao);
            ComponenteDeTela.Espera.AguardeIntervaloDeTempo(1);

            SalvarScreenshotFuncionalidade("DadosAtualizado");

            arquivosEdicaoUI.CliqueSalvar();

            arquivosEdicaoUI.CliqueCancelar();
            SalvarScreenshotFuncionalidade("ArquivoAtualizado");

            CompararScreenshot();
        }

        [Test]
        public void TestaCT0003ExclusaoDeArquivo()
        {
            contexto.AdicioneCenario("Exclusao");

            SalvarScreenshotFuncionalidade("Inicio");

            _arquivosInicioUI.CliqueExcluir();
            _arquivosInicioUI.CliqueConfirmar();

            SalvarScreenshotEspecifico(contexto, "MensagemDeConfirmacao", "#popup_container");

            _arquivosInicioUI.CliqueConfirmar();
            SalvarScreenshotFuncionalidade("ArquivoExcluido");

            CompararScreenshot();
        }

        protected override ContextoDeTeste CrieContextoDeTeste()
        {
            return new ContextoDeTeste("Administracao", "Desenvolvimento", "Arquivos");
        }

        private ArquivosModel CrieArquivoParaCadastro()
        {
            var arquivo = new ArquivosModel
            {
                Titulo = "Cadastro",
                Descricao = "Cadastro"
            };

            return arquivo;
        }

        private ArquivosModel CrieArquivoParaAtualizacao()
        {
            var arquivo = new ArquivosModel
            {
                Titulo = "Atualizacao",
                Descricao = "Atualizacao"
            };

            return arquivo;
        }

        private void EsperaPaginaCarregar()
        {
            ComponenteDeTela.Espera.AguardeScript("$(\"[class='pagination hide ']\").is(':visible')");
        }

    }
}
