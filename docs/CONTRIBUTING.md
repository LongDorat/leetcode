# Contributing Guidelines

Welcome to the LeetCode Solutions repository! This guide will help you understand how to contribute effectively to this project.

## 🚀 Quick Start

1. **Fork** this repository
2. **Clone** your fork locally
3. **Create** a new branch for your work
4. **Add** your solution using the provided scripts
5. **Test** your implementation thoroughly
6. **Submit** a pull request to the `develop` branch

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

Optional compilers/runtimes based on the languages you plan to contribute in, see the supported languages below: 
| Language       | Tool/Runtime           | Version               | Supported |
| -------------- | ---------------------- | --------------------- | --------- |
| **C#**         | .NET SDK               | 9.0 and above         | ✅         |
| **C**          | CMake + GCC/CLang/MSVC | at least 4.0 with C17 | ✅         |
| **Python**     | Python                 | ...                   | 🔄         |
| **Java**       | JDK                    | ...                   | 🔄         |
| **JavaScript** | Node.js                | ...                   | 🔄         |
  
> **Note**: If any compiler/runtime is not installed, the problem creation scripts will display an error message when attempting to generate new projects for that specific language if applied.

### Development Environment Setup

#### Step 1: Repository Setup

1. **Clone the repository**:
   ```powershell
   git clone https://github.com/YourUsername/leetcode.git
   cd leetcode
   ```

2. **Checkout the develop branch**:
   ```powershell
   git checkout develop

   # If the local branch didn't track the remote branch
   git branch --set-upstream-to=origin/develop develop
   git pull

   # Verify tracking
   git branch -vv
   ```

3. **Create a problem branch**:
   ```powershell
   git checkout -b problem/[ID]-[slug]
   ```
   
#### Step 2: Development Container (Optional but Recommended)

1. **Open in VS Code** with Dev Containers extension
2. **Reopen in Container** when prompted
3. **All tools are pre-configured** in the container

---

## 🎯 Adding New Problems

### Using the Automated Script

The easiest way to add a new problem is using the provided PowerShell script:

```powershell
cd scripts
.\new-problem.ps1
```

**The script will:**
1. Prompt for the LeetCode problem number
2. Ask for programming language (see supported languages in above table)
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

<details>
<summary><strong>🟣 C# Guidelines</strong></summary>

#### Class and Method Structure

```csharp
namespace ProblemName;

public class Solution
{
    /// <summary>
    /// Brief description of what the method does.
    /// </summary>
    /// <param name="paramName">Parameter description</param>
    /// <returns>Return value description</returns>
    /// <remarks> Time Complexity: O(n), Space Complexity: O(1) </remarks>
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

2. **Add helpful comments for complex logic** (don't over-comment):
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

// BruteForceTests or HashMapTests for specific approach testing
public class SolutionTests
{
    private readonly Solution _solution = new Solution();

    [Theory]
    [InlineData(new int[] {2, 7, 11, 15}, 9, new int[] {0, 1})]
    [InlineData(new int[] {3, 2, 4}, 6, new int[] {1, 2})]
    public void ValidInputs_ReturnsCorrectIndices(int[] nums, int target, int[] expected)
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
# Go to the problem directory
cd problems/csharp/[problem-folder]

# Build the project
dotnet build

# Run tests
dotnet test
```
</details>

<details>
<summary><strong>🔵 C Guidelines</strong></summary>

#### Function Structure and Documentation

```c
#include <stdio.h>
#include <stdlib.h>
#include <string.h>

/**
 * @brief Brief description of what the function does.
 * @param paramName Parameter description
 * @returns Return value description
 * @note Time Complexity: O(n), Space Complexity: O(1)
 */
int* functionName(int* nums, int numsSize, int target, int* returnSize) {
    // Implementation here
    *returnSize = 2; // Set return array size
    return result;
}
```

#### C Naming Conventions

- **Functions**: snake_case (`two_sum`, `is_valid_bst`)
- **Variables**: snake_case (`target_sum`, `left_node`)
- **Constants**: UPPER_SNAKE_CASE (`MAX_VALUE`, `DEFAULT_SIZE`)
- **Structs**: PascalCase (`TreeNode`, `ListNode`)
- **Macros**: UPPER_SNAKE_CASE (`MAX`, `MIN`)

#### C Code Style Guidelines

1. **Use meaningful variable names**:
   ```c
   // ✅ Good
   int target_sum = 9;
   int* indices = (int*)malloc(2 * sizeof(int));
   
   // ❌ Avoid
   int t = 9;
   int* arr = (int*)malloc(2 * sizeof(int));
   ```

2. **Add helpful comments for complex logic**:
   ```c
   // Use two pointers to find the target sum
   int left = 0, right = nums_size - 1;
   
   while (left < right) {
       int current_sum = nums[left] + nums[right];
       // ... logic
   }
   ```

3. **Handle memory management explicitly**:
   ```c
   int* two_sum(int* nums, int nums_size, int target, int* return_size) {
       if (nums == NULL || nums_size < 2) {
           *return_size = 0;
           return NULL;
       }
       
       int* result = (int*)malloc(2 * sizeof(int));
       if (result == NULL) {
           *return_size = 0;
           return NULL;
       }
       
       // Main logic here
       
       *return_size = 2;
       return result;
   }
   ```

4. **Always check for NULL pointers and validate inputs**:
   ```c
   if (nums == NULL || nums_size <= 0) {
       if (return_size) *return_size = 0;
       return NULL;
   }
   ```

#### C Multiple Solution Approaches

```c
/**
 * @brief Brute force approach - check all pairs
 * @note Time: O(n²), Space: O(1)
 */
int* brute_force(int* nums, int nums_size, int target, int* return_size) {
    // Implementation
}

/**
 * @brief Hash map approach using simple array as hash table
 * @note Time: O(n), Space: O(n)
 */
int* hash_map(int* nums, int nums_size, int target, int* return_size) {
    // Implementation
}

/**
 * @brief Two pointer approach (for sorted arrays)
 * @note Time: O(n), Space: O(1)
 */
int* two_pointer(int* nums, int nums_size, int target, int* return_size) {
    // Implementation
}
```
</details>

#### C Memory Management Guidelines

1. **Always free allocated memory**:
   ```c
   int* result = (int*)malloc(size * sizeof(int));
   // Use result...
   free(result); // Remember to free in calling code
   ```

2. **Set pointers to NULL after freeing**:
   ```c
   free(ptr);
   ptr = NULL;
   ```

3. **Use consistent allocation patterns**:
   ```c
   // For return arrays, caller is responsible for freeing
   int* create_result_array(int size) {
       int* arr = (int*)malloc(size * sizeof(int));
       if (arr == NULL) {
           return NULL; // Allocation failed
       }
       return arr;
   }
   ```

#### C Testing with Unity Framework

```c
#include <unity.h>
#include <stdlib.h>

// Function declarations
extern int* two_sum(int* nums, int nums_size, int target, int* return_size);

void test_two_sum_valid_inputs(void) {
    int nums1[] = {2, 7, 11, 15};
    int return_size;
    int* result = two_sum(nums1, 4, 9, &return_size);
    
    TEST_ASSERT_NOT_NULL(result);
    TEST_ASSERT_EQUAL(2, return_size);
    TEST_ASSERT_EQUAL(0, result[0]);
    TEST_ASSERT_EQUAL(1, result[1]);
    
    free(result); // Clean up
}

void test_two_sum_edge_cases(void) {
    int return_size;
    
    // Test NULL input
    int* result = two_sum(NULL, 0, 9, &return_size);
    TEST_ASSERT_NULL(result);
    TEST_ASSERT_EQUAL(0, return_size);
    
    // Test insufficient elements
    int nums[] = {5};
    result = two_sum(nums, 1, 10, &return_size);
    TEST_ASSERT_NULL(result);
    TEST_ASSERT_EQUAL(0, return_size);
}
```
```c
// test_runner.c
#include <unity.h>

// Declare test functions
extern void test_two_sum_valid_inputs(void);
extern void test_two_sum_edge_cases(void);

void setUp(void) {
    // Set up code if needed
}

void tearDown(void) {
    // Clean up code if needed
}

int main(void) {
    UNITY_BEGIN();
    RUN_TEST(test_two_sum_valid_inputs);
    RUN_TEST(test_two_sum_edge_cases);
    return UNITY_END();
}
```

#### C Build and Test Commands

```powershell
# Go to the problem directory
cd problems/c/[problem-folder]

# Re-configure the build files after you modify them
cmake -S . -B build

# Build the project using CMake
cmake --build build

# Run tests
ctest --test-dir build --verbose
```
</details>

---

## 🧪 Testing Guidelines

### Universal Testing Principles

Each problem should have a comprehensive test coverage regardless of the programming language:

### Test Categories

1. **Normal Cases**: Typical valid inputs
2. **Edge Cases**: Boundary conditions, empty inputs
3. **Error Cases**: Invalid inputs that should throw exceptions, though this depends on the problem constraints

### Cross-Validation Tests

For problems with multiple solution approaches, create tests that verify all approaches produce the same results:

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
   # git checkout -b problem/csharp-0001-two-sum
   git checkout -b problem/[language]-[number]-[slug]
   ```

2. **Add your changes**:
   ```bash
   git add .
   git commit -m "feat: add solution for problem [number]: [title]"
   ```

3. **Push to your fork**:
   ```bash
   git push origin problem/[number]-[slug]
   ```

4. **Create a Pull Request** with:
   - Title: `Add solution for problem [number]: [title]`  
   - All problem related PRs should target the `develop` branch and follow the template provided in `.github/pull_request_template.md`. Other PRs types will not be accepted, but instead will need a new issue created first.

---

## 📁 Project Structure

### Directory Organization

```
leetcode/
├── problems/
│   └── [language]/                        # C# solutions
│       └── [XXXX-problem-slug]/
│           ├── README.md              # Problem documentation
│           ├── Solution.*            # Main solution file
│           └── Tests/
│               ├── SolutionTests.*
│               └── CrossValidationTests.*
├── templates/
│   ├── csharp/                        # C# template files
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
  - Test files: `SolutionTests.cs`, `BruteForceTests.cs`, `CrossValidationTests.cs`
- **C**:
  - Source files: `solution.c`
  - Test files: `solution_tests.c`, `brute_force_tests.c`, `test_runner.c`

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
