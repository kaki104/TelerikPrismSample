using Prism;
using Prism.Mvvm;
using System;

namespace TelerikPrismSample.ViewModels
{
    public class ViewAViewModel : BindableBase, IActiveAware
    {
        public ViewAViewModel()
        {

        }

        private bool isActive;
        public bool IsActive
        {
            get => isActive;
            set => SetProperty(ref isActive, value);
        }

        public event EventHandler IsActiveChanged;
    }
}
