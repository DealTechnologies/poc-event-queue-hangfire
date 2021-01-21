# Introduction 
Prova de conceito utilizando filas com hangfire como serviço em background

- "SENDGRID_KEY": **"XXX-XXXX-XXXX"**
- "SALT_KEY": **"XXX-XXXX-XXXX"**
- "BASE_URI": **"http://localhost:7071/"**
- "USE_DASHBOARD": **"true"**

# Getting Started

> Set varables into *Solution/workerapi/**appsettings.json***

- ConnectionStrings:DefaultConnection : **<your_sql_connection>**
- Open package management console and run : **update-database**
- Run sln : **dotnet run**
- Use dashboard:  **https://localhost:{PORT}/dashboard**

# Build 
run command: **dotnet build**

# More

- [Dotnet](https://dotnet.microsoft.com/download)
- [Azure Functions](https://docs.microsoft.com/pt-br/azure/azure-functions)
- [Hangfire](https://www.hangfire.io/)
- [EF.Core](https://docs.microsoft.com/pt-br/ef/core/managing-schemas/migrations/?tabs=dotnet-core-cli)
