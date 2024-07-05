using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace HexManager;

public class CharToHexConverter : IValueConverter
{
    public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
    {
        string hexValue = string.Empty;
        if (value!=null && value is char)
        {
            char val = (char)value;
            hexValue = string.Format("{0:X2}", (byte)val);
        }
        return hexValue;
    }

    public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
    {
        return value;
    }
}
