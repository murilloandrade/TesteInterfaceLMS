//-----------------------------------------------------------------------
// <copyright file="IAcoesDeTeclado.cs" company="LG Sistemas">
//     Copyright © LG Sistemas. All rights reserved.
//     TODOS OS DIREITOS RESERVADOS.
// </copyright>
//-----------------------------------------------------------------------

using LG.LMS.TestesDeInterface.Infraestrutura.Enumeradores;

namespace LG.LMS.TestesDeInterface.Infraestrutura.Interfaces
{
    /// <summary>
    /// Ações de teclado.
    /// </summary>
    public interface IAcoesDeTeclado
    {
        /// <summary>
        /// Pressiona uma tecla do teclado em um elemento específico.
        /// </summary>
        /// <param name="idElemento">A ID do elemento onde a tecla deve ser digitada.</param>
        /// <param name="tecla">A tecla a ser digitada.</param>
        void PressioneTecla(string idElemento, EnumTeclas tecla);

        /// <summary>
        /// Digita um texto em um campo de texto da tela.
        /// </summary>
        /// <param name="idElemento">O ID do campo no qual o texto deve ser escrito.</param>
        /// <param name="texto">O texto a ser escrito no campo de texto.</param>
        void EscrevaTexto(string idElemento, string texto);

        /// <summary>
        /// Digita um texto em um campo de texto da tela e aguarda até ele todo ser escrito.
        /// As vezes por causa de uma requisição assíncrona o texto não é escrito por completo na página,
        /// caso isso ocorra, utilize esse método.
        /// </summary>
        /// <param name="cssElement">O Seletor css do campo em que se deseja digitar.</param>
        /// <param name="texto">O texto a ser escrito no campo de texto.</param>
        void EscrevaTextoAguardandoCampoSerPreenchido(string cssElement, string texto);

        /// <summary>
        /// Digita um texto em um campo de texto da tela.
        /// </summary>
        /// <param name="idElemento">O ID do campo no qual o texto deve ser escrito.</param>
        /// <param name="texto">O texto a ser escrito no campo de texto.</param>
        /// <param name="aguardarElementoVisivel">Informa se é necessário esperar até que o elemento esteja visível antes de escrever o texto.</param>
        void EscrevaTexto(string idElemento, string texto, bool aguardarElementoVisivel = true);

        /// <summary>
        /// Digita um texto em um campo de texto da tela.
        /// </summary>
        /// <param name="nameDoCampo">Name do campo.</param>
        /// <param name="texto">O texto a ser escrito no campo de texto.</param>
        void EscrevaTextoPorName(string nameDoCampo, string texto);

        /// <summary>
        /// Digita um texto em um campo de texto da tela.
        /// </summary>
        /// <param name="nameDoCampo">Name do campo.</param>
        /// <param name="texto">O texto a ser escrito no campo de texto.</param>
        /// <param name="aguardarElementoVisivel">Informa se é necessário esperar até que o elemento esteja visível antes de escrever o texto.</param>
        void EscrevaTextoPorName(string nameDoCampo, string texto, bool aguardarElementoVisivel = true);

        /// <summary>
        /// Digita um texto em um campo de texto da tela.
        /// </summary>
        /// <param name="cssDoCampo">Css do campo.</param>
        /// <param name="texto">O texto a ser escrito no campo de texto.</param>
        void EscrevaTextoPorCss(string cssDoCampo, string texto);

        /// <summary>
        /// Digita um texto em um campo de texto da tela.
        /// </summary>
        /// <param name="cssDoCampo">Css do campo.</param>
        /// <param name="texto">O texto a ser escrito no campo de texto.</param>
        /// <param name="aguardarElementoVisivel">Informa se é necessário esperar até que o elemento esteja visível antes de escrever o texto.</param>
        void EscrevaTextoPorCss(string cssDoCampo, string texto, bool aguardarElementoVisivel = true);

        /// <summary>
        /// Atribui foco para um elemento da tela.
        /// </summary>
        /// <param name="idElemento">O ID do elemento HTML a ser focado.</param>
        void FoqueElemento(string idElemento);

        /// <summary>
        /// Atribui foco para um elemento da tela.
        /// </summary>
        /// <param name="nameElemento">O NAME do elemento HTML a ser focado.</param>
        void FoqueElementoPorName(string nameElemento);

        /// <summary>
        /// Atribui foco para um elemento da tela.
        /// </summary>
        /// <param name="cssElemento">O CSS do elemento HTML a ser focado.</param>
        void FoqueElementoPorCss(string cssElemento);

        /// <summary>
        /// Executa o evento blur de um elemento via JavaScript.
        /// </summary>
        /// <param name="idElemento">O ID do elemento cujo evento blur deve ser executado.</param>
        void EfetueLostFocusElemento(string idElemento);

        /// <summary>
        /// Executa o evento blur de um elemento via JavaScript.
        /// </summary>
        /// <param name="nameElemento">O NAME do elemento cujo evento blur deve ser executado.</param>
        void EfetueLostFocusElementoPorName(string nameElemento);

        /// <summary>
        /// Executa o evento blur de um elemento via JavaScript.
        /// </summary>
        /// <param name="cssElemento">O CSS do elemento cujo evento blur deve ser executado.</param>
        void EfetueLostFocusElementoPorCss(string cssElemento);
    }
}
