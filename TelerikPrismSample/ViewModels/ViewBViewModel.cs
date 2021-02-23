using Prism;
using Prism.Commands;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;

namespace TelerikPrismSample.ViewModels
{
    public class ViewBViewModel : BindableBase, IActiveAware
    {
        public ViewBViewModel()
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
