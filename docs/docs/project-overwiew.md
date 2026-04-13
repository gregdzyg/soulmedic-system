# SoulMedic System

## 1. Project description

SoulMedic is a medical management system designed to support and streamline the workflow of a mental health clinic.

The system provides a backend API where all domain-related business logic is implemented and executed. This API can be consumed by multiple client applications.

Initially, the system is designed to be used with a mobile client built using React Native. However, the architecture allows for future expansion and integration with additional clients, such as web applications.

## 2. Problem statement

Without a dedicated system, traditional mental health clinics often struggle with managing patient data, staff information, and appointment schedules.

These processes are typically handled manually or through disconnected tools, which can lead to errors, lack of transparency, and chaotic scheduling.

Digitalizing appointment management and patient handling helps centralize the workflow, improve organization, and reduce scheduling conflicts.

## 3. Target users

The SoulMedic system is intended to support multiple user roles within a mental health clinic:

- **Patients** – the primary users of the first mobile version, responsible for browsing specialists and scheduling appointments.

- **Specialists** – future or partially supported users who may manage visits, review patient information, and create visit-related notes.

- **Administrative staff** – users responsible for managing clinic data and organizational processes as part of the broader system ecosystem.

## 4. Core features

The initial version of the system focuses on patient-oriented features:

- Browsing available specialists and their profiles
- Viewing available services and therapies
- Scheduling appointments by selecting date, time, and specialist
- Viewing upcoming and past appointments
- Tracking appointment status (e.g., scheduled, completed, canceled)

Additionally, selected features for specialists may be introduced:

- Viewing their schedule and assigned appointments
- Managing visit-related information (e.g., notes – future scope)

## 5. Project scope (MVP)

The first version of the project focuses on the core appointment workflow of the clinic.

The MVP will include:

- a backend API for managing the main domain entities related to appointments, specialists, patients, and services
- basic patient-oriented mobile features, such as browsing specialists, viewing services, booking appointments, and checking appointment status
- selected specialist-oriented features, such as viewing assigned appointments and schedule
- core CRUD operations for the most important entities required to support the appointment process

The MVP does not include full administrative or back-office functionality, which may be introduced in future versions of the system.

## 6. Technology stack

The system is built using the following technologies:

- **.NET Web API** – backend framework
- **Entity Framework Core** – data access layer
- **SQL Server** – relational database
- **Docker** – containerized database environment
- **MediatR** – implementation of CQRS pattern
- **Mapster** – object mapping between entities and DTOs
- **React Native** – mobile application framework
- **TypeScript** – strongly typed JavaScript for mobile client

## 7. Architecture approach

The system follows an API-first architecture, where the backend is designed as an independent layer responsible for all business logic and data management. The API is intended to be consumed by different client applications, starting with a mobile client.

The backend is structured using the CQRS (Command Query Responsibility Segregation) pattern, which separates read and write operations to improve clarity, scalability, and maintainability.

A feature-based structure is applied, organizing the code around business functionalities rather than technical layers. This approach improves modularity and makes the system easier to extend.

The first client of the system is a mobile application (mobile-first approach), designed primarily for patients and selected specialist workflows.

The architecture is designed with future expansion in mind, allowing integration with additional clients such as web applications or administrative panels.

## 8. Future development

The system is designed to be extended in future iterations. Planned improvements include:

- **Web client application** – a browser-based interface for patients and administrative staff, enabling full access to system functionality

- **Authentication and authorization** – user accounts, role-based access control, and secure login mechanisms

- **Payment integration** – support for online payments related to appointment booking and services

- **Notifications system** – reminders and updates for appointments (e.g., push notifications or email alerts)