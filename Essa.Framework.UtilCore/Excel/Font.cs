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

    public class Font : Element
    {
        public string FontName
        {
            get;
            set;
        }
        public string x_Family
        {
            get;
            set;
        }
        public int? Size
        {
            get;
            set;
        }
        public string Color
        {
            get;
            set;
        }
        public string Underline
        {
            get;
            set;
        }
        public bool? Bold
        {
            get;
            set;
        }
        public bool? Italic
        {
            get;
            set;
        }

        /// <summary>
        /// Construtor
        /// </summary>
        public Font()
        {
        }

        /// <summary>
        /// Construtor
        /// </summary>
        /// <param name="name">Nome da font</param>
        /// <param name="family">família ex: (Roman)</param>
        /// <param name="size">Tamanho</param>
        /// <param name="color">Cor</param>
        public Font(string name, string family, int? size, string color) 
            : this(name, family, size, color, null, null, null)
        {  
        }

        /// <summary>
        /// Construtor
        /// </summary>
        /// <param name="name">Nome da font</param>
        /// <param name="family">família ex: (Roman)</param>
        /// <param name="size">Tamanho</param>
        /// <param name="color">Cor</param>
        /// <param name="underline">informações de sublinhado (Single, Double)</param>
        public Font(string name, string family, int? size, string color, string underline)
            : this(name, family, size, color, underline, null, null)
        {   
        }

        public Font(string name, string family, int? size, string color, string underline, bool? bold)
            :this(name, family, size, color, underline, bold, null)
        {

        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="fontname"></param>
        /// <param name="family"></param>
        /// <param name="size"></param>
        /// <param name="color"></param>
        /// <param name="underline"></param>
        /// <param name="bold"></param>
        /// <param name="italic"></param>
        public Font(string fontname, string family, int? size, string color, string underline, bool? bold, bool? italic)
        {
            _type = ElementType.Font;
            FontName = fontname ?? null;
            x_Family = family ?? null;
            Size = size ?? null;
            Color = color ?? null;
            Underline = underline ?? null;
            Bold = bold ?? null;
            Italic = italic ?? null;
        }
    }
}
