✈️ AirlineBookingSystem

A modular, microservice-based airline booking system built as a demo portfolio project using modern .NET technologies and messaging patterns. The system showcases user authentication, CQRS and repository patterns, event-driven messaging, and clean architectural practices.
🛠 Tech Stack

    .NET 9

    Entity Framework Core

    ASP.NET Identity (JWT-based authentication)

    SQLite (local development and testing)

    MediatR (CQRS command/query dispatching)

    MassTransit (message transport abstraction)

    RabbitMQ (message broker - queues and streams)

🔐 User Authentication

The system uses ASP.NET Core Identity for authentication and authorization:

    Two user roles:

        SystemUser

        Administrator

    All protected endpoints require a valid JWT token with the appropriate role.

    Role-based access control is enforced via ASP.NET's built-in authorization mechanisms.

🗃 Database

    SQLite is used for simplicity and easy local testing.

    Entity Framework Core manages data access and schema definitions.

    Pre-seeded data is included for testing and demo purposes.

    Database schema and model updates are handled using EF Core migrations.

🧱 Architectural Patterns
✅ CQRS Pattern

    Commands and Queries are separated using MediatR.

    Clean separation between write and read concerns.

    All command/query handlers encapsulate business logic, keeping REST API endpoints lightweight.

🗃 Repository Pattern

    Data access is abstracted via interface-based generic repositories.

    Each repository can be extended for model-specific queries.

    Encourages decoupled, testable, and scalable data layers.

🧩 API Structure & Data Flow

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

📦 Messaging & Microservice Coordination

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

⚙️ Best Practices Followed

    Separation of Concerns: Commands/Queries encapsulate logic; Controllers are lean

    Dependency Injection: Services depend on abstractions via interfaces

    Microservice Architecture: Self-contained modules for each core domain

    Event-driven Design: Ensures scalability and decoupling between services

❗ Global Error Handling & Logging

While not every scenario is fully handled (as expected from a demo), the project includes:

    A global error controller for catching uncaught exceptions

    An internal stream publisher built with MediatR and RabbitMQ Stream

    Persistent log events are published into a dedicated error stream

This enables tracing and debugging of runtime issues in a centralized way.
📌 Notes

    This project is a portfolio demonstration, not a production-ready system. It showcases advanced patterns and architecture in .NET-based distributed systems with a focus on clean design and messaging between microservices.
