//-----------------------------------------------------------------------
// <copyright file="ArtigosModel.cs" company="LG Sistemas">
//     Copyright © LG Sistemas. All rights reserved.
//     TODOS OS DIREITOS RESERVADOS.
// </copyright>
//-----------------------------------------------------------------------

namespace LG.LMS.TestesDeInterface.PageModel.Administracao.Desenvolvimento.Artigos
{
    /// <summary>
    /// Representação das informações de dados da tela.
    /// </summary>
    public class ArtigosModel
    {
        public ArtigosModel()
        {
            Titulo = "N/A";
            Chamada = "N/A";
            Descricao = "N/A";
        }

        public string Titulo { get; set; }

        public string Chamada { get; set; }

        public string Descricao { get; set; }
    }
}
