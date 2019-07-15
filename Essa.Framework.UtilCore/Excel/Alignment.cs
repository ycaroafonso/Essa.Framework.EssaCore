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

    public class Alignment : Element
    {
        public string Horizontal { get; set; }
        public string Vertical { get; set; }
        public string WrapText { get; set; }

        /// <summary>
        /// Construtor
        /// </summary>
        /// <param name="horizontal"></param>
        public Alignment(string horizontal)
            : this(horizontal, null, null)
        { }

        /// <summary>
        /// Construtor
        /// </summary>
        /// <param name="horizontal"></param>
        /// <param name="vertical"></param>
        public Alignment(string horizontal, string vertical)
            : this(horizontal, vertical, null)
        { }
        /// <summary>
        /// Construtor
        /// </summary>
        /// <param name="horizontal"></param>
        /// <param name="vertical"></param>
        public Alignment(string horizontal, string vertical, string wrapText)
        {
            _type = ElementType.Alignment;

            if (horizontal != null)
                Horizontal = horizontal;

            if (vertical != null)
                Vertical = vertical;

            if (wrapText != null)
                WrapText = wrapText;
        }
    }
}
