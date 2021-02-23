using Prism.Ioc;
using Prism.Regions;
using System.Windows;
using Telerik.Windows.Controls;
using TelerikPrismSample.Views;

namespace TelerikPrismSample
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App
    {
        protected override Window CreateShell()
        {
            return Container.Resolve<MainWindow>();
        }

        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {

        }

        protected override void ConfigureRegionAdapterMappings(RegionAdapterMappings regionAdapterMappings)
        {
            base.ConfigureRegionAdapterMappings(regionAdapterMappings);
            regionAdapterMappings.RegisterMapping(typeof(RadDocking), Container.Resolve<DockingRegionAdapter>());
        }
    }
}
