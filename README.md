# Kaper

**Kaper** is a simple, lightweight interpreted scripting language built with C#. It uses the `.kap` file format and allows you to write and execute simple programs using easy-to-understand instructions.

Kaper was created as a project to explore how programming languages and interpreters work, while providing a simple environment for writing small scripts.

## Features

- Simple and easy-to-learn syntax.
- Custom `.kap` file format.
- Variables and basic data manipulation.
- Arithmetic operations.
- Conditional statements and jumps.
- User input and console output.
- Random number generation.
- Console customization (colors, title, etc.).
- Built-in delays and sound effects.

---

## Installation

1. Download the latest release of Kaper.
2. Create a folder anywhere on your computer.
3. Extract the contents of both the `kap` and `kapbuilder` folders into your new folder.
4. Make sure the folder structure looks like this:

```text
YourFolder/
├── kap.exe
└── kapbuilder.exe
```

5. Right-click your folder and select **Copy as path**.
6. Open the Windows Start menu and search for **Edit the system environment variables**.
7. Open it and click **Environment Variables**.
8. Under **System variables**, find and select `Path`.
9. Click **Edit**, then **New**.
10. Paste your folder's directory.
11. Click **OK** to save the changes and close the windows.

You should now be able to use `kap` and `kapbuilder` from PowerShell or Command Prompt.

---

## Getting Started

### 1. Create your first script

Create a new text file with the `.txt` extension.

For example, `hello.txt`.

Write the following code:

```text
print T Hello-from-Kaper!
```

### 2. Build your script

Open PowerShell in the directory containing your text file and run:

```powershell
kapbuilder hello.txt
```

This will generate a `.kap` file containing your script.

### 3. Run your program

Execute the generated file using:

```powershell
kap hello.kap
```

That's it! Your first Kaper program is running.

---

## Language Syntax

Kaper uses a simple instruction-based syntax.

**Each instruction must be written on its own line.**

Instructions generally follow this format:

```text
instruction parameter1 parameter2
```

### Available Instructions

| Instruction | Parameters | Description |
|---|---|---|
| `print` | `T/F`, text | Prints text to the console. `T` adds a new line, while `F` does not. |
| `var` | Name, value | Creates a variable. Use `-` instead of spaces in text values. |
| `set` | Variable, value | Changes an existing variable's value. |
| `input` | Variable | Reads user input and stores it in a variable. |
| `goto` | Line number | Jumps to a specific line in the script. |
| `if` | Value1, operator, Value2, line | Checks a condition and jumps to a line if it is true. |
| `delay` | Milliseconds | Pauses execution for a specified amount of time. |
| `random` | Min, max, variable | Generates a random number and stores it in a variable. |
| `add` | Number1, Number2, variable | Adds two numbers. |
| `sub` | Number1, Number2, variable | Subtracts two numbers. |
| `multi` | Number1, Number2, variable | Multiplies two numbers. |
| `div` | Number1, Number2, variable | Divides two numbers. |
| `concat` | Word1, Word2, variable | Joins two values together. |
| `length` | Word, variable | Gets the length of a string. |
| `substring` | Word, start index, length, variable | Extracts part of a string. |
| `title` | Text | Changes the console window title. |
| `color` | Color | Changes the console text color. |
| `clear` | None | Clears the console. |
| `beep` | Frequency, duration | Plays a console beep. |
| `pause` | None | Waits for a key press. |
| `close` | None | Stops program execution. |
| `log` | None | Prints interpreter log information. |

### Supported Colors

The `color` instruction supports:

`green`, `blue`, `red`, `white`, `yellow`, `cyan`, `magenta`, `darkgreen`, `darkblue`, `darkred`, `gray`.

### Conditional Operators

The `if` instruction supports the following operators:

| Operator | Description |
|---|---|
| `=` | Equal to |
| `!` | Not equal to |
| `<` | Less than |
| `>` | Greater than |

---

## Example Programs

### Hello World

```text
title Hello-World
color green
print T Welcome-to-Kaper!
pause
```

### Variables and Arithmetic

```text
var number1 10
var number2 5
var result 0

add number1 number2 result

print T Calculation-completed!
```

### User Input

```text
var username Guest

print F Enter-your-name:
input username

print T Welcome!
```

---

## Project Structure

```text
Kaper/
├── kap/
│   └── kap.exe
│
├── kapbuilder/
│   └── kapbuilder.exe
│
└── README.md
```

- **kap.exe** – The interpreter responsible for executing `.kap` scripts.
- **kapbuilder.exe** – The builder responsible for converting text scripts into `.kap` files.

---

## About the Project

Kaper is a personal programming project built using C#.

The main goal is to experiment with the fundamentals of programming language development, including instruction parsing, variables, control flow, and interpretation.

It is a simple project, but a fun way to explore how a programming language works behind the scenes.

**Built with C#**
