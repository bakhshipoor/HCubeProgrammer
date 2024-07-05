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
            byte[] dataBytes = Enumerable.Range(0, content.Length)
                     .Where(x => x % 2 == 0)
                     .Select(x => Convert.ToByte(content.Substring(x, 2), 16))
                     .ToArray();
            if (dataBytes != null)
            {
                DataBytes = new char[dataBytes.Length];
                for (int i = 0; i < dataBytes.Length; i++)
                {
                    DataBytes[i] = (char)dataBytes[i];
                }
            }

            string hexValue = string.Format("{0:X2}", (byte)DataBytes[0]);
        }

    }





    public char[] DataBytes
    {
        get { return (char[])GetValue(DataBytesProperty); }
        set { SetValue(DataBytesProperty, value); }
    }
    // Using a DependencyProperty as the backing store for DataBytes.  This enables animation, styling, binding, etc...
    public static readonly DependencyProperty DataBytesProperty =
        DependencyProperty.Register("DataBytes", typeof(char[]), typeof(HexViewerItem), new PropertyMetadata(null));





}
