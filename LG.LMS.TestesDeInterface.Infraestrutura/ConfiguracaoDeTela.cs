//-----------------------------------------------------------------------
// <copyright file="ConfiguracaoDeTela.cs" company="LG Sistemas">
//     Copyright © LG Sistemas. All rights reserved.
//     TODOS OS DIREITOS RESERVADOS.
// </copyright>
//-----------------------------------------------------------------------

using System;
using LG.LMS.TestesDeInterface.Infraestrutura.Enumeradores;

namespace LG.LMS.TestesDeInterface.Infraestrutura
{
    /// <summary>
    /// Parâmetros de configurações do componente de tela.
    /// </summary>
    public sealed class ConfiguracaoDeTela
    {
        /// <summary>
        /// Obtém ou define a URL para login.
        /// </summary>
        /// <value>
        /// A URL para efetuar login.
        /// </value>
        public string UrlLogin { get; set; }

        /// <summary>
        /// Obtém ou define a URL inicial da aplicação.
        /// </summary>
        /// <value>
        /// A URL inicial da aplicação.
        /// </value>
        public string UrlAplicacao { get; set; }

        /// <summary>
        /// Obtém ou define o tipo de browser a ser utilizado nos testes.
        /// </summary>
        /// <value>
        /// O tipo de browser.
        /// </value>
        public EnumBrowsers Browser { get; set; }

        /// <summary>
        /// Obtém ou define o diretório dos binários contendo webdriver.
        /// </summary>
        /// <value>
        /// A pasta de binários.
        /// </value>
        public string PastaDeBinarios { get; set; }

        /// <summary>
        /// Obtém ou define a configuração de timeout para os testes de tela.
        /// </summary>
        /// <value>
        /// O timeout.
        /// </value>
        public TimeSpan Timeout { get; set; }

        /// <summary>
        /// Obtém ou define se utiliza screenshot para captura de imagens com WebDriver.
        /// </summary>
        /// <value>
        /// A identificação de habilitação de screenshot.
        /// </value>
        public bool UtilizaScreenshot { get; set; }

        /// <summary>
        /// Obtém ou define o tipo de proxy.
        /// </summary>
        /// <value>
        /// O tipo de proxy.
        /// </value>
        public string ProxyType { get; set; }

        /// <summary>
        /// Obtém ou define o login.
        /// </summary>
        /// <value>
        /// O login do sistema.
        /// </value>
        public string Login { get; set; }

        /// <summary>
        /// Obtém ou define a senha.
        /// </summary>
        /// <value>
        /// A senha do sistema.
        /// </value>
        public string Senha { get; set; }

        /// <summary>
        /// Obtém ou define o tipo de ambiente.
        /// </summary>
        /// <value>
        /// O tipo de ambiente.
        /// </value>
        public EnumTipoDeAmbiente TipoDeAmbiente { get; set; }
    }
}
