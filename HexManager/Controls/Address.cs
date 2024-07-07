using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;

namespace HexManager.Controls;

public class Address : FrameworkElement
{
    public Address()
    {
        
    }

    public Address(string addressText) : this()
    {
        AddressText = addressText;
    }

    protected override void OnRender(DrawingContext drawingContext)
    {
        base.OnRender(drawingContext);
        drawingContext.DrawRectangle(Brushes.LightGray, null, new Rect(2, 2, RenderSize.Width - 2, RenderSize.Height - 2));
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
