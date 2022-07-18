#ifndef TESTHOST_CLRLOADER_H
#define TESTHOST_CLRLOADER_H

#include <iostream>
#include <cassert>
#include <dlfcn.h>
#include "hostfxr.h"
#include "coreclr_delegates.h"
#include "nethost.h"

class ClrLoader {
public:
    void Initialize(const char *runtime_config_path);

    void LoadAssemblyAndGetFunctionPointer(
            const char *assembly_path,
            const char *type_name,
            const char *method_name,
            const char *delegate_type_name,
            void **delegate);

private:
    hostfxr_initialize_for_runtime_config_fn init_fptr;
    hostfxr_get_runtime_delegate_fn get_delegate_fptr;
    hostfxr_close_fn close_fptr;
    load_assembly_and_get_function_pointer_fn load_assembly_and_get_function_pointer_fptr;

    bool TryLoadHostFxr();

    load_assembly_and_get_function_pointer_fn GetLoadAssemblyAndGetFunctionPointerFn(const char *runtime_config_path);

    static void *LoadLibrary(const char *path);

    static void *GetExport(void *h, const char *name);
};

#endif