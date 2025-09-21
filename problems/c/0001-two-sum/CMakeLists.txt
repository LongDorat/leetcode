cmake_minimum_required(VERSION 4.0)
project(two_sum C)

set(CMAKE_C_STANDARD 17)

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
add_executable(two_sum solution.c ${TEST_SOURCES})

# Link Unity framework
target_link_libraries(two_sum PRIVATE unity)

target_include_directories(two_sum PRIVATE
    ${unity_SOURCE_DIR}/src
)

enable_testing()

add_test(NAME two_sum_tests COMMAND two_sum)

set_tests_properties(two_sum_tests PROPERTIES
    WORKING_DIRECTORY ${CMAKE_CURRENT_BINARY_DIR}
)
