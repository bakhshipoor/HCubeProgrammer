﻿using HexManager.EventArgs;
using System.ComponentModel;
using System.Globalization;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Media;

namespace HexManager;

public class HexEditorContentHeaderCell : Decorator
{

    static HexEditorContentHeaderCell()
    {
        
    }

    public HexEditorContentHeaderCell(HexEditorContentHeaderColumns headerColumns, string text, int columnIndex) 
    {
        ParentHeaderColumns = headerColumns;
        _ParentHexEditor = headerColumns._ParentHexEditor;
        _ParentHexEditorContent = headerColumns.ParentHexEditorContent;
        Text = text;
        ColumnIndex = columnIndex;
        MinWidth = _ParentHexEditor.HexEditorContentColumnsMinWidth;
        //Width = MinWidth;
        Height = _ParentHexEditor.HexEditorContentHeaderColumnsHeight;

        HeaderCellSplitter child = new HeaderCellSplitter(this);
        child.Width = _ParentHexEditor.HexEditorContentHeaderSplitterWidth;
        child.Height = Height;
        child.RectWidth = _ParentHexEditor.HexEditorContentHeaderSplitterRectWidth;
        child.Background = _ParentHexEditor.HexEditorContentHeaderSplitterBackground;
        Child = child;
        SnapsToDevicePixels = true;
    }

    protected override void OnRender(DrawingContext drawingContext)
    {
        Rect bounds = new Rect(0, 0, ActualWidth, ActualHeight);
        Brush brush = _ParentHexEditor.HexEditorContentHeaderColumnsBackground;
        drawingContext.DrawRoundedRectangle(brush, null, bounds, 0, 0);

        var typeface = new Typeface("Segoe UI");
        var formattedText = new FormattedText(Text, CultureInfo.InvariantCulture, FlowDirection.LeftToRight,
                typeface, 12, Brushes.Black, VisualTreeHelper.GetDpi(this).PixelsPerDip);
        if (formattedText.Width < (ActualWidth - _ParentHexEditor.HexEditorContentHeaderSplitterWidth))
        {
            double labelX = (ActualWidth - formattedText.Width - _ParentHexEditor.HexEditorContentHeaderSplitterWidth) / 2;
            if (labelX < 0) { labelX = 0; }
            double labelY = (ActualHeight - formattedText.Height) / 2;
            if (labelY < 0) { labelY = 0; }
            Point labelLocation = new Point(labelX, labelY);
            drawingContext.DrawText(formattedText, labelLocation);
        }
    }

    protected override Size MeasureOverride(Size availableSize)
    {
        Size desired;
        UIElement child = Child;
        if (child != null)
        {
            Size childConstraint = new Size();
            childConstraint.Width = availableSize.Width;
            childConstraint.Height = availableSize.Height;
            child.Measure(childConstraint);
            desired = child.DesiredSize;
        }
        if (availableSize.Width == double.PositiveInfinity)
        {
            availableSize.Width = MinWidth + desired.Width;
            Width = availableSize.Width;
        }
        return availableSize;
    }

    protected override Size ArrangeOverride(Size finalSize)
    {
        Rect childArrangeRect = new Rect();
        childArrangeRect.Width = _ParentHexEditor.HexEditorContentHeaderSplitterWidth;
        childArrangeRect.Height = _ParentHexEditor.HexEditorContentHeaderColumnsHeight;
        childArrangeRect.X = (finalSize.Width - childArrangeRect.Width);
        childArrangeRect.Y = 0;
        UIElement child = Child;
        if (child != null)
        {
            child.Arrange(childArrangeRect);
        }
        return finalSize;
    }

    public string Text
    {
        get { return (string)GetValue(TextProperty); }
        set { SetValue(TextProperty, value); }
    }
    public static readonly DependencyProperty TextProperty =
        DependencyProperty.Register("Text", typeof(string), typeof(HexEditorContentHeaderCell), new PropertyMetadata(string.Empty));

    public int ColumnIndex
    {
        get { return (int)GetValue(ColumnIndexProperty); }
        set { SetValue(ColumnIndexProperty, value); }
    }
    public static readonly DependencyProperty ColumnIndexProperty =
        DependencyProperty.Register("ColumnIndex", typeof(int), typeof(HexEditorContentHeaderCell), new PropertyMetadata(0));

    public HexEditorContentHeaderColumns ParentHeaderColumns
    {
        get { return (HexEditorContentHeaderColumns)GetValue(ParentHeaderColumnsProperty); }
        set { SetValue(ParentHeaderColumnsProperty, value); }
    }
    public static readonly DependencyProperty ParentHeaderColumnsProperty =
        DependencyProperty.Register("ParentHeaderColumns", typeof(HexEditorContentHeaderColumns), typeof(HexEditorContentHeaderCell), new FrameworkPropertyMetadata(null, OnParentHeaderColumnsChanged));
    private static void OnParentHeaderColumnsChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
    {
        if (d!=null && d is HexEditorContentHeaderCell)
        {
            HexEditorContentHeaderCell headerCell = (HexEditorContentHeaderCell)d;
            headerCell._ParentHexEditor = ((HexEditorContentHeaderColumns)e.NewValue)._ParentHexEditor;
            headerCell._ParentHexEditorContent = ((HexEditorContentHeaderColumns)e.NewValue).ParentHexEditorContent;
        }
    }

    public static readonly RoutedEvent HeaderCellSizeChangedEvent = EventManager.RegisterRoutedEvent("HeaderCellSizeChanged", RoutingStrategy.Bubble, typeof(HeaderCellSizeEventHandler), typeof(HexEditorContentHeaderCell));
    [Category("Behavior")]
    public event HeaderCellSizeEventHandler HeaderCellSizeChanged 
    { 
        add { AddHandler(HeaderCellSizeChangedEvent, value); } 
        remove { RemoveHandler(HeaderCellSizeChangedEvent, value); } 
    }

    internal HexEditor _ParentHexEditor;
    internal HexEditorContent _ParentHexEditorContent;
}
