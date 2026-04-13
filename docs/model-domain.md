# Domain Model

## Core Entities

1. Patient
2. Specialist
3. Appointment
4. Service
5. AvailabilitySlot
6. AppointmentNote
7. Room
8. Specialization
9. AppointmentRecommendation
10. SpecialistService

## Entity Relationships

- Patient 1:N Appointment
- Specialist 1:N Appointment
- Specialization 1:N Specialist
- Specialist 1:N AvailabilitySlot
- Room 1:N Appointment
- Appointment 1:1 AppointmentNote
- Appointment 1:1 AppointmentRecommendation
- AvailabilitySlot 1:0..1 Appointment
- Specialist 1:N SpecialistService
- Service 1:N SpecialistService
- Specialist M:N Service through SpecialistService

## Initial Implementation Scope

- Patient
- Specialist
- Service
- AvailabilitySlot
- Appointment

## Entity Definitions 

### Patient
- Id (int)
- LastName (string)
- FirstName (string)
- Email (string)
- PhoneNumber (string)
- Address (string)
- CreatedAt (DateTime)
- IsActive (bool)

### Service
- Id (int)
- Name (string)
- Description (string)
- DurationInMinutes (int)
- Price (decimal)
- CreatedAt (DateTime)
- IsActive (bool)

### Specialist
- Id (int)
- LastName (string)
- FirstName (string)
- Email (string)
- PhoneNumber (string)
- SpecializationId (int)
- Bio (string)
- CreatedAt (DateTime)
- IsActive (bool)

### AvailabilitySlot
- Id (int)
- SpecialistId (int)
- StartTime (DateTime)
- EndTime (DateTime)
- IsAvailable (bool)

### Appointment
- Id (int)
- PatientId (int)
- SpecialistId (int)
- ServiceId (int)
- RoomId (int?)
- AvailabilitySlotId (int)
- Form (enum)
- Status (enum)
- CreatedAt (DateTime)

