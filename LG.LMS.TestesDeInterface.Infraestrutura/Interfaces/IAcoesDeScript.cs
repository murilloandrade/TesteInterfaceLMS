//-----------------------------------------------------------------------
// <copyright file="IAcoesDeScript.cs" company="LG Sistemas">
//     Copyright © LG Sistemas. All rights reserved.
//     TODOS OS DIREITOS RESERVADOS.
// </copyright>
//-----------------------------------------------------------------------

using OpenQA.Selenium;

namespace LG.LMS.TestesDeInterface.Infraestrutura.Interfaces
{
    /// <summary>
    /// Ações de spripts.
    /// </summary>
    public interface IAcoesDeScript
    {
        /// <summary>
        /// Obtém o valor de um atributo de um determinado elemento.
        /// </summary>
        /// <param name="idElemento">O ID do elemento cujo atributo deseja-se obter.</param>
        /// <param name="nomeDoAtributo">O nome do atributo cujo valor deseja-se obter.</param>
        /// <returns>Retorna uma string correspondente ao valor do atributo do elemento.</returns>
        string ObtenhaAtributo(string idElemento, string nomeDoAtributo);

        /// <summary>
        /// Obtém o valor de um atributo de um determinado elemento.
        /// </summary>
        /// <param name="nameElemento">O NAME do elemento cujo atributo deseja-se obter.</param>
        /// <param name="nomeDoAtributo">O nome do atributo cujo valor deseja-se obter.</param>
        /// <returns>Retorna uma string correspondente ao valor do atributo do elemento.</returns>
        string ObtenhaAtributoPorName(string nameElemento, string nomeDoAtributo);

        /// <summary>
        /// Obtém o valor de um atributo de um determinado elemento.
        /// </summary>
        /// <param name="cssElemento">O CSS do elemento cujo atributo deseja-se obter.</param>
        /// <param name="nomeDoAtributo">O nome do atributo cujo valor deseja-se obter.</param>
        /// <returns>Retorna uma string correspondente ao valor do atributo do elemento.</returns>
        string ObtenhaAtributoPorCss(string cssElemento, string nomeDoAtributo);

        /// <summary>
        /// Obtém o texto que está escrito em um campo na tela.
        /// </summary>
        /// <param name="idDoElemento">O ID do elemento cujo texto se deseja obter.</param>
        /// <returns>Retorna o texto que está escrito no campo especificado.</returns>
        string ObtenhaTextoDoElemento(string idDoElemento);

        /// <summary>
        /// Obtém o texto que está escrito em um campo na tela.
        /// </summary>
        /// <param name="nameDoElemento">O NAME do elemento cujo texto se deseja obter.</param>
        /// <returns>Retorna o texto que está escrito no campo especificado.</returns>
        string ObtenhaTextoDoElementoPorName(string nameDoElemento);

        /// <summary>
        /// Obtém o texto que está escrito em um campo na tela.
        /// </summary>
        /// <param name="cssDoElemento">O CSS do elemento cujo texto se deseja obter.</param>
        /// <returns>Retorna o texto que está escrito no campo especificado.</returns>
        string ObtenhaTextoDoElementoPorCss(string cssDoElemento);

        /// <summary>
        /// Obtém o valor de um determinado elemento do DOM.
        /// </summary>
        /// <param name="idElemento">O ID do elemento cujo valor deve ser obtido.</param>
        /// <returns>Retorna o valor atualmente contido no elemento informado.</returns>
        string ObtenhaValorElemento(string idElemento);

        /// <summary>
        /// Clica na checkbox.
        /// </summary>
        /// <param name="condicao">Define se quer marcar ou não.</param>
        /// <param name="seletor">Seletor da checkbox.</param>
        void CliqueCheckBox(bool condicao, string seletor);

        /// <summary>
        /// Obtém o valor de um determinado elemento do DOM.
        /// </summary>
        /// <param name="nameElemento">O NAME do elemento cujo valor deve ser obtido.</param>
        /// <returns>Retorna o valor atualmente contido no elemento informado.</returns>
        string ObtenhaValorElementoPorName(string nameElemento);

        /// <summary>
        /// Obtém o valor de um determinado elemento do DOM.
        /// </summary>
        /// <param name="cssElemento">O CSS do elemento cujo valor deve ser obtido.</param>
        /// <returns>Retorna o valor atualmente contido no elemento informado.</returns>
        string ObtenhaValorElementoPorCss(string cssElemento);

        /// <summary>
        /// Avalia uma expressão javascript em true ou false.
        /// </summary>
        /// <param name="script">A expressaoJavaScript a ser avaliada. Por exemplo, '"0 > 3" ou "return texto.indexOf('x') > -1". Informar a palavra-chave 'return' no inicio da expressão
        /// é opcional.</param>
        /// <returns>Retorna o valor booleano corespondente à expressão javascript que foi avaliada.</returns>
        bool AvalieBooleanJavaScript(string script);

        /// <summary>
        /// Obtém um elemento por meio de um seletor que retorna o objeto jQuery correspondente ao elemento que possui a XPath informada.
        /// </summary>
        /// <param name="xPath">A XPath do elemento que se deseja obter.</param>
        /// <returns>Retorna um seletor que retorna o objeto jQuery correspondente ao elemento que possui a XPath informada.</returns>
        string ObtenhaElementoPorJavaScript(string xPath);

        /// <summary>
        /// Obtém um elemento por meio de um seletor do Selenium.
        /// </summary>
        /// <param name="seletor">O seletor a ser usado para obter o elemento desejado.</param>
        /// <returns>Retorna um objeto representando um elemento do DOM.</returns>
        IWebElement ObtenhaElementoPorSelenium(By seletor);

        /// <summary>
        /// Executa um código JavaScript.
        /// </summary>
        /// <param name="script">O código JavaScript a ser executado.</param>
        /// <returns>Retorna o resultado retornado pela execução do código JavaScript.</returns>
        object ExecuteCodigoJavaScript(string script);

        /// <summary>
        /// Informa se um elemento de ID específico existe na tela.
        /// </summary>
        /// <param name="id">O ID do elemento que se deseja verificar se existe.</param>
        /// <returns>Retorna true se o elemento existir, e false se o elemento não existir.</returns>
        bool ExisteElementoPorId(string id);

        /// <summary>
        /// Informa se um elemento de NAME específico existe na tela.
        /// </summary>
        /// <param name="name">O NAME do elemento que se deseja verificar se existe.</param>
        /// <returns>Retorna true se o elemento existir, e false se o elemento não existir.</returns>
        bool ExisteElementoPorName(string name);

        /// <summary>
        /// Informa se um elemento de CSS específico existe na tela.
        /// </summary>
        /// <param name="css">O CSS do elemento que se deseja verificar se existe.</param>
        /// <returns>Retorna true se o elemento existir, e false se o elemento não existir.</returns>
        bool ExisteElementoPorCss(string css);

        /// <summary>
        /// Informa se um determinado elemento está visível na tela.
        /// </summary>
        /// <param name="idElemento">O ID do elemento que se deseja saber se está visível.</param>
        /// <returns>Retorna true caso o elemento esteja visível, e false caso ele esteja invisível.</returns>
        bool ElementoEstaVisivel(string idElemento);
    }
}
