#include "pch.h"
#include "framework.h"
#include "CubeProgrammer_API.h"
#include "CubeProgrammerAPI.h"

CUBEPROGRAMMERAPI_API int APIENTRY GetLoadersPath(_Out_ char** bLoaderPath)
{
    size_t sizeOfLoaderPath = strlen(loaderPath);
    *bLoaderPath = new char[sizeOfLoaderPath];
    *bLoaderPath = _strdup(loaderPath);
    return (int)sizeOfLoaderPath;
}

// STLINK functions
CUBEPROGRAMMERAPI_API int APIENTRY GetStLinkList(_Out_ debugConnectParameters** stLinkList, _In_ int shared)
{
    return getStLinkList(stLinkList, shared);
}

CUBEPROGRAMMERAPI_API int APIENTRY GetStLinkEnumerationList(_Out_ debugConnectParameters** stlink_list, _In_ int shared)
{
    return getStLinkEnumerationList(stlink_list, shared);
}

CUBEPROGRAMMERAPI_API int APIENTRY ConnectStLink(debugConnectParameters debugParameters)
{
    return connectStLink(debugParameters);
}

CUBEPROGRAMMERAPI_API int APIENTRY Reset(debugResetMode rstMode)
{
    return reset(rstMode);
}


// Bootloader functions
CUBEPROGRAMMERAPI_API int APIENTRY GetUsartList(usartConnectParameters** usartList)
{
    return getUsartList(usartList);
}

CUBEPROGRAMMERAPI_API int APIENTRY ConnectUsartBootloader(usartConnectParameters usartParameters)
{
    return  connectUsartBootloader(usartParameters);
}

CUBEPROGRAMMERAPI_API int APIENTRY SendByteUart(int byte)
{
    return sendByteUart(byte);
}

CUBEPROGRAMMERAPI_API int APIENTRY GetDfuDeviceList(dfuDeviceInfo** dfuList, int iPID, int iVID)
{
    return getDfuDeviceList(dfuList, iPID, iVID);
}

CUBEPROGRAMMERAPI_API int APIENTRY ConnectDfuBootloader(char* usbIndex)
{
    return connectDfuBootloader(usbIndex);
}

CUBEPROGRAMMERAPI_API int APIENTRY ConnectDfuBootloader2(dfuConnectParameters dfuParameters)
{
    return connectDfuBootloader2(dfuParameters);
}

CUBEPROGRAMMERAPI_API int APIENTRY ConnectSpiBootloader(spiConnectParameters spiParameters)
{
    return connectSpiBootloader(spiParameters);
}

CUBEPROGRAMMERAPI_API int APIENTRY ConnectCanBootloader(canConnectParameters canParameters)
{
    return connectCanBootloader(canParameters);
}

CUBEPROGRAMMERAPI_API int APIENTRY ConnectI2cBootloader(i2cConnectParameters i2cParameters)
{
    return connectI2cBootloader(i2cParameters);
}


// General purposes functions
CUBEPROGRAMMERAPI_API void APIENTRY SetDisplayCallbacks(displayCallBacks c)
{
    setDisplayCallbacks(c);
}

CUBEPROGRAMMERAPI_API void APIENTRY SetVerbosityLevel(int level)
{
    setVerbosityLevel(level);
}

CUBEPROGRAMMERAPI_API int APIENTRY CheckDeviceConnection(void)
{
    return checkDeviceConnection();
}

CUBEPROGRAMMERAPI_API generalInf* APIENTRY GetDeviceGeneralInf(void)
{
    return getDeviceGeneralInf();
}

CUBEPROGRAMMERAPI_API int APIENTRY ReadMemory(unsigned int address, unsigned char** data, unsigned int size)
{
    return readMemory(address, data, size);
}

CUBEPROGRAMMERAPI_API int APIENTRY WriteMemory(unsigned int address, char* data, unsigned int size)
{
    return writeMemory(address, data, size);
}

CUBEPROGRAMMERAPI_API int APIENTRY EditSector(unsigned int address, char* data, unsigned int size)
{
    return editSector(address, data, size);
}

CUBEPROGRAMMERAPI_API int APIENTRY DownloadFile(const wchar_t* filePath, unsigned int address, unsigned int skipErase, unsigned int verify, const wchar_t* binPath)
{
    return downloadFile(filePath, address, skipErase, verify, binPath);
}

CUBEPROGRAMMERAPI_API int APIENTRY Execute(unsigned int address)
{
    return execute(address);
}

CUBEPROGRAMMERAPI_API int APIENTRY MassErase(char* sFlashMemName = nullptr)
{
    return massErase(sFlashMemName = nullptr);
}

CUBEPROGRAMMERAPI_API int APIENTRY SectorErase(unsigned int sectors[], unsigned int sectorNbr, char* sFlashMemName = nullptr)
{
    return sectorErase(sectors, sectorNbr, sFlashMemName = nullptr);
}

CUBEPROGRAMMERAPI_API int APIENTRY ReadUnprotect(void)
{
    return readUnprotect();
}

CUBEPROGRAMMERAPI_API int APIENTRY TzenRegression(void)
{
    return 0;// tzenRegression();
}

CUBEPROGRAMMERAPI_API int APIENTRY GetTargetInterfaceType(void)
{
    return 0;// getTargetInterfaceType();
}

CUBEPROGRAMMERAPI_API volatile int* APIENTRY GetCancelPointer(void)
{
    return getCancelPointer();
}

CUBEPROGRAMMERAPI_API void* APIENTRY FileOpen(const wchar_t* filePath)
{
    return fileOpen(filePath);
}

CUBEPROGRAMMERAPI_API void APIENTRY FreeFileData(fileData_C* data)
{
    freeFileData(data);
}

CUBEPROGRAMMERAPI_API int APIENTRY Verify(fileData_C* fileData, unsigned int address)
{
    return verify(fileData, address);
}

CUBEPROGRAMMERAPI_API int APIENTRY SaveFileToFile(fileData_C* fileData, const wchar_t* sFileName)
{
    return saveFileToFile(fileData, sFileName);
}

CUBEPROGRAMMERAPI_API int APIENTRY SaveMemoryToFile(int address, int size, const wchar_t* sFileName)
{
    return saveMemoryToFile(address, size, sFileName);
}

CUBEPROGRAMMERAPI_API void APIENTRY Disconnect(void)
{
    disconnect();
}

CUBEPROGRAMMERAPI_API void APIENTRY DeleteInterfaceList(void)
{
    deleteInterfaceList();
}

CUBEPROGRAMMERAPI_API void APIENTRY AutomaticMode(const wchar_t* filePath, unsigned int address, unsigned int skipErase, unsigned int verify, int isMassErase, char* obCommand, int run)
{
    automaticMode(filePath, address, skipErase, verify, isMassErase, obCommand, run);
}

CUBEPROGRAMMERAPI_API int APIENTRY GetStorageStructure(storageStructure** deviceStorageStruct)
{
    return getStorageStructure(deviceStorageStruct);
}


// Option Bytes functions
CUBEPROGRAMMERAPI_API int APIENTRY SendOptionBytesCmd(char* command)
{
    return sendOptionBytesCmd(command);
}

CUBEPROGRAMMERAPI_API peripheral_C* APIENTRY InitOptionBytesInterface(void)
{
    return initOptionBytesInterface();
}

CUBEPROGRAMMERAPI_API peripheral_C* APIENTRY FastRomInitOptionBytesInterface(uint16_t deviceId)
{
    peripheral_C* xxx = { 0 };
    return xxx;// fastRomInitOptionBytesInterface(deviceId);
}

CUBEPROGRAMMERAPI_API int APIENTRY ObDisplay(void)
{
    return obDisplay();
}


// Loaders functions
CUBEPROGRAMMERAPI_API void APIENTRY SetLoadersPath(const char* path)
{
    setLoadersPath(path);
}

CUBEPROGRAMMERAPI_API void APIENTRY SetExternalLoaderPath(const char* path, externalLoader** externalLoaderInfo)
{
    setExternalLoaderPath(path, externalLoaderInfo);
}

CUBEPROGRAMMERAPI_API int APIENTRY GetExternalLoaders(const char* path, externalStorageInfo** externalStorageNfo)
{
    return getExternalLoaders(path, externalStorageNfo);
}

CUBEPROGRAMMERAPI_API void APIENTRY RemoveExternalLoader(const char* path)
{
    removeExternalLoader(path);
}

CUBEPROGRAMMERAPI_API void APIENTRY DeleteLoaders(void)
{
    deleteLoaders();
}


// STM32WB specific functions
CUBEPROGRAMMERAPI_API int APIENTRY GetUID64(unsigned char** data)
{
    return getUID64(data);
}

CUBEPROGRAMMERAPI_API int APIENTRY FirmwareDelete(void)
{
    return firmwareDelete();
}

CUBEPROGRAMMERAPI_API int APIENTRY FirmwareUpgrade(const wchar_t* filePath, unsigned int address, unsigned int firstInstall, unsigned int startStack, unsigned int verify)
{
    return firmwareUpgrade(filePath, address, firstInstall, startStack, verify);
}

CUBEPROGRAMMERAPI_API int APIENTRY StartWirelessStack(void)
{
    return startWirelessStack();
}

CUBEPROGRAMMERAPI_API int APIENTRY UpdateAuthKey(const wchar_t* filePath)
{
    return updateAuthKey(filePath);
}

CUBEPROGRAMMERAPI_API int APIENTRY AuthKeyLock(void)
{
    return authKeyLock();
}

CUBEPROGRAMMERAPI_API int APIENTRY WriteUserKey(const wchar_t* filePath, unsigned char keyType)
{
    return writeUserKey(filePath, keyType);
}

CUBEPROGRAMMERAPI_API int APIENTRY AntiRollBack(void)
{
    return antiRollBack();
}

CUBEPROGRAMMERAPI_API int APIENTRY StartFus(void)
{
    return startFus();
}

CUBEPROGRAMMERAPI_API int APIENTRY Unlockchip(void)
{
    return 0;//unlockchip();
}


// STM32MP specific functions
CUBEPROGRAMMERAPI_API int APIENTRY ProgramSsp(const wchar_t* sspFile, const wchar_t* licenseFile, const wchar_t* tfaFile, int hsmSlotId)
{
    return programSsp(sspFile, licenseFile, tfaFile, hsmSlotId);
}


// STM32 HSM specific functions
CUBEPROGRAMMERAPI_API const char* APIENTRY GetHsmFirmwareID(int hsmSlotId)
{
    return getHsmFirmwareID(hsmSlotId);
}

CUBEPROGRAMMERAPI_API unsigned long APIENTRY GetHsmCounter(int hsmSlotId)
{
    return getHsmCounter(hsmSlotId);
}

CUBEPROGRAMMERAPI_API const char* APIENTRY GetHsmState(int hsmSlotId)
{
    return getHsmState(hsmSlotId);
}

CUBEPROGRAMMERAPI_API const char* APIENTRY GetHsmVersion(int hsmSlotId)
{
    return getHsmVersion(hsmSlotId);
}

CUBEPROGRAMMERAPI_API const char* APIENTRY GetHsmType(int hsmSlotId)
{
    return getHsmType(hsmSlotId);
}

CUBEPROGRAMMERAPI_API int APIENTRY GetHsmLicense(int hsmSlotId, const wchar_t* outLicensePath)
{
    return getHsmLicense(hsmSlotId, outLicensePath);
}