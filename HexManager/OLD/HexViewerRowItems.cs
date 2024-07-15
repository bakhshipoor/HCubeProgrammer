using HexManager.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using static HexManager.Helpers.HexDisplayModeEnum;

namespace HexManager;

public class HexViewerRowItems
{
    public HexViewerRowItems()
    {
        ParentHexViewr = new();
        NumberOfDataColumns = 0;
        RowIndex = 0;
        RowAddress = new();
        HexBytes = [];
        ASCIIBytes = [];
        HexBytesModel = [];
    }

    public HexViewerRowItems(HexViewer hexViewer, int numberOfDataColumns, int rowIndex) : this()
    {
        ParentHexViewr = hexViewer;
        NumberOfDataColumns = numberOfDataColumns;
        RowIndex = rowIndex;
        for (int itemColumn = 0; itemColumn < NumberOfDataColumns; itemColumn++)
        {
            if (itemColumn == 0)
            {
                Address txbAddress = new Address();
                Grid.SetColumn(txbAddress, itemColumn * 2);
                Grid.SetRow(txbAddress, rowIndex);
                RowAddress = txbAddress;
                hexViewer.GrdHexDataCollection.Children.Add(txbAddress);
            }
            else
            {
                HexByteModel hexByteModel = new();
                HexByte hexByte = new HexByte(hexByteModel);
                Grid.SetColumn(hexByte, itemColumn * 2);
                Grid.SetRow(hexByte, rowIndex);
                HexBytes.Add(hexByte);
                hexViewer.GrdHexDataCollection.Children.Add(hexByte);
                HexByte asciiByte = new HexByte(hexByteModel);
                Grid.SetColumn(asciiByte, itemColumn * 4);
                Grid.SetRow(asciiByte, rowIndex);
                ASCIIBytes.Add(asciiByte);
                hexViewer.GrdHexDataCollection.Children.Add(asciiByte);
            }
        }

        RowAddress = new();
        Grid.SetColumn(RowAddress, 0);
        HexBytes = [];
        ASCIIBytes = [];
        HexBytesModel = [];
    }

    public HexViewer ParentHexViewr { get; set; }
    public int NumberOfDataColumns { get; set; }
    public int RowIndex { get; set; }
    public Address RowAddress { get; set; }
    public List<HexByte> HexBytes { get; set; }
    public List<HexByte> ASCIIBytes { get; set; }
    public List<HexByteModel> HexBytesModel { get; set; }
}
