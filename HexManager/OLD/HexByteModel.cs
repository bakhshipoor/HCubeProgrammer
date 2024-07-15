using HexManager.EventArgs;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.DirectoryServices.ActiveDirectory;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static HexManager.Helpers.HexByteModificationEnum;
using static HexManager.Helpers.HexDisplayModeEnum;

namespace HexManager.Models;

public class HexByteModel: ModelBase
{
    public event EventHandler<HexByteEventArgs>? HexByteDataChanged;

    public HexByteModel()
    {
        _HexString = string.Empty;
        _AsciiString = string.Empty;
        _DecimalString = string.Empty;
        _BinaryString = string.Empty;
    }

    public HexByteModel(byte data) : this()
    {
        Data = data;
    }

    private byte _Data;
	public byte Data
	{
		get { return _Data; }
		set 
        {
            byte oldValue = _Data;
            _Data = value;
            RefreshDataStrings();
            OnPropertyChanged(nameof(Data));
            OnHexByteDataChanged(new HexByteEventArgs(this, oldValue, value, HexByteModification.Edit));
        }
	}

	private string _HexString;
	public string HexString
    {
		get { return _HexString; }
		set 
        {
            if (value.Length > 2) return;
            string strHexData = value;
            char[] txtData = strHexData.ToCharArray();
            if (!txtData.All(char.IsAsciiHexDigit))
            {
                int charOffset = 0;
                int lenght = strHexData.Length;
                for (int i = 0; i < lenght; i++)
                {
                    char addedChar = strHexData[charOffset];
                    if (!char.IsAsciiHexDigit(addedChar))
                    {
                        string tempData = strHexData.Replace(addedChar.ToString(), "");
                        strHexData = tempData;
                        lenght--;
                    }
                    else
                        charOffset++;
                }
                value = strHexData.ToUpper();
            }
            if (!string.IsNullOrEmpty(value))
                Data = Convert.ToByte(value, 16);
            else
                Data = 0;
            _HexString = value.ToUpper(); 
            OnPropertyChanged(nameof(HexString)); 
        }
	}

    private string _AsciiString;
    public string AsciiString
    {
        get { return _AsciiString; }
        set 
        {
            if (value.Length > 1) return;
            if (!string.IsNullOrEmpty(value))
                Data = (byte)value[0];
            else
                Data = 0;
            _AsciiString = value; 
            OnPropertyChanged(nameof(AsciiString)); 
        }
    }

    private string _DecimalString;
    public string DecimalString
    {
        get { return _DecimalString; }
        set 
        {
            if (value.Length > 3) return;
            string strHexData = value;
            char[] txtData = strHexData.ToCharArray();
            if (!txtData.All(char.IsAsciiHexDigit))
            {
                int charOffset = 0;
                int lenght = strHexData.Length;
                for (int i = 0; i < lenght; i++)
                {
                    char addedChar = strHexData[charOffset];
                    if (!char.IsDigit(addedChar))
                    {
                        string tempData = strHexData.Replace(addedChar.ToString(), "");
                        strHexData = tempData;
                        lenght--;
                    }
                    else
                        charOffset++;
                }
                value = strHexData;
            }
            int tempdata = Convert.ToInt32(value, 10);
            if (tempdata < 0)
                value = "0";
            else if (tempdata > 255)
                value = "255";
            if (!string.IsNullOrEmpty(value))
                Data = Convert.ToByte(value, 10);
            else
                Data = 0;
            _DecimalString = value; 
            OnPropertyChanged(nameof(DecimalString)); 
        }
    }

    private string _BinaryString;
    public string BinaryString
    {
        get { return _BinaryString; }
        set 
        {
            if (value.Length > 8) return;
            string strHexData = value;
            char[] txtData = strHexData.ToCharArray();
            if (!txtData.All(c => c == 0x30 || c == 0x31))
            {
                int charOffset = 0;
                int lenght = strHexData.Length;
                for (int i = 0; i < lenght; i++)
                {
                    char addedChar = strHexData[charOffset];
                    if (addedChar != 0x30 && addedChar != 0x31)
                    {
                        string tempData = strHexData.Replace(addedChar.ToString(), "");
                        strHexData = tempData;
                        lenght--;
                    }
                    else
                        charOffset++;
                }
                value = strHexData;
            }
            if (!string.IsNullOrEmpty(value))
                Data = Convert.ToByte(value, 2);
            else
                Data = 0;
            _BinaryString = value; 
            OnPropertyChanged(nameof(BinaryString)); 
        }
    }

    private int _Address;
    public int Address
    {
        get { return _Address; }
        set { _Address = value; OnPropertyChanged(nameof(Address)); }
    }

    private bool _IsSelected;
    public bool IsSelected
    {
        get { return _IsSelected; }
        set { _IsSelected = value; OnPropertyChanged(nameof(IsSelected)); }
    }

    private bool _IsHover;
    public bool IsHover
    {
        get { return _IsHover; }
        set { _IsHover = value; OnPropertyChanged(nameof(IsHover)); }
    }

    private bool _IsRemoved;
    public bool IsRemoved
    {
        get { return _IsRemoved; }
        set 
        { 
            _IsRemoved = value; 
            OnPropertyChanged(nameof(IsRemoved));
            OnHexByteDataChanged(new HexByteEventArgs(this, Data, Data, HexByteModification.Remove));
        }
    }

    private void RefreshDataStrings()
    {
        _HexString = string.Format("{0:X2}", Data);
        _AsciiString = string.Format("{0}", (char)Data < 0x20 ? "." : (char)Data);
        _DecimalString = string.Format("{0:D3}", Data);
        _BinaryString = string.Format("{0:B8}", Data);
    }

    public virtual void OnHexByteDataChanged(HexByteEventArgs e)
    {
        HexByteDataChanged?.Invoke(this, e);
    }

}
