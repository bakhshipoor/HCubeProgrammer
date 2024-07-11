using Microsoft.Windows.Themes;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;

namespace HexManager;

public class HeaderCell : Decorator
{

    static HeaderCell()
    {
        IsEnabledProperty.OverrideMetadata(typeof(HeaderCell), new FrameworkPropertyMetadata(true, FrameworkPropertyMetadataOptions.AffectsRender));
    }

    public HeaderCell() 
    {
        Width = 30;
        Height = 30;
        Child = new HeaderCellSeperator();
        ((HeaderCellSeperator)Child).ParentCell = this;
        //HorizontalAlignment = HorizontalAlignment.Center;
        //VerticalAlignment = VerticalAlignment.Center;
    }

    public override void OnApplyTemplate()
    {
        base.OnApplyTemplate();
        
        ((HeaderCellSeperator)Child).HorizontalAlignment = HorizontalAlignment.Right;
    }

    

    protected override void OnRender(DrawingContext drawingContext)
    {
        Rect bounds = new Rect(0, 0, ActualWidth, ActualHeight);
        
        if (DrawBackground(drawingContext, ref bounds))
        {
            // Out of space, stop
            return;
        }

        //DrawShades(drawingContext, ref bounds);

        //drawingContext.DrawRectangle(Brushes.LightGray, null, new Rect(0, 0, RenderSize.Width, RenderSize.Height));
        
        var typeface = new Typeface("Segoe UI");
        var formattedText = new FormattedText(Text, CultureInfo.InvariantCulture, FlowDirection.LeftToRight,
                typeface, 12, Brushes.Black, VisualTreeHelper.GetDpi(this).PixelsPerDip);
        double labelX = (ActualWidth - formattedText.Width - 2) / 2;
        if (labelX < 0) labelX = 0;
        double labelY = (ActualHeight - formattedText.Height) / 2;
        if (labelY<0) labelY = 0;
        Point labelLocation = new Point(labelX, labelY);
        drawingContext.DrawText(formattedText, labelLocation);
    }

    private const double sideThickness = 1.0;
    private const double sideThickness2 = 1 * sideThickness;

    protected override Size MeasureOverride(Size availableSize)
    {
        Size desired;
        UIElement child = Child;
        if (child != null)
        {
            Size childConstraint = new Size();
            bool isWidthTooSmall = (availableSize.Width < sideThickness2);
            bool isHeightTooSmall = (availableSize.Height < sideThickness2);

            if (!isWidthTooSmall)
            {
                childConstraint.Width = availableSize.Width - sideThickness2;
            }
            if (!isHeightTooSmall)
            {
                childConstraint.Height = availableSize.Height - sideThickness2;
            }

            child.Measure(childConstraint);

            desired = child.DesiredSize;

            if (!isWidthTooSmall)
            {
                desired.Width += sideThickness2;
            }
            if (!isHeightTooSmall)
            {
                desired.Height += sideThickness2;
            }
        }
        else
        {
            desired = new Size(Math.Min(sideThickness2, availableSize.Width), Math.Min(sideThickness2, availableSize.Height));
        }

        return desired;
    }

    protected override Size ArrangeOverride(Size finalSize)
    {



        Rect childArrangeRect = new Rect();

        childArrangeRect.Width = Math.Max(0d, finalSize.Width - sideThickness2);
        childArrangeRect.Height = Math.Max(0d, finalSize.Height - sideThickness2);
        childArrangeRect.X = (finalSize.Width - childArrangeRect.Width) * 0.5;
        childArrangeRect.Y = (finalSize.Height - childArrangeRect.Height) * 0.5;

        UIElement child = Child;
        if (child != null)
        {
            child.Arrange(childArrangeRect);
        }

        return finalSize;

    }

    private void DrawShades(DrawingContext dc, ref Rect bounds)
    {
        // shades are inset an additional 0.3
        bounds.Inflate(-0.3, -0.3);

        // draw top shade
        Brush brush = Brushes.Gray;
        if (brush != null)
        {
            dc.DrawRoundedRectangle(brush, null, new Rect(bounds.Left, bounds.Top, bounds.Width, 1.0), 3.0, 3.0);
        }

        // draw bottom shade
        brush = Brushes.Gray;
        if (brush != null)
        {
            dc.DrawRoundedRectangle(brush, null, new Rect(bounds.Left, bounds.Bottom - 1.0, bounds.Width, 1.0), 3.0, 3.0);
        }

        // draw left shade
        brush = Brushes.Gray;
        if (brush != null)
        {
            dc.DrawRoundedRectangle(brush, null, new Rect(bounds.Left, bounds.Top, 1.0, bounds.Height), 3.0, 3.0);
        }

        // draw right shade
        brush = Brushes.Gray;
        if (brush != null)
        {
            dc.DrawRoundedRectangle(brush, null, new Rect(bounds.Right - 1.0, bounds.Top, 1.0, bounds.Height), 3.0, 3.0);
        }

        // dones with shades; outset bounds
        bounds.Inflate(0.3, 0.3);
    }

    private bool DrawBackground(DrawingContext dc, ref Rect bounds)
    {
        // draw actual background
        Brush brush = Brushes.AliceBlue;
        if (brush != null)
        {
            dc.DrawRoundedRectangle(brush, null, bounds, 3.0, 3.0);
        }

        if ((bounds.Width < 0.6) || (bounds.Height < 0.6))
        {
            // out of space; we're done
            return true;
        }

        return false;
    }


    public string Text
    {
        get { return (string)GetValue(TextProperty); }
        set { SetValue(TextProperty, value); }
    }
    public static readonly DependencyProperty TextProperty =
        DependencyProperty.Register("Text", typeof(string), typeof(HeaderCell), new PropertyMetadata(string.Empty));


}
