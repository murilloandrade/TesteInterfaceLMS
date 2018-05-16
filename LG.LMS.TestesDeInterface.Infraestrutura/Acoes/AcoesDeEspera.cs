// <copyright file="AcoesDeEspera.cs" company="LG Sistemas">
//     Copyright © LG Sistemas. All rights reserved.
//     TODOS OS DIREITOS RESERVADOS.
// </copyright>
//-----------------------------------------------------------------------

using System;
using System.Globalization;
using System.Threading;
using LG.LMS.TestesDeInterface.Infraestrutura.Interfaces;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace LG.LMS.TestesDeInterface.Infraestrutura.Acoes
{
    /// <summary>
    /// Ações de espera.
    /// </summary>
    internal sealed class AcoesDeEspera : AcoesDeTela, IAcoesDeEspera
    {
        private string _textoEsperadoMensagem;
        private string _scriptDeEsperaCondicional;

        public AcoesDeEspera(ComponenteDeTela componenteDeTela)
            : base(componenteDeTela)
        {
        }

        /// <summary>
        /// Aguarda até que um elemento de ID específico esteja presente na tela antes de continuar a execução dos comandos do teste.
        /// Note que esse método é diferente do método AguardeElementoVisivel.
        /// </summary>
        /// <param name="id">O ID do elemento pelo qual o teste irá aguardar.</param>
        public void AguardeElementoPresentePorId(string id)
        {
            AguardeElementoPresente(By.Id(id));
        }

        /// <summary>
        /// Aguarda até que um determinado campo da tela esteja preenchido com texto antes de continuar com a execução dos comandos do teste.
        /// </summary>
        /// <param name="idCampo">O ID do campo que deverá estar preenchido com texto.</param>
        public void AguardeCampoContemTexto(string idCampo)
        {
            var seletorDoCampo = string.Concat("$('#", idCampo, "')");
            var scriptCampoContemTexto = string.Concat(seletorDoCampo, ".val() != '' || ", seletorDoCampo, ".text() != ''");

            AguardeScript(scriptCampoContemTexto);
        }

        /// <summary>
        /// Espera até que um elemento de ID específico esteja visível na tela antes de prosseguir com a execução dos comandos do teste.
        /// Note que esse método é diferente do método AguardeElementoPresente.
        /// </summary>
        /// <param name="id">O ID do elemento que se deseja esperar estar visível.</param>
        public void AguardeElementoVisivelPorID(string id)
        {
            AguardeElementoVisivel(By.Id(id));
        }

        /// <summary>
        /// Espera até que um elemento de XPath específica esteja visível na tela antes de prosseguir com a execução dos comandos do teste.
        /// Note que esse método é diferente do método AguardeElementoPresente.
        /// </summary>
        /// <param name="xpath">A XPath do elemento que se deseja esperar estar visível.</param>
        public void AguardeElementoVisivelPorXPath(string xpath)
        {
            AguardeElementoVisivel(By.XPath(xpath));
        }

        /// <summary>
        /// Espera Customizado que espera uma ação customizada.
        /// </summary>
        /// <param name="acao">Função que será executada até condição ser verdadeira ou atingir o tempo limite.</param>
        public void AguardeCustomizado(Func<IWebDriver, bool> acao)
        {
            Wait.Until(acao);
        }

        /// <summary>
        /// Espera um número específico de segundos antes de continuar a execução dos comandos do teste.
        /// </summary>
        /// <param name="segundos">O número de segundos que a ser esperado antes de executar o próximo comando do teste.</param>
        public void AguardeIntervaloDeTempo(int segundos)
        {
            AguardeIntervaloDeTempo(new TimeSpan(0, 0, segundos));
        }

        /// <summary>
        /// Espera um número específico de milissegundos antes de continuar a execução dos comandos do teste.
        /// </summary>
        /// <param name="milissegundos">O número de milissegundos que a ser esperado antes de executar o próximo comando do teste.</param>
        public void AguardeIntervaloDeTempoPorMilissegundos(int milissegundos)
        {
            AguardeIntervaloDeTempo(new TimeSpan(0, 0, 0, 0, milissegundos));
        }

        /// <summary>
        /// Aguarda até que um campo de texto contenha um texto específico.
        /// </summary>
        /// <param name="idDoCampo">O ID do campo de texto.</param>
        /// <param name="textoEsperadoParaOCampo">O texto que o browser irá aguardar que esteja presente no campo de texto.</param>
        public void AguardeCampoContemTexto(string idDoCampo, string textoEsperadoParaOCampo)
        {
            var scriptCampoContemTextoEsperado = string.Concat(
                "return ",
                ObtenhaScriptQueVerificaSeCampoContemValor(idDoCampo, textoEsperadoParaOCampo, "val"),
                " || ",
                ObtenhaScriptQueVerificaSeCampoContemValor(idDoCampo, textoEsperadoParaOCampo, "text"));

            AguardeScript(scriptCampoContemTextoEsperado);
        }

        /// <summary>
        /// Aguarda ate que o script informado retorne true ao ser executado.
        /// </summary>
        /// <param name="script">O código JavaScript a ser executado para se verificar se a condição de espera já foi executada.</param>
        public void AguardeScript(string script)
        {
            _scriptDeEsperaCondicional = script;
            Wait.Until(AguardeScriptCondicional);
        }

        /// <summary>
        /// Aguarda até que a animação de carregamento seja removida da tela antes de prosseguir com a execução dos testes.
        /// </summary>
        public void AguardeConclusaoDoCarregamento()
        {
            if (ComponenteDeTela.Script.AvalieBooleanJavaScript("$ != undefined && $('#loading-geral') != null"))
            {
                AguardeScript("return !$('#loading-geral').is(':visible') && $('#loading-geral').length > 0;");
            }
        }

        /// <summary>
        /// Espera até que o elemento informado esteja visível na tela.
        /// </summary>
        /// <param name="seletor">O seletor que será usado pelo Selenium para encontrar o elemento na tela.</param>
        public void AguardeElementoVisivel(By seletor)
        {
            AguardeElementoPresente(seletor);
            Wait.Until(d => d.FindElement(seletor).Displayed);
        }

        /// <summary>
        /// Espera até que um elemento de ID específico esteja invisível na tela antes de prosseguir com a execução dos comandos do teste.
        /// </summary>
        /// <param name="id">O ID do elemento que se deseja esperar estar invisível.</param>
        public void AguardeElementoInvisivelPorID(string id)
        {
            AguardeElementoInvisivel(By.Id(id));
        }

        /// <summary>
        /// Espera até que um elemento esteja invisível na tela antes de prosseguir com a execução dos comandos do teste.
        /// </summary>
        /// <param name="classeCss">O seletor que será usado pelo Selenium para encontrar o elemento na tela.</param>
        public void AguardeElementoInvisivelPorClasse(string classeCss)
        {
            AguardeElementoInvisivel(By.ClassName(classeCss));
        }

        /// <summary>
        /// Espera até que um elemento com uma classe css esteja visível na tela antes 
        /// de prosseguir com a execução dos comandos do teste.
        /// </summary>
        /// <param name="classeCss">O ID do elemento que se deseja esperar estar visível.</param>
        public void AguardeElementoVisivelPorClasse(string classeCss)
        {
            AguardeElementoVisivel(By.ClassName(classeCss));
        }

        /// <summary>
        /// Espera até que o elemento esteja visível.
        /// </summary>
        /// <param name="seletor">O seletor do elemento.</param>
        public void AguardeElementoVisivelExpectedConditions(By seletor)
        {
            Wait.Until(ExpectedConditions.ElementIsVisible(seletor));
        }

        /// <summary>
        /// Espera até que o elemento esteja disponível para ser clicado.
        /// </summary>
        /// <param name="seletor">O seletor do elemento que deseja clicar.</param>
        public void AguardeElementoClicavel(By seletor)
        {
            Wait.Until(ExpectedConditions.ElementToBeClickable(seletor));
        }

        /// <summary>
        /// Espera até que o elemento esteja disponível para ser clicado.
        /// </summary>
        /// <param name="elemento">O elemento em que se deseja clicar.</param>
        public void AguardeElementoClicavel(IWebElement elemento)
        {
            Wait.Until(ExpectedConditions.ElementToBeClickable(elemento));
        }

        /// <summary>
        /// Aguarda até que elemento esteja presente.
        /// </summary>
        /// <param name="seletor">O seletor do elemento que deseja aguardar.</param>
        public void AguardeElementoExistir(By seletor)
        {
            Wait.Until(ExpectedConditions.ElementExists(seletor));
        }

        /// <summary>
        /// Verifica se o texto foi escrito corretamente, caso não ele tenta ser escrito novamente.
        /// </summary>
        /// <param name="seletor">O seletor css do elemento que deseja aguardar.</param>
        /// <param name="texto">O texto que será inserido no campo.</param>
        public void AguardaTextoSerEscritoPorCss(string seletor, string texto)
        {
            AguardaTextoSerEscrito(By.CssSelector(seletor), texto);
        }

        /// <summary>
        /// Verifica se o texto foi escrito corretamente, caso não ele tenta ser escrito novamente.
        /// </summary>
        /// <param name="seletor">O seletor css do elemento que deseja aguardar.</param>
        /// <param name="texto">O texto que será inserido no campo.</param>
        public void AguardaTextoSerEscrito(By seletor, string texto)
        {
            var elemento = Wait.Until(ExpectedConditions.ElementIsVisible(seletor));
            AguardaTextoSerEscrito(elemento, texto);
        }

        /// <summary>
        /// Verifica se o texto foi escrito corretamente, caso não ele tenta ser escrito novamente.
        /// </summary>
        /// <param name="elemento">O elemento que deseja aguardar.</param>
        /// <param name="texto">O texto que será inserido no campo.</param>
        public void AguardaTextoSerEscrito(IWebElement elemento, string texto)
        {
            var textoSemTab = texto.TrimEnd().EndsWith(Keys.Tab, StringComparison.OrdinalIgnoreCase) ? texto.Remove(texto.Length - 1, 1) : texto;
            var ultimoCaractere = textoSemTab.Substring(textoSemTab.Length - 1, 1);
            Wait.Until(d =>
            {
                string textoNoCampo = elemento.GetAttribute("value");

                if (textoNoCampo.Length >= textoSemTab.Length
                    && textoNoCampo.EndsWith(ultimoCaractere, StringComparison.OrdinalIgnoreCase))
                {
                    return true;
                }
                else
                {
                    elemento.Clear();
                    elemento.SendKeys(textoSemTab + Keys.Tab);
                    return false;
                }
            });
        }

        /// <summary>
        /// Aguarde elemento por ID esteja visivel e presente.
        /// </summary>
        /// <param name="idElemento">O ID do elemento.</param>
        public void AguardeElemento(string idElemento)
        {
            AguardeElementoVisivelPorID(idElemento);
        }

        /// <summary>
        /// Aguarde elemento por NAME esteja visivel e presente.
        /// </summary>
        /// <param name="nameElemento">O NAME do elemento.</param>
        public void AguardeElementoPorName(string nameElemento)
        {
            var byNameElemento = By.Name(nameElemento);
            AguardeElementoVisivel(byNameElemento);
        }

        /// <summary>
        /// Aguarde elemento por CSS esteja visivel e presente.
        /// </summary>
        /// <param name="cssElemento">O CSS do elemento.</param>
        public void AguardeElementoPorCss(string cssElemento)
        {
            var byCssElemento = By.CssSelector(cssElemento);
            AguardeElementoVisivel(byCssElemento);
        }

        /// <summary>
        /// Aguarda até que o elemento informado esteja visível antes de prosseguir a execução do teste.
        /// </summary>
        /// <param name="seletor">O seletor que será usado para encontrar o elemento na tela.</param>
        public void AguardeElementoPresente(By seletor)
        {
            Wait.Until(d => d.FindElement(seletor));
        }

        /// <summary>
        /// Espera até que um campo esteja preenchido com qualquer valor antes de prosseguir a execução do teste de tela.
        /// </summary>
        /// <param name="idElemento">O ID do elemento que deverá conter valor antes do teste continuar a ser executado.</param>
        public void AguardeCampoContemValor(string idElemento)
        {
            AguardeElementoPresente(By.Id(idElemento));

            var scriptObtenhaNomeDaTagDoElemento = string.Concat("return $('#", idElemento, "').get(0).tagName;");
            var tagDoElemento = ComponenteDeTela.Script.ExecuteCodigoJavaScript(scriptObtenhaNomeDaTagDoElemento).ToString();

            // Campos de combobox.
            if (tagDoElemento.ToLower(CultureInfo.InvariantCulture) == "select")
            {
                var scriptComboBoxFoiPreenchida = string.Concat("return $('#", idElemento, " option:selected').text() != '';");

                AguardeScript(scriptComboBoxFoiPreenchida);
            }
            else
            {
                var scriptCampoContemValor = string.Concat("$('#", idElemento, "').val() != '';");

                AguardeScript(scriptCampoContemValor);
            }
        }

        /// <summary>
        /// Espera até que a página esteja carregada.
        /// </summary>
        public void AguardePaginaCarregada()
        {
            _scriptDeEsperaCondicional = "document.readyState === 'complete'";
            Wait.Until(AguardeScriptCondicional);
        }

        #region "MÉTODOS AUXILIARES"

        private string ObtenhaScriptQueVerificaSeCampoContemValor(string idDoCampo, string textoEsperadoParaOCampo, string metodo)
        {
            return string.Concat("$('#", idDoCampo, "').", metodo, "().indexOf('", textoEsperadoParaOCampo, "') > -1 ");
        }

        private void AguardeElementoInvisivel(By seletor)
        {
            Wait.Until(d => !d.FindElement(seletor).Displayed);
        }

        private void AguardeIntervaloDeTempo(TimeSpan intervalo)
        {
            Thread.Sleep(intervalo);
        }

        /// <summary>
        /// Utilize este método para esperar até que um determinado código JavaScript seja avaliado como verdadeiro.
        /// </summary>
        /// <param name="driver">O objeto WebDriver usado para rodar os testes de tela.</param>
        /// <returns>Retorna true quando o código javascript for avaliado como verdadeiro.</returns>
        private bool AguardeScriptCondicional(IWebDriver driver)
        {
            return ComponenteDeTela.Script.AvalieBooleanJavaScript(_scriptDeEsperaCondicional);
        }

        #endregion
    }
}
