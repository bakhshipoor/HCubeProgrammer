using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace HexManager;

[StyleTypedProperty(Property = "ItemContainerStyle", StyleTargetType = typeof(HexViewerItem))]
public class HexViewer : ItemsControl
{
    static HexViewer()
    {
        DefaultStyleKeyProperty.OverrideMetadata(typeof(HexViewer), new FrameworkPropertyMetadata(typeof(HexViewer)));
    }
}
