using DevExpress.Data;
using DevExpress.Mvvm.UI.Interactivity;
using DevExpress.Xpf.Grid;
using System.Linq;

namespace Devexpress.GridControl.Demo.UI.Behaviours
{
    public class ColumnSortingFilteringBehaviour : Behavior<TableView>
    {
        protected override void OnAttached()
        {
            base.OnAttached();
            // unsubscribe from the AssociatedObject events
            AssociatedObject.ColumnHeaderClick += AssociatedObject_ColumnHeaderClick;
            AssociatedObject.ShowFilterPopup += AssociatedObject_ShowFilterPopup;
        }

        protected override void OnDetaching()
        {
            // unsubscribe from the AssociatedObject events
            AssociatedObject.ColumnHeaderClick -= AssociatedObject_ColumnHeaderClick;
            AssociatedObject.ShowFilterPopup -= AssociatedObject_ShowFilterPopup;
            base.OnDetaching();
        }

        private void AssociatedObject_ColumnHeaderClick(object sender, ColumnHeaderClickEventArgs e)
        {
            if (!AssociatedObject.AllowSorting)
            {
                e.Handled = true;
                return;
            }

            if (e.Column.SortOrder == ColumnSortOrder.Descending)
            {
                e.Column.SortOrder = ColumnSortOrder.None;
                e.Handled = true;
            }
        }

        private void AssociatedObject_ShowFilterPopup(object sender, FilterPopupEventArgs e)
        {
            if (e.Column is null)
                return;
            if (e.Column.FieldType.Name.Equals("DateTime"))
            {
                e.ExcelColumnFilterSettings.FilterItems.Reverse();
            }
        }
    }
}
