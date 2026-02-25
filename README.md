# Oceanography Data Management System

A full-stack, multi-tenant ASP.NET Core MVC application engineered to manage and process localized oceanographic telemetry. The system provides secure, user-isolated data logging for researchers to record critical environmental observations.

## Architecture & Tech Stack

This project is built on the .NET ecosystem, utilizing a monolithic MVC architecture for rapid development and server-side rendering.

* **Framework:** ASP.NET Core 8.0 MVC
* **Database:** SQL Server via Entity Framework (EF) Core 8.0
* **Authentication:** ASP.NET Core Identity
* **Frontend:** Razor Pages (CSHTML), Bootstrap 5, and jQuery
* **Version Control:** Standardized `.gitignore` for Visual Studio and .NET environments, explicitly ignoring build artifacts, local environment variables, and Nuget packages to maintain repository hygiene.



## Core Engineering Features

### 1. Data Integrity & Domain Validation
The `OceanData` domain model enforces strict, scientifically accurate validation constraints at the application level before database insertion:
* **Geospatial Bounds:** Latitude ranges between -90 and 90; Longitude between -180 and 180.
* **Thermodynamic & Chemical Bounds:** Temperature constrained between -2°C and 40°C; Salinity strictly limited to 0–50 PSU. 
* **Environmental Metrics:** pH (0–14) and Dissolved Oxygen (0–20 mg/L) are captured as nullable decimals to account for potential sensor failure or incomplete field data.

### 2. User-Isolated Data Access
The application implements user-specific data isolation. By extending the default Identity `ApplicationUser` with custom attributes (FirstName, LastName, Institution), the `OceanDataController` binds every environmental record to a specific `UserId`. Users can uniquely view and manage only their own recorded telemetry.

### 3. Streamlined UI/UX
The application relies on server-rendered Razor views with centralized layout management (`_Layout.cshtml`). Form submission and data validation are handled securely using built-in ASP.NET TagHelpers and client-side unobtrusive jQuery validation.

## Getting Started

### Prerequisites
* [.NET 8.0 SDK](https://dotnet.microsoft.com/download)
* SQL Server (LocalDB or dedicated instance)

### Installation & Setup

1. **Clone the repository:**
    ```bash
    git clone [https://github.com/your-username/OceanographyManagement.git](https://github.com/your-username/OceanographyManagement.git)
    cd OceanographyManagement
    ```
2. **Configure the Database:**
    Ensure your `appsettings.Development.json` contains the correct SQL Server connection string. The default expects a trusted local connection (`Server=localhost;Database=OceanographyDb`).
3. **Apply Entity Framework Migrations:**
    ```bash
    dotnet ef database update
    ```
4. **Run the application:**
    ```bash
    dotnet run
    ```

## Roadmap & Future Architectural Enhancements

While the current iteration successfully handles CRUD operations, the following improvements are planned for production scaling:
* **Repository Pattern Implementation:** Abstracting the `ApplicationDbContext` out of the controllers to adhere to the Dependency Inversion Principle and improve unit testability.
* **Pagination & Filtering:** Implementing server-side pagination in the `OceanData/Index` view to handle large datasets effectively.
* **Geospatial Database Integration:** Migrating spatial columns (Latitude/Longitude) to PostGIS or SQL Server Spatial Types for advanced geographic querying.
