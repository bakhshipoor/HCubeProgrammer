using System.IO;
using System.Runtime.InteropServices;
using static HCubeProgrammerLibrary.CubeProgeammerAPI.CubeProgrammerAPIFunctions;
using static HCubeProgrammerLibrary.CubeProgeammerAPI.CubeProgrammerAPIStructs;

namespace HCubeProgrammerLibrary;

public partial class HCubeProgrammerLib
{
    public HCubeProgrammerLib()
    {
        if (Environment.Is64BitOperatingSystem)
        {
            if (File.Exists(Win64BitDLLFileName))
            {
                IsValidDLLFile = true;
                ValidDLLFileName = Win64BitDLLFileName;
            }
        }
        else
        {
            if (File.Exists(Win32BitDLLFileName))
            {
                IsValidDLLFile = true;
                ValidDLLFileName = Win32BitDLLFileName;
            }
        }


        IntPtr stLinkList = new();
        int x1 = GetStLinkList(out stLinkList,0);
        if (stLinkList != IntPtr.Zero)
        {
            var size = Marshal.SizeOf<DebugConnectParameters>();
            for (var i = 0; i < x1; i++)
            {
                DebugConnectParameters currentItem = Marshal.PtrToStructure<DebugConnectParameters>(stLinkList + (i * size));
                Marshal.DestroyStructure<DebugConnectParameters>(stLinkList + (i * size));
            }
        }
        IntPtr xc = IntPtr.Zero;
        int iss = GetLoadersPath(out xc);
        if (xc != IntPtr.Zero)
        {
            string? currentItem2 = Marshal.PtrToStringAnsi(xc);
        }

        
    }


}
