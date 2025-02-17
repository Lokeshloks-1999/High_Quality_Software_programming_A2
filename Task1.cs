using System;
using System.Collections.Generic;

// Declaring a delegate to execute electrical tasks for each building.
public delegate void ElectricalTask(Building building);

class Task1
{
    static void Main()
    {
        // Creating a list to store all scheduled electrical jobs.
        List<Building> appointments = new List<Building>();

        // Displaying a welcome message and asking for the total number of customers.
        Console.WriteLine("Welcome to the Electrician Scheduling System");
        Console.Write("Enter the total number of customers: ");
        int customerCount = int.Parse(Console.ReadLine()); // Converting input to an integer.

        // Running a loop to collect details for each customer.
        for (int i = 0; i < customerCount; i++)
        {
            Console.WriteLine($"\nEnter the details of the customers {i + 1}:");

            // Asking for the customer's name.
            Console.Write("Name of the customer: ");
            string name = Console.ReadLine(); // Reading user input for the name.

            // Asking for the building type and ensuring it's a valid choice.
            string type;
            while (true)
            {
                Console.Write("Building Type (House, Barn, Garage): ");
                type = Console.ReadLine().ToLower(); // Converting input to lowercase for easy comparison.

                if (type == "house" || type == "barn" || type == "garage")
                {
                    break; // Exiting the loop if the input is valid.
                }

                // Displaying an error message if the input is invalid.
                Console.WriteLine("Please enter House, Barn, or Garage.");
            }

            // Asking for the size of the building and ensuring it within the allowed range.
            int size;
            while (true)
            {
                Console.Write("Enter size (1000 - 50000 sq.ft): ");
                if (int.TryParse(Console.ReadLine(), out size) && size >= 1000 && size <= 50000)
                {
                    break;
                }
                Console.WriteLine("Please enter a valid size between 1000 and 50000 sq.ft.");
            }





            // Asking for the number of light bulbs and ensuring it's within the limit.
            Console.Write("Number of Light Bulbs (Max 20): ");
            int bulbs = int.Parse(Console.ReadLine());

            while (bulbs < 1 || bulbs > 20) // Repeating if the input is out of range.
            {
                Console.Write("Please enter a number between 1 and 20: ");
                bulbs = int.Parse(Console.ReadLine());
            }

            // Asking for the number of outlets and ensuring it's within the limit.
            Console.Write("Number of Outlets (Max 50): ");
            int outlets = int.Parse(Console.ReadLine());

            while (outlets < 1 || outlets > 50) // Repeating if the input is out of range.
            {
                Console.Write("Please enter a number between 1 and 50: ");
                outlets = int.Parse(Console.ReadLine());
            }

            // Asking for the credit card number and ensuring it's exactly 16 digits.
            Console.Write("Credit Card (16-digit): ");
            string creditCard = Console.ReadLine();

            while (creditCard.Length != 16 || !long.TryParse(creditCard, out _)) // Checking if the input is 16 digits and numeric.
            {
                Console.Write("Enter a valid 16-digit Credit Card: ");
                creditCard = Console.ReadLine();
            }

            // Creating a building object based on the user's input.
            Building building = null;

            switch (type)
            {
                case "house":
                    building = new House { CustomerName = name, Size = size, LightBulbs = bulbs, Outlets = outlets, CreditCard = creditCard };
                    break;
                case "barn":
                    building = new Barn { CustomerName = name, Size = size, LightBulbs = bulbs, Outlets = outlets, CreditCard = creditCard };
                    break;
                case "garage":
                    building = new Garage { CustomerName = name, Size = size, LightBulbs = bulbs, Outlets = outlets, CreditCard = creditCard };
                    break;
            }

            // Adding the created building object to the list of appointments.
            appointments.Add(building);
        }

        // Sorting the appointments by building size before processing.
        appointments.Sort();

        // Creating a delegate function that handles all the electrical tasks for each appointment.
        ElectricalTask tasks = (building) =>
        {
            Console.WriteLine("\nCustomer details:");

            // Confirming that the wiring plan is ready.
            Console.WriteLine($"Wiring plan is ready for {building.CustomerName}'s {building.GetType().Name.ToLower()}.");

            // Confirming that all necessary parts have been purchased.
            Console.WriteLine($"All necessary parts for {building.CustomerName}'s {building.GetType().Name.ToLower()} are ready.");

            // Performing any special installation required for the building type.
            building.InstallSpecialEquipment();

            // Displaying a summary of the job.
            Console.WriteLine($"{building.CustomerName}, {building.GetType().Name.ToLower()}, {building.Size} sq.ft, {building.LightBulbs} bulbs, {building.Outlets} outlets, CC: {building.MaskCreditCard()}");
        };

        // Processing each appointment and executing the necessary tasks.
        Console.WriteLine("\nProcessing Appointments for customer\n");
        foreach (var appointment in appointments)
        {
            tasks(appointment); // Calling the delegate function for each customer.
        }

        // Confirming that all tasks have been successfully completed.
        Console.WriteLine("\ntasks completed successfully!");
    }
}
