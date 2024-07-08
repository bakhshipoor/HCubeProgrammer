using HCubeProgrammerLibrary.FirmwareFileData;
using HexManager.Controls;
using HexManager.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;
using static HexManager.Helpers.HexDisplayModeEnum;

namespace HexManager;

[TemplatePart(Name = ElementGridHexDataCollection, Type = typeof(Grid))]
public class HexViewer : ItemsControl
{
    private const string ElementGridHexDataCollection = "PART_GrdHexCollectionData";
    public Grid GrdHexDataCollection;

    static HexViewer()
    {
        DefaultStyleKeyProperty.OverrideMetadata(typeof(HexViewer), new FrameworkPropertyMetadata(typeof(HexViewer)));
    }

    public HexViewer()
    {
        GrdHexDataCollection = new();
    }

    public override void OnApplyTemplate()
    {
        base.OnApplyTemplate();

        GrdHexDataCollection = (Grid)GetTemplateChild(ElementGridHexDataCollection);

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
    //public double ViewAreaRowHeight { get; private set; } = 30.0;



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
        hexViewer.ViewAreaRowCount = (int)(hexViewer.ViewArea.Height / hexViewer.DefaultRowHeight);
        double leftOverHeight = hexViewer.ViewArea.Height % hexViewer.DefaultRowHeight;
        hexViewer.ViewAreaRowHeight = hexViewer.DefaultRowHeight + (leftOverHeight / (hexViewer.ViewAreaRowCount));
        hexViewer.ViewAreaRowCount--; // Columns Header

        hexViewer.GrdHexDataCollection.Children.Clear();
        hexViewer.GrdHexDataCollection.RowDefinitions.Clear();
        

        for (int itemRow = 0; itemRow < hexViewer.ViewAreaRowCount; itemRow++)
        {
            RowDefinition row = new RowDefinition();
            row.Height = new GridLength(hexViewer.ViewAreaRowHeight, GridUnitType.Pixel);
            hexViewer.GrdHexDataCollection.RowDefinitions.Add(row);
            Rectangle rect = new();
            rect.Fill = itemRow % 2 == 0 ? Brushes.AliceBlue : Brushes.Azure;
            Grid.SetRow(rect, itemRow);
            Grid.SetColumnSpan(rect, 51);
            hexViewer.GrdHexDataCollection.Children.Add(rect);
        }
        DrawVerticalLines(hexViewer.GrdHexDataCollection, hexViewer.ViewAreaRowCount, hexViewer.ViewAreaRowHeight);
    }

    private static void DrawVerticalLines(Grid viewGrid,int rowCount,double maxHeight)
    {
        for (int itemRow = 0; itemRow < rowCount; itemRow++)
        {
            Line vlAddress = MainVerticalLine(maxHeight);
            Grid.SetColumn(vlAddress, 1);
            Grid.SetRow(vlAddress, itemRow);
            viewGrid.Children.Add(vlAddress);

            Line vlAscii = MainVerticalLine(maxHeight);
            Grid.SetColumn(vlAscii, 33);
            Grid.SetRow(vlAscii, itemRow);
            viewGrid.Children.Add(vlAscii);

            Line vlByte00 = OneByteVerticalLine(maxHeight);
            Grid.SetColumn(vlByte00, 3);
            Grid.SetRow(vlByte00, itemRow);
            viewGrid.Children.Add(vlByte00);

            Line vlByte02 = OneByteVerticalLine(maxHeight);
            Grid.SetColumn(vlByte02, 7);
            Grid.SetRow(vlByte02, itemRow);
            viewGrid.Children.Add(vlByte02);

            Line vlByte04 = OneByteVerticalLine(maxHeight);
            Grid.SetColumn(vlByte04, 11);
            Grid.SetRow(vlByte04, itemRow);
            viewGrid.Children.Add(vlByte04);

            Line vlByte06 = OneByteVerticalLine(maxHeight);
            Grid.SetColumn(vlByte06, 15);
            Grid.SetRow(vlByte06, itemRow);
            viewGrid.Children.Add(vlByte06);

            Line vlByte08 = OneByteVerticalLine(maxHeight);
            Grid.SetColumn(vlByte08, 19);
            Grid.SetRow(vlByte08, itemRow);
            viewGrid.Children.Add(vlByte08);

            Line vlByte10 = OneByteVerticalLine(maxHeight);
            Grid.SetColumn(vlByte10, 23);
            Grid.SetRow(vlByte10, itemRow);
            viewGrid.Children.Add(vlByte10);

            Line vlByte12 = OneByteVerticalLine(maxHeight);
            Grid.SetColumn(vlByte12, 27);
            Grid.SetRow(vlByte12, itemRow);
            viewGrid.Children.Add(vlByte12);

            Line vlByte14 = OneByteVerticalLine(maxHeight);
            Grid.SetColumn(vlByte14, 31);
            Grid.SetRow(vlByte14, itemRow);
            viewGrid.Children.Add(vlByte14);

            Line vlByte01 = TwoByteVerticalLine(maxHeight);
            Grid.SetColumn(vlByte01, 5);
            Grid.SetRow(vlByte01, itemRow);
            viewGrid.Children.Add(vlByte01);

            Line vlByte05 = TwoByteVerticalLine(maxHeight);
            Grid.SetColumn(vlByte05, 13);
            Grid.SetRow(vlByte05, itemRow);
            viewGrid.Children.Add(vlByte05);

            Line vlByte09 = TwoByteVerticalLine(maxHeight);
            Grid.SetColumn(vlByte09, 21);
            Grid.SetRow(vlByte09, itemRow);
            viewGrid.Children.Add(vlByte09);

            Line vlByte13 = TwoByteVerticalLine(maxHeight);
            Grid.SetColumn(vlByte13, 29);
            Grid.SetRow(vlByte13, itemRow);
            viewGrid.Children.Add(vlByte13);

            Line vlByte03 = FourByteVerticalLine(maxHeight);
            Grid.SetColumn(vlByte03, 9);
            Grid.SetRow(vlByte03, itemRow);
            viewGrid.Children.Add(vlByte03);

            Line vlByte07 = FourByteVerticalLine(maxHeight);
            Grid.SetColumn(vlByte07, 17);
            Grid.SetRow(vlByte07, itemRow);
            viewGrid.Children.Add(vlByte07);

            Line vlByte11 = FourByteVerticalLine(maxHeight);
            Grid.SetColumn(vlByte11, 25);
            Grid.SetRow(vlByte11, itemRow);
            viewGrid.Children.Add(vlByte11);
        }
    }

    private static Line MainVerticalLine(double maxHeight)
    {
        Line vLine = new();
        vLine.Y2 = maxHeight;
        vLine.Stroke = Brushes.Gray;
        vLine.StrokeThickness = 2;
        vLine.HorizontalAlignment = HorizontalAlignment.Center;
        vLine.SnapsToDevicePixels = true;
        //vLine.ClipToBounds=true;
        return vLine;
    }

    private static Line OneByteVerticalLine(double maxHeight)
    {
        Line vLine = new();
        vLine.Y2 = maxHeight;
        vLine.Stroke = Brushes.Gray;
        vLine.StrokeThickness = 1;
        vLine.StrokeDashArray = new DoubleCollection() { 0.5, 2 };
        vLine.HorizontalAlignment = HorizontalAlignment.Center;
        vLine.SnapsToDevicePixels = true;
        //vLine.ClipToBounds = true;
        return vLine;
    }

    private static Line TwoByteVerticalLine(double maxHeight)
    {
        Line vLine = new();
        vLine.Y2 = maxHeight;
        vLine.Stroke = Brushes.Gray;
        vLine.StrokeThickness = 1;
        vLine.StrokeDashArray = new DoubleCollection() { 1.5, 3.5 };
        vLine.HorizontalAlignment = HorizontalAlignment.Center;
        vLine.SnapsToDevicePixels = true;
        //vLine.ClipToBounds = true;
        return vLine;
    }

    private static Line FourByteVerticalLine(double maxHeight)
    {
        Line vLine = new();
        vLine.Y2 = maxHeight;
        vLine.Stroke = Brushes.Gray;
        vLine.StrokeThickness = 1;
        vLine.HorizontalAlignment = HorizontalAlignment.Center;
        vLine.SnapsToDevicePixels = true;
        //vLine.ClipToBounds = true;
        return vLine;
    }

}
