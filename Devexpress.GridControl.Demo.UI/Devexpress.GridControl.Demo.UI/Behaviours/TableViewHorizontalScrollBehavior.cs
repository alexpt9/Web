using System.Windows.Controls;
using System.Windows.Input;
using DevExpress.Mvvm.UI.Interactivity;
using DevExpress.Xpf.Grid;

namespace Devexpress.GridControl.Demo.UI.Behaviours
{
  //https://www.devexpress.com/Support/Center/Question/Details/T837996/scrolling-tableview-horizontally-with-the-mouse-wheel-doesn-t-work-as-suggested-in-q567066
  public class TableViewHorizontalScrollBehavior : Behavior<TableView>
  {
    protected override void OnAttached()
    {
      base.OnAttached();
      AssociatedObject.Loaded += OnLoaded;
    }

    protected override void OnDetaching()
    {
      AssociatedObject.Loaded -= OnLoaded;
      base.OnDetaching();
    }

    private void OnLoaded(object sender, System.Windows.RoutedEventArgs e)
    {
      var presenter = (ScrollContentPresenter)AssociatedObject.ScrollContentPresenter;
      var scrollViewer = (ScrollViewer)presenter?.TemplatedParent;

      if (scrollViewer == null)
        return;

      //scrollViewer.PreviewMouseWheel -= OnPreviewMouseWheel;
      scrollViewer.PreviewMouseWheel += OnPreviewMouseWheel;
    }

    private void OnPreviewMouseWheel(object sender, MouseWheelEventArgs e)
    {
      //https://stackoverflow.com/questions/5750722/how-to-detect-modifier-key-states-in-wpf
      if (Keyboard.Modifiers != ModifierKeys.Shift)
        return;

      var scrollviewer = (ScrollViewer)sender;

      if (e.Delta > 0)
        scrollviewer.LineLeft();
      else
        scrollviewer.LineRight();

      e.Handled = true;
    }
  }
}
