# NotTheSilkRoad
This is the repository for P3 Team 2.


# Description:
This application is a basic online marketplace where users can create accounts and purchase products. The platform will dynamically update product availability as items are sold, and offers search functionality to help users find specific items. Each product listing can be clicked to view detailed information and images, and includes a "Buy Now" button for easy purchase.

# While running the links to the Deployed frontend and api are as follows:
API: notthesilkroadapi.azurewebsites.net

FrontEnd: notthesilkroadfront.azurewebsites.net

# For running on local machines: 
Ensure you are in the "FrontEnd-DevBranch" and you must have the api running from within the API directory of the Dev branch via 'dotnet run' and then once the API is running, you may open another terminal and proceed to the front-end directory within the upper Frontend directory within Dev and run 'npm install' to gather your dependencies, then 'npm run dev' and the program should spin up and work as intended.

# .ENV Setup:
> Create a .env file within the ./FrontEnd/front-end/ folder and add these lines to it:

`
#API_URL=https://notthesilkroadapi.azurewebsites.net
NEXT_PUBLIC_API_URL=http://localhost:5244
`

> This file is necessary to easily connect to your database ports and change it as needed.

> The first line is commented out as it will change based on what server you are hosting your database and application on.

> The second line is the local host database port. This may change depending on what you are using for your database. This project was built using a SQL server.

# Connection String Setup:

> Create a `connectionstring.env` file and add it to the `API` folder. Then add these lines to it:

` Server=localhost;User=[YourDatabaseUsername];Password=[YourPassword];Database=[DatabaseName];TrustServerCertificate=true; `

> This connection string is for a local host, but you can change the server and other information based on if you are using a server host such as Azure. When adding your personal information for the connection string, do not include the `[]`.

# appsettings.json Setup

You may also need to setup your appsettings.json file.

Create a file called `appsettings.json` and add it to the `API` folder, the same as the `connectionstring`.env file.

Add these lines to the `appsettings.json` file:

` {
    "Logging": {
      "LogLevel": {
        "Default": "Information",
        "Microsoft.AspNetCore": "Warning"
      }
    },
    //"ConnectionString": "Server=tcp:not-the-silk-road-server.database.windows.net,1433;Initial Catalog=NotTheSilkRoad;Persist Security Info=False;User ID=[serveradmin];Password=[yourpassword];MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;",
    "ConnectionString": "Server=localhost;User=[YourDatabaseUsername];Password=[YourPassword];Database=[DatabaseName];TrustServerCertificate=true;",
    "AllowedHosts": "*"
  }
  `

  > Then change the values based on your personal setup for your database. Be it local or server side.

