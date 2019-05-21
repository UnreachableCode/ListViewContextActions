using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ListViewContextActions.ViewCells
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SimpleItemViewCell : BaseTemplate
    {
        public SimpleItemViewCell()
        {
            InitializeComponent();
        }

        public static readonly BindableProperty ReferencedPageModelProperty = BindableProperty.Create(nameof(ReferencedPageModel),
                                                                            typeof(object),
                                                                            typeof(SimpleItemViewCell),
                                                                            defaultValue: null,
                                                                            propertyChanged: ReferencedPageChanged,
                                                                            defaultBindingMode: BindingMode.TwoWay);
        private static MenuItem menuItem;
        private static ViewCell simpleViewCell;

        static void ReferencedPageChanged(object bindableObject, object oldValue, object newValue)
        {
            if (newValue != null)
            {
                menuItem = new MenuItem();
                menuItem.Icon = "sharp_delete_white_24.png";
                menuItem.SetBinding(MenuItem.CommandProperty, new Binding("DeleteSelectedCommand", source: newValue));

                simpleViewCell = bindableObject as ViewCell;
            }
        }

        protected override void OnBindingContextChanged()
        {
            base.OnBindingContextChanged();
            if (BindingContext != null)
            {
                menuItem.SetBinding(MenuItem.CommandParameterProperty, new Binding("BindingContext", source: this));
                simpleViewCell.ContextActions.Add(menuItem);
            }
        }

        public object ReferencedPageModel
        {
            set { SetValue(ReferencedPageModelProperty, value); }
            get { return GetValue(ReferencedPageModelProperty); }
        }
    }
}