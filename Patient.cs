using System;

namespace COIS_2020H_Assignment2_DavidChan_ChengjunYin_MohammadRakib
{
    public class Patient
    {

        public int PatientNumber { get; set; }
        public int LevelOfEmergency { get; set; }
        public int TreatmentTime { get; set; }
        // Add ArrivalTime property
        public DateTime ArrivalTime { get; set; }

        // Constructor for the Patient class
        public Patient(int patientNumber, double treatmentMean)
        {
            PatientNumber = patientNumber;
            LevelOfEmergency = AssignEmergencyLevel();
            TreatmentTime = (int)CalculateTreatmentTime(treatmentMean, LevelOfEmergency);
        }


        //Methods
        public int AssignEmergencyLevel()
        {
            //Creating a random value
            Random random = new Random();
            double r = random.NextDouble();

            if (r < 0.6)
                return 1;
            else if (r < 0.9)
                return 2;
            else if (r < 1)
                return 3;
            else
                throw new InvalidOperationException("Your percentage is not possible!");
        }

        public double CalculateTreatmentTime(double mean, int emergencyLevel)
        {
            //Setting random values
            Random random = new Random();
            double u = random.NextDouble();
            double factor = 1;

            if (emergencyLevel == 2)
                factor = 2;
            else if (emergencyLevel == 3)
                factor = 4;

            return mean * (-1) * Math.Log(u) * factor;
        }

        public override string ToString()
        {
            return $"Patient Number: {PatientNumber}, Emergency Level: {LevelOfEmergency}, Treatment Time: {TreatmentTime}";
        }

    }
}