//-----------------------------------------------------------------------
// <copyright file="EscolaUI.cs" company="LG Sistemas">
//     Copyright © LG Sistemas. All rights reserved.
//     TODOS OS DIREITOS RESERVADOS.
// </copyright>
//-----------------------------------------------------------------------
using LG.LMS.TestesDeInterface.Infraestrutura;
using LG.LMS.TestesDeInterface.Infraestrutura.PageModel;
using LG.LMS.TestesDeInterface.PageModel.Portal;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace LG.LMS.TestesDeInterface.PageModel.Escolas
{
    public class EscolaUI : PaginaPadrao
    {
        private PortalUI _portalUI;

        public EscolaUI(ComponenteDeTela componenteDeTela, PortalUI portal)
            : base(componenteDeTela)
        {
            _portalUI = portal;
        }

        [FindsBy(How = How.CssSelector, Using = "[title='Escolas']")]
        public IWebElement Escola { get; set; }

        [FindsBy(How = How.Id, Using = "buscar-todas")]
        public IWebElement TodasAsTrilhas { get; set; }

        [FindsBy(How = How.Id, Using = "buscar-minhas")]
        public IWebElement MinhasTrilhas { get; set; }

        /// <summary>
        /// Click na primeira trilha do card.
        /// </summary>
        public void AcessarPrimeiraTrilha()
        {
            ComponenteDeTela.Script.ExecuteCodigoJavaScript("$('.bloco-principal.unstyled > a:first')[0].click()");
        }

        protected override void CarregarPagina()
        {
            ComponenteDeTela.AbrirTelaDeAplicacao();
            _portalUI.Escolas.Click();
        }
    }
}
