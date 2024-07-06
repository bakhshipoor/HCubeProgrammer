using HexManager.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Markup;
using static HexManager.Helpers.HexDisplayModeEnum;
using static System.Runtime.CompilerServices.RuntimeHelpers;

namespace HexManager;

[TemplatePart(Name = ElementTextBoxHexData, Type = typeof(TextBox))]
public class HexByte : Control
{
    private const string ElementTextBoxHexData = "PART_txtHexData";
    public TextBox txtHexData;

    static HexByte()
    {
        DefaultStyleKeyProperty.OverrideMetadata(typeof(HexByte), new FrameworkPropertyMetadata(typeof(HexByte)));
    }

    public HexByte()
    {
        txtHexData = new();
    }

    public override void OnApplyTemplate()
    {
        if (txtHexData != null)
        {
            txtHexData.LostFocus -= TxtHexData_LostFocus;
            txtHexData.LostKeyboardFocus -= TxtHexData_LostKeyboardFocus;
            txtHexData.PreviewLostKeyboardFocus -= TxtHexData_PreviewLostKeyboardFocus;
            txtHexData.PreviewKeyDown -= TxtHexData_PreviewKeyDown;
        }

        base.OnApplyTemplate();

        txtHexData = (TextBox)GetTemplateChild(ElementTextBoxHexData);

        if (txtHexData != null)
        {
            txtHexData.LostFocus += TxtHexData_LostFocus;
            txtHexData.LostKeyboardFocus += TxtHexData_LostKeyboardFocus;
            txtHexData.PreviewLostKeyboardFocus += TxtHexData_PreviewLostKeyboardFocus;
            txtHexData.PreviewKeyDown += TxtHexData_PreviewKeyDown;
        }
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
        EditMode = false;
    }

    private void TxtHexData_LostKeyboardFocus(object sender, KeyboardFocusChangedEventArgs e)
    {
        EditMode = false;
    }

    private void TxtHexData_LostFocus(object sender, RoutedEventArgs e)
    {
        EditMode = false;
    }

    public byte? Data
    {
        get { return (byte?)GetValue(DataProperty); }
        set { SetValue(DataProperty, value); }
    }
    public static readonly DependencyProperty DataProperty =
        DependencyProperty.Register("Data", typeof(byte?), typeof(HexByte), new FrameworkPropertyMetadata(null, FrameworkPropertyMetadataOptions.BindsTwoWayByDefault, OnDataChanged));
    private static void OnDataChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
    {
        HexByte hexByte = (HexByte)d;
        hexByte.RefreshDataStrings();
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
        hexByte.RefreshDataStrings();
    }

    public void RefreshDataStrings()
    {
        if (Data != null)
        {
            HexString = string.Format("{0:X2}", Data);
            AsciiString = string.Format("{0}", (char)Data<0x20?".": (char)Data);
            DecimalString = string.Format("{0:D3}", Data);
            BinaryString = string.Format("{0:B8}", Data);
            if (DisplayMode == HexDisplayMode.HexString)
            {
                SData = HexString;
                DataLenght = 2;
            }
            else if (DisplayMode == HexDisplayMode.AsciiString)
            {
                SData = AsciiString;
                DataLenght = 1;
            }
            else if (DisplayMode == HexDisplayMode.DecimalString)
            {
                SData = DecimalString;
                DataLenght = 3;
            }
            else if (DisplayMode == HexDisplayMode.BinaryString)
            {
                SData = BinaryString;
                DataLenght = 8;
            }
        }
    }

    public string HexString
    {
        get { return (string)GetValue(HexStringProperty); }
        set { SetValue(HexStringProperty, value); }
    }
    public static readonly DependencyProperty HexStringProperty =
        DependencyProperty.Register("HexString", typeof(string), typeof(HexByte), new FrameworkPropertyMetadata(string.Empty, FrameworkPropertyMetadataOptions.BindsTwoWayByDefault));

    public string AsciiString
    {
        get { return (string)GetValue(AsciiStringProperty); }
        set { SetValue(AsciiStringProperty, value); }
    }
    public static readonly DependencyProperty AsciiStringProperty =
        DependencyProperty.Register("AsciiString", typeof(string), typeof(HexByte), new FrameworkPropertyMetadata(string.Empty, FrameworkPropertyMetadataOptions.BindsTwoWayByDefault));

    public string DecimalString
    {
        get { return (string)GetValue(DecimalStringProperty); }
        set { SetValue(DecimalStringProperty, value); }
    }
    public static readonly DependencyProperty DecimalStringProperty =
        DependencyProperty.Register("DecimalString", typeof(string), typeof(HexByte), new FrameworkPropertyMetadata(string.Empty, FrameworkPropertyMetadataOptions.BindsTwoWayByDefault));

    public string BinaryString
    {
        get { return (string)GetValue(BinaryStringProperty); }
        set { SetValue(BinaryStringProperty, value); }
    }
    public static readonly DependencyProperty BinaryStringProperty =
        DependencyProperty.Register("BinaryString", typeof(string), typeof(HexByte), new FrameworkPropertyMetadata(string.Empty, FrameworkPropertyMetadataOptions.BindsTwoWayByDefault));

    public string SData
    {
        get { return (string)GetValue(SDataProperty); }
        set { SetValue(SDataProperty, value); }
    }
    public static readonly DependencyProperty SDataProperty =
        DependencyProperty.Register("SData", typeof(string), typeof(HexByte), new FrameworkPropertyMetadata(string.Empty, FrameworkPropertyMetadataOptions.BindsTwoWayByDefault, OnSDataChanged));
    private static void OnSDataChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
    {
        HexByte hexByte = (HexByte)d;
        //if (e.NewValue == null) return;
        string strHexData = (string)e.NewValue;
        char[] txtData = strHexData.ToCharArray();

        if (hexByte.DisplayMode == HexDisplayMode.HexString)
        {
            if (!txtData.All(char.IsAsciiHexDigit))
            {
                int charOffset = 0;
                int lenght = strHexData.Length;
                for (int i = 0; i < lenght; i++)
                {
                    char addedChar = strHexData[charOffset];
                    if (!char.IsAsciiHexDigit(addedChar))
                    {
                        string tempData = strHexData.Replace(addedChar.ToString(), "");
                        strHexData = tempData;
                        lenght--;
                    }
                    else
                        charOffset++;
                }
                hexByte.SData = strHexData.ToUpper();
            }
            if (!string.IsNullOrEmpty(hexByte.SData))
                hexByte.Data = Convert.ToByte(hexByte.SData, 16);
            else
                hexByte.Data = null;
        }
        else if (hexByte.DisplayMode == HexDisplayMode.AsciiString)
        {
            if (!string.IsNullOrEmpty(hexByte.SData))
                hexByte.Data = (byte)hexByte.SData[0];
            else
                hexByte.Data = null;
        }
        else if (hexByte.DisplayMode == HexDisplayMode.DecimalString)
        {
            if (!txtData.All(char.IsDigit))
            {
                int charOffset = 0;
                int lenght = strHexData.Length;
                for (int i = 0; i < lenght; i++)
                {
                    char addedChar = strHexData[charOffset];
                    if (!char.IsDigit(addedChar))
                    {
                        string tempData = strHexData.Replace(addedChar.ToString(), "");
                        strHexData = tempData;
                        lenght--;
                    }
                    else
                        charOffset++;
                }
                hexByte.SData = strHexData;
            }
            int tempdata = Convert.ToInt32(hexByte.SData, 10);
            if (tempdata < 0)
                hexByte.SData = "0";
            else if (tempdata > 255)
                hexByte.SData = "255";
            if (!string.IsNullOrEmpty(hexByte.SData))
                hexByte.Data = Convert.ToByte(hexByte.SData, 10);
            else
                hexByte.Data = null;
        }
        else if (hexByte.DisplayMode == HexDisplayMode.BinaryString)
        {
            if (!txtData.All(c => c == 0x30 || c == 0x31))
            {
                int charOffset = 0;
                int lenght = strHexData.Length;
                for (int i = 0; i < lenght; i++)
                {
                    char addedChar = strHexData[charOffset];
                    if (addedChar != 0x30 && addedChar != 0x31)
                    {
                        string tempData = strHexData.Replace(addedChar.ToString(), "");
                        strHexData = tempData;
                        lenght--;
                    }
                    else
                        charOffset++;
                }
                hexByte.SData = strHexData;
            }
            if (!string.IsNullOrEmpty(hexByte.SData))
                hexByte.Data = Convert.ToByte(hexByte.SData, 2);
            else
                hexByte.Data = null;
        }
    }


    public int DataLenght
    {
        get { return (int)GetValue(DataLenghtProperty); }
        set { SetValue(DataLenghtProperty, value); }
    }
    public static readonly DependencyProperty DataLenghtProperty =
        DependencyProperty.Register("DataLenght", typeof(int), typeof(HexByte), new FrameworkPropertyMetadata(2, FrameworkPropertyMetadataOptions.BindsTwoWayByDefault));

    public bool CanEdit
    {
        get { return (bool)GetValue(CanEditProperty); }
        set { SetValue(CanEditProperty, value); }
    }
    public static readonly DependencyProperty CanEditProperty =
        DependencyProperty.Register("CanEdit", typeof(bool), typeof(HexByte), new FrameworkPropertyMetadata(false, FrameworkPropertyMetadataOptions.BindsTwoWayByDefault));

    public bool EditMode
    {
        get { return (bool)GetValue(EditModeProperty); }
        set { SetValue(EditModeProperty, value); }
    }
    public static readonly DependencyProperty EditModeProperty =
        DependencyProperty.Register("EditMode", typeof(bool), typeof(HexByte), new FrameworkPropertyMetadata(false, FrameworkPropertyMetadataOptions.BindsTwoWayByDefault));

    protected override void OnPreviewMouseDoubleClick(MouseButtonEventArgs e)
    {
        base.OnPreviewMouseDoubleClick(e);
        if (CanEdit)
            EditMode = true;
    }
}
