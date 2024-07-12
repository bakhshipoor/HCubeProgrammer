using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace HexManager;

public class HexEditor : Control
{
    static HexEditor()
    {
        DefaultStyleKeyProperty.OverrideMetadata(typeof(HexEditor), new FrameworkPropertyMetadata(typeof(HexEditor)));
    }

    public HexEditor()
    {
        
    }

    public double HexEditorContentHeaderTypeHeight
    {
        get { return (double)GetValue(HexEditorContentHeaderTypeHeightProperty); }
        set { SetValue(HexEditorContentHeaderTypeHeightProperty, value); }
    }
    public static readonly DependencyProperty HexEditorContentHeaderTypeHeightProperty =
        DependencyProperty.Register("HexEditorContentHeaderTypeHeight", typeof(double), typeof(HexEditor), new PropertyMetadata(30.0));

    public double HexEditorContentHeaderColumnsHeight
    {
        get { return (double)GetValue(HexEditorContentHeaderColumnsHeightProperty); }
        set { SetValue(HexEditorContentHeaderColumnsHeightProperty, value); }
    }
    public static readonly DependencyProperty HexEditorContentHeaderColumnsHeightProperty =
        DependencyProperty.Register("HexEditorContentHeaderColumnsHeight", typeof(double), typeof(HexEditor), new PropertyMetadata(30.0));

    public Brush HexEditorContentHeaderColumnsBackground
    {
        get { return (Brush)GetValue(HexEditorContentHeaderColumnsBackgroundProperty); }
        set { SetValue(HexEditorContentHeaderColumnsBackgroundProperty, value); }
    }
    public static readonly DependencyProperty HexEditorContentHeaderColumnsBackgroundProperty =
        DependencyProperty.Register("HexEditorContentHeaderColumnsBackground", typeof(Brush), typeof(HexEditor), new PropertyMetadata(Brushes.Transparent));

    public double HexEditorContentRowHeight
    {
        get { return (double)GetValue(HexEditorContentRowHeightProperty); }
        set { SetValue(HexEditorContentRowHeightProperty, value); }
    }
    public static readonly DependencyProperty HexEditorContentRowHeightProperty =
        DependencyProperty.Register("HexEditorContentRowHeight", typeof(double), typeof(HexEditor), new PropertyMetadata(30.0));

    public double HexEditorContentHeaderSplitterWidth
    {
        get { return (double)GetValue(HexEditorContentHeaderSplitterWidthProperty); }
        set { SetValue(HexEditorContentHeaderSplitterWidthProperty, value); }
    }
    public static readonly DependencyProperty HexEditorContentHeaderSplitterWidthProperty =
        DependencyProperty.Register("HexEditorContentHeaderSplitterWidth", typeof(double), typeof(HexEditor), new PropertyMetadata(2.0));

    public Brush HexEditorContentHeaderSplitterBackground
    {
        get { return (Brush)GetValue(HexEditorContentHeaderSplitterBackgroundProperty); }
        set { SetValue(HexEditorContentHeaderSplitterBackgroundProperty, value); }
    }
    public static readonly DependencyProperty HexEditorContentHeaderSplitterBackgroundProperty =
        DependencyProperty.Register("HexEditorContentHeaderSplitterBackground", typeof(Brush), typeof(HexEditor), new PropertyMetadata(Brushes.Gray));

    public int NumberOfDataColumns
    {
        get { return (int)GetValue(NumberOfDataColumnsProperty); }
        set { SetValue(NumberOfDataColumnsProperty, value); }
    }
    public static readonly DependencyProperty NumberOfDataColumnsProperty =
        DependencyProperty.Register("NumberOfDataColumns", typeof(int), typeof(HexEditor), new PropertyMetadata(16));



}
