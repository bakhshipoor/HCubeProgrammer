using HCubeProgrammerLibrary.FirmwareFileData;
using HexManager.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace HexManager;


public class HexViewer : Control
{
    static HexViewer()
    {
        DefaultStyleKeyProperty.OverrideMetadata(typeof(HexViewer), new FrameworkPropertyMetadata(typeof(HexViewer)));
    }

    public HexViewer()
    {
        
    }

    


}
