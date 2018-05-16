//-----------------------------------------------------------------------
// <copyright file="GaleriasDeFotosModel.cs" company="LG Sistemas">
//     Copyright © LG Sistemas. All rights reserved.
//     TODOS OS DIREITOS RESERVADOS.
// </copyright>
//-----------------------------------------------------------------------

namespace LG.LMS.TestesDeInterface.PageModel.Administracao.Desenvolvimento.GaleriasDeFotos
{
    /// <summary>
    /// Representação das informações de dados da tela.
    /// </summary>
    public class GaleriasDeFotosModel
    {
        public GaleriasDeFotosModel()
        {
            Titulo = "N/A";
            Descricao = "N/A";
        }

        public string Titulo { get; set; }

        public string Descricao { get; set; }
    }
}
