//-----------------------------------------------------------------------
// <copyright file="FabricaDeComponenteDeTela.cs" company="LG Sistemas">
//     Copyright © LG Sistemas. All rights reserved.
//     TODOS OS DIREITOS RESERVADOS.
// </copyright>
//-----------------------------------------------------------------------

using System;
using System.Configuration;
using System.Globalization;
using System.IO;
using System.Reflection;
using LG.LMS.TestesDeInterface.Infraestrutura.Enumeradores;

namespace LG.LMS.TestesDeInterface.Infraestrutura
{
    public sealed class FabricaDeComponenteDeTela
    {
        private const string CHAVE_DE_CONFIGURACAO_LOGIN = "Login";
        private const string CHAVE_DE_CONFIGURACAO_SENHA = "Senha";
        private const string CHAVE_DE_CONFIGURACAO_TIMEOUT = "Timeout";
        private const string CHAVE_DE_CONFIGURACAO_BROWSER = "Browser";
        private const string CHAVE_DE_CONFIGURACAO_URL_LOGIN = "UrlLogin";
        private const string CHAVE_DE_CONFIGURACAO_URL_APLICACAO = "UrlAplicacao";
        private const string CHAVE_DE_CONFIGURACAO_UTILIZA_SCREENSHOT = "UtilizaScreenshot";
        private const string CHAVE_DE_CONFIGURACAO_PROXY_TYPE = "ProxyType";
        private const string CHAVE_DE_CONFIGURACAO_AMBIENTE = "Ambiente";

        /// <summary>
        /// Crie o componente de tela.
        /// </summary>
        /// <param name="appConfig">O arquivo de configuração.</param>
        /// <returns>O componente de tela.</returns>
        public static ComponenteDeTela Crie(string appConfig)
        {
            return Crie(appConfig, false);
        }

        /// <summary>
        /// Crie o componente de tela.
        /// </summary>
        /// <param name="appConfig">O arquivo de configuração.</param>
        /// <param name="utilizaRelatorioLegal">Define se utiliza relatórios legais.</param>
        /// <returns>O componente de tela.</returns>
        public static ComponenteDeTela Crie(string appConfig, bool utilizaRelatorioLegal)
        {
            var arquivoDeConfiguracao = CrieArquivoDeConfiguracao(appConfig);
            var configuracao = CrieConfiguracaoDeTela(arquivoDeConfiguracao, utilizaRelatorioLegal);
            var componenteDeTela = new ComponenteDeTela(configuracao);

            return componenteDeTela;
        }

        /// <summary>
        /// Metodo que obtem o App.config.
        /// </summary>
        /// <param name="appConfig">O arquivo de configuração.</param>
        /// <returns>Intancia de Configuration.</returns>
        public static Configuration CrieArquivoDeConfiguracao(string appConfig)
        {
            try
            {
                var map = new ExeConfigurationFileMap { ExeConfigFilename = appConfig };
                var configuracao = ConfigurationManager.OpenMappedExeConfiguration(map, ConfigurationUserLevel.None);

                return configuracao;
            }
            catch (ConfigurationErrorsException e)
            {
                throw new ConfigurationErrorsException(e.Message);
            }
        }

        private static ConfiguracaoDeTela CrieConfiguracaoDeTela(Configuration arquivoDeConfiguracao, bool utilizaRelatorioLegal)
        {
            var timeoutPadrao = ObtenhaConfiguracaoDeTimeout(arquivoDeConfiguracao);
            var browser = ObtenhaConfiguracaoDeBrowser(arquivoDeConfiguracao);
            var pastaDeBinarios = ObtenhaPastaDeBinarios();
            var urlInicialDaAplicacao = ObtenhaUrlLogin(arquivoDeConfiguracao);
            var urlInicialDoProduto = ObtenhaUrlAplicacao(arquivoDeConfiguracao);
            var utilizaScreenshot = ObtenhaUtilizaScreenshot(arquivoDeConfiguracao);
            var proxyType = ObtenhaProxyType(arquivoDeConfiguracao);
            var login = ObtenhaLogin(arquivoDeConfiguracao);
            var senha = ObtenhaSenha(arquivoDeConfiguracao);
            var tipoDeAmbiente = ObtenhaTipoDeAmbiente(arquivoDeConfiguracao);

            var configuracaoDeTela = new ConfiguracaoDeTela
            {
                TipoDeAmbiente = tipoDeAmbiente,
                Timeout = timeoutPadrao,
                Browser = browser,
                PastaDeBinarios = pastaDeBinarios,
                UrlLogin = urlInicialDaAplicacao,
                UrlAplicacao = urlInicialDoProduto,
                UtilizaScreenshot = utilizaScreenshot,
                ProxyType = proxyType,
                Login = login,
                Senha = senha
            };

            return configuracaoDeTela;
        }

        private static TimeSpan ObtenhaConfiguracaoDeTimeout(Configuration arquivoDeConfiguracao)
        {
            var configuracaoParaTimeoutPadrao = arquivoDeConfiguracao.AppSettings.Settings[CHAVE_DE_CONFIGURACAO_TIMEOUT].Value;

            if (string.IsNullOrEmpty(configuracaoParaTimeoutPadrao))
            {
                ArquivoAppNaoConfigurado("O timeout não foi definido.", CHAVE_DE_CONFIGURACAO_TIMEOUT);
            }

            int timeoutDosTestesDeTela;

            bool resultadoConversao = int.TryParse(configuracaoParaTimeoutPadrao, out timeoutDosTestesDeTela);

            if (timeoutDosTestesDeTela == 0 || resultadoConversao == false)
            {
                // Caso nenhum timeout seja informado, o valor de 30 segundos será usado como timeout padrão.
                timeoutDosTestesDeTela = 30;
            }

            var timeOutImplicito = new TimeSpan(0, 0, timeoutDosTestesDeTela);
            return timeOutImplicito;
        }

        private static EnumBrowsers ObtenhaConfiguracaoDeBrowser(Configuration arquivoDeConfiguracao)
        {
            var configuracaoDeBrowser = arquivoDeConfiguracao.AppSettings.Settings[CHAVE_DE_CONFIGURACAO_BROWSER].Value;

            if (string.IsNullOrEmpty(configuracaoDeBrowser))
            {
                ArquivoAppNaoConfigurado("O browser não foi definido.", CHAVE_DE_CONFIGURACAO_BROWSER);
            }

            EnumBrowsers browserDefinido;

            if (Enum.TryParse(configuracaoDeBrowser, out browserDefinido))
            {
                return browserDefinido;
            }

            return EnumBrowsers.IE;
        }

        private static string ObtenhaPastaDeBinarios()
        {
            var pastaDeBinarios = Path.GetDirectoryName(Assembly.GetExecutingAssembly().CodeBase).Replace("file:\\", string.Empty);
            return pastaDeBinarios;
        }

        private static string ObtenhaUrlLogin(Configuration arquivoDeConfiguracao)
        {
            var urlLogin = arquivoDeConfiguracao.AppSettings.Settings[CHAVE_DE_CONFIGURACAO_URL_LOGIN].Value;

            if (string.IsNullOrEmpty(urlLogin))
            {
                ArquivoAppNaoConfigurado("A URL inicial do login não foi definida.", CHAVE_DE_CONFIGURACAO_URL_LOGIN);
            }

            return urlLogin;
        }

        private static string ObtenhaUrlAplicacao(Configuration arquivoDeConfiguracao)
        {
            var urlAplicacao = arquivoDeConfiguracao.AppSettings.Settings[CHAVE_DE_CONFIGURACAO_URL_APLICACAO].Value;

            if (string.IsNullOrEmpty(urlAplicacao))
            {
                ArquivoAppNaoConfigurado("A URL inicial da aplicação não foi definida.", CHAVE_DE_CONFIGURACAO_URL_APLICACAO);
            }

            return urlAplicacao;
        }

        private static bool ObtenhaUtilizaScreenshot(Configuration arquivoDeConfiguracao)
        {
            var utilizaScreenshot = arquivoDeConfiguracao.AppSettings.Settings[CHAVE_DE_CONFIGURACAO_UTILIZA_SCREENSHOT].Value;

            if (string.IsNullOrEmpty(utilizaScreenshot))
            {
                ArquivoAppNaoConfigurado("A identificação se utiliza screenshot não foi definida.", CHAVE_DE_CONFIGURACAO_UTILIZA_SCREENSHOT);
            }

            return utilizaScreenshot.ToUpper(CultureInfo.InvariantCulture) == "S";
        }

        private static string ObtenhaProxyType(Configuration arquivoDeConfiguracao)
        {
            var proxyType = arquivoDeConfiguracao.AppSettings.Settings[CHAVE_DE_CONFIGURACAO_PROXY_TYPE].Value;

            if (string.IsNullOrEmpty(proxyType))
            {
                ArquivoAppNaoConfigurado("O tio de proxy não foi especificado.", CHAVE_DE_CONFIGURACAO_PROXY_TYPE);
            }

            return proxyType;
        }

        private static string ObtenhaLogin(Configuration arquivoDeConfiguracao)
        {
            var login = arquivoDeConfiguracao.AppSettings.Settings[CHAVE_DE_CONFIGURACAO_LOGIN].Value;

            if (string.IsNullOrEmpty(login))
            {
                ArquivoAppNaoConfigurado("O login não foi definido.", CHAVE_DE_CONFIGURACAO_LOGIN);
            }

            return login;
        }

        private static string ObtenhaSenha(Configuration arquivoDeConfiguracao)
        {
            var senha = arquivoDeConfiguracao.AppSettings.Settings[CHAVE_DE_CONFIGURACAO_SENHA].Value;

            if (string.IsNullOrEmpty(senha))
            {
                ArquivoAppNaoConfigurado("A senha não foi definido.", CHAVE_DE_CONFIGURACAO_SENHA);
            }

            return senha;
        }

        private static EnumTipoDeAmbiente ObtenhaTipoDeAmbiente(Configuration arquivoDeConfiguracao)
        {
            var tipoDeAmbiente = arquivoDeConfiguracao.AppSettings.Settings[CHAVE_DE_CONFIGURACAO_AMBIENTE].Value;
            var tipoDeAmbienteDefinido = EnumTipoDeAmbiente.LOCAL;

            if (string.IsNullOrEmpty(tipoDeAmbiente) || !Enum.TryParse(tipoDeAmbiente.ToUpper(CultureInfo.InvariantCulture), out tipoDeAmbienteDefinido))
            {
                ArquivoAppNaoConfigurado("O tipo de ambiente não foi definido.", CHAVE_DE_CONFIGURACAO_AMBIENTE);
            }

            return tipoDeAmbienteDefinido;
        }

        private static void ArquivoAppNaoConfigurado(string mensagem, string chave)
        {
            var mensagemDeErro = string.Concat(
                mensagem,
                " Adicione uma entrada key=\"",
                chave,
                "\" no arquivo App.config para corrigir este problema.");

            throw new SettingsPropertyNotFoundException(mensagemDeErro);
        }
    }
}
