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

    private void FillHexData(HexViewModel hexViewModel)
    {
        GrdHexDataCollection.Children.Clear();
        GrdHexDataCollection.RowDefinitions.Clear();

        int countOfRows = hexViewModel.HexBytes.Count / 16;
        
            for (int itemRow = 0; itemRow <= countOfRows; itemRow++)
            {
                RowDefinition row = new RowDefinition();
                row.Height = new GridLength(30, GridUnitType.Pixel);
                GrdHexDataCollection.RowDefinitions.Add(row);
            }
        

        Address[] txtAddresses = new Address[countOfRows+1];
        
            for (int i = 0; i <= countOfRows; i++)
            {
                txtAddresses[i] = new Address(string.Format("0x{0:X8}", hexViewModel.HexBytes[i * 16].Address));
                
            }
        

        int countOfBytes = hexViewModel.HexBytes.Count;
        HexByte[] hexBytes = new HexByte[countOfBytes];
        
            int rowCounter = 0;
            int columnCounter = 2;
            for (int i = 0; i < countOfBytes; i++)
            {
                hexBytes[i] = new HexByte(hexViewModel.HexBytes[i]);
                Grid.SetColumn(hexBytes[i], columnCounter);
                Grid.SetRow(hexBytes[i], rowCounter);
                columnCounter += 2;
                if (columnCounter>32)
                {
                    columnCounter = 2;
                    rowCounter++;
                }
            }
        

        
            rowCounter = 0;
            foreach (Address itemTextBloc in txtAddresses)
            {
                Grid.SetColumn(itemTextBloc, 0);
                Grid.SetRow(itemTextBloc, rowCounter);
                GrdHexDataCollection.Children.Add(itemTextBloc);
                rowCounter++;
            }
        

        
            
            foreach (HexByte itemHexByte in hexBytes)
            {
                
                GrdHexDataCollection.Children.Add(itemHexByte);
                
            }
        








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
