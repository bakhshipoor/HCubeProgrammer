using HexManager.EventArgs;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;

namespace HexManager;

public class HexEditorContent : Control
{
    static HexEditorContent()
    {
        
        DefaultStyleKeyProperty.OverrideMetadata(typeof(HexEditorContent), new FrameworkPropertyMetadata(typeof(HexEditorContent)));
    }

    public HexEditorContent()
    {
        SnapsToDevicePixels = true;
    }

    public HexEditor ParentHexEditor
    {
        get { return (HexEditor)GetValue(ParentHexEditorProperty); }
        set { SetValue(ParentHexEditorProperty, value); }
    }
    public static readonly DependencyProperty ParentHexEditorProperty =
        DependencyProperty.Register("ParentHexEditor", typeof(HexEditor), typeof(HexEditorContent), new PropertyMetadata(null));

    
}
