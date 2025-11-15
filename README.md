
---

# SchoolProject — Clean Architecture (ASP.NET Core Web API)

![.NET](https://img.shields.io/badge/.NET-8.0-purple?style=for-the-badge)
![Clean Architecture](https://img.shields.io/badge/Architecture-CleanArchitecture-blue?style=for-the-badge)
![xUnit](https://img.shields.io/badge/Testing-xUnit-brightgreen?style=for-the-badge)
![License](https://img.shields.io/badge/License-MIT-orange?style=for-the-badge)

This project is a School Management System built using **ASP.NET Core Web API** and designed following **Clean Architecture** principles.
It uses **Entity Framework Core (Code First)** and includes a full set of backend capabilities suitable for production-level systems.

---

## Table of Contents

* [Features and Architecture Overview](#features-and-architecture-overview)
* [Project Structure](#project-structure)
* [Tech Stack](#tech-stack)
* [Detailed Features](#detailed-features)
* [Unit Testing](#unit-testing)

---

## Features and Architecture Overview

### 1. Architectural Patterns

* Clean Architecture
* CQRS (Command Query Responsibility Segregation)
* Generic Repository Pattern

### 2. API Capabilities

* CRUD endpoints
* Pagination
* CORS support
* Localization for data and responses

### 3. Data and Validation

* FluentValidation
* Data Annotation validation
* Fluent API configurations
* Database operations via endpoints:

  * Views
  * Stored Procedures
  * Functions

### 4. Security

* ASP.NET Core Identity
* JWT Authentication
* Role-based and claims-based authorization
* Swagger with full authentication support

### 5. Services

* Email sending service
* Image upload service

### 6. Middleware and Filters

* Custom exception handling filters
* Request and response filters

### 7. Logging

* Centralized logging system

### 8. Unit Testing

* xUnit testing framework integrated

---

## Project Structure

```
SchoolProject
│
├── Application
│   ├── Features (CQRS: Commands & Queries)
│   ├── Interfaces
│   ├── Validations
│   └── DTOs
│
├── Domain
│   ├── Entities
│   └── Enums
│
├── Infrastructure
│   ├── Identity
│   ├── Persistence (EF Core, Repositories)
│   ├── Services (Email, Upload)
│   └── Logging
│
└── API
    ├── Controllers
    ├── Filters
    ├── Configurations
    └── Middlewares
```

---

## Tech Stack

| Category       | Technologies                      |
| -------------- | --------------------------------- |
| Framework      | ASP.NET Core Web API              |
| Architecture   | Clean Architecture, CQRS          |
| Database       | SQL Server / EF Core (Code First) |
| Authentication | Identity, JWT                     |
| Validation     | FluentValidation                  |
| Testing        | xUnit                             |
| Documentation  | Swagger / OpenAPI                 |

---

## Detailed Features

* Full structuring using Clean Architecture and CQRS
* Entity validation using both Data Annotations and Fluent API
* Fully integrated JWT authentication and Swagger security
* Authorization using roles and claims
* Support for database Views, Stored Procedures, and Functions through endpoints
* Localized data, messages, and responses
* Services for sending emails and uploading images
* Custom filters for exception handling and logging

---

## Unit Testing

The project includes **xUnit** tests to validate:

* Controller logic
* Business logic
* Validation rules
* Repository interactions

---
