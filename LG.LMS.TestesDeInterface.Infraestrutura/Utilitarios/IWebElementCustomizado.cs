//-----------------------------------------------------------------------
// <copyright file="IWebElementCustomizado.cs" company="LG Sistemas">
//     Copyright © LG Sistemas. All rights reserved.
//     TODOS OS DIREITOS RESERVADOS.
// </copyright>
//-----------------------------------------------------------------------

using OpenQA.Selenium;

namespace LG.LMS.TestesDeInterface.Infraestrutura.Utilitarios
{
    /// <summary>
    /// Interface de web element customizado.
    /// </summary>
    public interface IWebElementCustomizado : IWebElement
    {
        /// <summary>
        /// Sobrecarga do evento click.
        /// Abre a funcionalidade do elemento customizado.
        /// </summary>
        void AbrirFuncionalidade();
    }
}
