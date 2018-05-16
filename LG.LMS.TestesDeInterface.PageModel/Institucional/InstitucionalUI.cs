//-----------------------------------------------------------------------
// <copyright file="InstitucionalUI.cs" company="LG Sistemas">
//     Copyright © LG Sistemas. All rights reserved.
//     TODOS OS DIREITOS RESERVADOS.
// </copyright>
//-----------------------------------------------------------------------
using LG.LMS.TestesDeInterface.Infraestrutura;
using LG.LMS.TestesDeInterface.Infraestrutura.PageModel;
using LG.LMS.TestesDeInterface.PageModel.Portal;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace LG.LMS.TestesDeInterface.PageModel.Institucional
{
    public class InstitucionalUI : PaginaPadrao
    {
        private PortalUI _portalUI;

        public InstitucionalUI(ComponenteDeTela componenteDeTela, PortalUI portal)
            : base(componenteDeTela)
        {
            _portalUI = portal;
        }

        [FindsBy(How = How.CssSelector, Using = "[href='#manifesto']")]
        public IWebElement Manifesto { get; set; }

        [FindsBy(How = How.CssSelector, Using = "[href='#gestao']")]
        public IWebElement GestaoPessoalDoConhecimento { get; set; }

        [FindsBy(How = How.CssSelector, Using = "[href='#principios']")]
        public IWebElement Principios { get; set; }

        protected override void CarregarPagina()
        {
            ComponenteDeTela.AbrirTelaDeAplicacao();
            _portalUI.Institucional.Click();
        }
    }
}
