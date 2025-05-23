using FarmSystem.Test1.Utilities.Log;
using FarmSystem.Test2;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
