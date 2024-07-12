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
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Shapes;

namespace HexManager;

public class HexEditorContentData : Control
{
    static HexEditorContentData()
    {
        
    }

    public HexEditorContentData() : base()
    {
        SnapsToDevicePixels = true;
    }

    protected override void OnRender(DrawingContext drawingContext)
    {
        base.OnRender(drawingContext);
        if (ParentHexEditorContent == null) return;
        CreateRowRectangles(drawingContext);
        CreateVerticalLines(drawingContext);
        CreateDataCells(drawingContext);
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
        }
    }

    private void CreateVerticalLines(DrawingContext drawingContext)
    {
        int countOfColumns = _ParentHexEditor.NumberOfDataColumns;
        HexEditorContenColumnData[] columnsData = _ParentHexEditor.ColumnsData;
        Brush vlBrush = Brushes.LightGray;
        for (int itemVLine = 0; itemVLine < countOfColumns; itemVLine++)
        {
            Pen vlPen = new();
            if (itemVLine == 15)
            {
                // Main Line
                vlBrush = Brushes.Gray;
                vlPen = new Pen(vlBrush, 2.0);
            }
            else if (itemVLine % 2 == 0)
            {
                // One Byte Line
                DashStyle dashValues = new(new DoubleCollection() { 0.5, 2.0 }, 0);
                vlPen = new Pen(vlBrush, 1.0) { DashStyle = dashValues };
            }
            else if (itemVLine > 0 && (itemVLine - 1) % 4 == 0)
            {
                // Two Byte Line
                DashStyle dashValues = new(new DoubleCollection() { 1.5, 3.5 }, 0);
                vlPen = new Pen(vlBrush, 1.0) { DashStyle = dashValues };
            }
            else if (itemVLine > 2 && (itemVLine - 3) % 4 == 0)
            {
                // Four Byte Line
                vlPen = new Pen(vlBrush, 1.0);
            }

            Point start = new(columnsData[itemVLine].EndPoint.X - (vlPen.Thickness / 2), 0);
            Point end = new(columnsData[itemVLine].EndPoint.X - (vlPen.Thickness / 2), ActualHeight);

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
            Rect bounds = new Rect(0, previousRowTop, ActualWidth, _ParentHexEditor.HexEditorContentRowHeight);
            Brush brush = itemRow % 2 == 0 ? Brushes.AliceBlue : Brushes.Azure;
            drawingContext.DrawRoundedRectangle(brush, null, bounds, 0, 0);
            previousRowTop += rowHeight;
        }
    }

    private void CreateDataCells(DrawingContext drawingContext)
    {
        var typeface = new Typeface("Segoe UI");
        var formattedText = new FormattedText("00", CultureInfo.InvariantCulture, FlowDirection.LeftToRight,
                typeface, 12, Brushes.Black, VisualTreeHelper.GetDpi(this).PixelsPerDip);
        Point labelLocation = new Point(0, 0);
        drawingContext.DrawText(formattedText, labelLocation);
    }
}
