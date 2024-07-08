using HCubeProgrammerLibrary.FirmwareFileData;
using HexManager.Models;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Media;
using System.Windows.Shapes;
using System.Windows.Threading;

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
        ScrollViewer.SetVerticalScrollBarVisibility(this, ScrollBarVisibility.Disabled);
        ScrollViewer.SetHorizontalScrollBarVisibility(this, ScrollBarVisibility.Visible);
        GrdHexDataCollection = (Grid)GetTemplateChild(ElementGridHexDataCollection);
        ScrVertical = (ScrollBar)GetTemplateChild(ElementScrollBarScrVertical);
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
    public double DefaultRowHeight { get; private set; } = 30.0;

    public double ViewAreaRowHeight
    {
        get { return (double)GetValue(ViewAreaRowHeightProperty); }
        set { SetValue(ViewAreaRowHeightProperty, value); }
    }
    public static readonly DependencyProperty ViewAreaRowHeightProperty =
        DependencyProperty.Register("ViewAreaRowHeight", typeof(double), typeof(HexViewer), new FrameworkPropertyMetadata(30.0,FrameworkPropertyMetadataOptions.BindsTwoWayByDefault));

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
        hexViewer.ViewAreaRowCount = (int)((hexViewer.ViewArea.Height-15) / hexViewer.DefaultRowHeight);
        double leftOverHeight = (hexViewer.ViewArea.Height-15) % hexViewer.DefaultRowHeight;
        hexViewer.ViewAreaRowHeight = hexViewer.DefaultRowHeight + (leftOverHeight / (hexViewer.ViewAreaRowCount));
        hexViewer.ViewAreaRowCount--; // Columns Header
        hexViewer.ScrVertical.Margin = new Thickness(0, hexViewer.ViewAreaRowHeight, 0, 15);
        if (hexViewer.ViewAreaRowCount<=0)
        {
            hexViewer.GrdHexDataCollection.Children.Clear();
            hexViewer.GrdHexDataCollection.RowDefinitions.Clear();
            return;
        }

        GridLength gridRowHeight = new GridLength(hexViewer.ViewAreaRowHeight, GridUnitType.Pixel);
        RowDefinition[] gridRows = new RowDefinition[hexViewer.ViewAreaRowCount];
        Rectangle[] gridRowsRects = new Rectangle[hexViewer.ViewAreaRowCount];

        for (int itemRow = 0; itemRow < hexViewer.ViewAreaRowCount; itemRow++)
        {
            RowDefinition gridRow = new RowDefinition();
            gridRow.Height = gridRowHeight;
            gridRows[itemRow] = gridRow;

            Rectangle rect = new();
            rect.Fill = itemRow % 2 == 0 ? Brushes.AliceBlue : Brushes.Azure;
            Grid.SetRow(rect, itemRow);
            Grid.SetColumn(rect, 0);
            Grid.SetColumnSpan(rect, 67);
            gridRowsRects[itemRow] = rect;
        }

        hexViewer.GrdHexDataCollection.Children.Clear();
        hexViewer.GrdHexDataCollection.RowDefinitions.Clear();

        for (int itemRow = 0; itemRow < hexViewer.ViewAreaRowCount; itemRow++)
        {
            hexViewer.GrdHexDataCollection.RowDefinitions.Add(gridRows[itemRow]);
            hexViewer.GrdHexDataCollection.Children.Add(gridRowsRects[itemRow]);
        }

        DrawVerticalLines(hexViewer.GrdHexDataCollection, hexViewer.ViewAreaRowCount, hexViewer.ViewAreaRowHeight);
    }

    private static void DrawVerticalLines(Grid viewGrid,int gridRowCount,double maxHeight)
    {
        if (gridRowCount <= 0) return;
        for (int vlMainCounter = 1; vlMainCounter < 34; vlMainCounter += 32)
            viewGrid.Children.Add(MainVerticalLine(maxHeight, vlMainCounter, gridRowCount));

        for (int vlOneByteCounter = 3; vlOneByteCounter < 32; vlOneByteCounter += 4)
            viewGrid.Children.Add(OneByteVerticalLine(maxHeight, vlOneByteCounter, gridRowCount));

        for (int vlTwoByteCounter = 5; vlTwoByteCounter < 30; vlTwoByteCounter += 8)
            viewGrid.Children.Add(TwoByteVerticalLine(maxHeight, vlTwoByteCounter, gridRowCount));

        for (int vlFourByteCounter = 9; vlFourByteCounter < 26; vlFourByteCounter += 8)
            viewGrid.Children.Add(FourByteVerticalLine(maxHeight, vlFourByteCounter, gridRowCount));

        for (int vlAsciiCounter=35; vlAsciiCounter<67; vlAsciiCounter+=2)
            viewGrid.Children.Add(OneByteVerticalLine(maxHeight, vlAsciiCounter, gridRowCount));
    }

    private static Line MainVerticalLine(double maxHeight, int gridColumn, int gridRowCount)
    {
        Line vLine = new();
        vLine.Y2 = maxHeight * gridRowCount;
        vLine.Stroke = Brushes.Gray;
        vLine.StrokeThickness = 2;
        vLine.HorizontalAlignment = HorizontalAlignment.Center;
        vLine.SnapsToDevicePixels = true;
        Grid.SetColumn(vLine, gridColumn);
        Grid.SetRow(vLine, 0);
        Grid.SetRowSpan(vLine, gridRowCount);
        return vLine;
    }

    private static Line OneByteVerticalLine(double maxHeight, int gridColumn, int gridRowCount)
    {
        Line vLine = new();
        vLine.Y2 = maxHeight * gridRowCount;
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

    private static Line TwoByteVerticalLine(double maxHeight, int gridColumn, int gridRowCount)
    {
        Line vLine = new();
        vLine.Y2 = maxHeight * gridRowCount;
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

    private static Line FourByteVerticalLine(double maxHeight, int gridColumn, int gridRowCount)
    {
        Line vLine = new();
        vLine.Y2 = maxHeight * gridRowCount;
        vLine.Stroke = Brushes.Gray;
        vLine.StrokeThickness = 1;
        vLine.HorizontalAlignment = HorizontalAlignment.Center;
        vLine.SnapsToDevicePixels = true;
        Grid.SetColumn(vLine, gridColumn);
        Grid.SetRow(vLine, 0);
        Grid.SetRowSpan(vLine, gridRowCount);
        return vLine;
    }

}
