#include "ClrLoader.h"

void ClrLoader::Initialize(const char *runtime_config_path) {
    bool hostFxrLoaded = TryLoadHostFxr();
    if (hostFxrLoaded)
        load_assembly_and_get_function_pointer_fptr = GetLoadAssemblyAndGetFunctionPointerFn(runtime_config_path);
}

bool ClrLoader::TryLoadHostFxr() {
    char buffer[4096];
    size_t buffer_size = sizeof(buffer) / sizeof(char);
    int rc = get_hostfxr_path(buffer, &buffer_size, nullptr);
    if (rc != 0)
        return false;

    void *lib = LoadLibrary(buffer);
    init_fptr = (hostfxr_initialize_for_runtime_config_fn) GetExport(lib, "hostfxr_initialize_for_runtime_config");
    get_delegate_fptr = (hostfxr_get_runtime_delegate_fn) GetExport(lib, "hostfxr_get_runtime_delegate");
    close_fptr = (hostfxr_close_fn) GetExport(lib, "hostfxr_close");

    return (init_fptr && get_delegate_fptr && close_fptr);
}

void *ClrLoader::LoadLibrary(const char *path) {
    void *handle = dlopen(path, RTLD_LAZY | RTLD_LOCAL);
    assert(handle != nullptr);
    return handle;
}

void *ClrLoader::GetExport(void *h, const char *name) {
    void *address = dlsym(h, name);
    assert(address != nullptr);
    return address;
}

load_assembly_and_get_function_pointer_fn
ClrLoader::GetLoadAssemblyAndGetFunctionPointerFn(const char *runtime_config_path) {
    // Load .NET Core
    void *load_assembly_and_get_function_pointer = nullptr;
    hostfxr_handle cxt = nullptr;
    int rc = init_fptr(runtime_config_path, nullptr, &cxt);
    if (rc != 0 || cxt == nullptr) {
        std::cerr << "Init failed: " << std::hex << std::showbase << rc << std::endl;
        close_fptr(cxt);
        return nullptr;
    }

    // Get the load assembly function pointer
    rc = get_delegate_fptr(cxt, hdt_load_assembly_and_get_function_pointer, &load_assembly_and_get_function_pointer);
    if (rc != 0 || load_assembly_and_get_function_pointer == nullptr)
        std::cerr << "Get delegate failed: " << std::hex << std::showbase << rc << std::endl;

    close_fptr(cxt);
    return (load_assembly_and_get_function_pointer_fn) load_assembly_and_get_function_pointer;
}

void ClrLoader::LoadAssemblyAndGetFunctionPointer(const char *assembly_path, const char *type_name,
                                                  const char *method_name, const char *delegate_type_name,
                                                  void **delegate) {
    int rc = load_assembly_and_get_function_pointer_fptr(
            assembly_path,
            type_name,
            method_name,
            delegate_type_name,
            nullptr,
            delegate);
    assert(rc == 0 && delegate != nullptr && "Failure: LoadAssemblyAndGetFunctionPointer()");
}
