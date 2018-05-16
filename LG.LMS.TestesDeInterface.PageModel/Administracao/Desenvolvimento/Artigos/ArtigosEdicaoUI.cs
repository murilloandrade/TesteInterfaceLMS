//-----------------------------------------------------------------------
// <copyright file="ArtigosEdicaoUI.cs" company="LG Sistemas">
//     Copyright © LG Sistemas. All rights reserved.
//     TODOS OS DIREITOS RESERVADOS.
// </copyright>
//-----------------------------------------------------------------------

using System;
using LG.LMS.TestesDeInterface.Infraestrutura;
using LG.LMS.TestesDeInterface.Infraestrutura.PageModel;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System.Globalization;

namespace LG.LMS.TestesDeInterface.PageModel.Administracao.Desenvolvimento.Artigos
{
    public class ArtigosEdicaoUI : PaginaPadrao
    {
        public ArtigosEdicaoUI(ComponenteDeTela componenteDeTela)
            : base(componenteDeTela)
        {
        }

        [FindsBy(How = How.Id, Using = "titulo")]
        public IWebElement Titulo { get; set; }

        [FindsBy(How = How.Id, Using = "chamada")]
        public IWebElement Chamada { get; set; }

        /// <summary>
        /// Preenche os dados na tela.
        /// </summary>
        /// <param name="model">Os dados para preencher os campos na tela.</param>
        public void PreencheCampoNaTela(ArtigosModel model)
        {
            Titulo.PreencheCampo(model.Titulo);
            Chamada.PreencheCampo(model.Chamada);
            PreencheRichTextDescricao(model.Descricao);
            ComponenteDeTela.Script.ExecuteCodigoJavaScript("$('#idioma').val(1).change()");
            ComponenteDeTela.Script.ExecuteCodigoJavaScript("$('#categoria').val(1).change()");
            ComponenteDeTela.Script.ExecuteCodigoJavaScript("$('#grupo').val(1).change()");
        }

        public void PreencheRichTextDescricao(string descricao)
        {
            ComponenteDeTela.Script.ExecuteCodigoJavaScript(string.Format(CultureInfo.InvariantCulture, "$('#descricao').redactor('set','{0}')", descricao));
        }

        /// <summary>
        /// Click em confirmar na janela modal.
        /// </summary>
        public void CliqueConfirmar()
        {
            ComponenteDeTela.Script.ExecuteCodigoJavaScript("$('#popup_ok').click()");
        }

        /// <summary>
        /// Click em salvar na janela modal.
        /// </summary>
        public void CliqueSalvar()
        {
            ComponenteDeTela.Script.ExecuteCodigoJavaScript("$('.btn.btn-primary.salvar-submit')[0].click()");
        }

        protected override void CarregarPagina()
        {
        }

        public void CliqueCancelar()
        {
            ComponenteDeTela.Script.ExecuteCodigoJavaScript("$('.btn.btn-danger')[0].click()");
        }
    }
}
