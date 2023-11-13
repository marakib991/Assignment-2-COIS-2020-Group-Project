using System;
using Priority; // Assuming PriorityQueue is in the Priority namespace


namespace COIS_2020H_Assignment2_DavidChan_ChengjunYin_MohammadRakib
{
    // Event Class
    // Enumeration to define types of events in the simulation
    public enum EventType
    {
        ARRIVAL,   // Indicates a patient's arrival
        DEPARTURE  // Indicates a patient's departure
    }
    public class Event : IComparable
    {
        // Property to hold the patient associated with the event
        public Patient Patient { get; private set; }

        // Property to define the type of event (ARRIVAL or DEPARTURE)
        public EventType Type { get; private set; }

        // Property to hold the ID of the doctor assigned to the patient (for DEPARTURE events)
        // This is an int and could represent an ID in a system where doctors are identified by numbers
        public int DoctorAssigned { get; private set; }

        public int PatientNumber { get; private set; }

        // Property to hold the time when the event occurs
        public DateTime EventTime { get; set; }

        // Constructor for an ARRIVAL event
        // Only requires the patient and the time of the event
        // The doctor is not assigned at the time of arrival
        public Event(Patient patient, DateTime eventTime)
        {
            Patient = patient;
            Type = EventType.ARRIVAL;
            EventTime = eventTime;
            DoctorAssigned = -1; // Default value indicating no doctor is assigned for ARRIVAL
        }

        // Constructor for a DEPARTURE event
        // Requires the patient, the assigned doctor's ID, and the time of the event
        public Event(Patient patient, int doctorAssigned, DateTime eventTime)
        {
            Patient = patient;
            Type = EventType.DEPARTURE;
            DoctorAssigned = doctorAssigned; // Doctor assigned to the patient for this event
            EventTime = eventTime;
        }

        // Method to provide a string representation of the event for logging or debugging purposes
        // Includes different details based on the event type
        public override string ToString()
        {
            // Basic event details including type, patient number, and time
            string eventDetails = $"Event Type: {Type}, Patient Number: {Patient.PatientNumber}, Event Time: {EventTime}";

            // Add doctor information for DEPARTURE events
            if (Type == EventType.DEPARTURE)
            {
                eventDetails += $", Doctor Assigned: {DoctorAssigned}";
            }

            return eventDetails;
        }

        // Other properties and methods

        public int CompareTo(object obj)
        {
            if (obj == null) return 1;

            Event otherEvent = obj as Event;
            if (otherEvent != null)
                return this.EventTime.CompareTo(otherEvent.EventTime);
            else
                throw new ArgumentException("Object is not an Event");
        }
    }

}