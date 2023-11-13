using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Priority;

namespace COIS_2020H_Assignment2_DavidChan_ChengjunYin_MohammadRakib
{
    using Queue;
    public class Simulation
    {
        private PriorityQueue<Event> eventQueue;
        private Queue<Patient>[] waitingQueues;
        private int[] doctorsAvailability;
        public int treatmentMean { get; private set; }      //Number of doctors
        public int arrivalMean { get; private set; }        //Arrival of mean in unit of minutes
        public int numberOfDoctors { get; private set; }    //Number of doctors in integer
        public int numberOfPatients { get; private set; }   //Number of patients in integer
        public DateTime time { get; private set; }
        // List to store waiting times for each level of emergency
        private List<double>[] waitingTimes;

        // Constructor
        public Simulation(int T, int M, int N)
        {
            eventQueue = new PriorityQueue<Event>(); //A priority queue to sort based on emergency level
            waitingQueues = new Queue<Patient>[3]; // Three waiting queues for each level of emergency

            for (int i = 0; i < 3; i++)
            {
                waitingQueues[i] = new Queue<Patient>();
            }
            treatmentMean = T;
            arrivalMean = M;
            numberOfDoctors = N;
            doctorsAvailability = new int[numberOfDoctors];
            for (int i = 0; i < numberOfDoctors; i++)
            {
                doctorsAvailability[i] = -1;
            }
            time = new DateTime(2023, 11, 12, 9, 0, 0);     //Default date from 09:00 or 9:00am

            // Initialize waiting times list
            waitingTimes = new List<double>[3]; // Assuming 3 levels of emergency
            for (int i = 0; i < 3; i++)
            {
                waitingTimes[i] = new List<double>();
            }
        }

        // RunSimulation method
        public void RunSimulation()
        {
            // init first round of patient
            int firstRoundOfPatients = 15;
            Event mockEvent = new Event(new Patient(-1, treatmentMean), new DateTime(2023, 11, 12, 9, 0, 0)); //Mock datetime from 09:00 or 9:00am
            for (numberOfPatients = 0; numberOfPatients < firstRoundOfPatients;)
            {
                GenerateNextArrival(mockEvent);
            }
            Console.WriteLine("Simulation initialized!");

            // continue to handle until all patients are done
            while (eventQueue.Size() > 0 || waitingQueues[0].Size() > 0 || waitingQueues[1].Size() > 0 || waitingQueues[2].Size() > 0)
            {
                HandleNextEvent();
            }
        }

        private void HandleNextEvent()
        {
            Event currentEvent = eventQueue.Front();
            DateTime cutoffTime = new DateTime(2023, 11, 12, 15, 0, 0);
            // handle event with arrival earlier than 15:00
            if (currentEvent.Type == EventType.ARRIVAL && DateTime.Compare(currentEvent.EventTime, cutoffTime) < 0)
            {
                HandleArrival(currentEvent);
                GenerateNextArrival(currentEvent);
            }
            // handle departure event
            else if (currentEvent.Type == EventType.DEPARTURE)
            {
                HandleDeparture(currentEvent);
            }
            time = currentEvent.EventTime;
            eventQueue.Remove();

            // handle event with arrival after 15:00
            if (currentEvent.Type == EventType.ARRIVAL && DateTime.Compare(currentEvent.EventTime, cutoffTime) > 0)
            {
                Console.WriteLine(string.Format("{0} - Patient {1} ({2}) arrives after operating hours and is transferred.", currentEvent.EventTime.ToString(), currentEvent.Patient.PatientNumber, currentEvent.Patient.LevelOfEmergency));
            }
        }

        private void HandleArrival(Event currentEvent)
        {
            int doctorAvailable = -1;
            for (int i = 0; i < doctorsAvailability.Length; i++)
            {
                if (doctorsAvailability[i] < 0)
                {
                    doctorAvailable = i;
                    break;
                }
            }

            // no doctor available
            if (doctorAvailable == -1)
            {
                bool preEmpted = false;

                for (int i = 0; i < doctorsAvailability.Length; i++)
                {
                    if (doctorsAvailability[i] < currentEvent.Patient.LevelOfEmergency)
                    {
                        for (int j = 1; j < eventQueue.A.Length + 1; j++)
                        {
                            Event tempEvent = eventQueue.Peek(j);
                            if (tempEvent.DoctorAssigned == i)
                            {
                                // Record waiting time before patient is assigned to a doctor
                                double waitingTime = (currentEvent.EventTime - tempEvent.EventTime).TotalSeconds;
                                waitingTimes[tempEvent.Patient.LevelOfEmergency - 1].Add(waitingTime);

                                // send original patient to waiting queue
                                tempEvent.Patient.TreatmentTime = (int)(tempEvent.EventTime - currentEvent.EventTime).TotalSeconds;
                                eventQueue.RemoveAt(j);
                                waitingQueues[tempEvent.Patient.LevelOfEmergency - 1].Enqueue(tempEvent.Patient);

                                // set departure event for new patient
                                doctorsAvailability[i] = currentEvent.Patient.LevelOfEmergency;
                                Event departureEvent = new Event(currentEvent.Patient, i, currentEvent.EventTime.AddSeconds(currentEvent.Patient.TreatmentTime));
                                eventQueue.Insert(departureEvent);
                                Console.WriteLine(string.Format("{0} - Patient {1} ({2}) arrives and is assigned to Doctor {3}, pre-empting Patient {4} ({5}).", currentEvent.EventTime.ToString(), currentEvent.Patient.PatientNumber, currentEvent.Patient.LevelOfEmergency, i, tempEvent.Patient.PatientNumber, tempEvent.Patient.LevelOfEmergency));
                                preEmpted = true;
                                break;
                            }
                        }
                        break;
                    }
                }

                if (!preEmpted)
                {
                    // Create a new patient and set ArrivalTime
                    Patient newPatient = new Patient(numberOfPatients, treatmentMean)
                    {
                        ArrivalTime = currentEvent.EventTime
                    };

                    // Record waiting time before patient is assigned to a doctor
                    double waitingTime = (currentEvent.EventTime - newPatient.ArrivalTime).TotalSeconds;
                    waitingTimes[newPatient.LevelOfEmergency - 1].Add(waitingTime);

                    waitingQueues[currentEvent.Patient.LevelOfEmergency - 1].Enqueue(newPatient);
                    Console.WriteLine(string.Format("{0} - Patient {1} ({2}) arrives and is seated in the waiting room.", currentEvent.EventTime.ToString(), currentEvent.Patient.PatientNumber, currentEvent.Patient.LevelOfEmergency));
                }
            }
            else
            {
                // Record waiting time before patient is assigned to a doctor
                double waitingTime = (currentEvent.EventTime - currentEvent.Patient.ArrivalTime).TotalSeconds;
                waitingTimes[currentEvent.Patient.LevelOfEmergency - 1].Add(waitingTime);

                doctorsAvailability[doctorAvailable] = currentEvent.Patient.LevelOfEmergency;
                Event departure = new Event(currentEvent.Patient, doctorAvailable, currentEvent.EventTime.AddSeconds(currentEvent.Patient.TreatmentTime));
                eventQueue.Insert(departure);
                Console.WriteLine(string.Format("{0} - Patient {1} ({2}) arrives and is assigned to Doctor {3}.", currentEvent.EventTime.ToString(), currentEvent.Patient.PatientNumber, currentEvent.Patient.LevelOfEmergency, doctorAvailable));
            }
        }


        private void HandleDeparture(Event currentEvent)
        {
            doctorsAvailability[currentEvent.DoctorAssigned] = -1;

            bool doctorBusy = false;

            for (int i = 2; i > -1; i--)
            {
                if (waitingQueues[i].Size() > 0)
                {
                    doctorBusy = true;
                    Patient patient = waitingQueues[i].Front();

                    // Record waiting time before patient is assigned to a doctor
                    double waitingTime = (currentEvent.EventTime - patient.ArrivalTime).TotalSeconds;
                    waitingTimes[patient.LevelOfEmergency - 1].Add(waitingTime);

                    waitingQueues[i].Dequeue();
                    Event departure = new Event(patient, currentEvent.DoctorAssigned, currentEvent.EventTime.AddSeconds(patient.TreatmentTime));
                    doctorsAvailability[currentEvent.DoctorAssigned] = patient.LevelOfEmergency;
                    eventQueue.Insert(departure);
                    Console.WriteLine("{0} - Doctor {1} completes treatment of Patient {2} and is assigned to Patient {3}.", currentEvent.EventTime.ToString(), currentEvent.DoctorAssigned, currentEvent.Patient.PatientNumber, patient.PatientNumber);
                    break;
                }
            }

            if (!doctorBusy)
            {
                Console.WriteLine("{0} - Doctor {1} completes treatment of Patient {2}", currentEvent.EventTime.ToString(), currentEvent.DoctorAssigned, currentEvent.Patient.PatientNumber);
            }
        }


        // Generate next patient arrival
        private void GenerateNextArrival(Event currentEvent)
        {
            Patient patient = new Patient(numberOfPatients, treatmentMean);
            int gap = (int)(-1 * arrivalMean * Math.Log(new Random().NextDouble()));
            DateTime arriveAt = currentEvent.EventTime.AddSeconds(gap);
            Event arrivalEvent = new Event(patient, arriveAt);
            eventQueue.Insert(arrivalEvent);
            numberOfPatients++;
        }

        // Method to calculate average waiting time for a given emergency level
        private double CalculateAverageWaitingTime(int emergencyLevel)
        {
            List<double> currentWaitingTimes = waitingTimes[emergencyLevel - 1];
            if (currentWaitingTimes.Count == 0)
                return 0; // Avoid division by zero

            double totalWaitingTime = currentWaitingTimes.Sum();
            return totalWaitingTime / currentWaitingTimes.Count;
        }

        // Method to display average waiting times for all emergency levels
        public void DisplayAverageWaitingTimes()
        {
            Console.WriteLine("Average Waiting Times:");
            for (int i = 0; i < 3; i++) // Assuming 3 levels of emergency
            {
                double averageWaitingTime = CalculateAverageWaitingTime(i + 1);
                Console.WriteLine($"Level {i + 1}: {averageWaitingTime} seconds");
            }
        }
    }
}
