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
    using System.Data.Common;
    using System.Data;

    public class Worksheet : Element, IDisposable
    {
        /// <summary>
        /// Lista de elementos
        /// </summary>
        public IList<Object> Elements;

        /// <summary>
        /// Nome do worksheet
        /// </summary>
        private string _name;
        public string Name
        {
            get
            {
                return _name;
            }
            set
            {
                _name = value;
            }
        }

        public IList<Table> Tables
        {
            get
            {
                try
                {
                    if(Elements != null)
                    {
                        var res = Elements.Where(el => el.GetType().Name.Equals("Table"));
                        return (res != null) ? res.Cast<Table>().ToList() : null;
                    }
                    return null;
                }
                catch(Exception)
                {
                    return null;
                }
            }
        }

        /// <summary>
        /// Construtor
        /// </summary>
        public Worksheet()
            : this(null, null, null)
        {
        }

        /// <summary>
        /// Construtor
        /// </summary>
        /// <param name="name">Nome para o workseet</param>
        public Worksheet(string name)
            : this(name, null, null)
        {
        }

        /// <summary>
        /// Construtor
        /// </summary>
        /// <param name="name">Nome para o worksheet</param>
        /// <param name="attributes">Lista de atributos Extras</param>
        public Worksheet(string name, IDictionary<string, string> attributes)
            : this(name, attributes, null)
        {
        }

        /// <summary>
        /// Construtor
        /// </summary>
        /// <param name="name">Nome para o worksheet</param>
        /// <param name="attributes">Lista de atributos Extras</param>
        /// <param name="elements">Lista de elementos que compoem o worksheet (table, font, data, etc)</param>
        public Worksheet(string name, IDictionary<string, string> attributes, IEnumerable<Element> elements)
        {
            try
            {
                _name = name;
                _type = ElementType.Worksheet;
                if(attributes != null)
                    CustomAttributes = attributes;
                if(elements != null)
                {
                    foreach(Element elem in elements)
                        AddElement(elem);
                }
            }
            catch(Exception e)
            {
                throw e;
            }
        }

        /// <summary>
        /// Método para adicionar uma tabela
        /// </summary>
        /// <param name="tb"></param>
        public void AddTable(Table tb)
        {
            try
            {
                if(Elements != null)
                {
                    var bTb = Elements.Where(e => e.GetType().Name.Equals("Table"));
                    if(bTb != null)
                        Elements.Remove(bTb.First());
                }
                AddElement(tb);
            }
            catch(Exception e)
            {
                throw new Exception("Erro ao adcionar tabela : " + e.Message);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="nElement"></param>
        private void AddElement(Element nElement)
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

        ~Worksheet()
        {
            if(Elements != null)
                Elements.Clear();
        }
    }
}
