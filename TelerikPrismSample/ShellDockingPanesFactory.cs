using System.Linq;
using Telerik.Windows.Controls;
using Telerik.Windows.Controls.Docking;

namespace TelerikPrismSample
{
    public class ShellDockingPanesFactory : DockingPanesFactory
    {
        protected override void AddPane(RadDocking radDocking, RadPane pane)
        {
            var paneModel = pane as IPaneModel;
            if (paneModel != null && !(pane is RadPane))
            {
                RadPaneGroup group = null;
                switch (paneModel.Position)
                {
                    case DockState.DockedRight:
                        group = radDocking.SplitItems.ToList()
                            .FirstOrDefault(i => i.Control.Name == "rightGroup") as RadPaneGroup;
                        if (group != null)
                        {
                            group.Items.Add(pane);
                        }
                        return;
                    case DockState.DockedBottom:
                        group = radDocking.SplitItems.ToList()
                            .FirstOrDefault(i => i.Control.Name == "bottomGroup") as RadPaneGroup;
                        if (group != null)
                        {
                            group.Items.Add(pane);
                        }
                        return;
                    case DockState.DockedLeft:
                        group = radDocking.SplitItems.ToList()
                            .FirstOrDefault(i => i.Control.Name == "leftGroup") as RadPaneGroup;
                        if (group != null)
                        {
                            group.Items.Add(pane);
                        }
                        return;
                    case DockState.FloatingDockable:
                        var fdSplitContainer = radDocking.GeneratedItemsFactory.CreateSplitContainer();
                        group = radDocking.GeneratedItemsFactory.CreatePaneGroup();
                        fdSplitContainer.Items.Add(group);
                        group.Items.Add(pane);
                        radDocking.Items.Add(fdSplitContainer);
                        pane.MakeFloatingDockable();
                        return;
                    case DockState.FloatingOnly:
                        var foSplitContainer = radDocking.GeneratedItemsFactory.CreateSplitContainer();
                        group = radDocking.GeneratedItemsFactory.CreatePaneGroup();
                        foSplitContainer.Items.Add(group);
                        group.Items.Add(pane);
                        radDocking.Items.Add(foSplitContainer);
                        pane.MakeFloatingOnly();
                        return;
                    case DockState.DockedTop:
                    default:
                        return;
                }
            }
            else
            {
                var hostGroup = radDocking.SplitItems.ToList()
                    .FirstOrDefault(i => i.Control.Name == "hostGroup") as RadPaneGroup;
                if (hostGroup != null)
                {
                    pane.Header = $"{pane.Content.GetType().Name}";
                    hostGroup.Items.Add(pane);
                    return;
                }
            }

            base.AddPane(radDocking, pane);
        }
    }
}