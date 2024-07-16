using HexManager.EventArgs;
using System.Data;
using System.Globalization;
using System.Reflection.PortableExecutable;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Media;
using static System.Net.Mime.MediaTypeNames;

namespace HexManager;

[TemplatePart(Name = ElementHexEditorContentDataHeaderColumns, Type = typeof(HexEditorContentDataHeaderColumns))]
[TemplatePart(Name = ElementHexEditorContentData, Type = typeof(HexEditorContentData))]
public class HexEditorContent : Control
{
    private const string ElementHexEditorContentDataHeaderColumns = "PART_DataHeader";
    private const string ElementHexEditorContentData = "PART_ContentData";

    public StackPanel Contents { get; set; }

    static HexEditorContent()
    {
        DefaultStyleKeyProperty.OverrideMetadata(typeof(HexEditorContent), new FrameworkPropertyMetadata(typeof(HexEditorContent)));
    }

    public HexEditorContent()
    {
        SnapsToDevicePixels = true;
        HeaderColumns = [];
        Contents = new();

        DataHeaderColumns = new();
        ContentData = new();
        
        

        Loaded -= HexEditorContent_Loaded;
        Loaded += HexEditorContent_Loaded;
    }

    private void HexEditorContent_Loaded(object sender, RoutedEventArgs e)
    {
        if (sender != null && sender is HexEditorContent && _TemplateLoaded && ParentHexEditor != null)
        {
            //ContentData._ParentHexEditor = ParentHexEditor;
            double totalColumnsWidth = 0.0;
            for (int itemColumn = 0; itemColumn < ParentHexEditor.NumberOfColumns; itemColumn++)
            {
                HexEditorContentDataHeaderColumn column = new();
                column.ParentHexEditor = ParentHexEditor;
                column.ParentHeaderColumns = DataHeaderColumns;
                column.Text = $"{itemColumn:X2}";
                column.ColumnIndex = itemColumn;
                column.Width = ClaculateTextSize(column.Text).Width+4;
                totalColumnsWidth += column.Width;
                column.Height = ParentHexEditor.DataHeaderHeight;
                column.StartPoint = new Point(totalColumnsWidth- column.Width,0);
                column.EndPoint = new Point(totalColumnsWidth, column.Height);
                DataHeaderColumns.AddChild(column);
                HeaderColumns.Add(column);
            }
            if (!DataHeaderVisibility)
                ContentData.Width = totalColumnsWidth;
            ContentData.ParentHexEditorContent = this;
            _IsLoaded = true;
        }
    }

    public override void OnApplyTemplate()
    {
        base.OnApplyTemplate();
        DataHeaderColumns = (HexEditorContentDataHeaderColumns)GetTemplateChild(ElementHexEditorContentDataHeaderColumns);
        ContentData = (HexEditorContentData)GetTemplateChild(ElementHexEditorContentData);
        if (DataHeaderColumns != null && ContentData != null)
        {
            _TemplateLoaded = true;
        }
    }

    private bool _TemplateLoaded;
    private bool _IsLoaded;

    
    public HexEditorContentDataHeaderColumns DataHeaderColumns { get; set; }
    public HexEditorContentData ContentData { get; set; }
    public HexEditor? ParentHexEditor { get; set; }
    public List<HexEditorContentDataHeaderColumn> HeaderColumns { get; set; }

    public string TypeHeaderText
    {
        get { return (string)GetValue(TypeHeaderTextProperty); }
        set { SetValue(TypeHeaderTextProperty, value); }
    }
    public static readonly DependencyProperty TypeHeaderTextProperty =
        DependencyProperty.Register("TypeHeaderText", typeof(string), typeof(HexEditorContent), new PropertyMetadata("Hex Values"));

    public bool TypeHeadearVisibility
    {
        get { return (bool)GetValue(TypeHeadearVisibilityProperty); }
        set { SetValue(TypeHeadearVisibilityProperty, value); }
    }
    public static readonly DependencyProperty TypeHeadearVisibilityProperty =
        DependencyProperty.Register("TypeHeadearVisibility", typeof(bool), typeof(HexEditorContent), new FrameworkPropertyMetadata(false));

    public bool DataHeaderVisibility
    {
        get { return (bool)GetValue(DataHeaderVisibilityProperty); }
        set { SetValue(DataHeaderVisibilityProperty, value); }
    }
    public static readonly DependencyProperty DataHeaderVisibilityProperty =
        DependencyProperty.Register("DataHeaderVisibility", typeof(bool), typeof(HexEditorContent), new PropertyMetadata(false));

    
    private Size ClaculateTextSize(string text)
    {
        var typeface = new Typeface("Segoe UI");
        var formattedText = new FormattedText(text, CultureInfo.InvariantCulture, FlowDirection.LeftToRight,
                typeface, 12, Brushes.Black, VisualTreeHelper.GetDpi(this).PixelsPerDip);
        return new Size(formattedText.Width, formattedText.Height);
    }

}
