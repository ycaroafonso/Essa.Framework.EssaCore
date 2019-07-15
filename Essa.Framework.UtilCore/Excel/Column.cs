/************************************************************* 
 * ESCRITURAÇÃO FISCAL DIGITAL - EFD
 * ***********************************************************
 * Classe responsável pela criação de colunas de uma tabela
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

    public class Column : Element
    {
        public int? Index
        {
            get;
            set;
        }
        public string StyleID
        {
            get;
            set;
        }
        public bool? AutoFitWidth
        {
            get;
            set;
        }
        public double? Width
        {
            get;
            set;
        }
        public double? Span
        {
            get;
            set;
        }

        /// <summary>
        /// Construtor
        /// </summary>
        public Column()
        {
        }

        /// <summary>
        /// Construtor
        /// </summary>
        /// <param name="index">Indice da coluna</param>
        public Column(int index)
            : this(index, null, null, null, null)
        {
        }

        /// <summary>
        /// Construtor
        /// </summary>
        /// <param name="index">Indice da coluna</param>
        /// <param name="styleID">Id do estilo para coluna</param>
        public Column(int? index, string styleID)
            : this(index, styleID, null, null, null)
        {

        }

        /// <summary>
        /// Construtor
        /// </summary>
        /// <param name="index">Indice da coluna</param>
        /// <param name="styleID">Id do estilo para coluna</param>
        /// <param name="width">largura da coluna</param>
        public Column(int? index, string styleID, double? width)
            : this(index, styleID, null, width, null)
        {

        }

        /// <summary>
        /// Construtor
        /// </summary>
        /// <param name="index">indice da coluna</param>
        /// <param name="styleID">Id do estilo para a coluna</param>
        /// <param name="autoFitWidth">auto ajustar tamanho</param>
        /// <param name="width">largura da coluna</param>        
        public Column(int? index, string styleID, bool? autoFitWidth, double? width, double? span)
        {
            try
            {
                Index = index ?? null;
                StyleID = styleID ?? null;
                AutoFitWidth = autoFitWidth ?? null;
                Width = width ?? null;
                Span = span ?? null;
            }
            catch(Exception e)
            {
                throw e;
            }            
        }
    }
}
