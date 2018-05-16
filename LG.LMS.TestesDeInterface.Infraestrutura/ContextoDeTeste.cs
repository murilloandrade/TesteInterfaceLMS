//-----------------------------------------------------------------------
// <copyright file="ContextoDeTeste.cs" company="LG Sistemas">
//     Copyright © LG Sistemas. All rights reserved.
//     TODOS OS DIREITOS RESERVADOS.
// </copyright>
//-----------------------------------------------------------------------

using System;
using System.Collections.Generic;

namespace LG.LMS.TestesDeInterface.Infraestrutura
{
    /// <summary>
    /// Gerenciador de contexto de teste.
    /// </summary>
    public sealed class ContextoDeTeste
    {
        //// Cenários de testes com um contador.
        private readonly IDictionary<string, int> _cenarios;

        public ContextoDeTeste(string projeto, string modulo, string funcionalidade)
        {
            Projeto = projeto;
            Modulo = modulo;
            Funcionalidade = funcionalidade;
            _cenarios = new Dictionary<string, int>();
        }

        /// <summary>
        /// O nome do projeto que faz parte o teste.
        /// </summary>
        /// <value>
        /// O nome do projeto.
        /// </value>
        public string Projeto { get; private set; }

        /// <summary>
        /// O nome da funcionalidade do contexto de testado.
        /// </summary>
        /// <value>
        /// O nome da funcionalidade.
        /// </value>
        public string Funcionalidade { get; private set; }

        /// <summary>
        /// O nome do módulo da funcionalidade.
        /// </summary>
        /// <value>
        /// O nome do módulo.
        /// </value>
        public string Modulo { get; private set; }

        /// <summary>
        /// O nome do cenário de teste atual que está sendo testado.
        /// </summary>
        /// <value>
        /// O cenário de teste atual.
        /// </value>
        public string CenarioAtual { get; private set; }

        /// <summary>
        /// Adicione na lista de cenários o nome do caso de teste.
        /// </summary>
        /// <param name="cenario">O nome do cenário de teste.</param>
        public void AdicioneCenario(string cenario)
        {
            if (_cenarios.ContainsKey(cenario))
            {
                throw new ArgumentException("Cenário já adicionado.");
            }

            _cenarios.Add(cenario, 0);
            CenarioAtual = cenario;
        }

        /// <summary>
        /// Obtém o contador do cenário de testes utilizado para nomear screenshot.
        /// </summary>
        /// <param name="cenario">O nome do cenário de teste.</param>
        /// <returns>Retorna o contador.</returns>
        public int ObtenhaContador(string cenario)
        {
            if (!_cenarios.ContainsKey(cenario))
            {
                throw new ArgumentException("Cenário não existe.");
            }

            return _cenarios[cenario];
        }

        /// <summary>
        /// Atualiza o contador do cenário de teste específico.
        /// </summary>
        /// <param name="cenario">O nome do cenário de teste.</param>
        /// <param name="contador">O contador atualizado.</param>
        public void AtualizeContador(string cenario, int contador)
        {
            if (!_cenarios.ContainsKey(cenario))
            {
                throw new ArgumentException("Cenário não existe.");
            }

            _cenarios[cenario] = contador;
        }
    }
}
