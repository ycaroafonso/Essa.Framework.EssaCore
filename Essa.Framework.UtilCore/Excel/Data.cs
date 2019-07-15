/************************************************************* 
 * ESCRITURAÇÃO FISCAL DIGITAL - EFD
 * ***********************************************************
 * Classe responsável pela criação de elementos de dados para
 * as celulas de uma tabela para arquivos do excel
 * 
 * SGI - All rights reserved ©.
 * Criado por: cbsouza
 * Data da Criação: 24/11/2011 3:34:32 PM
 * Modificado por: --
 * Data da modificação: --
 * Observação: --
 * **********************************************************/

namespace Util.Excel
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class Data : Element
    {
        public string Type { get; set; }
        public string Xmlns { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public Data()
        {
        }

        /// <summary>
        /// Construtor
        /// </summary>
        /// <param name="type">tipo de dados. ex(string, number, etc)</param>
        public Data(string type)
            : this(type, null, null)
        {   
        }

        /// <summary>
        /// Construtor
        /// </summary>
        /// <param name="type">tipo de dados. ex(string, number, etc)</param>
        /// <param name="value">valor</param>
        public Data(string type, string value)
            : this(type, value, null)
        {
        }

        /// <summary>
        /// Construtor
        /// </summary>
        /// <param name="type">tipo de dados. ex(string, number, etc)</param>
        /// <param name="value">valor</param>
        /// <param name="xmlns">xmlns</param>
        public Data(string type, string value, string xmlns)
        {
            try
            {
                _type = ElementType.Data;
                Type = type ?? null;
                Value = value ?? null;
                Xmlns = xmlns ?? null;
            }
            catch(Exception e)
            {
                throw e;
            }
        }
    }
}
