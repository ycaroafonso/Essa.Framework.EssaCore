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

    public class Borders : Element
    {
        /// <summary>
        /// 
        /// </summary>
        public IList<Object> Elements;

        /// <summary>
        /// 
        /// </summary>
        public Borders()
            : this(null)
        {
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="Borders"></param>
        public Borders(IEnumerable<Border> borders)
        {
            try
            {
                _type = ElementType.Borders;
                if(borders != null)
                {

                    foreach(Border b in borders)
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

        /// <summary>
        /// 
        /// </summary>
        /// <param name="nElement"></param>
        public void AddElement(Border nElement)
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

        ~Borders()
        {
            if(Elements != null)
                Elements.Clear();
        }
    }
}
