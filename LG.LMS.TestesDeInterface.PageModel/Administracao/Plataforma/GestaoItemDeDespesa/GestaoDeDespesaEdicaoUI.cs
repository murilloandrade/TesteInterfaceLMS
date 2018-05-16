//-----------------------------------------------------------------------
// <copyright file="GestaoDeDespesaEdicaoUI.cs" company="LG Sistemas">
//     Copyright © LG Sistemas. All rights reserved.
//     TODOS OS DIREITOS RESERVADOS.
// </copyright>
//-----------------------------------------------------------------------

using LG.LMS.TestesDeInterface.Infraestrutura;
using LG.LMS.TestesDeInterface.Infraestrutura.PageModel;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace LG.LMS.TestesDeInterface.PageModel.Administracao.Plataforma.GestaoItemDeDespesa
{
    public class GestaoDeDespesaEdicaoUI : PaginaPadrao
    {
        public GestaoDeDespesaEdicaoUI(ComponenteDeTela componenteDeTela)
            : base(componenteDeTela)
        {
        }

        [FindsBy(How = How.Id, Using = "Descricao")]
        public IWebElement Titulo { get; set; }

        [FindsBy(How = How.ClassName, Using = "btn-salvar")]
        public IWebElement BotaoSalvar { get; set; }

        /// <summary>
        /// Preenche os dados na tela.
        /// </summary>
        /// <param name="model">Os dados para preencher os campos na tela.</param>
        public void PreencheCampoNaTela(GestaoDeDespesaModel model)
        {
            Titulo.PreencheCampo(model.Titulo);
        }

        /// <summary>
        /// Click em confirmar na janela modal.
        /// </summary>
        public void ClickConfirmar()
        {
            ComponenteDeTela.Script.ExecuteCodigoJavaScript("$('#popup_ok').click()");
        }

        protected override void CarregarPagina()
        {
        }
    }
}
