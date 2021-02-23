using Prism.Regions;
using System.Windows;
using Telerik.Windows.Controls;

namespace TelerikPrismSample
{
    /// <summary>
    /// DockingRegionAdapter
    /// </summary>
    public class DockingRegionAdapter : RegionAdapterBase<RadDocking>
    {
        /// <summary>
        /// 어떤 뷰가 주입되었고 ContentPanes가 생성되었는지 확인하는 데 사용됩니다.
        /// </summary>
        private static readonly DependencyProperty IsGeneratedProperty
            = DependencyProperty.RegisterAttached("IsGenerated", typeof(bool),
                typeof(DockingRegionAdapter), null);

        /// <summary>
        /// ContentPane.Closed 이벤트 핸들러 내에서 영역에 액세스 할 수 있도록 ContentPane이 속한 영역을 추적하는 데 사용됩니다.
        /// </summary>
        private static readonly DependencyProperty RegionProperty
            = DependencyProperty.RegisterAttached("Region", typeof(IRegion),
                typeof(DockingRegionAdapter), null);
        /// <summary>
        /// 생성자
        /// </summary>
        /// <param name="regionBehaviorFactory"></param>
        public DockingRegionAdapter(IRegionBehaviorFactory regionBehaviorFactory)
            : base(regionBehaviorFactory)
        {
        }
        /// <summary>
        /// 리즌과 컨트롤 연결
        /// </summary>
        /// <param name="region"></param>
        /// <param name="regionTarget"></param>
        protected override void Adapt(IRegion region, RadDocking regionTarget)
        {
            regionTarget.PanesSource = region.Views;
        }
        /// <summary>
        /// 비헤이비어 연결
        /// </summary>
        /// <param name="region"></param>
        /// <param name="regionTarget"></param>
        protected override void AttachBehaviors(IRegion region, RadDocking regionTarget)
        {
            base.AttachBehaviors(region, regionTarget);
            if (!region.Behaviors.ContainsKey(DockActivationRegionBehavior.BehaviorKey))
            {
                region.Behaviors.Add(DockActivationRegionBehavior.BehaviorKey,
                    new DockActivationRegionBehavior { HostControl = regionTarget });
            }
        }

        protected override IRegion CreateRegion()
        {
            //한번에 하나만 액티브가 되는 경우에 사용
            return new SingleActiveRegion();
        }
    }
}