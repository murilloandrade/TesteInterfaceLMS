//-----------------------------------------------------------------------
// <copyright file="LogDeErros.cs" company="LG Sistemas">
//     Copyright © LG Sistemas. All rights reserved.
//     TODOS OS DIREITOS RESERVADOS.
// </copyright>
//-----------------------------------------------------------------------

using System;
using System.Globalization;
using System.IO;
using System.Xml.Linq;

namespace LG.LMS.TestesDeInterface.Infraestrutura.Utilitarios
{
    public sealed class LogDeErros
    {
        public const string DIRETORIO_SCREENSHOTS_ERROS = "../../Erros/";

        /// <summary>
        /// Salva log de erro exception em xml "../../Erros/".
        /// </summary>
        /// <param name="nomeDoArquivo">O nome do arquivo.</param>
        /// <param name="ex">Os dados da exceção.</param>
        public static void SalvarLog(string nomeDoArquivo, Exception ex)
        {
            if (!Directory.Exists(DIRETORIO_SCREENSHOTS_ERROS))
            {
                Directory.CreateDirectory(DIRETORIO_SCREENSHOTS_ERROS);
            }

            var arquivo = string.Format(
                CultureInfo.InvariantCulture,
                "{0}{1}_{2}.xml",
                DIRETORIO_SCREENSHOTS_ERROS,
                nomeDoArquivo,
                DateTime.Now.ToString("yyyy-MM-dd_HH-mm-ss", CultureInfo.InvariantCulture));

            var mensagem = string.Empty;
            var source = string.Empty;
            var stackTrace = string.Empty;

            if (ex.InnerException != null)
            {
                mensagem = ex.InnerException.Message;
                source = ex.InnerException.Source;
                stackTrace = ex.InnerException.StackTrace;
            }

            var relatorio = new XDocument(
                    new XElement(
                        "Erro",
                        new XAttribute("Origem", nomeDoArquivo),
                        new XElement("Mensagem", ex.Message),
                        new XElement("Data", ex.Source),
                        new XElement(
                            "InnerException",
                            new XElement("Mensagem", mensagem),
                            new XElement("Source", source),
                            new XElement("StackTrace", stackTrace))));

            ////Salvo o arquivo como string, pois é a única forma de ele ficar identado.
            var relatorioIdentado = relatorio.ToString();
            using (var sw = File.CreateText(arquivo))
            {
                sw.WriteLine("<?xml version=\"1.0\" encoding=\"utf-8\"?>");
                sw.WriteLine(relatorioIdentado);
            }
        }
    }
}
