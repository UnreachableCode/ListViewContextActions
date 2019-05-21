using ListViewContextActions.PageModels;
using Xamarin.Forms;

namespace ListViewContextActions.ViewCells
{
    public class PersonItemDataTemplateSelector : DataTemplateSelector
    {
        protected override DataTemplate OnSelectTemplate(object item, BindableObject container)
        {
            //SimpleTemplate.SetValue(BaseTemplate.ParentBindingContextProperty, container.BindingContext);

            //return ((PeopleListPageModel)container.BindingContext).SimpleCellsEnabled ? SimpleTemplate : DetailedTemplate;
            return SimpleTemplate;
        }

        public DataTemplate SimpleTemplate { get; set; }
        public DataTemplate DetailedTemplate { get; set; }
    }
}
