//-----------------------------------------------------------------------
// <copyright file="AudiosModel.cs" company="LG Sistemas">
//     Copyright © LG Sistemas. All rights reserved.
//     TODOS OS DIREITOS RESERVADOS.
// </copyright>
//-----------------------------------------------------------------------

namespace LG.LMS.TestesDeInterface.PageModel.Administracao.Desenvolvimento.Audios
{
    /// <summary>
    /// Representação das informações de dados da tela.
    /// </summary>
    public class AudiosModel
    {
        public AudiosModel()
        {
            Titulo = "N/A";
            Chamada = "N/A";
        }

        public string Titulo { get; set; }

        public string Chamada { get; set; }
    }
}
