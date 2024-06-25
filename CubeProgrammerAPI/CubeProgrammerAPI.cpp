#include "pch.h"
#include "framework.h"
#include "CubeProgrammerAPI.h"
#include <CubeProgrammer_API.h>
#include <stdexcept>
#include <SetupAPI.h>

int LastErrorCode = 0;
string LastErrorMessage = "Operation Completed Successfully";

CUBEPROGRAMMERAPI_API int GetLoadersPath(_Out_ char** bLoaderPath)
{
    size_t sizeOfLoaderPath = strlen(loaderPath);
    *bLoaderPath = new char[sizeOfLoaderPath];
    *bLoaderPath = _strdup(loaderPath);
    return sizeOfLoaderPath;
}

// STLINK functions
CUBEPROGRAMMERAPI_API int GetStLinkList(debugConnectParameters** stLinkList, int shared)
{
    return getStLinkList(stLinkList, shared);
}

CUBEPROGRAMMERAPI_API int GetStLinkEnumerationList(debugConnectParameters** stlink_list, int shared)
{
    return getStLinkEnumerationList(stlink_list, shared);
}

CUBEPROGRAMMERAPI_API int ConnectStLink(debugConnectParameters debugParameters)
{
    return connectStLink(debugParameters);
}

CUBEPROGRAMMERAPI_API int Reset(debugResetMode rstMode)
{
    return reset(rstMode);
}


// Bootloader functions
CUBEPROGRAMMERAPI_API int GetUsartList(usartConnectParameters** usartList)
{
    return getUsartList(usartList);
}

CUBEPROGRAMMERAPI_API int ConnectUsartBootloader(usartConnectParameters usartParameters)
{
    return  connectUsartBootloader(usartParameters);
}

CUBEPROGRAMMERAPI_API int SendByteUart(int byte)
{
    return sendByteUart(byte);
}

CUBEPROGRAMMERAPI_API int GetDfuDeviceList(dfuDeviceInfo** dfuList, int iPID, int iVID)
{
    return getDfuDeviceList(dfuList, iPID, iVID);
}

CUBEPROGRAMMERAPI_API int ConnectDfuBootloader(char* usbIndex)
{
    return connectDfuBootloader(usbIndex);
}

CUBEPROGRAMMERAPI_API int ConnectDfuBootloader2(dfuConnectParameters dfuParameters)
{
    return connectDfuBootloader2(dfuParameters);
}

CUBEPROGRAMMERAPI_API int ConnectSpiBootloader(spiConnectParameters spiParameters)
{
    return connectSpiBootloader(spiParameters);
}

CUBEPROGRAMMERAPI_API int ConnectCanBootloader(canConnectParameters canParameters)
{
    return connectCanBootloader(canParameters);
}

CUBEPROGRAMMERAPI_API int ConnectI2cBootloader(i2cConnectParameters i2cParameters)
{
    return connectI2cBootloader(i2cParameters);
}


// General purposes functions
CUBEPROGRAMMERAPI_API void SetDisplayCallbacks(displayCallBacks c)
{
    setDisplayCallbacks(c);
}

CUBEPROGRAMMERAPI_API void SetVerbosityLevel(int level)
{
    setVerbosityLevel(level);
}

CUBEPROGRAMMERAPI_API int CheckDeviceConnection()
{
    return checkDeviceConnection();
}

CUBEPROGRAMMERAPI_API generalInf* GetDeviceGeneralInf()
{
    return getDeviceGeneralInf();
}

CUBEPROGRAMMERAPI_API int ReadMemory(unsigned int address, unsigned char** data, unsigned int size)
{
    return readMemory(address, data, size);
}

CUBEPROGRAMMERAPI_API int WriteMemory(unsigned int address, char* data, unsigned int size)
{
    return writeMemory(address, data, size);
}

CUBEPROGRAMMERAPI_API int EditSector(unsigned int address, char* data, unsigned int size)
{
    return editSector(address, data, size);
}

CUBEPROGRAMMERAPI_API int DownloadFile(const wchar_t* filePath, unsigned int address, unsigned int skipErase, unsigned int verify, const wchar_t* binPath)
{
    return downloadFile(filePath, address, skipErase, verify, binPath);
}

CUBEPROGRAMMERAPI_API int Execute(unsigned int address)
{
    return execute(address);
}

CUBEPROGRAMMERAPI_API int MassErase(char* sFlashMemName = nullptr)
{
    return massErase(sFlashMemName = nullptr);
}

CUBEPROGRAMMERAPI_API int SectorErase(unsigned int sectors[], unsigned int sectorNbr, char* sFlashMemName = nullptr)
{
    return sectorErase(sectors, sectorNbr, sFlashMemName = nullptr);
}

CUBEPROGRAMMERAPI_API int ReadUnprotect()
{
    return readUnprotect();
}

CUBEPROGRAMMERAPI_API int TzenRegression()
{
    return tzenRegression();
}

CUBEPROGRAMMERAPI_API int  GetTargetInterfaceType()
{
    return getTargetInterfaceType();
}

CUBEPROGRAMMERAPI_API volatile int* GetCancelPointer()
{
    return getCancelPointer();
}

CUBEPROGRAMMERAPI_API void* FileOpen(const wchar_t* filePath)
{
    return fileOpen(filePath);
}

CUBEPROGRAMMERAPI_API void FreeFileData(fileData_C* data)
{
    freeFileData(data);
}

CUBEPROGRAMMERAPI_API int Verify(fileData_C* fileData, unsigned int address)
{
    return verify(fileData, address);
}

CUBEPROGRAMMERAPI_API int SaveFileToFile(fileData_C* fileData, const wchar_t* sFileName)
{
    return saveFileToFile(fileData, sFileName);
}

CUBEPROGRAMMERAPI_API int SaveMemoryToFile(int address, int size, const wchar_t* sFileName)
{
    return saveMemoryToFile(address, size, sFileName);
}

CUBEPROGRAMMERAPI_API void Disconnect()
{
    disconnect();
}

CUBEPROGRAMMERAPI_API void DeleteInterfaceList()
{
    deleteInterfaceList();
}

CUBEPROGRAMMERAPI_API void AutomaticMode(const wchar_t* filePath, unsigned int address, unsigned int skipErase, unsigned int verify, int isMassErase, char* obCommand, int run)
{
    automaticMode(filePath, address, skipErase, verify, isMassErase, obCommand, run);
}

CUBEPROGRAMMERAPI_API int GetStorageStructure(storageStructure** deviceStorageStruct)
{
    return getStorageStructure(deviceStorageStruct);
}


// Option Bytes functions
CUBEPROGRAMMERAPI_API int SendOptionBytesCmd(char* command)
{
    return sendOptionBytesCmd(command);
}

CUBEPROGRAMMERAPI_API peripheral_C* InitOptionBytesInterface()
{
    return initOptionBytesInterface();
}

CUBEPROGRAMMERAPI_API peripheral_C* FastRomInitOptionBytesInterface(uint16_t deviceId)
{
    return fastRomInitOptionBytesInterface(deviceId);
}

CUBEPROGRAMMERAPI_API int ObDisplay()
{
    return obDisplay();
}


// Loaders functions
CUBEPROGRAMMERAPI_API void SetLoadersPath(const char* path)
{
    setLoadersPath(path);
}

CUBEPROGRAMMERAPI_API void SetExternalLoaderPath(const char* path, externalLoader** externalLoaderInfo)
{
    setExternalLoaderPath(path, externalLoaderInfo);
}

CUBEPROGRAMMERAPI_API int  GetExternalLoaders(const char* path, externalStorageInfo** externalStorageNfo)
{
    return getExternalLoaders(path, externalStorageNfo);
}

CUBEPROGRAMMERAPI_API void RemoveExternalLoader(const char* path)
{
    removeExternalLoader(path);
}

CUBEPROGRAMMERAPI_API void DeleteLoaders()
{
    deleteLoaders();
}


// STM32WB specific functions
CUBEPROGRAMMERAPI_API int GetUID64(unsigned char** data)
{
    return getUID64(data);
}

CUBEPROGRAMMERAPI_API int FirmwareDelete()
{
    return firmwareDelete();
}

CUBEPROGRAMMERAPI_API int FirmwareUpgrade(const wchar_t* filePath, unsigned int address, unsigned int firstInstall, unsigned int startStack, unsigned int verify)
{
    return firmwareUpgrade(filePath, address, firstInstall, startStack, verify);
}

CUBEPROGRAMMERAPI_API int StartWirelessStack()
{
    return startWirelessStack();
}

CUBEPROGRAMMERAPI_API int UpdateAuthKey(const wchar_t* filePath)
{
    return updateAuthKey(filePath);
}

CUBEPROGRAMMERAPI_API int AuthKeyLock()
{
    return authKeyLock();
}

CUBEPROGRAMMERAPI_API int WriteUserKey(const wchar_t* filePath, unsigned char keyType)
{
    return writeUserKey(filePath, keyType);
}

CUBEPROGRAMMERAPI_API int AntiRollBack()
{
    return antiRollBack();
}

CUBEPROGRAMMERAPI_API int StartFus()
{
    return startFus();
}

CUBEPROGRAMMERAPI_API int Unlockchip()
{
    return unlockchip();
}


// STM32MP specific functions
CUBEPROGRAMMERAPI_API int ProgramSsp(const wchar_t* sspFile, const wchar_t* licenseFile, const wchar_t* tfaFile, int hsmSlotId)
{
    return programSsp(sspFile, licenseFile, tfaFile, hsmSlotId);
}


// STM32 HSM specific functions
CUBEPROGRAMMERAPI_API const char* GetHsmFirmwareID(int hsmSlotId)
{
    return getHsmFirmwareID(hsmSlotId);
}

CUBEPROGRAMMERAPI_API unsigned long GetHsmCounter(int hsmSlotId)
{
    return getHsmCounter(hsmSlotId);
}

CUBEPROGRAMMERAPI_API const char* GetHsmState(int hsmSlotId)
{
    return getHsmState(hsmSlotId);
}

CUBEPROGRAMMERAPI_API const char* GetHsmVersion(int hsmSlotId)
{
    return getHsmVersion(hsmSlotId);
}

CUBEPROGRAMMERAPI_API const char* GetHsmType(int hsmSlotId)
{
    return getHsmType(hsmSlotId);
}

CUBEPROGRAMMERAPI_API int GetHsmLicense(int hsmSlotId, const wchar_t* outLicensePath)
{
    return getHsmLicense(hsmSlotId, outLicensePath);
}