/************************************************************* 
 * ESCRITURAÇÃO FISCAL DIGITAL - EFD
 * ***********************************************************
 * --Citar a função principal da classe aqui--
 * 
 * 
 * SGI - All rights reserved ©.
 * Criado por: Christian B. de Souza
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

    public class NumberFormat : Element
    {
        public string Format
        {
            get;
            set;
        }

        public NumberFormat()
        {
        }

        /// <summary>
        /// construtor
        /// </summary>
        /// <param name="format">Formato para o número. </param>
        public NumberFormat(string format)
        {
            Format = format;
        }
    }
}
