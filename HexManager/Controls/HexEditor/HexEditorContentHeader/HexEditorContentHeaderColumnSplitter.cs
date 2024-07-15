using System.Windows;
using System.Windows.Controls.Primitives;
using System.Windows.Input;
using System.Windows.Media;

namespace HexManager;

public class HexEditorContentHeaderColumnSplitter : Thumb
{
    static HexEditorContentHeaderColumnSplitter()
    {
        EventManager.RegisterClassHandler(typeof(HexEditorContentHeaderColumnSplitter), DragStartedEvent, new DragStartedEventHandler(OnDragStarted));
        EventManager.RegisterClassHandler(typeof(HexEditorContentHeaderColumnSplitter), DragDeltaEvent, new DragDeltaEventHandler(OnDragDelta));
        EventManager.RegisterClassHandler(typeof(HexEditorContentHeaderColumnSplitter), DragCompletedEvent, new DragCompletedEventHandler(OnDragCompleted));
        DefaultStyleKeyProperty.OverrideMetadata(typeof(HexEditorContentHeaderColumnSplitter), new FrameworkPropertyMetadata(typeof(HexEditorContentHeaderColumnSplitter)));
    }

    public HexEditorContentHeaderColumnSplitter(HexEditorContentHeaderColumn headerCell) 
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

    public HexEditorContentHeaderColumn ParentHeaderCell
    {
        get { return (HexEditorContentHeaderColumn)GetValue(ParentHeaderCellProperty); }
        set { SetValue(ParentHeaderCellProperty, value); }
    }
    public static readonly DependencyProperty ParentHeaderCellProperty =
        DependencyProperty.Register("ParentHeaderCell", typeof(HexEditorContentHeaderColumn), typeof(HexEditorContentHeaderColumnSplitter), new PropertyMetadata(null));

    public double RectWidth
    {
        get { return (double)GetValue(RectWidthProperty); }
        set { SetValue(RectWidthProperty, value); }
    }
    public static readonly DependencyProperty RectWidthProperty =
        DependencyProperty.Register("RectWidth", typeof(double), typeof(HexEditorContentHeaderColumnSplitter), new FrameworkPropertyMetadata(2.0, FrameworkPropertyMetadataOptions.AffectsRender));

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
        if (sender!=null && sender is HexEditorContentHeaderColumnSplitter)
        {
            HexEditorContentHeaderColumnSplitter hcs = (HexEditorContentHeaderColumnSplitter)sender;
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
                    if (hcs.ParentHeaderCell.MinWidth >= 0 && delta >= (hcs.ParentHeaderCell.MinWidth ))
                        hcs.ParentHeaderCell.Width += e.HorizontalChange;
                    else
                        hcs.ParentHeaderCell.Width = hcs.ParentHeaderCell.MinWidth;
                }
                    
            }
        }



    }

    private static void OnDragCompleted(object sender, DragCompletedEventArgs e)
    {
        
    }

    

}
