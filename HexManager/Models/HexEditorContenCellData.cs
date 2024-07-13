using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace HexManager;

public class HexEditorContenCellData
{
    public HexEditorContenCellData()
    {
        
    }

    public int ColumnIndex { get; set; }
    public int RowIndex { get; set; }
    public int CellIndex { get; set; }
    public Point StartPoint { get; set; }
    public Point EndPoint { get; set; }
    public double ColumnWidth { get; set; }
    public double RowHeight { get; set; }
}
