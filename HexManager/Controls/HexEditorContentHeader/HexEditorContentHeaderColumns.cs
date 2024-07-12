using HexManager.EventArgs;
using System.IO;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Shapes;

namespace HexManager;

public class HexEditorContentHeaderColumns : Panel, IAddChild
{
    static HexEditorContentHeaderColumns()
    {
        DefaultStyleKeyProperty.OverrideMetadata(typeof(HexEditorContentHeaderColumns), new FrameworkPropertyMetadata(typeof(HexEditorContentHeaderColumns)));
    }

    public HexEditorContentHeaderColumns()
    {
        _ParentHexEditor = new();
        SnapsToDevicePixels = true;
    }

    public HexEditorContentHeaderColumns(HexEditorContent hexEditorContent) : this()
    {
        ParentHexEditorContent = hexEditorContent;

    }

    public void AddChild(object value)
    {
        UIElement? child = value as UIElement;
        if (child != null)
        {
            Children.Add(child);
            return;
        }
    }

    public void AddText(string text)
    {

    }

    private void Initial()
    {
        if (_ParentHexEditor == null) return;
        for (int itemColumn = 0; itemColumn < _ParentHexEditor.NumberOfDataColumns; itemColumn++)
        {
            HexEditorContentHeaderCell cell = new HexEditorContentHeaderCell(this, $"{itemColumn:X2}", itemColumn);
            AddChild(cell);
        }
    }

    protected override void OnRender(DrawingContext dc)
    {
        if (_ParentHexEditor == null) return;
        Rect bounds = new Rect(0, 0, ActualWidth, _ParentHexEditor.HexEditorContentHeaderColumnsHeight);
        Brush brush = _ParentHexEditor.HexEditorContentHeaderColumnsBackground;
        Pen pen = new Pen(Brushes.Gray, 2);
        dc.DrawRoundedRectangle(brush, null, bounds, 0, 0);
        dc.DrawLine(pen, new Point(0, bounds.Height - 1), new Point(ActualWidth, bounds.Height - 1));
    }

    protected override Size MeasureOverride(Size constraint)
    {
        Size stackDesiredSize = new Size();
        UIElementCollection children = Children;
        Size layoutSlotSize = constraint;
        double logicalVisibleSpace, childLogicalSize;
        layoutSlotSize.Width = Double.PositiveInfinity;
        logicalVisibleSpace = constraint.Width;
        for (int i = 0, count = children.Count; i < count; ++i)
        {
            UIElement child = children[i];
            if (child == null) { continue; }
            child.Measure(layoutSlotSize);
            Size childDesiredSize = child.DesiredSize;
            stackDesiredSize.Width += childDesiredSize.Width;
            stackDesiredSize.Height = Math.Max(stackDesiredSize.Height, childDesiredSize.Height);
            childLogicalSize = childDesiredSize.Width;
        }
        return stackDesiredSize;
    }

    protected override Size ArrangeOverride(Size finalSize)
    {
        UIElementCollection children = Children;
        Rect rcChild = new Rect(finalSize);
        double previousChildSize = 0;
        rcChild.X = 0;
        rcChild.Y = 0;
        for (int i = 0, count = children.Count; i < count; ++i)
        {
            UIElement child = children[i];
            if (child == null) { continue; }
            rcChild.X += previousChildSize;
            previousChildSize = child.DesiredSize.Width;
            rcChild.Width = previousChildSize;
            rcChild.Height = Math.Max(finalSize.Height, child.DesiredSize.Height);
            HexEditorContenColumnData hexEditorContenColumnData = new();
            hexEditorContenColumnData.ColumnIndex = i;
            hexEditorContenColumnData.ColumnWidth = rcChild.Width;
            hexEditorContenColumnData.ColumnHeight = rcChild.Height;
            hexEditorContenColumnData.StartPoint = new Point(rcChild.X, rcChild.Y);
            hexEditorContenColumnData.EndPoint = new Point(rcChild.Right, rcChild.Bottom);
            RaiseEvent(new HexEditorContentHeaderCellSizeChangedEventArgs(hexEditorContenColumnData));
            child.Arrange(rcChild);
        }
        return finalSize;
    }

    public HexEditorContent ParentHexEditorContent
    {
        get { return (HexEditorContent)GetValue(ParentHexEditorContentProperty); }
        set { SetValue(ParentHexEditorContentProperty, value); }
    }
    public static readonly DependencyProperty ParentHexEditorContentProperty =
        DependencyProperty.Register("ParentHexEditorContent", typeof(HexEditorContent), typeof(HexEditorContentHeaderColumns), new FrameworkPropertyMetadata(null, OnParenHexEditorContentChanged));
    private static void OnParenHexEditorContentChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
    {
        if (d != null && d is HexEditorContentHeaderColumns)
        {
            HexEditorContentHeaderColumns headerColumns = (HexEditorContentHeaderColumns)d;
            headerColumns._ParentHexEditor = ((HexEditorContent)e.NewValue).ParentHexEditor;
            headerColumns.Initial();
        }
    }

    internal HexEditor _ParentHexEditor;

}