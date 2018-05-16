//-----------------------------------------------------------------------
// <copyright file="WebElementExtension.cs" company="LG Sistemas">
//     Copyright © LG Sistemas. All rights reserved.
//     TODOS OS DIREITOS RESERVADOS.
// </copyright>
//-----------------------------------------------------------------------

using System;
using System.Threading;
using OpenQA.Selenium;

namespace LG.LMS.TestesDeInterface.Infraestrutura.PageModel
{
    /// <summary>
    /// Utilitário de extensão de IWebElement.
    /// </summary>
    public static class WebElementExtension
    {
        /// <summary>
        /// Preenche campo com "SendKeys" webelement.
        /// </summary>
        /// <param name="elemento">O elemento para preenchimento.</param>
        /// <param name="valor">O valor a ser informado.</param>
        public static void PreencheCampo(this IWebElement elemento, string valor)
        {
            PreencheCampo(elemento, valor, 0);
        }

        /// <summary>
        /// Preenche campo com "SendKeys" webelement com tempo.
        /// Use esse método quando o SendKeys não preecher o campo completamente.
        /// </summary>
        /// <param name="elemento">O elemento para preenchimento.</param>
        /// <param name="valor">O valor a ser informado.</param>
        /// /// <param name="milissegundos">O tempo em milissegundos que ele irá aguardar.</param>
        public static void PreencheCampo(this IWebElement elemento, string valor, int milissegundos)
        {
            if (!valor.ToUpper().StartsWith("N/A", StringComparison.OrdinalIgnoreCase) && elemento.Enabled)
            {
                PreparaEPreencheCampo(elemento, valor, milissegundos);
            }
        }

        private static void PreparaEPreencheCampo(IWebElement elemento, string valor, int milissegundos)
        {
            elemento.Clear();
            Thread.Sleep(milissegundos);
            elemento.SendKeys(valor);
        }
    }
}
