using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace HexManager;

public class HexEditorContent : Control
{
    static HexEditorContent()
    {
        DefaultStyleKeyProperty.OverrideMetadata(typeof(HexEditorContent), new FrameworkPropertyMetadata(typeof(HexEditorContent)));
    }
}
