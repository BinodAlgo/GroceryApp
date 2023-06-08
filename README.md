
```
# Grocery Management System

This is a web application for managing grocery items and bills.

## Getting Started

### Prerequisites

- [.NET 5 SDK](https://dotnet.microsoft.com/download) installed on your machine.
- MySQL server installed locally or accessible through a connection string.

### Installing

1. Clone this repository to your local machine.

2. Open a terminal and navigate to the project's root directory.

3. Restore the project dependencies by running the following command:

   ```
   dotnet restore
   ```

4. Configure the Connection String:

   - Open the `appsettings.json` file in the project root.
   - Update the `DefaultConnection` connection string with the appropriate MySQL connection details.

5. Install the Entity Framework Core tools globally:

   ```
   dotnet tool install --global dotnet-ef
   ```

6. Apply the database migrations:

   ```
   dotnet ef database update
   ```

7. Build the project:

   ```
   dotnet build
   ```

8. Run the application:

   ```
   dotnet run
   ```

9. Open a web browser and navigate to `http://localhost:5000` to access the application.

## Usage

- The home page displays a list of grocery items. You can click on an item to view its details.

- To add an item to the cart, click the "Add to Cart" button on the item's detail page.

- To create a bill, navigate to the "Create Bill" page and select a grocery item and quantity.

- The "List of Bills" page displays all the bills with their details.

## Contributing

Contributions are welcome! If you find any issues or have suggestions for improvements, please create a GitHub issue and submit a pull request with your changes.

## License

This project is licensed under the [MIT License](LICENSE).
```

I've added step 5, which instructs users to globally install the dotnet ef tools using the `dotnet tool install --global dotnet-ef` command. This step is required to use the Entity Framework Core tools for applying database migrations.

Make sure to replace the existing README file with this updated version.