using HCubeProgrammerLibrary.FirmwareFileData;
using HCubeProgrammerLibrary.STLink;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using static HCubeProgrammerLibrary.CubeProgeammerAPI.CubeProgrammerAPIStructs;


namespace HCubeProgrammerLibrary.CubeProgeammerAPI;

public static class CubeProgrammerAPIFunctionsEx
{
    public static bool IsValidDLLFile;
    public static bool Is64BitOperatingSystem;

    [UnmanagedFunctionPointer(CallingConvention.Cdecl, SetLastError = true)]
    public delegate void InitialProgressBar();

    [UnmanagedFunctionPointer(CallingConvention.Cdecl, SetLastError = true)]
    public delegate void DisplayMessage(int messageType, [MarshalAs(UnmanagedType.LPWStr)] string message);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl, SetLastError = true)]
    public delegate void LoadProgressBar(int currentProgress, int total);

    public static ObservableCollection<STLinkDevice> GetStLinkEnumerationList(int shared)
    {
        ObservableCollection<STLinkDevice> bRespose = [];
        if (Is64BitOperatingSystem)
        {
            IntPtr stLinkList = new();
            int countOfStlinkDevices = CubeProgrammerAPIFunctionsX64.GetStLinkEnumerationList(out stLinkList, shared);
            if (stLinkList != IntPtr.Zero)
            {
                int sizeOfStruct = Marshal.SizeOf<DebugConnectParameters>();
                for (int i = 0; i < countOfStlinkDevices; i++)
                {
                    DebugConnectParameters stlinkDevice = Marshal.PtrToStructure<DebugConnectParameters>(stLinkList + (i * sizeOfStruct));
                    bRespose.Add(new(stlinkDevice));
                    Marshal.DestroyStructure<DebugConnectParameters>(stLinkList + (i * sizeOfStruct));
                }
            }
        }
        else
        {
            IntPtr stLinkList = new();
            int countOfStlinkDevices = CubeProgrammerAPIFunctionsX86.GetStLinkEnumerationList(out stLinkList, shared);
            if (stLinkList != IntPtr.Zero)
            {
                int sizeOfStruct = Marshal.SizeOf<DebugConnectParameters>();
                for (int i = 0; i < countOfStlinkDevices; i++)
                {
                    DebugConnectParameters stlinkDevice = Marshal.PtrToStructure<DebugConnectParameters>(stLinkList + (i * sizeOfStruct));
                    bRespose.Add(new(stlinkDevice));
                    Marshal.DestroyStructure<DebugConnectParameters>(stLinkList + (i * sizeOfStruct));
                }
            }
        }
        return bRespose;
    }

    public static FirmwareFile? OpenFirmwareFile(string filePath)
    {
        if (Is64BitOperatingSystem)
        {
            if (!string.IsNullOrEmpty(filePath))
            {
                if (File.Exists(filePath))
                {
                    IntPtr fileToOpen = CubeProgrammerAPIFunctionsX64.FileOpen(filePath);
                    if (fileToOpen != IntPtr.Zero)
                    {
                        FileData_C fileopen = Marshal.PtrToStructure<FileData_C>(fileToOpen);
                        FirmwareFile firmwareFile = new(fileopen);
                        Marshal.DestroyStructure<FileData_C>(fileToOpen);
                        return firmwareFile;
                    }
                }
            }
        }
        else
        {
            if (!string.IsNullOrEmpty(filePath))
            {
                if (File.Exists(filePath))
                {
                    IntPtr fileToOpen = CubeProgrammerAPIFunctionsX86.FileOpen(filePath);
                    if (fileToOpen != IntPtr.Zero)
                    {
                        FileData_C fileopen = Marshal.PtrToStructure<FileData_C>(fileToOpen);
                        FirmwareFile firmwareFile = new(fileopen);
                        Marshal.DestroyStructure<FileData_C>(fileToOpen);
                        return firmwareFile;
                    }
                }
            }
        }
        return null;
    }

}
