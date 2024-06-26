// dllmain.cpp : Defines the entry point for the DLL application.
#include "pch.h"

using namespace std;

DWORD dwTlsIndex; // address of shared memory

const char* loaderPath = "";

// https://github.com/K-Society/KSociety.SharpCubeProgrammer/blob/master/src/01/Programmer/dllmain.cpp#L21
static BOOL APIENTRY InitialSTLink(HMODULE hModule)
{
    WCHAR dllName[MAX_PATH + 1];
    DWORD size = 0;

    size = GetModuleFileNameW(hModule, dllName, MAX_PATH);
    if (size > 0)
    {
        // Path of DLL file
        wstring dllNameStr(dllName);
        // SIze of DLL File Path minus DLL File Name Size
        size_t pos = dllNameStr.size() - sizeof(DLLFILENAME); // DLLFILENAME in Preprocessors Definitions in project properties ---->  DLLFILENAME=R"($(TargetName)$(TargetExt))"
        // Subtract File Name From Path
        dllNameStr = dllNameStr.substr(0, pos);
        replace(dllNameStr.begin(), dllNameStr.end(), '\\', '/');
        const wchar_t* input = dllNameStr.c_str();

        // Count required buffer size (plus one for null-terminator).
        size_t bufferSize = (wcslen(input) + 1) * sizeof(wchar_t);
        char* buffer = new char[bufferSize];

        size_t convertedSize;
        wcstombs_s(&convertedSize, buffer, bufferSize, input, bufferSize);

        // Set device loaders path that contains FlashLoader and ExternalLoader folders.
        SetLoadersPath(buffer);

        loaderPath = _strdup(buffer);
        delete[] buffer;

        return 1;
    }
    return 0;
}

// https://learn.microsoft.com/en-us/windows/win32/dlls/using-thread-local-storage-in-a-dynamic-link-library
BOOL APIENTRY DllMain(HMODULE hModule, DWORD  ul_reason_for_call, LPVOID lpReserved)
{
    LPVOID lpvData;
    BOOL fIgnore;
    BOOL result = FALSE;
    switch (ul_reason_for_call)
    {
        // The DLL is loading due to process 
        // initialization or a call to LoadLibrary. 
    case DLL_PROCESS_ATTACH:
        // Allocate a TLS index.
        if ((dwTlsIndex = TlsAlloc()) == TLS_OUT_OF_INDEXES)
            return FALSE;

        result = InitialSTLink(hModule);
        if (!result)
            return FALSE;
        // No break: Initialize the index for first thread.
    // The attached process creates a new thread.
    case DLL_THREAD_ATTACH:
        // Initialize the TLS index for this thread.
        lpvData = (LPVOID)LocalAlloc(LPTR, 256);
        if (lpvData != NULL)
            fIgnore = TlsSetValue(dwTlsIndex, lpvData);
        break;
        // The thread of the attached process terminates.
    case DLL_THREAD_DETACH:
        // Release the allocated memory for this thread.
        lpvData = TlsGetValue(dwTlsIndex);
        if (lpvData != NULL)
            LocalFree((HLOCAL)lpvData);
        break;
        // DLL unload due to process termination or FreeLibrary. 
    case DLL_PROCESS_DETACH:
        // Release the allocated memory for this thread.
        deleteInterfaceList();
        lpvData = TlsGetValue(dwTlsIndex);
        if (lpvData != NULL)
            LocalFree((HLOCAL)lpvData);
        // Release the TLS index.
        TlsFree(dwTlsIndex);
        break;
    default:
        break;
    }
    return TRUE;
    UNREFERENCED_PARAMETER(hModule);
    UNREFERENCED_PARAMETER(lpReserved);
}

