using System;

// Creating an interface that defines the structure for electrical work.
public interface IElectricalWork
{
    int Size { get; set; } // Stores the size of the building in square feet.
    int LightBulbs { get; set; } // Stores the number of light bulbs required.
    int Outlets { get; set; } // Stores the number of outlets required.

    void CreateWiringSchema(); // Defines a method to create the wiring plan.
    void PurchaseParts(); // Defines a method to purchase required materials.
}

// Defining an abstract class that implements the interface and provides a base structure for all buildings.
public abstract class Building : IElectricalWork, IComparable<Building>
{
    // Properties to store building details
    public int Size { get; set; }
    public int LightBulbs { get; set; }
    public int Outlets { get; set; }
    public string CustomerName { get; set; } // Stores the customer's name.
    public string CreditCard { get; set; } // Stores the customer's credit card number.

    // Creating the wiring schema for the building
    public void CreateWiringSchema()
    {
        Console.WriteLine($"{CustomerName}: The wiring plan is ready!.");
    }

    // Purchasing necessary materials for electrical work
    public void PurchaseParts()
    {
        Console.WriteLine($"{CustomerName}: All required materials have been purchased");
    }

    // Declaring an abstract method that each building type will implement differently.
    public abstract void InstallSpecialEquipment();

    // Masking the credit card details for security before displaying them.
    public string MaskCreditCard()
    {
        return $"{CreditCard.Substring(0, 4)} XXXX XXXX {CreditCard.Substring(12,4)}"; // Hides the middle digits for privacy.
    }

    // Comparing buildings based on their size for sorting.
    public int CompareTo(Building other)
    {
        return this.Size.CompareTo(other.Size);
    }
}

// Creating a class for houses that inherits from Building and implements its  feature.
public class House : Building
{
    // Installing fire alarms specifically for houses.
    public override void InstallSpecialEquipment()
    {
        Console.WriteLine($"{CustomerName}: Fire alarms are set up and ready");
    }
}

// Creating a class for barns that inherits from Building and implements its  feature.
public class Barn : Building
{
    // Wiring the milking system specifically for barns.
    public override void InstallSpecialEquipment()
    {
        Console.WriteLine($"{CustomerName}: Milking system wiring is complete");
    }
}

// Creating a class for garages that inherits from Building and implements its  feature.
public class Garage : Building
{
    // Installing automatic doors specifically for garages.
    public override void InstallSpecialEquipment()
    {
        Console.WriteLine($"{CustomerName}: Automatic doors have been successfully installed");
    }
}

