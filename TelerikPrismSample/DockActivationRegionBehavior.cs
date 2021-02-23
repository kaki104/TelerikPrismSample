using Prism.Regions;
using Prism.Regions.Behaviors;
using System.Collections.Specialized;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using Telerik.Windows.Controls;

namespace TelerikPrismSample
{
    /// <summary>
    /// DockActivationRegionBehavior
    /// </summary>
    public class DockActivationRegionBehavior : RegionBehavior, IHostAwareRegionBehavior
    {
        public const string BehaviorKey = "DockActivationRegionBehavior";
        private RadDocking _hostControl;
        public DependencyObject HostControl
        {
            get => _hostControl;
            set => _hostControl = value as RadDocking;
        }

        protected override void OnAttach()
        {
            _hostControl.ActivePaneChanged += RadDocking_ActivePaneChanged;
            _hostControl.Close += RadDocking_Close;
            Region.ActiveViews.CollectionChanged += ActiveViews_CollectionChanged;
        }

        private void RadDocking_Close(object sender, Telerik.Windows.Controls.Docking.StateChangeEventArgs e)
        {
            //todo : 패인 닫힐때 처리 추가
        }

        /// <summary>
        /// 액티브뷰가 변경될때
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ActiveViews_CollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            if (e.Action == NotifyCollectionChangedAction.Add)
            {
                //are we dealing with a view
                FrameworkElement frameworkElement = e.NewItems[0] as FrameworkElement;
                if (frameworkElement != null)
                {
                    RadPane pane = _hostControl.Panes.FirstOrDefault(p => p.Content == frameworkElement);
                    if (pane != null)
                    {
                        pane.IsActive = true;
                    }
                }
                else
                {
                    //must be a viewmodel
                    object viewModel = e.NewItems[0];
                    RadPane contentPane = GetContentPaneFromFromViewModel(viewModel);
                    if (contentPane != null)
                    {
                        contentPane.IsActive = true;
                    }
                }
            }
        }
        /// <summary>
        /// 뷰모델에서 패인찾음
        /// </summary>
        /// <param name="viewModel"></param>
        /// <returns></returns>
        private RadPane GetContentPaneFromFromViewModel(object viewModel)
        {
            System.Collections.Generic.IEnumerable<RadPane> panes = _hostControl.Panes.OfType<RadPane>();
            foreach (RadPane contentPane in panes)
            {
                if (contentPane.DataContext == viewModel)
                {
                    return contentPane;
                }
            }
            return null;
        }
        /// <summary>
        /// RadDocking Active
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void RadDocking_ActivePaneChanged(object sender, Telerik.Windows.Controls.Docking.ActivePangeChangedEventArgs e)
        {
            if (e.OldPane != null)
            {
                RadPane item = e.OldPane;
                //ContentPane을 직접 다루고 있습니까?
                if (Region.Views.Contains(item) && Region.ActiveViews.Contains(item))
                {
                    Region.Deactivate(item);
                }
                else
                {
                    //이제 주입 된 뷰가 있는지 확인
                    ContentControl contentControl = item;
                    if (contentControl != null)
                    {
                        object injectedView = contentControl.Content;
                        if (Region.Views.Contains(injectedView) && Region.ActiveViews.Contains(injectedView))
                        {
                            Region.Deactivate(injectedView);
                        }
                    }
                }
            }

            if (e.NewPane != null)
            {
                RadPane item = e.NewPane;

                //ContentPane을 직접 다루고 있습니까?
                if (Region.Views.Contains(item) && !Region.ActiveViews.Contains(item))
                {
                    Region.Activate(item);
                }
                else
                {
                    //이제 주입 된 뷰가 있는지 확인
                    ContentControl contentControl = item;
                    if (contentControl != null)
                    {
                        object injectedView = contentControl.Content;
                        if (Region.Views.Contains(injectedView) && !Region.ActiveViews.Contains(injectedView))
                        {
                            Region.Activate(injectedView);
                        }
                    }
                }
            }
        }
    }
}