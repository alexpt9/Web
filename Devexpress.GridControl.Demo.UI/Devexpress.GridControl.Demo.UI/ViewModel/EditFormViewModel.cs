using DevExpress.Mvvm.DataAnnotations;
using DevExpress.Mvvm.POCO;
using DevExpress.Xpf.Grid.EditForm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace Devexpress.GridControl.Demo.UI.ViewModel
{
    [POCOViewModel]
    public class EditFormViewModel
    {
        public virtual List<string> Products { get; set; }
        public virtual string Product { get; set; }

        public virtual long? Quantity { get; set; }
        public virtual Decimal? Price { get; set; }

        protected EditFormViewModel()
        {
            Products = new List<string>() { "Formal Pants", "Shirts", "Jeans", "Shoes " };
        }

        public static EditFormViewModel Create()
        {
            return ViewModelSource.Create(() => new EditFormViewModel());
        }

        public void  Commit(object sender)
        {
            if(Price is null)
            {
                MessageBox.Show("Price is empty");
                return;
            }

            MessageBox.Show("Updated Successfully.");
            CloseView(sender);
        }

        public void CloseView(object sender)
        {
            var y = ((UserControl)sender).TemplatedParent as ContentPresenter;
            var z = y.Content as EditFormRowData;
            z.CancelCommand.Execute(null);
        }

    }
}
