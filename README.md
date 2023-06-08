
# Online Grocery App

This is an online grocery application that allows users to browse and purchase grocery items. It also provides an admin panel for managing the grocery items and user accounts.

## Features

- User Registration and Login
- Browse Grocery Items
- Add Items to Cart
- Create and Manage Bills
- Admin Panel for Grocery Item Management and User Account Management
- Logout Functionality

## Technologies Used

- C# programming language
- ASP.NET Core framework
- Entity Framework Core for database management
- MySQL database
- HTML/CSS for front-end
- Bootstrap for responsive design

## Getting Started

To run this application locally, follow these steps:

### Prerequisites

- [.NET Core SDK](https://dotnet.microsoft.com/download) installed on your machine
- MySQL database server installed

### Installation

1. Clone the repository:

   ```bash
   git clone https://github.com/BinodAlgo/GroceryApp.git
   ```

2. Change into the project directory:

   ```bash
   cd GroceryApp
   ```

3. Install the dotnet-ef tools globally by running the following command:

   ```bash
   dotnet tool install --global dotnet-ef
   ```

   This step is required to use the Entity Framework Core command-line tools for managing database migrations.

4. Create a new MySQL database for the application.

5. Update the database connection string in the `appsettings.json` file located in the `GroceryApp` project:

   ```json
   "ConnectionStrings": {
     "DefaultConnection": "server=localhost;database=your-database;user=root;password=your-password"
   }
   ```

   Replace `your-database` with the name of your MySQL database and update the `user` and `password` as necessary.

6. Apply the database migrations to create the necessary tables. Run the following command in the project root directory:

   ```bash
   dotnet ef database update --project GroceryApp
   ```

7. Install the required NuGet packages by running the following command in the project root directory:

   ```bash
   dotnet restore
   ```

8. Start the application:

   ```bash
   dotnet run --project GroceryApp
   ```

9. Open a web browser and navigate to `http://localhost:5121` to access the application.

## Usage

- Register a new user account or login with an existing account.
- Browse the grocery items and add items to the cart.
- View and manage your bills.
- Access the admin panel to manage grocery items and user accounts.

## Contributing

Contributions are welcome! If you find any issues or have suggestions for improvements, please open an issue or submit a pull request.

## License

This project is licensed under the [MIT License](LICENSE).
```

Please make sure to update the repository URL, database connection details, and any other specific information relevant to your project.