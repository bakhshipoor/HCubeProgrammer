// The following ifdef block is the standard way of creating macros which make exporting
// from a DLL simpler. All files within this DLL are compiled with the CUBEPROGRAMMERAPI_EXPORTS
// symbol defined on the command line. This symbol should not be defined on any project
// that uses this DLL. This way any other project whose source files include this file see
// CUBEPROGRAMMERAPI_API functions as being imported from a DLL, whereas this DLL sees symbols
// defined with this macro as being exported.
#ifdef CUBEPROGRAMMERAPI_EXPORTS
#define CUBEPROGRAMMERAPI_API __declspec(dllexport)
#else
#define CUBEPROGRAMMERAPI_API __declspec(dllimport)
#endif
// This class is exported from the dll
#include "CubeProgrammer_API.h"
#include "ExceptionManager.h"
#include <string>
using namespace std;

extern DWORD dwTlsIndex;
extern const char* loaderPath;


extern "C"
{
	CUBEPROGRAMMERAPI_API int GetLoadersPath(_Out_ char**);
	CUBEPROGRAMMERAPI_API void GetLLastError(EXCEPTION*);

	// STLINK functions
	CUBEPROGRAMMERAPI_API int GetStLinkList(debugConnectParameters**, int);
	CUBEPROGRAMMERAPI_API int GetStLinkEnumerationList(debugConnectParameters**, int);
	CUBEPROGRAMMERAPI_API int ConnectStLink(debugConnectParameters);
	CUBEPROGRAMMERAPI_API int Reset(debugResetMode);

	// Bootloader functions
	CUBEPROGRAMMERAPI_API int GetUsartList(usartConnectParameters**);
	CUBEPROGRAMMERAPI_API int ConnectUsartBootloader(usartConnectParameters);
	CUBEPROGRAMMERAPI_API int SendByteUart(int);
	CUBEPROGRAMMERAPI_API int GetDfuDeviceList(dfuDeviceInfo**, int, int);
	CUBEPROGRAMMERAPI_API int ConnectDfuBootloader(char*);
	CUBEPROGRAMMERAPI_API int ConnectDfuBootloader2(dfuConnectParameters);
	CUBEPROGRAMMERAPI_API int ConnectSpiBootloader(spiConnectParameters);
	CUBEPROGRAMMERAPI_API int ConnectCanBootloader(canConnectParameters);
	CUBEPROGRAMMERAPI_API int ConnectI2cBootloader(i2cConnectParameters);

	// General purposes functions
	CUBEPROGRAMMERAPI_API void SetDisplayCallbacks(displayCallBacks);
	CUBEPROGRAMMERAPI_API void SetVerbosityLevel(int);
	CUBEPROGRAMMERAPI_API int CheckDeviceConnection();
	CUBEPROGRAMMERAPI_API generalInf* GetDeviceGeneralInf();
	CUBEPROGRAMMERAPI_API int ReadMemory(unsigned int, unsigned char**, unsigned int);
	CUBEPROGRAMMERAPI_API int WriteMemory(unsigned int, char*, unsigned int);
	CUBEPROGRAMMERAPI_API int EditSector(unsigned int, char*, unsigned int);
	CUBEPROGRAMMERAPI_API int DownloadFile(const wchar_t*, unsigned int, unsigned int, unsigned int, const wchar_t*);
	CUBEPROGRAMMERAPI_API int Execute(unsigned int);
	CUBEPROGRAMMERAPI_API int MassErase(char*);
	CUBEPROGRAMMERAPI_API int SectorErase(unsigned int [], unsigned int, char*);
	CUBEPROGRAMMERAPI_API int ReadUnprotect();
	CUBEPROGRAMMERAPI_API int TzenRegression();
	CUBEPROGRAMMERAPI_API int  GetTargetInterfaceType();
	CUBEPROGRAMMERAPI_API volatile int* GetCancelPointer();
	CUBEPROGRAMMERAPI_API void* FileOpen(const wchar_t*);
	CUBEPROGRAMMERAPI_API void FreeFileData(fileData_C*);
	CUBEPROGRAMMERAPI_API int Verify(fileData_C*, unsigned int);
	CUBEPROGRAMMERAPI_API int SaveFileToFile(fileData_C*, const wchar_t*);
	CUBEPROGRAMMERAPI_API int SaveMemoryToFile(int, int, const wchar_t*);
	CUBEPROGRAMMERAPI_API void Disconnect();
	CUBEPROGRAMMERAPI_API void DeleteInterfaceList();
	CUBEPROGRAMMERAPI_API void AutomaticMode(const wchar_t*, unsigned int, unsigned int, unsigned int, int, char*, int);
	CUBEPROGRAMMERAPI_API int GetStorageStructure(storageStructure**);

	// Option Bytes functions
	CUBEPROGRAMMERAPI_API int SendOptionBytesCmd(char*);
	CUBEPROGRAMMERAPI_API peripheral_C* InitOptionBytesInterface();
	CUBEPROGRAMMERAPI_API peripheral_C* FastRomInitOptionBytesInterface(uint16_t);
	CUBEPROGRAMMERAPI_API int ObDisplay();

	// Loaders functions
	CUBEPROGRAMMERAPI_API void SetLoadersPath(const char*);
	CUBEPROGRAMMERAPI_API void SetExternalLoaderPath(const char*, externalLoader**);
	CUBEPROGRAMMERAPI_API int  GetExternalLoaders(const char*, externalStorageInfo**);
	CUBEPROGRAMMERAPI_API void RemoveExternalLoader(const char*);
	CUBEPROGRAMMERAPI_API void DeleteLoaders();

	// STM32WB specific functions
	CUBEPROGRAMMERAPI_API int GetUID64(unsigned char**);
	CUBEPROGRAMMERAPI_API int FirmwareDelete();
	CUBEPROGRAMMERAPI_API int FirmwareUpgrade(const wchar_t*, unsigned int, unsigned int, unsigned int, unsigned int);
	CUBEPROGRAMMERAPI_API int StartWirelessStack();
	CUBEPROGRAMMERAPI_API int UpdateAuthKey(const wchar_t*);
	CUBEPROGRAMMERAPI_API int AuthKeyLock();
	CUBEPROGRAMMERAPI_API int WriteUserKey(const wchar_t*, unsigned char);
	CUBEPROGRAMMERAPI_API int AntiRollBack();
	CUBEPROGRAMMERAPI_API int StartFus();
	CUBEPROGRAMMERAPI_API int Unlockchip();

	// STM32MP specific functions
	CUBEPROGRAMMERAPI_API int ProgramSsp(const wchar_t*, const wchar_t*, const wchar_t*, int);

	// STM32 HSM specific functions
	CUBEPROGRAMMERAPI_API const char* GetHsmFirmwareID(int);
	CUBEPROGRAMMERAPI_API unsigned long GetHsmCounter(int);
	CUBEPROGRAMMERAPI_API const char* GetHsmState(int);
	CUBEPROGRAMMERAPI_API const char* GetHsmVersion(int);
	CUBEPROGRAMMERAPI_API const char* GetHsmType(int);
	CUBEPROGRAMMERAPI_API int GetHsmLicense(int , const wchar_t*);
}