=> Maintenance Management Backend (ASP.NET Core-9)
This is the backend API for the Maintenance Management Module. It provides CRUD operations for services and tasks and uses JWT authentication.

=> Features
Built with ASP.NET Core and Entity Framework Core
SQL Server database
Auto-migration on startup
One default admin user seeded on first run
JWT-based authentication

=> Connection string
Before running the project, **update your SQL Server connection string** in `appsettings.json/appsettings.Development.json`:

=> Getting Started (Visual Studio)
Open the solution in Visual Studio.
Set the backend project as the startup project (MaintenanceManagementModule.API).
Run the project (Press **F5**).
The API will launch at `https://localhost:44369/api/` by default. You can test it using Swagger or connect the Angular frontend.

=> Default Admin Login
email : admin@maintenance.com
password : Admin@999


=> Maintenance Management Web (Angular)
This is the frontend of the Maintenance Management Module built with Angular-19 and Angular Material. It allows users to manage services and their associated tasks.

=> Features
List, add, update, and delete services and tasks
JWT-based authentication
UI using Angular Material

=> Setup Instructions
=> Clone the repository and navigate to the folder
=> Install dependencies
npm install

=> Start the development server
ng serve

=> Environment URL(APIBaseUrl)
Please update APIBaseUrl as per your local backend api url (src/environments/environment.ts & src/environments/environment.prod.ts for production build)

=> Credentials
email : admin@maintenance.com
password : Admin@999