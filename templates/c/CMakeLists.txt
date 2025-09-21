cmake_minimum_required(VERSION 3.16)
project(Template C)

set(CMAKE_C_STANDARD 11)

# Download Unity testing framework
include(FetchContent)
FetchContent_Declare(
    unity
    GIT_REPOSITORY https://github.com/ThrowTheSwitch/Unity.git
    GIT_TAG v2.6.1
)
FetchContent_MakeAvailable(unity)

# Find all test files
file(GLOB_RECURSE TEST_SOURCES "tests/*.c")

# Add the solution and test files
add_executable(Template solution.c ${TEST_SOURCES})

# Link Unity framework
target_link_libraries(Template PRIVATE unity)

target_include_directories(Template PRIVATE
    ${unity_SOURCE_DIR}/src
)

enable_testing()

add_test(NAME Template_tests COMMAND Template)

set_tests_properties(Template_tests PROPERTIES
    WORKING_DIRECTORY ${CMAKE_CURRENT_BINARY_DIR}
)
