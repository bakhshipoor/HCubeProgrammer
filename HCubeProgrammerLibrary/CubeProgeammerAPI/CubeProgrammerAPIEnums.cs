using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HCubeProgrammerLibrary.CubeProgeammerAPI;

public static class CubeProgrammerAPIEnums
{

    // Errors Enumerations
    public enum CubeProgrammerVerbosityLevel : uint
    {
        /// <summary>
        /// no messages ever printed by the library
        /// </summary>
        CUBEPROGRAMMER_VER_LEVEL_NONE = 0,
        /// <summary>
        /// warning, error and success messages are printed (default)
        /// </summary>
        CUBEPROGRAMMER_VER_LEVEL_ONE = 1,
        /// <summary>
        /// error roots informational messages are printed
        /// </summary>
        CUBEPROGRAMMER_VER_LEVEL_TWO = 2,
        /// <summary>
        /// debug and informational messages are printed
        /// </summary>
        CUBEPROGRAMMER_VER_LEVEL_DEBUG = 3,
        /// <summary>
        /// no progress bar is printed in the output of the library
        /// progress bars are printed only with verbosity level one
        /// </summary>
        CUBEPROGRAMMER_NO_PROGRESS_BAR = 4,
    }

    public enum CubeProgrammerError : int
    {
        /// <summary>
        /// Success (no error)
        /// </summary>
        CUBEPROGRAMMER_NO_ERROR = 0,
        /// <summary>
        /// Device not connected
        /// </summary>
        CUBEPROGRAMMER_ERROR_NOT_CONNECTED = -1,
        /// <summary>
        /// Device not found
        /// </summary>
        CUBEPROGRAMMER_ERROR_NO_DEVICE = -2,
        /// <summary>
        /// Device connection error
        /// </summary>
        CUBEPROGRAMMER_ERROR_CONNECTION = -3,
        /// <summary>
        /// No such file
        /// </summary>
        CUBEPROGRAMMER_ERROR_NO_FILE = -4,
        /// <summary>
        /// Operation not supported or unimplemented on this interface
        /// </summary>
        CUBEPROGRAMMER_ERROR_NOT_SUPPORTED = -5,
        /// <summary>
        /// Interface not supported or unimplemented on this plateform
        /// </summary>
        CUBEPROGRAMMER_ERROR_INTERFACE_NOT_SUPPORTED = -6,
        /// <summary>
        /// Insufficient memory
        /// </summary>
        CUBEPROGRAMMER_ERROR_NO_MEM = -7,
        /// <summary>
        /// Wrong parameters
        /// </summary>
        CUBEPROGRAMMER_ERROR_WRONG_PARAM = -8,
        /// <summary>
        /// Memory read failure
        /// </summary>
        CUBEPROGRAMMER_ERROR_READ_MEM = -9,
        /// <summary>
        /// Memory write failure
        /// </summary>
        CUBEPROGRAMMER_ERROR_WRITE_MEM = -10,
        /// <summary>
        /// Memory erase failure
        /// </summary>
        CUBEPROGRAMMER_ERROR_ERASE_MEM = -11,
        /// <summary>
        /// File format not supported for this kind of device
        /// </summary>
        CUBEPROGRAMMER_ERROR_UNSUPPORTED_FILE_FORMAT = -12,
        /// <summary>
        /// Refresh required 
        /// </summary>
        CUBEPROGRAMMER_ERROR_REFRESH_REQUIRED = -13,
        /// <summary>
        /// Refresh required
        /// </summary>
        CUBEPROGRAMMER_ERROR_NO_SECURITY = -14,
        /// <summary>
        /// Changing frequency problem
        /// </summary>
        CUBEPROGRAMMER_ERROR_CHANGE_FREQ = -15,
        /// <summary>
        /// RDP Enabled error
        /// </summary>
        CUBEPROGRAMMER_ERROR_RDP_ENABLED = -16,
        /* NB: Remember to update CUBEPROGRAMMER_ERROR_COUNT below. */
        /// <summary>
        /// Other error
        /// </summary>
        CUBEPROGRAMMER_ERROR_OTHER = -99,
    }

    // Flash Size  Structures and Enumerations
    public enum FlashSize : uint
    {
        Flash_Size_1KB = (1024),
        Flash_Size_512KB = (512 * 1024),
        Flash_Size_256KB = (256 * 1024),
    }

    // STM32WB Structures and Enumerations
    public enum WBFunctionArguments
    {
        FIRST_INSTALL_ACTIVE = 1,
        FIRST_INSTALL_NOT_ACTIVE = 0,
        START_STACK_ACTIVE = 1,
        START_STACK_NOT_ACTIVE = 1,
        VERIFY_FILE_DOWLOAD_FILE = 1,
        DO_NOT_VERIFY_DOWLOAD_FILE = 0,
    }

    // Bootloader Data Enumerations
    public enum USARTParity : uint
    {
        /// <summary>
        /// Even parity bit.
        /// </summary>
        EVEN = 0,
        /// <summary>
        /// Odd parity bit.
        /// </summary>
        ODD = 1,
        /// <summary>
        /// No check parity.
        /// </summary>
        NONE = 2, 
    }

    public enum USARTFlowControl : uint
    {
        /// <summary>
        /// No flow control.
        /// </summary>
        OFF = 0,
        /// <summary>
        /// Hardware flow control : RTS/CTS.
        /// </summary>
        HARDWARE = 1,
        /// <summary>
        /// Software flow control : Transmission is started and stopped by sending special characters.
        /// </summary>
        SOFTWARE = 2, 
    }

    // STLINK Data Enumerations
    public enum DebugResetMode : uint
    {
        /// <summary>
        /// Apply a reset by the software. 
        /// </summary>
        SOFTWARE_RESET,
        /// <summary>
        /// Apply a reset by the hardware.
        /// </summary>
        HARDWARE_RESET,
        /// <summary>
        /// Apply a reset by the internal core peripheral.
        /// </summary>
        CORE_RESET, 
    }

    public enum DebugConnectMode : uint
    {
        /// <summary>
        /// Connect with normal mode, the target is reset then halted while the type of reset is selected using the [debugResetMode].
        /// </summary>
        NORMAL_MODE,
        /// <summary>
        /// Connect with hotplug mode,  this option allows the user to connect to the target without halt or reset.
        /// </summary>
        HOTPLUG_MODE,
        /// <summary>
        /// Connect with under reset mode, option allows the user to connect to the target using a reset vector catch before executing any instruction.
        /// </summary>
        UNDER_RESET_MODE,
        /// <summary>
        /// Connect with power down mode.
        /// </summary>
        POWER_DOWN_MODE,
        /// <summary>
        /// Connect with pre reset mode.
        /// </summary>
        PRE_RESET_MODE, 
    }

    public enum DebugPort : uint
    {
        /// <summary>
        /// JTAG debug port.
        /// </summary>
        JTAG = 0,
        /// <summary>
        /// SWD debug port.
        /// </summary>
        SWD = 1, 
    }

    // General Data Enumerations
    public enum TargetInterfaceType : uint
    {
        /// <summary>
        /// STLINK used as connection interface.
        /// </summary>
        STLINK_INTERFACE = 0,
        /// <summary>
        /// USART used as connection interface.
        /// </summary>
        USART_INTERFACE = 1,
        /// <summary>
        /// USB DFU used as connection interface.
        /// </summary>
        USB_INTERFACE = 2,
        /// <summary>
        /// SPI used as connection interface.
        /// </summary>
        SPI_INTERFACE = 3,
        /// <summary>
        /// I2C used as connection interface.
        /// </summary>
        I2C_INTERFACE = 4,
        /// <summary>
        /// CAN used as connection interface.
        /// </summary>
        CAN_INTERFACE = 5, 
    }

}
