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

        private Person _selectedItem;
        public Person SelectedItem
        {
            get { return _selectedItem; }
            set
            {
                _selectedItem = value;
            }
        }

        public bool AllowColumnAutoWidth
        {
            get { return GetValue<bool>(); }
            set { SetValue(value); }
        }

        public List<string> Colours
        {
            get { return GetValue<List<string>>(); }
            set { SetValue(value); }
        }

        public string Colour
        {
            get { return GetValue<string>(); }
            set { SetValue(value); }
        }

        public List<double> FontSizes
        {
            get { return GetValue<List<double>>(); }
            set { SetValue(value); }
        }

        public double SelectedFontSize
        {
            get { return GetValue<double>(); }
            set { SetValue(value); }
        }

        public ObservableCollection<ContextMenuItem> ContextMenuItems
        {
            get { return GetValue<ObservableCollection<ContextMenuItem>>(); }
            set { SetValue(value); }
        }

        public List<double> Thickness
        {
            get { return GetValue<List<double>>(); }
            set { SetValue(value); }
        }

        public double BorderThickness
        {
            get { return GetValue<double>(); }
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
            FontSizes = new List<double>() { 10, 15, 20, 30 };
            Colours = new List<string>() { "Red", "Yellow", "Green", "Black" };
            Colour = Colours.Last();
            ContextMenuItems = new ObservableCollection<ContextMenuItem>();
            ContextMenuItems.Add(new ContextMenuItem() { Caption = "Dynamic Item 1", ContextMenuCommand = new DelegateCommand<string>(OnContextMenuExecute) });
            ContextMenuItems.Add(new ContextMenuItem() { Caption = "Dynamic Item 2", ContextMenuCommand = new DelegateCommand<string>(OnContextMenuExecute) });
            Thickness = new List<double>() { 0.5, 1, 1.5, 2, 2.5, 3, 3.5, 4, 4.5, 5 };
        }

        private void OnContextMenuExecute(string obj)
        {
            
        }
    }

    public class ContextMenuItem
    {
        public string Caption { get; set; }

        public DelegateCommand<string> ContextMenuCommand { get; set; }
    }
}
