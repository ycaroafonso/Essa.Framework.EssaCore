/************************************************************* 
 * ESCRITURAÇÃO FISCAL DIGITAL - EFD
 * ***********************************************************
 * --Citar a função principal da classe aqui--
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

    public class Border : Element
    {
        /// <summary>
        /// Posição da borda
        /// ex: (Bottom, Left, Right e Top)
        /// </summary>
        public string Position { get; set; }

        /// <summary>
        /// Estilo da linha
        /// Ex:( Continuous, Double)
        /// </summary>
        public string LineStyle { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public int? Weight { get; set; }

        public Border()
        {
            _type = ElementType.Border;
        }

        /// <summary>
        /// Construtor
        /// </summary>
        /// <param name="position">Posição da Borda</param>
        /// <param name="LineStyle">Estilo da linha</param>
        /// <param name="weight"></param>
        public Border (string position, string lineStyle, int? weight)
        {
            _type = ElementType.Border;
            Position = position.Trim() ?? null;
            LineStyle = lineStyle.Trim() ?? null;
            Weight = weight ?? null;
        }        
    }
}
