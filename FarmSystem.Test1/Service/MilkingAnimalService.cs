using FarmSystem.Test2;
using System.Collections.Generic;

namespace FarmSystem.Test1.Service
{
    public class MilkingAnimalService
    {
        public void ProduceMilk(Queue<Animal> animals)
        {
            foreach (var animal in animals)
            {
                if (animal is IMilkableAnimal milkable)
                {
                    milkable.ProduceMilk();
                  //  _logger.LogInformation($"{animal.GetType().Name} ID: {animal.Id} was milked");
                }
            }
        }
    }
}
