TrainingTracker : Project Setup Guide

Welcome to the TrainingTracker project!
This guide explains everything each team member needs to do to get the project running locally, including database setup, 
development settings, and Identity.

-------------------------------------------------------------------------------------------------------------------------



1: Create your local development settings file

- Each developer must create their own appsettings.Development.json (this file is ignored by Git and never pushed).
- In the project root (same folder as appsettings.json),you will see a file named appsettings.Development.json.
- Paste this and replace YOUR_SERVER_NAME_HERE with your SQL Server instance:

{
  "ConnectionStrings": {
    "DefaultConnection": "Server=YOUR_SERVER_NAME_HERE;Database=TrainingTrackerDb;Trusted_Connection=True;TrustServerCertificate=True;MultipleActiveResultSets=true"
  }
}

Examples:

SQL Express:
Server=MY-PC\\SQLEXPRESS;Database=TrainingTrackerDb;...

LocalDB:
Server=(localdb)\\MSSQLLocalDB;Database=TrainingTrackerDb;...

- Do not change Program.cs,it already reads DefaultConnection from the configuration.




2: .gitignore important note

- The appsettings.Development.json file is ignored in .gitignore to prevent conflicts between developers.
- This protects everyone’s:
- Local SQL connection string
- Passwords
- Machine-specific settings




3: Database setup

- Each developer needs to create a local database named TrainingTrackerDB and Identity tables will be automatically created 
  using EF migrations.
- You only need to run one command to create your database: Update-Database




4: How to add new migrations (ONLY when modifying the database)'

- When you make changes to the database schema, you need to create a new migration.
- Use the following command:
- Add-Migration YourMigrationName
- After creating the migration, apply it to your local database using:
- Update-Database




5: Project status

✔ ASP.NET Core Razor Pages installed
✔ Identity configured
✔ SQL Server database created
✔ Local development settings isolated
✔ Ready for team development

