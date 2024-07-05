using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using static HCubeProgrammerLibrary.CubeProgeammerAPI.CubeProgrammerAPIStructs;

namespace HCubeProgrammerLibrary.FirmwareFileData;

public class FirmwareFile
{
    public FirmwareFile()
    {
        Segments = [];
    }

    public FirmwareFile(FileData_C fileData_C) : this()
    {
        Type = fileData_C.Type;
        NumberOfSegments = fileData_C.segmentsNbr;
        int sizeOfCurrentSegment = 0;
        for (int segmentsCounter = 0; segmentsCounter < NumberOfSegments; segmentsCounter++)
        {
            if (fileData_C.segments != IntPtr.Zero)
            {
                SegmentData_C segmentdata = Marshal.PtrToStructure<SegmentData_C>(fileData_C.segments + (segmentsCounter * sizeOfCurrentSegment));
                FirmwareFileSegment fileSegemnt = new(segmentdata);
                Segments.Add(fileSegemnt);
                sizeOfCurrentSegment = segmentdata.size + sizeof(int) + sizeof(int);
            }
        }
    }

    public int Type {  get; set; }
    public int NumberOfSegments {  get; set; }
    public List<FirmwareFileSegment> Segments { get; set; }
}
