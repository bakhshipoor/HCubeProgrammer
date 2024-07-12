using System.Windows;

namespace HexManager;

public class HexEditorContenColumnData
{
    public HexEditorContenColumnData()
    {
        
    }

    public int ColumnIndex {  get; set; }
    public Point StartPoint {  get; set; }
    public Point EndPoint { get; set; }
    public double ColumnWidth {  get; set; }
    public double ColumnHeight { get; set; }
}
