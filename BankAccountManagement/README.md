Overview
This is a Bank Account Management system built using .NET Core. The project follows a clean architecture approach, separating concerns into different layers.

Project Structure
The solution is divided into the following layers:

BankAccountManagement.API: This project contains the main entry point of the application, including controllers, API routes, and the
API configuration.
BankAccountManagement.Application: Contains the business logic, services, and Data Transfer Objects (DTOs) used for communication between
layers
BankAccountManagement.Domain: Defines the core domain models, entities, and interfaces for repository pattern implementation
BankAccountManagement.Infrastructure: Implements the database access layer, including repository pattern implementations and database migrations, as well as Redis caching.
Technologies Used
.NET Core - The main framework used for building the API.
Entity Framework Core - ORM used for database interactions.
Redis (for caching) - Used for caching frequently accessed data to improve performance.
AutoMapper - Used for object-to-object mapping, ensuring proper DTO and model conversions.
Swagger (API Documentation) - Provides interactive API documentation for easier development and testing.
Prerequisites
Before you begin, ensure you have the following installed on your machine:

.NET SDK
SQL Server
Redis