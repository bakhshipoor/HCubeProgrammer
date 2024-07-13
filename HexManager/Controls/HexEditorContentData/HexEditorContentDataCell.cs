using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Markup;
using System.Windows.Media;
using static System.Net.Mime.MediaTypeNames;

namespace HexManager;

public class HexEditorContentDataCell : FrameworkElement
{
    static HexEditorContentDataCell()
    {
        
    }

    public HexEditorContentDataCell() : base()
    {
        
    }

    protected override void OnRender(DrawingContext drawingContext)
    {
        
        //Rect bounds = new Rect(0, 0, ActualWidth, ActualHeight);
        //Brush brush = Brushes.Red;
        //drawingContext.DrawRoundedRectangle(brush, null, bounds, 0, 0);

        var typeface = new Typeface("Segoe UI");
        var formattedText = new FormattedText(CellData, CultureInfo.InvariantCulture, FlowDirection.LeftToRight,
                typeface, 12, Brushes.Black, VisualTreeHelper.GetDpi(this).PixelsPerDip);
        if (formattedText.Width < (ActualWidth))
        {
            double labelX = (ActualWidth - formattedText.Width ) / 2;
            if (labelX < 0) { labelX = 0; }
            double labelY = (ActualHeight - formattedText.Height) / 2;
            if (labelY < 0) { labelY = 0; }
            Point labelLocation = new Point(labelX, labelY);
            drawingContext.DrawText(formattedText, labelLocation);
        }
        base.OnRender(drawingContext);
    }



    public string CellData
    {
        get { return (string)GetValue(CellDataProperty); }
        set { SetValue(CellDataProperty, value); }
    }
    public static readonly DependencyProperty CellDataProperty =
        DependencyProperty.Register("CellData", typeof(string), typeof(HexEditorContentDataCell), new PropertyMetadata("00"));



}
