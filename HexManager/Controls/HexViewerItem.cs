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

public class HexViewerItem : ContentControl
{
    static HexViewerItem()
    {
        DefaultStyleKeyProperty.OverrideMetadata(typeof(HexViewerItem), new FrameworkPropertyMetadata(typeof(HexViewerItem)));
    }

    public HexViewerItem()
    {
        
    }

    protected override void OnContentChanged(object oldContent, object newContent)
    {
        base.OnContentChanged(oldContent, newContent);
        if (newContent != null && newContent is string)
        {
            string content = (string)newContent;
            DataBytes = Enumerable.Range(0, content.Length)
                     .Where(x => x % 2 == 0)
                     .Select(x => Convert.ToByte(content.Substring(x, 2), 16))
                     .ToArray();
        }

    }





    public byte[] DataBytes
    {
        get { return (byte[])GetValue(DataBytesProperty); }
        set { SetValue(DataBytesProperty, value); }
    }
    // Using a DependencyProperty as the backing store for DataBytes.  This enables animation, styling, binding, etc...
    public static readonly DependencyProperty DataBytesProperty =
        DependencyProperty.Register("DataBytes", typeof(byte[]), typeof(HexViewerItem), new PropertyMetadata(null));





}
