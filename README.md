# CSV Import Demo

A full-stack ASP.NET Core Web API with React client for uploading, validating, and importing CSV data using Clean Architecture principles.

## Features
- **ASP.NET Core Web API Backend:**
  - Upload CSV file with product data
  - Validate each record (name required, price/quantity non-negative)
  - Save valid records to SQLite database
  - Retrieve all products via REST API
  - Unit tests for service layer

- **React Client Frontend:**
  - User-friendly interface for CSV file upload
  - Display validation results and imported products
  - Real-time feedback during upload process

## Tech Stack
- **Backend:** ASP.NET Core 8.0, Entity Framework Core, SQLite
- **Frontend:** React 18, Axios for API calls
- **Testing:** MSTest
- **Architecture:** Clean Architecture with separation of concerns

## Project Structure
```
├── Controllers/          # API endpoints
├── Services/            # Business logic
├── Validators/          # Validation logic  
├── Repositories/        # Data access layer
├── Data/               # EF Core DbContext
├── Models/             # Data models and DTOs
├── Tests/              # Unit tests
├── react-client/       # React frontend application
└── Properties/         # Launch settings
```

## Prerequisites
- [.NET 8.0 SDK](https://dotnet.microsoft.com/download/dotnet/8.0)
- [Node.js](https://nodejs.org/) (v16 or higher)
- [npm](https://www.npmjs.com/) (comes with Node.js)

## Getting Started

### Backend Setup
1. **Clone the repository:**
   ```bash
   git clone https://github.com/gitcopilotglid08/csv-import-demo.git
   cd csv-import-demo
   ```

2. **Restore .NET packages:**
   ```bash
   dotnet restore
   ```

3. **Build the project:**
   ```bash
   dotnet build
   ```

4. **Run the API:**
   ```bash
   dotnet run
   ```
   The API will be available at `https://localhost:5001` or `http://localhost:5000`

### Frontend Setup
1. **Navigate to the React client directory:**
   ```bash
   cd react-client
   ```

2. **Install npm packages:**
   ```bash
   npm install
   ```

3. **Start the React development server:**
   ```bash
   npm start
   ```
   The client will be available at `http://localhost:3000`

### Running Tests
```bash
dotnet test
```

### Quick Start (Both Applications)
Use the provided batch file to start both applications:
```bash
start-apps.bat
```

## API Endpoints
- `POST /api/products/upload` — Upload CSV file (form-data, key: file)
- `GET /api/products` — List all products

## Example CSV Format
```csv
Name,Price,Quantity
Product1,10.5,5
Product2,20,2
Invalid Product,,3
Another Product,15.99,0
```

## Development Notes
- The SQLite database (`products.db`) is automatically created on first run
- Invalid records are logged but not saved to the database
- The React client expects the API to be running on `https://localhost:5001`
- CORS is configured to allow requests from `http://localhost:3000`

## Contributing
1. Fork the repository
2. Create a feature branch
3. Make your changes
4. Add tests for new functionality
5. Ensure all tests pass
6. Submit a pull request

## License
This project is for demonstration purposes.
