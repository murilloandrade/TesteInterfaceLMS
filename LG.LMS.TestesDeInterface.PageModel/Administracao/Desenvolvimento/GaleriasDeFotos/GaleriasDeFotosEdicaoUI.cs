//-----------------------------------------------------------------------
// <copyright file="GaleriasDeFotosEdicaoUI.cs" company="LG Sistemas">
//     Copyright © LG Sistemas. All rights reserved.
//     TODOS OS DIREITOS RESERVADOS.
// </copyright>
//-----------------------------------------------------------------------

using System;
using LG.LMS.TestesDeInterface.Infraestrutura;
using LG.LMS.TestesDeInterface.Infraestrutura.PageModel;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace LG.LMS.TestesDeInterface.PageModel.Administracao.Desenvolvimento.GaleriasDeFotos
{
    public class GaleriasDeFotosEdicaoUI : PaginaPadrao
    {
        public GaleriasDeFotosEdicaoUI(ComponenteDeTela componenteDeTela)
            : base(componenteDeTela)
        {
        }

        [FindsBy(How = How.Id, Using = "titulo")]
        public IWebElement Titulo { get; set; }

        [FindsBy(How = How.Id, Using = "descricao")]
        public IWebElement Descricao { get; set; }

        /// <summary>
        /// Preenche os dados na tela.
        /// </summary>
        /// <param name="model">Os dados para preencher os campos na tela.</param>
        public void PreencheCampoNaTela(GaleriasDeFotosModel model)
        {
            Titulo.PreencheCampo(model.Titulo);
            Descricao.PreencheCampo(model.Descricao);
            ComponenteDeTela.Script.ExecuteCodigoJavaScript("$('#idioma').val(1).change()");
            ComponenteDeTela.Script.ExecuteCodigoJavaScript("$('#categorias').val(1).change()");
            ComponenteDeTela.Script.ExecuteCodigoJavaScript("$('#grupo-conteudo').val('MaterialDeApoio').change()");
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
