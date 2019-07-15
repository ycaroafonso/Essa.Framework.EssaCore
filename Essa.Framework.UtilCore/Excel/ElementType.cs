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
    
    public enum ElementType
    {
        WorkBook,
        Worksheet,
        Style,
        Styles,
        table,
        Row,
        Column,
        Cell,
        Data,
        Alignment,
        Border,
        Borders,
        Font,
        Interior,
        NumberFormat,
        Protection
    }    
}
