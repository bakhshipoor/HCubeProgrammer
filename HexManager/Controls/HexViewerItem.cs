using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace HexManager;

public class HexViewerItem : Control
{
    static HexViewerItem()
    {
        DefaultStyleKeyProperty.OverrideMetadata(typeof(HexViewerItem), new FrameworkPropertyMetadata(typeof(HexViewerItem)));
    }

    public HexViewerItem()
    {
        
    }

    //protected override void OnContentChanged(object oldContent, object newContent)
    //{
    //    //base.OnContentChanged(oldContent, newContent);
    //    //if (newContent != null && newContent is string)
    //    //{
    //    //    string content = (string)newContent;
    //    //    DataBytes = Enumerable.Range(0, content.Length)
    //    //             .Where(x => x % 2 == 0)
    //    //             .Select(x => Convert.ToByte(content.Substring(x, 2), 16))
    //    //             .ToArray();
    //    //}

    //}

    public byte[] DataBytes
    {
        get { return (byte[])GetValue(DataBytesProperty); }
        set { SetValue(DataBytesProperty, value); }
    }
    public static readonly DependencyProperty DataBytesProperty =
        DependencyProperty.Register("DataBytes", typeof(byte[]), typeof(HexViewerItem), new FrameworkPropertyMetadata(null, FrameworkPropertyMetadataOptions.BindsTwoWayByDefault));


    public int Address
    {
        get { return (int)GetValue(AddressProperty); }
        set { SetValue(AddressProperty, value); }
    }
    public static readonly DependencyProperty AddressProperty =
        DependencyProperty.Register("Address", typeof(int), typeof(HexViewerItem), new FrameworkPropertyMetadata(0,OnAddressChanged));
    private static void OnAddressChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
    {
        HexViewerItem hexViewerItem = (HexViewerItem)d;
        hexViewerItem.AddressString = string.Format("0x{0:X8}", e.NewValue);
    }


    public string AddressString
    {
        get { return (string)GetValue(AddressStringProperty); }
        set { SetValue(AddressStringProperty, value); }
    }
    public static readonly DependencyProperty AddressStringProperty =
        DependencyProperty.Register("AddressString", typeof(string), typeof(HexViewerItem), new FrameworkPropertyMetadata(string.Empty));






}
