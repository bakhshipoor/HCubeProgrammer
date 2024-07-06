using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HexManager.Helpers;

public static class HexByteModificationEnum
{
    public enum HexByteModification : uint
    {
        Edit=0,
        Remove,
        Add,
    }
}
