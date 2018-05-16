//-----------------------------------------------------------------------
// <copyright file="ArquivosModel.cs" company="LG Sistemas">
//     Copyright © LG Sistemas. All rights reserved.
//     TODOS OS DIREITOS RESERVADOS.
// </copyright>
//-----------------------------------------------------------------------

namespace LG.LMS.TestesDeInterface.PageModel.Administracao.Desenvolvimento.Arquivos
{ 
    /// <summary>
    /// Representação das informações de dados da tela.
    /// </summary>
    public class ArquivosModel
    {
        public ArquivosModel()
        {
            Titulo = "N/A";
            Descricao = "N/A";
            DataPublicacao = "N/A";
        }

        public string Titulo { get; set; }

        public string Descricao { get; set; }

        public string DataPublicacao { get; set; }
    }
}
