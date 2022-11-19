# Readme File

## **PLUGINS**

> - `Name: C# Id: ms-dotnettools.csharp Description: C# for Visual Studio Code (powered by OmniSharp). Version: 1.25.0 Publisher: Microsoft VS Marketplace Link: https://marketplace.visualstudio.com/items?itemName=ms-dotnettools.csharp`
> - `Name: C# Extensions Id: kreativ-software.csharpextensions Description: C# IDE Extensions for VSCode Version: 1.7.3 Publisher: JosKreativ VS Marketplace Link: https://marketplace.visualstudio.com/items?itemName=kreativ-software.csharpextensions`
> - `patcx.vscode-nuget-gallery`

## BUILD

> - `dotnet build`

> - `dotnet run --project WebStore.Web/WebStore.Web.csproj` -> front

### **EFC RELATIONS**

> - Its Important in `1:M` to add `ICollection<Example> {get; set;}`

```
// Migrations in DAL
dotnet ef  --project /Users/akjj004/Proj/Zaawansowane_Programowanie_Internetowe_N/WebStore.DAL/ --startup-project /Users/akjj004/Proj/Zaawansowane_Programowanie_Internetowe_N/WebStore.Web/ migrations add Inital
// UPDATE
dotnet ef database update --project ./WebStore.DAL/  --startup-project ./WebStore.Web/
// REMOVE
dotnet ef  --project /Users/akjj004/Proj/Zaawansowane_Programowanie_Internetowe_N/WebStore.DAL/ --startup-project /Users/akjj004/Proj/Zaawansowane_Programowanie_Internetowe_N/WebStore.Web/ migrations remove
```

## IMPRT

WHEN UPDATE DATABASE TARGET MIGRATION ADD LAST ONE NEVER DELETE USED DATABASE ON UPDATE


## Docker config

docker pull mcr.microsoft.com/azure-sql-edge

docker run -e "ACCEPT_EULA=1" -e "MSSQL_SA_PASSWORD=MyPass@word" -e "MSSQL_PID=Developer" -e "MSSQL_USER=SA" -p 1433:1433 -d --name=sql mcr.microsoft.com/azure-sql-edge

azure data studio

