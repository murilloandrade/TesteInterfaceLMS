//-----------------------------------------------------------------------
// <copyright file="WebElementCustomizado.cs" company="LG Sistemas">
//     Copyright © LG Sistemas. All rights reserved.
//     TODOS OS DIREITOS RESERVADOS.
// </copyright>
//-----------------------------------------------------------------------

using System.Collections.ObjectModel;
using System.Drawing;
using OpenQA.Selenium;

namespace LG.LMS.TestesDeInterface.Infraestrutura.Utilitarios
{
    /// <summary>
    /// Web element customizado para pesquisa.
    /// </summary>
    public class WebElementCustomizado : IWebElementCustomizado
    {
        private readonly IWebElement _element;
        private readonly IJavaScriptExecutor _javaScript;
        private readonly string _cssElement;
        private readonly ISearchContext _contexto;

        public WebElementCustomizado(ISearchContext contexto, IWebElement element, string cssElement)
        {
            _element = element;
            _contexto = contexto;
            _javaScript = (IJavaScriptExecutor)_contexto;
            _cssElement = cssElement;
        }

        /// <summary>
        /// Obtém o indicativo se o elemento está visível.
        /// </summary>
        /// <value>
        /// O displayed do elemento.
        /// </value>
        public bool Displayed
        {
            get { return _element.Displayed; }
        }

        /// <summary>
        /// Obtém o indicativo se o elemento está habilitado.
        /// </summary>
        /// <value>
        /// O indicativo de habilitação do elemento.
        /// </value>
        public bool Enabled
        {
            get { return _element.Enabled; }
        }

        /// <summary>
        /// Obtém a localização do elemento.
        /// </summary>
        /// <value>
        /// A localização do elemento.
        /// </value>
        public Point Location
        {
            get { return _element.Location; }
        }

        /// <summary>
        /// Obtém o indicativo se o elemento está selecionado.
        /// </summary>
        /// <value>
        /// O indicativo de seleção.
        /// </value>
        public bool Selected
        {
            get { return _element.Selected; }
        }

        /// <summary>
        /// Obtém o tamanho do elemento.
        /// </summary>
        /// <value>
        /// O tamanho do elemento.
        /// </value>
        public Size Size
        {
            get { return _element.Size; }
        }

        /// <summary>
        /// Obtém o nome da tagName do elemento.
        /// </summary>
        /// <value>
        /// A tagName do elemento.
        /// </value>
        public string TagName
        {
            get { return _element.TagName; }
        }

        /// <summary>
        /// Obtém o texto do elemento.
        /// </summary>
        /// <value>
        /// O texto do elemento.
        /// </value>
        public string Text
        {
            get { return _element.Text; }
        }

        /// <summary>
        /// Abre a funcionalidade do elemento customizado.
        /// </summary>
        public void AbrirFuncionalidade()
        {
            var script = string.Concat("$(\"", _cssElement, "\").click()");
            _javaScript.ExecuteScript(script);
        }

        /// <summary>
        /// Abre a funcionalidade do elemento customizado.
        /// </summary>
        public void Click()
        {
            AbrirFuncionalidade();
        }

        /// <summary>
        /// Limpa o conteúdo do elemento.
        /// </summary>
        public void Clear()
        {
            _element.Clear();
        }

        /// <summary>
        /// Obtém o atributo do elemento.
        /// </summary>
        /// <param name="attributeName">O nome do atributo.</param>
        /// <returns>O atributo.</returns>
        public string GetAttribute(string attributeName)
        {
            return _element.GetAttribute(attributeName);
        }

        /// <summary>
        /// Obtém o valor css do elemento.
        /// </summary>
        /// <param name="propertyName">O nome da propriedade.</param>
        /// <returns>O valor css.</returns>
        public string GetCssValue(string propertyName)
        {
            return _element.GetCssValue(propertyName);
        }

        /// <summary>
        /// Preenche um texto no elemento.
        /// </summary>
        /// <param name="text">O texto a ser informado no elemento.</param>
        public void SendKeys(string text)
        {
            _element.SendKeys(text);
        }

        /// <summary>
        /// Envia um comando de submit para o server.
        /// </summary>
        public void Submit()
        {
            _element.Submit();
        }

        /// <summary>
        /// Obtém o elemento por selenium.
        /// </summary>
        /// <param name="by">O seletor.</param>
        /// <returns>O elemento consultado.</returns>
        public IWebElement FindElement(By by)
        {
            return _element.FindElement(by);
        }

        /// <summary>
        /// Obtém o elemento por selenium. 
        /// </summary>
        /// <param name="by">O seletor.</param>
        /// <returns>O elemento consultado.</returns>
        public ReadOnlyCollection<IWebElement> FindElements(By by)
        {
            return _element.FindElements(by);
        }
    }
}
