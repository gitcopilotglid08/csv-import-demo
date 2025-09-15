# CsvImportDemo

A minimal ASP.NET Core Web API demo for uploading, validating, and importing CSV data using Clean Architecture principles.

## Features
- Upload CSV file with product data
- Validate each record (name required, price/quantity non-negative)
- Save valid records to SQLite database
- Retrieve all products
- Unit tests for service layer

## Project Structure
- Controllers: API endpoints
- Services: Business logic
- Validators: Validation logic
- Repositories: Data access
- Data: EF Core DbContext
- Models: Data models
- Tests: Unit tests

## Getting Started
1. Restore packages: `dotnet restore`
2. Build: `dotnet build`
3. Run: `dotnet run`
4. Test: `dotnet test`

## API Endpoints
- `POST /api/products/upload` — Upload CSV file (form-data, key: file)
- `GET /api/products` — List all products

## Example CSV
```
Name,Price,Quantity
Product1,10.5,5
Product2,20,2
```
