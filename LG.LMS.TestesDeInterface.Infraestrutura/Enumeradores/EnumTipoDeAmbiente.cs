//-----------------------------------------------------------------------
// <copyright file="EnumTipoDeAmbiente.cs" company="LG Sistemas">
//     Copyright © LG Sistemas. All rights reserved.
//     TODOS OS DIREITOS RESERVADOS.
// </copyright>
//-----------------------------------------------------------------------

namespace LG.LMS.TestesDeInterface.Infraestrutura.Enumeradores
{
    /// <summary>
    /// Enumeração contendo todos os browsers disponíveis para execução de testes de interface gráfica com o Selenium.
    /// </summary>
    public enum EnumTipoDeAmbiente
    {
        /// <summary>
        /// Indica que ambiente de testes é na máquina local.
        /// </summary>
        LOCAL,

        /// <summary>
        /// Indica que ambiente de testes é na VM.
        /// </summary>
        VM
    }
}
