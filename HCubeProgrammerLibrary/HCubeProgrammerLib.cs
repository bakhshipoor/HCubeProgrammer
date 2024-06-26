using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Shapes;
using static HCubeProgrammerLibrary.CubeProgeammerAPI.CubeProgrammerAPIEnums;
using static HCubeProgrammerLibrary.CubeProgeammerAPI.CubeProgrammerAPIStructs;
using static HCubeProgrammerLibrary.HCubeProgrammerLib;

namespace HCubeProgrammerLibrary;

public partial class HCubeProgrammerLib
{
    public HCubeProgrammerLib()
    {
        
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

        int iss = GetLoadersPath(out IntPtr xc);
        if (xc != IntPtr.Zero)
        {
            string? currentItem2 = Marshal.PtrToStringAnsi(xc);
        }

        
    }

    [LibraryImport("D:\\6 Develope\\HCubeProgrammer\\STM32CubeProgrammerAPI\\lib\\CubeProgrammerAPIx64.dll")]
    public static partial int GetStLinkList(out IntPtr stLinkList, int shared);

    [LibraryImport("D:\\6 Develope\\HCubeProgrammer\\STM32CubeProgrammerAPI\\lib\\CubeProgrammerAPIx64.dll")]
    public static partial int GetLoadersPath(out IntPtr LoaderPath);

}
