Sample design Architecture based on .NET Core REST API and CQRS implementation with raw SQL.
==============================================================


## Give a Star! dear friend:star:

If you like this project, learn or you are using in your soloution, please give me a star. Thanks!

## Description
Sample design Architecture based on .NET Core REST API and CQRS implementation with raw SQL. [CQRS](https://docs.microsoft.com/en-us/azure/architecture/guide/architecture-styles/cqrs) approach and Domain Driven Design.

## Architecture [Clean Architecture](http://blog.cleancoder.com/uncle-bob/2012/08/13/the-clean-architecture.html)


## CQRS

Read Model - executing raw SQL scripts on database views objects (using [Dapper](https://github.com/StackExchange/Dapper)).

Write Model - Domain Driven Design approach (using Entity Framework Core).

Commands/Queries/Domain Events handling using [MediatR](https://github.com/jbogard/MediatR) library.


## Validation
Data validation using [FluentValidation](https://github.com/JeremySkinner/FluentValidation)


## Caching
Using Cache-Aside pattern and in-memory cache of .net cache.

## Integration
Outbox Pattern implementation using [Quartz.NET](https://github.com/quartznet/quartznet)



## How to run application
1. no need to run migration only run sql scripts
2. Execute InitializeDatabase.sql script.
2. Set connection string (appsettings.json).
3. Run!

## How to run Integration Tests
1. no need to run migration only run sql scripts
2. Execute InitializeDatabase.sql script.
3. Set connection string using environment variable named `ASPNETCORE_IntegrationTest_ConnectionString`
- Run tests from project [src/Tests/CQRSInfra.IntegrationTest](src/Tests/CQRSInfra.IntegrationTest)
