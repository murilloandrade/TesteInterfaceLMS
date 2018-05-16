//-----------------------------------------------------------------------
// <copyright file="AcoesDeTeclado.cs" company="LG Sistemas">
//     Copyright © LG Sistemas. All rights reserved.
//     TODOS OS DIREITOS RESERVADOS.
// </copyright>
//-----------------------------------------------------------------------

using System;
using System.Globalization;
using LG.LMS.TestesDeInterface.Infraestrutura.Enumeradores;
using LG.LMS.TestesDeInterface.Infraestrutura.Interfaces;
using OpenQA.Selenium;

namespace LG.LMS.TestesDeInterface.Infraestrutura.Acoes
{
    /// <summary>
    /// Ações de teclado.
    /// </summary>
    internal sealed class AcoesDeTeclado : AcoesDeTela, IAcoesDeTeclado
    {
        internal AcoesDeTeclado(ComponenteDeTela componenteDeTela)
            : base(componenteDeTela)
        {
        }

        /// <summary>
        /// Pressiona uma tecla do teclado em um elemento específico.
        /// </summary>
        /// <param name="idElemento">A ID do elemento onde a tecla deve ser digitada.</param>
        /// <param name="tecla">A tecla a ser digitada.</param>
        public void PressioneTecla(string idElemento, EnumTeclas tecla)
        {
            var scriptPressionarTecla = string.Concat(
                @"var eventoKeydownWebDriver = jQuery.Event('keydown'); eventoKeydownWebDriver.which = ",
                (int)tecla,
                @"; $('#",
                idElemento,
                "').trigger(eventoKeydownWebDriver);");

            ComponenteDeTela.Script.ExecuteCodigoJavaScript(scriptPressionarTecla);
        }

        /// <summary>
        /// Digita um texto em um campo de texto da tela.
        /// </summary>
        /// <param name="idElemento">O ID do campo no qual o texto deve ser escrito.</param>
        /// <param name="texto">O texto a ser escrito no campo de texto.</param>
        public void EscrevaTexto(string idElemento, string texto)
        {
            EscrevaTexto(idElemento, texto, true);
        }

        /// <summary>
        /// Digita um texto em um campo de texto da tela e aguarda até ele todo ser escrito.
        /// As vezes por causa de uma requisição assíncrona o texto não é escrito por completo na página,
        /// caso isso ocorra, utilize esse método.
        /// </summary>
        /// <param name="cssElement">O Seletor css do campo em que se deseja digitar.</param>
        /// <param name="texto">O texto a ser escrito no campo de texto.</param>
        public void EscrevaTextoAguardandoCampoSerPreenchido(string cssElement, string texto)
        {
            ComponenteDeTela.Espera.AguardaTextoSerEscritoPorCss(cssElement, texto);
        }

        /// <summary>
        /// Digita um texto em um campo de texto da tela.
        /// </summary>
        /// <param name="idElemento">O ID do campo no qual o texto deve ser escrito.</param>
        /// <param name="texto">O texto a ser escrito no campo de texto.</param>
        /// <param name="aguardarElementoVisivel">Informa se é necessário esperar até que o elemento esteja visível antes de escrever o texto.</param>
        public void EscrevaTexto(string idElemento, string texto, bool aguardarElementoVisivel = true)
        {
            EscrevaTexto(
                By.Id(idElemento),
                () => ComponenteDeTela.Script.ExecuteCodigoJavaScript(string.Concat("$('#", idElemento, "').val('');")),
                texto,
                aguardarElementoVisivel);
        }

        /// <summary>
        /// Digita um texto em um campo de texto da tela.
        /// </summary>
        /// <param name="nameDoCampo">Name do campo.</param>
        /// <param name="texto">O texto a ser escrito no campo de texto.</param>
        public void EscrevaTextoPorName(string nameDoCampo, string texto)
        {
            EscrevaTextoPorName(nameDoCampo, texto, true);
        }

        /// <summary>
        /// Digita um texto em um campo de texto da tela.
        /// </summary>
        /// <param name="nameDoCampo">Name do campo.</param>
        /// <param name="texto">O texto a ser escrito no campo de texto.</param>
        /// <param name="aguardarElementoVisivel">Informa se é necessário esperar até que o elemento esteja visível antes de escrever o texto.</param>
        public void EscrevaTextoPorName(string nameDoCampo, string texto, bool aguardarElementoVisivel = true)
        {
            EscrevaTexto(
             By.Name(nameDoCampo),
             () => ComponenteDeTela.Script.ExecuteCodigoJavaScript(string.Format(CultureInfo.InvariantCulture, "$('[name=\"{0}\"]').val('')", nameDoCampo)),
             texto,
             aguardarElementoVisivel);
        }

        /// <summary>
        /// Digita um texto em um campo de texto da tela.
        /// </summary>
        /// <param name="cssDoCampo">Css do campo.</param>
        /// <param name="texto">O texto a ser escrito no campo de texto.</param>
        public void EscrevaTextoPorCss(string cssDoCampo, string texto)
        {
            EscrevaTextoPorCss(cssDoCampo, texto, true);
        }

        /// <summary>
        /// Digita um texto em um campo de texto da tela.
        /// </summary>
        /// <param name="cssDoCampo">Css do campo.</param>
        /// <param name="texto">O texto a ser escrito no campo de texto.</param>
        /// <param name="aguardarElementoVisivel">Informa se é necessário esperar até que o elemento esteja visível antes de escrever o texto.</param>
        public void EscrevaTextoPorCss(string cssDoCampo, string texto, bool aguardarElementoVisivel = true)
        {
            EscrevaTexto(
             By.CssSelector(cssDoCampo),
             () => ComponenteDeTela.Script.ExecuteCodigoJavaScript(string.Format(CultureInfo.InvariantCulture, "$(\"{0}\").val('')", cssDoCampo)),
             texto,
             aguardarElementoVisivel);
        }

        /// <summary>
        /// Atribui foco para um elemento da tela.
        /// </summary>
        /// <param name="idElemento">O ID do elemento HTML a ser focado.</param>
        public void FoqueElemento(string idElemento)
        {
            ComponenteDeTela.Espera.AguardeElementoVisivel(By.Id(idElemento));

            var scriptFocarElemento = string.Concat("$('#", idElemento, "').focus();");
            ComponenteDeTela.Script.ExecuteCodigoJavaScript(scriptFocarElemento);
        }

        /// <summary>
        /// Atribui foco para um elemento da tela.
        /// </summary>
        /// <param name="nameElemento">O NAME do elemento HTML a ser focado.</param>
        public void FoqueElementoPorName(string nameElemento)
        {
            ComponenteDeTela.Espera.AguardeElementoVisivel(By.Name(nameElemento));

            var scriptFocarElemento = string.Concat("$('[name=\"", nameElemento, "\"]').focus();");
            ComponenteDeTela.Script.ExecuteCodigoJavaScript(scriptFocarElemento);
        }

        /// <summary>
        /// Atribui foco para um elemento da tela.
        /// </summary>
        /// <param name="cssElemento">O CSS do elemento HTML a ser focado.</param>
        public void FoqueElementoPorCss(string cssElemento)
        {
            ComponenteDeTela.Espera.AguardeElementoVisivel(By.CssSelector(cssElemento));

            var scriptFocarElemento = string.Concat("$('", cssElemento, "').focus();");
            ComponenteDeTela.Script.ExecuteCodigoJavaScript(scriptFocarElemento);
        }

        /// <summary>
        /// Executa o evento blur de um elemento via JavaScript.
        /// </summary>
        /// <param name="idElemento">O ID do elemento cujo evento blur deve ser executado.</param>
        public void EfetueLostFocusElemento(string idElemento)
        {
            var scriptBlur = string.Concat("$('#", idElemento, "').blur();");
            ComponenteDeTela.Script.ExecuteCodigoJavaScript(scriptBlur);
        }

        /// <summary>
        /// Executa o evento blur de um elemento via JavaScript.
        /// </summary>
        /// <param name="nameElemento">O NAME do elemento cujo evento blur deve ser executado.</param>
        public void EfetueLostFocusElementoPorName(string nameElemento)
        {
            var scriptBlur = string.Concat("$('[name=\"", nameElemento, "\"]').blur();");
            ComponenteDeTela.Script.ExecuteCodigoJavaScript(scriptBlur);
        }

        /// <summary>
        /// Executa o evento blur de um elemento via JavaScript.
        /// </summary>
        /// <param name="cssElemento">O CSS do elemento cujo evento blur deve ser executado.</param>
        public void EfetueLostFocusElementoPorCss(string cssElemento)
        {
            var scriptBlur = string.Concat("$('", cssElemento, "').blur();");
            ComponenteDeTela.Script.ExecuteCodigoJavaScript(scriptBlur);
        }

        private void EscrevaTexto(By selector, Action limpaCampo, string texto, bool aguardarElementoVisivel)
        {
            ComponenteDeTela.Espera.AguardeElementoPresente(selector);

            if (aguardarElementoVisivel)
            {
                ComponenteDeTela.Espera.AguardeElementoVisivel(selector);
            }

            // Limpa o campo antes de digitar o novo texto.
            limpaCampo();

            var elemento = ComponenteDeTela.Script.ObtenhaElementoPorSelenium(selector);

            elemento.SendKeys(texto);
        }
    }
}
