# App_Finanças .NET 10.0 Upgrade Tasks

## Overview

This document tracks the execution of the upgrade of `App_Finanças` from `net472` to `net10.0`. Work includes converting the project to SDK-style, migrating package references, restoring and building the solution, and validating tests if present.

**Progress**: 3/4 tasks complete (75%) ![0%](https://progress-bar.xyz/75)

---

## Tasks

### [✓] TASK-001: Verify prerequisites *(Completed: 2026-02-12 06:54)*
**References**: Plan §2, Plan §4, Plan §10

- [✓] (1) Verify required `.NET 10.0` SDK is installed on the execution environment per Plan §4.
- [✓] (2) Runtime/SDK version meets minimum requirements (**Verify**).
- [✓] (3) If a `global.json` file exists, validate its SDK version compatibility with .NET 10.0 per Plan §4 (**Verify**).
- [✓] (4) Verify required tooling availability (`dotnet` CLI, NuGet tooling) and that a package restore can run (dry-run) per Plan §4 (**Verify**).

### [✓] TASK-002: Atomic project conversion, framework and package upgrade with compilation fixes *(Completed: 2026-02-12 03:57)*
**References**: Plan §2, Plan §4, Plan §5, Plan §6

- [✓] (1) Convert `App_Finanças\App_Finanças.csproj` to SDK-style and apply required project file structure changes per Plan §4.
- [✓] (2) Update `TargetFramework` to `net10.0` in `App_Finanças.csproj` per Plan §4.
- [✓] (3) Migrate `packages.config` entries into `<PackageReference>` items or use `Directory.Packages.props` as specified in Plan §4 and Plan §5.
- [✓] (4) Update package versions according to the Package Update Reference (Plan §5) and remove or replace packages provided by the runtime when appropriate per Plan §5 and Plan §6.
- [✓] (5) Run `dotnet restore` to restore all dependencies per Plan §4/§5.
- [✓] (6) Build the solution and fix all compilation errors arising from framework and package changes, addressing breaking changes noted in Plan §6 (combined bounded operation).
- [✓] (7) Solution builds with 0 errors (**Verify**).

### [✓] TASK-003: Run test suite and validate upgrade *(Completed: 2026-02-12 03:58)*
**References**: Plan §7, Plan §6

- [✓] (1) Run all test projects (if any exist) per Plan §7.
- [✓] (2) Fix any test failures (reference remediation steps in Plan §6 for common breaking changes).
- [✓] (3) Re-run tests after fixes.
- [✓] (4) All tests pass with 0 failures (**Verify**)

### [▶] TASK-004: Final commit
**References**: Plan §10

- [▶] (1) Commit all remaining changes with message: "TASK-004: feat(upgrade): convert to SDK-style and migrate to net10.0; update packages"





