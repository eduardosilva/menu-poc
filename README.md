# Menu PoC

## Getting started

### Install dependencies

Use the `install-packages.bat` to install dependencies or you can install individually:

```bash
// front
cd front\ & npm i
```

```bash
// back
cd back\MenuPocApi & dotnet restore
```

### Run

```bash
// front
cd front\ & npm start
```

```bash
// back
cd back\MenuPocApi & dotnet run
```

### Tests

```bash
// front
cd front\ & npm test
```

```bash
// back
cd back\MenuPocApiTests\ & dotnet test
```

### Urls

* (web): http://localhost:4200;
* (api): http://localhost:5000
* (swagger): http://localhost:5000/swagger/index.html

### Front-Stack

* [Angular](https://angular.io/)
* [NG-Zorro](https://ng.ant.design/docs/introduce/en)

### Patterns

Some useful patterns & practices using in this project

[SASS 7-](https://sass-guidelin.es/#architecture)
[Service As Facade](https://medium.com/angular-in-depth/angular-you-may-not-need-ngrx-e80546cc56ee)

## Back

### Back-Stack

* [ASP.Net API Core](https://docs.microsoft.com/en-us/aspnet/core/web-api/?view=aspnetcore-3.1)
* [Swagger](https://swagger.io/)
* [XUnit](https://xunit.net/)
* [Moq](https://github.com/moq/moq4)
