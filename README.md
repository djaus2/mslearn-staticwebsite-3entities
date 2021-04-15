# About this Repository

The starting point was the Azure Static Websites tutorial. The outcome of that was progressively extended so as to implement a number of editable entities 
rather than the one fixed entity. The ultimate aim is to have the app backed by Entity Framework Core with access to an Azure SQL dataabase. The functionality is meant to be similar to that as in two Blazor apps which are available as repositories here. Each step in this "morphing" process has been bookmarked as a separate branch. The main branch is always the latest and is what is deployed as an Azure Static Websites for viewing.

[The deployed app](https://brave-wave-05ed2c51e.azurestaticapps.net/)

# This Version
- This version (this bracnch) implements: 
  - 3 Entities: Activity, Helper and Round. 
    - **_A Helper volunteers for an activity which is for a specific round of athletics competition._**
  - Entities are stored in a C# LocalStorage service.
  - Can add, delete and modify the entities.
  - Can reset the "pseudo" database to the initial entities.
  - Nb: The app uses Scoped services so all users see the same data so please reset teh data if you give teh deployed verion a go , when done.

# Links
- Start: The Azure Static Websites tutorial [here](https://docs.microsoft.com/en-us/learn/modules/publish-app-service-static-web-app-api-dotnet/)
- [The Original Official/Microsoft Sample Repository](https://github.com/MicrosoftDocs/mslearn-staticwebapp-dotnet)
- Functionality to be similar to Blazor Apps: [djaus2/EFBlazorBasics](https://github.com/djaus2/EFBlazorBasics) and [djaus2/EFBlazorBasics_Wasm](https://github.com/djaus2/EFBlazorBasics_Wasm) respositories.

# Branches of the Repository
Each is a bookmark in order of this progression.

- [Completed-tutorial](https://github.com/djaus2/mslearnstaticwebsite/tree/Completed-tutorial)
  - After completing the tutorial
- [Rename-Products-to-Activitys](https://github.com/djaus2/mslearnstaticwebsite/tree/Rename-Products-to-Activitys)
  - Renamed the Products entity as Activitys. Functionality etc. Unchanged otherwise.
- [Activitys-helpers-rounds-Basic](https://github.com/djaus2/mslearnstaticwebsite/tree/Activitys-Helpers-Rounds-Basic)
  - Added Helpers and Round entities as properties to Activitys. Can list Activitys and get Helpers and Rounds on client from that.
- [Add-helper_and-round-apis](https://github.com/djaus2/mslearnstaticwebsite/tree/Add-helper_and-round-apis)
  - Implemented Helper and Round APIs and app pages
- [Tried-Chrissainty-localstorage](https://github.com/djaus2/mslearnstaticwebsite/tree/Tried-Chrissainty-localstorage)
  - This was a dead-end as it uses Javascript which made no sense on the server.
- [Entities-as-a-csharp-local-storage-service](https://github.com/djaus2/mslearnstaticwebsite/tree/Entities-as-a-csharp-local-storage-service)
  - Used the [LocalStorage Nuget Package from Julien Hanssens](https://github.com/hanssens/localstorage) which is C# app-centred storage.
  - Meant to mimic a database: Can Add, delete and Update entities.
- [Can-reset-data](https://github.com/djaus2/mslearnstaticwebsite/tree/Can-reset-data)
- main - This branch



