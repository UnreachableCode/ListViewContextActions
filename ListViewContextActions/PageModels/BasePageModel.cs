using System;
using FreshMvvm;

namespace ListViewContextActions.PageModels
{
    public class BasePageModel : FreshBasePageModel
    {
        private bool _isBusy;
        public bool IsBusy
        {
            get => _isBusy;
            set
            {
                _isBusy = value;
                RaisePropertyChanged(nameof(IsBusy));
            }
        }
    }
}
