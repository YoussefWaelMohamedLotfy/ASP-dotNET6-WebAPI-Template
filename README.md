# ASP.NET Core 6 Web API Template

The ready template for the next Up-to-Date Web API Project.

## Features supported

+ Clean Assembly Service Registration
+ Clean Endpoint Structure (Request-EndPoint-Response (**REPR**) Pattern)
  + CRUD Operations with Data Transfer Objects (Commands + Results)
+ AutoMapper
+ OpenAPI (Swagger) Documentation
  + Summarized Endpoints with Descriptions
  + Request and Response Examples
+ application/xml Responses supported
+ Entity Framework Core 6
  + SQL Server Connection
+ Docker Support
  > The Container will throw a "LocalDB is not supported on this Platform" error. You should change the Connection String of SqlServerConnection in *appsettings.json* to a working instance.
+ Asynchronous Repository and Unit of Work Patterns implemented
+ API Keys Authentication (Dummy Implementation)
+ Polly for Retry Pattern
+ Bogus Fake Data Generator for DbContext Seeding
+ Serilog
  + Console Sink
+ API Versioning
  + Header Based
  + Media Type Based
+ Health Checks
  + Entity Framework Core DbContext Check
  + SQL Server Check
  + Redis Cache Check
  + URL Group Check
+ Pagination
+ Caching using Redis
+ Distributed Rate Limiting
  + IP Limiting Rules
  + Client Limiting Rules
+ Fluent Validation Support
+ SignalR Realtime Communication
+ Hangfire for Background Jobs Scheduling
+ Automatic publishing to the internet using [ngrok](https://ngrok.com/) 