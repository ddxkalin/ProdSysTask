# ProdSys

ProdSys is a project that displays the users in the DevExtreme's data-grid and is implemented with AngularJS.
The Application is created for the ProdSys ERP system, just to show how to work with the essentials inside the whole system.

## Tech-stack
1. AngularJS, TypeScript, DevExtreme.
2. C# (ASP.NET), Dapper ORM, SQL.

## Install Packages

Run the command within the project directory to install packages from the project dependencies

```
$ cd ../ProdSys
$ ng install
```

## Project Setup and Execution

### Start the back-end implementation

```
$ cd ../ProdSys/API
$ dotnet-restore
$ dotnet run
```

### Start the front-end implementation

In the 'client-app' project directory, you can run the React app:

```
$ cd ProdSys\client-app
$ ng server --o
```.

