# Dotnet-Core-Api-Authentication-with-Anguar-5

## Basic Requirements

   [Asp.Net Core SDK](https://www.microsoft.com/net/learn/get-started/windows/)
   
   Microsoft Sql Server    
   
   
## Run BackEnd
   Clone the repository.
   
   Open terminal in the DotnetWebApiAuthentication repository.
   
   type **dotnet restore** in the terminal to restore any additional packages.
   
   type **dotnet ef database update** in the terminal.
   
   type **dotnet run**.
   
## Run FrontEnd
   Open terminal in the AngularTokenAuthentication repository.
   type **ng serve**.
   
   
## Api list
   * [Post] http://localhost:5000/api/account/register **Register User**
     * Json Data in body exmaple
      ```
      {
        "Email" : "iammonmoy@ooutlook.com",
        "UserName" : "Somthing",
        "Password" : "512345Rrm_",
        "ConfirmPassword" : "512345Xyz_"
      }
      ```
   
   * [Post] http://localhost:5000/api/account/login **User login. Get Token**
     * Json Data in body exmaple
      ```
      {
        "Email" : "iammonmoy@gmail.com",
        "Password" : "512345Xyz_"
      }
      ```
