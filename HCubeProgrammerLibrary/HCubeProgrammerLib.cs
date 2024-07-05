using HCubeProgrammerLibrary.CubeProgeammerAPI;
using HCubeProgrammerLibrary.FirmwareFileData;
using HCubeProgrammerLibrary.STLink;
using System.Collections.ObjectModel;
using System.IO;
using System.Runtime.InteropServices;
using static HCubeProgrammerLibrary.CubeProgeammerAPI.CubeProgrammerAPIFunctionsEx;
using static HCubeProgrammerLibrary.CubeProgeammerAPI.CubeProgrammerAPIFunctionsX64;
using static HCubeProgrammerLibrary.CubeProgeammerAPI.CubeProgrammerAPIFunctionsX86;
using static HCubeProgrammerLibrary.CubeProgeammerAPI.CubeProgrammerAPIStructs;

namespace HCubeProgrammerLibrary;

public partial class HCubeProgrammerLib
{
    public ObservableCollection<STLinkDevice> STLinkDevices { get; set; }
    public HCubeProgrammerLib()
    {
        if (Environment.Is64BitOperatingSystem)
        {
            if (File.Exists(Win64BitDLLFileName))
            {
                IsValidDLLFile = true;
                Is64BitOperatingSystem = true;
            }
        }
        else
        {
            if (File.Exists(Win32BitDLLFileName))
            {
                IsValidDLLFile = true;
                Is64BitOperatingSystem = false;
            }
        }

        STLinkDevices = [];

        int shared = 0;
        GetSTLinkDevices(shared);

        //IntPtr xc = IntPtr.Zero;
        //int iss = GetLoadersPath(out xc);
        //if (xc != IntPtr.Zero)
        //{
        //    string? currentItem2 = Marshal.PtrToStringAnsi(xc);
        //}

        
        FirmwareFile? firmwareFile = OpenFirmwareFile(@"D:\1 Electronic\Electric Fireplace\Codes\Touch-Panel-V6.1\Release\Touch-Panel-V6.1.elf");

    }

    public void GetSTLinkDevices(int shared)
    {
        STLinkDevices = [.. GetStLinkEnumerationList(shared)];
    }


}
