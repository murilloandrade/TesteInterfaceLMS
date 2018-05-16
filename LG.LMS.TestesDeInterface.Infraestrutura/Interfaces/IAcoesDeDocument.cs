//-----------------------------------------------------------------------
// <copyright file="IAcoesDeDocument.cs" company="LG Sistemas">
//     Copyright © LG Sistemas. All rights reserved.
//     TODOS OS DIREITOS RESERVADOS.
// </copyright>
//-----------------------------------------------------------------------

namespace LG.LMS.TestesDeInterface.Infraestrutura.Interfaces
{
    /// <summary>
    /// Ações do document.
    /// </summary>
    public interface IAcoesDeDocument
    {
        /// <summary>
        /// Preenche o elemento utilizanto getElementById setando o valor na propriedade value.
        /// </summary>
        /// <param name="idElemento">O nome do elemento.</param>
        /// <param name="valor">O valor a ser alterado.</param>
        void PreencheElementoPorId(string idElemento, string valor);

        /// <summary>
        /// Preenche o elemento utilizanto getElementByName setando o valor na propriedade value.
        /// </summary>
        /// <param name="nameElemento">O nome do elemento.</param>
        /// <param name="valor">O valor a ser alterado.</param>
        void PreencheElementoPorName(string nameElemento, string valor);

        /// <summary>
        /// Preenche o elemento utilizanto getElementByClassName setando o valor na propriedade value.
        /// </summary>
        /// <param name="classNameElemento">O nome do elemento.</param>
        /// <param name="valor">O valor a ser alterado.</param>
        void PreencheElementoPorClassName(string classNameElemento, string valor);

        /// <summary>
        /// Preenche o elemento utilizanto querySelector setando o valor na propriedade value.
        /// </summary>
        /// <param name="cssElemento">O nome do elemento.</param>
        /// <param name="valor">O valor a ser alterado.</param>
        void PreencheElementoPorCSS(string cssElemento, string valor);

        /// <summary>
        /// Clica no elemento utilizanto getElementById.
        /// </summary>
        /// <param name="idElemento">O nome do elemento.</param>
        void CliqueElementoPorId(string idElemento);

        /// <summary>
        /// Clica no elemento utilizanto getElementByName.
        /// </summary>
        /// <param name="nameElemento">O nome do elemento.</param>
        void CliqueElementoPorName(string nameElemento);

        /// <summary>
        /// Clica no elemento utilizanto getElementByClassName.
        /// </summary>
        /// <param name="classNameElemento">O nome do elemento.</param>
        void CliqueElementoPorClassName(string classNameElemento);

        /// <summary>
        /// Obtenha combo box.
        /// </summary>
        /// <param name="cssSeletor">Seletor referente a combo box.</param>
        /// <param name="value">Valor para busca da option a ser selecionada.</param>
        void SelecioneValueCombo(string cssSeletor, string value);

        /// <summary>
        /// Obtenha combo box.
        /// </summary>
        /// <param name="cssSeletor">Seletor referente a combo box.</param>
        /// <param name="index">O indice para seleção da combo.</param>
        void SelecioneValueCombo(string cssSeletor, int index);
    }
}
