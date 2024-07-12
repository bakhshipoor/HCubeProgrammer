using System.Globalization;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace HexManager;

public class HeaderCell : Decorator
{

    static HeaderCell()
    {
        
    }

    public HeaderCell(HeaderColumns headerColumns, string text) 
    {
        ParentHeaderColumns = headerColumns;
        _ParentHexEditor = headerColumns._ParentHexEditor;
        _ParentHexEditorContent = headerColumns.ParentHexEditorContent;
        Text = text;
        Width = _ParentHexEditorContent.HexEditorContentColumnsWidth;
        Height = _ParentHexEditor.HexEditorContentHeaderColumnsHeight;

        HeaderCellSplitter child = new HeaderCellSplitter(this);
        child.Width = _ParentHexEditor.HexEditorContentHeaderSplitterWidth;
        child.Height = Height;
        child.BorderThickness = new Thickness(_ParentHexEditor.HexEditorContentHeaderSplitterWidth);
        child.BorderBrush = _ParentHexEditor.HexEditorContentHeaderSplitterBackground;
        Child = child;
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
        DependencyProperty.Register("Text", typeof(string), typeof(HeaderCell), new PropertyMetadata(string.Empty));

    public HeaderColumns ParentHeaderColumns
    {
        get { return (HeaderColumns)GetValue(ParentHeaderColumnsProperty); }
        set { SetValue(ParentHeaderColumnsProperty, value); }
    }
    public static readonly DependencyProperty ParentHeaderColumnsProperty =
        DependencyProperty.Register("ParentHeaderColumns", typeof(HeaderColumns), typeof(HeaderCell), new FrameworkPropertyMetadata(null, OnParentHeaderColumnsChanged));
    private static void OnParentHeaderColumnsChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
    {
        if (d!=null && d is HeaderCell)
        {
            HeaderCell headerCell = (HeaderCell)d;
            headerCell._ParentHexEditor = ((HeaderColumns)e.NewValue)._ParentHexEditor;
            headerCell._ParentHexEditorContent = ((HeaderColumns)e.NewValue).ParentHexEditorContent;
        }
    }

    internal HexEditor _ParentHexEditor;
    internal HexEditorContent _ParentHexEditorContent;
}
