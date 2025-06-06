﻿using FarmSystem.Test1.Utilities;
using FarmSystem.Test1.Utilities.Log;
using System;

namespace FarmSystem.Test1
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            Excercise1();  
            Excercise2();
            Excercise3();
            Excercise4();
            Console.ReadKey();
        }

/************************************************************************************************************
Exercise 1 : Apply OOP concepts (abstraction and encapsulation) to the classes
modify the code to get the output below
Cow has entered the farm
Hen has entered the farm
Horse has entered the farm
Sheep has entered the farm
***************************************************************************************************************/
        private static void Excercise1()
        {
            Console.WriteLine("Exercise 1 : Press any key when it is time to open the Farm to animals");
            FileLogger.Instance.LogInformation("Exercise 1 initiated");
            try
            {
                Console.ReadKey();
                var farm = new EmydexFarmSystem();
                Cow cow = new Cow();
                cow.Id = Utility.GenerateId();
                cow.NoOfLegs = 4;
                farm.Enter(cow);

                Hen hen = new Hen();
                hen.Id = Utility.GenerateId();
                hen.NoOfLegs = 2; //Hen has 2 legs
                farm.Enter(hen);

                Horse horse = new Horse();
                horse.Id = Utility.GenerateId();
                horse.NoOfLegs = 4;
                farm.Enter(horse);

                Sheep sheep = new Sheep();
                sheep.Id = Utility.GenerateId();
                sheep.NoOfLegs = 4;
                farm.Enter(sheep);

                FileLogger.Instance.LogInformation("Exercise 1 Ended");
                Console.ReadKey();
            }
            catch (Exception ex)
            {
                FileLogger.Instance.LogError($"Exception: {ex.Message}");
            }
        }

/***************************************************************************************************************
 Test Excercise 2
 If you have completed the first test excercise, you can continue with the second one
 Modify the program and EmydexFarmSystem.MakeNoise() method to get the below output
 Expected Test 2 Program Output

 Exercise 2 : Press any key to scare the animals in the farm
    Cow has entered the farm
    Hen has entered the farm
    Horse has entered the farm
    Sheep has entered the farm
    Cow says Moo!
    Hen says CLUCKAAAAAWWWWK!
    Horse says Neigh!
    Sheep says baa!
 *****************************************************************************************************************/
        private static void Excercise2()
        {
            // Apply OOP concepts and modify the code below to get the required output 
            Console.WriteLine("Exercise 2 : Press any key to scare the animals in the farm");
            FileLogger.Instance.LogInformation("Exercise 2 initiated");
            try
            {
                Console.ReadKey();
                var farm = new EmydexFarmSystem();
                Cow cow = new Cow();
                cow.Id = Utility.GenerateId();
                cow.NoOfLegs = 4;
                farm.Enter(cow);

                Hen hen = new Hen();
                hen.Id = Utility.GenerateId();
                hen.NoOfLegs = 2; //Hen has 2 legs
                farm.Enter(hen);

                Horse horse = new Horse();
                horse.Id = Utility.GenerateId();
                horse.NoOfLegs = 4;
                farm.Enter(horse);

                Sheep sheep = new Sheep();
                sheep.Id = Utility.GenerateId();
                sheep.NoOfLegs = 4;
                farm.Enter(sheep);

                farm.MakeNoise();

                FileLogger.Instance.LogInformation("Exercise 2 Ended");
                Console.ReadKey();
            }
            catch (Exception ex)
            {
                FileLogger.Instance.LogError($"Exception: {ex.Message}");
            }
        }

/*****************************************************************************************************************
Test Excercise 3
If you have completed the previous test excercise, you can continue with this one
The project includes an interface IMilkableAnimal. Make use of this interface to implement on the relevant classes
so that calling the EmydexFarmSystem.MilkAnimals() method to get the below output

Expected Test 3 Program Output

Exercise 3 : Press any key when it is time to milk animals
Cow has entered the farm
Hen has entered the farm
Horse has entered the farm
Sheep has entered the farm
Cow was milked!
************************************************************************************************************/
        private static void Excercise3()
        {
            //: Apply OOP concepts and modify the code below to get the required output 
            Console.WriteLine("Exercise 3 : Press any key when it is time to milk animals");
            FileLogger.Instance.LogInformation("Exercise 3 initiated");
            try
            {
                Console.ReadKey();
                var farm = new EmydexFarmSystem();
                Cow cow = new Cow();
                cow.Id = Utility.GenerateId();
                cow.NoOfLegs = 4;
                farm.Enter(cow);

                Hen hen = new Hen();
                hen.Id = Utility.GenerateId();
                hen.NoOfLegs = 2; //Hen has 2 legs
                farm.Enter(hen);

                Horse horse = new Horse();
                horse.Id = Utility.GenerateId();
                horse.NoOfLegs = 4;
                farm.Enter(horse);

                Sheep sheep = new Sheep();
                sheep.Id = Utility.GenerateId();
                sheep.NoOfLegs = 4;
                farm.Enter(sheep);

                farm.MilkAnimals();

                FileLogger.Instance.LogInformation("Exercise 3 Ended");
                Console.ReadKey();
            }
            catch (Exception ex)
            {
                FileLogger.Instance.LogError($"Exception: {ex.Message}");
            }
        }

/****************************************************************************************************
Test Excercise 4
Modify the EmydexFarmSystem.ReleaseAllAnimals() so that all animals are released (simply clear the collection )
Expose an event on the FarmSystem FarmEmpty which is invoked once all the animals are released
Subscribe to that event in the main to get the expected output

Expected Test 4 Program Output

Exercise 4: Press any key to free all animals
Cow has entered the farm
Hen has entered the farm
Horse has entered the farm
Sheep has entered the farm
Cow has left the farm
Hen has left the farm
Horse has left the farm
Sheep has left the farm
Emydex Farm is now empty
********************************************************************************************************************/
        private static void Excercise4()
        {
            //Apply OOP concepts and modify the code below to get the required output 
            Console.WriteLine("Exercise 4: Press any key to free all animals");
            FileLogger.Instance.LogInformation("Exercise 4 initiated");
            try
            {
                Console.ReadKey();
                var farm = new EmydexFarmSystem();

                // Subscribe to the event
                farm.FarmEmpty += (sender, args) =>
                {
                    Console.WriteLine("Emydex Farm is now empty");
                    FileLogger.Instance.LogInformation("Emydex Farm is now empty");
                };

                Cow cow = new Cow();
                cow.Id = Utility.GenerateId();
                cow.NoOfLegs = 4;
                farm.Enter(cow);

                Hen hen = new Hen();
                hen.Id = Utility.GenerateId();
                hen.NoOfLegs = 2; //Hen has 2 legs
                farm.Enter(hen);

                Horse horse = new Horse();
                horse.Id = Utility.GenerateId();
                horse.NoOfLegs = 4;
                farm.Enter(horse);

                Sheep sheep = new Sheep();
                sheep.Id = Utility.GenerateId();
                sheep.NoOfLegs = 4;
                farm.Enter(sheep);

                farm.ReleaseAllAnimals();
                FileLogger.Instance.LogInformation("Exercise 4 Ended");
                Console.ReadKey();
            }
            catch (Exception ex)
            {
                FileLogger.Instance.LogError($"Exception: {ex.Message}");
            }
        }

    }
}