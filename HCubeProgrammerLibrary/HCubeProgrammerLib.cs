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

public class HCubeProgrammerLib
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

    [DllImport("D:\\6 Develope\\HCubeProgrammer\\STM32CubeProgrammerAPI\\lib\\CubeProgrammerAPIx64.dll")]
    public static extern int GetStLinkList(out IntPtr stLinkList, int shared);

    [DllImport("D:\\6 Develope\\HCubeProgrammer\\STM32CubeProgrammerAPI\\lib\\CubeProgrammerAPIx64.dll")]
    public static extern int GetLoadersPath(out IntPtr LoaderPath);

    

    //[StructLayout(LayoutKind.Sequential, Size = 4, CharSet = CharSet.Ansi)]
    //public struct EXCEPTION
    //{
    //    public int ErrorCode;
    //    [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 500)]
    //    public string Message;
    //}

    //[StructLayout(LayoutKind.Sequential, Size =312, CharSet = CharSet.Ansi)]
    //public struct debugConnectParameters
    //{
    //    public debugPort dbgPort;                  /**< Select the type of debug interface #debugPort. */
    //    public int index;                          /**< Select one of the debug ports connected. */
    //    [MarshalAs(UnmanagedType.ByValTStr,SizeConst =33)]
    //    public string serialNumber;              /**< ST-LINK serial number. */
    //    [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 20)]
    //    public string firmwareVersion;           /**< Firmware version. */
    //    [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 5)]
    //    public string targetVoltage;              /**< Operate voltage. */
    //    public int accessPortNumber;               /**< Number of available access port. */
    //    public int accessPort;                     /**< Select access port controller. */
    //    public debugConnectMode connectionMode;    /**< Select the debug CONNECT mode #debugConnectMode. */
    //    public debugResetMode resetMode;           /**< Select the debug RESET mode #debugResetMode. */
    //    public int isOldFirmware;                  /**< Check Old ST-LINK firmware version. */
    //    public Frequencies freq;                   /**< Supported frequencies #frequencies. */
    //    public int frequency;                      /**< Select specific frequency. */
    //    public int isBridge;                       /**< Indicates if it's Bridge device or not. */
    //    public int shared;                         /**< Select connection type, if it's shared, use ST-LINK Server. */
    //    [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 100)]
    //    public string board;                    /**< board Name */
    //    public int DBG_Sleep;
    //    public int speed;                   /**< Select speed flashing of Cortex M33 series. */
    //}

    //public enum debugPort : uint
    //{
    //    JTAG = 0,               /**< JTAG debug port. */
    //    SWD = 1,                /**< SWD debug port. */
    //}

    //[StructLayout(LayoutKind.Sequential, Size = 104, CharSet = CharSet.Ansi)]
    //public struct Frequencies
    //{
    //    [MarshalAs(UnmanagedType.ByValArray, ArraySubType = UnmanagedType.U4, SizeConst = 12)]
    //    public uint[] jtagFreq;          /**<  JTAG frequency. */
    //    public uint jtagFreqNumber;        /**<  Get JTAG supported frequencies. */
    //    [MarshalAs(UnmanagedType.ByValArray, ArraySubType = UnmanagedType.U4,SizeConst = 12)]
    //    public uint[] swdFreq;           /**<  SWD frequency. */
    //    public uint swdFreqNumber;         /**<  Get SWD supported frequencies. */
    //}

    //public enum debugConnectMode : uint
    //{
    //    NORMAL_MODE,            /**< Connect with normal mode, the target is reset then halted while the type of reset is selected using the [debugResetMode]. */
    //    HOTPLUG_MODE,           /**< Connect with hotplug mode,  this option allows the user to connect to the target without halt or reset. */
    //    UNDER_RESET_MODE,       /**< Connect with under reset mode, option allows the user to connect to the target using a reset vector catch before executing any instruction. */
    //    POWER_DOWN_MODE,        /**< Connect with power down mode. */
    //    PRE_RESET_MODE          /**< Connect with pre reset mode. */
    //}

    //public enum debugResetMode : uint
    //{
    //    SOFTWARE_RESET,         /**< Apply a reset by the software. */
    //    HARDWARE_RESET,         /**< Apply a reset by the hardware. */
    //    CORE_RESET              /**< Apply a reset by the internal core peripheral. */
    //}
}
