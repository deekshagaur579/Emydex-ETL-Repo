using FarmSystem.Test1.Utilities.Log;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FarmSystem.Test1
{
    public abstract class Animal
    {
        private string _id;
        private int _noOfLegs = 2;  // Default value set here

        public string Id
        {
            get { return _id; }
            set { _id = value; }
        }

        public int NoOfLegs
        {
            get { return _noOfLegs; }
            set { _noOfLegs = value; } // Allow changing if needed
        }
        //TEST 1
        public virtual void EnterFarm()
        {
            Console.WriteLine($"{this.GetType().Name} has entered the farm");
            FileLogger.Instance.LogInformation($"{this.GetType().Name} ID: {Id} entered");
        }
    }
}
