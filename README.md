# 🧩 LeetCode Solutions Collection

[![GitHub license](https://img.shields.io/github/license/LongDorat/leetcode)](https://github.com/LongDorat/leetcode/blob/main/LICENSE)
[![GitHub stars](https://img.shields.io/github/stars/LongDorat/leetcode)](https://github.com/LongDorat/leetcode/stargazers)
[![GitHub forks](https://img.shields.io/github/forks/LongDorat/leetcode)](https://github.com/LongDorat/leetcode/network)

A comprehensive collection of LeetCode problem solutions implemented in multiple programming languages, featuring clean code, detailed explanations, and extensive test coverage.

## 🚀 Overview

This repository contains my solutions to various LeetCode problems, organized by language. Each solution includes:

- ✅ **Clean, readable code** with proper documentation
- 📖 **Detailed explanations** of algorithms and approaches
- ⚡ **Time and space complexity analysis**
- 🧪 **Comprehensive unit tests**
- 🎯 **Multiple solution approaches** when applicable

## 🛠️ Supported Languages

| Language | Status | Solutions Count | Template Available |
|----------|--------|----------------|-------------------|
| ![C#](https://img.shields.io/badge/C%23-239120?style=flat&logo=c-sharp&logoColor=white) | ✅ Active | 1 | ✅ |
| ![C++](https://img.shields.io/badge/C++-00599C?style=flat&logo=c%2B%2B&logoColor=white) | ✅ Active | 1 | ✅ |
| ![C](https://img.shields.io/badge/C-00599C?style=flat&logo=c&logoColor=white) | ❌ Not Available | - | ❌ |

## 📁 Project Structure

```
📦 leetcode
├── 📂 src/                    # Solution implementations
│   ├── 📂 csharp/             # C# solutions
│   └── 📂 cpp/                # C++ solutions
├── 📂 templates/              # Project templates for each language
│   ├── 📂 csharp/             # C# project template
│   └── 📂 cpp/                # C++ project template
├── 📄 README.md               # This file
└── 📄 LICENSE                 # Project license
```

## 🎯 Getting Started

### Prerequisites

Choose one of the following setup methods:

#### 🐳 DevContainer Setup (Recommended)
**Perfect for consistent development environment across all languages**
- [Docker Desktop](https://www.docker.com/products/docker-desktop) 
- [Visual Studio Code](https://code.visualstudio.com/) with the [Dev Containers extension](https://marketplace.visualstudio.com/items?itemName=ms-vscode-remote.remote-containers)

#### 💻 Local Development Setup
**For developers who prefer local tooling**

**For C# Development:**
- [.NET 9.0 SDK](https://dotnet.microsoft.com/download/dotnet/9.0) or later
- Visual Studio 2022 / VS Code with C# extension

**For C++ Development:**
- **CMake 3.14** or later
- **C++17 compatible compiler:**
  - **Windows:** Visual Studio 2019+ or MinGW-w64
  - **Linux:** GCC 7+ or Clang 5+
  - **macOS:** Xcode 10+ or Clang 5+
- **clang-format** (optional, for code formatting)

### 🔧 Setup Instructions

#### 🐳 DevContainer Setup (Recommended)

This method provides a consistent, pre-configured development environment with all necessary tools installed.

1. **Clone the repository:**
   ```bash
   git clone https://github.com/LongDorat/leetcode.git
   cd leetcode
   ```

2. **Open the project in Visual Studio Code:**
   ```bash
   code .
   ```

3. **Open in DevContainer:**
   - VS Code will automatically detect the DevContainer configuration
   - Click "Reopen in Container" when prompted, or
   - Press `Ctrl+Shift+P` (or `Cmd+Shift+P` on macOS) and select `Dev Containers: Reopen in Container`

4. **Wait for container setup:**
   - First-time setup may take a few minutes to download and configure the container
   - All development tools and dependencies will be automatically installed

#### 💻 Local Development Setup

1. **Clone the repository:**
   ```bash
   git clone https://github.com/LongDorat/leetcode.git
   cd leetcode
   ```

2. **Navigate to a language's directory:**
   ```bash
   cd src/csharp/
   ```

3. **Verify your development environment:**
   ```bash
   # For C#
   dotnet --version
   
   # For C++
   cmake --version
   g++ --version  # or clang++ --version on macOS
   ```

### 🚀 Quick Start - Creating Your First Solution

Once your environment is set up, you can quickly create a new problem solution:

#### Using C# Template

1. **Navigate to the C# templates directory:**
   ```bash
   cd templates/csharp/
   ```

2. **Copy the template to a new problem directory:**
   ```bash
   # Create new problem directory in src (example: problem 26)
   mkdir -p ../../src/csharp/00026-remove-duplicates
   cp -r . ../../src/csharp/00026-remove-duplicates/
   cd ../../src/csharp/00026-remove-duplicates/
   ```

3. **Initialize a new xUnit project and adding dependency**
   ```bash
   dotnet new xunit -o ".\" -n "ProblemName" -f net9.0
   ```
   ```bash
   dotnet add package Microsoft.Extensions.DependencyInjection
   ```

4. **Add the new project into the solution file**
   ```bash
   cd src/csharp
   dotnet sln add /00001-two-sum/TwoSum.csproj
   ```

5. **Start coding:**
   - Edit `Solutions.cs` to implement your solution
   - Update `Tests/SolutionMethodTest.cs` to add test cases
   - Modify `README.md` with problem details

#### Using C++ Template

1. **Navigate to the C++ templates directory:**
   ```bash
   cd templates/cpp/
   ```

2. **Copy the template to a new problem directory:**
   ```bash
   # Create new problem directory in src (example: problem 26)
   mkdir -p ../../src/cpp/00026-remove-duplicates
   cp -r . ../../src/cpp/00026-remove-duplicates/
   cd ../../src/cpp/00026-remove-duplicates/
   ```

3. **Configure and build the project:**
   ```bash
   # Configure CMake (creates build directory)
   cmake -B build -DCMAKE_BUILD_TYPE=Debug
   
   # Build the project
   cmake --build build
   ```

4. **Start coding:**
   - Edit `Solutions.hpp` to declare your solution functions
   - Edit `Solutions.cpp` to implement your solutions
   - Update test files in `Tests/` directory to add test cases
   - Modify `CMakeLists.txt` at the `add_executable` section to include your new test files
   - Modify `README.md` with problem details

## 📝 Solution Template Usage

### C# Template

Each C# solution follows this structure:

```csharp
namespace ProblemSolution;

public interface ISolutions
{
    /// <summary>
    /// Problem description summary
    /// </summary>
    /// <param name="input">Input parameter description</param>
    /// <returns>Return value description</returns>
    /// <remarks>Time Complexity: O(n) | Space Complexity: O(1)</remarks>
    ReturnType SolutionMethod(InputType input);
}

public class Solutions : ISolutions
{
    public ReturnType SolutionMethod(InputType input)
    {
        // Implementation here
        return result;
    }
}
```

### C++ Template

Each C++ solution follows this structure:

**Solutions.hpp:**
```cpp
#ifndef SOLUTIONS_HPP
#define SOLUTIONS_HPP

#include "IncludeLib.hpp"

/**
 * @brief Problem description summary
 * @param input Input parameter description
 * @return Return value description
 * @note Time Complexity: O(n) | Space Complexity: O(1)
 */
int SolutionName(int args);

#endif
```

**Solutions.cpp:**
```cpp
#include "Solutions.hpp"

int SolutionName(int args) {
    // Implementation here
    return true;
}
```

**Test Structure:**
```cpp
#include <gtest/gtest.h>
#include "../Solutions.hpp"

TEST(SolutionNameTest, BasicFunctionality) {
    EXPECT_EQ(expected_result, SolutionName(input));
}
```

### Running Tests

#### C# Tests
```bash
# Navigate to solution directory
cd src/csharp/problem-name/

# Run all tests
dotnet test

# Run tests with detailed output
dotnet test --verbosity normal

# Run specific test
dotnet test --filter "TestMethodName"
```

#### C++ Tests
```bash
# Navigate to solution directory
cd src/cpp/problem-name/

# Build the project (if not already built)
cmake --build build

# Run all tests
ctest --test-dir build --output-on-failure

# Run specific test
ctest --test-dir build -R "TestName" --output-on-failure

# Run tests with verbose output
ctest --test-dir build --output-on-failure --verbose
```

## 📊 Solutions Overview

📋 **[View All Solutions →](SOLUTIONS.md)**

**Quick Info:**
- 🎯 **Total Problems Solved:** 1
- 🟢 **Easy:** 1 | 🟡 **Medium:** 0 | 🔴 **Hard:** 0

## 🤝 Contributing

Contributions are welcome! Please feel free to submit a Pull Request. For major changes, please open an issue first to discuss what you would like to change.

### Contributing Guidelines

1. **Fork the repository**
2. **Create a feature branch** (`git checkout -b feature/problem number/language (e.g feature/00001/cs)`)
3. **Follow the existing code style** and template structure
4. **Add comprehensive tests** for your solution
5. **Update documentation** if necessary
6. **Commit your changes** (`git commit -am 'feat: add solution for problem...'`)
7. **Push to the branch** (`git push origin feature/problem number/language`)
8. **Create a Pull Request**

### Code Style Guidelines

- **Use meaningful variable names** and add comments for complex logic
- **Follow language-specific formatting conventions:**
  - **C#:** There is an automated formatting workflow
  - **C++:** There is an automated clang-format workflow
- **Include time and space complexity analysis** in code comments
- **Write comprehensive unit tests** covering edge cases
- **Document your approach** in the README template

## 📚 Resources

- [LeetCode Official Website](https://leetcode.com/)
- [Algorithm Complexity Cheat Sheet](https://www.bigocheatsheet.com/)
- [C# Documentation](https://docs.microsoft.com/en-us/dotnet/csharp/)
- [C++ Reference](https://en.cppreference.com/)
- [GoogleTest Documentation](https://google.github.io/googletest/)
- [CMake Documentation](https://cmake.org/documentation/)

## 📄 License

This project is licensed under the MIT License - see the [LICENSE](LICENSE) file for details.

## 🙏 Acknowledgments

- Thanks to [LeetCode](https://leetcode.com/) for providing an excellent platform for coding practice
- Inspired by the programming community's collaborative spirit
- Special thanks to all contributors who help improve this repository

---

**Happy Coding! 🚀**

*"The only way to learn a new programming language is by writing programs in it." - Dennis Ritchie*
