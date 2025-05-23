using System;

namespace FarmSystem.Test1
{
    public class Cow : Animal
    {

        //exercise  1 changes
        //private string _id;
        //private int _noOfLegs = 4;


        //public string Id
        //{
        //    get { return _id; }
        //    set
        //    {
        //        _id = value;
        //    }
        //}

        //public int NoOfLegs
        //{
        //    get
        //    {
        //        return _noOfLegs;
        //    }
        //    set
        //    {
        //        _noOfLegs = 4;
        //    }
        //}

        public override void Talk()
        {
            Console.WriteLine("Cow says Moo!");
        }
        public void Walk()
        {
            Console.WriteLine("Cow is walking");
        }

        public void ProduceMilk()
        {
            Console.WriteLine("Cow produced milk");
        }

        public void Run()
        {
            Console.WriteLine("Cow is running");
        }

    }
}