cmake_minimum_required(VERSION 3.14)
project(ProblemName)

set(CMAKE_CXX_STANDARD 17)
set(CMAKE_CXX_STANDARD_REQUIRED ON)

set(CMAKE_EXPORT_COMPILE_COMMANDS ON)

include(FetchContent)
FetchContent_Declare(
  googletest
  GIT_REPOSITORY https://github.com/google/googletest.git
  GIT_TAG        v1.17.0
)
# For Windows: Prevent overriding the parent project's compiler/linker settings
set(gtest_force_shared_crt ON CACHE BOOL "" FORCE)
FetchContent_MakeAvailable(googletest)

enable_testing()

add_executable(
    SolutionTests
    Solutions.cpp
    Tests/SolutionTests.cpp
)

target_link_libraries(
    SolutionTests
    GTest::gtest_main
)

include(GoogleTest)
gtest_discover_tests(SolutionTests)