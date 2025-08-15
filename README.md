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
| ![C#](https://img.shields.io/badge/C%23-239120?style=flat&logo=c-sharp&logoColor=white) | ✅ Active | Coming Soon | ✅ |
| ![C](https://img.shields.io/badge/C-00599C?style=flat&logo=c&logoColor=white) | ❌ Not Available | - | ❌ |
| ![C++](https://img.shields.io/badge/C++-00599C?style=flat&logo=c%2B%2B&logoColor=white) | ❌ Not Available | - | ❌ |

## 📁 Project Structure

```
📦 leetcode
├── 📂 src/                    # Solution implementations
├── 📂 templates/              # Project templates for each language
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

2. **Navigate to the C# directory:**
   ```bash
   cd src/csharp/
   ```

3. **Verify your development environment:**
   ```bash
   # For C#
   dotnet --version
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
   # Create new problem directory in src
   mkdir -p ../../src/csharp/00001-two-sum
   cp -r . ../../src/csharp/00001-two-sum/
   cd ../../src/csharp/00001-two-sum/
   ```

3. **Restore dependencies and run initial tests:**
   ```bash
   dotnet restore
   dotnet build
   dotnet test
   ```

4. **Start coding:**
   - Edit `Solutions.cs` to implement your solution
   - Update `Tests/SolutionMethodTest.cs` to add test cases
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

### Running Tests

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

## 📊 Problem Categories

| Category | Count | Difficulty Breakdown |
|----------|-------|---------------------|
| 🔢 **Array** | Coming Soon | Easy: 0, Medium: 0, Hard: 0 |
| 🔗 **Linked List** | Coming Soon | Easy: 0, Medium: 0, Hard: 0 |
| 🌳 **Tree** | Coming Soon | Easy: 0, Medium: 0, Hard: 0 |
| 📈 **Dynamic Programming** | Coming Soon | Easy: 0, Medium: 0, Hard: 0 |
| 🔍 **Two Pointers** | Coming Soon | Easy: 0, Medium: 0, Hard: 0 |
| 📊 **Graph** | Coming Soon | Easy: 0, Medium: 0, Hard: 0 |

## 🤝 Contributing

Contributions are welcome! Please feel free to submit a Pull Request. For major changes, please open an issue first to discuss what you would like to change.

### Contributing Guidelines

1. **Fork the repository**
2. **Create a feature branch** (`git checkout -b feature/problem/solution`)
3. **Follow the existing code style** and template structure
4. **Add comprehensive tests** for your solution
5. **Update documentation** if necessary
6. **Commit your changes** (`git commit -am 'feat: add solution for problem...'`)
7. **Push to the branch** (`git push origin feature/problem/solution`)
8. **Create a Pull Request**

### Code Style Guidelines

- **Use meaningful variable names** and add comments for complex logic
- **Follow C# formatting conventions** (There is a check workflow for C# formatting)
- **Include time and space complexity analysis** in code comments
- **Write comprehensive unit tests** covering edge cases
- **Document your approach** in the README template

## 📚 Resources

- [LeetCode Official Website](https://leetcode.com/)
- [Algorithm Complexity Cheat Sheet](https://www.bigocheatsheet.com/)
- [C# Documentation](https://docs.microsoft.com/en-us/dotnet/csharp/)

## 📄 License

This project is licensed under the MIT License - see the [LICENSE](LICENSE) file for details.

## 🙏 Acknowledgments

- Thanks to [LeetCode](https://leetcode.com/) for providing an excellent platform for coding practice
- Inspired by the programming community's collaborative spirit
- Special thanks to all contributors who help improve this repository

---

**Happy Coding! 🚀**

*"The only way to learn a new programming language is by writing programs in it." - Dennis Ritchie*
