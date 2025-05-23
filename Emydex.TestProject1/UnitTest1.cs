using FarmSystem.Test1;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.IO;

namespace Emydex.TestProject1
{
    public class Tests
    {
        private FarmSystem.Test1.EmydexFarmSystem farm;
        private StringWriter consoleOutput;

        [SetUp]
        public void SetUp()
        {
            farm = new FarmSystem.Test1.EmydexFarmSystem();
            consoleOutput = new StringWriter();
            Console.SetOut(consoleOutput);
        }

        [TearDown]
        public void TearDown()
        {
            consoleOutput.Dispose();
        }

        // Animal Sound Tests
        [TestCase(typeof(Cow), "Moo")]
        [TestCase(typeof(Hen), "CLUCKAAAAAWWWWK")]
        [TestCase(typeof(Horse), "Neigh")]
        [TestCase(typeof(Sheep), "Baa")]
        public void Animal_MakeSound_ReturnsExpectedSound(Type animalType, string expectedSound)
        {
            // Arrange
            var animals = new List<Animal>
            {
                new Hen(),
                new Cow(),
                new Horse(),
                new Sheep()
            };

            var expectedOutputs = new List<string>
            {
                "Hen says CLUCKAAAAAWWWWK!",
                "Cow says Moo!",
                "Horse says neigh!",
                "Sheep says baa!"
            };

            for (int i = 0; i < animals.Count; i++)
            {
                var output = new StringWriter();
                Console.SetOut(output);

                // Act
                animals[i].Talk();
                var actualOutput = output.ToString().Trim();

                // Assert
                Assert.AreEqual(expectedOutputs[i], actualOutput, $"Failed for {animals[i].GetType().Name}");
            }
            // Additional test for no animals in the farm
            var emptyAnimals = new List<Animal>();

            var emptyOutput = new StringWriter();
            Console.SetOut(emptyOutput);

            foreach (var animal in emptyAnimals)
            {
                animal.Talk();
            }
            var actualEmptyOutput = emptyOutput.ToString().Trim();

            // Assert that there is no output when no animals exist
            Assert.IsTrue(string.IsNullOrEmpty(actualEmptyOutput), "Expected no output when there are no animals in the farm");
        }
    }
}