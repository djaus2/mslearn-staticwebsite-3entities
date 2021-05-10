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
  - Nb: The app uses Scoped services so all users see the same data so please reset teh data if you give the deployed verion a go , when done.

# Links
- Start: The Azure Static Websites tutorial [here](https://docs.microsoft.com/en-us/learn/modules/publish-app-service-static-web-app-api-dotnet/)
- [The Original Official/Microsoft Sample Repository](https://github.com/MicrosoftDocs/mslearn-staticwebapp-dotnet)
- Functionality to be similar to Blazor Apps: [djaus2/EFBlazorBasics](https://github.com/djaus2/EFBlazorBasics) and [djaus2/EFBlazorBasics_Wasm](https://github.com/djaus2/EFBlazorBasics_Wasm) respositories.

# Branches of the Repository
Each is a bookmark in order of this progression.
- See the list [here](http://www.sportronics.com.au/web/Azure_Static_Websites-Multiple_Entities-index.html)
- The main branch is the final version of the app here:[djaus2/mslearn-staticwebsite-3entities](https://github.com/djaus2/mslearn-staticwebsite-3entities)



