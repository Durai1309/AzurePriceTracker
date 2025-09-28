# AzurePriceTracker

AzurePriceTracker is an ASP.NET Core MVC application that tracks Azure retail prices in real-time. It fetches pricing data via Azure’s REST API, stores it in a database, and provides a user-friendly interface to explore service pricing.

## Features

- Fetch Azure retail pricing dynamically in INR.
- Store raw pricing data in a SQL database using Entity Framework Core.
- Group and display services by Service Family and Service Name.
- View detailed product information including SKU, unit price, and location.
- Interactive grid interface powered by [w2ui](http://w2ui.com/) with search, sorting, and pagination.
- Supports tracking multiple Azure services and SKUs.

## Technologies Used

- ASP.NET Core MVC
- Entity Framework Core
- SQL Server (or any EF Core supported database)
- w2ui for responsive grid UI
- HttpClient for REST API calls
- C#, .NET 6

## Getting Started

### Prerequisites

- [.NET 6 SDK](https://dotnet.microsoft.com/download/dotnet/6.0)
- SQL Server or any database supported by EF Core
- Visual Studio or VS Code

### Installation

1. Clone the repository:
   ```bash
   git clone https://github.com/Durai1309/AzurePriceTracker.git
   cd AzurePriceTracker
2. Configure your database connection string in appsettings.json:

   "ConnectionStrings": {
     "DefaultConnection": "Server=YOUR_SERVER;Database=AzurePriceDb;Trusted_Connection=True;"
   }

3. Apply EF Core migrations: dotnet ef database update

4. Run the application: dotnet run

5. Open a browser and go to: https://localhost:5001/AzurePrices
