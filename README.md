# Emydex-ETL-Repo
Emydex Windows Take home assessment 
# Emydex Farm System

A console-based .NET application that simulates a farm where animals enter, talk, are milked (if possible), and exit. This project demonstrates key software engineering principles like **SOLID**, **design patterns**, and clean architecture using C#.

---

## Purpose

This project was developed as part of the **Emydex recruitment process**.

> **Original codebase**:  
> extended from  
> [`https://github.com/Emydex-Technology/ETL-Repo`](https://github.com/Emydex-Technology/ETL-Repo)  
> Version .Net Framework 4.5

The exercises and enhancements are tailored around demonstrating understanding of maintainable coding practices, design patterns, and object-oriented principles within the context of an existing legacy project.

---

## Version Updates

- Upgraded to **.NET Framework 4.5.2** since `4.5-dev` is no longer available.

---

## Problem Statements and Outputs

### Test Excercise 1
```csharp

Using your understanding of Object Oriented Programing concepts, modify the classes and program in Test1 to use abstraction and inheritence
to make the FarmSystem more efficient and easier to maintain and extend 
Introduce new classes if needed 
Hold the animals in the farm so they are available for furture activities in a First in First Out basis (Queued animals)
 
Expected Test1 Program Output

Exercise 1 : Press any key when it is time to open the Farm to animals
Cow has entered the farm
Hen has entered the farm
Horse has entered the farm
Sheep has entered the farm
```
### INPUT
```text
Press any key on keyboard
```
### OUTPUT
![image](https://github.com/user-attachments/assets/9d30cfbc-c8f6-4431-a4de-e7ba8ba043eb)

### Test Excercise 2
```csharp

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

```
### INPUT
```text
Press any key on keyboard
```
### OUTPUT
![image](https://github.com/user-attachments/assets/682da1b8-59be-4e3b-ac14-d2b0a2ca33cf)

### Test Excercise 3
```csharp

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

```
### INPUT
```text
Press any key on keyboard
```
### OUTPUT
![image](https://github.com/user-attachments/assets/c9df90e0-c585-4b32-9f12-34e4926298d9)

### Test Excercise 4
```csharp

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
```
### INPUT
```text
Press any key on keyboard
```
### OUTPUT

![image](https://github.com/user-attachments/assets/6fcb5292-db2a-4d4c-a21d-0fb782274df8)


---
## Clean Code and Clean Git


### Code Commenting for Traceability

All modified or newly added lines are marked with inline comments such as:
```csharp
//TEST 1
//TEST 2
//TEST 3
//TEST 4
```
This allows for easier reference, version tracking, and understanding of changes made across exercises.

### Clean Git

.gitignore updated to exclude /FarmSystem.Test1/bin/debug/ from version control.


---

# Solution  
## Exercise 1

Approach:
```text
Abstraction
```
Code Changes:

Created abstract class Animal.cs with:

```csharp
public abstract class Animal
{
    private string _id;
    private int _noOfLegs = 2; // Default for Hen

    public string Id
    {
        get { return _id; }
        set { _id = value; }
    }

    public int NoOfLegs
    {
        get { return _noOfLegs; }
        set { _noOfLegs = value; }
    }

    public abstract void Talk();
}
```
Removed duplicate properties Id and NoOfLegs from Cow.cs, Hen.cs, Sheep.cs, Horse.cs.

All animals inherit from Animal, example:
```csharp
public class Cow : Animal
{
  
}
```
Queue<Animal> animalQueue used in EmydexFarmSystem.cs for FIFO animal management.

## Exercise 2

Approach:
```text
Polymorphism via Abstraction
```
Code Changes:

Added:

```csharp
public abstract void Talk(); // in Animal.cs
```
Implemented Talk() method in each derived class:

```csharp
public override void Talk()
{
    Console.WriteLine("Sheep says Baa!");
}
```
Called Talk() from EmydexFarmSystem.cs when listing animals:

```csharp

            if (_animals.Any())
            {
                foreach (Animal animal in _animals)
                {
                    animal.Talk();
                    FileLogger.Instance.LogInformation($"{animal.GetType().Name} ID: {animal.Id} entered");
                }
            }
```
## Exercise 3

Approach:

```text
Open/Closed Principle (OCP)
```
Code Changes:

Created interface:

```csharp
public interface IMilkableAnimal
{
    void ProduceMilk();
}
```
Implemented in milkable animals only (Cow):

```csharp
public void ProduceMilk()
{
    Console.WriteLine("Cow was milked!");
}
```
Created MilkingAnimalService.cs:

```csharp
public class MilkingAnimalService
{
    public void MilkAnimals(IEnumerable<Animal> animals)
    {
        foreach (var animal in animals)
        {
            if (animal is IMilkableAnimal milkable)
            {
                milkable.ProduceMilk();
            }
        }
    }
}
```
Maintains OCP – new milkable animals can be added without modifying system logic.

### Exercise 4 

Approach:

```text
Event Handling (Observer Pattern)
```
Code Changes:

Defined event in EmydexFarmSystem.cs:

```csharp
public event EventHandler FarmEmpty;
private void OnFarmEmpty()
{
    FarmEmpty?.Invoke(this, EventArgs.Empty);
}
```
Triggered event after releasing all animals:

```csharp
animalQueue.Clear();
OnFarmEmpty(); // Notify subscribers
```
Subscribed in Program.cs:

```csharp
 // Subscribe to the event
 farm.FarmEmpty += (sender, args) =>
 {
     Console.WriteLine("Emydex Farm is now empty");
     FileLogger.Instance.LogInformation("Emydex Farm is now empty");
 };
```
Implements Observer Pattern via C# event and delegate mechanisms.
---

# Solution Explanation 

## Demonstrated SDLC Lifecycle Events:
   Followed a structured approach to requirements, design, implementation, and testing. 
   Have 3 different branches Main, Dev, Test.

---

   
## SOLID Principles
  ### S - Single Responsibility Principle (SRP):
  ```text  
  Each class (e.g., Animal, Logger, EmydexFarmSystem) has one well-defined responsibility.
   ``` 
 ### O - Open/Closed Principle (OCP):
  ```text 
  New animal types can be added without modifying existing farm logic via polymorphism.
   ``` 
  ### L - Liskov Substitution Principle (LSP):
  
  ### I - Interface Segregation Principle (ISP):
    ```text
    IMilkableAnimal ensures only milkable animals implement milking behavior, keeping interfaces focused.
    ```
  D - Dependency Inversion Principle (DIP):

---


## OOPs Concepts
### Abstraction: 
```text
Common animal traits and behaviors are defined in the abstract Animal class to hide implementation details.
```
### Encapsulation: 
```text
Properties like Id and NoOfLegs are accessed via getters/setters to protect internal data.
```
### Inheritance: 
```text
Cow, Hen, Sheep, and Horse inherit from Animal to reuse shared logic.
```
### Polymorphism: 
```text
Each animal overrides the Talk() method, allowing uniform interaction with diverse behavior.
```

---


## DataStructure Used

### Queue<Animal>: 
```text
Maintains animals in the farm in a First-In-First-Out (FIFO) order for processing and releasing them sequentially.
```
### string: 
```text
Used extensively for properties like Id, logs, and configuration paths (e.g., Guid.NewGuid().ToString() for unique identifiers).
```
### EventHandler delegate: 
```text
Implements the Observer Pattern to notify when the farm becomes empty via the FarmEmpty event.
```
---


## Patterns Implemented
### Singleton Pattern: 
```text
Ensures a single, global instance of the FileLogger for consistent and centralized logging throughout the system.
```
### Observer Pattern: 
```text
Implements event-based communication using the FarmEmpty event, notifying subscribers when the farm is emptied.
```
---

# Project Structure Overview
```text
Emydex.FarmSystem.Test/
├── Solution Items/
│   ├── Test1Objective.txt
│   ├── Test2Objective.txt
│   ├── Test3Objective.txt
│   └── Test4Objective.txt
├── FarmSystem.Test/
│   ├── Properties/
│   ├── References/
│   ├── Interfaces/
│   │   └── IMilkableAnimal.cs
│   ├── Service/
│   │   └── MilkingAnimalService.cs
│   ├── Utilities/
│   │   ├── Utility.cs
│   │   └── Log/
│   │       ├── FileLogger.cs
│   │       └── ILogger.cs
│   ├── Animal.cs
│   ├── App.config
│   ├── Cow.cs
│   ├── EmydexFarmSystem.cs
│   ├── Hen.cs
│   ├── Horse.cs
│   ├── Program.cs
│   └── Sheep.cs

```

---


# Unit Tests
This project includes unit tests for all animal classes in the farm system. The tests verify that each animal produces the expected sound when the Talk() method is called. There is also a test case to ensure the system behaves correctly when no animals are present.

## Running Tests
The tests are written using NUnit framework.

You can run the tests directly within Visual Studio 2022 using the Test Explorer window.

Alternatively, tests can be run via the command line using the dotnet test command.

## Example test case
Each animal (Cow, Hen, Horse, Sheep) outputs its specific sound.

When there are no animals in the farm, the system produces no output, ensuring no unexpected behavior occurs.
```csharp
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
  }
```
