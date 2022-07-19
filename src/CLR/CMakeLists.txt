target_sources(
        ${CMAKE_PROJECT_NAME} PRIVATE

        coreclr_delegates.h
        hostfxr.h
        nethost.h

        ClrLoader.h
        ClrLoader.cpp

        Wrappers/ClrPlayerWrapper.cpp
        Wrappers/ClrPlayerWrapper.h

        Wrappers/ClrRootWrapper.cpp
        Wrappers/ClrRootWrapper.h
)

if (UNIX AND NOT APPLE)
    target_link_libraries(${CMAKE_PROJECT_NAME} PRIVATE ${CMAKE_SOURCE_DIR}/src/CLR/libnethost.so)
endif ()
if (WIN32)
endif ()