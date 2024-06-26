using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using static HCubeProgrammerLibrary.CubeProgeammerAPI.CubeProgrammerAPIEnums;
using static HCubeProgrammerLibrary.CubeProgeammerAPI.CubeProgrammerAPIFunctions;

namespace HCubeProgrammerLibrary.CubeProgeammerAPI;

public static class CubeProgrammerAPIStructs
{

    // Bootloader Data Structures and Enumerations
    [StructLayout(LayoutKind.Sequential, Size = 224, CharSet = CharSet.Ansi)]
    public struct DFUDeviceInfo
    {
        /// <summary>
        /// USB index.
        /// </summary>
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 10)]
        public string usbIndex;
        /// <summary>
        /// Bus number.
        /// </summary>
        public int busNumber;
        /// <summary>
        /// Address number.
        /// </summary>
        public int addressNumber;
        /// <summary>
        /// Product number.
        /// </summary>
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 100)]
        public string productId;
        /// <summary>
        /// Serial number.
        /// </summary>
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 100)]
        public string serialNumber;
        /// <summary>
        /// DFU version.
        /// </summary>
        public uint dfuVersion;
    }

    [StructLayout(LayoutKind.Sequential, Size = 132, CharSet = CharSet.Ansi)]
    public struct USARTConnectParameters
    {
        /// <summary>
        /// Interface identifier: COM1, COM2, /dev/ttyS0...
        /// </summary>
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 100)]
        public string portName;
        /// <summary>
        /// Speed transmission: 115200, 9600...
        /// </summary>
        public uint baudrate;
        /// <summary>
        /// Parity bit: value in usartParity.
        /// </summary>
        public USARTParity parity;
        /// <summary>
        /// Data bit: value in {6, 7, 8}.
        /// </summary>
        public byte dataBits;
        /// <summary>
        /// Stop bit: value in {1, 1.5, 2}.
        /// </summary>
        public float stopBits;
        /// <summary>
        /// Flow control: value in usartFlowControl.
        /// </summary>
        public USARTFlowControl flowControl;
        /// <summary>
        /// RTS: Value in {0,1}.
        /// </summary>
        public int statusRTS;
        /// <summary>
        /// DTR: Value in {0,1}.
        /// </summary>
        public int statusDTR;
        /// <summary>
        /// Set No Init bits: value in {0,1}.
        /// </summary>
        public byte noinitBits;
        /// <summary>
        /// request a read unprotect: value in {0,1}.
        /// </summary>
        public char rdu;
        /// <summary>
        /// request a TZEN regression: value in {0,1}.
        /// </summary>
        public char tzenreg;
    }

    [StructLayout(LayoutKind.Sequential, Size = 12, CharSet = CharSet.Ansi)]
    public struct DFUConnectParameters
    {
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 10)]
        public string usb_index;
        /// <summary>
        /// request a read unprotect: value in {0,1}.
        /// </summary>
        public char rdu;
        /// <summary>
        /// request a TZEN regression: value in {0,1}.
        /// </summary>
        public char tzenreg;
    }

    [StructLayout(LayoutKind.Sequential, Size = 52, CharSet = CharSet.Ansi)]
    public struct SPIConnectParameters
    {
        /// <summary>
        /// Speed transmission 187, 375, 750, 1500, 3000, 6000, 12000 KHz.
        /// </summary>
        public uint baudrate;
        /// <summary>
        /// crc polynom value.
        /// </summary>
        public ushort crcPol;
        /// <summary>
        /// 2LFullDuplex/2LRxOnly/1LRx/1LTx.
        /// </summary>
        public int direction;
        /// <summary>
        /// 1Edge or 2Edge.
        /// </summary>
        public int cpha;
        /// <summary>
        /// LOW or HIGH.
        /// </summary>
        public int cpol;
        /// <summary>
        /// DISABLE or ENABLE.
        /// </summary>
        public int crc;
        /// <summary>
        /// First bit: LSB or MSB.
        /// </summary>
        public int firstBit;
        /// <summary>
        /// Frame format: Motorola or TI.
        /// </summary>
        public int frameFormat;
        /// <summary>
        /// Size of frame data: 16bit or 8bit .
        /// </summary>
        public int dataSize;
        /// <summary>
        /// Operating mode: Slave or Master.
        /// </summary>
        public int mode;
        /// <summary>
        /// Selection: Soft or Hard.
        /// </summary>
        public int nss;
        /// <summary>
        /// NSS pulse: No Pulse or Pulse.
        /// </summary>
        public int nssPulse;
        /// <summary>
        /// Delay of few microseconds, No Delay or Delay, at least 4us delay is inserted
        /// </summary>
        public int delay;
    }

    [StructLayout(LayoutKind.Sequential, Size = 36, CharSet = CharSet.Ansi)]
    public struct CANConnectParameters
    {
        /// <summary>
        /// Baudrate and speed transmission 125KHz, 250KHz, 500KHz...
        /// </summary>
        public int br;
        /// <summary>
        /// CAN mode: NORMAL, LOOPBACK...,
        /// </summary>
        public int mode;
        /// <summary>
        /// CAN type: STANDARD or EXTENDED.
        /// </summary>
        public int ide;
        /// <summary>
        /// Frame format: DATA or REMOTE.
        /// </summary>
        public int rtr;
        /// <summary>
        /// Memory of received messages: FIFO0 or FIFO1.
        /// </summary>
        public int fifo;
        /// <summary>
        /// Filter mode: MASK or LIST.
        /// </summary>
        public int fm;
        /// <summary>
        /// Filter scale: 16 or 32.
        /// </summary>
        public int fs;
        /// <summary>
        /// Filter activation: DISABLE or ENABLE.
        /// </summary>
        public int fe;
        /// <summary>
        /// Filter bank number: 0 to 13.
        /// </summary>
        public char fbn;
    }

    [StructLayout(LayoutKind.Sequential, Size = 36, CharSet = CharSet.Ansi)]
    public struct I2CConnectParameters
    {
        /// <summary>
        /// Device address in hex format.
        /// </summary>
        public int add;
        /// <summary>
        /// Baudrate and speed transmission : 100 or 400 KHz.
        /// </summary>
        public int br;
        /// <summary>
        /// Speed Mode: STANDARD or FAST.
        /// </summary>
        public int sm;
        /// <summary>
        /// Address Mode: 7 or 10 bits.
        /// </summary>
        public int am;
        /// <summary>
        /// Analog filter: DISABLE or ENABLE.
        /// </summary>
        public int af;
        /// <summary>
        /// Digital filter: DISABLE or ENABLE.
        /// </summary>
        public int df;
        /// <summary>
        /// Digital noise filter: 0 to 15.
        /// </summary>
        public char dnf;
        /// <summary>
        /// Rise time: 0-1000 for STANDARD speed mode and  0-300 for FAST.
        /// </summary>
        public int rt;
        /// <summary>
        /// Fall time: 0-300 for STANDARD speed mode and  0-300 for FAST.
        /// </summary>
        public int ft;
    }

    // STLINK Data Structures and Enumerations
    [StructLayout(LayoutKind.Sequential, Size = 104, CharSet = CharSet.Ansi)]
    public struct Frequencies
    {
        /// <summary>
        /// JTAG frequency.
        /// </summary>
        [MarshalAs(UnmanagedType.ByValArray, ArraySubType = UnmanagedType.U4, SizeConst = 12)]
        public uint[] jtagFreq;
        /// <summary>
        /// Get JTAG supported frequencies.
        /// </summary>
        public uint jtagFreqNumber;
        /// <summary>
        /// SWD frequency.
        /// </summary>
        [MarshalAs(UnmanagedType.ByValArray, ArraySubType = UnmanagedType.U4, SizeConst = 12)]
        public uint[] swdFreq;
        /// <summary>
        /// Get SWD supported frequencies.
        /// </summary>
        public uint swdFreqNumber;
    }

    [StructLayout(LayoutKind.Sequential, Size = 312, CharSet = CharSet.Ansi)]
    public struct DebugConnectParameters
    {
        /// <summary>
        /// Select the type of debug interface #debugPort.
        /// </summary>
        public DebugPort dbgPort;
        /// <summary>
        /// Select one of the debug ports connected.
        /// </summary>
        public int index;
        /// <summary>
        /// ST-LINK serial number.
        /// </summary>
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 33)]
        public string serialNumber;
        /// <summary>
        /// Firmware version.
        /// </summary>
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 20)]
        public string firmwareVersion;
        /// <summary>
        /// Operate voltage.
        /// </summary>
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 5)]
        public string targetVoltage;
        /// <summary>
        /// Number of available access port.
        /// </summary>
        public int accessPortNumber;
        /// <summary>
        /// Select access port controller.
        /// </summary>
        public int accessPort;
        /// <summary>
        /// Select the debug CONNECT mode #debugConnectMode.
        /// </summary>
        public DebugConnectMode connectionMode;
        /// <summary>
        /// Select the debug RESET mode #debugResetMode.
        /// </summary>
        public DebugResetMode resetMode;
        /// <summary>
        /// Check Old ST-LINK firmware version.
        /// </summary>
        public int isOldFirmware;
        /// <summary>
        /// Supported frequencies #frequencies.
        /// </summary>
        public Frequencies freq;
        /// <summary>
        /// Select specific frequency.
        /// </summary>
        public int frequency;
        /// <summary>
        /// Indicates if it's Bridge device or not.
        /// </summary>
        public int isBridge;
        /// <summary>
        /// Select connection type, if it's shared, use ST-LINK Server.
        /// </summary>
        public int shared;
        /// <summary>
        /// Board Name
        /// </summary>
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 100)]
        public string board;
        public int DBG_Sleep;
        /// <summary>
        /// Select speed flashing of Cortex M33 series.
        /// </summary>
        public int speed;
    }

    // General Data Structures and Enumerations
    [StructLayout(LayoutKind.Sequential, Size = 24, CharSet = CharSet.Ansi)]
    public struct DisplayCallBacks
    {
        /// <summary>
        /// Add a progress bar.
        /// </summary>
        public InitialProgressBar InitialProgressBar;
        /// <summary>
        /// Display internal messages according to verbosity level.
        /// </summary>
        public DisplayMessage DisplayMessage;
        /// <summary>
        /// Display the loading of read/write process.
        /// </summary>
        public LoadProgressBar LoadProgressBar;
    }

    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
    public struct SegmentData_C
    {
        /// <summary>
        /// Segment start address.
        /// </summary>
        public int address;
        /// <summary>
        /// Memory segment size.
        /// </summary>
        public int size;
        /// <summary>
        /// Memory segment data.
        /// </summary>
        public IntPtr data; // byte*
    }

    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
    public struct FileData_C
    {
        /// <summary>
        /// File extension type.
        /// </summary>
        public int Type;
        /// <summary>
        /// Number of required segments.
        /// </summary>
        public int segmentsNbr;
        /// <summary>
        /// Segments description.
        /// </summary>
        public IntPtr segments; // SegmentData_C*
    }

    [StructLayout(LayoutKind.Sequential, Size = 496, CharSet = CharSet.Ansi)]
    public struct GgeneralInf
    {
        /// <summary>
        /// Device ID.
        /// </summary>
        public ushort deviceId;
        /// <summary>
        /// Flash memory size.
        /// </summary>
        public int flashSize;
        /// <summary>
        /// Bootloader version
        /// </summary>
        public int bootloaderVersion;
        /// <summary>
        /// Device MCU or MPU.
        /// </summary>
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 4)]
        public string type;
        /// <summary>
        /// Cortex CPU.
        /// </summary>
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 20)]
        public string cpu;
        /// <summary>
        /// Device name.
        /// </summary>
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 100)]
        public string name;
        /// <summary>
        /// Device serie.
        /// </summary>
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 100)]
        public string series;
        /// <summary>
        /// Take notice.
        /// </summary>
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 150)]
        public string description;
        /// <summary>
        /// Revision ID.
        /// </summary>
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 8)]
        public string revisionId;
        /// <summary>
        /// Board Rpn.
        /// </summary>
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 100)]
        public string board;
    }


    // Loaders Data Structures
    [StructLayout(LayoutKind.Sequential, Size = 8, CharSet = CharSet.Ansi)]
    public struct DeviceSector
    {
        /// <summary>
        /// Number of Sectors
        /// </summary>
        public uint sectorNum;
        /// <summary>
        /// Sector Size in BYTEs.
        /// </summary>
        public uint sectorSize;
    }

    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
    public struct ExternalLoader
    {
        /// <summary>
        /// FlashLoader file path.
        /// </summary>
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 200)]
        public string filePath;
        /// <summary>
        /// Device Name and Description.
        /// </summary>
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 100)]
        public string deviceName;
        /// <summary>
        /// Device Type: ONCHIP, EXT8BIT, EXT16BIT, ...
        /// </summary>
        public int deviceType;
        /// <summary>
        /// Default Device Start Address.
        /// </summary>
        public uint deviceStartAddress;
        /// <summary>
        /// Total Size of Device.
        /// </summary>
        public uint deviceSize;
        /// <summary>
        /// Programming Page Size.
        /// </summary>
        public uint pageSize;
        // Content of Erased Memory.
        //public byte EraseValue;
        /// <summary>
        /// Type number.
        /// </summary>
        public uint sectorsTypeNbr;
        /// <summary>
        /// Device sectors.
        /// </summary>
        public IntPtr sectors; // DeviceSector*
    }

    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
    public struct ExternalStorageInfo
    {
        public uint externalLoaderNbr;
        public IntPtr externalLoader; // ExternalLoader*
    }

}
