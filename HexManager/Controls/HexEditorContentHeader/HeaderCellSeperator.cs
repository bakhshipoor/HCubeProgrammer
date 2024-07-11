using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;

namespace HexManager;

public class HeaderCellSeperator : Thumb
{

    static HeaderCellSeperator()
    {
        EventManager.RegisterClassHandler(typeof(HeaderCellSeperator), DragStartedEvent, new DragStartedEventHandler(OnDragStarted));
        EventManager.RegisterClassHandler(typeof(HeaderCellSeperator), DragDeltaEvent, new DragDeltaEventHandler(OnDragDelta));
        EventManager.RegisterClassHandler(typeof(HeaderCellSeperator), DragCompletedEvent, new DragCompletedEventHandler(OnDragCompleted));

        

    }
    public HeaderCellSeperator() 
    {
        Width = 2;
        BorderThickness = new Thickness(2);
        BorderBrush = Brushes.Gray;
        HorizontalAlignment = HorizontalAlignment.Right;
    }

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

    public HeaderCell ParentCell
    {
        get { return (HeaderCell)GetValue(ParentCellProperty); }
        set 
        { 
            SetValue(ParentCellProperty, value); 
        }
    }
    public static readonly DependencyProperty ParentCellProperty =
        DependencyProperty.Register("ParentCell", typeof(HeaderCell), typeof(HeaderCellSeperator), new PropertyMetadata(null));


    private static void OnDragStarted(object sender, DragStartedEventArgs e)
    {
        
    }
  
    private static void OnDragDelta(object sender, DragDeltaEventArgs e)
    {
        if (sender!=null && sender is HeaderCellSeperator)
        {
            HeaderCellSeperator hcs = (HeaderCellSeperator)sender;
            if (hcs.ParentCell != null)
            {
                double delta = hcs.ParentCell.Width + e.HorizontalChange;
                if (e.HorizontalChange>0)
                {
                    if (hcs.ParentCell.MaxWidth >= 0 && delta <= hcs.ParentCell.MaxWidth)
                        hcs.ParentCell.Width += e.HorizontalChange;
                    else
                        hcs.ParentCell.Width = hcs.ParentCell.MaxWidth;
                }
                else
                {
                    if (hcs.ParentCell.MinWidth >= 0 && delta >= (hcs.ParentCell.MinWidth + 2))
                        hcs.ParentCell.Width += e.HorizontalChange;
                    else
                        hcs.ParentCell.Width = 3;
                }
                    
            }
        }



    }

    private static void OnDragCompleted(object sender, DragCompletedEventArgs e)
    {
        
    }

    

}
