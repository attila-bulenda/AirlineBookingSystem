## ✈️ AirlineBookingSystem

A modular, microservice-based airline booking system built as a demo portfolio project using modern .NET technologies and messaging patterns. The system showcases user authentication, CQRS and repository patterns, event-driven messaging, and clean architectural practices.
🛠 Tech Stack

    .NET 9

    Entity Framework Core

    ASP.NET Identity (JWT-based authentication)

    SQLite (local development and testing)

    MediatR (CQRS command/query dispatching)

    MassTransit (message transport abstraction)

    RabbitMQ (message broker - queues and streams)

## 🔐 User Authentication

The system uses ASP.NET Core Identity for authentication and authorization:

    Two user roles:

        SystemUser

        Administrator

    All protected endpoints require a valid JWT token with the appropriate role.

    Role-based access control is enforced via ASP.NET's built-in authorization mechanisms.

## 🗃 Database

    SQLite is used for simplicity and easy local testing.

    Entity Framework Core manages data access and schema definitions.

    Pre-seeded data is included for testing and demo purposes.

    Database schema and model updates are handled using EF Core migrations.

## 🧱 Architectural Patterns
✅ CQRS Pattern

    Commands and Queries are separated using MediatR.

    Clean separation between write and read concerns.

    All command/query handlers encapsulate business logic, keeping REST API endpoints lightweight.

🗃 Repository Pattern

    Data access is abstracted via interface-based generic repositories.

    Each repository can be extended for model-specific queries.

    Encourages decoupled, testable, and scalable data layers.

## 🧩 API Structure & Data Flow

The system separates responsibilities between services with clearly defined APIs and access roles. The main flows are visualized below.

Services Overview:
User API

    No Auth: Registration, Login

    With Auth: View/update own profile, delete account

Admin API

    No Auth: Login

    With Auth: Manage users, update profiles, delete users

Flights API

    Public: View flights

    Admin: Manage flight schedules

Bookings API

    Users: Book, cancel, or modify flights

    Admin: View all bookings

Invoicing API

    Admin/Automation: Generate and manage invoices
    
<img width="1021" height="717" alt="Dataflow diagram" src="https://github.com/user-attachments/assets/e95ddb64-2827-41aa-90b8-e23b6910b6fb" />

## 📦 Messaging & Microservice Coordination

The architecture follows an event-driven approach powered by RabbitMQ, MassTransit, and MediatR to ensure clean microservice communication.

Event Flows:
📨 Publish–Subscribe

    One service publishes an event

    Notification service listens and sends alerts

🔁 Chained Events (Multi-Service Flow)

    Booking API emits a flight booked event

    Invoicing API picks it up and creates an invoice

    Notification service listens to the invoice creation and notifies the user

<img width="1070" height="757" alt="Messaging ecosystem" src="https://github.com/user-attachments/assets/a9be7b48-3d29-4ef7-950f-27a2b3842d99" />

## ⚙️ Best Practices Followed

    Separation of Concerns: Commands/Queries encapsulate logic; Controllers are lean

    Dependency Injection: Services depend on abstractions via interfaces

    Microservice Architecture: Self-contained modules for each core domain

    Event-driven Design: Ensures scalability and decoupling between services

## ❗ Global Error Handling & Logging

While not every scenario is fully handled (as expected from a demo), the project includes:

    A global error controller for catching uncaught exceptions

    An internal stream publisher built with MediatR and RabbitMQ Stream

    Persistent log events are published into a dedicated error stream

This enables tracing and debugging of runtime issues in a centralized way.

## 📬 Postman Collection

A full-featured Postman collection is included in the project for testing and interacting with all APIs in the AirlineBookingSystem — including users, flights, bookings, and invoices.
▶️ How to Use

    Import the Collection in Postman

        Download the collection file:
        📥 postman_collection.json

        In Postman:
        File → Import → Select the .json file
        Or drag and drop it into the Postman app.

    Authentication Setup

        Use the Login user or Login admin request to retrieve a JWT token.

        Set the token as a Bearer Token in the Authorization tab of each request, or store it as a variable named jwt_token in a Postman environment.

    Environment (Optional)
    You can configure a Postman environment to simplify reusing the API base URLs and token.

Explore the APIs

The collection includes ready-to-run examples for:

    🧑 Users API (register, login, profile, deletion)

    ✈️ Flights API (view, create, update, delete flights)

    📘 Bookings API (CRUD operations)

    💸 Invoices API (create and retrieve invoices)

## 🚀 Running the Project

To run the full system in Visual Studio:

1. Open the solution in Visual Studio 2022.
2. Go to `Configure startup projects` → `Configure startup projects`
<img width="1230" height="1036" alt="image" src="https://github.com/user-attachments/assets/6f99431d-07a8-4728-b779-7739c2862ed1" />
3. Select **Multiple startup projects**.
4. Set the following projects to `Start`:

   - AirlineBookingSystem.Users.API  
   - AirlineBookingSystem.Notifications.API  
   - AirlineBookingSystem.Flights.API  
   - AirlineBookingSystem.Invoices.API  
   - AirlineBookingSystem.Global.ErrorHandlingService  
<img width="2898" height="1356" alt="image" src="https://github.com/user-attachments/assets/c7fb9fca-3113-4578-bdfd-b77e75fd1166" />

All other projects can be set to `None`.

## 📌 Notes

This project is a portfolio demonstration, not a production-ready system. It showcases advanced patterns and architecture in .NET-based distributed systems with a focus on clean design and messaging between microservices.
