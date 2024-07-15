using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace HexManager;

public class Address : Control
{
    //static Address()
    //{
    //    DefaultStyleKeyProperty.OverrideMetadata(typeof(Address), new FrameworkPropertyMetadata(typeof(Address)));

    //}
    public Address()
    {
        
    }

    public Address(string text) : this()
    {
        AddressText = text;
    }

    protected override void OnRender(DrawingContext drawingContext)
    {
        base.OnRender(drawingContext);
        //drawingContext.DrawRectangle(Brushes.LightGray, null, new Rect(2, 2, 28, 28));
        var typeface = new Typeface("Courier New");
        var formattedText = new FormattedText(AddressText, CultureInfo.InvariantCulture, FlowDirection.LeftToRight,
                typeface, 12, Brushes.Black, VisualTreeHelper.GetDpi(this).PixelsPerDip);
        drawingContext.DrawText(formattedText, new Point(2, 2));
    }

    public string AddressText
    {
        get { return (string)GetValue(AddressTextProperty); }
        set { SetValue(AddressTextProperty, value); }
    }
    public static readonly DependencyProperty AddressTextProperty =
        DependencyProperty.Register("AddressText", typeof(string), typeof(Address), new PropertyMetadata(string.Empty));


}
