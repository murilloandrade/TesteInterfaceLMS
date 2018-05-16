//-----------------------------------------------------------------------
// <copyright file="PaginaPadrao.cs" company="LG Sistemas">
//     Copyright © LG Sistemas. All rights reserved.
//     TODOS OS DIREITOS RESERVADOS.
// </copyright>
//-----------------------------------------------------------------------
using OpenQA.Selenium.Support.PageObjects;

namespace LG.LMS.TestesDeInterface.Infraestrutura.PageModel
{
    public abstract class PaginaPadrao
    {
        private readonly bool _inicializarElementos;

        protected PaginaPadrao(ComponenteDeTela componenteDeTela, bool inicializarElementos)
        {
            ComponenteDeTela = componenteDeTela;
            _inicializarElementos = inicializarElementos;
        }

        protected PaginaPadrao(ComponenteDeTela componenteDeTela)
            : this(componenteDeTela, true)
        {
        }

        /// <summary>
        /// Componente de tela com acessoa ao WebDriver.
        /// </summary>
        /// <value>
        /// O componente de tela.
        /// </value>
        public ComponenteDeTela ComponenteDeTela { get; private set; }

        /// <summary>
        /// Carrega a página e inicializa os elementos da página específica.
        /// </summary>
        public void AbrirFuncionalidade()
        {
            CarregarPagina();

            //// Só pode ser inicializado os elementos quando a página já estiver carregado.
            if (_inicializarElementos)
            {
                InicializarElementos();
            }
        }

        /// <summary>
        /// Inicializa todos elementos da página.
        /// </summary>
        public void InicializarElementos()
        {
            PageFactory.InitElements(ComponenteDeTela.WebDriver, this);
        }

        protected abstract void CarregarPagina();
    }
}
