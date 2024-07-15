using HexManager.EventArgs;
using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Input;
using System.Windows.Interop;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Shapes;

namespace HexManager;

public class HexEditorContentData : Panel
{
    static HexEditorContentData()
    {
        
    }

    public HexEditorContentData() : base()
    {
        SnapsToDevicePixels = true;
        //RenderOptions.SetEdgeMode(this, EdgeMode.Aliased);
        //RenderOptions.SetCachingHint(this, CachingHint.Cache);
    }

    protected override void OnRender(DrawingContext drawingContext)
    {
        base.OnRender(drawingContext);
        if (ParentHexEditorContent == null) return;
        CreateRowRectangles(drawingContext);
        CreateVerticalLines(drawingContext);
    }

    protected override Size MeasureOverride(Size availableSize)
    {
        return base.MeasureOverride(availableSize);
    }

    protected override Size ArrangeOverride(Size finalSize)
    {
        if (ParentHexEditorContent == null) { return finalSize; }
        UIElementCollection children = Children;
        int countOfColumns = _ParentHexEditor.NumberOfDataColumns;
        int countOfRows = _ParentHexEditor.NumberOfDataRows;
        int childIndex = 0;
        double offset = _ParentHexEditor.HexEditorContentHeaderSplitterWidth;
        for (int itemRow = 0; itemRow < countOfRows; itemRow++)
        {
            for (int itemColumn = 0; itemColumn < countOfColumns; itemColumn++)
            {
                UIElement child = children[childIndex];
                if (child == null) { continue; }
                Rect rcChild = new Rect();
                ParentHexEditorContent.HeaderColumns[itemColumn].MinWidth = Math.Max(_ParentHexEditor.DataCells[itemRow, itemColumn].CalculateWidth() + 24, ParentHexEditorContent.HeaderColumns[itemColumn].MinWidth);
                rcChild.Width = ParentHexEditorContent.HeaderColumns[itemColumn].Width - offset;
                rcChild.Height = _ParentHexEditor.HexEditorContentRowHeight;
                rcChild.X = ParentHexEditorContent.HeaderColumns[itemColumn].StartPoint.X;
                rcChild.Y = itemRow * rcChild.Height;
                child.Arrange(rcChild);

                childIndex++;
            }
        }
        return finalSize;
    }

    internal HexEditor _ParentHexEditor=new();

    public HexEditorContent ParentHexEditorContent
    {
        get { return (HexEditorContent)GetValue(ParentHexEditorContentProperty); }
        set { SetValue(ParentHexEditorContentProperty, value); }
    }
    public static readonly DependencyProperty ParentHexEditorContentProperty =
        DependencyProperty.Register("ParentHexEditorContent", typeof(HexEditorContent), typeof(HexEditorContentData), new FrameworkPropertyMetadata(null, OnParentHexEditorContentChanged));
    private static void OnParentHexEditorContentChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
    {
        if (d!=null && d is HexEditorContentData)
        {
            HexEditorContentData hexEditorContentData = (HexEditorContentData)d;
            hexEditorContentData._ParentHexEditor = ((HexEditorContent)e.NewValue).ParentHexEditor;
            hexEditorContentData.ParentHexEditorContent.ContentData = hexEditorContentData;
        }
    }

    private void CreateVerticalLines(DrawingContext drawingContext)
    {
        int countOfColumns = _ParentHexEditor.NumberOfDataColumns;
        int countOfRows = _ParentHexEditor.NumberOfDataRows;
        
        Brush vlBrush = Brushes.LightGray;
        double lineThickness = 1.0;
        for (int itemVLine = 0; itemVLine < countOfColumns; itemVLine++)
        {
            Pen vlPen = new();
            double offset = _ParentHexEditor.HexEditorContentHeaderSplitterWidth/2;
            // Main Line
            if (itemVLine == 15)
            {
                vlBrush = Brushes.Gray;
                vlPen = new Pen(vlBrush, 2.0);
            }
            // One Byte Line
            else if (itemVLine % 2 == 0)
            {
                DashStyle dashValues = new(new DoubleCollection() { 0.5, 2.0 }, 0);
                vlPen = new Pen(vlBrush, lineThickness) { DashStyle = dashValues };

            }
            // Two Byte Line
            else if (itemVLine > 0 && (itemVLine - 1) % 4 == 0)
            {
                DashStyle dashValues = new(new DoubleCollection() { 1.5, 3.5 }, 0);
                vlPen = new Pen(vlBrush, lineThickness) { DashStyle = dashValues };
            }
            // Four Byte Line
            else if (itemVLine > 2 && (itemVLine - 3) % 4 == 0)
            {
                //DashStyle dashValues = new(new DoubleCollection() { 2.5, 5 }, 0);
                vlPen = new Pen(vlBrush, lineThickness) /*{ DashStyle = dashValues }*/;
            }
            Point start = new(ParentHexEditorContent.HeaderColumns[itemVLine].EndPoint.X-2, 0);
            Point end = new(ParentHexEditorContent.HeaderColumns[itemVLine].EndPoint.X-2, ActualHeight);

            drawingContext.DrawLine(vlPen, start, end);
        }
    }

    private void CreateRowRectangles(DrawingContext drawingContext)
    {
        if (ActualHeight <= 0) { return; }
        int rowCounts = (int)(ActualHeight / _ParentHexEditor._DefaultHeaderTypeHeight);
        double leftRowHeight = ActualHeight % _ParentHexEditor._DefaultHeaderColumnsHeight;
        double rowHeight = _ParentHexEditor._DefaultHeaderTypeHeight + (leftRowHeight / rowCounts);
        _ParentHexEditor.NumberOfDataRows = rowCounts;
        _ParentHexEditor.HexEditorContentRowHeight = rowHeight;
        int countOfRows = rowCounts;
        double previousRowTop = 0.0;
        for (int itemRow = 0; itemRow < countOfRows; itemRow++)
        {
            Rect bounds = new Rect(0 - 2, previousRowTop, ActualWidth - 1, _ParentHexEditor.HexEditorContentRowHeight);
            Brush brush = itemRow % 2 == 0 ? Brushes.AliceBlue : Brushes.Azure;
            //Brush brush = itemRow % 2 == 0 ? Brushes.Yellow : Brushes.LightGreen;
            drawingContext.DrawRoundedRectangle(brush, null, bounds, 0, 0);
            previousRowTop += rowHeight;
        }
    }

}
