# Use Cases

## Actors

### Patient
A person using the system to browse specialists, view available services, book appointments, and check upcoming visits.

### Specialist
A clinic professional who provides services, views assigned appointments, and creates visit-related notes and recommendations.

### Administrative Staff
A system user responsible for managing selected clinic data and supporting the organizational workflow of the clinic.

---

## Core Use Cases

### Patient Use Cases
- Browse specialists
- View specialist profiles
- View available services
- View specialist availability
- Book appointment
- View upcoming appointments
- View past appointments
- Cancel appointment

### Specialist Use Cases
- View assigned appointments
- View personal schedule
- Add appointment note
- Add appointment recommendation

### Administrative Staff Use Cases
- Manage specialists
- Manage services
- Manage rooms
- Manage selected clinic data

---

## Detailed Use Case: Book Appointment

### Name
Book Appointment

### Primary Actor
Patient

### Goal
The patient wants to schedule a new appointment with a selected specialist.

### Preconditions
- The patient exists in the system.
- The specialist exists in the system.
- The specialist has at least one available time slot.
- The selected service is assigned to the selected specialist.

### Main Success Scenario
1. The patient opens the list of specialists.
2. The patient selects a specialist.
3. The system displays specialist details and available services.
4. The patient selects a service.
5. The system displays available time slots for the selected specialist and service.
6. The patient selects one available slot.
7. The system validates the slot availability.
8. The system creates a new appointment.
9. The selected availability slot is marked as unavailable.
10. The system displays appointment confirmation.

### Extensions
- **5a. No available slots**  
  The system informs the patient that no available slots exist for the selected specialist.

- **7a. Selected slot is no longer available**  
  The system informs the patient that the slot has already been booked and asks to choose another one.

- **8a. Appointment creation fails**  
  The system displays an error message and the booking process is cancelled.

### Postconditions
- A new appointment is created in the system.
- The selected availability slot is no longer available.
- The appointment is visible in the patient's appointment list.

---

## Detailed Use Case: View Specialist Availability

### Name
View Specialist Availability

### Primary Actor
Patient

### Goal
The patient wants to check available appointment slots for a selected specialist.

### Preconditions
- The specialist exists in the system.
- The specialist has availability slots defined in the system.

### Main Success Scenario
1. The patient opens the list of specialists.
2. The patient selects a specialist.
3. The system loads the specialist profile.
4. The system displays available time slots for the specialist.
5. The patient reviews the available appointment options.

### Extensions
- **4a. No availability found**  
  The system informs the patient that there are currently no available slots.

### Postconditions
- The patient can see the specialist's current availability.
- The patient may continue to the appointment booking process.

---

## Detailed Use Case: Add Appointment Note

### Name
Add Appointment Note

### Primary Actor
Specialist

### Goal
The specialist wants to create an internal note related to a completed or ongoing appointment.

### Preconditions
- The specialist exists in the system.
- The appointment exists in the system.
- The appointment is assigned to the specialist.

### Main Success Scenario
1. The specialist opens the list of assigned appointments.
2. The specialist selects an appointment.
3. The system displays appointment details.
4. The specialist enters the note content.
5. The system saves the note and links it to the appointment.

### Extensions
- **4a. Note content is empty**  
  The system informs the specialist that the note cannot be empty.

- **5a. Saving fails**  
  The system displays an error message.

### Postconditions
- The appointment note is saved in the system.
- The note is linked to the selected appointment.

---

## Detailed Use Case: Add Appointment Recommendation

### Name
Add Appointment Recommendation

### Primary Actor
Specialist

### Goal
The specialist wants to save recommendations for the patient after the appointment.

### Preconditions
- The specialist exists in the system.
- The appointment exists in the system.
- The appointment is assigned to the specialist.

### Main Success Scenario
1. The specialist opens the appointment details.
2. The specialist enters recommendation content for the patient.
3. The system saves the recommendation and links it to the appointment.

### Extensions
- **2a. Recommendation content is empty**  
  The system informs the specialist that the recommendation cannot be empty.

- **3a. Saving fails**  
  The system displays an error message.

### Postconditions
- The recommendation is saved in the system.
- The recommendation is linked to the selected appointment.