# 🚀 Signup Page - ASP.NET Core Web Application

<div align="center">

A modern, full-stack signup application built with **ASP.NET Core Web API**, **Entity Framework Core**, and **SQL Server**. Features a beautiful frontend with Tailwind CSS and secure password hashing.

[![.NET](https://img.shields.io/badge/.NET-8.0-512BD4?logo=dotnet)](https://dotnet.microsoft.com/)
[![ASP.NET Core](https://img.shields.io/badge/ASP.NET%20Core-8.0-512BD4?logo=dotnet)](https://dotnet.microsoft.com/apps/aspnet)
[![Entity Framework](https://img.shields.io/badge/EF%20Core-8.0-512BD4)](https://learn.microsoft.com/en-us/ef/core/)
[![SQL Server](https://img.shields.io/badge/SQL%20Server-2019+-CC2927?logo=microsoft-sql-server)](https://www.microsoft.com/sql-server)

</div>

---

## ✨ Features

- 🔐 **Secure User Registration** - Password hashing using SHA256
- 🎨 **Modern UI** - Beautiful signup form built with Tailwind CSS
- 🏗️ **Clean Architecture** - Separation of concerns with DTOs, Models, and Controllers
- 📊 **Entity Framework Core** - Code-first database approach
- 🔒 **Input Validation** - Server-side validation with Data Annotations
- 🌐 **RESTful API** - Clean API endpoints following REST principles
- 📱 **Responsive Design** - Mobile-friendly interface

---

## 🛠️ Tech Stack

| Layer | Technology |
|-------|-----------|
| **Backend** | ASP.NET Core 8.0 Web API |
| **ORM** | Entity Framework Core 8.0 |
| **Database** | SQL Server / LocalDB |
| **Frontend** | HTML5, JavaScript (Vanilla), Tailwind CSS |
| **Language** | C# (.NET 8.0) |

---

## 📁 Project Structure

```
signuppage/
│
├── Controllers/
│   └── AuthController.cs          # Authentication API endpoints
│
├── Data/
│   └── AppDbContext.cs            # Entity Framework database context
│
├── Models/
│   └── User.cs                    # User entity model
│
├── DTOs/
│   └── SignupDto.cs               # Data Transfer Object for signup
│
├── wwwroot/
│   ├── index.html                 # Signup page frontend
│   └── script.js                  # Form submission JavaScript
│
├── Properties/
│   └── launchSettings.json        # Launch configuration
│
├── appsettings.json               # Application configuration
├── Program.cs                     # Application entry point
└── signuppage.csproj             # Project file with dependencies
```

---

## 📋 Prerequisites

Before you begin, ensure you have the following installed:

- [**.NET 8.0 SDK**](https://dotnet.microsoft.com/download/dotnet/8.0) or later
- [**SQL Server**](https://www.microsoft.com/en-us/sql-server/sql-server-downloads) (Express/Developer edition) or **SQL Server LocalDB**
- [**Visual Studio 2022**](https://visualstudio.microsoft.com/) (recommended) or **VS Code** with C# extension
- **Git** (for version control)

---

## 🚀 Getting Started

### Step 1: Clone the Repository

```bash
git clone https://github.com/Hamza0053/signuppage.git
cd signuppage
```

### Step 2: Restore Dependencies

```bash
dotnet restore
```

### Step 3: Configure Database Connection

Update the connection string in `appsettings.json`:

```json
{
  "ConnectionStrings": {
    "DefaultConnection": "Server=(localdb)\\MSSQLLocalDB;Database=SignupDemoDB;Trusted_Connection=True;TrustServerCertificate=True;"
  }
}
```

> **Note:** For SQL Server Express, use:
> ```json
> "Server=localhost\\SQLEXPRESS;Database=SignupDemoDB;Trusted_Connection=True;TrustServerCertificate=True;"
> ```

### Step 4: Create Database

#### Option A: Using Entity Framework Migrations (Recommended)

```bash
# Create initial migration
dotnet ef migrations add InitialCreate

# Apply migration to create database
dotnet ef database update
```

#### Option B: Manual SQL Script

Open **SQL Server Management Studio (SSMS)** and execute:

```sql
CREATE DATABASE SignupDemoDB;
GO

USE SignupDemoDB;
GO

CREATE TABLE Users (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    FullName NVARCHAR(100) NOT NULL,
    Email NVARCHAR(100) NOT NULL UNIQUE,
    PasswordHash NVARCHAR(255) NOT NULL,
    CreatedAt DATETIME NOT NULL DEFAULT GETDATE()
);
GO
```

### Step 5: Run the Application

#### Using Visual Studio
1. Press **F5** or click the **Run** button
2. The application will start with the configured port

#### Using Command Line
```bash
dotnet run
```

The application will be available at:
- **HTTPS:** `https://localhost:7089/index.html`
- **HTTP:** `http://localhost:5089/index.html`

> **Note:** Port numbers may vary. Check the console output for the actual URLs.

---

## 📖 Usage

### Signup Flow

1. **Open the Signup Page**
   - Navigate to `https://localhost:7089/index.html` in your browser

2. **Fill in the Form**
   - Enter your **Full Name**
   - Enter a valid **Email** address
   - Enter a **Password** (minimum 6 characters)

3. **Submit**
   - Click the **Sign Up** button
   - You'll receive a success message if registration is successful

4. **Verify in Database**
   - Check the `Users` table in SQL Server to see the new user record
   - Password will be stored as a hash (never plain text)

---

## 🔌 API Endpoints

### POST `/api/auth/signup`

Register a new user account.

**Request Body:**
```json
{
  "fullName": "John Doe",
  "email": "john.doe@example.com",
  "password": "securepassword123"
}
```

**Success Response (200 OK):**
```
Signup successful
```

**Error Response (400 Bad Request):**
```
Email already exists
```

**Validation Rules:**
- `fullName`: Required, any string
- `email`: Required, valid email format
- `password`: Required, minimum 6 characters

---

## 🔒 Security Features

- ✅ **Password Hashing** - Passwords are hashed using SHA256 before storage
- ✅ **Email Uniqueness** - Prevents duplicate email registrations
- ✅ **Input Validation** - Server-side validation using Data Annotations
- ✅ **HTTPS Support** - Secure connection enabled by default
- ✅ **CORS Configuration** - Cross-origin requests configured

> **⚠️ Security Note:** For production, consider using **bcrypt** or **PBKDF2** instead of SHA256 for password hashing, as SHA256 is fast and vulnerable to rainbow table attacks.

---

## 🧪 Testing

### Manual Testing

1. Test valid signup:
   ```json
   POST /api/auth/signup
   {
     "fullName": "Test User",
     "email": "test@example.com",
     "password": "password123"
   }
   ```

2. Test duplicate email:
   - Try signing up with the same email twice
   - Should return "Email already exists"

3. Test validation:
   - Submit empty fields
   - Submit invalid email format
   - Submit password less than 6 characters

### Using Swagger (if enabled)

If Swagger is configured, navigate to:
```
https://localhost:7089/swagger
```

---

## 🏗️ Architecture

### Data Flow

```
Frontend (index.html)
    ↓
JavaScript (script.js)
    ↓
API Endpoint (/api/auth/signup)
    ↓
AuthController
    ↓
SignupDto (Validation)
    ↓
AppDbContext (Entity Framework)
    ↓
SQL Server Database
```

### Key Components

- **DTOs** - Data Transfer Objects prevent exposing internal models
- **Models** - Entity classes representing database tables
- **DbContext** - Entity Framework context for database operations
- **Controllers** - Handle HTTP requests and business logic

---

## 📝 Configuration

### Connection Strings

**LocalDB (Default):**
```json
"Server=(localdb)\\MSSQLLocalDB;Database=SignupDemoDB;Trusted_Connection=True;TrustServerCertificate=True;"
```

**SQL Server Express:**
```json
"Server=localhost\\SQLEXPRESS;Database=SignupDemoDB;Trusted_Connection=True;TrustServerCertificate=True;"
```

**SQL Server (Named Instance):**
```json
"Server=localhost\\YourInstanceName;Database=SignupDemoDB;User Id=sa;Password=YourPassword;TrustServerCertificate=True;"
```

### CORS Settings

CORS is configured in `Program.cs` to allow all origins. For production, restrict this:

```csharp
policy.WithOrigins("https://yourdomain.com")
      .AllowAnyHeader()
      .AllowAnyMethod();
```

---

## 🤝 Contributing

Contributions are welcome! Please follow these steps:

1. **Fork the repository**
2. **Create a feature branch**
   ```bash
   git checkout -b feature/amazing-feature
   ```
3. **Make your changes**
4. **Commit your changes**
   ```bash
   git commit -m "Add amazing feature"
   ```
5. **Push to the branch**
   ```bash
   git push origin feature/amazing-feature
   ```
6. **Open a Pull Request**

---

## 📦 Dependencies

| Package | Version | Purpose |
|---------|---------|---------|
| `Microsoft.EntityFrameworkCore` | 8.0.10 | Entity Framework Core |
| `Microsoft.EntityFrameworkCore.SqlServer` | 8.0.10 | SQL Server provider |
| `Microsoft.EntityFrameworkCore.Tools` | 8.0.10 | EF Core tools for migrations |
| `Swashbuckle.AspNetCore` | 6.6.2 | Swagger/OpenAPI support |

---

## 🔮 Future Enhancements

- [ ] **JWT Authentication** - Implement login with JWT tokens
- [ ] **Email Verification** - Send verification emails on signup
- [ ] **Password Reset** - Forgot password functionality
- [ ] **Frontend Validation** - Client-side form validation
- [ ] **EF Core Migrations** - Automated database migrations
- [ ] **Unit Tests** - Add xUnit test project
- [ ] **Integration Tests** - Test API endpoints
- [ ] **Docker Support** - Containerize the application
- [ ] **CI/CD Pipeline** - Automated deployment
- [ ] **Better Password Hashing** - Migrate to bcrypt/PBKDF2
- [ ] **Rate Limiting** - Prevent abuse
- [ ] **Logging** - Enhanced logging with Serilog

---

## 📄 License

This project is open source and available under the [MIT License](LICENSE).

---

## 👤 Author

- GitHub: [@Hamza Nazir](https://github.com/Hamza0053)
- Email: hamzanazir653@gmail.com

---

## 🙏 Acknowledgments

- [ASP.NET Core Documentation](https://learn.microsoft.com/en-us/aspnet/core/)
- [Entity Framework Core Documentation](https://learn.microsoft.com/en-us/ef/core/)
- [Tailwind CSS](https://tailwindcss.com/)

---

## 📞 Support

If you have any questions or need help, please:
- Open an [Issue](https://github.com/Hamza0053/signuppage.git)
- Check the [Documentation](https://github.com/Hamza0053/signuppage.git)

---

<div align="center">

**⭐ Star this repo if you find it helpful! ⭐**

Made with ❤️ using ASP.NET Core

</div>

