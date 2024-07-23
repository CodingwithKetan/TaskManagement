# Task Management System

A comprehensive task management system designed to help employees track their tasks, attach documents, add notes, and complete tasks. This system supports various roles: Admin, Manager, and Developer, each with specific capabilities.

## Features

### Admin
- Register new employees.
- View reports related to tasks that are due within a week, month, etc.

### Manager
- Create and assign tasks to team members.
- Track the progress of tasks assigned to their team.

### Developer
- Track tasks assigned to them.
- Add notes and attach documents to tasks.
- Update the status of tasks.

## Technical Details

### Technologies Used
- **ASP.NET Core**: Framework for building the web API.
- **Entity Framework Core**: ORM for data access.
- **SQL Server**: Database for storing application data.
- **Onion Architecture**: A layered architecture pattern that promotes separation of concerns and dependency inversion.

### Benefits of Onion Architecture
- **Separation of Concerns**: Helps to keep different parts of the application independent from each other.
- **Testability**: Facilitates testing by isolating business logic from infrastructure concerns.
- **Maintainability**: Makes it easier to manage and modify the application over time.
- **Flexibility**: Allows for easier substitution of different technologies or frameworks.

### NuGet Packages
1. **`Microsoft.AspNetCore.Authentication.JwtBearer`**
   - **Purpose**: Provides JWT bearer token authentication support, which is essential for securing API endpoints.
   
2. **`Microsoft.EntityFrameworkCore.SqlServer`**
   - **Purpose**: Provides SQL Server database provider for Entity Framework Core, enabling communication with the SQL Server database.
   
3. **`Microsoft.AspNetCore.Identity.EntityFrameworkCore`**
   - **Purpose**: Provides Identity support with Entity Framework Core, facilitating user authentication and authorization.
   
4. **`Microsoft.EntityFrameworkCore.Tools`**
   - **Purpose**: Contains tools for Entity Framework Core, including migrations and database updates.

## How to Run the Application

1. **Clone the repository:**

    ```bash
    git clone https://github.com/your-username/task-management-system.git
    ```

2. **Navigate to the project directory:**

    ```bash
    cd task-management-system
    ```

3. **Update the SQL connection string:**
   - Open `appsettings.json` and modify the `DefaultConnection` string to match your SQL Server instance.

4. **Create the database:**
   - Run the following command to apply migrations and create the database:

    ```bash
    dotnet ef database update
    ```

5. **Run the application:**

    ```bash
    dotnet run
    ```

## Future Enhancements

### Token Refresh Functionality
- Implement functionality for refreshing JWT tokens.

### Employee Hierarchy
- Add functionality to manage employee roles and hierarchy.

### Logging
- Implement logging for better monitoring and debugging.

### Global Exception Handling and Fluent Validation
- Add global exception handling to manage errors gracefully.
- Implement Fluent Validation for input validation.

## Contact

Ketan Ghori - [ghoriketan33@gmail.com](mailto:your-email@example.com)