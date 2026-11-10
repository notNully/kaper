# Kaper

A simple interpreted scripting language built with C#.

Kaper uses its own `.kap` file format and provides a collection of basic instructions for writing and running simple scripts.

The project was built for no purpose and just a fun project i built


## Features

- Simple and easy-to-learn syntax.
- Custom `.kap` file format.
- Variables and basic data manipulation.
- Arithmetic operations.
- Conditional statements and jumps.
- User input and console output.
- Random number generation.
- Console customization (colors, title, etc.).
- Built-in delays.

---

## Installation

1. Download the latest release of Kaper.
2. Create a folder anywhere on your computer.
3. Extract the contents of both the `kap` and `kapbuilder` folders into your new folder.
4. Make sure the files are located like this:

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
| `if` | Value1, operator, Value2, line | Checks a condition and jumps to a specific line if it is true. |
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
| `pause` | None | Waits for a key press. |
| `close` | None | Stops program execution. |
| `log` | None | Prints interpreter log information. |

---

## Conditional Statements (`if`)

The `if` instruction allows your program to make decisions.

It compares two values using an operator. If the condition is true, Kaper jumps to the specified line number. If the condition is false, the program continues executing the next line normally.

### Syntax

```text
if [value1] [operator] [value2] [line number]
```

| Parameter | Description |
|---|---|
| Value1 | The first value you want to compare. |
| Operator | The comparison operator. |
| Value2 | The second value you want to compare. |
| Line number | The line Kaper should jump to if the condition is true. |

### Supported Operators

| Operator | Meaning | Example |
|---|---|---|
| `=` | Equal to | `if 10 = 10 5` |
| `!` | Not equal to | `if 10 ! 5 5` |
| `<` | Less than | `if 5 < 10 5` |
| `>` | Greater than | `if 10 > 5 5` |

### Example

```text
var age 18

if age > 17 5
print T You-are-under-18
goto 6
print T You-are-18-or-older
```

**How it works:**

1. Line 1 creates a variable called `age` with the value `18`.
2. Line 3 checks whether `age` is greater than `17`.
3. Since the condition is true, Kaper jumps to line 5.
4. Line 5 prints `You-are-18-or-older`.

If the age were `16`, the condition would be false, so Kaper would continue to line 4 instead.

**Important:** Line numbers start at `1`, and the jump only happens when the condition is true.

---

## Other Supported Features

### Colors

The `color` instruction supports:

`green`, `blue`, `red`, `white`, `yellow`, `cyan`, `magenta`, `darkgreen`, `darkblue`, `darkred`, `gray`.

Example:

```text
color green
print T This-text-is-green
```

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

## About the Project

Kaper is a personal programming project built using C#.

The main goal is to experiment with the fundamentals of programming language development, including instruction parsing, variables, control flow, and interpretation.

It is a simple project, but a fun way to explore how a programming language works behind the scenes.

**Built with C#**
