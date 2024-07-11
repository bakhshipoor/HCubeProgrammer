using HCubeProgrammerLibrary;
using HexManager;
using HexManager.Models;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace HCubeProgrammer;

public partial class MainWindow : Window
{
    
    public MainWindow()
    {
        DataContext = this;

        InitializeComponent();

        Loaded += MainWindow_Loaded;

        
        


    }

    private void MainWindow_Loaded(object sender, RoutedEventArgs e)
    {
        //HWFile.DataFile = hCube.DataFile;

    }

   
    public HCubeProgrammerLib hCube { get; set; } = new();
}

