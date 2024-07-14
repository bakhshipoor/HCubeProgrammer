using System.Windows;
using System.Windows.Controls.Primitives;
using System.Windows.Input;
using System.Windows.Media;

namespace HexManager;

public class HeaderCellSplitter : Thumb
{
    static HeaderCellSplitter()
    {
        EventManager.RegisterClassHandler(typeof(HeaderCellSplitter), DragStartedEvent, new DragStartedEventHandler(OnDragStarted));
        EventManager.RegisterClassHandler(typeof(HeaderCellSplitter), DragDeltaEvent, new DragDeltaEventHandler(OnDragDelta));
        EventManager.RegisterClassHandler(typeof(HeaderCellSplitter), DragCompletedEvent, new DragCompletedEventHandler(OnDragCompleted));
        DefaultStyleKeyProperty.OverrideMetadata(typeof(HeaderCellSplitter), new FrameworkPropertyMetadata(typeof(HeaderCellSplitter)));
    }

    public HeaderCellSplitter(HexEditorContentHeaderCell headerCell) 
    {
        ParentHeaderCell = headerCell;
        SnapsToDevicePixels = true;
    }

    protected override void OnRender(DrawingContext drawingContext)
    {
        base.OnRender(drawingContext);
        Rect bounds = new Rect(1.0, 0, RectWidth, ActualHeight);
        Brush brush = Background;
        drawingContext.DrawRoundedRectangle(brush, null, bounds, 0, 0);
    }

    public HexEditorContentHeaderCell ParentHeaderCell
    {
        get { return (HexEditorContentHeaderCell)GetValue(ParentHeaderCellProperty); }
        set { SetValue(ParentHeaderCellProperty, value); }
    }
    public static readonly DependencyProperty ParentHeaderCellProperty =
        DependencyProperty.Register("ParentHeaderCell", typeof(HexEditorContentHeaderCell), typeof(HeaderCellSplitter), new PropertyMetadata(null));

    public double RectWidth
    {
        get { return (double)GetValue(RectWidthProperty); }
        set { SetValue(RectWidthProperty, value); }
    }
    public static readonly DependencyProperty RectWidthProperty =
        DependencyProperty.Register("RectWidth", typeof(double), typeof(HeaderCellSplitter), new FrameworkPropertyMetadata(2.0, FrameworkPropertyMetadataOptions.AffectsRender));

    protected override void OnMouseEnter(MouseEventArgs e)
    {
        base.OnMouseEnter(e);
        this.Cursor = Cursors.SizeWE;
    }

    protected override void OnMouseLeave(MouseEventArgs e)
    {
        base.OnMouseLeave(e);
        this.Cursor = Cursors.None;
    }

    private static void OnDragStarted(object sender, DragStartedEventArgs e)
    {
        
    }
  
    private static void OnDragDelta(object sender, DragDeltaEventArgs e)
    {
        if (sender!=null && sender is HeaderCellSplitter)
        {
            HeaderCellSplitter hcs = (HeaderCellSplitter)sender;
            if (hcs.ParentHeaderCell != null)
            {
                double delta = hcs.ParentHeaderCell.Width + e.HorizontalChange;
                if (e.HorizontalChange>0)
                {
                    if (hcs.ParentHeaderCell.MaxWidth >= 0 && delta <= hcs.ParentHeaderCell.MaxWidth)
                        hcs.ParentHeaderCell.Width += e.HorizontalChange;
                    else
                        hcs.ParentHeaderCell.Width = hcs.ParentHeaderCell.MaxWidth;
                }
                else
                {
                    if (hcs.ParentHeaderCell.MinWidth >= 0 && delta >= (hcs.ParentHeaderCell.MinWidth + 2))
                        hcs.ParentHeaderCell.Width += e.HorizontalChange;
                    else
                        hcs.ParentHeaderCell.Width = 3;
                }
                    
            }
        }



    }

    private static void OnDragCompleted(object sender, DragCompletedEventArgs e)
    {
        
    }

    

}
