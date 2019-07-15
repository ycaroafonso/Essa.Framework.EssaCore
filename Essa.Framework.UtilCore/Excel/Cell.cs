/*************************************************************
 * ESCRITURAÇÃO FISCAL DIGITAL - EFD
 * ***********************************************************
 * Classe responsável pela criação de celulas de uma tabela
 * para arquivos do excel
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

    public class Cell : Element
    {
        /// <summary>
        /// Merge em colunas
        /// </summary>
        public int? MergeAcross
        {
            get;
            set;
        }

        public int? Index
        {
            get;
            set;
        }
        
        /// <summary>
        /// Id do estilo
        /// </summary>
        public string StyleID
        {
            get;
            set;
        }

        /// <summary>
        /// Formulas do excel
        /// Exemplo: (soma, média, max, min, etc)
        /// </summary>
        public string Formula
        {
            get;
            set;
        }

        /// <summary>
        /// Lista de elementos
        /// </summary>
        public IList<Object> Elements;

        /// <summary>
        /// Construtor
        /// </summary>
        public Cell()
        {
        }

        public Cell(int? index)
            : this(index, null, null, null)
        { 
        }
        /// <summary>
        /// Construtor
        /// </summary>
        /// <param name="styleID">Id do estilo</param>
        public Cell(string styleID)
            : this(null, styleID, null, null)
        {
        }

        /// <summary>
        /// Construtor
        /// </summary>
        /// <param name="styleID">Id do estilo</param>
        public Cell(int? index, string styleID)
            : this(index, styleID, null, null)
        {
        }
        /// <summary>
        /// Construtor
        /// </summary>
        /// <param name="elements">Lista de elementos</param>
        public Cell(IEnumerable<Element> elements)
            : this(null, null, null, null, elements)
        {
        }

        /// <summary>
        /// Construtor
        /// </summary>
        /// <param name="elements">Lista de elementos</param>
        public Cell(int? index, IEnumerable<Element> elements)
            : this(index, null, null, null, elements)
        {
        }

        /// <summary>
        /// Construtor
        /// </summary>
        /// <param name="styleID">Id do estilo</param>
        /// <param name="elements">Lista de elementos</param>
        public Cell(int? index, string styleID, IEnumerable<Element> elements)
            : this(index, styleID, null, null, elements)
        {
        }

        /// <summary>
        /// Construtor
        /// </summary>
        /// <param name="styleID">Id do estilo</param>
        /// <param name="formula">formula</param>
        /// <param name="mergeAcross"></param>
        public Cell(int? index, string styleID, string formula, int? mergeAcross)
            : this(index, styleID, formula, mergeAcross, null)
        {
        }

        /// <summary>
        /// Construtor
        /// </summary>
        /// <param name="styleID">Id do estilo</param>
        /// <param name="formula">Formula para o elemento</param>
        /// <param name="mergeAcross">Quantidade de colunas ao qual deseja mesclar</param>
        /// <param name="elements">lista de elementos da célula</param>
        public Cell(int? index, string styleID, string formula, int? mergeAcross, IEnumerable<Element> elements)
        {
            try
            {
                _type = ElementType.Cell;
                Index = index ?? null;
                StyleID = styleID ?? null;
                Formula = formula ?? null;
                MergeAcross = mergeAcross ?? null;

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
        /// Método para adicionar elementos a celula
        /// </summary>
        /// <param name="nElement"></param>
        public void AddElement(Element nElement)
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

        ~Cell()
        {
            if(Elements != null)
                Elements.Clear();
        }
    }
}
