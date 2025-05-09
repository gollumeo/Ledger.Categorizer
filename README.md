# Ledger.Categorizer

**Transaction categorization engine for FinTech applications.**
Assigns a business intent (category) to raw bank transactions using domain-driven rules.

---

## 🚀 Use Case

Given a transaction with a description, amount, and date, this module returns a financial category such as:

* `FoodDelivery`
* `Transport`
* `HighExpense`
* `Uncategorized`

---

## 🔍 Example

**Input**

```json
{
  "description": "Uber Eats Paris",
  "amount": 29.90,
  "date": "2025-05-08T12:45:00Z"
}
```

**Output**

```json
{
  "category": "FoodDelivery"
}
```

---

## 🧠 Business Rules

* If `description` contains `"Uber"` → `Transport`
* If `description` contains `"Eats"` or `"Deliveroo"` → `FoodDelivery`
* If `amount > 1000` → `HighExpense`
* Else → `Uncategorized`

> The rules are encapsulated in the domain layer and easily extendable.

---

## 🛡 Architecture

This project follows strict **Clean Architecture** and **CQRS** principles.

```
Ledger.Categorizer/
├── Api/            # ASP.NET Core Minimal API (exposition)
├── Application/    # Use cases, commands, handlers (CQRS)
├── Domain/         # Entities, ValueObjects, Rules
├── Infrastructure/ # Rule engine implementation
└── Tests/          # xUnit test suite
```

---

## ✅ Test Coverage

Unit tested with [xUnit](https://xunit.net/).
You can run all tests with:

```bash
dotnet test
```

---

## 📦 Installation (WIP)

This module is not yet published as a NuGet package.
To integrate it manually:

1. Clone the repository
2. Reference the `.csproj` from your solution
3. Inject the `ICategorizeTransaction` implementation into your service container

---

## 📦 Integration Ready

* [X] Self-contained
* [X] No persistence required
* [X] Plug & play via DI
* [X] Fully tested and extensible

---

## © License

MIT — Free to use, modify, and distribute.
