﻿using System;

namespace FarmSystem.Test1
{
    public class Sheep : Animal
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
            Console.WriteLine("Sheep says baa!");
        }

        //not in use yet
        //public void Run()
        //{
        //    Console.WriteLine("Sheep is running");
        //}
    }

}