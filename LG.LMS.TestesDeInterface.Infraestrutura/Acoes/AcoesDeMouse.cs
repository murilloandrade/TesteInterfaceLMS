//-----------------------------------------------------------------------
// <copyright file="AcoesDeMouse.cs" company="LG Sistemas">
//     Copyright © LG Sistemas. All rights reserved.
//     TODOS OS DIREITOS RESERVADOS.
// </copyright>
//-----------------------------------------------------------------------

using LG.LMS.TestesDeInterface.Infraestrutura.Interfaces;
using OpenQA.Selenium;

namespace LG.LMS.TestesDeInterface.Infraestrutura.Acoes
{
    /// <summary>
    /// Ações de mouse.
    /// </summary>
    internal sealed class AcoesDeMouse : AcoesDeTela, IAcoesDeMouse
    {
        internal AcoesDeMouse(ComponenteDeTela componenteDeTela)
            : base(componenteDeTela)
        {
        }

        /// <summary>
        /// Clica em um elemento usando JavaScript em vez do Selenium.
        /// </summary>
        /// <param name="idElemento">O ID do elemento a ser clicado.</param>
        public void CliqueComJavaScriptElementoPorId(string idElemento)
        {
            ComponenteDeTela.Espera.AguardeElementoVisivel(By.Id(idElemento));
            ComponenteDeTela.Script.ExecuteCodigoJavaScript(string.Concat("$('#", idElemento, "').click();"));
        }

        /// <summary>
        /// Clica em um elemento selecionando-se com um seletor de classe com jQuery.
        /// </summary>
        /// <param name="classe">A classe CSS a ser usada para se obter o elemento a ser clicado.</param>
        public void CliqueElementoPorClasse(string classe)
        {
            ComponenteDeTela.Espera.AguardeElementoVisivel(By.ClassName(classe));

            var scriptClique = string.Concat("$('.", classe, "').click();");

            ComponenteDeTela.Script.ExecuteCodigoJavaScript(scriptClique);
        }

        /// <summary>
        /// Clica um elemento que possui um ID específico.
        /// </summary>
        /// <param name="idDoElemento">O ID do elemento a ser clicado.</param>
        public void CliqueElementoPorId(string idDoElemento)
        {
            CliqueElemento(By.Id(idDoElemento));
        }

        /// <summary>
        /// Clica um elemento que possui um name específico.
        /// </summary>
        /// <param name="nameDoElemento">O name do elemento a ser clicado.</param>
        public void CliqueElementoPorName(string nameDoElemento)
        {
            CliqueElemento(By.Name(nameDoElemento));
        }

        /// <summary>
        /// Clica um elemento que possui um css específico.
        /// </summary>
        /// <param name="cssDoElemento">O css do elemento a ser clicado.</param>
        public void CliqueElementoPorCss(string cssDoElemento)
        {
            CliqueElemento(By.CssSelector(cssDoElemento));
        }

        /// <summary>
        /// Executa um duplo clique em um elemento de ID específico.
        /// </summary>
        /// <param name="idDoElemento">O ID do elemento no qual o duplo clique deve ser executado.</param>
        public void DuploCliqueElementoPorID(string idDoElemento)
        {
            PrepareElementoParaReceberClick(By.Id(idDoElemento));

            var scriptDuploClique = string.Concat("$('#", idDoElemento, "').dblclick();");

            ComponenteDeTela.Script.ExecuteCodigoJavaScript(scriptDuploClique);
        }

        /// <summary>
        /// Clica em um elemento selecionando-se por XPATH.
        /// </summary>
        /// <param name="xPath">A XPATH do elemento a ser clicado no DOM (Document Object Model).</param>
        public void CliqueElementoPorXPath(string xPath)
        {
            CliqueElemento(By.XPath(xPath));
        }

        /// <summary>
        /// Executa um duplo clique em um elemento selecionando-se por XPATH.
        /// </summary>
        /// <param name="xPath">A XPATH do elemento a ser clicado no DOM (Document Object Model).</param>
        public void DuploCliqueElementoPorXPath(string xPath)
        {
            PrepareElementoParaReceberClick(By.XPath(xPath));

            var elementoAlvoDoDuploClique = ComponenteDeTela.Script.ObtenhaElementoPorJavaScript(xPath);
            var scriptDuploClique = string.Concat(elementoAlvoDoDuploClique, ".dblclick();");

            ComponenteDeTela.Script.ExecuteCodigoJavaScript(scriptDuploClique);
        }

        /// <summary>
        /// Marca um radio button ou checkbox, não alterando o estado do elemento caso ele já esteja marcado.
        /// </summary>
        /// <param name="idElemento">O ID do elemento radio button ou checkbox a ser marcado.</param>
        public void MarqueRadioOuCheckbox(string idElemento)
        {
            ComponenteDeTela.Espera.AguardeElementoVisivel(By.Id(idElemento));
            ComponenteDeTela.Script.ExecuteCodigoJavaScript(string.Concat("$('#", idElemento, "').attr('checked', 'checked');"));
        }

        /// <summary>
        /// Desmarca ou remove a seleção de um radio button ou checkbox.
        /// </summary>
        /// <param name="idElemento">O ID do radio button ou da checkbox a ser desmarcado(a).</param>
        public void DesmarqueRadioOuCheckbox(string idElemento)
        {
            ComponenteDeTela.Espera.AguardeElementoVisivel(By.Id(idElemento));
            ComponenteDeTela.Script.ExecuteCodigoJavaScript(string.Concat("$('#", idElemento, "').attr('checked', null);"));
        }

        /// <summary>
        /// Realiza um clique no conceito.
        /// </summary>
        /// <param name="idElemento">O ID do elemento a ser clicado.</param>
        public void CliqueRadioOuCheckbox(string idElemento)
        {
            ComponenteDeTela.Espera.AguardeElementoVisivel(By.Id(idElemento));
            ComponenteDeTela.Script.ExecuteCodigoJavaScript(string.Concat("$('#", idElemento, "').click();"));
        }

        /// <summary>
        /// Seleciona uma opção no dropDown list.
        /// </summary>
        /// <param name="idElement">Id do elemento.</param>
        /// <param name="valor">Valor a ser selecionado.</param>
        public void SelecionaElementoDropDownList(string idElement, string valor)
        {
            var dropDownList = ComponenteDeTela.Script.ObtenhaElementoPorSelenium(By.Id(idElement));
            dropDownList.SendKeys(valor);
        }

        /// <summary>
        /// Clica em um elemento por meio de um seletor do Selenium.
        /// </summary>
        /// <param name="seletor">O seletor do Selenium.</param>
        public void CliqueElemento(By seletor)
        {
            PrepareElementoParaReceberClick(seletor);
            ComponenteDeTela.Script.ObtenhaElementoPorSelenium(seletor).Click();
        }

        /// <summary>
        /// Clica em um elemento de link.
        /// </summary>
        /// <param name="nomeDoLink">O nome do link.</param>
        public void CliqueNoLink(string nomeDoLink)
        {
            var seletor = By.LinkText(nomeDoLink);
            CliqueElemento(seletor);
        }

        private void PrepareElementoParaReceberClick(By seletor)
        {
            // É necessário aguardar até que a animação de carregamento tenha sido tirada da tela, pois caso contrário
            // o driver iria clicar no overlay do carregamento, e não no elemento desejado.
            ComponenteDeTela.Espera.AguardeElementoVisivel(seletor);
        }
    }
}
