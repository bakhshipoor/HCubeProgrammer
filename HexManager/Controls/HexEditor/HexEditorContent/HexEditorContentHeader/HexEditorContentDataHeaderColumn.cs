using HexManager.EventArgs;
using System.ComponentModel;
using System.Globalization;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Media;

namespace HexManager;

public class HexEditorContentDataHeaderColumn : Decorator
{

    static HexEditorContentDataHeaderColumn()
    {
        
    }

    public HexEditorContentDataHeaderColumn()
    {
        SnapsToDevicePixels = true;
        ParentHexEditor = new();
        ParentHexEditorContent = new();
        HexEditorContentDataHeaderColumnSplitter child = new HexEditorContentDataHeaderColumnSplitter(this);
        child.Width = ParentHexEditor.SplitterWidth;
        child.Height = Height;
        child.RectWidth = ParentHexEditor.SplitterLineWidth;
        child.Background = ParentHexEditor.HeaderLinesColor;
        Child = child;
    }

    public HexEditorContentDataHeaderColumn(HexEditorContentDataHeaderColumns headerColumns, string text, int columnIndex) : this()
    {
        ParentHeaderColumns = headerColumns;
        ParentHexEditor = headerColumns._ParentHexEditor;
        ParentHexEditorContent = headerColumns.ParentHexEditorContent;
        Text = text;
        ColumnIndex = columnIndex;
        
        
    }

    protected override void OnRender(DrawingContext drawingContext)
    {
        Rect bounds = new Rect(0, 0, ActualWidth, ActualHeight);
        Brush brush = ParentHexEditor.HeadersBackground;
        drawingContext.DrawRoundedRectangle(brush, null, bounds, 0, 0);

        var typeface = new Typeface("Segoe UI");
        var formattedText = new FormattedText(Text, CultureInfo.InvariantCulture, FlowDirection.LeftToRight,
                typeface, 12, Brushes.Black, VisualTreeHelper.GetDpi(this).PixelsPerDip);

        if (formattedText.Width < (ActualWidth - ParentHexEditor.SplitterWidth))
        {
            double labelX = (ActualWidth - formattedText.Width - ParentHexEditor.SplitterWidth) / 2;
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
            if (MinWidth == 0 )
            {
                var typeface = new Typeface("Segoe UI");
                var formattedText = new FormattedText(Text, CultureInfo.InvariantCulture, FlowDirection.LeftToRight,
                        typeface, 12, Brushes.Black, VisualTreeHelper.GetDpi(this).PixelsPerDip);
                MinWidth = formattedText.Width + 22;
            }
            availableSize.Width = MinWidth + desired.Width;
            Width = availableSize.Width;
            
        }
        return availableSize;
    }

    protected override Size ArrangeOverride(Size finalSize)
    {
        Rect childArrangeRect = new Rect();
        childArrangeRect.Width = ParentHexEditor.SplitterWidth;
        childArrangeRect.Height = ParentHexEditor.DataHeaderHeight;
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
        DependencyProperty.Register("Text", typeof(string), typeof(HexEditorContentDataHeaderColumn), new PropertyMetadata(string.Empty));

    public int ColumnIndex
    {
        get { return (int)GetValue(ColumnIndexProperty); }
        set { SetValue(ColumnIndexProperty, value); }
    }
    public static readonly DependencyProperty ColumnIndexProperty =
        DependencyProperty.Register("ColumnIndex", typeof(int), typeof(HexEditorContentDataHeaderColumn), new PropertyMetadata(0));

    public HexEditorContentDataHeaderColumns ParentHeaderColumns
    {
        get { return (HexEditorContentDataHeaderColumns)GetValue(ParentHeaderColumnsProperty); }
        set { SetValue(ParentHeaderColumnsProperty, value); }
    }
    public static readonly DependencyProperty ParentHeaderColumnsProperty =
        DependencyProperty.Register("ParentHeaderColumns", typeof(HexEditorContentDataHeaderColumns), typeof(HexEditorContentDataHeaderColumn), new FrameworkPropertyMetadata(null, OnParentHeaderColumnsChanged));
    private static void OnParentHeaderColumnsChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
    {
        if (d!=null && d is HexEditorContentDataHeaderColumn)
        {
            HexEditorContentDataHeaderColumn headerCell = (HexEditorContentDataHeaderColumn)d;
            headerCell.ParentHexEditor = ((HexEditorContentDataHeaderColumns)e.NewValue)._ParentHexEditor;
            headerCell.ParentHexEditorContent = ((HexEditorContentDataHeaderColumns)e.NewValue).ParentHexEditorContent;
        }
    }

    public static readonly RoutedEvent HeaderCellSizeChangedEvent = EventManager.RegisterRoutedEvent("HeaderCellSizeChanged", RoutingStrategy.Bubble, typeof(HeaderCellSizeEventHandler), typeof(HexEditorContentDataHeaderColumn));
    [Category("Behavior")]
    public event HeaderCellSizeEventHandler HeaderCellSizeChanged 
    { 
        add { AddHandler(HeaderCellSizeChangedEvent, value); } 
        remove { RemoveHandler(HeaderCellSizeChangedEvent, value); } 
    }

    public Point StartPoint
    {
        get { return (Point)GetValue(StartPointProperty); }
        set { SetValue(StartPointProperty, value); }
    }
    public static readonly DependencyProperty StartPointProperty =
        DependencyProperty.Register("StartPoint", typeof(Point), typeof(HexEditorContentDataHeaderColumn), new PropertyMetadata(new Point(0,0)));

    public Point EndPoint
    {
        get { return (Point)GetValue(EndPointProperty); }
        set { SetValue(EndPointProperty, value); }
    }
    public static readonly DependencyProperty EndPointProperty =
        DependencyProperty.Register("EndPoint", typeof(Point), typeof(HexEditorContentDataHeaderColumn), new PropertyMetadata(new Point(0,0)));

    public HexEditor ParentHexEditor { get; set; }
    public HexEditorContent ParentHexEditorContent { get; set; }
}
