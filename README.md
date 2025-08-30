# LeetCode Solutions Collection

## 📖 Description

This repository contains my collection of LeetCode problem solutions implemented in multiple programming languages. Each solution includes comprehensive test cases, detailed explanations, and optimized approaches to help others learn and understand different problem-solving techniques.

## 🚀 Quick Start

### Prerequisites

Before getting started, ensure you have the following installed:

#### 🔧 Required Tools
- **Git** - Version control system for cloning the repository
- **PowerShell** - Cross-platform automation and configuration tool

#### 💻 Platform-Specific PowerShell Installation

<details>
<summary><strong>🪟 Windows Users</strong></summary>

PowerShell comes pre-installed on Windows 10/11. For older versions or to get the latest PowerShell 7+:
- Download from [PowerShell GitHub Releases](https://github.com/PowerShell/PowerShell/releases)
- Or install via Windows Package Manager: `winget install Microsoft.PowerShell`

</details>

<details>
<summary><strong>🐧 Linux Users</strong></summary>

Install PowerShell on Linux using your distribution's package manager:

**Ubuntu/Debian:**
```bash
sudo apt update && sudo apt install -y powershell
```

**For other distributions or manual installation, refer to:**
📖 [Official PowerShell on Linux Documentation](https://docs.microsoft.com/en-us/powershell/scripting/install/installing-powershell-core-on-linux?view=powershell-7.5)

</details>

<details>
<summary><strong>🍎 macOS Users</strong></summary>

Install PowerShell on macOS:

**Using Homebrew (Recommended):**
```bash
brew install powershell
```

**For other installation methods, refer to:**
📖 [Official PowerShell on macOS Documentation](https://docs.microsoft.com/en-us/powershell/scripting/install/installing-powershell-core-on-macos?view=powershell-7.5)

</details>

#### 🚀 Programming Language Runtimes

Choose and install the runtime for your preferred programming language(s):

| Language                | Installation Guide |
| ----------------------- | ------------------ |
| No language support yet |                    |

### Installation

```bash
# Clone the repository
git clone https://github.com/longdorat/leetcode.git

# Navigate to the project directory
cd leetcode

# Run the interactive setup script
./scripts/setup.ps1
```

The setup script will:
- Check for required dependencies
- Configure your development environment
- Guide you through the initial setup process

## 🛠️ Usage

### Creating a New Problem Solution

To create a new LeetCode problem solution:

```bash
# Run the problem creation script
./scripts/new-problem.ps1

# Follow the interactive prompts to:
# - Enter the problem number
# - Select programming language
# - Choose difficulty level
# - Set up the initial template
```

### Working on an Existing Problem

To open and work on an existing problem:

```bash
# Navigate to a specific problem directory
cd problems/<language>/<problem-number>-<problem-name>

# Example: Opening the Two Sum problem in Python
cd problems/python/0001-two-sum
```

### Running Tests

Each problem comes with a comprehensive test suite:

```bash
# Navigate to the problem directory
cd problems/<language>/<problem-number>-<problem-name>

# Check the problem's README for specific test commands
cat README.md
```

## 📁 Project Structure

```
leetcode/
├── 📂 problems/           # Individual problem solutions
│   ├── python/
│   │   ├── 0001-two-sum/
│   │   └── 0002-add-two-numbers/
│   └── ...
├── 📂 templates/          # Solution templates for different languages
│   ├── python/
│   ├── java/
│   ├── cpp/
│   └── ...
├── 📂 scripts/            # Automation and utility scripts
│   ├── new-problem.ps1
│   └── setup.ps1
├── 📂 docs/              # Documentation and guides
│   ├── contributing.md
│   └── ...
├── 📂 .github/           # GitHub workflows and templates
├── 📄 README.md
└── 📄 LICENSE
```

## 📊 Solved Problems

<div align="center">

![Total Problems](https://img.shields.io/badge/Total%20Problems-0-blue?style=for-the-badge)
![Easy](https://img.shields.io/badge/Easy-0-green?style=for-the-badge)
![Medium](https://img.shields.io/badge/Medium-0-orange?style=for-the-badge)
![Hard](https://img.shields.io/badge/Hard-0-red?style=for-the-badge)

</div>

📖 **[Complete Problem List & Categories →](docs/SOLVED.md)**

## 🤝 Contributing

Contributions are welcome! Please read our [Contributing Guidelines](docs/contributing.md) for details on:

- Code style and standards
- How to submit solutions
- Testing requirements
- Documentation standards

### How to Contribute

1. **Fork** the repository
2. **Create** a feature branch (`git checkout -b feature/amazing-solution`)
3. **Commit** your changes (`git commit -m 'Add amazing solution for problem X'`)
4. **Push** to the branch (`git push origin feature/amazing-solution`)
5. **Open** a Pull Request

## 📚 Resources

- [LeetCode Official Website](https://leetcode.com/)
- [Algorithm Visualization](https://visualgo.net/)
- [Big O Cheat Sheet](https://www.bigocheatsheet.com/)
- [Data Structures and Algorithms](https://github.com/trekhleb/javascript-algorithms)

## 📄 License

This project is licensed under the MIT License - see the [LICENSE](LICENSE) file for details.

## ⭐ Support

If you find this repository helpful, please consider giving it a star! ⭐

---

**Happy Coding!** 🎉

