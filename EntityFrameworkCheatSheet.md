dotnet tool install --global dotnet-ef
dotnet tool update --global dotnet-ef

-- create your template app, project, etc.
-- Add packages to your project
dotnet add package Microsoft.EntityFrameworkCore.Design
dotnet add package Microsoft.EntityFrameworkCore.SlqServer

-- Write your code, create your classes, create the DbContext classes
-- After the above, we can migrate to the database

-- Use the terminal commands below without the '< >' and whatever migration name wanted
dotnet ef migrations add <Migration_Name>
dotnet ef database update <most recent migration OR Target_Migration_Name>
