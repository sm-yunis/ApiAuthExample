# A Very Basis JWT API Authentication using ASP.NET Core 5

## The app runs on http://localhost:5000 on default, use /Properties/launchSettings.json to change it.

- To authenticate use the `/signin/{secretKey}` path where secretKey is route parameter use "super" to authenticate
- The index page is not protected
- The `/auth` path is protected and you need to add JWT token to the authentication header 