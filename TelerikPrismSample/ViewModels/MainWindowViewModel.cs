using Prism.Commands;
using Prism.Ioc;
using Prism.Mvvm;
using Prism.Regions;
using System;
using System.Linq;
using System.Windows.Input;

namespace TelerikPrismSample.ViewModels
{
    public class MainWindowViewModel : BindableBase
    {
        private string _title = "Prism Application";
        private readonly IContainerProvider _containerProvider;
        private readonly IRegionManager _regionManager;

        public string Title
        {
            get { return _title; }
            set { SetProperty(ref _title, value); }
        }

        public ICommand OpenCommand { get; set; }

        public MainWindowViewModel()
        {
        }

        public MainWindowViewModel(
            IContainerProvider containerProvider, 
            IRegionManager regionManager)
        {
            _containerProvider = containerProvider;
            _regionManager = regionManager;

            OpenCommand = new DelegateCommand<string>(OnOpen);
        }

        private void OnOpen(string obj)
        {
            switch(obj)
            {
                case "ViewA":
                case "ViewB":
                    ActivateRegion(obj, $"TelerikPrismSample.Views.{obj}, TelerikPrismSample, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null");
                    break;
            }
        }

        private void ActivateRegion(string viewName, string typeName)
        {
            var type = Type.GetType(typeName);
            if (type == null)
                throw new Exception("The view cannot be found. Please check the ClassName.");

            var region = _regionManager.Regions["ContentRegion"];
            object existView = (from view in region.Views
                                let viewTypeName = view.GetType().Name
                                where viewTypeName == viewName
                                select view).FirstOrDefault();
            if (existView == null)
            {
                object view = _containerProvider.Resolve(type);
                region.Add(view);
                region.Activate(view);
            }
            else
            {
                region.Activate(existView);
            }
        }
    }
}
