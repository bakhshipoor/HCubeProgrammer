using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace HexManager;

public class HexEditor : DataGrid
{
    static HexEditor()
    {
        DefaultStyleKeyProperty.OverrideMetadata(typeof(HexEditor), new FrameworkPropertyMetadata(typeof(HexEditor)));
    }

    public HexEditor()
    {
        
    }
}
