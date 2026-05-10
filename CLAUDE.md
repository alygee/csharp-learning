# CLAUDE.md

This file provides guidance to Claude Code (claude.ai/code) when working with code in this repository.

## Repository purpose

A 30-day C#/.NET learning repo. Each `dayN/` folder is one day's exercise, with one or more independent console projects inside. There is **no solution file, no `Directory.Build.props`, no `global.json`** — every `*.csproj` stands on its own. Days build on each other in roadmap order (see `README.md`), but they don't share code; reuse happens by re-implementing patterns from earlier days, not by referencing them.

The `README.md` is the source of truth for the roadmap and progress table. **When you add a new day's project, also update `README.md`**: the intro line ("реализованы задания…"), the progress table, the structure tree, the run-commands list, and the "Реализованные мини-проекты" section. The user expects all five to stay in sync.

The roadmap section ("План обучения") lists the *original* schedule; actual day numbers may diverge from it (e.g. LINQ landed on day 9, not the planned day 11). Don't rewrite the roadmap to match reality — it's intentional history.

## Commands

The repo path contains a space and Cyrillic characters, so always quote it when shelling out.

```bash
# Run a project
dotnet run --project dayN/<ProjectName>/<ProjectName>.csproj

# Run tests (only day1 has them so far)
dotnet test day1/HelloWorld.Tests/HelloWorld.Tests.csproj

# Run a single xUnit test by fully-qualified name
dotnet test day1/HelloWorld.Tests/HelloWorld.Tests.csproj --filter "FullyQualifiedName~UnitTest1.MethodName"
```

There is no top-level build/lint/test runner — invoke `dotnet` against a specific `.csproj`.

## Target framework caveat

Console projects target `net10.0`. The lone test project (`day1/HelloWorld.Tests`) still targets `net8.0` with older xUnit (2.4.2) and `Microsoft.NET.Test.Sdk` (17.6.0). This mismatch is pre-existing — don't "fix" it as a side quest. If the host SDK can't run net8, raise it with the user before changing TFMs.

## Code conventions

These are followed consistently across all days. Match them in new code:

- **Project layout:** `dayN/<ProjectName>/` with `Program.cs` + supporting files. The csproj's `RootNamespace` is implicit and equals the project name; every file declares `namespace <ProjectName>;` (file-scoped).
- **csproj template** (console app):
  ```xml
  <PropertyGroup>
    <OutputType>Exe</OutputType>
    <TargetFramework>net10.0</TargetFramework>
    <ImplicitUsings>enable</ImplicitUsings>
    <Nullable>enable</Nullable>
  </PropertyGroup>
  ```
- **No top-level statements.** Every project has an explicit `internal static class Program` with `private static void Main()` that delegates to an `App`/`Run`-style class.
- **`internal sealed class`** is the default for domain types. Constructors and members are `internal` unless they need to be `public` (e.g. `ToString` overrides). `private readonly` fields use a leading underscore (`_catalog`); instance member access inside methods uses an explicit `this.` prefix.
- **XML doc comments are written in Russian** (`/// <summary>`), as are user-facing `Console.WriteLine` strings, menu labels, and inline comments. Keep that — it's the user's preference, not an accident.
- **Console-app shape:** there's a recurring pattern of `ConsoleInput` static helpers (`ReadRequiredString`, `ReadEmail`, …), a `Menu` class that exposes a `Choice` property and a `BookMenuChoice`-style enum, and an `App` class with a `Run()` method. New console projects in this repo should follow that shape rather than inventing a new one.

## When the user says "набросай dayN/X" (scaffold)

The expected deliverable is a runnable console project under `dayN/X/` matching the conventions above, **plus** the five `README.md` updates listed under "Repository purpose". Verify the scaffold builds (`dotnet run --project …`) before reporting done. If the project is a "playground" (e.g. `day9/LinqPlayground`), one worked example + remaining stubs as `// TODO` comments with hints is the established pattern — the user fills the rest in themselves.
