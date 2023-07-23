using Devexpress.GridControl.Demo.UI.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Devexpress.GridControl.Demo.UI.Interfaces
{
    public interface IXmlDataProvider
    {
        List<Field> GetBlotterColumns(string fileName);
    }
}
