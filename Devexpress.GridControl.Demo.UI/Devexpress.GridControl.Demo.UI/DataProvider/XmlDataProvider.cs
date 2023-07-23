using Devexpress.GridControl.Demo.UI.Interfaces;
using Devexpress.GridControl.Demo.UI.Model;
using DevExpress.Xpf.Grid;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace Devexpress.GridControl.Demo.UI.DataProvider
{
    public class XmlDataProvider : IXmlDataProvider
    {
        public List<Field> GetBlotterColumns(string fileName)
        {
            XmlDocument xdc = new XmlDocument();
            xdc.Load(Environment.CurrentDirectory + @"\Resource\" + fileName);
            XmlNodeList xmlNodes = xdc.SelectNodes("/Columns/Column");
            List<Field> columnFields = new List<Field>();
            //columnFields.Add(new Field() { Id = "IsSelected", TemplateType = TemplateType.checkbox, Fixed = FixedStyle.Left, EnName = string.Empty, HebName= string.Empty}); 
            foreach (XmlNode xmlNode in xmlNodes)
            {
                Field field = new Field();
                XmlElement element = (XmlElement)xmlNode;
                foreach(XmlNode child in xmlNode.ChildNodes)
                { 
                    if(child.Name == "Id")
                       field.Id = child.InnerText;
                    if (child.Name == "Name")
                        field.HeaderName = child.InnerText; ;
                    if (child.Name == "Type")
                        field.TemplateType = child.InnerText== "Default" ? TemplateType.Default : TemplateType.Lookup;
                    if (child.Name == "Fixed")
                        field.Fixed = child.InnerText == "True" ? FixedStyle.Left : FixedStyle.None;
                    if (child.Name == "Width")
                        field.Width = child.InnerText;
                    if (child.Name == "EnName")
                        field.EnName = child.InnerText;
                    if (child.Name == "HebName")
                        field.HebName = child.InnerText;
                    field.HeaderName = field.EnName;

                }
                columnFields.Add(field);
            }
            return columnFields;
        }
    }
}
