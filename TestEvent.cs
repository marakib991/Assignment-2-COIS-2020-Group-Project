//using System;

//namespace COIS_2020H_Assignment2_DavidChan_ChengjunYin_MohammadRakib
//{
//    public class TestEvent
//    {
//        public static void RunTests()
//        {
//            Console.WriteLine("Running Event Tests...");
//            ArrivalEventCreationTest();
//            DepartureEventCreationTest();
//            EventToStringTest();
//            // Add more test methods as needed
//            Console.WriteLine("Event Tests Completed.\n");
//        }

//        private static void ArrivalEventCreationTest()
//        {
//            DateTime arrivalTime = DateTime.Now;
//            Patient patient = new Patient(1, 1, 1);

//            Event arrivalEvent = new Event(patient, arrivalTime);

//            // Assert
//            Console.WriteLine("ArrivalEventCreationTest:");
//            Console.WriteLine($"Expected Type: {EventType.ARRIVAL}, Actual Type: {arrivalEvent.Type}");
//            Console.WriteLine($"Expected Patient: {patient}, Actual Patient: {arrivalEvent.Patient}");
//            Console.WriteLine($"Expected Event Time: {arrivalTime}, Actual Event Time: {arrivalEvent.EventTime}");
//            Console.WriteLine($"Expected Doctor Assigned: -1, Actual Doctor Assigned: {arrivalEvent.DoctorAssigned}");
//            Console.WriteLine();
//        }

//        private static void DepartureEventCreationTest()
//        {
//            DateTime departureTime = DateTime.Now;
//            Patient patient = new Patient(2, 2);
//            int doctorAssigned = 123;

//            Event departureEvent = new Event(patient, doctorAssigned, departureTime);

//            // Assert
//            Console.WriteLine("DepartureEventCreationTest:");
//            Console.WriteLine($"Expected Type: {EventType.DEPARTURE}, Actual Type: {departureEvent.Type}");
//            Console.WriteLine($"Expected Patient: {patient}, Actual Patient: {departureEvent.Patient}");
//            Console.WriteLine($"Expected Doctor Assigned: {doctorAssigned}, Actual Doctor Assigned: {departureEvent.DoctorAssigned}");
//            Console.WriteLine($"Expected Event Time: {departureTime}, Actual Event Time: {departureEvent.EventTime}");
//            Console.WriteLine();
//        }

//        private static void EventToStringTest()
//        {
//            DateTime eventTime = DateTime.Now;
//            Patient patient = new Patient(0, 3);
//            int doctorAssigned = 456;

//            Event departureEvent = new Event(patient, doctorAssigned, eventTime);
//            string eventString = departureEvent.ToString();

//            // Assert
//            Console.WriteLine("EventToStringTest:");
//            Console.WriteLine($"Expected: EventType.DEPARTURE in the string, Actual: {eventString.Contains(EventType.DEPARTURE.ToString())}");
//            Console.WriteLine($"Expected: Patient number in the string, Actual: {eventString.Contains(patient.PatientNumber.ToString())}");
//            Console.WriteLine($"Expected: Doctor Assigned in the string, Actual: {eventString.Contains(doctorAssigned.ToString())}");
//            Console.WriteLine($"Expected: Event Time in the string, Actual: {eventString.Contains(eventTime.ToString())}");
//            Console.WriteLine();
//        }
//    }
//}
