using HexManager.Helpers;
using HexManager.Models;
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

    public HexByte(HexByteModel hexByteModel) : this()
    {
        HexByteData = hexByteModel;
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
        
    }

    private void TxtHexData_LostKeyboardFocus(object sender, KeyboardFocusChangedEventArgs e)
    {
        
    }

    private void TxtHexData_LostFocus(object sender, RoutedEventArgs e)
    {
        
    }

    protected override void OnPreviewMouseDoubleClick(MouseButtonEventArgs e)
    {
        base.OnPreviewMouseDoubleClick(e);
       
    }

    public HexByteModel HexByteData
    {
        get { return (HexByteModel)GetValue(HexByteDataProperty); }
        set { SetValue(HexByteDataProperty, value); }
    }
    public static readonly DependencyProperty HexByteDataProperty =
        DependencyProperty.Register("HexByteData", typeof(HexByteModel), typeof(HexByte), new FrameworkPropertyMetadata(new HexByteModel(),FrameworkPropertyMetadataOptions.BindsTwoWayByDefault));


}
