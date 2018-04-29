# eManage Development

Following a few information about the project.
If you have any questions, feel free to contact me.

- [eManage Development](#emanage-development)
    - [Projet Folder Structure](#projet-folder-structure)
    - [Backend](#backend)
    - [Frontend](#frontend)

## Projet Folder Structure

----------

```
.
├── eManage.Domain
|   └── ....
├── eManage.Repo
|   └── ....
├── eManage.UI
|   ├── app
|   |    └── ...
|   └── index.html
├── eManage.WebApi
|   └── ....
├── eManage.sln
└── README.MD
```

## Backend

----------
The backend is composed by three different **.Net Core 2.0** projects (available on the **eManage** solution): 

- eManage.Domain
  - This project contains the interface for the ef repository, as well as a "DTO" user object.
- eManage.Repo
  - Implementation of the repository using ef core.*
- eManage.WebApi
  - WebApi project which exposes all the required endpoints.**\
    The URL for the application is configured to be http://localhost:60815/.\
    Once the application starts, the default page will be the [Swagger UI page](https://swagger.io/swagger-ui/).

>\* During the configuration process of the WebApi, the DbContext is set to work with an "in memory" database. **Nothing will persist on disk.**

```csharp
services.AddDbContext<eManage.Repo.eManageContext>(opt =>   opt.UseInMemoryDatabase("neverlandDb"));
```

> \** The API CORS policy allow requests only from http://localhost:8000. If you decided to start the client on another port/domain, this must be changed.

```csharp
services.AddCors(options =>
            {

                options.AddPolicy("allowAll",
                    builder =>
                    {
                        builder.WithOrigins("http://localhost:8000");
                        builder.AllowAnyMethod();
                        builder.AllowAnyHeader();
                    });
            });
```

## Frontend

----------

The client application can be found under the eManage.UI folder.
To start the frontend application, from your command prompt navigate to the folder path and type.

```sh
npm start
```

This will download all the necessary npm packages, and it will make the application available at http://localhost:8000.

> Note: the application is configured to use the endpoints exposed at http://localhost:60815. If you change the server endpoint, this must be changed in the UI app as well.  
To do so, open the **eManage.app.js** and replace the URL in the following line

```js
$apiEndpoint.set("http://localhost:60815/api/");
```

The client already uses a minified file which contains all javascript files in the app. The file is named "eManage.app.min.js" under the "scripts" folder.
If you want to regenerate it, you can just call the default gulp process 

```sh
gulp
```