using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using static HCubeProgrammerLibrary.CubeProgeammerAPI.CubeProgrammerAPIStructs;

namespace HCubeProgrammerLibrary.FirmwareFileData;

public class FirmwareFileSegment
{
    public FirmwareFileSegment()
    {
        
    }

    public FirmwareFileSegment(SegmentData_C segmentData_C) : this()
    {
        Address = segmentData_C.address;
        Size = segmentData_C.size;
        Data = new byte[Size];
        Marshal.Copy(segmentData_C.data, Data, 0, Size);
    }

    public int Address { get; set; }
    public int Size { get; set; }
    public byte[]? Data { get; set; }
}
