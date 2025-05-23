using FarmSystem.Test1.Service;
using FarmSystem.Test1.Utilities.Log;
using System;
using System.Collections.Generic;
using System.Linq;

namespace FarmSystem.Test1
{
    public class EmydexFarmSystem
    {
        private readonly Queue<Animal> _animals = new Queue<Animal>();
        //exercise 4 changes
        //raising event 
        public event EventHandler FarmEmpty;
        protected virtual void OnFarmEmpty()
        {
            FarmEmpty?.Invoke(this, EventArgs.Empty);
        }

        //TEST 1
        public void Enter(Animal animal)
        {
            //Modify the code so that we can display the type of animal (cow, sheep etc) 
            //Hold all the animals so it is available for future activities

            //exercise 1 chnages
            if (animal != null)
            {
                _animals.Enqueue(animal); //FIFO queue
                animal.EnterFarm();
            }
            else
            {
                Console.WriteLine("No Animal has entered the Emydex farm");
            }

        }

        //TEST 2
        public void MakeNoise()
        {
            //Test 2 : Modify this method to make the animals talk

            if (_animals.Any())
            {
                foreach (Animal animal in _animals)
                {
                    animal.Talk();
                    FileLogger.Instance.LogInformation($"{animal.GetType().Name} ID: {animal.Id} entered");
                }
            }
            else
            {
                Console.WriteLine("There are no animals in the farm");
            }
        }

        //TEST 3
        public void MilkAnimals()
        {
            if (_animals.Any())
            {
                try
                {
                    var milkingService = new MilkingAnimalService();
                    milkingService.ProduceMilk(_animals);
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Cannot identify the farm animals which can be milked");
                    FileLogger.Instance.LogError("Cannot identify the farm animals which can be milked" + ex.Message);
                }
            }
            else
            {
                Console.WriteLine("There are no animals in the farm");
            }
        }

        //TEST 4
        public void ReleaseAllAnimals()
        {
            try
            {
                if (_animals.Any())
                {
                    while (_animals.Any())
                    {
                        var animal = _animals.Dequeue();
                        Console.WriteLine($"{animal.GetType().Name} has left the farm");
                        FileLogger.Instance.LogInformation($"{animal.GetType().Name} ID: {animal.Id} has left the farm");
                    }
                    // Raise the FarmEmpty event
                    OnFarmEmpty();
                }
                else
                {
                    Console.WriteLine("There are no animals in the farm to empty.");
                }
            }
            catch (Exception ex)
            {
                FileLogger.Instance.LogError($"There are still animals in the farm, farm is not free" + ex.Message);
                Console.WriteLine("There are still animals in the farm, farm is not free");
            }
        }
    }
}