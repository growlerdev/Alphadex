# Alphadex

[![GitHub Release](https://img.shields.io/github/v/release/growlerdev/Alphadex?display_name=release&logo=github&label=release)](https://github.com/growlerdev/Alphadex/releases)
[![GitHub Release](https://img.shields.io/github/v/release/growlerdev/Alphadex?include_prereleases&display_name=release&logo=github&label=latest%20build)](https://github.com/growlerdev/Alphadex/releases)
[![NuGet Downloads](https://img.shields.io/nuget/dt/Alphadex?logo=nuget&color=9932CC)](https://www.nuget.org/packages/Alphadex)
[![GitHub License](https://img.shields.io/github/license/growlerdev/Alphadex?color=salmon)](LICENSE.md)
[![GitHub Actions Workflow Status](https://img.shields.io/github/actions/workflow/status/growlerdev/Alphadex/main.yml?logo=githubactions&logoColor=white&label=Build%20and%20Deploy)](https://github.com/growlerdev/Alphadex/actions/workflows/main.yml)

A .NET library for converting zero-based indices to alphabetic sequences, similar to Excel column naming (A, B, C, ... Z, AA, AB, etc.). Perfect for generating column names, sequence identifiers, or any scenario where you need human-readable alphabetic progression.

## Features

- 🔤 Convert any zero-based index to an alphabetic sequence
- 🔄 Supports infinite sequences with recursive prefixing
- ⚙️ Customizable character sets (not limited to A-Z)
- 📦 Lightweight .NET Standard 2.0 library
- 🚀 High performance with simple API

## Installation

Install the package via NuGet Package Manager:

```bash
dotnet add package Alphadex
```

Or via Package Manager Console in Visual Studio:

```powershell
Install-Package Alphadex
```

## Quick Start

```csharp
using Alphadex;

var service = new AlphaNumericService();
Console.WriteLine(service.GetString(0));  // Output: "A"
Console.WriteLine(service.GetString(25)); // Output: "Z"
Console.WriteLine(service.GetString(26)); // Output: "AA"
```

## Usage

### Basic Usage

The default character set is the English alphabet (A-Z).

```csharp
var alphaSvc = new AlphaNumericService();

// Single characters (0-25)
alphaSvc.GetString(0);  // returns "A"
alphaSvc.GetString(1);  // returns "B"
alphaSvc.GetString(2);  // returns "C"
alphaSvc.GetString(25); // returns "Z"

// Double characters (26+)
alphaSvc.GetString(26);  // returns "AA"
alphaSvc.GetString(27);  // returns "AB"
alphaSvc.GetString(777); // returns "ACX"
```

### Practical Examples

**Excel-style column naming:**
```csharp
var columnService = new AlphaNumericService();

for (int i = 0; i < 30; i++)
{
    Console.WriteLine($"Column {i}: {columnService.GetString(i)}");
}
// Output: Column 0: A, Column 1: B, ... Column 26: AA, Column 27: AB
```

**Generating sequence identifiers:**
```csharp
var idGenerator = new AlphaNumericService();
var items = new List<string> { "Task 1", "Task 2", "Task 3" };

for (int i = 0; i < items.Count; i++)
{
    Console.WriteLine($"{idGenerator.GetString(i)}: {items[i]}");
}
// Output: A: Task 1, B: Task 2, C: Task 3
```

### Custom Character Sets

You can override the default character set by passing a custom string to the constructor.

```csharp
// Using custom characters
var alphaSvc = new AlphaNumericService("SOMETEXT");

alphaSvc.GetString(0); // returns "S"
alphaSvc.GetString(1); // returns "O"
alphaSvc.GetString(2); // returns "M"
alphaSvc.GetString(7); // returns "T"
alphaSvc.GetString(8); // returns "SS" (wraps around with prefix)
```

## How It Works

The algorithm works by:
1. For indices within the character set length, it returns the character directly
2. For indices beyond the set length, it calculates a prefix recursively and appends the remainder

This creates sequences like: A, B, C, ..., Z, AA, AB, AC, ..., AZ, BA, BB, BC, etc.

## Requirements

- .NET Standard 2.0 or higher
- Compatible with .NET Framework 4.6.1+, .NET Core 2.0+, .NET 5+

## Contributing

Contributions are welcome! Please feel free to submit a Pull Request. For major changes, please open an issue first to discuss what you would like to change.

## License

This project is licensed under the MIT License - see the [LICENSE.md](LICENSE.md) file for details.
