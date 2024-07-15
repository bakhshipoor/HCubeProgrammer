using HCubeProgrammerLibrary.FirmwareFileData;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HexManager.Models;

public class HexViewModel
{
    public HexViewModel()
    {
        DataFile = new();
        HexBytes = [];
    }

    public HexViewModel(FirmwareFile dataFile) : this()
    {
        DataFile = dataFile;
        foreach (FirmwareFileSegment itemSegment in DataFile.Segments)
        {
            if (itemSegment.Data == null) continue;
            int address = itemSegment.Address;
            for (int dataCounter = 0; dataCounter < itemSegment.Size; dataCounter++)
            {
                HexByteModel hexByte = new();
                hexByte.Address = address;
                hexByte.Data = itemSegment.Data[dataCounter];
                HexBytes.Add(hexByte);
                address++;
            }
        }
    }

    public FirmwareFile DataFile { get; set; }
    public ObservableCollection<HexByteModel> HexBytes {  get; set; }
}
