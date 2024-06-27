using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using static HCubeProgrammerLibrary.CubeProgeammerAPI.CubeProgrammerAPIEnums;
using static HCubeProgrammerLibrary.CubeProgeammerAPI.CubeProgrammerAPIStructs;

namespace HCubeProgrammerLibrary.CubeProgeammerAPI;

public static partial class CubeProgrammerAPIFunctions
{
    public const string Win64BitDLLFileName = "lib\\CubeProgrammerAPIx64.dll";
    public const string Win32BitDLLFileName = "lib\\CubeProgrammerAPIx86.dll";
    public static bool IsValidDLLFile { get; set; } = false;
    public static string ValidDLLFileName { get; set; } = string.Empty;

    #region 64Bit Operating System

    [DllImport(Win64BitDLLFileName, SetLastError = true)]
    public static extern int GetLoadersPath(out IntPtr bLoaderPath);

    // STLINK functions
    [DllImport(Win64BitDLLFileName, SetLastError = true)]
    public static extern int GetStLinkList(out IntPtr stLinkList, int shared);

    [DllImport(Win64BitDLLFileName, SetLastError = true)]
    public static extern int GetStLinkEnumerationList(IntPtr stlink_list, int shared);

    [DllImport(Win64BitDLLFileName, SetLastError = true)]
    public static extern int ConnectStLink(DebugConnectParameters debugParameters);

    [DllImport(Win64BitDLLFileName, SetLastError = true)]
    public static extern int Reset(DebugResetMode rstMode);

    // Bootloader functions
    [DllImport(Win64BitDLLFileName, SetLastError = true)]
    public static extern int GetUsartList(IntPtr usartList);

    [DllImport(Win64BitDLLFileName, SetLastError = true)]
    public static extern int ConnectUsartBootloader(USARTConnectParameters usartParameters);

    [DllImport(Win64BitDLLFileName, SetLastError = true)]
    public static extern int SendByteUart(int sendByte);

    [DllImport(Win64BitDLLFileName, SetLastError = true)]
    public static extern int GetDfuDeviceList(IntPtr dfuList, int iPID, int iVID);

    [DllImport(Win64BitDLLFileName, SetLastError = true)]
    public static extern int ConnectDfuBootloader(IntPtr usbIndex);

    [DllImport(Win64BitDLLFileName, SetLastError = true)]
    public static extern int ConnectDfuBootloader2(DFUConnectParameters dfuParameters);

    [DllImport(Win64BitDLLFileName, SetLastError = true)]
    public static extern int ConnectSpiBootloader(SPIConnectParameters spiParameters);

    [DllImport(Win64BitDLLFileName, SetLastError = true)]
    public static extern int ConnectCanBootloader(CANConnectParameters canParameters);

    [DllImport(Win64BitDLLFileName, SetLastError = true)]
    public static extern int ConnectI2cBootloader(I2CConnectParameters i2cParameters);

    // General purposes functions
    [DllImport(Win64BitDLLFileName, SetLastError = true)]
    public static extern void SetDisplayCallbacks(DisplayCallBacks c);

    [DllImport(Win64BitDLLFileName, SetLastError = true)]
    public static extern void SetVerbosityLevel(int level);

    [DllImport(Win64BitDLLFileName, SetLastError = true)]
    public static extern int CheckDeviceConnection();

    [DllImport(Win64BitDLLFileName, SetLastError = true)]
    public static extern IntPtr GetDeviceGeneralInf();

    [DllImport(Win64BitDLLFileName, SetLastError = true)]
    public static extern int ReadMemory(uint address, IntPtr data, uint size);

    [DllImport(Win64BitDLLFileName, SetLastError = true)]
    public static extern int WriteMemory(uint address, IntPtr data, uint size);

    [DllImport(Win64BitDLLFileName, SetLastError = true)]
    public static extern int EditSector(uint address, IntPtr data, uint size);

    [DllImport(Win64BitDLLFileName, SetLastError = true)]
    public static extern int DownloadFile(IntPtr filePath, uint address, uint skipErase, uint verify, IntPtr binPath);

    [DllImport(Win64BitDLLFileName, SetLastError = true)]
    public static extern int Execute(uint address);

    [DllImport(Win64BitDLLFileName, SetLastError = true)]
    public static extern int MassErase(IntPtr sFlashMemName);

    [DllImport(Win64BitDLLFileName, SetLastError = true)]
    public static extern int SectorErase(uint[] sectors, uint sectorNbr, IntPtr sFlashMemName);

    [DllImport(Win64BitDLLFileName, SetLastError = true)]
    public static extern int ReadUnprotect();

    [DllImport(Win64BitDLLFileName, SetLastError = true)]
    public static extern int TzenRegression();

    [DllImport(Win64BitDLLFileName, SetLastError = true)]
    public static extern int GetTargetInterfaceType();

    [DllImport(Win64BitDLLFileName, SetLastError = true)]
    public static extern IntPtr GetCancelPointer();

    [DllImport(Win64BitDLLFileName, SetLastError = true)]
    public static extern IntPtr FileOpen(IntPtr filePath);

    [DllImport(Win64BitDLLFileName, SetLastError = true)]
    public static extern void FreeFileData(IntPtr data);

    [DllImport(Win64BitDLLFileName, SetLastError = true)]
    public static extern int Verify(IntPtr fileData, uint address);

    [DllImport(Win64BitDLLFileName, SetLastError = true)]
    public static extern int SaveFileToFile(IntPtr fileData, IntPtr sFileName);

    [DllImport(Win64BitDLLFileName, SetLastError = true)]
    public static extern int SaveMemoryToFile(int address, int size, IntPtr sFileName);

    [DllImport(Win64BitDLLFileName, SetLastError = true)]
    public static extern void Disconnect();

    [DllImport(Win64BitDLLFileName, SetLastError = true)]
    public static extern void DeleteInterfaceList();

    [DllImport(Win64BitDLLFileName, SetLastError = true)]
    public static extern void AutomaticMode(IntPtr filePath, uint address, uint skipErase, uint verify, int isMassErase, IntPtr obCommand, int run);

    [DllImport(Win64BitDLLFileName, SetLastError = true)]
    public static extern int GetStorageStructure(IntPtr deviceStorageStruct);

    // Option Bytes functions
    [DllImport(Win64BitDLLFileName, SetLastError = true)]
    public static extern int SendOptionBytesCmd(IntPtr command);

    [DllImport(Win64BitDLLFileName, SetLastError = true)]
    public static extern IntPtr InitOptionBytesInterface();

    [DllImport(Win64BitDLLFileName, SetLastError = true)]
    public static extern IntPtr FastRomInitOptionBytesInterface(ushort deviceId);

    [DllImport(Win64BitDLLFileName, SetLastError = true)]
    public static extern int ObDisplay();

    // Loaders functions
    [DllImport(Win64BitDLLFileName, SetLastError = true)]
    public static extern void SetLoadersPath(IntPtr path);

    [DllImport(Win64BitDLLFileName, SetLastError = true)]
    public static extern void SetExternalLoaderPath(IntPtr path, IntPtr externalLoaderInfo);

    [DllImport(Win64BitDLLFileName, SetLastError = true)]
    public static extern int GetExternalLoaders(IntPtr path, IntPtr externalStorageNfo);

    [DllImport(Win64BitDLLFileName, SetLastError = true)]
    public static extern void RemoveExternalLoader(IntPtr path);

    [DllImport(Win64BitDLLFileName, SetLastError = true)]
    public static extern void DeleteLoaders();

    // STM32WB specific functions
    [DllImport(Win64BitDLLFileName, SetLastError = true)]
    public static extern int GetUID64(IntPtr data);

    [DllImport(Win64BitDLLFileName, SetLastError = true)]
    public static extern int FirmwareDelete();

    [DllImport(Win64BitDLLFileName, SetLastError = true)]
    public static extern int FirmwareUpgrade(IntPtr filePath, uint address, uint firstInstall, uint startStack, uint verify);

    [DllImport(Win64BitDLLFileName, SetLastError = true)]
    public static extern int StartWirelessStack();

    [DllImport(Win64BitDLLFileName, SetLastError = true)]
    public static extern int UpdateAuthKey(IntPtr filePath);

    [DllImport(Win64BitDLLFileName, SetLastError = true)]
    public static extern int AuthKeyLock();

    [DllImport(Win64BitDLLFileName, SetLastError = true)]
    public static extern int WriteUserKey(IntPtr filePath, byte keyType);

    [DllImport(Win64BitDLLFileName, SetLastError = true)]
    public static extern int AntiRollBack();

    [DllImport(Win64BitDLLFileName, SetLastError = true)]
    public static extern int StartFus();

    [DllImport(Win64BitDLLFileName, SetLastError = true)]
    public static extern int Unlockchip();

    // STM32MP specific functions
    [DllImport(Win64BitDLLFileName, SetLastError = true)]
    public static extern int ProgramSsp(IntPtr sspFile, IntPtr licenseFile, IntPtr tfaFile, int hsmSlotId);

    // STM32 HSM specific functions
    [DllImport(Win64BitDLLFileName, SetLastError = true)]
    public static extern IntPtr GetHsmFirmwareID(int hsmSlotId);

    [DllImport(Win64BitDLLFileName, SetLastError = true)]
    public static extern ulong GetHsmCounter(int hsmSlotId);

    [DllImport(Win64BitDLLFileName, SetLastError = true)]
    public static extern IntPtr GetHsmState(int hsmSlotId);

    [DllImport(Win64BitDLLFileName, SetLastError = true)]
    public static extern IntPtr GetHsmVersion(int hsmSlotId);

    [DllImport(Win64BitDLLFileName, SetLastError = true)]
    public static extern IntPtr GetHsmType(int hsmSlotId);

    [DllImport(Win64BitDLLFileName, SetLastError = true)]
    public static extern int GetHsmLicense(int hsmSlotId, IntPtr outLicensePath);

    #endregion

}
