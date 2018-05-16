//-----------------------------------------------------------------------
// <copyright file="TestesDeAudios.cs" company="LG Sistemas">
//     Copyright © LG Sistemas. All rights reserved.
//     TODOS OS DIREITOS RESERVADOS.
// </copyright>
//-----------------------------------------------------------------------

using LG.LMS.TestesDeInterface.Infraestrutura;
using LG.LMS.TestesDeInterface.PageModel.Administracao;
using LG.LMS.TestesDeInterface.PageModel.Administracao.Desenvolvimento.Audios;
using LG.LMS.TestesDeInterface.PageModel.Portal;
using NUnit.Framework;

namespace LG.LMS.TestesDeInterface.Testes.Administracao.Desenvolvimento
{
    [TestFixture(Category = "Aministracao")]
    public class TestesDeAudios : TestesDeInterfaceBase
    {
        private AudiosInicioUI _audiosInicioUI;
        private AudiosModel _modelParaCadastro;
        private AudiosModel _modelParaAtualizacao;

        [TestFixtureSetUp]
        public void FixtureSetUp()
        {
            var portalUI = new PortalUI(ComponenteDeTela);
            portalUI.InicializarElementos();

            var adminUI = new AdministracaoUI(ComponenteDeTela, portalUI);
            adminUI.InicializarElementos();

            _audiosInicioUI = new AudiosInicioUI(ComponenteDeTela, adminUI);
            _audiosInicioUI.AbrirFuncionalidade();

            _modelParaCadastro = CrieAudioParaCadastro();
            _modelParaAtualizacao = CrieAudioParaAtualizacao();
        }

        [Test]
        public void TestaCT0001CadastroDeAudio()
        {
            contexto.AdicioneCenario("Cadastro");

            SalvarScreenshotFuncionalidade("Inicio");

            _audiosInicioUI.CliqueCadastrar();
            SalvarScreenshotFuncionalidade("Novo");

            var audiosEdicaoUI = new AudiosEdicaoUI(ComponenteDeTela);
            audiosEdicaoUI.InicializarElementos();
            audiosEdicaoUI.PreencheCampoNaTela(_modelParaCadastro);

            SalvarScreenshotFuncionalidade("DadosPreenchidos");

            audiosEdicaoUI.CliqueSalvar();

            audiosEdicaoUI.CliqueCancelar();

            EsperaPaginaCarregar();

            SalvarScreenshotFuncionalidade("AudioCadastrado");

            CompararScreenshot();
        }

        [Test]
        public void TestaCT0002AtualizacaoDeAudio()
        {
            contexto.AdicioneCenario("Atualizacao");

            SalvarScreenshotFuncionalidade("Inicio");

            _audiosInicioUI.CliqueEditar();

            ComponenteDeTela.Espera.AguardeIntervaloDeTempo(1);

            SalvarScreenshotFuncionalidade("Edicao");

            var audiosEdicaoUI = new AudiosEdicaoUI(ComponenteDeTela);
            audiosEdicaoUI.InicializarElementos();
            audiosEdicaoUI.PreencheCampoNaTela(_modelParaAtualizacao);
            ComponenteDeTela.Espera.AguardeIntervaloDeTempo(1);

            SalvarScreenshotFuncionalidade("DadosAtualizado");

            audiosEdicaoUI.CliqueSalvar();

            audiosEdicaoUI.CliqueCancelar();
            SalvarScreenshotFuncionalidade("AudioAtualizado");

            CompararScreenshot();
        }

        [Test]
        public void TestaCT0003ExclusaoDeAudio()
        {
            contexto.AdicioneCenario("Exclusao");

            SalvarScreenshotFuncionalidade("Inicio");

            _audiosInicioUI.CliqueExcluir();
            _audiosInicioUI.CliqueConfirmar();

            SalvarScreenshotEspecifico(contexto, "MensagemDeConfirmacao", "#popup_container");

            _audiosInicioUI.CliqueConfirmar();
            SalvarScreenshotFuncionalidade("AudioExcluido");

            CompararScreenshot();
        }

        protected override ContextoDeTeste CrieContextoDeTeste()
        {
            return new ContextoDeTeste("Administracao", "Desenvolvimento", "Audios");
        }

        private AudiosModel CrieAudioParaCadastro()
        {
            var audio = new AudiosModel
            {
                Titulo = "Cadastro",
                Chamada = "Cadastro"
            };

            return audio;
        }

        private AudiosModel CrieAudioParaAtualizacao()
        {
            var audio = new AudiosModel
            {
                Titulo = "Atualizacao",
                Chamada = "Atualizacao"
            };

            return audio;
        }

        private void EsperaPaginaCarregar()
        {
            ComponenteDeTela.Espera.AguardeScript("$(\"[class='pagination hide ']\").is(':visible')");
        }

    }
}