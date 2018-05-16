//-----------------------------------------------------------------------
// <copyright file="TestesDeGaleriasDeFotos.cs" company="LG Sistemas">
//     Copyright © LG Sistemas. All rights reserved.
//     TODOS OS DIREITOS RESERVADOS.
// </copyright>
//-----------------------------------------------------------------------

using LG.LMS.TestesDeInterface.Infraestrutura;
using LG.LMS.TestesDeInterface.PageModel.Administracao;
using LG.LMS.TestesDeInterface.PageModel.Administracao.Desenvolvimento.GaleriasDeFotos;
using LG.LMS.TestesDeInterface.PageModel.Portal;
using NUnit.Framework;

namespace LG.LMS.TestesDeInterface.Testes.Administracao.Desenvolvimento
{
    [TestFixture(Category = "Aministracao")]
    public class TestesDeGaleriasDeFotos : TestesDeInterfaceBase
    {
        private GaleriasDeFotosInicioUI _galeriasDeFotosInicioUI;
        private GaleriasDeFotosModel _modelParaCadastro;
        private GaleriasDeFotosModel _modelParaAtualizacao;

        [TestFixtureSetUp]
        public void FixtureSetUp()
        {
            var portalUI = new PortalUI(ComponenteDeTela);
            portalUI.InicializarElementos();

            var adminUI = new AdministracaoUI(ComponenteDeTela, portalUI);
            adminUI.InicializarElementos();

            _galeriasDeFotosInicioUI = new GaleriasDeFotosInicioUI(ComponenteDeTela, adminUI);
            _galeriasDeFotosInicioUI.AbrirFuncionalidade();

            _modelParaCadastro = CrieGaleriaDeFotosParaCadastro();
            _modelParaAtualizacao = CrieGaleriaDeFotosParaAtualizacao();
        }

        [Test]
        public void TestaCT0001CadastroDeGaleriaDeFotos()
        {
            contexto.AdicioneCenario("Cadastro");

            SalvarScreenshotFuncionalidade("Inicio");

            _galeriasDeFotosInicioUI.CliqueCadastrar();
            SalvarScreenshotFuncionalidade("Novo");

            var galeriasDeFotosEdicaoUI = new GaleriasDeFotosEdicaoUI(ComponenteDeTela);
            galeriasDeFotosEdicaoUI.InicializarElementos();
            galeriasDeFotosEdicaoUI.PreencheCampoNaTela(_modelParaCadastro);

            SalvarScreenshotFuncionalidade("DadosPreenchidos");

            galeriasDeFotosEdicaoUI.CliqueSalvar();
            SalvarScreenshotEspecifico(contexto, "MensagemDeConfirmacao", "#popup_container");

            galeriasDeFotosEdicaoUI.CliqueConfirmar();

            galeriasDeFotosEdicaoUI.CliqueCancelar();
            SalvarScreenshotFuncionalidade("GaleriaDeFotosCadastrada");

            CompararScreenshot();
        }

        [Test]
        public void TestaCT0002AtualizacaoDeGaleriaDeFotos()
        {
            contexto.AdicioneCenario("Atualizacao");

            SalvarScreenshotFuncionalidade("Inicio");

            _galeriasDeFotosInicioUI.CliqueEditar();

            ComponenteDeTela.Espera.AguardeIntervaloDeTempo(1);

            SalvarScreenshotFuncionalidade("Edicao");

            var galeriasDeFotosEdicaoUI = new GaleriasDeFotosEdicaoUI(ComponenteDeTela);
            galeriasDeFotosEdicaoUI.InicializarElementos();
            galeriasDeFotosEdicaoUI.PreencheCampoNaTela(_modelParaAtualizacao);
            ComponenteDeTela.Espera.AguardeIntervaloDeTempo(1);

            SalvarScreenshotFuncionalidade("DadosAtualizado");

            galeriasDeFotosEdicaoUI.CliqueSalvar();
            SalvarScreenshotEspecifico(contexto, "MensagemDeConfirmacao", "#popup_container");

            galeriasDeFotosEdicaoUI.CliqueConfirmar();

            galeriasDeFotosEdicaoUI.CliqueCancelar();
            SalvarScreenshotFuncionalidade("GaleriaDeFotosAtualizada");

            CompararScreenshot();
        }

        [Test]
        public void TestaCT0003ExclusaoDeGaleriaDeFotos()
        {
            contexto.AdicioneCenario("Exclusao");

            SalvarScreenshotFuncionalidade("Inicio");

            _galeriasDeFotosInicioUI.CliqueExcluir();
            _galeriasDeFotosInicioUI.CliqueConfirmar();

            SalvarScreenshotEspecifico(contexto, "MensagemDeConfirmacao", "#popup_container");

            _galeriasDeFotosInicioUI.CliqueConfirmar();
            SalvarScreenshotFuncionalidade("GaleriaDeFotosExcluida");

            CompararScreenshot();
        }

        protected override ContextoDeTeste CrieContextoDeTeste()
        {
            return new ContextoDeTeste("Administracao", "Desenvolvimento", "GaleriasDeFotos");
        }

        private GaleriasDeFotosModel CrieGaleriaDeFotosParaCadastro()
        {
            var galeriaDeFotos = new GaleriasDeFotosModel
            {
                Titulo = "Cadastro",
                Descricao = "Cadastro"
            };

            return galeriaDeFotos;
        }

        private GaleriasDeFotosModel CrieGaleriaDeFotosParaAtualizacao()
        {
            var galeriaDeFotos = new GaleriasDeFotosModel
            {
                Titulo = "Atualizacao",
                Descricao = "Atualizacao"
            };

            return galeriaDeFotos;
        }

    }
}
