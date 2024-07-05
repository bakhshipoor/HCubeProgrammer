using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using static HCubeProgrammerLibrary.CubeProgeammerAPI.CubeProgrammerAPIEnums;
using static HCubeProgrammerLibrary.CubeProgeammerAPI.CubeProgrammerAPIStructs;

namespace HCubeProgrammerLibrary.STLink;

public class STLinkDevice
{
    public STLinkDevice()
    {
        SerialNumber = string.Empty;
        FirmwareVersion = string.Empty;
        TargetVoltage = string.Empty;
        Board = string.Empty;
        JTAGFrequencies = [];
        SWDFrequencies = [];
    }

    public STLinkDevice(DebugConnectParameters debugConnectParameters) : this()
    {
        DebugPort = debugConnectParameters.dbgPort;
        Index = debugConnectParameters.index;
        SerialNumber = debugConnectParameters.serialNumber;
        FirmwareVersion = debugConnectParameters.firmwareVersion;
        TargetVoltage = debugConnectParameters.targetVoltage;
        AcessPortNumber = debugConnectParameters.accessPortNumber;
        AccessPort = debugConnectParameters.accessPort;
        ConnectionMode = debugConnectParameters.connectionMode;
        ResetMode = debugConnectParameters.resetMode;
        IsOldFirmware = debugConnectParameters.isOldFirmware;
        Frequency = debugConnectParameters.frequency;
        IsBridge = debugConnectParameters.isBridge;
        Shared = debugConnectParameters.shared;
        Board = debugConnectParameters.board;
        DBG_Sleep = debugConnectParameters.DBG_Sleep;
        Speed = debugConnectParameters.speed;

        JTAGFreqNumber = debugConnectParameters.freq.jtagFreqNumber;
        SWDFreqNumber = debugConnectParameters.freq.swdFreqNumber;
        for (int i=0;i<JTAGFreqNumber;i++)
        {
            JTAGFrequencies.Add(debugConnectParameters.freq.jtagFreq[i]);
        }
        for (int i = 0; i < SWDFreqNumber; i++)
        {
            SWDFrequencies.Add(debugConnectParameters.freq.swdFreq[i]);
        }
        
    }

    public DebugPort DebugPort { get; set; }
    public int Index { get; set; }
    public string SerialNumber { get; set; }
    public string FirmwareVersion { get; set; }
    public string TargetVoltage { get; set; }
    public int AcessPortNumber { get; set; }
    public int AccessPort { get; set; }
    public DebugConnectMode ConnectionMode { get; set; }
    public DebugResetMode ResetMode { get; set; }
    public int IsOldFirmware { get; set; }
    public int Frequency { get; set; }
    public int IsBridge { get; set; }
    public int Shared { get; set; }
    public string Board { get; set; }
    public int DBG_Sleep { get; set; }
    public int Speed { get; set; }

    public List<uint> JTAGFrequencies { get; set; }
    public uint JTAGFreqNumber { get; set; }
    public List<uint> SWDFrequencies { get; set; }
    public uint SWDFreqNumber { get; set; }
}
