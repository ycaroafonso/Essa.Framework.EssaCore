/************************************************************* 
 * ESCRITURAÇÃO FISCAL DIGITAL - EFD
 * ***********************************************************
 * Classe responsável pela criação de elementos para compor o
 * arquivos do excel
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

    public class Element : IDisposable
    {
        protected ElementType _type;
        public IDictionary<string, string> CustomAttributes;
        private string _value;
        public string Value
        {
            get
            {
                return _value;
            }
            set
            {
                _value = value;
            }
        }

        public Element()
        {
        }
        /// <summary>
        /// Construtor
        /// </summary>
        /// <param name="eType">Tipo de elemento</param>
        public Element(ElementType eType)
        {
            _type = eType;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="eType">Tipo de elemento</param>
        public Element(string eType) : this(eType, null)
        {   
        }

        /// <summary>
        /// Construtor
        /// </summary>
        /// <param name="eType">Tipo de elemento</param>
        /// <param name="attributes">Atributos customizados para o elemento</param>
        public Element(string eType, Dictionary<string,string> attributes)
        {
            try
            {
                ElementType t = (ElementType)Enum.Parse(typeof(ElementType),eType);
                
                if( t != null || string.IsNullOrEmpty(eType))
                {
                    throw new Exception("Tipo inválido para o elemento.");
                }
                else
                {
                    _type = t;
                }

                if(attributes != null)
                {
                    CustomAttributes = attributes;
                }
            }
            catch(Exception e)
            {
                throw e;
            }
            
        }

        /// <summary>
        /// Método responsável por adcionar atributos
        /// </summary>
        /// <param name="name">Nome do atributo</param>
        /// <param name="value">Valor</param>
        public void AddAttribute(string name, string value)
        {
            try
            {
                if(CustomAttributes == null)
                {
                    CustomAttributes = new Dictionary<string, string>();
                }
                CustomAttributes.Add(name, value);
            }
            catch(Exception e)
            {
                throw e;
            }
        }
        
        #region IDisposable Members

        public void Dispose()
        {
            if(CustomAttributes != null)
            {
                CustomAttributes.Clear();
                CustomAttributes = null;
            }
            
            _value = null;
            GC.SuppressFinalize(this);            
        }

        #endregion
        
        ~Element()
        {
            Dispose();
        }
    }
}
