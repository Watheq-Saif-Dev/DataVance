#  DataVance — ERP & Financial Management System

> ⚠️ **Work in Progress** — This project is currently under active development and is **not production-ready**. Features are being added and architectural patterns are being refined continuously.

---

##  Overview

**DataVance** is an enterprise-grade ERP (Enterprise Resource Planning) system focused on **financial management**, built with a clean, scalable architecture using **.NET 8** and **Blazor Server**.

The system is designed to handle complex financial workflows including multi-currency accounting, fiscal year management, journal entries, purchase transactions, and automated rule-based journal generation.

> 🔧 **Status:** Under Development — Core financial modules are functional, but several features, UI polish, and testing layers are still being built.

---

## Architecture

The project follows **Clean Architecture** principles with strict layer separation:

```
DataVance.sln
├── DataVance                    → Presentation Layer  (Blazor Server)
├── DataVance.Application        → Application Layer   (CQRS + MediatR)
├── DataVance.Domain             → Domain Layer        (Entities + Domain Logic)
└── DataVance.Infrastructure     → Infrastructure Layer (EF Core + SQL Server)
```

### Key Architectural Patterns Applied

| Pattern | Implementation |
|---|---|
| **CQRS** | MediatR with Commands & Queries |
| **Pipeline Behaviors** | Logging, Authorization, Validation, Transaction, Outbox |
| **Domain Events** | Via `AggregateRoot` + Outbox Pattern |
| **Rule Engine** | Specifications Pattern + Context Builders |
| **Repository Pattern** | Per-aggregate repositories |
| **Unit of Work** | Coordinated DB transactions |
| **Feature-Based Structure** | 10 isolated feature modules |

---

## Completed Modules

- [x] **Chart of Accounts** — Hierarchical account structure
- [x] **Multi-Currency Support** — Currency management + exchange rates
- [x] **Fiscal Year & Periods** — Year/period creation and management
- [x] **Journal Entries** — Manual and automated double-entry bookkeeping
- [x] **Opening Balances** — Initial balance setup per account/currency
- [x] **Purchase Transactions** — Procurement with auto journal generation
- [x] **Financial Reports** — Balance sheet and P&L structure
- [x] **Rule Engine** — Automated accounting rule execution
- [x] **Audit System** — Full change tracking and audit logs
- [x] **Identity & Security** — Role-based access + permission system
- [x] **Branch System** — Multi-branch data isolation
- [x] **Event Management** — Domain event processing via Outbox

---

## Tech Stack

| Layer | Technology |
|---|---|
| Runtime | .NET 8 |
| UI Framework | Blazor Server |
| ORM | Entity Framework Core 8 |
| Database | SQL Server |
| Mediator | MediatR |
| Authentication | ASP.NET Core Identity |
| Architecture | Clean Architecture + DDD |

---

##  Getting Started

### Prerequisites

- [.NET 8 SDK](https://dotnet.microsoft.com/download/dotnet/8.0)
- SQL Server (local or remote)
- Visual Studio 2022 / VS Code

### Setup

1. **Clone the repository**
   ```bash
   git clone https://github.com/your-username/DataVance.git
   cd DataVance
   ```

2. **Configure the connection string**  
   In `DataVance/appsettings.json`, update:
   ```json
   {
     "ConnectionStrings": {
       "DefaultConnection": "Server=YOUR_SERVER;Database=DataVanceDb;Trusted_Connection=True;"
     }
   }
   ```
   >  Recommended: Use [User Secrets](https://learn.microsoft.com/en-us/aspnet/core/security/app-secrets) instead of hardcoding credentials.

3. **Apply migrations**
   ```bash
   dotnet ef database update --project DataVance.Infrastructure --startup-project DataVance
   ```

4. **Run the application**
   ```bash
   dotnet run --project DataVance
   ```
   Navigate to `https://localhost:xxxx`

---

##  Project Stats

| Metric | Value |
|---|---|
| Source Files | 407 files (excl. Migrations) |
| Lines of Code | ~18,257 lines |
| Database Migrations | 60+ migrations |

