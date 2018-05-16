//-----------------------------------------------------------------------
// <copyright file="LoginUI.cs" company="LG Sistemas">
//     Copyright © LG Sistemas. All rights reserved.
//     TODOS OS DIREITOS RESERVADOS.
// </copyright>
//-----------------------------------------------------------------------

using LG.LMS.TestesDeInterface.Infraestrutura;
using LG.LMS.TestesDeInterface.Infraestrutura.PageModel;
using LG.LMS.TestesDeInterface.Infraestrutura.Utilitarios;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace LG.LMS.TestesDeInterface.PageModel.Login
{
    /// <summary>
    /// Representação da tela de login.
    /// </summary>
    public class LoginUI : PaginaPadrao
    {
        public LoginUI(ComponenteDeTela componenteDeTela)
            : base(componenteDeTela)
        {
        }

        [FindsBy(How = How.Id, Using = "EmailOuLogin")]
        public IWebElement Login { get; set; }

        [FindsBy(How = How.Id, Using = "Senha")]
        public IWebElement Senha { get; set; }

        [FindsBy(How = How.Custom, Using = "[data-id-selenium='entrar']", CustomFinderType = typeof(ByElementCustomizado))]
        public IWebElement BotaoEntrar { get; set; }

        /// <summary>
        /// Efetue o login.
        /// </summary>
        /// <param name="login">O nome do usuário.</param>
        /// <param name="senha">A senha de login.</param>
        public void EfetueLogin(string login, string senha)
        {
            Login.PreencheCampo(login);
            Senha.PreencheCampo(senha);
            BotaoEntrar.Submit();
            ComponenteDeTela.Espera.AguardePaginaCarregada();
        }

        protected override void CarregarPagina()
        {
            ComponenteDeTela.AbrirTelaDeLogin();
        }
    }
}
