//-----------------------------------------------------------------------
// <copyright file="AcoesDeScript.cs" company="LG Sistemas">
//     Copyright © LG Sistemas. All rights reserved.
//     TODOS OS DIREITOS RESERVADOS.
// </copyright>
//-----------------------------------------------------------------------

using System;
using System.Globalization;
using System.Linq;
using LG.LMS.TestesDeInterface.Infraestrutura.Interfaces;
using NUnit.Framework;
using OpenQA.Selenium;

namespace LG.LMS.TestesDeInterface.Infraestrutura.Acoes
{
    /// <summary>
    /// Ações de script.
    /// </summary>
    internal sealed class AcoesDeScript : AcoesDeTela, IAcoesDeScript
    {
        internal AcoesDeScript(ComponenteDeTela componenteDeTela)
            : base(componenteDeTela)
        {
        }

        /// <summary>
        /// Obtém o valor de um atributo de um determinado elemento.
        /// </summary>
        /// <param name="idElemento">O ID do elemento cujo atributo deseja-se obter.</param>
        /// <param name="nomeDoAtributo">O nome do atributo cujo valor deseja-se obter.</param>
        /// <returns>Retorna uma string correspondente ao valor do atributo do elemento.</returns>
        public string ObtenhaAtributo(string idElemento, string nomeDoAtributo)
        {
            var scriptObterValor = string.Concat("return $('#", idElemento, "').attr('", nomeDoAtributo, "');");
            return ExecuteCodigoJavaScript(scriptObterValor).ToString();
        }

        /// <summary>
        /// Obtém o valor de um atributo de um determinado elemento.
        /// </summary>
        /// <param name="nameElemento">O NAME do elemento cujo atributo deseja-se obter.</param>
        /// <param name="nomeDoAtributo">O nome do atributo cujo valor deseja-se obter.</param>
        /// <returns>Retorna uma string correspondente ao valor do atributo do elemento.</returns>
        public string ObtenhaAtributoPorName(string nameElemento, string nomeDoAtributo)
        {
            var scriptObterValor = string.Format(CultureInfo.InvariantCulture, "return $('[name=\"{0}\"]').attr('{1}');", nameElemento, nomeDoAtributo);
            return ExecuteCodigoJavaScript(scriptObterValor).ToString();
        }

        /// <summary>
        /// Obtém o valor de um atributo de um determinado elemento.
        /// </summary>
        /// <param name="cssElemento">O CSS do elemento cujo atributo deseja-se obter.</param>
        /// <param name="nomeDoAtributo">O nome do atributo cujo valor deseja-se obter.</param>
        /// <returns>Retorna uma string correspondente ao valor do atributo do elemento.</returns>
        public string ObtenhaAtributoPorCss(string cssElemento, string nomeDoAtributo)
        {
            var scriptObterValor = string.Format(CultureInfo.InvariantCulture, "return $('{0}').attr('{1}');", cssElemento, nomeDoAtributo);
            return ExecuteCodigoJavaScript(scriptObterValor).ToString();
        }

        /// <summary>
        /// Obtém o texto que está escrito em um campo na tela.
        /// </summary>
        /// <param name="idDoElemento">O ID do elemento cujo texto se deseja obter.</param>
        /// <returns>Retorna o texto que está escrito no campo especificado.</returns>
        public string ObtenhaTextoDoElemento(string idDoElemento)
        {
            return ExecuteCodigoJavaScript(string.Concat("return $('#", idDoElemento, "').text();")).ToString();
        }

        /// <summary>
        /// Obtém o texto que está escrito em um campo na tela.
        /// </summary>
        /// <param name="nameDoElemento">O NAME do elemento cujo texto se deseja obter.</param>
        /// <returns>Retorna o texto que está escrito no campo especificado.</returns>
        public string ObtenhaTextoDoElementoPorName(string nameDoElemento)
        {
            return ExecuteCodigoJavaScript(string.Format(CultureInfo.InvariantCulture, "return $('[name=\"{0}\"]').text();", nameDoElemento)).ToString();
        }

        /// <summary>
        /// Obtém o texto que está escrito em um campo na tela.
        /// </summary>
        /// <param name="cssDoElemento">O CSS do elemento cujo texto se deseja obter.</param>
        /// <returns>Retorna o texto que está escrito no campo especificado.</returns>
        public string ObtenhaTextoDoElementoPorCss(string cssDoElemento)
        {
            return ExecuteCodigoJavaScript(string.Format(CultureInfo.InvariantCulture, "return $('{0}').text();", cssDoElemento)).ToString();
        }

        /// <summary>
        /// Obtém o valor de um determinado elemento do DOM.
        /// </summary>
        /// <param name="idElemento">O ID do elemento cujo valor deve ser obtido.</param>
        /// <returns>Retorna o valor atualmente contido no elemento informado.</returns>
        public string ObtenhaValorElemento(string idElemento)
        {
            return ObtenhaAtributo(idElemento, "value");
        }

        /// <summary>
        /// Clica na checkbox.
        /// </summary>
        /// <param name="condicao">Define se quer marcar ou não.</param>
        /// <param name="seletor">Seletor da checkbox.</param>
        public void CliqueCheckBox(bool condicao, string seletor)
        {
            ComponenteDeTela.Script.ExecuteCodigoJavaScript(string.Format(CultureInfo.InvariantCulture, "$(\"{0}\").prop('checked', {1}).change()", seletor, condicao.ToString().ToLower(CultureInfo.InvariantCulture)));
        }

        /// <summary>
        /// Obtém o valor de um determinado elemento do DOM.
        /// </summary>
        /// <param name="nameElemento">O NAME do elemento cujo valor deve ser obtido.</param>
        /// <returns>Retorna o valor atualmente contido no elemento informado.</returns>
        public string ObtenhaValorElementoPorName(string nameElemento)
        {
            var script = string.Format(CultureInfo.InvariantCulture, "return $('[name=\"{0}\"]').val()", nameElemento);
            return ExecuteCodigoJavaScript(script).ToString();
        }

        /// <summary>
        /// Obtém o valor de um determinado elemento do DOM.
        /// </summary>
        /// <param name="cssElemento">O CSS do elemento cujo valor deve ser obtido.</param>
        /// <returns>Retorna o valor atualmente contido no elemento informado.</returns>
        public string ObtenhaValorElementoPorCss(string cssElemento)
        {
            var script = string.Format(CultureInfo.InvariantCulture, "return $('{0}').val()", cssElemento);
            return ExecuteCodigoJavaScript(script).ToString();
        }

        /// <summary>
        /// Avalia uma expressão javascript em true ou false.
        /// </summary>
        /// <param name="script">A expressaoJavaScript a ser avaliada. Por exemplo, '"0 > 3" ou "return texto.indexOf('x') > -1". Informar a palavra-chave 'return' no inicio da expressão
        /// é opcional.</param>
        /// <returns>Retorna o valor booleano corespondente à expressão javascript que foi avaliada.</returns>
        public bool AvalieBooleanJavaScript(string script)
        {
            if (!script.StartsWith("return", StringComparison.OrdinalIgnoreCase))
            {
                script = string.Concat("return ", script);
            }

            return bool.Parse(ExecuteCodigoJavaScript(script).ToString());
        }

        /// <summary>
        /// Obtém um elemento por meio de um seletor que retorna o objeto jQuery correspondente ao elemento que possui a XPath informada.
        /// </summary>
        /// <param name="xPath">A XPath do elemento que se deseja obter.</param>
        /// <returns>Retorna um seletor que retorna o objeto jQuery correspondente ao elemento que possui a XPath informada.</returns>
        public string ObtenhaElementoPorJavaScript(string xPath)
        {
            return string.Concat("$(document.evaluate( \"", xPath, "\" ,document, null, XPathResult.FIRST_ORDERED_NODE_TYPE, null ).singleNodeValue)");
        }

        /// <summary>
        /// Obtém um elemento por meio de um seletor do Selenium.
        /// </summary>
        /// <param name="seletor">O seletor a ser usado para obter o elemento desejado.</param>
        /// <returns>Retorna um objeto representando um elemento do DOM.</returns>
        public IWebElement ObtenhaElementoPorSelenium(By seletor)
        {
            var elementoEncontrado = WebDriver.FindElements(seletor).FirstOrDefault();

            if (elementoEncontrado == null)
            {
                Assert.Fail(string.Concat("O elemento ", seletor.ToString(), " não existe na tela sendo testada ou não foi possível encontrá-lo."));
            }

            return elementoEncontrado;
        }

        /// <summary>
        /// Executa um código JavaScript.
        /// </summary>
        /// <param name="script">O código JavaScript a ser executado.</param>
        /// <returns>Retorna o resultado retornado pela execução do código JavaScript.</returns>
        public object ExecuteCodigoJavaScript(string script)
        {
            return JavaScript.ExecuteScript(script);
        }

        /// <summary>
        /// Informa se um elemento de ID específico existe na tela.
        /// </summary>
        /// <param name="id">O ID do elemento que se deseja verificar se existe.</param>
        /// <returns>Retorna true se o elemento existir, e false se o elemento não existir.</returns>
        public bool ExisteElementoPorId(string id)
        {
            return AvalieBooleanJavaScript(string.Concat("return $('#", id, "').length > 0;"));
        }

        /// <summary>
        /// Informa se um elemento de NAME específico existe na tela.
        /// </summary>
        /// <param name="name">O NAME do elemento que se deseja verificar se existe.</param>
        /// <returns>Retorna true se o elemento existir, e false se o elemento não existir.</returns>
        public bool ExisteElementoPorName(string name)
        {
            return AvalieBooleanJavaScript(string.Format(CultureInfo.InvariantCulture, "return $('[name=\"{0}\"]').length > 0;", name));
        }

        /// <summary>
        /// Informa se um elemento de CSS específico existe na tela.
        /// </summary>
        /// <param name="css">O CSS do elemento que se deseja verificar se existe.</param>
        /// <returns>Retorna true se o elemento existir, e false se o elemento não existir.</returns>
        public bool ExisteElementoPorCss(string css)
        {
            return AvalieBooleanJavaScript(string.Format(CultureInfo.InvariantCulture, "return $('{0}').length > 0;", css));
        }

        /// <summary>
        /// Informa se um determinado elemento está visível na tela.
        /// </summary>
        /// <param name="idElemento">O ID do elemento que se deseja saber se está visível.</param>
        /// <returns>Retorna true caso o elemento esteja visível, e false caso ele esteja invisível.</returns>
        public bool ElementoEstaVisivel(string idElemento)
        {
            ComponenteDeTela.Espera.AguardeElementoPresente(By.Id(idElemento));

            return AvalieBooleanJavaScript(string.Concat("return $('#", idElemento, "').is(':visible');"));
        }
    }
}
