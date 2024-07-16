using HexManager.EventArgs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Input;
using System.Windows.Media;

namespace HexManager;


[TemplatePart(Name = ElementScrollViewerScvHexEditor, Type = typeof(ScrollBar))]
[TemplatePart(Name = ElementStackPanelContents, Type = typeof(StackPanel))]
public class HexEditor : Control
{
    private const string ElementScrollViewerScvHexEditor = "PART_ScrollViewer";
    private const string ElementStackPanelContents = "PART_Contents";

    public ScrollViewer ScvHexEditor { get; set; }
    public StackPanel Contents { get; set; }

    static HexEditor()
    {
        
        DefaultStyleKeyProperty.OverrideMetadata(typeof(HexEditor), new FrameworkPropertyMetadata(typeof(HexEditor)));
    }

    public HexEditor()
    {
        HexEditorContents = [];
        ScvHexEditor = new();
        Contents = new();

        Loaded -= HexEditor_Loaded;
        Loaded += HexEditor_Loaded;
    }

    private void HexEditor_Loaded(object sender, RoutedEventArgs e)
    {
        if (sender != null && sender is HexEditor && _TemplateLoaded)
        {
            HexEditorContents.Clear();
            Contents.Children.Clear();
            //for (int itemContent = 0; itemContent < NumberOfContents; itemContent++)
            //{
            HexEditorContent hexEditorContent = new();
            hexEditorContent.ParentHexEditor = this;
            hexEditorContent.TypeHeadearVisibility = true;
            hexEditorContent.DataHeaderVisibility = false;
            HexEditorContents.Add(hexEditorContent);
            Contents.Children.Add(hexEditorContent);

            hexEditorContent = new();
            hexEditorContent.ParentHexEditor = this;
            hexEditorContent.TypeHeadearVisibility = true;
            hexEditorContent.DataHeaderVisibility = false;
            HexEditorContents.Add(hexEditorContent);
            Contents.Children.Add(hexEditorContent);
            //}
            _IsLoaded = true;
        }
    }

    public override void OnApplyTemplate()
    {
        base.OnApplyTemplate();
        _TemplateLoaded = false;
        ScvHexEditor = (ScrollViewer)GetTemplateChild(ElementScrollViewerScvHexEditor);
        Contents = (StackPanel)GetTemplateChild(ElementStackPanelContents);
        if (ScvHexEditor != null && Contents != null)
        {
            _TemplateLoaded = true;
        }
    }

    private bool _TemplateLoaded;
    private bool _IsLoaded;
    internal double _DefaultHeaderTypeHeight = 30.0;
    internal double _DefaultHeaderColumnsHeight = 30.0;
    internal double _DefaultDataRowHeight = 30.0;

    #region Contents

    public List<HexEditorContent> HexEditorContents { get; set; }

    public int NumberOfContents
    {
        get { return (int)GetValue(NumberOfContentsProperty); }
        set { SetValue(NumberOfContentsProperty, value); }
    }
    public static readonly DependencyProperty NumberOfContentsProperty =
        DependencyProperty.Register("NumberOfContents", typeof(int), typeof(HexEditor), new PropertyMetadata(2));



    #endregion Contents

    #region Content Header

    public int NumberOfColumns
    {
        get { return (int)GetValue(NumberOfColumnsProperty); }
        set { SetValue(NumberOfColumnsProperty, value); }
    }
    public static readonly DependencyProperty NumberOfColumnsProperty =
        DependencyProperty.Register("NumberOfColumns", typeof(int), typeof(HexEditor), new FrameworkPropertyMetadata(16));

    public double TypeHeaderHeight
    {
        get { return (double)GetValue(TypeHeaderHeightProperty); }
        set { SetValue(TypeHeaderHeightProperty, value); }
    }
    public static readonly DependencyProperty TypeHeaderHeightProperty =
        DependencyProperty.Register("TypeHeaderHeight", typeof(double), typeof(HexEditor), new FrameworkPropertyMetadata(30.0));

    public double DataHeaderHeight
    {
        get { return (double)GetValue(DataHeaderHeightProperty); }
        set { SetValue(DataHeaderHeightProperty, value); }
    }
    public static readonly DependencyProperty DataHeaderHeightProperty =
        DependencyProperty.Register("DataHeaderHeight", typeof(double), typeof(HexEditor), new FrameworkPropertyMetadata(30.0));

    public Brush HeadersBackground
    {
        get { return (Brush)GetValue(HeadersBackgroundProperty); }
        set { SetValue(HeadersBackgroundProperty, value); }
    }
    public static readonly DependencyProperty HeadersBackgroundProperty =
        DependencyProperty.Register("HeadersBackground", typeof(Brush), typeof(HexEditor), new FrameworkPropertyMetadata(Brushes.Transparent));

    public double SplitterWidth
    {
        get { return (double)GetValue(SplitterWidthProperty); }
        set { SetValue(SplitterWidthProperty, value); }
    }
    public static readonly DependencyProperty SplitterWidthProperty =
        DependencyProperty.Register("SplitterWidth", typeof(double), typeof(HexEditor), new FrameworkPropertyMetadata(4.0));
    
    public double SplitterLineWidth
    {
        get { return (double)GetValue(SplitterLineWidthProperty); }
        set { SetValue(SplitterLineWidthProperty, value); }
    }
    public static readonly DependencyProperty SplitterLineWidthProperty =
        DependencyProperty.Register("SplitterLineWidth", typeof(double), typeof(HexEditor), new PropertyMetadata(2.0));

    public Brush HeaderLinesColor
    {
        get { return (Brush)GetValue(HeaderLinesColorProperty); }
        set { SetValue(HeaderLinesColorProperty, value); }
    }
    public static readonly DependencyProperty HeaderLinesColorProperty =
        DependencyProperty.Register("HeaderLinesColor", typeof(Brush), typeof(HexEditor), new FrameworkPropertyMetadata(Brushes.Gray));


    #endregion Content Header

    public double HexEditorContentRowHeight
    {
        get { return (double)GetValue(HexEditorContentRowHeightProperty); }
        set { SetValue(HexEditorContentRowHeightProperty, value); }
    }
    public static readonly DependencyProperty HexEditorContentRowHeightProperty =
        DependencyProperty.Register("HexEditorContentRowHeight", typeof(double), typeof(HexEditor), new FrameworkPropertyMetadata(30.0));

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
            hexEditor.DataCells = new HexEditorContentDataCell[(int)e.NewValue, hexEditor.NumberOfColumns];
            foreach (HexEditorContent itemHexContent in hexEditor.HexEditorContents)
            {
                itemHexContent.ContentData.Children.Clear();
            }
            for (int itemRow=0; itemRow < (int)e.NewValue; itemRow++)
            {
                for (int itemColumn=0;itemColumn< hexEditor.NumberOfColumns; itemColumn++)
                {
                    hexEditor.DataCells[itemRow, itemColumn] = new HexEditorContentDataCell();
                    if (itemRow == 4 && itemColumn == 4) hexEditor.DataCells[itemRow, itemColumn].CellData = "ABCDEF";
                    foreach (HexEditorContent itemHexContent in hexEditor.HexEditorContents)
                    {
                        itemHexContent.ContentData.Children.Add(new HexEditorContentDataCell(hexEditor.DataCells[itemRow, itemColumn]));
                    }
                }
            }
        }
    }

    public HexEditorContentDataCell[,] DataCells
    {
        get { return (HexEditorContentDataCell[,])GetValue(DataCellsProperty); }
        set { SetValue(DataCellsProperty, value); }
    }
    public static readonly DependencyProperty DataCellsProperty =
        DependencyProperty.Register("DataCells", typeof(HexEditorContentDataCell[,]), typeof(HexEditor), new FrameworkPropertyMetadata(new HexEditorContentDataCell[1, 16], FrameworkPropertyMetadataOptions.AffectsArrange));


}
