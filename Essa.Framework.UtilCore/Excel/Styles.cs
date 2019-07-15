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

    public class Styles : Element
    {
        /// <summary>
        /// 
        /// </summary>
        public IList<Object> Elements;

        public Styles() : this (null, false)
        {
            _type = ElementType.Styles;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="createDefaultStyles"></param>
        public Styles(bool createDefaultStyles) : this(null, createDefaultStyles)
        {   
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="styles"></param>
        /// <param name="createDefaultStyles"></param>
        public Styles(IEnumerable<Style> styles, bool createDefaultStyles)
        {
            try
            { 
                _type = ElementType.Styles;
                if (createDefaultStyles)
                    CreateDefaults();

                if(styles != null)
                {
                    foreach(Style b in styles)
                    {
                        AddElement(b);
                    }
                }
            }
            catch(Exception e)
            {
                throw e;
            }
        }

        private void CreateDefaults()
        {
            try
            {
                // estilo Default - formatação das celulas normais do documento
                Style sDefault = new Style("Default", "Normal");
                sDefault.AddElement(new Alignment(null, "Bottom"));
                sDefault.AddElement(new Borders());
                sDefault.AddElement(new Font("Times New Roman", "Swiss", 12, "#000000"));
                sDefault.AddElement(new Interior());
                sDefault.AddElement(new NumberFormat());
                sDefault.AddElement(new Protection());
                AddElement(sDefault);

                // estilo padrao para texto
                Style sDefaultText = new Style("sDefaultText", null);
                sDefaultText.AddElement(new NumberFormat("@"));
                AddElement(sDefaultText);

                // estilo padrao para data
                Style sDefaultDate = new Style("sDefaultDate", null);
                sDefaultDate.AddElement(new NumberFormat("[$-409]dd/mm/yyyy;@"));
                AddElement(sDefaultDate);

                // estilo padrao para numero
                Style sDefaultNumber = new Style("sDefaultNumber", null);
                sDefaultNumber.AddElement(new NumberFormat("Standard"));
                AddElement(sDefaultNumber);

                // estilo padrao para titulo
                Style sDefaultHeader = new Style("sDefaultHeader", null);
                sDefaultHeader.AddElement(new Alignment(null, "Bottom"));
                sDefaultHeader.AddElement(new Font("Times New Roman", "Swiss", 13, "#000000", null, true));
                sDefaultHeader.AddElement(new NumberFormat("Standard"));
                AddElement(sDefaultHeader);

                // estilo padrao para titulo
                Style sDefaultTitle = new Style("sDefaultTitle", null);
                sDefaultTitle.AddElement(new Alignment(null, "Bottom"));
                sDefaultTitle.AddElement(new Font("Times New Roman", "Swiss", 12, "#000000", null, true));
                sDefaultTitle.AddElement(new NumberFormat("Standard"));
                AddElement(sDefaultTitle);
            }
            catch (Exception e)
            {
                
                throw e;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="nElement"></param>
        public void AddElement(Style nElement)
        {
            try
            {
                if(Elements == null)
                    Elements = new List<object>();

                Elements.Add(nElement);
            }
            catch(Exception e)
            {
                throw e;
            }
        }

        ~Styles()
        {
            if(Elements != null)
                Elements.Clear();
        }
    }
}
