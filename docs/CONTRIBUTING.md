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
   git clone https://github.com/longdorat/leetcode.git
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

#### Python
- Follow [PEP 8](https://pep8.org/) style guidelines
- Use type hints where appropriate
- Maximum line length: 88 characters (Black formatter standard)
- Use descriptive variable names: `left_pointer` instead of `l`

#### Java
- Follow [Google Java Style Guide](https://google.github.io/styleguide/javaguide.html)
- Use camelCase for variables and methods
- Use PascalCase for class names
- Include proper access modifiers

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

### Naming Conventions

Follow language-specific naming conventions with these examples:

#### Python
```python
# Variables and functions: snake_case
target_sum = 9
left_pointer = 0
right_pointer = len(nums) - 1

def two_sum(nums, target):
    pass

def find_longest_substring(s):
    pass

# Classes: PascalCase
class ListNode:
    pass

class TreeNode:
    pass

# Constants: SCREAMING_SNAKE_CASE
MAX_INT_VALUE = 2**31 - 1
DEFAULT_CAPACITY = 16
```

#### Java
```java
// Variables and methods: camelCase
int targetSum = 9;
int leftPointer = 0;
int rightPointer = nums.length - 1;

public int[] twoSum(int[] nums, int target) {
    // Implementation
}

public String findLongestSubstring(String s) {
    // Implementation
}

// Classes: PascalCase
public class ListNode {
    int val;
    ListNode next;
}

public class TreeNode {
    int val;
    TreeNode left;
    TreeNode right;
}

// Constants: SCREAMING_SNAKE_CASE
public static final int MAX_INT_VALUE = Integer.MAX_VALUE;
public static final int DEFAULT_CAPACITY = 16;
```

#### C/C++
```cpp
// Variables and functions: snake_case
int target_sum = 9;
int left_pointer = 0;
int right_pointer = nums.size() - 1;

std::vector<int> two_sum(std::vector<int>& nums, int target) {
    // Implementation
}

std::string find_longest_substring(std::string s) {
    // Implementation
}

// Structs/Classes: PascalCase
struct ListNode {
    int val;
    ListNode* next;
};

class TreeNode {
public:
    int val;
    TreeNode* left;
    TreeNode* right;
};

// Constants: SCREAMING_SNAKE_CASE or kConstantName
const int MAX_INT_VALUE = INT_MAX;
const int DEFAULT_CAPACITY = 16;
```

#### C#
```csharp
// Local variables and parameters: camelCase
int targetSum = 9;
int leftPointer = 0;
int rightPointer = nums.Length - 1;

// Public methods: PascalCase
public int[] TwoSum(int[] nums, int target) 
{
    // Implementation
}

public string FindLongestSubstring(string s) 
{
    // Implementation
}

// Classes: PascalCase
public class ListNode 
{
    public int Val { get; set; }
    public ListNode Next { get; set; }
}

public class TreeNode 
{
    public int Val { get; set; }
    public TreeNode Left { get; set; }
    public TreeNode Right { get; set; }
}

// Constants: PascalCase
public const int MaxIntValue = int.MaxValue;
public const int DefaultCapacity = 16;

// Private fields: camelCase with underscore prefix
private int _targetSum;
private readonly List<int> _results;
```

#### File Naming Conventions

- **Problem directories**: Use kebab-case: `0001-two-sum`, `0042-trapping-rain-water`
- **Solution files**: 
  - Python: `solution.py`
  - Java: `Solution.java`
  - C++: `solution.cpp`
  - C#: `Solution.cs`
- **Test files**: 
  - Python: `solution_test.py`
  - Java: `SolutionTest.java`
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

### Comprehensive Test Coverage

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