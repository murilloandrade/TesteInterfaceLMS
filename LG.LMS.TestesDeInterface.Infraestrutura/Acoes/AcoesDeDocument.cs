//-----------------------------------------------------------------------
// <copyright file="AcoesDeDocument.cs" company="LG Sistemas">
//     Copyright © LG Sistemas. All rights reserved.
//     TODOS OS DIREITOS RESERVADOS.
// </copyright>
//-----------------------------------------------------------------------

using System.Globalization;
using LG.LMS.TestesDeInterface.Infraestrutura.Interfaces;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace LG.LMS.TestesDeInterface.Infraestrutura.Acoes
{
    /// <summary>
    /// Ações de document.
    /// </summary>
    internal class AcoesDeDocument : AcoesDeTela, IAcoesDeDocument
    {
        internal AcoesDeDocument(ComponenteDeTela componenteDeTela)
            : base(componenteDeTela)
        {
        }

        /// <summary>
        /// Preenche o elemento utilizanto getElementById setando o valor na propriedade value.
        /// </summary>
        /// <param name="idElemento">O nome do elemento.</param>
        /// <param name="valor">O valor a ser alterado.</param>
        public void PreencheElementoPorId(string idElemento, string valor)
        {
            var script = string.Format(CultureInfo.InvariantCulture, "document.getElementById('{0}').value = '{1}'", idElemento, valor);
            ExecuteScript(script);
        }

        /// <summary>
        /// Preenche o elemento utilizanto getElementByName setando o valor na propriedade value.
        /// </summary>
        /// <param name="nameElemento">O nome do elemento.</param>
        /// <param name="valor">O valor a ser alterado.</param>
        public void PreencheElementoPorName(string nameElemento, string valor)
        {
            var script = string.Format(CultureInfo.InvariantCulture, "document.getElementByName('{0}').value = '{1}'", nameElemento, valor);
            ExecuteScript(script);
        }

        /// <summary>
        /// Preenche o elemento utilizanto getElementByClassName setando o valor na propriedade value.
        /// </summary>
        /// <param name="classNameElemento">O nome do elemento.</param>
        /// <param name="valor">O valor a ser alterado.</param>
        public void PreencheElementoPorClassName(string classNameElemento, string valor)
        {
            var script = string.Format(CultureInfo.InvariantCulture, "document.getElementByClassName('{0}').value = '{1}'", classNameElemento, valor);
            ExecuteScript(script);
        }

        /// <summary>
        /// Preenche o elemento utilizanto querySelector setando o valor na propriedade value.
        /// </summary>
        /// <param name="cssElemento">O seletor do elemento.</param>
        /// <param name="valor">O valor a ser alterado.</param>
        public void PreencheElementoPorCSS(string cssElemento, string valor)
        {
            var script = string.Format(CultureInfo.InvariantCulture, "document.querySelector(\"{0}\").value = '{1}'", cssElemento, valor);
            ExecuteScript(script);
        }

        /// <summary>
        /// Clica no elemento utilizanto getElementById.
        /// </summary>
        /// <param name="idElemento">O nome do elemento.</param>
        public void CliqueElementoPorId(string idElemento)
        {
            var script = string.Format(CultureInfo.InvariantCulture, "document.getElementById('{0}').click()", idElemento);
            ExecuteScript(script);
        }

        /// <summary>
        /// Clica no elemento utilizanto getElementByName.
        /// </summary>
        /// <param name="nameElemento">O nome do elemento.</param>
        public void CliqueElementoPorName(string nameElemento)
        {
            var script = string.Format(CultureInfo.InvariantCulture, "document.getElementByName('{0}').click()", nameElemento);
            ExecuteScript(script);
        }

        /// <summary>
        /// Clica no elemento utilizanto getElementByClassName.
        /// </summary>
        /// <param name="classNameElemento">O nome do elemento.</param>
        public void CliqueElementoPorClassName(string classNameElemento)
        {
            var script = string.Format(CultureInfo.InvariantCulture, "document.getElementByClassName('{0}').click()", classNameElemento);
            ExecuteScript(script);
        }

        /// <summary>
        /// Obtenha combo box.
        /// </summary>
        /// <param name="cssSeletor">Seletor referente a combo box.</param>
        /// <param name="value">Valor para busca da option a ser selecionada.</param>
        public void SelecioneValueCombo(string cssSeletor, string value)
        {
            var combobox = ObtenhaCombo(cssSeletor);
            combobox.SelectByValue(value);
        }

        /// <summary>
        /// Obtenha combo box.
        /// </summary>
        /// <param name="cssSeletor">Seletor referente a combo box.</param>
        /// <param name="index">O indice para seleção da combo.</param>
        public void SelecioneValueCombo(string cssSeletor, int index)
        {
            var combobox = ObtenhaCombo(cssSeletor);
            combobox.SelectByIndex(index);
        }

        private SelectElement ObtenhaCombo(string cssSelector)
        {
            return new SelectElement(By.CssSelector(cssSelector).FindElement(ComponenteDeTela.WebDriver));
        }

        private void ExecuteScript(string script)
        {
            ComponenteDeTela.Script.ExecuteCodigoJavaScript(script);
        }
    }
}
