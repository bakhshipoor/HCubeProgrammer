using HexManager.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static HexManager.Helpers.HexByteModificationEnum;

namespace HexManager.EventArgs;

public class HexByteEventArgs
{
    public HexByteEventArgs(HexByteModel hexByte, byte oldData, byte newData, HexByteModification modificationStatus)
    {
        HexByte = hexByte;
        OldData = oldData;
        NewData = newData;
        ModificationStatus = modificationStatus;
    }

    HexByteModel HexByte {  get; set; }
    public byte OldData { get; set; }
    public byte NewData { get; set; }
    public HexByteModification ModificationStatus { get; set; }
}
