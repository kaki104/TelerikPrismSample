using System.Windows.Controls;
using Telerik.Windows.Controls.Docking;

namespace TelerikPrismSample.Views
{
    /// <summary>
    /// Interaction logic for ViewA
    /// </summary>
    public partial class ViewA : UserControl, IPaneModel
    {
        public ViewA()
        {
            InitializeComponent();
        }

        public DockState Position => DockState.FloatingDockable;
    }
}
