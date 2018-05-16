//-----------------------------------------------------------------------
// <copyright file="PortalUI.cs" company="LG Sistemas">
//     Copyright © LG Sistemas. All rights reserved.
//     TODOS OS DIREITOS RESERVADOS.
// </copyright>
//-----------------------------------------------------------------------

using LG.LMS.TestesDeInterface.Infraestrutura;
using LG.LMS.TestesDeInterface.Infraestrutura.PageModel;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace LG.LMS.TestesDeInterface.PageModel.Portal
{
    public class PortalUI : PaginaPadrao
    {
        public PortalUI(ComponenteDeTela componenteDeTela)
            : base(componenteDeTela)
        {
        }

        [FindsBy(How = How.CssSelector, Using = "[data-identificador='Home']")]
        public IWebElement Home { get; set; }

        [FindsBy(How = How.CssSelector, Using = "[data-identificador='Escola']")]
        public IWebElement Escolas { get; set; }

        [FindsBy(How = How.CssSelector, Using = "[data-identificador='Cursos']")]
        public IWebElement Oficinas { get; set; }

        [FindsBy(How = How.CssSelector, Using = "[data-identificador='Institucional']")]
        public IWebElement Institucional { get; set; }

        [FindsBy(How = How.CssSelector, Using = "[data-identificador='Tutoria']")]
        public IWebElement Tutoria { get; set; }

        [FindsBy(How = How.ClassName, Using = "menu-Admin")]
        public IWebElement Admin { get; set; }

        protected override void CarregarPagina()
        {
            ComponenteDeTela.AbrirTelaDeAplicacao();
        }
    }
}
