using Devexpress.GridControl.Demo.UI.Model;
using DevExpress.Xpf.Grid.GroupRowLayout;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace Devexpress.GridControl.Demo.UI.Template
{
    public class ColumnTemplateSelector : DataTemplateSelector
    {
        public DataTemplate DefaultColumnTemplate { get; set; }
        public DataTemplate LookupColumnTemplate { get; set; }
        public DataTemplate CheckboxTemplate { get; set; }
        
        public override DataTemplate SelectTemplate(object item, DependencyObject container)
        {
            Field column = item as Field;
            if (column == null) return null;
            switch (column.TemplateType)
            {
                case TemplateType.Default:
                    return DefaultColumnTemplate;
                case TemplateType.Lookup:
                    return LookupColumnTemplate;
                case TemplateType.checkbox:
                    return CheckboxTemplate;
            }
            return null;
        }
    }
}
