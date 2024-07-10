using HCubeProgrammerLibrary.FirmwareFileData;
using HexManager;
using HexManager.Models;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Media;
using System.Windows.Shapes;
using System.Windows.Threading;
using static HexManager.Helpers.HexDisplayModeEnum;

internal static class HexViewerHelpers
{
    public static readonly DependencyProperty DataFileProperty =
        DependencyProperty.Register("DataFile", typeof(FirmwareFile), typeof(HexViewer), new FrameworkPropertyMetadata(new FirmwareFile(), OnDataFileChanged));
    public static readonly DependencyProperty HexDataCollectionProperty =
        DependencyProperty.Register("HexDataCollection", typeof(HexViewModel), typeof(HexViewer), new FrameworkPropertyMetadata(new HexViewModel(), OnHexDataCollectionChanged));
    public static readonly DependencyProperty ViewAreaRowHeightProperty =
        DependencyProperty.Register("ViewAreaRowHeight", typeof(double), typeof(HexViewer), new FrameworkPropertyMetadata(30.0, FrameworkPropertyMetadataOptions.BindsTwoWayByDefault));
    public static readonly DependencyProperty ViewAreaHeightProperty =
        DependencyProperty.Register("ViewAreaHeight", typeof(double), typeof(HexViewer), new FrameworkPropertyMetadata(0.0, FrameworkPropertyMetadataOptions.BindsTwoWayByDefault));
    public static readonly DependencyProperty ViewAreaWidthProperty =
        DependencyProperty.Register("ViewAreaWidth", typeof(double), typeof(HexViewer), new FrameworkPropertyMetadata(0.0, FrameworkPropertyMetadataOptions.BindsTwoWayByDefault));
    public static readonly DependencyProperty ViewAreaRowCountProperty =
        DependencyProperty.Register("ViewAreaRowCount", typeof(int), typeof(HexViewer), new FrameworkPropertyMetadata(0, FrameworkPropertyMetadataOptions.BindsTwoWayByDefault));

    private static void OnDataFileChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
    {
        HexViewer hexViewer = (HexViewer)d;
        if (e.NewValue != null)
        {
            hexViewer.HexDataCollection = new((FirmwareFile)e.NewValue);
        }
    }

    private static void OnHexDataCollectionChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
    {
        HexViewer hexViewer = (HexViewer)d;
        if (e.NewValue != null)
        {
            //hexViewer.FillHexData((HexViewModel)e.NewValue);
        }
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

    private static Line CreateFourByteVerticalLine(HexViewer hexViewer, int gridColumn)
    {
        Line vLine = new();

        Binding bindingMaxHeight = new();
        bindingMaxHeight.Source = hexViewer;
        bindingMaxHeight.Path = new PropertyPath("ViewAreaHeight");
        bindingMaxHeight.Mode = BindingMode.OneWay;
        bindingMaxHeight.UpdateSourceTrigger = UpdateSourceTrigger.PropertyChanged;
        BindingOperations.SetBinding(vLine, Line.Y2Property, bindingMaxHeight);
        Binding bindingRowSpan = new();
        bindingRowSpan.Source = hexViewer;
        bindingRowSpan.Path = new PropertyPath("ViewAreaRowCount");
        bindingRowSpan.Mode = BindingMode.OneWay;
        bindingRowSpan.UpdateSourceTrigger = UpdateSourceTrigger.PropertyChanged;
        BindingOperations.SetBinding(vLine, Grid.RowSpanProperty, bindingRowSpan);

        vLine.Stroke = Brushes.Gray;
        vLine.StrokeThickness = 1;
        vLine.HorizontalAlignment = HorizontalAlignment.Center;
        vLine.SnapsToDevicePixels = true;
        Grid.SetColumn(vLine, gridColumn);
        Grid.SetRow(vLine, 0);
        return vLine;
    }

    private static Line CreateMainVerticalLine(HexViewer hexViewer, int gridColumn)
    {
        Line vLine = new();

        Binding bindingMaxHeight = new();
        bindingMaxHeight.Source = hexViewer;
        bindingMaxHeight.Path = new PropertyPath("ViewAreaHeight");
        bindingMaxHeight.Mode = BindingMode.OneWay;
        bindingMaxHeight.UpdateSourceTrigger = UpdateSourceTrigger.PropertyChanged;
        BindingOperations.SetBinding(vLine, Line.Y2Property, bindingMaxHeight);
        Binding bindingRowSpan = new();
        bindingRowSpan.Source = hexViewer;
        bindingRowSpan.Path = new PropertyPath("ViewAreaRowCount");
        bindingRowSpan.Mode = BindingMode.OneWay;
        bindingRowSpan.UpdateSourceTrigger = UpdateSourceTrigger.PropertyChanged;
        BindingOperations.SetBinding(vLine, Grid.RowSpanProperty, bindingRowSpan);

        vLine.Stroke = Brushes.Gray;
        vLine.StrokeThickness = 2;
        vLine.HorizontalAlignment = HorizontalAlignment.Center;
        vLine.SnapsToDevicePixels = true;
        Grid.SetColumn(vLine, gridColumn);
        Grid.SetRow(vLine, 0);
        return vLine;
    }

    private static Line CreateOneByteVerticalLine(HexViewer hexViewer, int gridColumn)
    {
        Line vLine = new();

        Binding bindingMaxHeight = new();
        bindingMaxHeight.Source = hexViewer;
        bindingMaxHeight.Path = new PropertyPath("ViewAreaHeight");
        bindingMaxHeight.Mode = BindingMode.OneWay;
        bindingMaxHeight.UpdateSourceTrigger = UpdateSourceTrigger.PropertyChanged;
        BindingOperations.SetBinding(vLine, Line.Y2Property, bindingMaxHeight);
        Binding bindingRowSpan = new();
        bindingRowSpan.Source = hexViewer;
        bindingRowSpan.Path = new PropertyPath("ViewAreaRowCount");
        bindingRowSpan.Mode = BindingMode.OneWay;
        bindingRowSpan.UpdateSourceTrigger = UpdateSourceTrigger.PropertyChanged;
        BindingOperations.SetBinding(vLine, Grid.RowSpanProperty, bindingRowSpan);

        vLine.Stroke = Brushes.Gray;
        vLine.StrokeThickness = 1;
        vLine.StrokeDashArray = new DoubleCollection() { 0.5, 2 };
        vLine.HorizontalAlignment = HorizontalAlignment.Center;
        vLine.SnapsToDevicePixels = true;
        Grid.SetColumn(vLine, gridColumn);
        Grid.SetRow(vLine, 0);
        return vLine;
    }

    private static Line CreateTwoByteVerticalLine(HexViewer hexViewer, int gridColumn)
    {
        Line vLine = new();

        Binding bindingMaxHeight = new();
        bindingMaxHeight.Source = hexViewer;
        bindingMaxHeight.Path = new PropertyPath("ViewAreaHeight");
        bindingMaxHeight.Mode = BindingMode.OneWay;
        bindingMaxHeight.UpdateSourceTrigger = UpdateSourceTrigger.PropertyChanged;
        BindingOperations.SetBinding(vLine, Line.Y2Property, bindingMaxHeight);
        Binding bindingRowSpan = new();
        bindingRowSpan.Source = hexViewer;
        bindingRowSpan.Path = new PropertyPath("ViewAreaRowCount");
        bindingRowSpan.Mode = BindingMode.OneWay;
        bindingRowSpan.UpdateSourceTrigger = UpdateSourceTrigger.PropertyChanged;
        BindingOperations.SetBinding(vLine, Grid.RowSpanProperty, bindingRowSpan);

        vLine.Stroke = Brushes.Gray;
        vLine.StrokeThickness = 1;
        vLine.StrokeDashArray = new DoubleCollection() { 1.5, 3.5 };
        vLine.HorizontalAlignment = HorizontalAlignment.Center;
        vLine.SnapsToDevicePixels = true;
        Grid.SetColumn(vLine, gridColumn);
        Grid.SetRow(vLine, 0);
        return vLine;
    }

    private static void CreateVerticalLines(HexViewer hexViewer)
    {
        for (int itemVLine = 0; itemVLine < hexViewer._NumberOfGridVerticalLines; itemVLine++)
        {
            if (itemVLine == 0 || itemVLine == 16)
            {
                hexViewer._GridVerticalLines[itemVLine] = CreateMainVerticalLine(hexViewer, (itemVLine * 2) + 1);
            }
            else if (itemVLine % 2 == 1 || itemVLine > 16)
            {
                hexViewer._GridVerticalLines[itemVLine] = CreateOneByteVerticalLine(hexViewer, (itemVLine * 2) + 1);
            }
            else if (itemVLine > 0 && itemVLine < 16 && (itemVLine - 2) % 4 == 0)
            {
                hexViewer._GridVerticalLines[itemVLine] = CreateTwoByteVerticalLine(hexViewer, (itemVLine * 2) + 1);
            }
            else if (itemVLine > 0 && itemVLine < 16 && itemVLine % 4 == 0)
            {
                hexViewer._GridVerticalLines[itemVLine] = CreateFourByteVerticalLine(hexViewer, (itemVLine * 2) + 1);
            }
        }
    }

    internal static void InitialViewingArea(HexViewer hexViewer)
    {
        hexViewer.GrdHexDataCollection.Children.Clear();
        hexViewer.GrdHexDataCollection.RowDefinitions.Clear();
        CreateRowDefinitions(hexViewer);
        CreateVerticalLines(hexViewer);
        AddVerticalLinesToGrid(hexViewer);
        InitialViewAreaDataCells(hexViewer);
    }

    internal static void CreateRowDefinitions(HexViewer hexViewer)
    {
        hexViewer._GridRows = new RowDefinition[hexViewer._MaxRowCount];
        hexViewer._GridRowsRects = new Rectangle[hexViewer._MaxRowCount];
        AddRowDefinitions(hexViewer, 0, hexViewer._MaxRowCount);
    }

    internal static void AddRowDefinition(HexViewer hexViewer, int rowIndex)
    {
        hexViewer._GridRows[rowIndex] = CreateRowDefinition(hexViewer);
        hexViewer._GridRowsRects[rowIndex] = CreateGridRowRectangle(rowIndex, hexViewer._GridNumberOfColumns);
        hexViewer.GrdHexDataCollection.RowDefinitions.Add(hexViewer._GridRows[rowIndex]);
        hexViewer.GrdHexDataCollection.Children.Add(hexViewer._GridRowsRects[rowIndex]);
        AddRowDataCell(hexViewer, rowIndex);
    }

    internal static void AddRowDefinitions(HexViewer hexViewer, int startRowIndex, int rowCount)
    {
        for (int itemRow = startRowIndex; itemRow < rowCount; itemRow++)
        {
            AddRowDefinition(hexViewer, itemRow);
        }
    }

    internal static void OnViewAreaChanged(HexViewer hexViewer)
    {
        hexViewer.ViewAreaRowCount = (int)((hexViewer.ViewAreaHeight - 15) / hexViewer._DefaultRowHeight);
        double leftOverHeight = (hexViewer.ViewAreaHeight - 15) % hexViewer._DefaultRowHeight;
        hexViewer.ViewAreaRowHeight = hexViewer._DefaultRowHeight + (leftOverHeight / (hexViewer.ViewAreaRowCount));
        hexViewer.ViewAreaRowCount--; // Columns Header
        if (hexViewer.ViewAreaRowCount > hexViewer._MaxRowCount)
        {
            int addedRows = (int)(hexViewer.ViewAreaHeight / hexViewer._DefaultRowHeight);
            int addedCells = addedRows * 32;
            AddRowDefinitions(hexViewer, hexViewer._MaxRowCount, addedRows);
            hexViewer._MaxRowCount += addedRows;
            hexViewer._MaxCellCount += addedCells;
            InitialViewingArea(hexViewer);
        }
        hexViewer.ScrVertical.Margin = new Thickness(0, hexViewer.ViewAreaRowHeight, 0, 15);
        //if (hexViewer.ViewAreaRowCount <= 0)
        //{
        //    hexViewer.GrdHexDataCollection.Children.Clear();
        //    hexViewer.GrdHexDataCollection.RowDefinitions.Clear();
        //    return;
        //}

        //hexViewer.GrdHexDataCollection.Children.Clear();
        //hexViewer.GrdHexDataCollection.RowDefinitions.Clear();

        //for (int itemRow = 0; itemRow < hexViewer.ViewAreaRowCount; itemRow++)
        //{
        //    hexViewer.GrdHexDataCollection.RowDefinitions.Add(hexViewer._GridRows[itemRow]);
        //    hexViewer.GrdHexDataCollection.Children.Add(hexViewer._GridRowsRects[itemRow]);
        //}

        //AddVerticalLinesToGrid(hexViewer);
        //AddDataCellsTOGrid(hexViewer);
    }

    private static void AddVerticalLinesToGrid(HexViewer hexViewer)
    {
        for (int itemVLine = 0; itemVLine < hexViewer._NumberOfGridVerticalLines; itemVLine++)
        {
            hexViewer.GrdHexDataCollection.Children.Add(hexViewer._GridVerticalLines[itemVLine]);
        }
    }

    internal static void AddRowDataCell(HexViewer hexViewer, int rowIndex)
    {
        HexViewerRowItems hexViewerRowItems = new HexViewerRowItems(hexViewer,hexViewer._NumberOfGridDataColumns,rowIndex);
        hexViewer.ViewAreaDataCells.Add(hexViewerRowItems);
    }

    internal static void InitialViewAreaDataCells(HexViewer hexViewer)
    {
        //hexViewer._ViewAreaDataCells = new UIElement[hexViewer._MaxRowCount][];
        //for (int itemRow = 0; itemRow < hexViewer._MaxRowCount; itemRow++)
        //{
        //    hexViewer._ViewAreaDataCells[itemRow] = new UIElement[hexViewer._NumberOfGridDataColumns];
        //}
        //for (int itemRow = 0; itemRow < hexViewer._MaxRowCount; itemRow++)
        //{
            
        //    for (int itemColumn = 0; itemColumn < hexViewer._NumberOfGridDataColumns; itemColumn++)
        //    {
        //        if (itemColumn == 0)
        //        {
        //            Address txbAddress = new Address();
        //            Grid.SetColumn(txbAddress, itemColumn * 2);
        //            Grid.SetRow(txbAddress, itemRow);
        //            hexViewer._ViewAreaDataCells[itemRow][itemColumn] = txbAddress;
        //        }
        //        else
        //        {
        //            HexByte hexByte = new HexByte();
        //            if (itemColumn > 16)
        //                hexByte.DisplayMode = HexDisplayMode.AsciiString;
        //            Grid.SetColumn(hexByte, itemColumn * 2);
        //            Grid.SetRow(hexByte, itemRow);
        //            hexViewer._ViewAreaDataCells[itemRow][itemColumn] = hexByte;
        //        }
        //    }
        //}
    }

    internal static void AddDataCellsTOGrid(HexViewer hexViewer)
    {
        //hexViewer.ViewAreaDataCells = new UIElement[hexViewer.ViewAreaRowCount][];
        //for (int itemRow = 0; itemRow < hexViewer.ViewAreaRowCount; itemRow++)
        //{
        //    hexViewer.ViewAreaDataCells[itemRow] = new UIElement[hexViewer._NumberOfGridDataColumns];
        //    for (int itemColumn = 0; itemColumn < hexViewer._NumberOfGridDataColumns; itemColumn++)
        //    {
        //        //if (hexViewer._ViewAreaDataCells[itemRow][itemColumn] == null)
        //        //    break;
        //        hexViewer.ViewAreaDataCells[itemRow][itemColumn] = hexViewer._ViewAreaDataCells[itemRow][itemColumn];
        //        if (itemColumn == 0)
        //        {
        //            ((Address)hexViewer.ViewAreaDataCells[itemRow][itemColumn]).AddressText = $"{itemRow:X8}";
        //        }
        //        hexViewer.GrdHexDataCollection.Children.Add(hexViewer.ViewAreaDataCells[itemRow][itemColumn]);
        //    }
        //}
    }
}