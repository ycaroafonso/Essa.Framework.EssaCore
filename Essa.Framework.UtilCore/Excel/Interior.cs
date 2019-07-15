/************************************************************* 
 * ESCRITURAÇÃO FISCAL DIGITAL - EFD
 * ***********************************************************
 * --Citar a função principal da classe aqui--
 * 
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

    public class Interior : Element
    {
        public string Color
        {
            get;
            set;
        }
        public string Pattern
        {
            get;
            set;
        }

        /// <summary>
        /// 
        /// </summary>
        public Interior()
        {
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="color"></param>
        public Interior(string color) : this(color, null)
        {
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="color"></param>
        /// <param name="pattern"></param>
        public Interior(string color, string pattern)
        {
            Color = color;
            Pattern = pattern;
        }
    }
}
