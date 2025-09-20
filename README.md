# LeetCode Problem Solutions

A comprehensive repository for managing and organizing LeetCode problem solutions with automated workflows and standardized project structure.

## 🚀 Features

- **Automated Problem Setup**: PowerShell scripts to quickly scaffold new LeetCode problems
- **Multi-Language Support**: Extensible architecture supporting multiple programming languages
- **Standardized Templates**: Consistent project structure with unit tests and documentation templates
- **Problem Registry**: Centralized tracking of solved problems with metadata
- **Development Container**: Ready-to-use dev environment with all required tools
- **Solution Management**: Integrated with Visual Studio solution for easy development

## 📁 Project Structure

```
leetcode/
├── 📂 problems/           # Language-specific problem implementations
│   ├── 📂 csharp/        # C# solutions with xUnit tests
│   ├── 📂 python/        # Python solutions (planned)
│   ├── 📂 java/          # Java solutions (planned)
│   └── 📂 javascript/    # JavaScript solutions (planned)
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

Requirements for local development:
- **PowerShell** (Windows PowerShell or PowerShell Core)
- **Git**

Language-specific compilers and runtimes (install as needed):
- **.NET SDK** (for C# solutions)
- **Python** (for Python solutions)
- **JDK** (for Java solutions)
- **Node.js** (for JavaScript solutions)

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

> **Note**: If any compiler/runtime is not installed, the problem creation scripts will display an error message when attempting to generate new projects for that specific language.

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
# Navigate to the repo directory
cd leetcode

# Run the new problem script
.\scripts\new-problem.ps1
```

The script will:
1. Prompt for the LeetCode problem number
2. Ask for the programming language (see supported languages in `config/config.json`)
3. Fetch problem data from LeetCode API
4. Create a properly structured project with language-specific templates

### Removing a Problem

To remove an existing problem:

```powershell
cd leetcode
.\scripts\remove-problem.ps1
```

The script will:
- Remove the problem folder and all files
- Remove any language-specific project references (e.g., from solution files)
- Update the problem registry

### Working with Solutions

Each supported language has its own workflow. Examples:

#### C# Solutions
```powershell
# Navigate to C# problems directory
cd problems/csharp

# Build all projects
dotnet build

# Run tests for a specific problem
cd [problem-folder]
dotnet test

# Run all tests
cd ../
dotnet test
```

#### Other Languages
See the language-specific sections in [CONTRIBUTING.md](docs/CONTRIBUTING.md) for detailed workflows for each supported language.

## 🔧 Supported Languages

| Language | Status | Template | Testing Framework | Build System |
|----------|---------|----------|-------------------|--------------|
| **C#** | ✅ Active | ✅ Available | xUnit | .NET CLI |
| **Python** | 🔄 Planned | 🔄 In Development | pytest | pip |
| **Java** | 🔄 Planned | 🔄 In Development | JUnit | Maven/Gradle |
| **JavaScript** | 🔄 Planned | 🔄 In Development | Jest | npm |

> **Contributing New Languages**: See [CONTRIBUTING.md](docs/CONTRIBUTING.md) for guidelines on adding support for additional programming languages.

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

### Language-Specific Examples

**C# Structure:**
```
0001-two-sum/
├── README.md
├── Solution.cs
├── TwoSum.csproj
└── Tests/
    ├── SolutionTests.cs
    └── CrossValidationTests.cs
```

**Python Structure (Planned):**
```
0001-two-sum/
├── README.md
├── solution.py
├── requirements.txt
└── tests/
    ├── test_solution.py
    └── test_cross_validation.py
```

## 🔧 Configuration

### config.json

```json
{
    "problemIdPadding": 4,                    # Zero-pad problem IDs to 4 digits
    "supportedLanguages": [                   # List of supported languages
        "csharp",
        "python",
        "java", 
        "javascript"
    ],         
    "problemPath": {                          # Paths to language-specific problems
        "csharp": "./problems/csharp",
        "python": "./problems/python",
        "java": "./problems/java",
        "javascript": "./problems/javascript"
    },
    "templatePath": {                         # Paths to language-specific templates
        "csharp": "./templates/csharp",
        "python": "./templates/python",
        "java": "./templates/java",
        "javascript": "./templates/javascript"
    }
}
```

### Problem Registry (problems.json)

Automatically maintained registry of all created problems with metadata:

```json
{
    "csharp": [
        {
            "problemNumber": "1",
            "titleSlug": "two-sum",
            "questionTitle": "Two Sum",
            "projectName": "TwoSum",
            "folderPath": "./problems/csharp/0001-two-sum",
            "createdDate": "2025-09-20T10:30:00Z"
        }
    ],
    "python": [],
    "java": [],
    "javascript": []
}
```

## 🧪 Testing

The project emphasizes comprehensive testing across all supported languages:

- **Unit Tests**: Test individual methods and edge cases
- **Cross-Validation Tests**: Compare multiple solution approaches
- **Integration Tests**: Verify end-to-end functionality

### Testing Frameworks by Language

| Language | Framework | Commands |
|----------|-----------|----------|
| **C#** | xUnit | `dotnet test` |
| **Python** | pytest | `pytest` (planned) |
| **Java** | JUnit | `mvn test` (planned) |
| **JavaScript** | Jest | `npm test` (planned) |

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
