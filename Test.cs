//using COIS_2020H_Assignment2_DavidChan_ChengjunYin_MohammadRakib;

//public class Test
//{
//    public static void Main()
//    {
//        //Booleans
//        bool case1 = true, case2 = true, case3 = true, case4 = true, case5 = false,
//            case6 = false, case7 = false, case8 = false, case9 = false, case10 = false,
//            case11 = false, case12 = false, case13 = false, case14 = false, case15 = false,
//            case16 = false, case17 = false, case18 = false, case19 = false, case20 = false,
//            case21 = false, case22 = false, case23 = false;

//        //Cases
//        if (case1)
//            TestCase1();
//        if (case2)
//            TestCase2();
//        if (case3)
//            TestCase3();
//        if (case4)
//            TestCase4();
//    }

//    public static void TestCase1()
//    {
//        //Time generation test
//        Console.WriteLine("Case 1: Time generation");
//        double totalTime = 0, averageTime = 0;
//        Patient firstPat = new Patient(1, 60);
//        for (int i = 0; i < 1000; i++)
//            totalTime = totalTime + firstPat.CalculateTreatmentTime(60, i);
//        averageTime = totalTime / 1000;

//        if (averageTime > 60)
//            Console.WriteLine("The time is {0}, to compare with 60 seconds: \n Difference: {1}", averageTime, averageTime - 60);
//        else
//            Console.WriteLine("The time is {0}, to compare with 60 seconds: \n Difference: {1}", averageTime, 60 - averageTime);

//        Console.WriteLine(" ");
//    }

//    public static void TestCase2()
//    {
//        Console.WriteLine("Case 2: Time generation in emergrency \nUsing treatment time as 120s as 2 minutes ");
//        Patient patOne = new Patient(1, 120);
//        Patient patTwo = new Patient(2, 120);
//        Patient patThr = new Patient(3, 120);

//        Console.WriteLine("The time time for patient 1 is: " + patOne.CalculateTreatmentTime(120, 1));
//        Console.WriteLine("The time time for patient 2 is: " + patTwo.CalculateTreatmentTime(120, 2));
//        Console.WriteLine("The time time for patient 3 is: " + patThr.CalculateTreatmentTime(120, 3));
//        Console.WriteLine(" ");
//    }

//    public static void TestCase3()
//    {
//        Console.WriteLine("Case 3: Time generation \nUsing treatment time as 120s as 2 minutes ");
//        Patient patOne = new Patient(1, 120);
//        Event arrival = new Event(patOne, DateTime.MinValue);
//    }

//    public static void TestCase4()
//    {
//        Console.WriteLine("Case 4: Time generation \nUsing treatment time as 120s as 2 minutes ");
//        Patient patient = new Patient(1, 120);
//        Event evenr4 = new Event(patient, DateTime.Now);
//        Console.WriteLine(evenr4.ToString);

//    }

//    public static void TestCase5()
//    {
//        Console.WriteLine("Case 5: ");
//        Patient patient = new Patient(1, 120);

//    }

//    public static void TestCase6()
//    {
//        Patient patient = new Patient(1, 120);
//    }

//    public static void TestCase7()
//    {

//    }

//    public static void TestCase8()
//    {

//    }

//    public static void TestCase9() //Zero input
//    {

//    }
//}