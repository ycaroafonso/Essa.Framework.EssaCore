/************************************************************* 
 * ESCRITURAÇÃO FISCAL DIGITAL - EFD
 * ***********************************************************
 * Classe responsável pela criação de tabelas para arquivos 
 * do excel
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
    using System.Data.Common;
    using System.Data;
    using System.Reflection;

    public class Table : Element
    {
        public int? ExpandedColumnCount
        {
            get;
            set;
        }

        public int? ExpandedRowCount
        {
            get;
            set;
        }

        public int? x_FullColumns
        {
            get;
            set;
        }

        public int? x_FullRows
        {
            get;
            set;
        }

        public double? DefaultColumnWidth
        {
            get;
            set;
        }

        public double? DefaultRowHeight
        {
            get;
            set;
        }

        /// <summary>
        /// Lista de elementos
        /// </summary>
        public IList<Object> Elements;

        /// <summary>
        /// Lista de linhas da tabela
        /// </summary>
        public IList<Row> Rows
        {
            get
            {
                try
                {
                    if (Elements != null)
                    {
                        var res = Elements.Where(e => e.GetType().Name.Equals("Row"));
                        return (res != null) ? res.Cast<Row>().ToList() : null;
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
        /// Lista de colunas da tabela
        /// </summary>
        public IList<Column> Columns
        {
            get
            {
                try
                {
                    if (Elements != null)
                    {
                        var res = Elements.Where(e => e.GetType().Name.Equals("Column"));
                        return (res != null) ? res.Cast<Column>().ToList() : null;
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
        /// 
        /// </summary>
        public Table()
        {
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="dt"></param>
        public Table(DbDataReader dt)
            : this(null, null, null, null, null, null, dt)
        {
        }

        /// <summary>
        /// Construtor
        /// </summary>
        /// <param name="expandedColumnCount"></param>
        /// <param name="expandedRowCount"></param>
        /// <param name="fullColumns"></param>
        /// <param name="fullRows"></param>
        /// <param name="defaultRowHeight"></param>
        public Table(int? expandedColumnCount, int? expandedRowCount, int? fullColumns, int? fullRows,
            double? defaultColumnWidth, double? defaultRowHeight, DbDataReader dt)
        {
            try
            {
                ExpandedColumnCount = expandedColumnCount ?? null;
                ExpandedRowCount = expandedRowCount ?? null;
                x_FullColumns = fullColumns ?? null;
                x_FullRows = fullRows ?? null;
                DefaultColumnWidth = defaultColumnWidth ?? null;
                DefaultRowHeight = defaultRowHeight ?? null;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        #region Métodos para adicionar cabeçalho

        /// <summary>
        /// Método para adicionar cabeçalho
        /// </summary>
        /// <param name="header">Informação</param>
        public void AddHeader(string header)
        {
            AddHeader(header, null, false);
        }

        /// <summary>
        /// Método para adicionar cabeçalho
        /// </summary>
        /// <param name="header">Informação</param>
        /// <param name="styleId">Id do estilo</param>
        public void AddHeader(string header, string styleId)
        {
            AddHeader(header, styleId, false);
        }

        /// <summary>
        /// Método para adicionar cabeçalho
        /// </summary>
        /// <param name="header">Informação</param>
        /// <param name="useDefaultStyle">Se true, utiliza o estilo padrão para formatação de título </param>
        public void AddHeader(string header, bool useDefaultStyle)
        {
            AddHeader(header, null, useDefaultStyle);
        }

        /// <summary>
        /// Método para adicionar um conjunto de cabeçalhos
        /// </summary>
        /// <param name="header">Informação</param>
        /// <param name="styleId">Id do estilo</param>
        /// <param name="useDefaultStyle">Se true, utiliza o estilo padrão para formatação de título </param>        
        public void AddHeader(List<string> Headers, string styleId, bool useDefaultStyle)
        {
            try
            {
                foreach (string header in Headers)
                    AddHeader(header, styleId, useDefaultStyle);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        /// <summary>
        /// Método para adicionar cabeçalho
        /// </summary>
        /// <param name="header">Informação</param>
        /// <param name="styleId">Id do estilo</param>
        /// <param name="useDefaultStyle">Se true, utiliza o estilo padrão para formatação de título </param>
        public void AddHeader(string header, string styleId, bool useDefaultStyle)
        {
            try
            {
                Row _r = new Row();
                if (useDefaultStyle)
                    styleId = "sDefaultHeader";
                Cell _c = new Cell(null, styleId, new List<Element>() { new Data("String", header) });
                _r.AddCell(_c);
                AddRow(_r);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        #endregion

        /// <summary>
        /// Método para adicionar Linhas na tabela
        /// </summary>
        /// <param name="row">Linha</param>
        public void AddRow(Row row)
        {
            AddElement(row);
        }

        /// <summary>
        /// Método para Adicionar Colunas na tabela        
        /// </summary>
        /// <param name="column">Coluna</param>
        public void AddColumn(Column column)
        {
            AddElement(column);
        }

        /// <summary>
        /// Método para adicionar conjunto de dados a tabela a partir de um ou mais dataReader
        /// </summary>
        /// <param name="dataReaders">tabela de dados</param>
        public void AddDataReader(IEnumerable<DbDataReader> dataReaders)
        {
            AddDataReader(dataReaders, false, false);
        }

        /// 
        /// <summary>
        /// Método para adicionar conjunto de dados a tabela a partir de um ou mais dataReader
        /// </summary>
        /// <param name="dataReaders">tabela de dados</param>
        /// <param name="autoTitles">Se true, automaticamente cria os titulos para as colunas</param>
        public void AddDataReader(IEnumerable<DbDataReader> dataReaders, bool autoTitle)
        {
            AddDataReader(dataReaders, autoTitle, false);
        }

        /// <summary>
        /// Método para adicionar conjunto de dados a tabela a partir de um ou mais dataReader
        /// </summary>
        /// <param name="dataReaders">tabela de dados</param>
        /// <param name="autoTitles">Se true, automaticamente cria os titulos para as colunas</param>
        /// /// <param name="useDefaultStyle">Se true, automaticamente utiliza os estilos padrões para as colunas</param>
        public void AddDataReader(IEnumerable<DbDataReader> dataReaders, bool autoTitle, bool useDefaultStyle)
        {
            try
            {
                int count = 0;
                foreach (DbDataReader dt in dataReaders)
                {
                    while (dt.Read())
                    {
                        // cria a a ligação com os estilos padrão
                        if (count == 0 && useDefaultStyle)
                        {
                            for (int i = 0; i < dt.FieldCount; i++)
                            {
                                string styleId = null;

                                switch (dt[i].GetType().ToString().ToLower())
                                {
                                    case "datetime":
                                        styleId = "sDefaultDate";
                                        break;
                                    case "number":
                                        styleId = "sDefaultNumber";
                                        break;
                                    case "string":
                                    case "dbnull":
                                    default:
                                        styleId = "sDefaultText";
                                        break;
                                }
                                if (styleId != null)
                                    AddColumn(new Column(i + 1, styleId));
                            }
                        }

                        // cria os titulos para as colunas
                        if (autoTitle)
                        {
                            // titulos da tabela
                            Row rTitles = new Row();
                            for (int i = 0; i < dt.FieldCount; i++)
                            {
                                Data d = new Data("String", dt.GetName(i));
                                rTitles.AddCell(new Cell(new List<Element>() { d }));
                            }
                            AddRow(rTitles);
                        }

                        // dados da tabela
                        Row novaLilha = new Row();
                        for (int col = 0; col < dt.FieldCount; col++)
                        {
                            Data d = new Data();
                            switch (dt[col].GetType().Name.ToLower())
                            {

                                case "datetime":
                                    d.Type = "DateTime";
                                    d.Value = dt.GetDateTime(col).ToString("s");
                                    break;

                                case "string":
                                    d.Type = "String";
                                    d.Value = dt.GetString(col);
                                    break;

                                case "boolean":
                                    d.Type = "Boolean";
                                    d.Value = Convert.ToString(dt.GetBoolean(col));
                                    break;

                                case "int":
                                case "decimal":
                                case "double":
                                case "float":
                                case "long":
                                    d.Type = "Number";
                                    d.Value = Convert.ToString(dt[col]);
                                    break;

                                default:
                                    d.Type = "Number";
                                    d.Value = dt.GetString(col).ToString().Replace(',', '.');
                                    break;
                            }
                            Cell c = new Cell();
                            c.AddElement(d);
                            novaLilha.AddCell(c);
                        }
                        AddRow(novaLilha);
                        count++;
                    }
                }
            }
            catch (Exception e)
            {
                throw new Exception("Erro ao criar tabela: " + e.Message);
            }
        }


        /// <summary>
        /// Método para adicionar dados a tabela
        /// </summary>
        /// <param name="data"></param>
        /// <param name="titles"></param>
        public void AddData(IEnumerable<Object> data)
        {
            AddData(data, (Row)null, false, false);
        }

        /// <summary>
        /// Método para adicionar dados a tabela
        /// </summary>
        /// <param name="data"></param>
        /// <param name="titles"></param>
        public void AddData(IEnumerable<Object> data, List<Cell> titles)
        {
            AddData(data, titles, false, false);
        }

        /// <summary>
        /// Método para adicionar dados a tabela
        /// </summary>
        /// <param name="data"></param>
        /// <param name="titles"></param>
        /// <param name="useDefaultStyle"></param>
        public void AddData(IEnumerable<Object> data, List<Cell> titles, bool useDefaultStyle)
        {
            AddData(data, titles, false, useDefaultStyle);
        }

        /// <summary>
        /// Método para adicionar dados a tabela
        /// </summary>
        /// <param name="data">Lista de dados</param>
        /// <param name="autoTitle"></param>
        /// <param name="useDefaultStyle"></param>
        public void AddData(IEnumerable<Object> data, bool autoTitle, bool useDefaultStyle)
        {
            AddData(data, (Row)null, autoTitle, useDefaultStyle);
        }

        /// <summary>
        /// Método para adicionar dados a tabela
        /// </summary>
        /// <param name="data"></param>
        /// <param name="titles"></param>
        /// <param name="autoTitle"></param>
        /// <param name="useDefaultStyle"></param>
        public void AddData(IEnumerable<Object> data, List<Cell> titles, bool autoTitle, bool useDefaultStyle)
        {
            AddData(data, new Row(titles), autoTitle, useDefaultStyle);
        }
        /// <summary>
        /// Método para adicionar dados a tabela
        /// </summary>
        /// <param name="data">Lista de dados</param>
        /// <param name="titles">Linha com os Titulos</param>
        /// <param name="autoTitle">se true, auto gerar títulos para a coleção de dados</param>
        /// <param name="useDefaultStyle">se true, usa os styles padrões para os tipos de dados</param>
        public void AddData(IEnumerable<Object> data, Row titles, bool autoTitle, bool useDefaultStyle)
        {
            try
            {
                // adiciona os titulos a tabela                         
                if (titles != null)
                {
                    AddRow(titles);
                }

                if (data != null && data.Count() > 0)
                {
                    object obj = data.First();

                    // adiciona o estilo padrao para o titulo
                    if (useDefaultStyle)
                    {
                        var ps = obj.GetType().GetProperties();
                        foreach (PropertyInfo p in ps)
                        {
                            string styleId = null;
                            if (p.PropertyType.FullName.ToLower().Contains("int") ||
                                p.PropertyType.FullName.ToLower().Contains("decimal") ||
                                p.PropertyType.FullName.ToLower().Contains("double") ||
                                p.PropertyType.FullName.ToLower().Contains("float") ||
                                p.PropertyType.FullName.ToLower().Contains("long"))
                            {
                                styleId = "sDefaultNumber";
                            }                            
                            else if (p.PropertyType.FullName.ToLower().Contains("string"))
                            {
                                styleId = "sDefaultText";
                            }
                            else if (p.PropertyType.FullName.ToLower().Contains("datetime"))
                            {
                                styleId = "sDefaultDate";
                            }
                            else
                            {
                                styleId = "sDefaultText";
                            }
                            
                            if (styleId != null)
                                AddColumn(new Column(null, styleId));
                        }
                    }

                    // cria os titulos automaticamente na tabela                
                    if (autoTitle)
                    {
                        // titulos da tabela
                        Row rAutoTitles = new Row();
                        var pObj = obj.GetType().GetProperties();
                        foreach (PropertyInfo p in pObj)
                        {
                            string styleId = null;
                            if (useDefaultStyle)
                                styleId = "sDefaultTitle";
                            Data d = new Data("String", p.Name);
                            rAutoTitles.AddCell(new Cell(null, styleId, new List<Element>() { d }));
                        }
                        AddRow(rAutoTitles);
                    }


                    // adiciona os dados na tabela
                    foreach (Object o in data)
                    {
                        Row nRow = new Row();
                        var properties = o.GetType().GetProperties();
                        foreach (PropertyInfo prop in properties)
                        {
                            Cell c = new Cell();
                            if (prop.Name.Equals("Value") || prop.PropertyType.IsInterface)
                                continue;
                            MethodInfo getter = prop.GetGetMethod();
                            Object val = getter.Invoke(o, null);

                            Data d = new Data();
                            if (prop.PropertyType.FullName.ToLower().Contains("int") ||
                                prop.PropertyType.FullName.ToLower().Contains("decimal") ||
                                prop.PropertyType.FullName.ToLower().Contains("double") ||
                                prop.PropertyType.FullName.ToLower().Contains("float") ||
                                prop.PropertyType.FullName.ToLower().Contains("long"))
                            {
                                d.Type = "Number";
                                d.Value = (val != null) ? Convert.ToString(val).Replace(',', '.') : null;
                            }
                            else if (prop.PropertyType.FullName.ToLower().Contains("string"))
                            {
                                d.Type = "String";
                                d.Value = (val != null) ? val.ToString() : null;
                            }
                            else if (prop.PropertyType.FullName.ToLower().Contains("datetime"))
                            {
                                d.Type = "DateTime";
                                d.Value = (val != null) ? ((DateTime)val).ToString("s") : null;
                            }
                            
                            else if (prop.PropertyType.FullName.ToLower().Contains("boolean"))
                            {
                                d.Type = "Boolean";
                                d.Value = (val != null) ? Convert.ToString((bool)val) : null;
                            }                            
                            else
                            {
                                d.Type = "String";
                                d.Value = (val != null) ? Convert.ToString(val).Replace(',', '.') : null;
                            }
                            
                            if (val != null)
                                c.AddElement(d);
                            nRow.AddCell(c);
                        }
                        AddRow(nRow);
                    }
                }
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        /// <summary>
        /// Método para adicionar elementos na tabela (lista de elementos)
        /// </summary>
        /// <param name="nElement">Elemento (Row, Columns, etc)</param>
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

        ~Table()
        {
            if (Elements != null)
                Elements.Clear();
        }

    }
}
