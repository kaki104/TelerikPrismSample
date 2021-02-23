using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using Telerik.Windows.Controls.Docking;

namespace TelerikPrismSample
{
    public class PRISMSaveLoadLayoutHelper : DefaultSaveLoadLayoutHelper
    {
        // Not implemented !
        //protected override DependencyObject ElementLoadingOverride(string serializationTag)
        //{
        //    var element = base.ElementLoadingOverride(serializationTag);
        //    if (serializationTag == "Document" && element == null)
        //    {
        //        element = FileServicesModule.CreateDocument("New Document") as DependencyObject;
        //    }

        //    return element;
        //}
    }
}