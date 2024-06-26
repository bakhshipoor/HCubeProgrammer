#ifndef  CubeProgrammerAPI_H
#define CubeProgrammerAPI_H

// This class is exported from the dll
#include "pch.h"
#include "framework.h"
#include "CubeProgrammer_API.h"
#include <string>
using namespace std;
extern DWORD dwTlsIndex;
extern const char* loaderPath;

#ifdef __cplusplus
extern "C"
{
#endif

#ifdef CUBEPROGRAMMERAPI_EXPORTS
#define CUBEPROGRAMMERAPI_API __declspec(dllexport)
#else
#define CUBEPROGRAMMERAPI_API 
#endif

	CUBEPROGRAMMERAPI_API int GetLoadersPath(_Out_ char**);

	// STLINK functions
	CUBEPROGRAMMERAPI_API int APIENTRY GetStLinkList(debugConnectParameters**, int);
	CUBEPROGRAMMERAPI_API int APIENTRY GetStLinkEnumerationList(debugConnectParameters**, int);
	CUBEPROGRAMMERAPI_API int APIENTRY ConnectStLink(debugConnectParameters);
	CUBEPROGRAMMERAPI_API int APIENTRY Reset(debugResetMode);

	// Bootloader functions
	CUBEPROGRAMMERAPI_API int APIENTRY GetUsartList(usartConnectParameters**);
	CUBEPROGRAMMERAPI_API int APIENTRY ConnectUsartBootloader(usartConnectParameters);
	CUBEPROGRAMMERAPI_API int APIENTRY SendByteUart(int);
	CUBEPROGRAMMERAPI_API int APIENTRY GetDfuDeviceList(dfuDeviceInfo**, int, int);
	CUBEPROGRAMMERAPI_API int APIENTRY ConnectDfuBootloader(char*);
	CUBEPROGRAMMERAPI_API int APIENTRY ConnectDfuBootloader2(dfuConnectParameters);
	CUBEPROGRAMMERAPI_API int APIENTRY ConnectSpiBootloader(spiConnectParameters);
	CUBEPROGRAMMERAPI_API int APIENTRY ConnectCanBootloader(canConnectParameters);
	CUBEPROGRAMMERAPI_API int APIENTRY ConnectI2cBootloader(i2cConnectParameters);

	// General purposes functions
	CUBEPROGRAMMERAPI_API void APIENTRY SetDisplayCallbacks(displayCallBacks);
	CUBEPROGRAMMERAPI_API void APIENTRY SetVerbosityLevel(int);
	CUBEPROGRAMMERAPI_API int APIENTRY CheckDeviceConnection(void);
	CUBEPROGRAMMERAPI_API generalInf* APIENTRY GetDeviceGeneralInf(void);
	CUBEPROGRAMMERAPI_API int APIENTRY ReadMemory(unsigned int, unsigned char**, unsigned int);
	CUBEPROGRAMMERAPI_API int APIENTRY WriteMemory(unsigned int, char*, unsigned int);
	CUBEPROGRAMMERAPI_API int APIENTRY EditSector(unsigned int, char*, unsigned int);
	CUBEPROGRAMMERAPI_API int APIENTRY DownloadFile(const wchar_t*, unsigned int, unsigned int, unsigned int, const wchar_t*);
	CUBEPROGRAMMERAPI_API int APIENTRY Execute(unsigned int);
	CUBEPROGRAMMERAPI_API int APIENTRY MassErase(char*);
	CUBEPROGRAMMERAPI_API int APIENTRY SectorErase(unsigned int[], unsigned int, char*);
	CUBEPROGRAMMERAPI_API int APIENTRY ReadUnprotect(void);
	CUBEPROGRAMMERAPI_API int APIENTRY TzenRegression(void);
	CUBEPROGRAMMERAPI_API int APIENTRY  GetTargetInterfaceType(void);
	CUBEPROGRAMMERAPI_API volatile int* APIENTRY GetCancelPointer(void);
	CUBEPROGRAMMERAPI_API void* APIENTRY FileOpen(const wchar_t*);
	CUBEPROGRAMMERAPI_API void APIENTRY FreeFileData(fileData_C*);
	CUBEPROGRAMMERAPI_API int APIENTRY Verify(fileData_C*, unsigned int);
	CUBEPROGRAMMERAPI_API int APIENTRY SaveFileToFile(fileData_C*, const wchar_t*);
	CUBEPROGRAMMERAPI_API int APIENTRY SaveMemoryToFile(int, int, const wchar_t*);
	CUBEPROGRAMMERAPI_API void APIENTRY Disconnect(void);
	CUBEPROGRAMMERAPI_API void APIENTRY DeleteInterfaceList(void);
	CUBEPROGRAMMERAPI_API void APIENTRY AutomaticMode(const wchar_t*, unsigned int, unsigned int, unsigned int, int, char*, int);
	CUBEPROGRAMMERAPI_API int APIENTRY GetStorageStructure(storageStructure**);

	// Option Bytes functions
	CUBEPROGRAMMERAPI_API int APIENTRY SendOptionBytesCmd(char*);
	CUBEPROGRAMMERAPI_API peripheral_C* APIENTRY InitOptionBytesInterface(void);
	CUBEPROGRAMMERAPI_API peripheral_C* APIENTRY FastRomInitOptionBytesInterface(uint16_t);
	CUBEPROGRAMMERAPI_API int APIENTRY ObDisplay(void);

	// Loaders functions
	CUBEPROGRAMMERAPI_API void APIENTRY SetLoadersPath(const char*);
	CUBEPROGRAMMERAPI_API void APIENTRY SetExternalLoaderPath(const char*, externalLoader**);
	CUBEPROGRAMMERAPI_API int APIENTRY  GetExternalLoaders(const char*, externalStorageInfo**);
	CUBEPROGRAMMERAPI_API void APIENTRY RemoveExternalLoader(const char*);
	CUBEPROGRAMMERAPI_API void APIENTRY DeleteLoaders(void);

	// STM32WB specific functions
	CUBEPROGRAMMERAPI_API int APIENTRY GetUID64(unsigned char**);
	CUBEPROGRAMMERAPI_API int APIENTRY FirmwareDelete(void);
	CUBEPROGRAMMERAPI_API int APIENTRY FirmwareUpgrade(const wchar_t*, unsigned int, unsigned int, unsigned int, unsigned int);
	CUBEPROGRAMMERAPI_API int APIENTRY StartWirelessStack(void);
	CUBEPROGRAMMERAPI_API int APIENTRY UpdateAuthKey(const wchar_t*);
	CUBEPROGRAMMERAPI_API int APIENTRY AuthKeyLock(void);
	CUBEPROGRAMMERAPI_API int APIENTRY WriteUserKey(const wchar_t*, unsigned char);
	CUBEPROGRAMMERAPI_API int APIENTRY AntiRollBack(void);
	CUBEPROGRAMMERAPI_API int APIENTRY StartFus(void);
	CUBEPROGRAMMERAPI_API int APIENTRY Unlockchip(void);

	// STM32MP specific functions
	CUBEPROGRAMMERAPI_API int ProgramSsp(const wchar_t*, const wchar_t*, const wchar_t*, int);

	// STM32 HSM specific functions
	CUBEPROGRAMMERAPI_API const char* APIENTRY GetHsmFirmwareID(int);
	CUBEPROGRAMMERAPI_API unsigned long APIENTRY GetHsmCounter(int);
	CUBEPROGRAMMERAPI_API const char* APIENTRY GetHsmState(int);
	CUBEPROGRAMMERAPI_API const char* APIENTRY GetHsmVersion(int);
	CUBEPROGRAMMERAPI_API const char* APIENTRY GetHsmType(int);
	CUBEPROGRAMMERAPI_API int APIENTRY GetHsmLicense(int, const wchar_t*);


#ifdef __cplusplus
}
#endif


#endif // CubeProgrammerAPI_H