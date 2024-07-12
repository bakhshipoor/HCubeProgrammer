using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Markup;
using System.Windows.Media;

namespace HexManager;

public class HeaderColumns : Panel, IAddChild
{
    static HeaderColumns()
    {
        DefaultStyleKeyProperty.OverrideMetadata(typeof(HeaderColumns), new FrameworkPropertyMetadata(typeof(HeaderColumns)));
    }

    public HeaderColumns()
    {
        _ParentHexEditor = new();
    }

    public HeaderColumns(HexEditorContent hexEditorContent) : this()
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
        for (int i = 0; i < _ParentHexEditor.NumberOfDataColumns; i++)
        {
            HeaderCell cell = new HeaderCell(this, $"{i:X2}");
            AddChild(cell);
        }
    }

    protected override void OnRender(DrawingContext dc)
    {
        if (_ParentHexEditor == null) return;
        Rect bounds = new Rect(0, 0, ActualWidth, _ParentHexEditor.HexEditorContentHeaderColumnsHeight);
        Brush brush = _ParentHexEditor.HexEditorContentHeaderColumnsBackground;
        dc.DrawRoundedRectangle(brush, null, bounds, 0, 0);
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
        DependencyProperty.Register("ParentHexEditorContent", typeof(HexEditorContent), typeof(HeaderColumns), new FrameworkPropertyMetadata(null, OnParenHexEditorContentChanged));
    private static void OnParenHexEditorContentChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
    {
        if (d != null && d is HeaderColumns)
        {
            HeaderColumns headerColumns = (HeaderColumns)d;
            headerColumns._ParentHexEditor = ((HexEditorContent)e.NewValue).ParentHexEditor;
            headerColumns.Initial();
        }
    }

    internal HexEditor _ParentHexEditor;

}