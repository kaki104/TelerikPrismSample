using System.Windows.Controls;
using Telerik.Windows.Controls.Docking;

namespace TelerikPrismSample.Views
{
    /// <summary>
    /// Interaction logic for ViewB
    /// </summary>
    public partial class ViewB : UserControl, IPaneModel
    {
        public ViewB()
        {
            InitializeComponent();
        }

        public DockState Position => DockState.FloatingDockable;
    }
}
