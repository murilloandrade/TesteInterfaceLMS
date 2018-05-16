//-----------------------------------------------------------------------
// <copyright file="TrilhaUI.cs" company="LG Sistemas">
//     Copyright © LG Sistemas. All rights reserved.
//     TODOS OS DIREITOS RESERVADOS.
// </copyright>
//-----------------------------------------------------------------------
using LG.LMS.TestesDeInterface.Infraestrutura;
using LG.LMS.TestesDeInterface.Infraestrutura.PageModel;

namespace LG.LMS.TestesDeInterface.PageModel.Escolas
{
    public class TrilhaUI : PaginaPadrao
    {
        private EscolaUI _escolaUI;

        public TrilhaUI(ComponenteDeTela componenteDeTela, EscolaUI escolaUI)
            : base(componenteDeTela)
        {
            _escolaUI = escolaUI;
        }

        /// <summary>
        /// Acessa os detalhes da primeira trilha associada.
        /// </summary>
        public void ClickDetalhes()
        {
            ComponenteDeTela.Script.ExecuteCodigoJavaScript("$('.trilhas a:first')[0].click()");
        }

        protected override void CarregarPagina()
        {
        }
    }
}
