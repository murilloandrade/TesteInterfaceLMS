//-----------------------------------------------------------------------
// <copyright file="ByElementCustomizado.cs" company="LG Sistemas">
//     Copyright © LG Sistemas. All rights reserved.
//     TODOS OS DIREITOS RESERVADOS.
// </copyright>
//-----------------------------------------------------------------------

using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using OpenQA.Selenium;

namespace LG.LMS.TestesDeInterface.Infraestrutura.Utilitarios
{
    /// <summary>
    /// Pesquisa de elemento customizado.
    /// </summary>
    public class ByElementCustomizado : By
    {
        public ByElementCustomizado(string cssElement)
        {
            Description = cssElement;
            FindElementMethod = ObtenhaElemento;
            FindElementsMethod = ObtenhaElementos;
        }

        private WebElementCustomizado ObtenhaElemento(ISearchContext contexto)
        {
            var element = contexto.FindElement(CssSelector(Description));
            var elementCustomizado = new WebElementCustomizado(contexto, element, Description);

            return elementCustomizado;
        }

        private ReadOnlyCollection<IWebElement> ObtenhaElementos(ISearchContext contexto)
        {
            var elements = contexto.FindElements(CssSelector(Description)).FirstOrDefault();
            var elementCustomizado = new WebElementCustomizado(contexto, elements, Description);

            return new ReadOnlyCollection<IWebElement>(new List<IWebElement> { elementCustomizado });
        }
    }
}
