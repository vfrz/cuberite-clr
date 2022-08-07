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
    target_link_libraries(${CMAKE_PROJECT_NAME} PRIVATE ${CMAKE_SOURCE_DIR}/src/CLR/linux-x64/libnethost.so)
endif ()
if (WIN32)
    target_link_libraries(${CMAKE_PROJECT_NAME} PRIVATE ${CMAKE_SOURCE_DIR}/src/CLR/win-x64/libnethost.lib)
endif ()

file(MAKE_DIRECTORY ${CMAKE_BINARY_DIR}/Server/clr)
add_custom_target(COPY_CLR_FILES
        COMMAND ${CMAKE_COMMAND} -E copy_directory ${CMAKE_SOURCE_DIR}/clr/CuberiteClr.Runtime/bin/Release/net7.0/publish ${CMAKE_BINARY_DIR}/Server/clr/
        )
add_dependencies(${CMAKE_PROJECT_NAME} COPY_CLR_FILES)