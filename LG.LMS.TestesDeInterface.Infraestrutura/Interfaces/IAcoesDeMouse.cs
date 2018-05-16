//-----------------------------------------------------------------------
// <copyright file="IAcoesDeMouse.cs" company="LG Sistemas">
//     Copyright © LG Sistemas. All rights reserved.
//     TODOS OS DIREITOS RESERVADOS.
// </copyright>
//-----------------------------------------------------------------------

using OpenQA.Selenium;

namespace LG.LMS.TestesDeInterface.Infraestrutura.Interfaces
{
    /// <summary>
    /// Ações de mouse.
    /// </summary>
    public interface IAcoesDeMouse
    {
        /// <summary>
        /// Clica em um elemento usando JavaScript em vez do Selenium.
        /// </summary>
        /// <param name="idElemento">O ID do elemento a ser clicado.</param>
        void CliqueComJavaScriptElementoPorId(string idElemento);

        /// <summary>
        /// Clica em um elemento selecionando-se com um seletor de classe com jQuery.
        /// </summary>
        /// <param name="classe">A classe CSS a ser usada para se obter o elemento a ser clicado.</param>
        void CliqueElementoPorClasse(string classe);

        /// <summary>
        /// Clica um elemento que possui um ID específico.
        /// </summary>
        /// <param name="idDoElemento">O ID do elemento a ser clicado.</param>
        void CliqueElementoPorId(string idDoElemento);

        /// <summary>
        /// Clica um elemento que possui um name específico.
        /// </summary>
        /// <param name="nameDoElemento">O name do elemento a ser clicado.</param>
        void CliqueElementoPorName(string nameDoElemento);

        /// <summary>
        /// Clica um elemento que possui um css específico.
        /// </summary>
        /// <param name="cssDoElemento">O css do elemento a ser clicado.</param>
        void CliqueElementoPorCss(string cssDoElemento);

        /// <summary>
        /// Executa um duplo clique em um elemento de ID específico.
        /// </summary>
        /// <param name="idDoElemento">O ID do elemento no qual o duplo clique deve ser executado.</param>
        void DuploCliqueElementoPorID(string idDoElemento);

        /// <summary>
        /// Clica em um elemento selecionando-se por XPATH.
        /// </summary>
        /// <param name="xPath">A XPATH do elemento a ser clicado no DOM (Document Object Model).</param>
        void CliqueElementoPorXPath(string xPath);

        /// <summary>
        /// Executa um duplo clique em um elemento selecionando-se por XPATH.
        /// </summary>
        /// <param name="xPath">A XPATH do elemento a ser clicado no DOM (Document Object Model).</param>
        void DuploCliqueElementoPorXPath(string xPath);

        /// <summary>
        /// Marca um radio button ou checkbox, não alterando o estado do elemento caso ele já esteja marcado.
        /// </summary>
        /// <param name="idElemento">O ID do elemento radio button ou checkbox a ser marcado.</param>
        void MarqueRadioOuCheckbox(string idElemento);

        /// <summary>
        /// Desmarca ou remove a seleção de um radio button ou checkbox.
        /// </summary>
        /// <param name="idElemento">O ID do radio button ou da checkbox a ser desmarcado(a).</param>
        void DesmarqueRadioOuCheckbox(string idElemento);

        /// <summary>
        /// Realiza um clique no conceito.
        /// </summary>
        /// <param name="idElemento">O ID do elemento a ser clicado.</param>
        void CliqueRadioOuCheckbox(string idElemento);

        /// <summary>
        /// Seleciona uma opção no dropDown list.
        /// </summary>
        /// <param name="idElement">Id do elemento.</param>
        /// <param name="valor">Valor a ser selecionado.</param>
        void SelecionaElementoDropDownList(string idElement, string valor);

        /// <summary>
        /// Clica em um elemento por meio de um seletor do Selenium.
        /// </summary>
        /// <param name="seletor">O seletor do Selenium.</param>
        void CliqueElemento(By seletor);

        /// <summary>
        /// Clica em um elemento de link.
        /// </summary>
        /// <param name="nomeDoLink">O nome do link.</param>
        void CliqueNoLink(string nomeDoLink);
    }
}
