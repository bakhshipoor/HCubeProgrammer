using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;

namespace HexManager;

[TemplatePart(Name = ElementScrollBarScrVertical, Type = typeof(ScrollBar))]
[TemplatePart(Name = ElementScrollBarScrHorizontal, Type = typeof(ScrollBar))]
public class HexScrollViewer : ScrollViewer
{
    private const string ElementScrollBarScrVertical = "PART_VerticalScrollBar";
    private const string ElementScrollBarScrHorizontal = "PART_HorizontalScrollBar";
    public ScrollBar ScrVertical { get; set; }
    public ScrollBar ScrHorizontal { get; set; }

    static HexScrollViewer()
    {
        DefaultStyleKeyProperty.OverrideMetadata(typeof(HexScrollViewer), new FrameworkPropertyMetadata(typeof(HexScrollViewer)));
    }

    public HexScrollViewer()
    {
        ScrVertical = new();
        ScrHorizontal = new();
    }

    public override void OnApplyTemplate()
    {
        base.OnApplyTemplate();
        ScrVertical = (ScrollBar)GetTemplateChild(ElementScrollBarScrVertical);
        ScrHorizontal = (ScrollBar)GetTemplateChild(ElementScrollBarScrHorizontal);
    }

    protected override void OnRenderSizeChanged(SizeChangedInfo sizeInfo)
    {
        base.OnRenderSizeChanged(sizeInfo);
    }
}
