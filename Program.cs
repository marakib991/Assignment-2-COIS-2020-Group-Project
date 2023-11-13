using System;

namespace COIS_2020H_Assignment2_DavidChan_ChengjunYin_MohammadRakib
{
    class Program
    {
        static void Main(string[] args)
        {
            bool t1 = false;
            bool t2 = false;
            bool t3 = true;
            if (t1)
            {
                //// Creating an instance of the Patient class
                //var patient = new Patient(1, 5);

                //// Displaying the patient details
                //Console.WriteLine(patient.ToString());

                //// Testing the methods of the Patient class
                //var emergencyLevel = patient.AssignEmergencyLevel();
                //var treatmentTime = patient.CalculateTreatmentTime(10, emergencyLevel);

                //// Displaying the results of the methods
                //Console.WriteLine("Assigned Emergency Level: " + emergencyLevel);
                //Console.WriteLine("Calculated Treatment Time: " + treatmentTime);
            }

            if (t2)
            {
                //// Testing Patient class
                //Patient patient1 = new Patient(1, 20);
                //Patient patient2 = new Patient(2, 25);
                //Patient patient3 = new Patient(3, 30);

                //Console.WriteLine("Patients:");
                //Console.WriteLine(patient1.ToString());
                //Console.WriteLine(patient2.ToString());
                //Console.WriteLine(patient3.ToString());

                //// Testing Queue class
                //COIS_2020H_Assignment2_DavidChan_ChengjunYin_MohammadRakib.Queue.Queue<Event> eventQueue = new COIS_2020H_Assignment2_DavidChan_ChengjunYin_MohammadRakib.Queue.Queue<Event>();
                //eventQueue.Enqueue(new Event(patient1, DateTime.Now));
                //eventQueue.Enqueue(new Event(patient2, DateTime.Now.AddMinutes(10)));
                //eventQueue.Enqueue(new Event(patient3, DateTime.Now.AddMinutes(15)));

                //Console.WriteLine("\nQueue:");
                //while (!eventQueue.Empty())
                //{
                //    Console.WriteLine(eventQueue.Front().ToString());
                //    eventQueue.Dequeue();
                //}

                //// Testing PriorityQueue class
                //PriorityQueue<Event> priorityQueue = new PriorityQueue<Event>();
                //priorityQueue.Insert(new Event(patient1, DateTime.Now));
                //priorityQueue.Insert(new Event(patient2, DateTime.Now.AddMinutes(10)));
                //priorityQueue.Insert(new Event(patient3, DateTime.Now.AddMinutes(15)));

                //Console.WriteLine("\nPriority Queue:");
                //while (!priorityQueue.Empty())
                //{
                //    Console.WriteLine(priorityQueue.Front().ToString());
                //    priorityQueue.Remove();
                //}

                //// Testing Simulation class
                //Console.WriteLine("\nTesting Simulation class: ");
                //Simulation simulation = new Simulation();
                //simulation.RunSimulation(10, 5, 5);
            }

            if (t3)
            {
                Simulation simulation = new Simulation(120, 120, 11);
                Console.WriteLine("Treatment mean time: " + simulation.treatmentMean);
                Console.WriteLine("Arrival mean time: " + simulation.arrivalMean);
                Console.WriteLine("Number of doctors in hospital: " + simulation.numberOfDoctors);
                simulation.RunSimulation();
                Console.WriteLine();
                simulation.DisplayAverageWaitingTimes();
            }
        }
    }
}
