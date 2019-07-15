/************************************************************* 
 * ESCRITURAÇÃO FISCAL DIGITAL - EFD
 * ***********************************************************
 * Classe responsável pela criação das linhas de uma tabela
 * para arquivos do excel 
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

    public class Row : Element
    {
        public bool? AutoFitHeight
        {
            get;
            set;
        }
        public double? Height
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
        /// Lista de elementos
        /// </summary>
        public IList<Object> Elements;

        /// <summary>
        /// 
        /// </summary>
        public IList<Cell> Cells
        {
            get
            {
                try
                {
                    if (Elements != null)
                    {
                        var res = Elements.Where(el => el.GetType().Name.Equals("Cell"));
                        return (res != null) ? res.Cast<Cell>().ToList() : null;
                    }
                    return null;
                }
                catch (Exception)
                {
                    return null;
                }
            }
        }

        /// <summary>
        /// Construtor
        /// </summary>
        public Row()
        {
        }

        /// <summary>
        /// Construtor que recebe um indice para o linha
        /// </summary>
        /// <param name="index">Indice para linha</param>
        public Row(int? index)
            : this(index, null, null, null)
        {

        }

        /// <summary>
        /// Construtor
        /// </summary>
        /// <param name="cells">Lista de celulas para a linha</param>
        public Row(IEnumerable<Cell> cells)
            : this(null, null, null, cells)
        {
        }

        /// <summary>
        /// Construtor
        /// </summary>
        /// <param name="cells">Lista de celulas para a linha</param>
        public Row(int? index, IEnumerable<Cell> cells)
            : this(index, null, null, cells)
        {
        }

        /// <summary>
        /// Construtor
        /// </summary>
        /// <param name="autoFitHeight"></param>
        public Row(bool? autoFitHeight)
            : this(null, autoFitHeight, null, null)
        {
        }
        
        /// <summary>
        /// Construtor
        /// </summary>
        /// <param name="autoFitheight"></param>
        /// <param name="height"></param>
        public Row(int? index, bool? autoFitheight, double? height)
            : this(null, autoFitheight, height, null)
        {
        }

        /// <summary>
        /// Construtor
        /// </summary>
        /// <param name="autoFitheight"></param>
        /// <param name="height"></param>
        public Row(int? index, bool? autoFitheight, double? height, IEnumerable<Cell> cells)
        {
            try
            {
                Index = index ?? null;
                AutoFitHeight = autoFitheight ?? null;
                Height = height ?? null;
                if (cells != null)
                {
                    foreach (Cell c in cells)
                        AddElement(c);
                }
            }
            catch (Exception e)
            {
                throw e;
            }
        }


        public void AddCell(Cell cell)
        {
            AddElement(cell);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="nElement"></param>
        private void AddElement(Element nElement)
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

        ~Row()
        {
            if (Elements != null)
                Elements.Clear();
        }
    }
}
