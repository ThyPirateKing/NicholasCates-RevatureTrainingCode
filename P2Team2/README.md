## 1.) First Delete Migrations Folder in the PfProj folder
## 2.) Configure your docker container server from Microsoft SQL. Run this terminal command: `docker run -e "ACCEPT_EULA=Y" -e "MSSQL_SA_PASSWORD=YourPasswordGoesHere" -e "MSSQL_PID=Express" -p 1433:1433 -d mcr.microsoft.com/mssql/server:2022-latest`
## 3.) Configure your connection string in your appsettings.json file
## 4.) Then Perform a database migration inside of the PfProj folder by running the code: `dotnet ef migrations add InitialMigration`. Then update the database by running this in terminal: `dotnet ef database update`.
## 5.) Run the terminal command `dotnet run` inside PfProj folder
## 6.) Open the Class.html file in the folders
