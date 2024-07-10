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
    #region CTOR
    static HexViewer()
    {
        DefaultStyleKeyProperty.OverrideMetadata(typeof(HexViewer), new FrameworkPropertyMetadata(typeof(HexViewer)));
    }

    public HexViewer()
    {
        GrdHexDataCollection = new();
        ScrVertical = new();
        ViewAreaDataCells = [];
        _ViewAreaDataCells = [];
    }
        
    #endregion CTOR

    #region Overrides
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
        
        HexViewerHelpers.InitialViewingArea(this);
    }

    //protected override void OnRender(DrawingContext drawingContext)
    //{
    //    base.OnRender(drawingContext);
    //    ViewArea = RenderSize;
    //    HexViewerHelpers.OnViewAreaChanged(this);
    //}

    protected override void OnRenderSizeChanged(SizeChangedInfo sizeInfo)
    {
        base.OnRenderSizeChanged(sizeInfo);
        ViewAreaHeight = RenderSize.Height;
        ViewAreaWidth = RenderSize.Width;
        HexViewerHelpers.OnViewAreaChanged(this);
        //InitialViewAreaDataCells(this);
        //AddDataCellsTOGrid(this);
    }
    #endregion Overrides

    #region Private Variables
    private const string ElementGridHexDataCollection = "PART_GrdHexCollectionData";
    private const string ElementScrollBarScrVertical = "PART_ScrVertical";
    internal double _ScreenHeight;
    internal int _MaxRowCount;
    internal int _MaxCellCount;
    internal double _DefaultRowHeight = 30.0;
    internal RowDefinition[] _GridRows = new RowDefinition[1];
    internal Rectangle[] _GridRowsRects = new Rectangle[1];
    internal int _GridNumberOfColumns = 67;
    internal int _NumberOfGridVerticalLines = 33;
    internal int _NumberOfGridDataColumns = 33;
    internal int _RowDataColumns = 17;
    internal Line[] _GridVerticalLines = new Line[33];
    internal UIElement[][] _ViewAreaDataCells;
    #endregion Private Variables

    #region Public Variables
    public FirmwareFile DataFile
    {
        get { return (FirmwareFile)GetValue(HexViewerHelpers.DataFileProperty); }
        set { SetValue(HexViewerHelpers.DataFileProperty, value); }
    }
    public HexViewModel HexDataCollection
    {
        get { return (HexViewModel)GetValue(HexViewerHelpers.HexDataCollectionProperty); }
        set { SetValue(HexViewerHelpers.HexDataCollectionProperty, value); }
    }

    public Grid GrdHexDataCollection;
    public ScrollBar ScrVertical;
    public double ViewAreaRowHeight
    {
        get { return (double)GetValue(HexViewerHelpers.ViewAreaRowHeightProperty); }
        set { SetValue(HexViewerHelpers.ViewAreaRowHeightProperty, value); }
    }
    public int ViewAreaCellCount { get; internal set; }
    //public UIElement[][] ViewAreaDataCells { get; internal set; }
    #endregion Public Variables




    public List<HexViewerRowItems> ViewAreaDataCells
    {
        get { return (List<HexViewerRowItems>)GetValue(ViewAreaDataCellsProperty); }
        set { SetValue(ViewAreaDataCellsProperty, value); }
    }
    public static readonly DependencyProperty ViewAreaDataCellsProperty =
        DependencyProperty.Register("ViewAreaDataCells", typeof(List<HexViewerRowItems>), typeof(HexViewer), new FrameworkPropertyMetadata(new List<HexViewerRowItems>(), FrameworkPropertyMetadataOptions.BindsTwoWayByDefault));




    public double ViewAreaHeight
    {
        get { return (double)GetValue(HexViewerHelpers.ViewAreaHeightProperty); }
        set { SetValue(HexViewerHelpers.ViewAreaHeightProperty, value); }
    }

    public double ViewAreaWidth
    {
        get { return (double)GetValue(HexViewerHelpers.ViewAreaWidthProperty); }
        set { SetValue(HexViewerHelpers.ViewAreaWidthProperty, value); }
    }

    public int ViewAreaRowCount
    {
        get { return (int)GetValue(HexViewerHelpers.ViewAreaRowCountProperty); }
        set { SetValue(HexViewerHelpers.ViewAreaRowCountProperty, value); }
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
}
