CFS assessment:
Section 1) UI Automation Suite

It is a UI test Automation suite for testing the Amazon India website using Selenium WebDriver with BDD cucumber framework.

Tested website
- `https://www.amazon.in/`

BDD framework artifacts
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
1. Open the solution in Visual Studio.
2. The 'TargetFramework' is `net6.0`
3. Place the matching `chromedriver.exe` in `Drivers\` or add it to PATH.

To Run tests there are two methods:
1)Visual Studio: Build then run tests from 'Test Explorer'
2)Run below commands from Command prompt (from repo root):
  - `dotnet build`
  - `dotnet test`
Screenshots will be saved in the below path after the test execution: {Root directory}\bin\Release\net6.0\screenshots 


Section 2)API Automation Suite:

This project implements automated API tests for the Petstore API (https://petstore.swagger.io/) using a BDD approach with Reqnroll, RestSharp, and C# targeting .NET 6 framework.

The test suite covers Create,Read,Update and Delete operations with dynamic test data generation and comprehensive assertions.

Project Structure
- PetstoreApi.feature` — Gherkin scenarios
- Models/Pet.cs` — Schema
- Helpers/TestDataGenerator.cs` — Dynamic payload generator
- Helpers/ApiClient.cs` — RestSharp wrapper
- PetStepDefinitions.cs` — step implementations

Prerequisites
- .NET 6 SDK
- Visual Studio 2026 or dotnet CLI
- NuGet packages: `RestSharp`, `Newtonsoft.Json`, `NUnit`, `NUnit3TestAdapter`, `Reqnroll`

Setup & Configuration
Base URL:
The API client is pre-configured with the Petstore API base URL: "https://petstore.swagger.io/v2/"
Dynamic test data is generated using random values

Run tests
1)Visual Studio: Build solution → Test Explorer → Run tests
2)Run below commands from Command prompt (from repo root):
    dotnet test --logger "console;verbosity=detailed" OR dotnet test 

Output
- View output in Visual Studio: `View > Output` → select `Tests` pane.
- CLI logs appear in the terminal when running `dotnet test`.

Base endpoints
- Create / Update: `POST/PUT https://petstore.swagger.io/v2/pet`
- Get / Delete: `GET/DELETE https://petstore.swagger.io/v2/pet/{id}`

GIT Repository
Repository: https://github.com/KampanN/CFStest
Branch: main


