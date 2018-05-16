//-----------------------------------------------------------------------
// <copyright file="DetalhesDaTrilhaUI.cs" company="LG Sistemas">
//     Copyright © LG Sistemas. All rights reserved.
//     TODOS OS DIREITOS RESERVADOS.
// </copyright>
//-----------------------------------------------------------------------
using LG.LMS.TestesDeInterface.Infraestrutura;
using LG.LMS.TestesDeInterface.Infraestrutura.PageModel;

namespace LG.LMS.TestesDeInterface.PageModel.Escolas
{
    public class DetalhesDaTrilhaUI : PaginaPadrao
    {
        public DetalhesDaTrilhaUI(ComponenteDeTela componenteDeTela)
            : base(componenteDeTela)
        {
        }

        /// <summary>
        /// Acessa o primeiro curso da trilha.
        /// </summary>
        public void AcessarPrimeiroCurso()
        {
            ComponenteDeTela.Script.ExecuteCodigoJavaScript("$('.cabecalho.cabecalho-conteudo.CursoPresencial .row a:first')[0].click()");
        }

        protected override void CarregarPagina()
        {
        }
    }
}
