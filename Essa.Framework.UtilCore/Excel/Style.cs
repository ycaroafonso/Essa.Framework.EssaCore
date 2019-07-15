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
    using System.Xml;
    using System.IO;

    public class Style : Element
    {
        /// <summary>
        /// 
        /// </summary>
        private string _id;
        public string ID
        {
            get
            {
                return _id;
            }
            set
            {
                _id = value;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        private string _name;
        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }

        private string _parent;
        public string Parent
        {
            get { return _parent; }
            set { _parent = value; }
        }

        /// <summary>
        /// 
        /// </summary>
        public List<Object> Elements;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <param name="name"></param>
        public Style(string id, string name)
            : this(id, name, null, null, null)
        {
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <param name="name"></param>
        /// <param name="value"></param>
        public Style(string id, string name, string value)
            : this(id, name, value, null, null)
        {
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <param name="name"></param>
        /// <param name="value"></param>
        public Style(string id, string name, string parent, string value)
            : this(id, name, value, parent, null)
        {
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <param name="name"></param>
        /// <param name="attributes"></param>
        /// <param name="value"></param>
        public Style(string id, string name, string value, string parent, Dictionary<string, string> attributes)
        {
            try
            {
                _type = ElementType.Style;
                
                if (!string.IsNullOrEmpty(id))
                    _id = id;

                if (!string.IsNullOrEmpty(name))
                    _name = name;

                if (!string.IsNullOrEmpty(parent))
                    _parent = parent;

                if (!string.IsNullOrEmpty(value))
                    Value = value;
                
                if (attributes != null)
                    CustomAttributes = attributes;
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
        public void AddElement(Element nElement)
        {
            try
            {
                if (Elements == null)
                    Elements = new List<object>();

                Elements.Add(nElement);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        ~Style()
        {
            if (Elements != null)
                Elements.Clear();
        }
    }
}
