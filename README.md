# MyMvcApp-Contact-Databse-Application

Ahoy matey! Welcome aboard the MyMvcApp-Contact-Database-Application!

```
           ___
         _/`.-'`.
  _      '  )    \
 /_)_.-..--'/     ;
  /        (      |
 |          `-._  |
 |    .-'      _`.| 
 \   (        (_.' 
  \   `._.-._.'   
   `-._  _.'      
       ``         
   _.._   _.._ 
 .'    `Y'    '.
(  O )     ( O  )
 )     .-.     (
(     (   )     )
 `.    `-'    .'
   `-.___..-'
      /   \
     /     \
    /_/ \_\
   /_/   \_\
  PIRATE
```

## What be this?

This here be a web application fer keepin’ track o’ yer contacts, built with the mighty powers o’ MVC. Store yer mateys’ names, numbers, and more, all in one treasure chest!

## How to set sail

1. Clone this here repo to yer ship (computer).
2. Hoist the sails with yer favorite IDE.
3. Run the app and start addin’ yer crew!

## Features

- Add, edit, and delete yer contacts
- Search fer a matey by name
- Keep yer contact list safe from scallywags

## Deployin’ to Azure with GitHub Actions

Want to hoist yer app to the Azure cloud? Here’s how to deploy with GitHub Actions:

1. **Fork or clone this repo.**
2. **Create an Azure Resource Group** (if ye don’t have one):
   ```sh
   az group create --name <YourResourceGroup> --location <AzureRegion>
   ```
3. **Create an Azure Service Principal** and save the output as a GitHub secret named `AZURE_CREDENTIALS`:
   ```sh
   az ad sp create-for-rbac --name "github-actions-deploy" --sdk-auth --role contributor --scopes /subscriptions/<SUBSCRIPTION_ID>/resourceGroups/<YourResourceGroup>
   ```
4. **Edit the workflow file** at `.github/workflows/azure-deploy.yml` and set:
   - `AZURE_RESOURCE_GROUP` to your resource group name
   - `AZURE_WEBAPP_NAME` to your desired web app name (should match the ARM template)
   - `AZURE_REGION` to your Azure region (e.g., eastus)
5. **Push your changes to the `main` branch.**
6. **GitHub Actions will automatically:**
   - Deploy the ARM template in `deploy/deploy.json` to create the Azure resources
   - Build and publish the app to Azure App Service

Once the workflow completes, your app will be live at:

```
https://<your-web-app-name>.azurewebsites.net
```

## Contributin’

Spotted a bug or got an idea? Raise yer anchor and open an issue or pull request!

Fair winds and happy codin’, ye salty dog!

