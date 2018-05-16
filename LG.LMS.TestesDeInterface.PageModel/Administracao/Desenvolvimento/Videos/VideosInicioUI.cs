// <copyright file="VideosInicioUI.cs" company="LG Sistemas">
//     Copyright © LG Sistemas. All rights reserved.
//     TODOS OS DIREITOS RESERVADOS.
// </copyright>
//-----------------------------------------------------------------------

using LG.LMS.TestesDeInterface.Infraestrutura;
using LG.LMS.TestesDeInterface.Infraestrutura.PageModel;

namespace LG.LMS.TestesDeInterface.PageModel.Administracao.Desenvolvimento.Videos
{
    public class VideosInicioUI : PaginaPadrao
    {
        private AdministracaoUI _adminUI;

        public VideosInicioUI(ComponenteDeTela componenteDeTela, AdministracaoUI adminUI)
            : base(componenteDeTela)
        {
            _adminUI = adminUI;
        }

        public void CliqueCadastrar()
        {
            ComponenteDeTela.Script.ExecuteCodigoJavaScript("$('.cadastro-de-video')[0].click()");
        }

        public void CliqueEditar()
        {
            ComponenteDeTela.Script.ExecuteCodigoJavaScript("$('.conteudo-listagem').first('tr').find(\"[data-id-selenium='editar']\")[0].click()");
        }

        public void CliqueExcluir()
        {
            ComponenteDeTela.Script.ExecuteCodigoJavaScript("$('.conteudo-listagem').first('tr').find(\"[data-id-selenium='excluir']\")[0].click()");
        }

        public void CliqueConfirmar()
        {
            ComponenteDeTela.Script.ExecuteCodigoJavaScript("$('#popup_ok').click()");
        }

        protected override void CarregarPagina()
        {
            _adminUI.AbrirFuncionalidade();
            _adminUI.CliqueVideos();
        }
    }
}
