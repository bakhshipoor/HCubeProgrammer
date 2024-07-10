using HexManager.Models;
using System.Globalization;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using static HexManager.Helpers.HexDisplayModeEnum;

namespace HexManager;

[TemplatePart(Name = ElementTextBoxHexData, Type = typeof(TextBox))]
public class HexByte : Control
{

    private const string ElementTextBoxHexData = "PART_txtHexData";
    public TextBox txtHexData;

    //static HexByte()
    //{
    //    DefaultStyleKeyProperty.OverrideMetadata(typeof(HexByte), new FrameworkPropertyMetadata(typeof(HexByte)));
    //}

    public HexByte()
    {
        txtHexData = new();
    }

    public HexByte(HexByteModel hexByteModel) : this()
    {
        HexByteData = hexByteModel;
    }

    protected override void OnRender(DrawingContext drawingContext)
    {
        base.OnRender(drawingContext);
        drawingContext.DrawRectangle(Brushes.LightGray, null, new Rect(2, 2, 28, 28));
        var typeface = new Typeface("Courier New");
        var formattedText = new FormattedText(HexByteText, CultureInfo.InvariantCulture, FlowDirection.LeftToRight,
                typeface, 12, Brushes.Black, VisualTreeHelper.GetDpi(this).PixelsPerDip);
        drawingContext.DrawText(formattedText, new Point(2, 2));
    }

    //protected override void OnRender(DrawingContext drawingContext)
    //{
    //    base.OnRender(drawingContext);
    //    drawingContext.DrawRectangle(Brushes.LightGray, null, new Rect(2, 2, RenderSize.Width - 2, RenderSize.Height - 2));
    //    var typeface = new Typeface("Courier New");
    //    var formattedText = new FormattedText(HexByteText, CultureInfo.InvariantCulture, FlowDirection.LeftToRight,
    //            typeface, 12, Brushes.Black, VisualTreeHelper.GetDpi(this).PixelsPerDip);
    //    drawingContext.DrawText(formattedText, new Point(2, 2));
    //}

    public override void OnApplyTemplate()
    {
        if (txtHexData != null)
        {
            txtHexData.LostFocus -= TxtHexData_LostFocus;
            txtHexData.LostKeyboardFocus -= TxtHexData_LostKeyboardFocus;
            txtHexData.PreviewLostKeyboardFocus -= TxtHexData_PreviewLostKeyboardFocus;
            txtHexData.PreviewKeyDown -= TxtHexData_PreviewKeyDown;
        }
        HexByteData.HexByteDataChanged -= HexByteData_HexByteDataChanged;

        base.OnApplyTemplate();

        HexByteData.HexByteDataChanged += HexByteData_HexByteDataChanged;

        txtHexData = (TextBox)GetTemplateChild(ElementTextBoxHexData);

        if (txtHexData != null)
        {
            txtHexData.LostFocus += TxtHexData_LostFocus;
            txtHexData.LostKeyboardFocus += TxtHexData_LostKeyboardFocus;
            txtHexData.PreviewLostKeyboardFocus += TxtHexData_PreviewLostKeyboardFocus;
            txtHexData.PreviewKeyDown += TxtHexData_PreviewKeyDown;
        }
    }

    private void HexByteData_HexByteDataChanged(object? sender, EventArgs.HexByteEventArgs e)
    {
        //if (DisplayMode == HexDisplayMode.HexString)
        //{
        //    HexByteText = HexByteData.HexString;
        //}
        //else if (DisplayMode == HexDisplayMode.AsciiString)
        //{
        //    HexByteText = HexByteData.AsciiString;
        //}
    }

    private void TxtHexData_PreviewKeyDown(object sender, KeyEventArgs e)
    {
        if (e.Key == Key.Escape)
        {
            Keyboard.ClearFocus();
        }
        else if (e.Key == Key.Enter)
        {
            Keyboard.ClearFocus();
        }
    }

    private void TxtHexData_PreviewLostKeyboardFocus(object sender, KeyboardFocusChangedEventArgs e)
    {
        DoLostFocus();
    }

    private void TxtHexData_LostKeyboardFocus(object sender, KeyboardFocusChangedEventArgs e)
    {
        DoLostFocus();
    }

    private void TxtHexData_LostFocus(object sender, RoutedEventArgs e)
    {
        DoLostFocus();
    }

    private void DoLostFocus()
    {
        EditMode = false;
        if (DisplayMode == HexDisplayMode.HexString)
        {
            string strTemp = string.Format("{0:X2}", HexByteData.Data);
            HexByteData.HexString = strTemp;
            HexByteText = strTemp;
        }
    }

    protected override void OnPreviewMouseDoubleClick(MouseButtonEventArgs e)
    {
        base.OnPreviewMouseDoubleClick(e);
        if (CanEdit)
            EditMode = true;
    }

    public HexByteModel HexByteData
    {
        get { return (HexByteModel)GetValue(HexByteDataProperty); }
        set { SetValue(HexByteDataProperty, value); }
    }
    public static readonly DependencyProperty HexByteDataProperty =
        DependencyProperty.Register("HexByteData", typeof(HexByteModel), typeof(HexByte), new FrameworkPropertyMetadata(new HexByteModel(), FrameworkPropertyMetadataOptions.BindsTwoWayByDefault, OnHexByteDataChanged));
    private static void OnHexByteDataChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
    {
        HexByte hexByte = (HexByte)d;
        if (e.NewValue!=null)
        {
            HexByteModel hexByteModel = (HexByteModel)e.NewValue;
            if (hexByte.DisplayMode == HexDisplayMode.HexString)
            {
                hexByte.HexByteText = hexByteModel.HexString;
            }
            else if (hexByte.DisplayMode == HexDisplayMode.AsciiString)
            {
                hexByte.HexByteText = hexByteModel.AsciiString;
            }
        }
    }


    public string HexByteText
    {
        get { return (string)GetValue(HexByteTextProperty); }
        set { SetValue(HexByteTextProperty, value); }
    }
    public static readonly DependencyProperty HexByteTextProperty =
        DependencyProperty.Register("HexByteText", typeof(string), typeof(HexByte), new FrameworkPropertyMetadata(string.Empty, FrameworkPropertyMetadataOptions.BindsTwoWayByDefault, OnHexByteTextChanged));
    private static void OnHexByteTextChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
    {
        HexByte hexByte = (HexByte)d;
        if (hexByte.DisplayMode == HexDisplayMode.HexString)
        {
            hexByte.HexByteData.HexString = hexByte.HexByteText;
            hexByte.HexByteText = hexByte.HexByteData.HexString;
        }
        else if (hexByte.DisplayMode == HexDisplayMode.AsciiString)
        {
            hexByte.HexByteData.AsciiString = hexByte.HexByteText;
            hexByte.HexByteText = hexByte.HexByteData.AsciiString;
        }
    }

    public HexDisplayMode DisplayMode
    {
        get { return (HexDisplayMode)GetValue(DisplayModeProperty); }
        set { SetValue(DisplayModeProperty, value); }
    }
    public static readonly DependencyProperty DisplayModeProperty =
        DependencyProperty.Register("DisplayMode", typeof(HexDisplayMode), typeof(HexByte), new FrameworkPropertyMetadata(HexDisplayMode.HexString, FrameworkPropertyMetadataOptions.BindsTwoWayByDefault, OnDisplayModeChanged));
    private static void OnDisplayModeChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
    {
        HexByte hexByte = (HexByte)d;
        if (hexByte.DisplayMode == HexDisplayMode.HexString)
        {
            hexByte.HexByteText = hexByte.HexByteData.HexString;
        }
        else if (hexByte.DisplayMode == HexDisplayMode.AsciiString)
        {
            hexByte.HexByteText = hexByte.HexByteData.AsciiString;
        }
    }

    public bool CanEdit
    {
        get { return (bool)GetValue(CanEditProperty); }
        set { SetValue(CanEditProperty, value); }
    }
    public static readonly DependencyProperty CanEditProperty =
        DependencyProperty.Register("CanEdit", typeof(bool), typeof(HexByte), new PropertyMetadata(true));

    public bool EditMode
    {
        get { return (bool)GetValue(EditModeProperty); }
        set { SetValue(EditModeProperty, value); }
    }
    public static readonly DependencyProperty EditModeProperty =
        DependencyProperty.Register("EditMode", typeof(bool), typeof(HexByte), new PropertyMetadata(false));


}
