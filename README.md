# FoodDelivery 🍽️

**FoodDelivery** is a sample micro/monorepo showing an ASP.NET Core API and a Blazor Server frontend for a simple food delivery domain.

---

## 🚀 Quick Start

### Prerequisites
- **.NET 8.0 SDK** (install from https://dotnet.microsoft.com)
- A code editor (VS Code / Visual Studio / Rider)

### Build & Run
From the repository root:

```bash
# restore packages and build
dotnet restore
dotnet build

# Run API
dotnet run --project FoodDelivery.API

# Run Blazor Server UI
dotnet run --project FoodDelivery.BlazorServer
```

Open the Blazor app at https://localhost:5001 (or the URL shown in the console). The API runs at the URL shown by the API project.

---

## 📁 Project Structure
- `FoodDelivery.sln` - solution file
- `FoodDelivery.API/` - ASP.NET Core Web API
- `FoodDelivery.BlazorServer/` - Blazor Server UI
- `FoodDelivery.Application/` - application services and features
- `FoodDelivery.Domain/` - domain entities, value objects, enums
- `FoodDelivery.Infrastructure/` - infrastructure implementations
- `FoodDelivery.Shared/` - shared utilities or types

---

## ⚙️ Configuration
- App settings: `appsettings.json` and `appsettings.Development.json` per project
- Use `ASPNETCORE_ENVIRONMENT=Development` to pick development settings when needed

---

## 🧪 Tests
No test projects are included yet. Consider adding xUnit/NUnit projects under a `tests/` folder.

---

## 🤝 Contributing
1. Fork the repo
2. Create a branch for your change
3. Open a pull request with a clear description

---

## 📝 License
This repository currently has no license file. Add a `LICENSE` file (e.g., MIT) if you want to allow reuse.

---

If you'd like, I can also add a minimal `LICENSE` and a basic `CONTRIBUTING.md`. ✅
