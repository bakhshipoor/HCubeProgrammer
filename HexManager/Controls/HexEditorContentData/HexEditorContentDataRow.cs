using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Markup;
using System.Windows.Media;

namespace HexManager;

public class HexEditorContentDataRow : FrameworkElement, IAddChild
{
    static HexEditorContentDataRow()
    {
        
    }

    public HexEditorContentDataRow() : base()
    {
        
    }

    protected override void OnRender(DrawingContext drawingContext)
    {
        base.OnRender(drawingContext);
        Rect bounds = new Rect(0, 0, 400, 30);
        Brush brush = Brushes.AliceBlue;
        drawingContext.DrawRoundedRectangle(brush, null, bounds, 0, 0);
    }

    protected override Size MeasureOverride(Size availableSize)
    {
        return base.MeasureOverride(availableSize);
    }

    protected override Size ArrangeOverride(Size finalSize)
    {
        return base.ArrangeOverride(finalSize);
    }

    public void AddChild(object value)
    {
        
    }

    public void AddText(string text)
    {
        
    }

    internal HexEditor _ParentHexEditor=new();
    internal HexEditorContent _ParentHexEditorContent=new();

    public HexEditorContentData ParenHexEditorContentData
    {
        get { return (HexEditorContentData)GetValue(ParenHexEditorContentDataProperty); }
        set { SetValue(ParenHexEditorContentDataProperty, value); }
    }
    public static readonly DependencyProperty ParenHexEditorContentDataProperty =
        DependencyProperty.Register("ParenHexEditorContentData", typeof(HexEditorContentData), typeof(HexEditorContentDataRow), new FrameworkPropertyMetadata(null, OnParenHexEditorContentDataChanged));
    private static void OnParenHexEditorContentDataChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
    {
        if (d!=null && d is HexEditorContentDataRow)
        {
            HexEditorContentDataRow hexEditorContentDataRow = (HexEditorContentDataRow)d;
            hexEditorContentDataRow._ParentHexEditor = ((HexEditorContentData)e.NewValue)._ParentHexEditor;
            hexEditorContentDataRow._ParentHexEditorContent = ((HexEditorContentData)e.NewValue).ParentHexEditorContent;
        }
    }



    public int RowIndex
    {
        get { return (int)GetValue(RowIndexProperty); }
        set { SetValue(RowIndexProperty, value); }
    }
    public static readonly DependencyProperty RowIndexProperty =
        DependencyProperty.Register("RowIndex", typeof(int), typeof(HexEditorContentDataRow), new PropertyMetadata(0));


}
