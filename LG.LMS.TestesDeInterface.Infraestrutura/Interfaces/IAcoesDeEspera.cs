//-----------------------------------------------------------------------
// <copyright file="IAcoesDeEspera.cs" company="LG Sistemas">
//     Copyright © LG Sistemas. All rights reserved.
//     TODOS OS DIREITOS RESERVADOS.
// </copyright>
//-----------------------------------------------------------------------

using System;
using OpenQA.Selenium;

namespace LG.LMS.TestesDeInterface.Infraestrutura.Interfaces
{
    /// <summary>
    /// Ações de espera.
    /// </summary>
    public interface IAcoesDeEspera
    {
        /// <summary>
        /// Aguarda até que um elemento de ID específico esteja presente na tela antes de continuar a execução dos comandos do teste.
        /// Note que esse método é diferente do método AguardeElementoVisivel.
        /// </summary>
        /// <param name="id">O ID do elemento pelo qual o teste irá aguardar.</param>
        void AguardeElementoPresentePorId(string id);

        /// <summary>
        /// Aguarda até que um determinado campo da tela esteja preenchido com texto antes de continuar com a execução dos comandos do teste.
        /// </summary>
        /// <param name="idCampo">O ID do campo que deverá estar preenchido com texto.</param>
        void AguardeCampoContemTexto(string idCampo);

        /// <summary>
        /// Espera até que um elemento de ID específico esteja visível na tela antes de prosseguir com a execução dos comandos do teste.
        /// Note que esse método é diferente do método AguardeElementoPresente.
        /// </summary>
        /// <param name="id">O ID do elemento que se deseja esperar estar visível.</param>
        void AguardeElementoVisivelPorID(string id);

        /// <summary>
        /// Espera até que um elemento de XPath específica esteja visível na tela antes de prosseguir com a execução dos comandos do teste.
        /// Note que esse método é diferente do método AguardeElementoPresente.
        /// </summary>
        /// <param name="xpath">A XPath do elemento que se deseja esperar estar visível.</param>
        void AguardeElementoVisivelPorXPath(string xpath);

        /// <summary>
        /// Espera Customizado que espera uma ação customizada.
        /// </summary>
        /// <param name="acao">Função que será executada até condição ser verdadeira ou atingir o tempo limite.</param>
        void AguardeCustomizado(Func<IWebDriver, bool> acao);

        /// <summary>
        /// Espera um número específico de segundos antes de continuar a execução dos comandos do teste.
        /// </summary>
        /// <param name="segundos">O número de segundos que a ser esperado antes de executar o próximo comando do teste.</param>
        void AguardeIntervaloDeTempo(int segundos);

        /// <summary>
        /// Espera um número específico de milissegundos antes de continuar a execução dos comandos do teste.
        /// </summary>
        /// <param name="milissegundos">O número de milissegundos que a ser esperado antes de executar o próximo comando do teste.</param>
        void AguardeIntervaloDeTempoPorMilissegundos(int milissegundos);

        /// <summary>
        /// Aguarda até que um campo de texto contenha um texto específico.
        /// </summary>
        /// <param name="idDoCampo">O ID do campo de texto.</param>
        /// <param name="textoEsperadoParaOCampo">O texto que o browser irá aguardar que esteja presente no campo de texto.</param>
        void AguardeCampoContemTexto(string idDoCampo, string textoEsperadoParaOCampo);

        /// <summary>
        /// Aguarda ate que o script informado retorne true ao ser executado.
        /// </summary>
        /// <param name="script">O código JavaScript a ser executado para se verificar se a condição de espera já foi executada.</param>
        void AguardeScript(string script);

        /// <summary>
        /// Aguarda até que a animação de carregamento seja removida da tela antes de prosseguir com a execução dos testes.
        /// </summary>
        void AguardeConclusaoDoCarregamento();

        /// <summary>
        /// Espera até que o elemento informado esteja visível na tela.
        /// </summary>
        /// <param name="seletor">O seletor que será usado pelo Selenium para encontrar o elemento na tela.</param>
        void AguardeElementoVisivel(By seletor);

        /// <summary>
        /// Espera até que um elemento de ID específico esteja invisível na tela antes de prosseguir com a execução dos comandos do teste.
        /// </summary>
        /// <param name="id">O ID do elemento que se deseja esperar estar invisível.</param>
        void AguardeElementoInvisivelPorID(string id);

        /// <summary>
        /// Espera até que um elemento esteja invisível na tela antes de prosseguir com a execução dos comandos do teste.
        /// </summary>
        /// <param name="classeCss">O seletor que será usado pelo Selenium para encontrar o elemento na tela.</param>
        void AguardeElementoInvisivelPorClasse(string classeCss);

        /// <summary>
        /// Espera até que um elemento com uma classe css esteja visível na tela antes 
        /// de prosseguir com a execução dos comandos do teste.
        /// </summary>
        /// <param name="classeCss">O ID do elemento que se deseja esperar estar visível.</param>
        void AguardeElementoVisivelPorClasse(string classeCss);

        /// <summary>
        /// Espera até que o elemento esteja visível.
        /// </summary>
        /// <param name="seletor">O seletor do elemento.</param>
        void AguardeElementoVisivelExpectedConditions(By seletor);

        /// <summary>
        /// Espera até que o elemento esteja disponível para ser clicado.
        /// </summary>
        /// <param name="seletor">O seletor do elemento que deseja clicar.</param>
        void AguardeElementoClicavel(By seletor);

        /// <summary>
        /// Espera até que o elemento esteja disponível para ser clicado.
        /// </summary>
        /// <param name="elemento">O elemento em que se deseja clicar.</param>
        void AguardeElementoClicavel(IWebElement elemento);

        /// <summary>
        /// Aguarda até que elemento esteja presente.
        /// </summary>
        /// <param name="seletor">O seletor do elemento que deseja aguardar.</param>
        void AguardeElementoExistir(By seletor);

        /// <summary>
        /// Verifica se o texto foi escrito corretamente, caso não ele tenta ser escrito novamente.
        /// </summary>
        /// <param name="seletor">O seletor css do elemento que deseja aguardar.</param>
        /// <param name="texto">O texto que será inserido no campo.</param>
        void AguardaTextoSerEscritoPorCss(string seletor, string texto);

        /// <summary>
        /// Verifica se o texto foi escrito corretamente, caso não ele tenta ser escrito novamente.
        /// </summary>
        /// <param name="seletor">O seletor css do elemento que deseja aguardar.</param>
        /// <param name="texto">O texto que será inserido no campo.</param>
        void AguardaTextoSerEscrito(By seletor, string texto);

        /// <summary>
        /// Verifica se o texto foi escrito corretamente, caso não ele tenta ser escrito novamente.
        /// </summary>
        /// <param name="elemento">O elemento que deseja aguardar.</param>
        /// <param name="texto">O texto que será inserido no campo.</param>
        void AguardaTextoSerEscrito(IWebElement elemento, string texto);

        /// <summary>
        /// Aguarde elemento por ID esteja visivel e presente.
        /// </summary>
        /// <param name="idElemento">O ID do elemento.</param>
        void AguardeElemento(string idElemento);

        /// <summary>
        /// Aguarde elemento por NAME esteja visivel e presente.
        /// </summary>
        /// <param name="nameElemento">O NAME do elemento.</param>
        void AguardeElementoPorName(string nameElemento);

        /// <summary>
        /// Aguarde elemento por CSS esteja visivel e presente.
        /// </summary>
        /// <param name="cssElemento">O CSS do elemento.</param>
        void AguardeElementoPorCss(string cssElemento);

        /// <summary>
        /// Aguarda até que o elemento informado esteja visível antes de prosseguir a execução do teste.
        /// </summary>
        /// <param name="seletor">O seletor que será usado para encontrar o elemento na tela.</param>
        void AguardeElementoPresente(By seletor);

        /// <summary>
        /// Espera até que um campo esteja preenchido com qualquer valor antes de prosseguir a execução do teste de tela.
        /// </summary>
        /// <param name="idElemento">O ID do elemento que deverá conter valor antes do teste continuar a ser executado.</param>
        void AguardeCampoContemValor(string idElemento);

        /// <summary>
        /// Espera até que a página esteja carregada.
        /// </summary>
        void AguardePaginaCarregada();
    }
}
