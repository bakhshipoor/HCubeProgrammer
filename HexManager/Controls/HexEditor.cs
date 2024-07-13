﻿using HexManager.EventArgs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Media;

namespace HexManager;


[TemplatePart(Name = ElementScrollViewerScvHexEditor, Type = typeof(ScrollBar))]
public class HexEditor : Control
{
    private const string ElementScrollViewerScvHexEditor = "PART_ScrollViewer";
    
    public ScrollViewer ScvHexEditor { get; set; }
    
    static HexEditor()
    {
        EventManager.RegisterClassHandler(typeof(HexEditor), HexEditorContentHeaderCell.HeaderCellSizeChangedEvent, new HeaderCellSizeEventHandler(OnHeaderCellSizeChanged));
        DefaultStyleKeyProperty.OverrideMetadata(typeof(HexEditor), new FrameworkPropertyMetadata(typeof(HexEditor)));
    }

    public HexEditor()
    {
        ScvHexEditor = new();
        
    }

    public override void OnApplyTemplate()
    {
        base.OnApplyTemplate();
        ScvHexEditor = (ScrollViewer)GetTemplateChild(ElementScrollViewerScvHexEditor);
    }

    protected override void OnRender(DrawingContext drawingContext)
    {
        base.OnRender(drawingContext);
    }

    internal double _DefaultHeaderTypeHeight = 30.0;
    internal double _DefaultHeaderColumnsHeight = 30.0;
    internal double _DefaultDataRowHeight = 30.0;
    internal int _DeaultDataColumnsCount = 16;
    internal double _VerticalScrollBarWidth = 17.0;
    internal double _HorizontalScrollBarHeight = 17.0;

    public double HexEditorContentHeaderTypeHeight
    {
        get { return (double)GetValue(HexEditorContentHeaderTypeHeightProperty); }
        set { SetValue(HexEditorContentHeaderTypeHeightProperty, value); }
    }
    public static readonly DependencyProperty HexEditorContentHeaderTypeHeightProperty =
        DependencyProperty.Register("HexEditorContentHeaderTypeHeight", typeof(double), typeof(HexEditor), new FrameworkPropertyMetadata(30.0));

    public double HexEditorContentHeaderColumnsHeight
    {
        get { return (double)GetValue(HexEditorContentHeaderColumnsHeightProperty); }
        set { SetValue(HexEditorContentHeaderColumnsHeightProperty, value); }
    }
    public static readonly DependencyProperty HexEditorContentHeaderColumnsHeightProperty =
        DependencyProperty.Register("HexEditorContentHeaderColumnsHeight", typeof(double), typeof(HexEditor), new FrameworkPropertyMetadata(30.0));

    public Brush HexEditorContentHeaderColumnsBackground
    {
        get { return (Brush)GetValue(HexEditorContentHeaderColumnsBackgroundProperty); }
        set { SetValue(HexEditorContentHeaderColumnsBackgroundProperty, value); }
    }
    public static readonly DependencyProperty HexEditorContentHeaderColumnsBackgroundProperty =
        DependencyProperty.Register("HexEditorContentHeaderColumnsBackground", typeof(Brush), typeof(HexEditor), new FrameworkPropertyMetadata(Brushes.Transparent));

    public double HexEditorContentRowHeight
    {
        get { return (double)GetValue(HexEditorContentRowHeightProperty); }
        set { SetValue(HexEditorContentRowHeightProperty, value); }
    }
    public static readonly DependencyProperty HexEditorContentRowHeightProperty =
        DependencyProperty.Register("HexEditorContentRowHeight", typeof(double), typeof(HexEditor), new FrameworkPropertyMetadata(30.0));

    public double HexEditorContentHeaderSplitterWidth
    {
        get { return (double)GetValue(HexEditorContentHeaderSplitterWidthProperty); }
        set { SetValue(HexEditorContentHeaderSplitterWidthProperty, value); }
    }
    public static readonly DependencyProperty HexEditorContentHeaderSplitterWidthProperty =
        DependencyProperty.Register("HexEditorContentHeaderSplitterWidth", typeof(double), typeof(HexEditor), new FrameworkPropertyMetadata(2.0));

    public Brush HexEditorContentHeaderSplitterBackground
    {
        get { return (Brush)GetValue(HexEditorContentHeaderSplitterBackgroundProperty); }
        set { SetValue(HexEditorContentHeaderSplitterBackgroundProperty, value); }
    }
    public static readonly DependencyProperty HexEditorContentHeaderSplitterBackgroundProperty =
        DependencyProperty.Register("HexEditorContentHeaderSplitterBackground", typeof(Brush), typeof(HexEditor), new FrameworkPropertyMetadata(Brushes.Gray));

    public int NumberOfDataColumns
    {
        get { return (int)GetValue(NumberOfDataColumnsProperty); }
        set { SetValue(NumberOfDataColumnsProperty, value); }
    }
    public static readonly DependencyProperty NumberOfDataColumnsProperty =
        DependencyProperty.Register("NumberOfDataColumns", typeof(int), typeof(HexEditor), new FrameworkPropertyMetadata(16));

    public int NumberOfDataRows
    {
        get { return (int)GetValue(NumberOfDataRowsProperty); }
        set { SetValue(NumberOfDataRowsProperty, value); }
    }
    public static readonly DependencyProperty NumberOfDataRowsProperty =
        DependencyProperty.Register("NumberOfDataRows", typeof(int), typeof(HexEditor), new FrameworkPropertyMetadata(0,OnDataRowsChanged));

    private static void OnDataRowsChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
    {
        if (d != null && d is HexEditor)
        {
            HexEditor hexEditor = (HexEditor)d;
            hexEditor.CellsData = new HexEditorContenCellData[(int)e.NewValue, hexEditor.NumberOfDataColumns];
            hexEditor.DataCell = new HexEditorContentDataCell[(int)e.NewValue, hexEditor.NumberOfDataColumns];
            foreach (HexEditorContent itemHexContent in hexEditor.HexEditorContents)
            {
                itemHexContent.ContentData.Children.Clear();
            }
            for (int itemRow=0; itemRow < (int)e.NewValue; itemRow++)
            {
                for (int itemColumn=0;itemColumn< hexEditor.NumberOfDataColumns;itemColumn++)
                {
                    hexEditor.CellsData[itemRow, itemColumn] = new HexEditorContenCellData();
                    hexEditor.DataCell[itemRow, itemColumn] = new HexEditorContentDataCell();
                    foreach (HexEditorContent itemHexContent in hexEditor.HexEditorContents)
                    {
                        itemHexContent.ContentData.Children.Add(hexEditor.DataCell[itemRow, itemColumn]);
                    }
                }
            }
        }
    }

    public double HexEditorContentColumnsMinWidth
    {
        get { return (double)GetValue(HexEditorContentColumnsMinWidthProperty); }
        set { SetValue(HexEditorContentColumnsMinWidthProperty, value); }
    }
    public static readonly DependencyProperty HexEditorContentColumnsMinWidthProperty =
        DependencyProperty.Register("HexEditorContentColumnsMinWidth", typeof(double), typeof(HexEditor), new PropertyMetadata(30.0));

    public HexEditorContenColumnData[] ColumnsData = new HexEditorContenColumnData[16];

    private static void OnHeaderCellSizeChanged(object sender, HexEditorContentHeaderCellSizeChangedEventArgs e)
    {
        if (sender != null && sender is HexEditor)
        {
            HexEditor hexEditor = (HexEditor)sender;
            hexEditor.ColumnsData[e.ColumnData.ColumnIndex] = new();
            hexEditor.ColumnsData[e.ColumnData.ColumnIndex] = e.ColumnData;
        }
    }

    public HexEditorContenCellData[,] CellsData = new HexEditorContenCellData[1, 16];
    public HexEditorContentDataCell[,] DataCell = new HexEditorContentDataCell[1, 16];
    public List<HexEditorContent> HexEditorContents = [];
}
