//-----------------------------------------------------------------------
// <copyright file="AdministracaoUI.cs" company="LG Sistemas">
//     Copyright © LG Sistemas. All rights reserved.
//     TODOS OS DIREITOS RESERVADOS.
// </copyright>
//-----------------------------------------------------------------------

using LG.LMS.TestesDeInterface.Infraestrutura;
using LG.LMS.TestesDeInterface.Infraestrutura.PageModel;
using LG.LMS.TestesDeInterface.PageModel.Portal;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace LG.LMS.TestesDeInterface.PageModel.Administracao
{
    public class AdministracaoUI : PaginaPadrao
    {
        private PortalUI _portalUI;

        public AdministracaoUI(ComponenteDeTela componenteDeTela, PortalUI portalUI)
            : base(componenteDeTela)
        {
            _portalUI = portalUI;
        }

        [FindsBy(How = How.CssSelector, Using = "#menu-principal > li > a")]
        public IWebElement Inicio { get; set; }

        /// <summary>
        /// Abre a funcionalidade questões certificadas.
        /// </summary>
        public void CliqueQuestoesCertificadas()
        {
            ComponenteDeTela.Script.ExecuteCodigoJavaScript("$('.gestaoQuestoesSurvey a:first')[0].click()");
        }

        /// <summary>
        /// Abre a funcionalidade gestão de item de despesa.
        /// </summary>
        public void CliqueGestaoDeItemDeDespesa()
        {
            ComponenteDeTela.Script.ExecuteCodigoJavaScript("$('.gestaoItemDespesa a:first')[0].click()");
        }

        /// <summary>
        /// Abre a funcionalidade galerias de fotos.
        /// </summary>
        public void CliqueGaleriasDeFotos()
        {
            ComponenteDeTela.Script.ExecuteCodigoJavaScript("$('.GaleriasDeFotos a:first')[0].click()");
        }

        /// <summary>
        /// Abre a funcionalidade artigos.
        /// </summary>
        public void CliqueArtigos()
        {
            ComponenteDeTela.Script.ExecuteCodigoJavaScript("$('.gestaoConteudo a:first')[0].click()");
        }

        /// <summary>
        /// Abre a funcionalidade arquivos.
        /// </summary>
        public void CliqueArquivos()
        {
            ComponenteDeTela.Script.ExecuteCodigoJavaScript("$('.arquivos a:first')[0].click()");
        }

        /// <summary>
        /// Abre a funcionalidade links.
        /// </summary>
        public void CliqueLinks()
        {
            ComponenteDeTela.Script.ExecuteCodigoJavaScript("$('.links a:first')[0].click()");
        }

        /// <summary>
        /// Abre a funcionalidade videos.
        /// </summary>
        public void CliqueVideos()
        {
            ComponenteDeTela.Script.ExecuteCodigoJavaScript("$('.videos a:first')[0].click()");
        }

        /// <summary>
        /// Abre a funcionalidade videos.
        /// </summary>
        public void CliqueAudios()
        {
            ComponenteDeTela.Script.ExecuteCodigoJavaScript("$('.audios a:first')[0].click()");
        }

        protected override void CarregarPagina()
        {
            _portalUI.AbrirFuncionalidade();
            _portalUI.Admin.Click();
        }
    }
}
