using HCubeProgrammerLibrary.FirmwareFileData;
using HexManager.Models;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Shapes;
using System.Windows.Threading;
using System.Xml.Linq;

namespace HexManager;

[TemplatePart(Name = ElementGridHexDataCollection, Type = typeof(Grid))]
[TemplatePart(Name = ElementScrollBarScrVertical, Type = typeof(Grid))]
public class HexViewer : Control
{
    private const string ElementGridHexDataCollection = "PART_GrdHexCollectionData";
    private const string ElementScrollBarScrVertical = "PART_ScrVertical";
    public Grid GrdHexDataCollection;
    public ScrollBar ScrVertical;

    static HexViewer()
    {
        DefaultStyleKeyProperty.OverrideMetadata(typeof(HexViewer), new FrameworkPropertyMetadata(typeof(HexViewer)));
    }

    public HexViewer()
    {
        GrdHexDataCollection = new();
        ScrVertical = new();
    }

    public override void OnApplyTemplate()
    {
        base.OnApplyTemplate();

        _ScreenHeight = SystemParameters.PrimaryScreenHeight;
        _MaxRowCount = (int)(_ScreenHeight / _DefaultRowHeight);
        _MaxCellCount = _MaxRowCount * 32;

        ScrollViewer.SetVerticalScrollBarVisibility(this, ScrollBarVisibility.Disabled);
        ScrollViewer.SetHorizontalScrollBarVisibility(this, ScrollBarVisibility.Visible);
        GrdHexDataCollection = (Grid)GetTemplateChild(ElementGridHexDataCollection);
        ScrVertical = (ScrollBar)GetTemplateChild(ElementScrollBarScrVertical);

        InitialViewingArea(this);
    }

    protected override void OnRender(DrawingContext drawingContext)
    {
        base.OnRender(drawingContext);
        ViewArea = RenderSize;
        OnViewAreaChanged(this);
    }

    protected override void OnRenderSizeChanged(SizeChangedInfo sizeInfo)
    {
        base.OnRenderSizeChanged(sizeInfo);
        ViewArea = RenderSize;
        OnViewAreaChanged(this);
    }

    public FirmwareFile DataFile
    {
        get { return (FirmwareFile)GetValue(DataFileProperty); }
        set { SetValue(DataFileProperty, value); }
    }
    public static readonly DependencyProperty DataFileProperty =
        DependencyProperty.Register("DataFile", typeof(FirmwareFile), typeof(HexViewer), new FrameworkPropertyMetadata(new FirmwareFile(), OnDataFileChanged));
    private static void OnDataFileChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
    {
        HexViewer hexViewer = (HexViewer)d;
        if (e.NewValue!=null)
        {
            hexViewer.HexDataCollection = new((FirmwareFile)e.NewValue);
        }
    }

    public HexViewModel HexDataCollection
    {
        get { return (HexViewModel)GetValue(HexDataCollectionProperty); }
        set { SetValue(HexDataCollectionProperty, value); }
    }
    public static readonly DependencyProperty HexDataCollectionProperty =
        DependencyProperty.Register("HexDataCollection", typeof(HexViewModel), typeof(HexViewer), new FrameworkPropertyMetadata(new HexViewModel(), OnHexDataCollectionChanged));
    private static void OnHexDataCollectionChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
    {
        HexViewer hexViewer = (HexViewer)d;
        if (e.NewValue != null)
        {
            hexViewer.FillHexData((HexViewModel)e.NewValue);
        }
    }

    public Size ViewArea { get; private set; }
    public int ViewAreaRowCount { get; private set; }
    public int ViewAreaCellCount { get; private set; }

    public double ViewAreaRowHeight
    {
        get { return (double)GetValue(ViewAreaRowHeightProperty); }
        set { SetValue(ViewAreaRowHeightProperty, value); }
    }
    public static readonly DependencyProperty ViewAreaRowHeightProperty =
        DependencyProperty.Register("ViewAreaRowHeight", typeof(double), typeof(HexViewer), new FrameworkPropertyMetadata(30.0,FrameworkPropertyMetadataOptions.BindsTwoWayByDefault));

    internal double _ScreenHeight;
    internal int _MaxRowCount;
    internal int _MaxCellCount;
    internal double _DefaultRowHeight = 30.0;
    internal RowDefinition[] _GridRows; 
    internal Rectangle[] _GridRowsRects;
    internal int _GridNumberOfColumns = 67;
    internal int _NumberOfGridVerticalLines = 33;
    internal Line[] _GridVerticalLines = new Line[33];

    private static void InitialViewingArea(HexViewer hexViewer)
    {
        hexViewer._GridRows = new RowDefinition[hexViewer._MaxRowCount];
        hexViewer._GridRowsRects = new Rectangle[hexViewer._MaxRowCount];
        for (int itemRow=0;itemRow<hexViewer._MaxRowCount;itemRow++)
        {
            hexViewer._GridRows[itemRow] = CreateRowDefinition(hexViewer);
            hexViewer._GridRowsRects[itemRow] = CreateGridRowRectangle(itemRow, hexViewer._GridNumberOfColumns);
        }
        CreateVerticalLines(hexViewer);
    }

    private void FillHexData(HexViewModel hexViewModel)
    {
        

        //Address[] txtAddresses = new Address[countOfRows+1];
        
        //for (int i = 0; i <= countOfRows; i++)
        //{
        //    txtAddresses[i] = new Address(string.Format("0x{0:X8}", hexViewModel.HexBytes[i * 16].Address));
                
        //}
        

        //int countOfBytes = hexViewModel.HexBytes.Count;
        //HexByte[] hexBytes = new HexByte[countOfBytes];
        
        //    int rowCounter = 0;
        //    int columnCounter = 2;
        //    for (int i = 0; i < countOfBytes; i++)
        //    {
        //        hexBytes[i] = new HexByte(hexViewModel.HexBytes[i]);
        //        Grid.SetColumn(hexBytes[i], columnCounter);
        //        Grid.SetRow(hexBytes[i], rowCounter);
        //        columnCounter += 2;
        //        if (columnCounter>32)
        //        {
        //            columnCounter = 2;
        //            rowCounter++;
        //        }
        //    }
        

        
        //    rowCounter = 0;
        //    foreach (Address itemTextBloc in txtAddresses)
        //    {
        //        Grid.SetColumn(itemTextBloc, 0);
        //        Grid.SetRow(itemTextBloc, rowCounter);
        //        GrdHexDataCollection.Children.Add(itemTextBloc);
        //        rowCounter++;
        //    }
        

        
            
        //    foreach (HexByte itemHexByte in hexBytes)
        //    {
                
        //        GrdHexDataCollection.Children.Add(itemHexByte);
                
        //    }
        








        //int rowCounter = 0;
        //int columnCounter = 0;
        //foreach (HexByteModel itemHexByteModel in hexViewModel.HexBytes)
        //{
        //    if (columnCounter == 0)
        //    {
        //        TextBlock txtAddress = new();
        //        txtAddress.Text = string.Format("0x{0:X8}",itemHexByteModel.Address);
        //        Grid.SetColumn(txtAddress, columnCounter);
        //        Grid.SetRow(txtAddress, rowCounter);
        //        GrdHexDataCollection.Children.Add(txtAddress);
        //        columnCounter += 2;

        //    }
        //    //HexByte hexByte = new(itemHexByteModel);
        //    //if (columnCounter > 33)
        //    //    hexByte.DisplayMode = HexDisplayMode.AsciiString;
        //    //Grid.SetColumn(hexByte, columnCounter);
        //    //Grid.SetRow(hexByte, rowCounter);
        //    //GrdHexDataCollection.Children.Add(hexByte);
        //    columnCounter += 3;
        //    if (columnCounter > 49)
        //    {
        //        columnCounter = 0;
        //        rowCounter++;
        //    }
        //}
    }

    private static void OnViewAreaChanged(HexViewer hexViewer)
    {
        hexViewer.ViewAreaRowCount = (int)((hexViewer.ViewArea.Height-15) / hexViewer._DefaultRowHeight);
        double leftOverHeight = (hexViewer.ViewArea.Height-15) % hexViewer._DefaultRowHeight;
        hexViewer.ViewAreaRowHeight = hexViewer._DefaultRowHeight + (leftOverHeight / (hexViewer.ViewAreaRowCount));
        hexViewer.ViewAreaRowCount--; // Columns Header
        if (hexViewer.ViewAreaRowCount > hexViewer._MaxRowCount)
        {
            hexViewer._MaxRowCount = hexViewer.ViewAreaRowCount;
            InitialViewingArea(hexViewer);
        }
        hexViewer.ScrVertical.Margin = new Thickness(0, hexViewer.ViewAreaRowHeight, 0, 15);
        if (hexViewer.ViewAreaRowCount<=0)
        {
            hexViewer.GrdHexDataCollection.Children.Clear();
            hexViewer.GrdHexDataCollection.RowDefinitions.Clear();
            return;
        }

        hexViewer.GrdHexDataCollection.Children.Clear();
        hexViewer.GrdHexDataCollection.RowDefinitions.Clear();

        for (int itemRow = 0; itemRow < hexViewer.ViewAreaRowCount; itemRow++)
        {
            hexViewer.GrdHexDataCollection.RowDefinitions.Add(hexViewer._GridRows[itemRow]);
            hexViewer.GrdHexDataCollection.Children.Add(hexViewer._GridRowsRects[itemRow]);
        }

        AddVerticalLinesToGrid(hexViewer);
    }

    private static RowDefinition CreateRowDefinition(HexViewer hexViewer)
    {
        RowDefinition rowDefinition = new RowDefinition();
        Binding binding = new();
        binding.Source = hexViewer;
        binding.Path = new PropertyPath("ViewAreaRowHeight");
        binding.Mode = BindingMode.OneWay;
        binding.UpdateSourceTrigger = UpdateSourceTrigger.PropertyChanged;
        BindingOperations.SetBinding(rowDefinition, RowDefinition.HeightProperty, binding);
        return rowDefinition;
    }

    private static Rectangle CreateGridRowRectangle(int rowIndex, int numberOfColumns)
    {
        Rectangle rect = new Rectangle();
        rect.Fill = rowIndex % 2 == 0 ? Brushes.AliceBlue : Brushes.Azure;
        Grid.SetRow(rect, rowIndex);
        Grid.SetColumn(rect, 0);
        Grid.SetColumnSpan(rect, numberOfColumns);
        return rect;
    }

    private static Line CreateMainVerticalLine(double maxHeight, int gridColumn, int gridRowCount)
    {
        Line vLine = new();
        vLine.Y2 = maxHeight;
        vLine.Stroke = Brushes.Gray;
        vLine.StrokeThickness = 2;
        vLine.HorizontalAlignment = HorizontalAlignment.Center;
        vLine.SnapsToDevicePixels = true;
        Grid.SetColumn(vLine, gridColumn);
        Grid.SetRow(vLine, 0);
        Grid.SetRowSpan(vLine, gridRowCount);
        return vLine;
    }

    private static Line CreateOneByteVerticalLine(double maxHeight, int gridColumn, int gridRowCount)
    {
        Line vLine = new();
        vLine.Y2 = maxHeight;
        vLine.Stroke = Brushes.Gray;
        vLine.StrokeThickness = 1;
        vLine.StrokeDashArray = new DoubleCollection() { 0.5, 2 };
        vLine.HorizontalAlignment = HorizontalAlignment.Center;
        vLine.SnapsToDevicePixels = true;
        Grid.SetColumn(vLine, gridColumn);
        Grid.SetRow(vLine, 0);
        Grid.SetRowSpan(vLine, gridRowCount);
        return vLine;
    }

    private static Line CreateTwoByteVerticalLine(double maxHeight, int gridColumn, int gridRowCount)
    {
        Line vLine = new();
        vLine.Y2 = maxHeight;
        vLine.Stroke = Brushes.Gray;
        vLine.StrokeThickness = 1;
        vLine.StrokeDashArray = new DoubleCollection() { 1.5, 3.5 };
        vLine.HorizontalAlignment = HorizontalAlignment.Center;
        vLine.SnapsToDevicePixels = true;
        Grid.SetColumn(vLine, gridColumn);
        Grid.SetRow(vLine, 0);
        Grid.SetRowSpan(vLine, gridRowCount);
        return vLine;
    }

    private static Line CreateFourByteVerticalLine(double maxHeight, int gridColumn, int gridRowCount)
    {
        Line vLine = new();
        vLine.Y2 = maxHeight;
        vLine.Stroke = Brushes.Gray;
        vLine.StrokeThickness = 1;
        vLine.HorizontalAlignment = HorizontalAlignment.Center;
        vLine.SnapsToDevicePixels = true;
        Grid.SetColumn(vLine, gridColumn);
        Grid.SetRow(vLine, 0);
        Grid.SetRowSpan(vLine, gridRowCount);
        return vLine;
    }

    private static void CreateVerticalLines(HexViewer hexViewer)
    {
        for (int itemVLine = 0; itemVLine < hexViewer._NumberOfGridVerticalLines; itemVLine++)
        {
            if (itemVLine == 0 || itemVLine == 16)
            {
                hexViewer._GridVerticalLines[itemVLine] = CreateMainVerticalLine(hexViewer._MaxRowCount * hexViewer._DefaultRowHeight, (itemVLine * 2) + 1, hexViewer._MaxRowCount);
            }
            else if (itemVLine % 2 == 1 || itemVLine > 16)
            {
                hexViewer._GridVerticalLines[itemVLine] = CreateOneByteVerticalLine(hexViewer._MaxRowCount * hexViewer._DefaultRowHeight, (itemVLine * 2) + 1, hexViewer._MaxRowCount);
            }
            else if (itemVLine > 0 && itemVLine < 16 && (itemVLine - 2) % 4 == 0)
            {
                hexViewer._GridVerticalLines[itemVLine] = CreateTwoByteVerticalLine(hexViewer._MaxRowCount * hexViewer._DefaultRowHeight, (itemVLine * 2) + 1, hexViewer._MaxRowCount);
            }
            else if (itemVLine > 0 && itemVLine < 16 && itemVLine % 4 == 0)
            {
                hexViewer._GridVerticalLines[itemVLine] = CreateFourByteVerticalLine(hexViewer._MaxRowCount * hexViewer._DefaultRowHeight, (itemVLine * 2) + 1, hexViewer._MaxRowCount);
            }
        }
    }

    private static void AddVerticalLinesToGrid(HexViewer hexViewer)
    {
        for (int itemVLine = 0; itemVLine < hexViewer._NumberOfGridVerticalLines; itemVLine++)
        {
            hexViewer.GrdHexDataCollection.Children.Add(hexViewer._GridVerticalLines[itemVLine]);
        }
    }
}
