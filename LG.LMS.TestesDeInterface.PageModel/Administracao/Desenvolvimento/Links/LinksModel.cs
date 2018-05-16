//-----------------------------------------------------------------------
// <copyright file="LinksModel.cs" company="LG Sistemas">
//     Copyright © LG Sistemas. All rights reserved.
//     TODOS OS DIREITOS RESERVADOS.
// </copyright>
//-----------------------------------------------------------------------

namespace LG.LMS.TestesDeInterface.PageModel.Administracao.Desenvolvimento.Links
{
    /// <summary>
    /// Representação das informações de dados da tela.
    /// </summary>
    public class LinksModel
    {
        public LinksModel()
        {
            Titulo = "N/A";
            Descricao = "N/A";
            Link = "N/A";
        }

        public string Titulo { get; set; }

        public string Descricao { get; set; }

        public string Link { get; set; }
    }
}
