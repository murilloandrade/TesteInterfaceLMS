//-----------------------------------------------------------------------
// <copyright file="AcoesDeTela.cs" company="LG Sistemas">
//     Copyright © LG Sistemas. All rights reserved.
//     TODOS OS DIREITOS RESERVADOS.
// </copyright>
//-----------------------------------------------------------------------

using LG.LMS.TestesDeInterface.Infraestrutura.Utilitarios;
using OpenQA.Selenium;

namespace LG.LMS.TestesDeInterface.Infraestrutura.Acoes
{
    /// <summary>
    /// Ações de tela.
    /// </summary>
    internal abstract class AcoesDeTela
    {
        protected AcoesDeTela(ComponenteDeTela componenteDeTela)
        {
            ComponenteDeTela = componenteDeTela;
            WebDriver = ComponenteDeTela.WebDriver;
            JavaScript = (IJavaScriptExecutor)WebDriver;
            Wait = new WebDriverWaitCustomizado(componenteDeTela, ComponenteDeTela.ConfiguracaoDeTela.Timeout);
        }

        protected ComponenteDeTela ComponenteDeTela { get; private set; }

        protected IWebDriver WebDriver { get; private set; }

        protected IJavaScriptExecutor JavaScript { get; private set; }

        protected WebDriverWaitCustomizado Wait { get; private set; }
    }
}
