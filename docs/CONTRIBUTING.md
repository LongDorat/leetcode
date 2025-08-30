# Contributing Guidelines

Welcome to the LeetCode Solutions Collection! We appreciate your interest in contributing to this repository. This guide will help you understand how to contribute effectively and maintain the high quality standards of our solutions.

## 📋 Table of Contents

- [Getting Started](#getting-started)
- [Code Style and Standards](#code-style-and-standards)
- [How to Submit Solutions](#how-to-submit-solutions)
- [Testing Requirements](#testing-requirements)
- [Documentation Standards](#documentation-standards)
- [Pull Request Process](#pull-request-process)
- [Issue Guidelines](#issue-guidelines)
- [Community Guidelines](#community-guidelines)

## 🚀 Getting Started

### Prerequisites

Before contributing, ensure you have:
- Completed the [Quick Start setup](../README.md#-quick-start) from the main README
- Familiarized yourself with the [project structure](../README.md#-project-structure)
- Read through existing solutions to understand our standards

### Setting Up Your Development Environment

1. **Fork the repository** on GitHub
2. **Clone your fork** locally:
   ```bash
   git clone https://github.com/YOUR_USERNAME/leetcode.git
   cd leetcode
   ```
3. **Run the setup script**:
   ```bash
   ./scripts/setup.ps1
   ```

## 🎨 Code Style and Standards

### General Principles

- **Clarity over cleverness**: Write code that is easy to understand
- **Consistency**: Follow the established patterns in the repository
- **Efficiency**: Optimize for time and space complexity when possible
- **Readability**: Use meaningful variable names and add comments for complex logic

### Language-Specific Standards

#### C/C++
- Follow [Google C++ Style Guide](https://google.github.io/styleguide/cppguide.html)
- Use snake_case for variables and functions
- Use PascalCase for class names
- Prefer `std::` prefix over `using namespace std`

#### C#
- Follow [Microsoft C# Coding Conventions](https://docs.microsoft.com/en-us/dotnet/csharp/fundamentals/coding-style/coding-conventions)
- Use PascalCase for public members and methods
- Use camelCase for private fields and local variables
- Use meaningful names and avoid abbreviations

### File Naming Conventions

- **Problem directories**: Use kebab-case: `0001-two-sum`, `0042-trapping-rain-water`
- **Solution files**: 
  - C++: `solution.cpp`
  - C#: `Solution.cs`
- **Test files**: 
  - C++: `solution_test.cpp`
  - C#: `SolutionTest.cs`

## 📝 How to Submit Solutions

### Creating a New Solution

1. **Use the problem creation script**:
   ```bash
   ./scripts/new-problem.ps1
   ```

2. **Follow the interactive prompts** to set up the problem structure

3. **Implement your solution** following these guidelines:
   - Start with a brute force approach if applicable
   - Optimize step by step
   - Include multiple approaches when beneficial
   - Add detailed comments explaining the algorithm

### Solution Structure

Each solution should include:

```
problems/<language>/<number>-<name>/
├── solution.<ext>           # Main solution file
├── README.md               # Problem description and explanation
└── tests/                  # Test cases directory
    ├── <name | approach>_test.<ext> # Main test file
    └── benchmarks.<ext>    # Performance benchmarks (optional)
```

## 🧪 Testing Requirements

### Test Coverage

Your solution must include:

- **Edge cases**: Empty inputs, single elements, maximum constraints
- **Normal cases**: Typical problem scenarios
- **Boundary cases**: Minimum and maximum values
- **Corner cases**: Unusual but valid inputs

### Performance Testing

For solutions with time/space complexity considerations:
- Include performance benchmarks for large inputs
- Compare different approaches when applicable
- Document the trade-offs between different solutions

## 📚 Documentation Standards

### README.md for Each Problem

Each problem's README.md should include:

1. **Problem Statement**: Clear description of the problem
2. **Examples**: Input/output examples with explanations
3. **Constraints**: All problem constraints
4. **Approach**: Detailed explanation of the solution approach. Include multiple approaches if applicable
5. **Complexity Analysis**: Time and space complexity
6. **Key Insights**: Important observations or patterns
7. **Related Problems**: Links to similar problems
8. **Metadata**: Additional information, such as source links, difficulty levels, etc.

## 🔄 Pull Request Process

### Before Submitting

1. **Create a feature branch**:
   ```bash
   git checkout -b problem/language/number
   ```

2. **Test your solution** thoroughly

3. **Update documentation** as needed

### Pull Request Guidelines

1. **Title Format**: `Add solution for Problem XXXX: Problem Name`

2. **Description Template**:
   ```markdown
   ## Problem Information
   - **Problem Number**: XXXX
   - **Problem Name**: [Name]
   - **Difficulty**: Easy/Medium/Hard
   - **Language**: Python/Java/C++/etc.
   
   ## Solution Summary
   - **Approach**: [Brief description]
   - **Time Complexity**: O(...)
   - **Space Complexity**: O(...)
   
   ## Additional Notes
   [Any additional context or considerations]
   ```

## 🐛 Issue Guidelines

### Reporting Bugs

When reporting a bug, include:
- **Problem number and name**
- **Programming language**
- **Description of the issue**
- **Steps to reproduce**
- **Expected vs actual behavior**
- **Environment details** (OS, language version, etc.)

### Suggesting Enhancements

For enhancement suggestions:
- **Clear description** of the proposed feature
- **Justification** for why it would be valuable
- **Possible implementation** approach
- **Potential drawbacks** or considerations

### Feature Requests

We welcome requests for:
- New programming language support
- Additional solution approaches
- Improved tooling and scripts
- Documentation improvements

## 🤝 Community Guidelines

### Code of Conduct

- **Be respectful** and constructive in all interactions
- **Help others learn** by providing clear explanations
- **Give credit** where credit is due
- **Focus on the code**, not the person

## 🎯 Quality Standards

> **Before your code is merged**, it will be reviewed by automatic workflows to ensure compliance with quality standards, including testing and formatting.

Thank you for contributing to the LeetCode Solutions Collection! Your efforts help create a valuable resource for the programming community. 🎉

---

For questions about contributing, please [open an issue](https://github.com/longdorat/leetcode/issues) or reach out to the maintainers.
