//-----------------------------------------------------------------------
// <copyright file="TestesDeVideos.cs" company="LG Sistemas">
//     Copyright © LG Sistemas. All rights reserved.
//     TODOS OS DIREITOS RESERVADOS.
// </copyright>
//-----------------------------------------------------------------------

using LG.LMS.TestesDeInterface.Infraestrutura;
using LG.LMS.TestesDeInterface.PageModel.Administracao;
using LG.LMS.TestesDeInterface.PageModel.Administracao.Desenvolvimento.Videos;
using LG.LMS.TestesDeInterface.PageModel.Portal;
using NUnit.Framework;

namespace LG.LMS.TestesDeInterface.Testes.Administracao.Desenvolvimento
{
    [TestFixture(Category = "Aministracao")]
    public class TestesDeVideos : TestesDeInterfaceBase
    {
        private VideosInicioUI _videosInicioUI;
        private VideosModel _modelParaCadastro;
        private VideosModel _modelParaAtualizacao;

        [TestFixtureSetUp]
        public void FixtureSetUp()
        {
            var portalUI = new PortalUI(ComponenteDeTela);
            portalUI.InicializarElementos();

            var adminUI = new AdministracaoUI(ComponenteDeTela, portalUI);
            adminUI.InicializarElementos();

            _videosInicioUI = new VideosInicioUI(ComponenteDeTela, adminUI);
            _videosInicioUI.AbrirFuncionalidade();

            _modelParaCadastro = CrieVideoParaCadastro();
            _modelParaAtualizacao = CrieVideoParaAtualizacao();
        }

        [Test]
        public void TestaCT0001CadastroDeVideo()
        {
            contexto.AdicioneCenario("Cadastro");

            SalvarScreenshotFuncionalidade("Inicio");

            _videosInicioUI.CliqueCadastrar();
            SalvarScreenshotFuncionalidade("Novo");

            var videosEdicaoUI = new VideosEdicaoUI(ComponenteDeTela);
            videosEdicaoUI.InicializarElementos();
            videosEdicaoUI.PreencheCampoNaTela(_modelParaCadastro);

            SalvarScreenshotFuncionalidade("DadosPreenchidos");

            videosEdicaoUI.CliqueSalvar();
            //SalvarScreenshotEspecifico(contexto, "MensagemDeConfirmacao", "#popup_container");

            //videosEdicaoUI.CliqueConfirmar();

            videosEdicaoUI.CliqueCancelar();
            SalvarScreenshotFuncionalidade("VideoCadastrado");

            CompararScreenshot();
        }

        [Test]
        public void TestaCT0002AtualizacaoDeVideo()
        {
            contexto.AdicioneCenario("Atualizacao");

            SalvarScreenshotFuncionalidade("Inicio");

            _videosInicioUI.CliqueEditar();

            ComponenteDeTela.Espera.AguardeIntervaloDeTempo(1);

            SalvarScreenshotFuncionalidade("Edicao");

            var videosEdicaoUI = new VideosEdicaoUI(ComponenteDeTela);
            videosEdicaoUI.InicializarElementos();
            videosEdicaoUI.PreencheCampoNaTela(_modelParaAtualizacao);
            ComponenteDeTela.Espera.AguardeIntervaloDeTempo(1);

            SalvarScreenshotFuncionalidade("DadosAtualizado");

            videosEdicaoUI.CliqueSalvar();
            //SalvarScreenshotEspecifico(contexto, "MensagemDeConfirmacao", "#popup_container");

            //videosEdicaoUI.CliqueConfirmar();

            videosEdicaoUI.CliqueCancelar();
            SalvarScreenshotFuncionalidade("VideoAtualizado");

            CompararScreenshot();
        }

        [Test]
        public void TestaCT0003ExclusaoDeVideo()
        {
            contexto.AdicioneCenario("Exclusao");

            SalvarScreenshotFuncionalidade("Inicio");

            _videosInicioUI.CliqueExcluir();
            _videosInicioUI.CliqueConfirmar();

            SalvarScreenshotEspecifico(contexto, "MensagemDeConfirmacao", "#popup_container");

            _videosInicioUI.CliqueConfirmar();
            SalvarScreenshotFuncionalidade("VideoExcluido");

            CompararScreenshot();
        }

        protected override ContextoDeTeste CrieContextoDeTeste()
        {
            return new ContextoDeTeste("Administracao", "Desenvolvimento", "Videos");
        }

        private VideosModel CrieVideoParaCadastro()
        {
            var video = new VideosModel
            {
                Titulo = "Cadastro",
                Chamada = "Cadastro",
                Embed = "<embed src=\"video.wma\">"
            };

            return video;
        }

        private VideosModel CrieVideoParaAtualizacao()
        {
            var video = new VideosModel
            {
                Titulo = "Atualizacao",
                Chamada = "Atualizacao"
            };

            return video;
        }

    }
}
