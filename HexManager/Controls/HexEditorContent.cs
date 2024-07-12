using System.Windows;
using System.Windows.Controls;

namespace HexManager;

public class HexEditorContent : Control
{
    static HexEditorContent()
    {
        DefaultStyleKeyProperty.OverrideMetadata(typeof(HexEditorContent), new FrameworkPropertyMetadata(typeof(HexEditorContent)));
    }

    public HexEditorContent()
    {
        
    }

    public HexEditor ParentHexEditor
    {
        get { return (HexEditor)GetValue(ParentHexEditorProperty); }
        set { SetValue(ParentHexEditorProperty, value); }
    }
    public static readonly DependencyProperty ParentHexEditorProperty =
        DependencyProperty.Register("ParentHexEditor", typeof(HexEditor), typeof(HexEditorContent), new PropertyMetadata(null));

    public double HexEditorContentColumnsWidth
    {
        get { return (double)GetValue(HexEditorContentColumnsWidthProperty); }
        set { SetValue(HexEditorContentColumnsWidthProperty, value); }
    }
    public static readonly DependencyProperty HexEditorContentColumnsWidthProperty =
        DependencyProperty.Register("HexEditorContentColumnsWidth", typeof(double), typeof(HexEditorContent), new PropertyMetadata(30.0));



}
