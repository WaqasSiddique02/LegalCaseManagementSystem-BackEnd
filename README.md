# FrontEnd Link
[GitHub Repository](https://github.com/WaqasSiddique02/LegalCaseManagementSystem-FrontEnd)

## Title of the Project
**The Legals – Legal Firm Management Software**

## Description
The Legals is a comprehensive Legal Case Management System designed to streamline the operations of a legal firm. It enables efficient handling of cases, clients, tasks, and documentation. Developed using **Blazor Server** for the frontend and **ASP.NET 8** for the backend, the system offers **role-based access** to three types of users: **Admin, Lawyer, and Client**. The system ensures a secure, modern interface for managing legal data and interactions.

## Goals/Objectives
- Provide a centralized platform for legal firms to manage cases, hearings, documents, invoices, and client communications.
- Offer role-based access control to streamline operations for Admins, Lawyers, and Clients.
- Enhance transparency, reduce manual effort, and digitize the legal workflow.
- Implement secure, scalable, and responsive web technology for modern legal practices.

### Technologies Used
- **Frontend**: Blazor Server  
- **Backend**: ASP.NET 8, RESTful APIs  
- **Database**: Microsoft SQL Server, Entity Framework Core  
- **Authentication**: JWT (JSON Web Tokens)  
- **API Documentation**: Swagger

## 2. Problem Statement
Legal firms traditionally rely on paper records and manual communication to manage cases, clients, and hearings. This method is prone to errors, delays, and inefficiencies, especially in managing deadlines, documents, and financial records. Without a centralized system, coordination between lawyers, clients, and administrators becomes fragmented and time-consuming.

## 3. Proposed Solution
The Legals offers a digital solution by integrating all legal management activities into a single, robust web platform. With distinct access roles and user-friendly interfaces, it allows users to manage and track cases, upload and access legal documents, handle client billing, and monitor legal proceedings in real-time. Role-based dashboards ensure that each user sees the information relevant to their responsibilities, thereby improving productivity, accountability, and client satisfaction.

## 4. Modules and Functionality Details

### Admin Module
- Manage Users (Add/Edit/Delete lawyers and clients)
- Create, update, and delete legal cases
- Schedule and manage hearings and tasks
- Upload and manage legal documents
- Generate and manage invoices
- Monitor system-wide activity and logs

### Lawyer Module
- View and manage assigned legal cases
- Access hearing schedules and task lists
- Upload notes or case updates
- View and download invoices
- Access dashboard for recent activities

### Client Module
- Register and log in securely
- View personal case history and current cases
- Access legal documents
- View and pay invoices online
- View hearing schedules and case status

## 5. System Architecture

### Components:
- **Frontend**: Blazor Server (C# Razor Components)
- **Backend**: ASP.NET 8 RESTful APIs
- **Database**: MS SQL Server
- **Authentication**: JWT (Role-based access)
- **API Documentation**: Swagger

### Component Interaction:
- Blazor Server sends HTTP requests to RESTful APIs.
- Backend processes requests, communicates with the database using Entity Framework Core.
- Backend returns secured, role-filtered data to the frontend.
- Authentication and Authorization handled via JWT.

## 6. Features

### Frontend Features
- Responsive UI with role-based dashboards
- Login and registration pages
- Case tracking views
- Hearing schedules
- Document access and invoice payment for clients

### Backend Services
- RESTful API endpoints for CRUD operations on cases, users, hearings, tasks, documents, and invoices
- Authentication using JWT
- Role-based authorization
- DTOs for data consistency

### Database-Level Features
- Entity relationships (Cases ↔ Users ↔ Hearings/Documents/Invoices)
- Entity Framework Core with Code-First approach
- Relationships managed via foreign keys

## 7. Frontend Documentation

### Framework
- Blazor Server (.NET)

### Structure
- **Pages/**: Contains role-specific UI pages (Admin, Lawyer, Client)
- **Shared/**: Layouts and components shared across roles
- **Services/**: Handles API requests
- **wwwroot/**: Static assets

### Important Pages
- `Login.razor`, `Register.razor`
- `AdminDashboard.razor`, `LawyerDashboard.razor`, `ClientDashboard.razor`

### API Integration
- Frontend calls RESTful APIs using injected HTTP services

## 8. Backend Documentation

### Framework
- ASP.NET 8 Web API

### Structure
- **Controllers/**: API endpoints
- **Services/**: Business logic
- **DTOs/**: Data transfer objects for validation and security
- **Models/**: EF Core entity models
- **Middleware/**: JWT authentication and error handling

### Authentication
- JWT Tokens with role-based claims

### Documentation
- Swagger UI available at `/swagger`

## 9. Database Design

### ERD (Entity Relationship Diagram)
**Entities**: Users, Lawyer, Client, Cases, Hearings, Tasks, Documents, Invoices, CaseTasks

### ORM
- Entity Framework Core with Code-First migrations

## 10. Installation & Setup

### Prerequisites
- .NET SDK 8
- MS SQL Server

### Setup Steps
1. Clone the repository from GitHub
2. Configure `appsettings.json` with your DB connection string
3. Run migrations using EF Core CLI
4. Run backend via Visual Studio or CLI (`dotnet run`)
5. Run frontend Blazor Server project
6. Access Swagger at `/swagger` for API documentation
