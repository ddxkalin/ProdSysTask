# ProdSys

ProdSysTask is a project that displays the users in the database in the DevExtreme's data-grid which is implemented with AngularJS.
ProdSys is a modern ERP system that collaborates and exchanges data with software and cloud services. They have customers in most industries.
Together with their customers, they have developed ProdSys to become a system that makes companies all over Norway more profitable.
They strongly focus on development, innovation and new technologies.

The Application is created for the ProdSys ERP system, just to show, how to work with the essentials inside the whole system.

## HomePage
![Screenshot 2023-01-18 at 2 53 01](https://user-images.githubusercontent.com/22754404/213054225-ce431b9c-b11c-4fa0-9a10-115f282cce3b.png)


## Tech-stack
1. AngularJS, TypeScript, DevExtreme.
2. C# (ASP.NET), Dapper ORM, SQL, Xunit.

## Install Packages

Run the command within the project directory to install packages from the project dependencies

```
$ npm install -g @angular/cli
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
```
