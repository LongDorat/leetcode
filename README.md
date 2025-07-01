# LeetCode Solutions in C#

A comprehensive collection of LeetCode problem solutions implemented in C# with .NET 9.0, featuring unit tests and organized structure for efficient learning and practice.

## 🎯 Project Overview

This repository contains my solutions to LeetCode problems, organized by problem ranges and implemented with modern C# practices. Each solution includes:

- **Clean, readable C# implementation**
- **Comprehensive unit tests using xUnit**
- **Detailed documentation and time/space complexity analysis**
- **Problem-specific README with multiple solution approaches**
- **Proper project structure with .csproj files**

## 📁 Project Structure

```
leetcode/
├── leetcode.sln                    # Visual Studio solution file
├── README.md                       # This file
├── LICENSE                         # Project license
└── Problems/                       # All problem solutions
    ├── 00001-00100/                # Problems 1-100
    │   ├── [00001] Two Sum/
    │   │   ├── Solution.cs         # Solution implementation
    │   │   ├── UnitTest.cs         # Unit tests
    │   │   ├── Two_Sum.csproj      # Project file
    │   │   └── README.md          # Problem-specific documentation
    │   └── [00002] Add Two Number/
    └── 00101-00200/                # Problems 101-200 and more
```

## 🛠️ Technology Stack

- **Framework**: .NET 9.0
- **Language**: C# with nullable reference types enabled
- **Testing Framework**: xUnit
- **IDE**: Visual Studio 2022 / Visual Studio Code
- **Package Manager**: NuGet

## 🚀 Getting Started

### Prerequisites

- [.NET 9.0 SDK](https://dotnet.microsoft.com/download/dotnet/9.0) or later
- Visual Studio 2022 / Visual Studio Code / JetBrains Rider (optional)

### Running the Solutions

1. **Clone the repository**

   ```bash
   git clone https://github.com/yourusername/leetcode-csharp.git
   cd leetcode-csharp
   ```
2. **Open the solution**

   ```bash
   # Using Visual Studio
   start leetcode.sln

   # Or using command line
   dotnet restore
   ```
3. **Run tests for a specific problem**

   ```bash
   cd "Problems/00001-00100/00001 Two Sum"
   dotnet test
   ```
4. **Run all tests**

   ```bash
   dotnet test
   ```

### Problem.md

Each problem folder includes a detailed Problem.md with:

- Problem description and examples
- Multiple solution approaches with complexity analysis
- Step-by-step algorithm explanation
- Test cases and edge cases

## 📊 Progress Tracking

| Range           | Completed   | Total         | Progress     |
| --------------- | ----------- | ------------- | ------------ |
| 1-100           | 3           | 100           | 3%           |
| 101-200         | 0           | 100           | 0%           |
| **Total** | **3** | **200** | **1.5%** |

## 🎯 Solved Problems

### Easy Problems

- [X] [1. Two Sum](Problems/00001-00100/00001%20Two%20Sum/) - Array, Hash Table

### Medium Problems

- [X] [2. Add Two Numbers](Problems/00001-00100/00002%20Add%20Two%20Number/) - Linked List, Math
- [X] [3. Longest Substring Without Repeating Characters](Problems/00001-00100/00003%20Longest%20Substring%20Without%20Repeating%20Characters/) - Hash Table, String, Sliding Window

### Hard Problems

*Coming soon...*

## 🧪 Testing

All solutions include comprehensive unit tests with multiple test cases:

- **Edge cases**: Empty inputs, single elements, boundary values
- **Normal cases**: Typical problem scenarios
- **Performance tests**: Large input validation (where applicable)

### Running Tests

```bash
# Run all tests
dotnet test

# Run tests with detailed output
dotnet test --verbosity normal

# Run tests for specific problem
dotnet test "Problems/00001-00100/00001 Two Sum"
```

## 🎨 Code Style Guidelines

- **Naming**: PascalCase for public members, camelCase for local variables
- **Documentation**: XML comments for public methods with complexity analysis
- **Null Safety**: Nullable reference types enabled
- **Testing**: Comprehensive test coverage with descriptive test names
- **Performance**: Time and space complexity documented

## 🤝 Contributing

Feel free to suggest improvements or alternative solutions:

1. Fork the repository
2. Create a feature branch
3. Add your solution with tests
4. Ensure all tests pass
5. Submit a pull request

## 📖 Learning Resources

- [LeetCode](https://leetcode.com/) - Original problem source
- [C# Documentation](https://docs.microsoft.com/en-us/dotnet/csharp/)
- [xUnit Documentation](https://xunit.net/)
- [Big O Cheat Sheet](https://www.bigocheatsheet.com/)

## 📄 License

This project is licensed under the MIT License - see the [LICENSE](LICENSE) file for details.

## 🏷️ Tags

`csharp` `dotnet` `leetcode` `algorithms` `data-structures` `coding-interview` `problem-solving` `xunit` `unit-testing`

---

⭐ If you find this repository helpful, please consider giving it a star!

📧 Questions or suggestions? Feel free to open an issue or reach out!
