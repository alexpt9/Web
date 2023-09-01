using DevExpress.Mvvm.UI;
using DevExpress.Mvvm.UI.Interactivity;
using DevExpress.Xpf.Core;
using DevExpress.Xpf.Grid;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace Devexpress.GridControl.Demo.UI.Behaviours
{
    public class ColumnSimpleButtonBehaviour : Behavior<Button>
    {
        GridColumnHeader colHeader;
        protected override void OnAttached()
        {
            base.OnAttached();
            // unsubscribe from the AssociatedObject events
            AssociatedObject.Click += AssociatedObject_Click;
            AssociatedObject.Loaded += AssociatedObject_Loaded;
            AssociatedObject.Unloaded += AssociatedObject_Unloaded;
        }

        protected override void OnDetaching()
        {
            // unsubscribe from the AssociatedObject events
            AssociatedObject.Click -= AssociatedObject_Click;
            AssociatedObject.Loaded -= AssociatedObject_Loaded;
            AssociatedObject.Unloaded -= AssociatedObject_Unloaded;
            base.OnDetaching();
        }

        private void AssociatedObject_Loaded(object sender, RoutedEventArgs e)
        {
            AssociatedObject.Visibility = Visibility.Collapsed;
            colHeader = GetGridColumnHeader(sender);
            if (colHeader != null)
            {
                colHeader.MouseEnter += ColHeader_MouseEnter;
                colHeader.MouseLeave += ColHeader_MouseLeave;
            }
        }

        private void AssociatedObject_Unloaded(object sender, RoutedEventArgs e)
        {
            if (colHeader != null)
            {
                colHeader.MouseEnter -= ColHeader_MouseEnter;
                colHeader.MouseLeave -= ColHeader_MouseLeave;
            }
        }

        private void ColHeader_MouseLeave(object sender, MouseEventArgs e)
        {
            if(colHeader is null)
                AssociatedObject.Visibility = Visibility.Collapsed;
            if (colHeader.ColumnFilterPopup.IsPopupOpen)
                return;
            AssociatedObject.Visibility = Visibility.Collapsed;
        }

        private void ColHeader_MouseEnter(object sender, MouseEventArgs e)
        {
            AssociatedObject.Visibility = Visibility.Visible;
        }

        private void AssociatedObject_Click(object sender, RoutedEventArgs e)
        {
            GridColumnHeader colHeader = GetGridColumnHeader(sender);
            colHeader?.ColumnFilterPopup.ShowPopup();
            if(colHeader != null)
                colHeader.ColumnFilterPopup.PopupClosed += ColumnFilterPopup_PopupClosed;
        }

        private void ColumnFilterPopup_PopupClosed(object sender, DevExpress.Xpf.Editors.ClosePopupEventArgs e)
        {
            AssociatedObject.Visibility = Visibility.Collapsed;
            colHeader.ColumnFilterPopup.PopupClosed -= ColumnFilterPopup_PopupClosed;
        }

        private  GridColumnHeader GetGridColumnHeader(object sender)
        {
            var simpleButton = sender as Button;
            if (simpleButton is null)
                return null;
            var gridColumnData = simpleButton.DataContext as GridColumnData;
            if (gridColumnData is null)
                return null;

            var tableView = gridColumnData.View as TableView;
            GridColumnHeader colHeader = LayoutTreeHelper.GetVisualChildren(gridColumnData.View).OfType<GridColumnHeader>().
                FirstOrDefault(h => (GridColumn)h.DataContext == gridColumnData.Column);
            return colHeader;
        }
    }
}
