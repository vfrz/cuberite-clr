target_sources(
        ${CMAKE_PROJECT_NAME} PRIVATE

        coreclr_delegates.h
        hostfxr.h
        nethost.h

        ClrLoader.h
        ClrLoader.cpp

        ClrWrapper.h
        ClrWrapper.cpp

        ClrHooks.h

        ClrCommandHandler.h
        ClrCommandHandler.cpp
)

if (UNIX AND NOT APPLE)
    target_link_libraries(${CMAKE_PROJECT_NAME} PRIVATE ${CMAKE_SOURCE_DIR}/src/CLR/libnethost.so)
endif ()
if (WIN32)
endif ()