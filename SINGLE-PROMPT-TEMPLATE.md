# Complete CSV Import Demo Project - Single Prompt

Use this comprehensive prompt to recreate the entire CSV Import Demo project with Clean Architecture:

---

**Create a complete ASP.NET Core Web API project with React frontend for CSV import using Clean Architecture.**

## Project Requirements:
- ASP.NET Core Web API with Entity Framework Core SQLite
- React frontend for file upload and product display
- Clean Architecture with Controllers, Services, Validators, Repositories, Data, Models folders
- CSV parsing with validation using CsvHelper
- Real-time product display after upload
- Unit tests with Moq and xUnit

## Project Structure:
```
CsvImportDemo/
├── Controllers/ProductsController.cs
├── Services/IProductService.cs, ProductService.cs
├── Validators/IProductValidator.cs, ProductValidator.cs
├── Repositories/IProductRepository.cs, ProductRepository.cs
├── Data/AppDbContext.cs
├── Models/Product.cs, ProductCsvDto.cs
├── Tests/ProductServiceTests.cs
├── Program.cs, appsettings.json, CsvImportDemo.csproj
├── sample-products.csv
├── NuGet.config (public feed only)
├── react-client/
│   ├── package.json
│   ├── public/index.html
│   └── src/index.js, App.js, App.css
└── start-apps.bat
```

## Technical Details:
- **Product model**: Id (auto), Name, Price, Quantity
- **ProductCsvDto** for CSV import (Name, Price, Quantity only - no Id)
- **Validation**: non-empty name, non-negative price/quantity
- **CORS** configured for React app
- **Error handling** with detailed messages
- **SQLite database** with EF Core
- **Swagger UI** enabled
- **Auto-generated ports** in launchSettings.json

## Package Dependencies:
### ASP.NET Core:
- Microsoft.EntityFrameworkCore.Sqlite
- Microsoft.EntityFrameworkCore.Design  
- CsvHelper
- Moq 4.*
- Swashbuckle.AspNetCore
- xunit
- xunit.runner.visualstudio

### React:
- React 18.2.0
- react-dom 18.2.0
- react-scripts 5.0.1
- axios 1.6.0

## API Endpoints:
- **POST** `/api/products/upload` (CSV file upload with form-data)
- **GET** `/api/products` (list all products)

## Key Implementation Notes:
1. **CSV Import Logic**: Use ProductCsvDto to read CSV, then convert to Product entity (Id auto-generated)
2. **CORS Configuration**: Allow localhost:3000 for React app
3. **Error Handling**: Comprehensive validation with row-specific error messages
4. **React App**: File upload component + products table with real-time updates
5. **Database**: SQLite with EnsureCreated() for demo purposes
6. **NuGet.config**: Only public NuGet feed to avoid authentication issues

## Sample CSV Format:
```csv
Name,Price,Quantity
Laptop,999.99,10
Mouse,25.50,50
Keyboard,75.00,25
```

**Create all files with complete implementation, proper error handling, CORS configuration, and ensure the React app connects to the correct API port from launchSettings.json. Include a batch script to start both applications and sample CSV data for testing.**

---

## Usage Instructions:
1. Copy the prompt above
2. Paste into a new AI conversation
3. The AI will create the complete working project
4. Run `start-apps.bat` or manually start API with `dotnet run` and React with `npm start`