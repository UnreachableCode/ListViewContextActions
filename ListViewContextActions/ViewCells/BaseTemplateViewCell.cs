
using Xamarin.Forms;

namespace ListViewContextActions.ViewCells
{
    public class BaseTemplate : ViewCell
    {
        public static BindableProperty ParentBindingContextProperty = BindableProperty.Create(nameof(ParentBindingContext), typeof(object), typeof(BaseTemplate), null);

        public object ParentBindingContext
        {
            get { return GetValue(ParentBindingContextProperty); }
            set { SetValue(ParentBindingContextProperty, value); }
        }
    }
}
