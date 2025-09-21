# LeetCode Problem Solutions

A repository to manage solved LeetCode problems across multiple programming languages.

## 📁 Project Structure

```
leetcode/
├── 📂 problems/           # Language-specific problem implementations
│   └── 📂 csharp/        # C# solutions with xUnit tests
├── 📂 templates/         # Project templates for new problems
│   ├── 📂 csharp/        # C# template with Solution.cs and test files
│   └── 📂 [language]/    # Templates for other languages
├── 📂 scripts/           # PowerShell automation scripts
│   ├── new-problem.ps1   # Create new problem from LeetCode
│   └── remove-problem.ps1 # Remove existing problem
├── 📂 config/            # Configuration and problem registry
│   ├── config.json       # Project configuration
│   └── problems.json     # Registry of created problems
├── 📂 cache/             # Cached LeetCode problem data
├── 📂 docs/              # Documentation
└── 📂 .devcontainer/     # Development environment setup
```

## 🛠️ Installation & Setup

### Prerequisites

Requires tools to run the scripts and manage the projects:
- **PowerShell** (Windows PowerShell or PowerShell Core)
- **Git**

Language-specific compilers and runtimes (install as needed):  
| Language       | Tool/Runtime | Version       | Supported |
| -------------- | ------------ | ------------- | --------- |
| **C#**         | .NET SDK     | 9.0 and above | ✅         |
| **C/C++**      | CMake + GCC  | ...           | 🔄         |
| **Python**     | Python       | ...           | 🔄         |
| **Java**       | JDK          | ...           | 🔄         |
| **JavaScript** | Node.js      | ...           | 🔄         |

### Option 1: Local Development

1. **Clone the repository**:
   ```powershell
   git clone https://github.com/LongDorat/leetcode.git
   cd leetcode
   ```

2. **Verify installation** (optional, based on languages you plan to use):
    ```powershell
    # Verify .NET SDK installation (for C#)
    dotnet --version
    
    # Verify Python installation (for Python)
    python --version
    
    # Verify Java installation (for Java)
    java --version
    
    # Verify Node.js installation (for JavaScript)
    node --version
    ```

> **Note**: If any compiler/runtime is not installed, the problem creation scripts will display an error message when attempting to generate new projects for that specific language if applied.

### Option 2: Development Container (Recommended)

1. **Prerequisites**:
   - Docker Desktop
   - Visual Studio Code with Dev Containers extension

2. **Open in container**:
   - Open the repository in VS Code
   - Command Palette → "Dev Containers: Reopen in Container"
   - The container includes all required tools and VS Code extensions

## 🎯 Usage

### Creating a New Problem

Use the automated script to create a new LeetCode problem:

```powershell
# Navigate to the scripts directory
cd scripts

# Run the new problem script
.\new-problem.ps1
```

The script will:
1. Prompt for the LeetCode problem number
2. Ask for the programming language (see supported languages above)
3. Fetch problem data from LeetCode API
4. Create a properly structured project with a language-specific template

### Removing a Problem

To remove an existing problem:

```powershell
cd scripts
.\remove-problem.ps1
```

The script will:
- Remove the problem folder and all files
- Remove any language-specific project references (e.g., from solution files)
- Update the problem registry

## 📋 Problem Structure

Each problem follows a standardized structure regardless of the programming language:

```
[problem-number]-[problem-slug]/
├── README.md                    # Problem description and solution approach
├── Solution.[ext]               # Main solution implementation
├── [Project/Config File]        # Language-specific project file
└── Tests/                       # Test directory
    ├── SolutionTests.[ext]     # Unit tests for the solution
    └── CrossValidationTests.[ext] # Cross-validation tests (if multiple approaches)
```

## 🤝 Contributing

See [CONTRIBUTING.md](docs/CONTRIBUTING.md) for detailed guidelines on:
- Adding new problems
- Code standards and conventions
- Testing requirements
- Documentation standards

## 📄 License

This project is licensed under the MIT License - see the [LICENSE](LICENSE) file for details.

## 🙋‍♂️ Author

**LongDorat** - [GitHub Profile](https://github.com/LongDorat)

---

**Happy Coding!** 🚀 Let's solve some problems together!
