/************************************************************* 
 * ESCRITURAÇÃO FISCAL DIGITAL - EFD
 * ***********************************************************
 * Classe responsável pela criação de arquivos em excel (xml)
 * 
 * 
 * SGI - All rights reserved ©.
 * Criado por: Christian Bakargy de Souza
 * Data da Criação: 17/11/2011 13:53:03 PM
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
    using System.Reflection;
    using System.Data.Common;

    public class Excel : IDisposable
    {
        /// <summary>
        /// Número máximo de linhas por pagina ou planilha
        /// </summary>
        private int maximoLinhasPorPlanilha = 65000;

        /// <summary>
        /// Arquivo em XML gerado
        /// </summary>
        private XmlTextWriter xml;

        
        /// <summary>
        /// Doc em XML
        /// </summary>
        public XmlTextWriter Doc
        {
            get
            {
                return xml;
            }
            set
            {
                xml = value;
            }
        }

        public StringWriter sw { get; set; }
        /// <summary>
        // Extensão do arquivo
        /// </summary>
        public string Extension { get; set; }

        /// <summary>
        /// Nome do arquivo
        /// </summary>
        public string FileName { get; set; }

        /// <summary>
        /// Diretório de destino do arquivo
        /// </summary>
        public string FilePath { get; set; }

        /// <summary>
        /// Lista de elementos
        /// </summary>
        public IList<Object> Elements;

        /// <summary>
        /// Construtor
        /// </summary>
        /// <param name="fileName">Nome do arquivo</param>
        /// <param name="extension">Extensão do arquivo</param>
        /// <param name="filePath">Diretório de destino</param>
        public Excel(string fileName, string extension, string filePath)
        {
            try
            {
                FileName = fileName;
                Extension = extension;
                FilePath = filePath;
            }
            catch(Exception ex)
            {
                throw new Exception("Erro ao criar/abrir o arquiquivo" + ex.Message);
            }
        }

        /// <summary>
        /// Construtor com StringWriter
        /// </summary>
        public Excel(ref StringWriter _sw)
        {
            try
            {
                sw = _sw;
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao criar/abrir o arquivo" + ex.Message);
            }
        }

        /// <summary>
        /// Método para início do arquivo
        /// </summary>
        private void Start()
        {
            try
            {
                xml = new XmlTextWriter(string.Format("{0}{1}.{2}", FilePath, FileName, Extension), Encoding.UTF8);
                xml.WriteStartDocument();
                xml.WriteRaw("<?mso-application progid=\"Excel.Sheet\"?>");
                xml.WriteStartElement("Workbook");
                xml.WriteAttributeString("xmlns", "urn:schemas-microsoft-com:office:spreadsheet");
                xml.WriteAttributeString("xmlns:o", "urn:schemas-microsoft-com:office:office");
                xml.WriteAttributeString("xmlns:x", "urn:schemas-microsoft-com:office:excel");
                xml.WriteAttributeString("xmlns:ss", "urn:schemas-microsoft-com:office:spreadsheet");
                xml.WriteAttributeString("xmlns:html", "http://www.w3.org/TR/REC-html40");
            }
            catch(Exception e)
            {
                throw new Exception("Erro ao cria arquivo: " + e.Message);
            }
        }

        /// <summary>
        /// Método para início do arquivo usando StringWriter
        /// </summary>
        private void StartSw()
        {
            try
            {
                xml = new XmlTextWriter(sw);
                xml.WriteStartDocument();
                xml.WriteRaw("<?mso-application progid=\"Excel.Sheet\"?>");
                xml.WriteStartElement("Workbook");
                xml.WriteAttributeString("xmlns", "urn:schemas-microsoft-com:office:spreadsheet");
                xml.WriteAttributeString("xmlns:o", "urn:schemas-microsoft-com:office:office");
                xml.WriteAttributeString("xmlns:x", "urn:schemas-microsoft-com:office:excel");
                xml.WriteAttributeString("xmlns:ss", "urn:schemas-microsoft-com:office:spreadsheet");
                xml.WriteAttributeString("xmlns:html", "http://www.w3.org/TR/REC-html40");
            }
            catch (Exception e)
            {
                throw new Exception("Erro ao cria arquivo: " + e.Message);
            }
        }

        /// <summary>
        /// Metodo para criar o arquivo excel
        /// </summary>
        public void Create()
        {
            try
            {
                Start();
                foreach(Element item in Elements)
                {
                    CreateElement(item);
                }
                End();
            }
            catch(Exception e)
            {
                throw e;
            }
        }

        /// <summary>
        /// Metodo para criar o arquivo excel
        /// </summary>
        public void CreateSw()
        {
            try
            {
                StartSw();
                foreach (Element item in Elements)
                {
                    CreateElement(item);
                }
                xml.WriteEndDocument();
                xml.Flush();
                Dispose();
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        /// <summary>
        /// Método para finalizar do arquivo
        /// </summary>
        private void End()
        {
            xml.WriteEndDocument();
            Dispose();
        }

        #region Métodos para criação de Styles

        /// <summary>
        /// Método para adicionar estilos para o documento
        /// </summary>
        /// <param name="nStyle"></param>
        public void AddStyles(Styles nStyles)
        {
            try
            {
                AddElement(nStyles);
            }
            catch(Exception e)
            {
                throw e;
            }
        }
        #endregion

        #region Métodos para criação de Elementos


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

        /// <summary>
        /// Método para adicionar elementos
        /// </summary>
        /// <param name="nElement"></param>
        private void CreateElement(Element nElement)
        {
            try
            {
                string sType = nElement.GetType().Name;
                Dictionary<string, string> tAttrs = (Dictionary<string, string>)nElement.CustomAttributes;
                var properties = nElement.GetType().GetProperties();
                if(tAttrs == null)
                    tAttrs = new Dictionary<string, string>();

                foreach(PropertyInfo prop in properties)
                {
                    if(prop.Name.Equals("Value") || prop.PropertyType.IsInterface)
                        continue;

                    MethodInfo getter = prop.GetGetMethod();
                    Object val = getter.Invoke(nElement, null);

                    if(val != null)
                    {
                        tAttrs.Add(prop.Name.Replace('_', ':'), Convert.ToString(val));
                    }
                }

                FieldInfo elements = nElement.GetType().GetField("Elements") ?? null;
                if(elements != null)
                {
                    CreateElement(sType, null, null, tAttrs, nElement.Value, false);
                    IList<Object> lElements = (List<Object>)elements.GetValue(nElement);
                    if(lElements != null)
                    {
                        foreach(Element e in lElements.OrderBy(e => e.GetType().Name))
                            CreateElement(e);
                    }
                    EndElement();
                }
                else
                {
                    CreateElement(sType, null, null, tAttrs, nElement.Value, true);
                }

            }
            catch(Exception e)
            {
                throw e;
            }
        }

        /// <summary>
        /// Método para adicionar elementos
        /// </summary>
        /// <param name="type">Tipo do elemento</param>
        /// <param name="id">Id</param>
        /// <param name="name">Nome</param>
        /// <param name="attributes">Lista de atributos customizados</param>
        /// <param name="value">Valor</param>
        private void CreateElement(string type, string id, string name, IDictionary<string, string> attributes,
            object value, bool endTag)
        {
            try
            {
                xml.WriteStartElement(type);

                if(!string.IsNullOrEmpty(id))
                    xml.WriteAttributeString("ss:ID", id);
                if(!string.IsNullOrEmpty(name))
                    xml.WriteAttributeString("ss:Name", name);

                if(attributes != null)
                {
                    foreach(KeyValuePair<string, string> attr in attributes)
                    {
                        string val;
                        switch(attr.Value.ToLower())
                        {
                            case "true":
                                val = "1";
                            break;
                            case "false":
                                val = "0";
                            break;
                            default:
                                val = attr.Value;
                            break;
                        }                        
                        xml.WriteAttributeString((attr.Key.Contains(":") || attr.Key.Contains("xmlns")) ? attr.Key : "ss:" + attr.Key, val);
                    }
                }
                if(value != null)
                {
                    xml.WriteValue(value);
                }

                if(endTag)
                    xml.WriteEndElement();
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public void EndElement()
        {
            xml.WriteEndElement();
        }

        #endregion

        #region Métodos para criação de WorkSheets (Planilhas ou Paginas)

        /// <summary>
        /// Método para Adicionar um worksheet
        /// </summary>
        /// <param name="nWorkSheet"></param>
        public void AddWorkSheet(Worksheet nWorkSheet)
        {
            try
            {
                AddElement(nWorkSheet);
            }
            catch(Exception e)
            {
                throw e;
            }
        }

        #endregion

        ~Excel()
        {
            if(Elements != null)
                Elements.Clear();
        }

        public bool Close()
        {
            Dispose();
            return true;
        }

        #region IDisposable Members

        public void Dispose()
        {
            xml.Close();
            Doc = null;
        }

        #endregion
    }
}
