// src/app/models/appointment.model.ts
export interface Appointment {
  id: number;                    // Unique identifier for the appointment (if applicable)
  userId: number;                // Foreign key to associate with a user (patient)
  providerId: number;            // Foreign key to associate with a healthcare provider
  appointmentDate: Date;         // Date and time of the appointment
  appointmentType: string;       // Type of the appointment (e.g., "Consultation", "Follow-up")
  status: string;                // Appointment status (e.g., "Scheduled", "Completed", "Cancelled")
  reason?: string;               // Reason for the appointment (optional)
}

