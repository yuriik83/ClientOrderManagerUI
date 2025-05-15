# Client Order Manager

A fullstack .NET 8 web application for managing customer orders, statuses, and email notifications. Built with ASP.NET Core Web API and Blazor Server.

## Features
- Add, update, delete client orders
- Order statuses (Pending, In Progress, Completed)
- Email reminders on status changes
- Admin dashboard with Blazor
- RESTful API with Swagger docs
- Logging with Serilog

## Tech Stack
- ASP.NET Core 8 Web API
- Entity Framework Core
- PostgreSQL or SQL Server
- Blazor Server
- MailKit, AutoMapper, FluentValidation
- Serilog for logging

## Getting Started

### Prerequisites
- .NET 8 SDK
- PostgreSQL or SQL Server
- Visual Studio 2022+ or Rider

### Run Locally
1. Clone the repo
   ```
   git clone https://github.com/yourusername/ClientOrderManager.git
   ```
2. Set connection string and email settings in `appsettings.json`
3. Apply EF migrations:
   ```
   dotnet ef database update --project ClientOrderManager.API
   ```
4. Run both API and UI projects