# MVCAspNetApp

This is an ASP.NET MVC application that uses Entity Framework Core for data access.

## Project Setup

Here are the steps to create the project and install dependencies:

1. **Create the ASP.NET MVC project**
    Create a new ASP.NET MVC project named `MVCAspNetApp` [Replace this with your preferred name] using the .NET CLI with the following command:

    ```bash
    dotnet new mvc -o MVCAspNetApp
    ```

2. **Navigate to the project directory** Navigate into the newly created project directory:
```bash
cd MVCAspNetApp
```

3. **Install the EF Core CLI** Install the Entity Framework Core command-line interface:
```bash
dotnet tool install --global dotnet-ef
```

4. **Add Entity Framework Core** Add the Entity Framework Core package to your project:
```bash
dotnet add package Microsoft.EntityFrameworkCore
```

5. **Update the appsettings.json file** Add your connection string to the appsettings.json file:
```bash
"ConnectionStrings": {
    "DefaultConnection": "Your_Connection_String_Here"
}
```
6. **Update the Program.cs file** Update the Program.cs file to use the connection string from the appsettings.json file.

7. **Create the LeadEntity class** Create a `LeadEntity` class in the Models folder with properties for Id, LeadSource, Name, Mobile, and Phone.

8. **Create the ApplicationDbContext class** Create an `ApplicationDbContext` class in the Data folder. This class is used to interact with the database using Entity Framework Core.

9. **Update the HomeController** Update the `HomeController` in the Controllers folder to handle HTTP requests and responses.

10. **Update the Views** Update the views in the Views folder to display data to the user.

11. **Create the initial database migration** Create the initial database migration:
```bash
dotnet ef migrations add InitialCreate
```

12. **Update the database** Update the database to apply the migration:
```bash
dotnet ef database update
```

## Troubleshooting
If you encounter an error like "Cannot open server 'evketek6-sql' requested by the login. Client with IP address '51.140.125.85' is not allowed to access the server", you need to create a firewall rule in the Azure portal to allow your IP address to access the server.


## Running the Project
To run the project, use the following command in the terminal:
```bash
dotnet run
```
This will start the application and it will be accessible at `http://localhost:5000`.