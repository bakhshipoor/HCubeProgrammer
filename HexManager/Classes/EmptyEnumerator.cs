using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HexManager.Classes;

internal class EmptyEnumerator : IEnumerator
{
    // singleton class, private ctor
    private EmptyEnumerator()
    {
    }

    /// <summary>
    /// Read-Only instance of an Empty Enumerator.
    /// </summary>
    public static IEnumerator Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = new EmptyEnumerator();
            }
            return _instance;
        }
    }

    /// <summary>
    /// Does nothing.
    /// </summary>
    public void Reset() { }

    /// <summary>
    /// Returns false.
    /// </summary>
    /// <returns>false</returns>
    public bool MoveNext() { return false; }


#pragma warning disable 1634, 1691  // about to use PreSharp message numbers - unknown to C#

    /// <summary>
    /// Returns null.
    /// </summary>
    public object Current
    {
        get
        {
#pragma warning disable 6503 // "Property get methods should not throw exceptions."

            throw new InvalidOperationException();

#pragma warning restore 6503
        }
    }
#pragma warning restore 1634, 1691

    private static IEnumerator _instance;
}
