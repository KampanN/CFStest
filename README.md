CFS assessment

It is a UI test Automation suite for testing the Amazon India website using Selenium WebDriver with BDD cucumber framework.

Tested website
- `https://www.amazon.in/`

BDD framework and test stack
- BDD: Reqnroll (SpecFlow compatibility)
- Test runner: `NUnit`
- Browser automation: `Selenium.WebDriver`
- Language / TFM: C# with .NET 6 version 
- Project layout:
  - `Features\` — generated feature scenarios in Gherkin syntax
  - `StepDefinitions\` — step implementations
  - `Pages\` — page objects and implementations
  - `Drivers\` — Chrome driver
  - `screenshots\` — created at runtime for captured screenshots

Prerequisites
- .NET 6 SDK installed
- Visual Studio or `dotnet` CLI
- Google Chrome installed
- Matching `chromedriver.exe` for your Chrome version:
- Installed Reqnroll related Nuget packages.

Setup
1. Open the folder/solution in Visual Studio.
2. The 'TargetFramework' is `net6.0`
3. Place the matching `chromedriver.exe` in `Drivers\` or add it to PATH.

To Run tests there are two methods:
1)Visual Studio: Build then run tests from 'Test Explorer'
2)Run below commands from Command prompt (from repo root):
  - `dotnet build`
  - `dotnet test`
Screenshots will be saved in the below path after the test execution: C:\Dev\bin\Release\net6.0\screenshots



