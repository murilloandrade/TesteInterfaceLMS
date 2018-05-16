using System;
using System.Collections.Generic;
using System.IO;
using LG.LMS.TestesDeInterface.Infraestrutura;
using LG.LMS.TestesDeInterface.Infraestrutura.Utilitarios;
using LG.LMS.TestesDeInterface.PageModel.Login;
using NUnit.Framework;
using OpenQA.Selenium;

namespace LG.LMS.TestesDeInterface.Testes
{
    /// <summary>
    /// Testes de interface base.
    /// </summary>
    public abstract class TestesDeInterfaceBase
    {
        #region PROPRIEDADES

        /// <summary>
        /// Componente de tela para controle personalizado do WebDriver.
        /// </summary>
        /// <value>
        /// O componente de tela.
        /// </value>
        public static ComponenteDeTela ComponenteDeTela { get; set; }

        /// <summary>
        /// O componente WebDriver para controle de tela.
        /// </summary>
        /// <value>
        /// Componente WebDriver.
        /// </value>
        protected IWebDriver driver
        {
            get { return ComponenteDeTela.WebDriver; }
        }

        /// <summary>
        /// O contexto de teste para controles dos cenários de testes e numeração das screenshots.
        /// </summary>
        /// <value>
        /// O contexto de teste.
        /// </value>
        protected ContextoDeTeste contexto { get; private set; }

        #endregion

        #region MÉTODOS DE TESTES

        [TestFixtureSetUp]
        public void Inicializa()
        {
            try
            {
                contexto = CrieContextoDeTeste();

                if (ComponenteDeTela == null || ComponenteDeTela.WebDriver == null)
                {
                    ExecuteProcessoDeLogin();
                }
                else
                {
                    ComponenteDeTela.AbrirTelaDeAplicacao();
                }

            }
            catch (Exception e)
            {
                var categoria = CapturarCategoriaDeTeste();
                categoria = string.IsNullOrEmpty(categoria) ? "Inicializa" : categoria;

                if (ComponenteDeTela != null && ComponenteDeTela.WebDriver != null)
                {
                    ComponenteDeTela.SalvarScreenshotErro(categoria);
                }

                LogDeErros.SalvarLog(categoria, e);
                Finaliza();
            }
        }

        [TestFixtureTearDown]
        public void Finaliza()
        {
            FinalizaComponenteDeTela();
        }

        #endregion

        #region MÉTODOS PROTECTED

        protected abstract ContextoDeTeste CrieContextoDeTeste();

        protected virtual bool EhParaEfetuarLoginAutomatico()
        {
            return true;
        }

        protected void PrepareContextoDeTeste()
        {
            contexto = CrieContextoDeTeste();
        }

        protected virtual void EfetueLoginManual()
        {
            throw new NotImplementedException("Não foi implementado o login manual.");
        }

        protected void EfetueLoginAutomatico()
        {
            var login = ComponenteDeTela.ConfiguracaoDeTela.Login;
            var senha = ComponenteDeTela.ConfiguracaoDeTela.Senha;

            EfetueLogin(login, senha);
        }

        protected void EfetueLogin(string login, string senha)
        {
            var loginUI = new LoginUI(ComponenteDeTela);
            loginUI.AbrirFuncionalidade();
            loginUI.EfetueLogin(login, senha);
        }

        protected void AguardePainelDeFuncionalidade()
        {
            ComponenteDeTela.Espera.AguardeElementoVisivel(By.CssSelector("#container-principal"));
        }

        #endregion

        #region MÉTODOS SCREENSHOT

        protected void SalvarScreenshot(string nomeDoArquivo)
        {
            SalvarScreenshot(contexto, nomeDoArquivo);
        }

        protected void SalvarScreenshotFuncionalidadeEComparar(string nomeDoArquivo)
        {
            SalvarScreenshotFuncionalidade(nomeDoArquivo);
            CompararScreenshot(contexto);
        }

        protected void SalvarScreenshotFuncionalidade(string nomeDoArquivo)
        {
            SalvarScreenshotFuncionalidade(nomeDoArquivo, 1);
        }

        protected void SalvarScreenshotFuncionalidade(string nomeDoArquivo, int segundos)
        {
            ComponenteDeTela.Espera.AguardeIntervaloDeTempo(segundos);
            SalvarScreenshotFuncionalidade(contexto, nomeDoArquivo);
        }

        /// <summary>
        /// Salva as capturas de imagens da tela inteira.
        /// </summary>
        /// <param name="contexto">Contexto de cenários de testes.</param>
        /// <param name="nomeDoArquivo">O nome do arquivo.</param>
        /// <param name="segundos">O intervalo de segundos de espera antes de fazer o print da tela.</param>
        /// <param name="subPasta">Os diretórios da subpasta da funcionalidade.</param>
        protected void SalvarScreenshot(ContextoDeTeste contexto, string nomeDoArquivo, int segundos, params string[] subPasta)
        {
            ComponenteDeTela.Espera.AguardeIntervaloDeTempo(segundos);
            SalvarScreenshot(contexto, nomeDoArquivo, subPasta);
        }

        /// <summary>
        /// Salva as capturas de imagens da tela inteira.
        /// </summary>
        /// <param name="contexto">Contexto de cenários de testes.</param>
        /// <param name="nomeDoArquivo">O nome do arquivo.</param>
        /// <param name="subPasta">Os diretórios da subpasta da funcionalidade.</param>
        protected void SalvarScreenshot(ContextoDeTeste contexto, string nomeDoArquivo, params string[] subPasta)
        {
            var diretorioDeImagens = CrieDiretorioDeImagens(contexto, subPasta);
            ComponenteDeTela.SalvarScreenshot(nomeDoArquivo, diretorioDeImagens, contexto);
        }

        /// <summary>
        /// Salva as capturas de imagens da funcionalidade.
        /// </summary>
        /// <param name="contexto">Contexto de cenários de testes.</param>
        /// <param name="nomeDoArquivo">O nome do arquivo.</param>
        /// <param name="subPasta">Os diretórios da subpasta da funcionalidade.</param>
        protected void SalvarScreenshotFuncionalidade(ContextoDeTeste contexto, string nomeDoArquivo, params string[] subPasta)
        {
            ComponenteDeTela.Espera.AguardeElementoVisivelPorID("container-principal");
            SalvarScreenshotEspecifico(contexto, nomeDoArquivo, "#container-principal", subPasta);
        }

        /// <summary>
        /// Salva as capturas de imagens.
        /// </summary>
        /// <param name="contexto">Contexto de cenários de testes.</param>
        /// <param name="nomeDoArquivo">O nome do arquivo.</param>
        /// <param name="cssComponenteParaScreenshot">O CSS do componente para captura de imagem.</param>
        /// <param name="subPasta">Os diretórios da subpasta da funcionalidade.</param>
        protected void SalvarScreenshotEspecifico(ContextoDeTeste contexto, string nomeDoArquivo, string cssComponenteParaScreenshot, params string[] subPasta)
        {
            var diretorioDeImagens = CrieDiretorioDeImagens(contexto, subPasta);
            ComponenteDeTela.SalvarScreenshotEspecifico(nomeDoArquivo, diretorioDeImagens, contexto, cssComponenteParaScreenshot);
        }

        /// <summary>
        /// Compare as capturas de imagens.
        /// </summary>
        /// <param name="subPasta">Os diretórios da subpasta da funcionalidade.</param>
        protected void CompararScreenshot(params string[] subPasta)
        {
            CompararScreenshot(contexto, subPasta);
        }

        /// <summary>
        /// Compare as capturas de imagens.
        /// </summary>
        /// <param name="contexto">O contexto de cenários de testes.</param>
        /// <param name="subPasta">Os diretórios da subpasta da funcionalidade.</param>
        protected void CompararScreenshot(ContextoDeTeste contexto, params string[] subPasta)
        {
            var diretorioDeImagens = CrieDiretorioDeImagens(contexto, subPasta);
            ComponenteDeTela.CompararScreenshot(contexto, diretorioDeImagens);
        }

        protected string CrieDiretorioDeImagens(ContextoDeTeste contexto, params string[] subPasta)
        {
            var diretorios = new List<string>
            {
                Environment.CurrentDirectory, 
                "../../Screenshots", 
                contexto.Projeto,
                contexto.Modulo,
                contexto.Funcionalidade
            };

            diretorios.AddRange(subPasta);

            var diretorioDeImagens = Path.Combine(diretorios.ToArray());
            return diretorioDeImagens;
        }

        #endregion

        #region MÉTODOS DE SUPORTE PRIVATES

        private void FinalizaComponenteDeTela()
        {
            var ehClasseTearDown = this is ZzzTearDown;

            if (ehClasseTearDown && ComponenteDeTela != null)
            {
                ComponenteDeTela.Dispose();
            }
        }

        private string CapturarCategoriaDeTeste()
        {
            var atributo = this.GetType().GetCustomAttributes(typeof(TestFixtureAttribute), false);
            var categoria = ((TestFixtureAttribute)atributo[0]).Category;

            return categoria;
        }

        private void ExecuteProcessoDeLogin()
        {
            var appConfig = string.Concat(AppDomain.CurrentDomain.BaseDirectory, @"\..\..\LG.LMS.TestesDeInterface.Testes\App.config");
            ComponenteDeTela = FabricaDeComponenteDeTela.Crie(appConfig);

            if (EhParaEfetuarLoginAutomatico())
            {
                EfetueLoginAutomatico();
            }
            else
            {
                EfetueLoginManual();
            }

            ComponenteDeTela.Espera.AguardeElementoVisivel(By.CssSelector("#container-principal"));

            //// Deleta todas as imagens "*.atual.*" e "*.diff.*".
            ApagaTodasImagensNaoVersionadas();
        }

        private void ApagaTodasImagensNaoVersionadas()
        {
            var diretorioAtual = CrieDiretorioDeImagens(contexto);

            if (Directory.Exists(diretorioAtual))
            {
                Delete(diretorioAtual, "*.atual.*");
                Delete(diretorioAtual, "*.diff.*");
            }
        }

        private void Delete(string diretorioAtual, string searchPattern)
        {
            var arquivos = Directory.GetFiles(diretorioAtual, searchPattern);

            foreach (var arquivo in arquivos)
            {
                File.Delete(arquivo);
            }
        }

        #endregion
    }
}
