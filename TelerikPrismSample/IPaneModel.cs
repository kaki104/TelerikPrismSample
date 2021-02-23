using Telerik.Windows.Controls.Docking;

namespace TelerikPrismSample
{
    public interface IPaneModel
    {
        DockState Position { get; }
    }
}