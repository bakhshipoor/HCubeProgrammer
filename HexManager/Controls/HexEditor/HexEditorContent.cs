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
        HeaderColumns = [];
    }

    public HexEditor ParentHexEditor
    {
        get { return (HexEditor)GetValue(ParentHexEditorProperty); }
        set { SetValue(ParentHexEditorProperty, value); }
    }
    public static readonly DependencyProperty ParentHexEditorProperty =
        DependencyProperty.Register("ParentHexEditor", typeof(HexEditor), typeof(HexEditorContent), new FrameworkPropertyMetadata(null, OnParentHexEditorChanged));
    private static void OnParentHexEditorChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
    {
        if (d != null && d is HexEditorContent)
        {
            HexEditorContent hexEditorContent = (HexEditorContent)d;
            hexEditorContent.ParentHexEditor.HexEditorContents.Add(hexEditorContent);
        }
    }

    public HexEditorContentData ContentData
    {
        get { return (HexEditorContentData)GetValue(ContentDataProperty); }
        set { SetValue(ContentDataProperty, value); }
    }
    public static readonly DependencyProperty ContentDataProperty =
        DependencyProperty.Register("ContentData", typeof(HexEditorContentData), typeof(HexEditorContent), new PropertyMetadata(null));

    public List<HexEditorContentHeaderColumn> HeaderColumns;
}
