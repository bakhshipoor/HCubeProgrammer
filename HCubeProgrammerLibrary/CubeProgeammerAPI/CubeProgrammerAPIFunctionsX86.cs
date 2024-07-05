using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using static HCubeProgrammerLibrary.CubeProgeammerAPI.CubeProgrammerAPIEnums;
using static HCubeProgrammerLibrary.CubeProgeammerAPI.CubeProgrammerAPIStructs;

namespace HCubeProgrammerLibrary.CubeProgeammerAPI;

public static partial class CubeProgrammerAPIFunctionsX86
{
    public const string Win32BitDLLFileName = "lib\\CubeProgrammerAPIx86.dll";
    
    #region 32Bit Operating System

    [DllImport(Win32BitDLLFileName, SetLastError = true)]
    internal static extern int GetLoadersPath(out IntPtr bLoaderPath);

    // STLINK functions
    [DllImport(Win32BitDLLFileName, SetLastError = true)]
    internal static extern int GetStLinkList(out IntPtr stLinkList, int shared);

    [DllImport(Win32BitDLLFileName, SetLastError = true)]
    internal static extern int GetStLinkEnumerationList(out IntPtr stlink_list, int shared);

    [DllImport(Win32BitDLLFileName, SetLastError = true)]
    internal static extern int ConnectStLink(DebugConnectParameters debugParameters);

    [DllImport(Win32BitDLLFileName, SetLastError = true)]
    internal static extern int Reset(DebugResetMode rstMode);

    // Bootloader functions
    [DllImport(Win32BitDLLFileName, SetLastError = true)]
    internal static extern int GetUsartList(IntPtr usartList);

    [DllImport(Win32BitDLLFileName, SetLastError = true)]
    internal static extern int ConnectUsartBootloader(USARTConnectParameters usartParameters);

    [DllImport(Win32BitDLLFileName, SetLastError = true)]
    internal static extern int SendByteUart(int sendByte);

    [DllImport(Win32BitDLLFileName, SetLastError = true)]
    internal static extern int GetDfuDeviceList(IntPtr dfuList, int iPID, int iVID);

    [DllImport(Win32BitDLLFileName, SetLastError = true)]
    internal static extern int ConnectDfuBootloader(IntPtr usbIndex);

    [DllImport(Win32BitDLLFileName, SetLastError = true)]
    internal static extern int ConnectDfuBootloader2(DFUConnectParameters dfuParameters);

    [DllImport(Win32BitDLLFileName, SetLastError = true)]
    internal static extern int ConnectSpiBootloader(SPIConnectParameters spiParameters);

    [DllImport(Win32BitDLLFileName, SetLastError = true)]
    internal static extern int ConnectCanBootloader(CANConnectParameters canParameters);

    [DllImport(Win32BitDLLFileName, SetLastError = true)]
    internal static extern int ConnectI2cBootloader(I2CConnectParameters i2cParameters);

    // General purposes functions
    [DllImport(Win32BitDLLFileName, SetLastError = true)]
    internal static extern void SetDisplayCallbacks(DisplayCallBacks c);

    [DllImport(Win32BitDLLFileName, SetLastError = true)]
    internal static extern void SetVerbosityLevel(int level);

    [DllImport(Win32BitDLLFileName, SetLastError = true)]
    internal static extern int CheckDeviceConnection();

    [DllImport(Win32BitDLLFileName, SetLastError = true)]
    internal static extern IntPtr GetDeviceGeneralInf();

    [DllImport(Win32BitDLLFileName, SetLastError = true)]
    internal static extern int ReadMemory(uint address, IntPtr data, uint size);

    [DllImport(Win32BitDLLFileName, SetLastError = true)]
    internal static extern int WriteMemory(uint address, IntPtr data, uint size);

    [DllImport(Win32BitDLLFileName, SetLastError = true)]
    internal static extern int EditSector(uint address, IntPtr data, uint size);

    [DllImport(Win32BitDLLFileName, SetLastError = true)]
    internal static extern int DownloadFile(IntPtr filePath, uint address, uint skipErase, uint verify, IntPtr binPath);

    [DllImport(Win32BitDLLFileName, SetLastError = true)]
    internal static extern int Execute(uint address);

    [DllImport(Win32BitDLLFileName, SetLastError = true)]
    internal static extern int MassErase(IntPtr sFlashMemName);

    [DllImport(Win32BitDLLFileName, SetLastError = true)]
    internal static extern int SectorErase(uint[] sectors, uint sectorNbr, IntPtr sFlashMemName);

    [DllImport(Win32BitDLLFileName, SetLastError = true)]
    internal static extern int ReadUnprotect();

    [DllImport(Win32BitDLLFileName, SetLastError = true)]
    internal static extern int TzenRegression();

    [DllImport(Win32BitDLLFileName, SetLastError = true)]
    internal static extern int GetTargetInterfaceType();

    [DllImport(Win32BitDLLFileName, SetLastError = true)]
    internal static extern IntPtr GetCancelPointer();

    [DllImport(Win32BitDLLFileName, SetLastError = true)]
    internal static extern IntPtr FileOpen([MarshalAs(UnmanagedType.LPWStr)] string filePath);

    [DllImport(Win32BitDLLFileName, SetLastError = true)]
    internal static extern void FreeFileData(IntPtr data);

    [DllImport(Win32BitDLLFileName, SetLastError = true)]
    internal static extern int Verify(IntPtr fileData, uint address);

    [DllImport(Win32BitDLLFileName, SetLastError = true)]
    internal static extern int SaveFileToFile(IntPtr fileData, IntPtr sFileName);

    [DllImport(Win32BitDLLFileName, SetLastError = true)]
    internal static extern int SaveMemoryToFile(int address, int size, IntPtr sFileName);

    [DllImport(Win32BitDLLFileName, SetLastError = true)]
    internal static extern void Disconnect();

    [DllImport(Win32BitDLLFileName, SetLastError = true)]
    internal static extern void DeleteInterfaceList();

    [DllImport(Win32BitDLLFileName, SetLastError = true)]
    internal static extern void AutomaticMode(IntPtr filePath, uint address, uint skipErase, uint verify, int isMassErase, IntPtr obCommand, int run);

    [DllImport(Win32BitDLLFileName, SetLastError = true)]
    internal static extern int GetStorageStructure(IntPtr deviceStorageStruct);

    // Option Bytes functions
    [DllImport(Win32BitDLLFileName, SetLastError = true)]
    internal static extern int SendOptionBytesCmd(IntPtr command);

    [DllImport(Win32BitDLLFileName, SetLastError = true)]
    internal static extern IntPtr InitOptionBytesInterface();

    [DllImport(Win32BitDLLFileName, SetLastError = true)]
    internal static extern IntPtr FastRomInitOptionBytesInterface(ushort deviceId);

    [DllImport(Win32BitDLLFileName, SetLastError = true)]
    internal static extern int ObDisplay();

    // Loaders functions
    [DllImport(Win32BitDLLFileName, SetLastError = true)]
    internal static extern void SetLoadersPath(IntPtr path);

    [DllImport(Win32BitDLLFileName, SetLastError = true)]
    internal static extern void SetExternalLoaderPath(IntPtr path, IntPtr externalLoaderInfo);

    [DllImport(Win32BitDLLFileName, SetLastError = true)]
    internal static extern int GetExternalLoaders(IntPtr path, IntPtr externalStorageNfo);

    [DllImport(Win32BitDLLFileName, SetLastError = true)]
    internal static extern void RemoveExternalLoader(IntPtr path);

    [DllImport(Win32BitDLLFileName, SetLastError = true)]
    internal static extern void DeleteLoaders();

    // STM32WB specific functions
    [DllImport(Win32BitDLLFileName, SetLastError = true)]
    internal static extern int GetUID64(IntPtr data);

    [DllImport(Win32BitDLLFileName, SetLastError = true)]
    internal static extern int FirmwareDelete();

    [DllImport(Win32BitDLLFileName, SetLastError = true)]
    internal static extern int FirmwareUpgrade(IntPtr filePath, uint address, uint firstInstall, uint startStack, uint verify);

    [DllImport(Win32BitDLLFileName, SetLastError = true)]
    internal static extern int StartWirelessStack();

    [DllImport(Win32BitDLLFileName, SetLastError = true)]
    internal static extern int UpdateAuthKey(IntPtr filePath);

    [DllImport(Win32BitDLLFileName, SetLastError = true)]
    internal static extern int AuthKeyLock();

    [DllImport(Win32BitDLLFileName, SetLastError = true)]
    internal static extern int WriteUserKey(IntPtr filePath, byte keyType);

    [DllImport(Win32BitDLLFileName, SetLastError = true)]
    internal static extern int AntiRollBack();

    [DllImport(Win32BitDLLFileName, SetLastError = true)]
    internal static extern int StartFus();

    [DllImport(Win32BitDLLFileName, SetLastError = true)]
    internal static extern int Unlockchip();

    // STM32MP specific functions
    [DllImport(Win32BitDLLFileName, SetLastError = true)]
    internal static extern int ProgramSsp(IntPtr sspFile, IntPtr licenseFile, IntPtr tfaFile, int hsmSlotId);

    // STM32 HSM specific functions
    [DllImport(Win32BitDLLFileName, SetLastError = true)]
    internal static extern IntPtr GetHsmFirmwareID(int hsmSlotId);

    [DllImport(Win32BitDLLFileName, SetLastError = true)]
    internal static extern ulong GetHsmCounter(int hsmSlotId);

    [DllImport(Win32BitDLLFileName, SetLastError = true)]
    internal static extern IntPtr GetHsmState(int hsmSlotId);

    [DllImport(Win32BitDLLFileName, SetLastError = true)]
    internal static extern IntPtr GetHsmVersion(int hsmSlotId);

    [DllImport(Win32BitDLLFileName, SetLastError = true)]
    internal static extern IntPtr GetHsmType(int hsmSlotId);

    [DllImport(Win32BitDLLFileName, SetLastError = true)]
    internal static extern int GetHsmLicense(int hsmSlotId, IntPtr outLicensePath);

    #endregion



}
