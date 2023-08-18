using BilRegistrering_s_app;
using BilRegistrering_s_app.Help_functions;
using System;
using System.Globalization;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;

class Program
{
    // List to store registered cars.
    private static List<Car> registeredCars = new List<Car>();

    // Entry point of the application, Displays the main menu and handles user interactions
    static void Main(string[] args)
    {
        IntroSequence.Show();
        int choice;
        do
        {
            choice = ShowMenu();
            switch (choice)
            {
                case 1:
                    RegisterCar();
                    break;
                case 2:
                    DisplayCustomerInfo();
                    break;
                case 3:
                    break;  // Exit
                default:
                    Console.WriteLine("Oops! Try again.");
                    break;
            }
        } while (choice != 3);
    }


    public static string ConvertToEnumValue(string userInput)
    {
        // Convert everything to lowercase
        userInput = userInput.ToLower();

        // Replacing spaces with underscores and replacing slashes and hyphens with underscores
        string formattedInput = userInput.Replace(" ", "_").Replace("/", "_").Replace("-", "_");

        // Convert the formatted input to the enum naming format
        // Splitting the input to extract the car name and date
        string[] parts = formattedInput.Split('_');
        string carName = string.Join("_", parts.Take(parts.Length - 3));  // All parts except the last three (date components)

        // Constructing the enum value
        string enumValue = carName + "_" + string.Join("_", parts.Skip(parts.Length - 3));

        return enumValue;
    }
    static void RegisterCar()
    {
        Console.Clear();

        Car newCar = new Car();

        while (true)
        {
            Console.Clear();
            Console.WriteLine("Register Car");
            Console.WriteLine("----------------");
            Console.Write("Enter car make (alphabets and spaces only): ");
            newCar.Make = Console.ReadLine();
            if (HelpFunctions.IsLetterAndSpacesOnly(newCar.Make))
            {
                break;
            }
            else
            {
                Console.WriteLine("Invalid car make. Please try again.");
                Thread.Sleep(1000);
                HelpFunctions.ClearNextLine();
            }
        }

        while (true)
        {
            Console.Clear();
            Console.Clear();
            Console.WriteLine("Create New User");
            Console.WriteLine("----------------\n");
            Console.Write("Enter car make: " + newCar.Make + "\n");
            Console.Write("Enter car model (alphabets and spaces only): ");
            newCar.Model = Console.ReadLine();
            if (HelpFunctions.IsLettersonly(newCar.Model))
            {
                break;
            }
            else
            {
                Console.WriteLine("Invalid car model. Please try again.");
                Thread.Sleep(1000);

                HelpFunctions.ClearNextLine();
            }
        }

        while (true)
        {
            Console.Clear();
            Console.WriteLine("Register Car");
            Console.WriteLine("----------------\n");
            Console.Write("Enter car make: " + newCar.Make + "\n");
            Console.Write("Enter car model: " + newCar.Model + "\n");
            Console.Write("Enter car manufacturing date (format dd-MM-yyyy): ");
            if (DateTime.TryParseExact(Console.ReadLine(), "dd-MM-yyyy", null, DateTimeStyles.None, out DateTime date))
            {
                newCar.ManufacturingDate = date;
                InspectionCheck(newCar);

                if (DateTime.Now.Year - newCar.ManufacturingDate.Year > 5)
                {
                    Console.Write("The car is older than 5 years. Please enter the date of the car's last service (format dd-MM-yyyy): ");
                    if (DateTime.TryParseExact(Console.ReadLine(), "dd-MM-yyyy", null, DateTimeStyles.None, out DateTime serviceDate))
                    {
                        newCar.LastServiceDate = serviceDate;
                    }
                    else
                    {
                        Console.WriteLine("Invalid date format for service date. Please try again.");
                        Thread.Sleep(1000);
                        HelpFunctions.ClearNextLine();
                        continue;
                    }
                }
                break;
            }
            else
            {
                Console.WriteLine("Invalid date format. Please try again.");
                Thread.Sleep(1000);
                HelpFunctions.ClearNextLine();
            }
        }


        while (true)
        {
            Console.Clear();
            Console.WriteLine("Create New User");
            Console.WriteLine("----------------\n");
            Console.Write("Enter car make " + newCar.Make + "\n");
            Console.Write("Enter car model " + newCar.Model + "\n");
            Console.Write("Enter car manufacturing date: " + newCar.ManufacturingDate.ToString("dd-MM-yyyy") + "\n");
            Console.Write("Enter car license plate (format XX12345): ");
            newCar.LicensePlate = Console.ReadLine();
            if (Regex.IsMatch(newCar.LicensePlate, @"^[A-Za-z]{2}\d{5}$"))
            {
                break;
            }
            else
            {
                Console.WriteLine("Invalid license plate format. Please try again.");
                Thread.Sleep(1000);

                HelpFunctions.ClearNextLine();
            }
        }

        while (true)
        {
            Console.Clear();
            Console.WriteLine("Register Car");
            Console.WriteLine("----------------\n");
            Console.Write("Enter car make: " + newCar.Make + "\n");
            Console.Write("Enter car model: " + newCar.Model + "\n");
            Console.Write("Enter car manufacturing date: " + newCar.ManufacturingDate.ToString("dd-MM-yyyy") + "\n");
            Console.Write("Enter car license plate: " + newCar.LicensePlate + "\n");
            Console.Write("Enter engine size (e.g. 1.6 for 1.6L): ");
            if (decimal.TryParse(Console.ReadLine(), out decimal engineSize))
            {
                newCar.EngineSize = engineSize;
                break;
            }
            else
            {
                Console.WriteLine("Invalid engine size. Please enter a valid number.");
                Thread.Sleep(1000);
                HelpFunctions.ClearNextLine();
            }
        }

        while (true)
        {
            Console.Clear();
            Console.WriteLine("Create New User");
            Console.WriteLine("----------------\n");
            Console.Write("Enter car make: " + newCar.Make + "\n");
            Console.Write("Enter car model: " + newCar.Model + "\n");
            Console.Write("Enter car manufacturing date: " + newCar.ManufacturingDate.ToString("dd-MM-yyyy") + "\n");
            Console.Write("Enter car license plate: " + newCar.LicensePlate + "\n");
            Console.Write("Enter engine type: " + newCar.EngineSize + "\n");
            Console.Write("Enter owner's name: ");
            newCar.FirstName = Console.ReadLine();
            if (HelpFunctions.IsLettersonly(newCar.FirstName))
            {
                break;
            }
            else
            {
                Console.WriteLine("Invalid contact info. Please try again.");
                Thread.Sleep(1000);

                HelpFunctions.ClearNextLine();
            }
        }

        while (true)
        {
            Console.Clear();
            Console.WriteLine("Create New User");
            Console.WriteLine("----------------\n");
            Console.Write("Enter car make: " + newCar.Make + "\n");
            Console.Write("Enter car model: " + newCar.Model + "\n");
            Console.Write("Enter car manufacturing date: " + newCar.ManufacturingDate.ToString("dd-MM-yyyy") + "\n");
            Console.Write("Enter car license plate: " + newCar.LicensePlate + "\n");
            Console.Write("Enter engine type: " + newCar.EngineSize + "\n");
            Console.Write("Enter owner's name: " + newCar.FirstName + "\n");
            Console.Write("Enter owner's last name: ");
            newCar.LastName = Console.ReadLine();
            if (HelpFunctions.IsLettersonly(newCar.LastName))
            {
                break;
            }
            else
            {
                Console.WriteLine("Invalid contact info. Please try again.");
                Thread.Sleep(1000);

                HelpFunctions.ClearNextLine();
            }
        }

        while (true)
        {
            Console.Clear();
            Console.WriteLine("Create New User");
            Console.WriteLine("----------------\n");
            Console.Write("Enter car make: " + newCar.Make + "\n");
            Console.Write("Enter car model: " + newCar.Model + "\n");
            Console.Write("Enter car manufacturing date: " + newCar.ManufacturingDate.ToString("dd-MM-yyyy") + "\n");
            Console.Write("Enter car license plate: " + newCar.LicensePlate + "\n");
            Console.Write("Enter engine type: " + newCar.EngineSize + "\n");
            Console.Write("Enter owner's name:" + newCar.FirstName + "\n");
            Console.Write("Enter owner's last name: " + newCar.LastName + "\n");
            Console.Write("Enter owner's Phonenumber: ");
            newCar.PhoneNumber = Console.ReadLine();
            if (HelpFunctions.IsDigitsOnly(newCar.PhoneNumber))
            {
                break;
            }
            else
            {
                Console.WriteLine("Invalid Phone number, try again.");
                Thread.Sleep(1000);

                HelpFunctions.ClearNextLine();
            }
        }

        while (true)
        {
            Console.Clear();
            Console.WriteLine("Create New User");
            Console.WriteLine("----------------\n");
            Console.Write("Enter car make:" + newCar.Make + "\n");
            Console.Write("Enter car model:" + newCar.Model + "\n");
            Console.Write("Enter car manufacturing date: " + newCar.ManufacturingDate.ToString("dd-MM-yyyy") + "\n");
            Console.Write("Enter car license plate: " + newCar.LicensePlate + "\n");
            Console.Write("Enter engine type: " + newCar.EngineSize + "\n");
            Console.Write("Enter owner's Name: " + newCar.FirstName + "\n");
            Console.Write("Enter owner's last name: " + newCar.LastName + "\n");
            Console.Write("Enter owner's Phonenumber: " + newCar.PhoneNumber + "\n");
            Console.Write("Enter repair requirements: ");
            newCar.RepairRequirements = Console.ReadLine();
            if (!string.IsNullOrWhiteSpace(newCar.RepairRequirements))
            {
                break;
            }
            else
            {
                Console.WriteLine("Invalid repair requirements. Please try again.");
                Thread.Sleep(1000);

                HelpFunctions.ClearNextLine();
            }
        }

        if (RecallCheck(newCar))
        {
            Console.WriteLine($"WARNING: This car ({newCar.Make} {newCar.Model} {newCar.ManufacturingDate:dd-MM-yyyy}) has a recall issue: {newCar.RecallDescription}. Please contact the manufacturer!");
        }
        else
        {
            Console.WriteLine("This car has no recall issues.");
        }

        if (newCar.RequiresSpecialInspection())
        {
            Console.WriteLine("This car requires a special inspection due to its age.");
        }

        registeredCars.Add(newCar);

        Console.WriteLine("\nCar registered successfully! Press any key to return to menu...");
        Console.ReadKey();
    }


    public static bool RecallCheck(Car car)
    {
        string recallCheck = $"{car.Make.Replace(" ", "_").ToLower()}_{car.Model.Replace(" ", "_").ToLower()}_{car.ManufacturingDate:dd_MM_yyyy}";

        if (Enum.TryParse(recallCheck, true, out RecalledCars recalledCar)) // Added the ignoreCase parameter to Enum.TryParse
        {
            var recallDescription = recalledCar.GetAttribute<DescriptionAttribute>().Description;
            car.RecallDescription = recallDescription; // Set the recall description here
            return true;
        }

        return false;
    }

    static string DisplayRegisteredCars()
    {
        StringBuilder registeredCarsList = new StringBuilder();

        if (!registeredCars.Any())
        {
            registeredCarsList.AppendLine("No cars registered.");
        }
        else
        {
            foreach (var car in registeredCars)
            {
                registeredCarsList.AppendLine($"{car.Make} {car.Model} - {car.LicensePlate}");
            }
        }

        return registeredCarsList.ToString().TrimEnd(); // Remove last newline for formatting purposes.
    }

    static void InspectionCheck(Car car)
    {
        if (car.RequiresSpecialInspection())
        {
            car.NeedsInspection = true;
            Console.WriteLine("\nThis car requires a special inspection.");
        }
        else
        {
            car.NeedsInspection = false;
            Console.WriteLine("\nThis car does not require a special inspection.");
        }
    }

    static void DisplayCustomerInfo()
    {
        Console.Clear();

        if (!registeredCars.Any()) // Checking if the list is empty
        {
            Console.WriteLine("No customers registered.");
        }
        else
        {
            Console.WriteLine("Registered Customers Info:");
            Console.WriteLine("--------------------------");
            foreach (var car in registeredCars)
            {
                Console.Write($"Name: {car.FirstName} {car.LastName} ");
                Console.Write($"Phone Number: {car.PhoneNumber} ");
                Console.WriteLine($"Car: {car.Make} {car.Model} - {car.ManufacturingDate:dd-MM-yyyy}\n");
            }
        }

        Console.WriteLine("\nPress any key to return to menu...");
        Console.ReadKey();
    }



    static int ShowMenu()
    {
        Console.Clear();
        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.WriteLine("╔════════════════════════════════════════════════════╗");
        Console.WriteLine("║          CAR REGISTRATION AND INSPECTION           ║");
        Console.WriteLine("╠════════════════════════════════════════════════════╣");

        // Maximum length for car text to ensure fixed borders
        int maxCarTextLength = 50;

        // Directly print all cars from the registeredCars list
        foreach (var car in registeredCars)
        {
            string carInfo = $"{car.Make} {car.Model} - {car.LicensePlate}";
            // Ensure car text is truncated or padded to fit within the width of the menu
            carInfo = carInfo.Length > maxCarTextLength ? carInfo.Substring(0, maxCarTextLength) : carInfo.PadRight(maxCarTextLength);
            Console.WriteLine($"║ {carInfo} ║");
        }

        Console.WriteLine("║                                                    ║");
        Console.WriteLine("║    1. Register a new car                           ║");
        Console.WriteLine("║                                                    ║");
        Console.WriteLine("║    2. Display customer info                        ║");
        Console.WriteLine("║                                                    ║");
        Console.WriteLine("║    3. Exit                                         ║");
        Console.WriteLine("╚════════════════════════════════════════════════════╝");
        Console.ForegroundColor = ConsoleColor.White;
        Console.Write("\nEnter your choice: ");
   
        ConsoleKeyInfo keyInfo = Console.ReadKey(intercept: true);
        while (keyInfo.Key != ConsoleKey.D1 && keyInfo.Key != ConsoleKey.NumPad1 &&
               keyInfo.Key != ConsoleKey.D2 && keyInfo.Key != ConsoleKey.NumPad2 &&
               keyInfo.Key != ConsoleKey.D3 && keyInfo.Key != ConsoleKey.NumPad3)
        {
            keyInfo = Console.ReadKey(intercept: true);
        }

        Console.WriteLine();

        switch (keyInfo.Key)
        {
            case ConsoleKey.D1:
            case ConsoleKey.NumPad1:
                return 1;
            case ConsoleKey.D2:
            case ConsoleKey.NumPad2:
                return 2;
            case ConsoleKey.D3:
            case ConsoleKey.NumPad3:
                return 3;
            default:
                return 0; // Invalid input
        }
    }
}
