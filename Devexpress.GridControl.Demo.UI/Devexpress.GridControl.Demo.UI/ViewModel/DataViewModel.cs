using Devexpress.GridControl.Demo.UI.DataProvider;
using Devexpress.GridControl.Demo.UI.Model;
using DevExpress.Mvvm;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Devexpress.GridControl.Demo.UI.ViewModel
{
    public class DataViewModel : ViewModelBase
    { 
        public bool IsContentAlighenedRightToLeft 
        {
            get { return GetValue<bool>(); }
            set 
            { 
                SetValue(value);
                Messenger.Default.Send(IsContentAlighenedRightToLeft);
                if(value)
                {
                    foreach(var item in Columns)
                    {
                        item.HeaderName = item.EnName;
                    }
                }
                else
                {
                    foreach (var item in Columns)
                    {
                        item.HeaderName = item.HebName;
                    }
                }
            }
        }
        public ObservableCollection<Field> Columns
        {
            get { return GetProperty(() => Columns); }
            set { SetProperty(() => Columns, value); }
        }
        public ObservableCollection<Person> Data 
        {
            get { return GetValue<ObservableCollection<Person>>(); }
            set { SetValue(value); } 
        } 

        public DataViewModel()
        {
            var xmlDataPrvider = new XmlDataProvider();
            Columns = new ObservableCollection<Field>();
            Columns.AddRange(xmlDataPrvider.GetBlotterColumns("DataViewColumns.xml"));
            var dataProvider = new ApiDataProvider();
            Data = new ObservableCollection<Person>();
            Data.AddRange(dataProvider.GetPersonsList());
            IsContentAlighenedRightToLeft = false;
        }
    }
}
