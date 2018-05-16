//-----------------------------------------------------------------------
// <copyright file="EnumBrowsers.cs" company="LG Sistemas">
//     Copyright © LG Sistemas. All rights reserved.
//     TODOS OS DIREITOS RESERVADOS.
// </copyright>
//-----------------------------------------------------------------------

namespace LG.LMS.TestesDeInterface.Infraestrutura.Enumeradores
{
    /// <summary>
    /// Enumeração contendo todos os browsers disponíveis para execução de testes de interface gráfica com o Selenium.
    /// </summary>
    public enum EnumBrowsers
    {
        /// <summary>
        /// Indica que os testes de interface gráfica serão executados utilizando o browser Internet Explorer.
        /// </summary>
        IE,

        /// <summary>
        /// Indica que os testes de interface gráfica serão executados utilizando o broswer Google Chrome.
        /// </summary>
        CHROME,

        /// <summary>
        /// Indica que os testes de interface gráfica serão executados utilizando o broswer Google Chrome.
        /// </summary>
        CHROME_HEADLESS,

        /// <summary>
        /// Indica que os testes de interface gráfica serão executados utilizando o browser Mozilla Firefox.
        /// </summary>
        FIREFOX,

        /// <summary>
        /// Indica que os testes de interface gráfica serão executados utilizando o browser PhantomJS.
        /// </summary>
        PHANTOMJS
    }
}
