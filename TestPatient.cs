//using System;

//namespace COIS_2020H_Assignment2_DavidChan_ChengjunYin_MohammadRakib.Tests
//{
//    public class TestPatient
//    {
//        public static void RunTests()
//        {
//            Console.WriteLine("Running Patient Tests...");

//            TestAssignEmergencyLevel();
//            TestCalculateTreatmentTime();
//            TestToString();

//            Console.WriteLine("Patient Tests Completed.\n");
//        }

//        private static void TestAssignEmergencyLevel()
//        {
//            Console.WriteLine("TestAssignEmergencyLevel:");

//            for (int i = 0; i < 5; i++)
//            {
//                Patient patient = new Patient(1, 0);

//                int emergencyLevel = patient.AssignEmergencyLevel();

//                Console.WriteLine($"Example {i + 1}: Emergency Level: {emergencyLevel}");
//            }

//            Console.WriteLine();
//        }

//        private static void TestCalculateTreatmentTime()
//        {
//            Console.WriteLine("TestCalculateTreatmentTime:");

//            for (int i = 0; i < 5; i++)
//            {
//                Patient patient = new Patient(1, 0);

//                double mean = 5; // Set a mean value for the test
//                int emergencyLevel = patient.AssignEmergencyLevel();

//                double treatmentTime = patient.CalculateTreatmentTime(mean, emergencyLevel);

//                Console.WriteLine($"Example {i + 1}: Treatment Time: {treatmentTime}");
//            }

//            Console.WriteLine();
//        }

//        private static void TestToString()
//        {
//            Console.WriteLine("TestToString:");

//            for (int i = 0; i < 5; i++)
//            {
//                Patient patient = new Patient(1, 1, 0);

//                string patientString = patient.ToString();

//                Console.WriteLine($"Example {i + 1}: {patientString}");
//            }

//            Console.WriteLine();
//        }
//    }
//}
