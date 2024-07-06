using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HexManager.Helpers;

public static class HexDisplayModeEnum
{
    public enum HexDisplayMode : uint
    {
        HexString=0,
        AsciiString=1,
        DecimalString=2,
        BinaryString=3,
    }
}
