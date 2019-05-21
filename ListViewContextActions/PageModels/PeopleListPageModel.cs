using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Input;
using ListViewContextActions.Models;
using Xamarin.Forms;

namespace ListViewContextActions.PageModels
{
    public class PeopleListPageModel : BasePageModel
    {
        private ICommand _deleteSelectedCommand;

        public ICommand DeleteSelectedCommand => _deleteSelectedCommand ?? (_deleteSelectedCommand = new Command<Person>(async personItem =>
        {
            await DeleteScanItem(personItem);
        }));

        protected override void ViewIsAppearing(object sender, EventArgs e)
        {
            base.ViewIsAppearing(sender, e);

            for (int i = 0; i < 20; i++)
            {
                PersonItems.Add(new Person
                {
                    Name = $"Person {i}",
                    Number = i
                });
            }
        }

        private async Task DeleteScanItem(Person personItem)
        {
            var confirmDelete = await CoreMethods.DisplayAlert(
                $"Delete: {personItem.Name}",
                "Are you sure you want to delete?",
                "Ok",
                "Cancel"
            );

            if (confirmDelete)
            {
                RemoveItemFromList(personItem.Number);
            }
        }

        private void RemoveItemFromList(int personNumber)
        {
            var removingPerson = PersonItems.FirstOrDefault(s => s.Number == personNumber);
            var isTopItem = removingPerson == PersonItems.First();
            PersonItems.Remove(removingPerson);
            //if (!isTopItem) // No need to renumber if only the top item is removed
            //{
            RenumberItems();
            //}
        }

        private void RenumberItems()
        {
            var itemCount = PersonItems.Count;
            for (int i = 0; i < itemCount; i++)
            {
                PersonItems[i].Number = i;
            }
            RaisePropertyChanged(nameof(PersonItems));
        }

        public ObservableCollection<Person> PersonItems
        {
            get => _personItems ?? (_personItems = new ObservableCollection<Person>());
            set => _personItems = value;
        }
        public bool SimpleCellsEnabled { get; internal set; } = true;

        private ObservableCollection<Person> _personItems;
    }
}