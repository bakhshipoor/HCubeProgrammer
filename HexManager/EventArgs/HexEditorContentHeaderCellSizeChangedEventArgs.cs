using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls.Primitives;

namespace HexManager.EventArgs;

public delegate void HeaderCellSizeEventHandler(object sender, HexEditorContentHeaderCellSizeChangedEventArgs e);

public class HexEditorContentHeaderCellSizeChangedEventArgs : RoutedEventArgs
{
    
    public HexEditorContentHeaderCellSizeChangedEventArgs(HexEditorContenColumnData columnData) : base()
    {
        _ColumnData = columnData;
        RoutedEvent = HexEditorContentHeaderCell.HeaderCellSizeChangedEvent;
    }

    public HexEditorContenColumnData ColumnData
    {
        get { return _ColumnData; }
    }

    protected override void InvokeEventHandler(Delegate genericHandler, object genericTarget)
    {
        HeaderCellSizeEventHandler handler = (HeaderCellSizeEventHandler)genericHandler;
        handler(genericTarget, this);
    }

    private HexEditorContenColumnData _ColumnData;
}
