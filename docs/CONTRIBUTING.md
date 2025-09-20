# Contributing Guidelines

Welcome to the LeetCode Solutions repository! This guide will help you understand how to contribute effectively to this project.

## 🚀 Quick Start

1. **Fork** this repository
2. **Clone** your fork locally
3. **Create** a new branch for your work
4. **Add** your solution using the provided scripts
5. **Test** your implementation thoroughly
6. **Submit** a pull request

## 📋 Table of Contents

- [Getting Started](#-getting-started)
- [Adding New Problems](#-adding-new-problems)
- [General Code Standards](#-general-code-standards)
- [Language-Specific Guidelines](#-language-specific-guidelines)
  - [C# Guidelines](#-c-guidelines)
- [Testing Guidelines](#-testing-guidelines)
- [Documentation Standards](#-documentation-standards)
- [Submission Process](#-submission-process)
- [Project Structure](#-project-structure)

---

## 🛠️ Getting Started

### Prerequisites

Before contributing, ensure you have:

- **PowerShell** (Windows PowerShell 5.1+ or PowerShell Core 7.0+)
- **Git** for version control
- **Visual Studio Code** (recommended)

Optional compilers/runtimes based on the languages you plan to contribute in:
- **.NET 9.0 SDK** or later
  
> **Note**: If any compiler/runtime is not installed, the problem creation scripts will display an error message when attempting to generate new projects for that specific language.

### Development Environment Setup

#### Option 1: Local Development

1. **Clone the repository**:
   ```powershell
   git clone https://github.com/YourUsername/leetcode.git
   cd leetcode
   ```

2. **Verify .NET installation**:
   ```powershell
   dotnet --version
   # Should output 9.0.0 or later
   ```

3. **Test the scripts**:
   ```powershell
   cd scripts
   Get-Help .\new-problem.ps1
   ```

#### Option 2: Development Container (Recommended)

1. **Open in VS Code** with Dev Containers extension
2. **Reopen in Container** when prompted
3. **All tools are pre-configured** in the container

---

## 🎯 Adding New Problems

### Using the Automated Script (Recommended)

The easiest way to add a new problem is using the provided PowerShell script:

```powershell
cd scripts
.\new-problem.ps1
```

**The script will:**
1. Prompt for the LeetCode problem number
2. Ask for programming language (see supported languages in `config/config.json`)
3. Fetch problem metadata from LeetCode API
4. Create a standardized project structure from a template
5. Update the problem registry

---

## 📐 General Code Standards

These standards apply to all programming languages in this repository:

### Universal Principles

1. **Readability First**: Code should be self-documenting and easy to understand
2. **Consistent Naming**: Use consistent naming conventions within each language
3. **Edge Case Handling**: Always handle boundary conditions and invalid inputs
4. **Performance Awareness**: Document time and space complexity
5. **Clean Code**: Follow language-specific best practices

### Multiple Solution Approaches

When implementing multiple approaches for the same problem, use descriptive method names that indicate the approach:

- `BruteForce()` - Naive O(n²) or higher complexity solution
- `Optimized()` - More efficient solution
- `TwoPointer()`, `HashMap()`, `BinarySearch()` - Algorithm-specific names

### Documentation Requirements

All solutions must include:
- **Algorithm description** in comments
- **Time complexity** analysis
- **Space complexity** analysis
- **Key insights** or trade-offs

---

## 🔧 Language-Specific Guidelines

### 🟣 C# Guidelines

#### Class and Method Structure

```csharp
namespace ProblemName;

public class Solution
{
    /// <summary>
    /// Brief description of what the method does.
    /// Time Complexity: O(...)
    /// Space Complexity: O(...)
    /// </summary>
    /// <param name="paramName">Parameter description</param>
    /// <returns>Return value description</returns>
    public ReturnType MethodName(ParameterType paramName)
    {
        // Implementation here
        return result;
    }
}
```

#### C# Naming Conventions

- **Classes**: PascalCase (`Solution`, `TreeNode`)
- **Methods**: PascalCase (`TwoSum`, `IsValidBST`)
- **Variables**: camelCase (`targetSum`, `leftNode`)
- **Constants**: PascalCase (`MaxValue`, `DefaultSize`)
- **Private fields**: camelCase with underscore (`_cache`, `_visited`)

#### C# Code Style Guidelines

1. **Use meaningful variable names**:
   ```csharp
   // ✅ Good
   int targetSum = 9;
   int[] indices = new int[2];
   
   // ❌ Avoid
   int t = 9;
   int[] arr = new int[2];
   ```

2. **Add helpful comments for complex logic**:
   ```csharp
   // Use two pointers to find the target sum
   int left = 0, right = nums.Length - 1;
   
   while (left < right)
   {
       int currentSum = nums[left] + nums[right];
       // ... logic
   }
   ```

3. **Handle edge cases explicitly**:
   ```csharp
   public int[] TwoSum(int[] nums, int target)
   {
       if (nums == null || nums.Length < 2)
           throw new ArgumentException("Array must contain at least 2 elements");
       
       // Main logic here
   }
   ```

#### C# Multiple Solution Approaches

```csharp
public class Solution
{
    /// <summary>
    /// Brute force approach - check all pairs
    /// Time: O(n²), Space: O(1)
    /// </summary>
    public int[] BruteForce(int[] nums, int target)
    {
        // Implementation
    }
    
    /// <summary>
    /// Hash map approach - single pass
    /// Time: O(n), Space: O(n)
    /// </summary>
    public int[] HashMap(int[] nums, int target)
    {
        // Implementation
    }
}
```

#### C# Testing with xUnit

```csharp
namespace ProblemName.Tests;

public class SolutionTests
{
    private readonly Solution _solution = new Solution();

    [Theory]
    [InlineData(new int[] {2, 7, 11, 15}, 9, new int[] {0, 1})]
    [InlineData(new int[] {3, 2, 4}, 6, new int[] {1, 2})]
    public void TwoSum_ValidInputs_ReturnsCorrectIndices(int[] nums, int target, int[] expected)
    {
        // Act
        var result = _solution.TwoSum(nums, target);

        // Assert
        Assert.Equal(expected, result);
    }
}
```

#### C# Build and Test Commands

```powershell
# Build project
dotnet build

# Run tests for specific problem
cd problems/csharp/[problem-folder]
dotnet test

# Run all C# tests
cd problems/csharp
dotnet test

# Run tests with coverage
dotnet test --collect:"XPlat Code Coverage"

# Format code
dotnet format
```

---

## 🧪 Testing Guidelines

### Universal Testing Principles

### Universal Testing Principles

Each problem should have comprehensive test coverage regardless of the programming language:

### Test Categories

1. **Normal Cases**: Typical valid inputs
2. **Edge Cases**: Boundary conditions, empty inputs
3. **Error Cases**: Invalid inputs that should throw exceptions

### Cross-Validation Tests

For problems with multiple solution approaches, create tests that verify all approaches produce the same results:

```
// Language-specific examples are shown in the Language-Specific Guidelines section
```

### Language-Specific Testing

See the [Language-Specific Guidelines](#-language-specific-guidelines) section for testing frameworks and patterns specific to each language.

---

## 📖 Documentation Standards

### Problem README Template

Each problem should have a README.md file, which is included when creating a new problem via the script.

### Code Documentation

- **Function/Method Documentation**: Use language-appropriate documentation standards
- **Inline Comments**: Explain complex algorithms and business logic
- **Time/Space Complexity**: Always document in method/function headers

---

## 🔄 Submission Process

### Before Submitting

1. **Verify Code Quality**:
   ```powershell
   # Language-specific build commands
   # See Language-Specific Guidelines for exact commands
   ```

2. **Update Documentation**:
   - Complete the problem README.md
   - Update approach descriptions
   - Add complexity analysis

3. **Test Edge Cases**:
   - Verify all test cases pass
   - Add additional edge cases if needed
   - Ensure error handling is appropriate

### Git Workflow

1. **Create a feature branch**:
   ```bash
   git checkout -b problem/[number]-[slug]
   ```

2. **Add your changes**:
   ```bash
   git add .
   git commit -m "feat: add solution for problem [number]: [title]
   
   - Implement [approach] with O([time]) time complexity
   - Add comprehensive unit tests
   - Include detailed documentation"
   ```

3. **Push to your fork**:
   ```bash
   git push origin problem/[number]-[slug]
   ```

4. **Create a Pull Request** with:
   - Clear title: "Add solution for problem X: Problem Title"
   - Description of the approach used
   - Time and space complexity analysis
   - Any special considerations or trade-offs

### Pull Request Guidelines

#### Title Format
```
Add solution for problem [number]: [Problem Title]
```

#### Description Template
```markdown
## Problem Summary
Brief description of the problem

## Solution Approach
- **Algorithm:** [Approach name]
- **Time Complexity:** O(...)
- **Space Complexity:** O(...)

## Key Insights
- Key insight 1
- Key insight 2
```

---

## 📁 Project Structure

### Directory Organization

```
leetcode/
├── problems/
│   ├── csharp/                        # C# solutions
│   │   └── [XXXX-problem-slug]/
│   │       ├── README.md              # Problem documentation
│   │       ├── Solution.cs            # Main solution
│   │       ├── [ProblemName].csproj   # Project file
│   │       └── Tests/
│   │           ├── SolutionTests.cs
│   │           └── CrossValidationTests.cs
│   ├── python/                        # Python solutions (future)
│   ├── java/                          # Java solutions (future)
│   └── javascript/                    # JavaScript solutions (future)
├── templates/
│   ├── csharp/                        # C# template files
│   ├── python/                        # Python template files (future)
│   └── [other-languages]/             # Additional language templates
├── scripts/
│   ├── new-problem.ps1               # Automated problem creation
│   └── remove-problem.ps1            # Problem removal
├── config/
│   ├── config.json                   # Project configuration
│   └── problems.json                 # Problem registry
└── docs/
    ├── CONTRIBUTING.md               # This file
    └── SOLVED.md                     # Progress tracking
```

### File Naming Conventions

**Universal Conventions:**
- **Problem folders**: `[XXXX-problem-slug]` (e.g., `0001-two-sum`)
- **Documentation**: `README.md` (problem-specific)

**Language-Specific Conventions:**
- **C#**: 
  - Project files: `[ProblemNamePascalCase].csproj` (e.g., `TwoSum.csproj`)
  - Test files: `SolutionTests.cs`, `CrossValidationTests.cs`
- **Future languages**: Will follow language-specific conventions

---

## 🔮 Adding New Languages

When contributing support for a new programming language:

1. **Update Configuration**:
   - Add language to `config/config.json` under `supportedLanguages`
   - Add language paths for `problemPath` and `templatePath`

2. **Create Templates**:
   - Create template directory: `templates/[language]/`
   - Include solution template file
   - Include test template files
   - Include README template with placeholders

3. **Update Scripts**:
   - Add language-specific operations to `new-problem.ps1`
   - Add language-specific cleanup to `remove-problem.ps1`

4. **Update Documentation**:
   - Add language-specific guidelines to this CONTRIBUTING.md
   - Update main README.md to reflect new language support

5. **Test Framework**:
   - Ensure the new language has proper testing setup
   - Include examples in the language guidelines

---

## 🤝 Getting Help

### Resources

- **Project Issues**: Check existing issues on GitHub
- **LeetCode Discussion**: Official problem discussions
- **Algorithm Patterns**: Study common problem-solving patterns

### Contact

- **GitHub Issues**: For bug reports and feature requests
- **Discussions**: For questions and general discussion
- **Code Review**: Submit PRs for collaborative review

---

## 🎉 Recognition

Contributors will be recognized in:
- Repository README.md
- Individual problem solution credits
- Special achievements for significant contributions

Thank you for contributing to this LeetCode solutions repository! Every solution helps the community learn and grow. 🚀
