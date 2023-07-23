using DevExpress.Mvvm;
using DevExpress.Xpf.Grid;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Devexpress.GridControl.Demo.UI.Model
{
    public class Field : BindableBase
    {
        public string Id { get; set; }
        public string HeaderName 
        {
            get { return GetValue<string>(); }
            set { SetValue(value); }
        }
        public string Width { get; set; }
        public FixedStyle Fixed { get; set; }
        public TemplateType TemplateType { get;  set; }

        public string EnName { get; set; }

        public string HebName { get; set; }

        public bool IsCheckBoxColumn { get; set; }
    }

    public enum TemplateType
    {
        Default,
        Lookup,
        checkbox
    }
}
