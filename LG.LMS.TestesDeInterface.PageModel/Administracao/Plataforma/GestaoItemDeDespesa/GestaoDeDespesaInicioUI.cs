//-----------------------------------------------------------------------
// <copyright file="GestaoDeDespesaInicioUI.cs" company="LG Sistemas">
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
    public class GestaoDeDespesaInicioUI : PaginaPadrao
    {
        private AdministracaoUI _adminUI;

        public GestaoDeDespesaInicioUI(ComponenteDeTela componenteDeTela, AdministracaoUI adminUI)
            : base(componenteDeTela)
        {
            _adminUI = adminUI;
        }

        [FindsBy(How = How.Id, Using = "despesa-index-novo")]
        public IWebElement BotaoNovo { get; set; }

        /// <summary>
        /// Abre a tela de edição do item selecionado.
        /// </summary>
        /// <param name="titulo">O título da despesa.</param>
        public void CliqueEditar(string titulo)
        {
            var script = string.Concat("$('[data-nome=\"", titulo, "\"] #despesa-index-template-acoes-editar')[0].click()");
            ComponenteDeTela.Script.ExecuteCodigoJavaScript(script);
        }

        /// <summary>
        /// Exclue o item selecionado.
        /// </summary>
        /// <param name="titulo">O título da despesa.</param>
        public void CliqueExcluir(string titulo)
        {
            var script = string.Concat("$('[data-nome=\"", titulo, "\"] #despesa-index-template-acoes-excluir')[0].click()");
            ComponenteDeTela.Script.ExecuteCodigoJavaScript(script);
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
            _adminUI.AbrirFuncionalidade();
            _adminUI.CliqueGestaoDeItemDeDespesa();
        }
    }
}
