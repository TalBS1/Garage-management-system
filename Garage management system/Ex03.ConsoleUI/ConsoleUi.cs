using System;
using System.Collections.Generic;
using System.Linq;
using Ex03.GarageLogic;
namespace Ex03.ConsoleUI
{
    public class Program
    {
        public static void Main()
        {
            ConsoleUi ui = new ConsoleUi();
            ui.Run();
        }
    }
    public class ConsoleUi
    {
        private readonly Garage r_MGarage;
        public ConsoleUi()
        {
            r_MGarage = new Garage();
        }

        public void Run()
        {
            bool exit = false;

            while (!exit)
            {
                Console.WriteLine("\nGarage Management System");
                Console.WriteLine("1. Add a vehicle");
                Console.WriteLine("2. Show vehicle list");
                Console.WriteLine("3. Update vehicle state");
                Console.WriteLine("4. Inflate wheels to max");
                Console.WriteLine("5. Refuel vehicle");
                Console.WriteLine("6. Recharge electric vehicle");
                Console.WriteLine("7. Show vehicle details");
                Console.WriteLine("8. Exit");
                Console.Write("Choose an option: ");

                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        addVehicle();
                        break;
                    case "2":
                        showVehicleList();
                        break;
                    case "3":
                        updateVehicleState();
                        break;
                    case "4":
                        inflateWheels();
                        break;
                    case "5":
                        refuelVehicle();
                        break;
                    case "6":
                        rechargeVehicle();
                        break;
                    case "7":
                        showVehicleDetails();
                        break;
                    case "8":
                        exit = true;
                        Console.WriteLine("Exiting Garage Management System. Goodbye!");
                        break;
                    default:
                        Console.WriteLine("Invalid option. Please try again.");
                        break;
                }
            }
        }
        private static eLicenseType getLicenseTypeFromUser()
        {
            while (true)
            {
                Console.Write("Enter license type (A1, A2, B1, B2): ");
                string input = Console.ReadLine();
                if (!string.IsNullOrEmpty(input) && !input.All(char.IsDigit))
                {
                    if (Enum.TryParse(input, out eLicenseType licenseType)
                       && Enum.IsDefined(typeof(eLicenseType), licenseType))
                    {
                        return licenseType;
                    }
                }

                Console.WriteLine("Invalid license type. Please choose A1, A2, B1, or B2.");
            }
        }

        private static int getEngineVolumeFromUser()
        {
            while (true)
            {
                Console.Write("Enter engine volume (cc): ");
                if (int.TryParse(Console.ReadLine(), out int engineVolume) && engineVolume > 0)
                {
                    return engineVolume;
                }
                Console.WriteLine("Invalid engine volume. Please enter a positive integer.");
            }
        }

        private static eCarColor getCarColorFromUser()
        {
            while (true)
            {
                Console.Write("Enter car color (Black, White, Gray, Blue): ");
                string input = Console.ReadLine();
                if (!string.IsNullOrEmpty(input) && !input.All(char.IsDigit))
                {
                    if (Enum.TryParse(input, out eCarColor carColor) && Enum.IsDefined(typeof(eCarColor), carColor))
                    {
                        return carColor;
                    }
                }

                Console.WriteLine("Invalid car color. Please choose Black, White, Gray, or Blue.");
            }
        }

        private static int getNumberOfDoorsFromUser()
        {
            while (true)
            {
                Console.Write("Enter number of doors (2-5): ");
                if (int.TryParse(Console.ReadLine(), out int numberOfDoors) && numberOfDoors >= 2 && numberOfDoors <= 5)
                {
                    return numberOfDoors;
                }
                Console.WriteLine("Invalid number of doors. Please enter a number between 2 and 5.");
            }
        }

        public void addVehicle()
        {
            try
            {
                string licenseNumber;
                do
                {
                    Console.Write("Enter license number: ");
                    licenseNumber = Console.ReadLine();
                } while (string.IsNullOrWhiteSpace(licenseNumber));

                if (r_MGarage.IsVehicleExists(licenseNumber))
                {
                    Console.WriteLine("Vehicle already exists in the garage. Changing its state to 'In Repair'.");
                    r_MGarage.UpdateVehicleState(licenseNumber, eVehicleState.InRepair);
                    return;
                }

                Console.WriteLine("\nAdding a new vehicle...");
                Console.WriteLine("Available vehicle types:");

                var vehicleTypes = VehicleFactory.GetSupportedVehicleTypes();
                for (int i = 0; i < vehicleTypes.Count; i++)
                {
                    Console.WriteLine($"{i + 1}. {vehicleTypes[i]}");
                }

                int vehicleTypeChoice;
                do
                {
                    Console.Write("Choose a vehicle type (1-{vehicleTypes.Count}): ");
                } while (!int.TryParse(Console.ReadLine(), out vehicleTypeChoice) || vehicleTypeChoice < 1 || vehicleTypeChoice > vehicleTypes.Count);

                eVehicleType chosenType = vehicleTypes[vehicleTypeChoice - 1];

                Dictionary<string, string> vehicleQuestions = VehicleFactory.GetVehicleQuestions(chosenType);
                List<object> parameters = new List<object>();

                Console.Write("Enter the model name of the vehicle: ");
                parameters.Add(Console.ReadLine()); // Model name input
                foreach (var question in vehicleQuestions)
                {
                    Console.Write(question.Key);
                    string input = Console.ReadLine();
                    parameters.Add(input);
                }

                string ownerName;
                do
                {
                    Console.Write("Enter owner name: ");
                    ownerName = Console.ReadLine();
                } while (string.IsNullOrWhiteSpace(ownerName));

                string ownerPhone;
                do
                {
                    Console.Write("Enter owner phone: ");
                    ownerPhone = Console.ReadLine();
                } while (string.IsNullOrWhiteSpace(ownerPhone));

                Vehicle newVehicle = VehicleFactory.CreateVehicle(chosenType, parameters[0].ToString(), parameters.Skip(1).ToArray());
                r_MGarage.AddVehicle(licenseNumber, newVehicle, ownerName, ownerPhone);

                Console.WriteLine("Vehicle added successfully!");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error adding vehicle: {ex.Message}");
            }
        }




        //private void addVehicle()
        //{
        //    Console.Write("Enter license number: ");
        //    string licenseNumber = Console.ReadLine();

        //    if (r_MGarage.IsVehicleExists(licenseNumber))
        //    {
        //        Console.WriteLine("Vehicle already exists in the garage. Changing its state to 'In Repair'.");
        //        r_MGarage.UpdateVehicleState(licenseNumber, eVehicleState.InRepair);
        //        return;
        //    }

        //    Console.WriteLine("\nAdding a new vehicle...");
        //    Console.WriteLine("Available vehicle types:");

        //    var vehicleTypes = VehicleFactory.GetSupportedVehicleTypes();
        //    for (int i = 0; i < vehicleTypes.Count; i++)
        //    {
        //        Console.WriteLine($"{i + 1}. {vehicleTypes[i]}");
        //    }

        //    eVehicleType chosenType;
        //    while (true)
        //    {
        //        Console.Write("Choose a vehicle type (1-5): ");
        //        if (int.TryParse(Console.ReadLine(), out int vehicleTypeChoice) && vehicleTypeChoice >= 1 && vehicleTypeChoice <= vehicleTypes.Count)
        //        {
        //            chosenType = vehicleTypes[vehicleTypeChoice - 1];
        //            break;
        //        }
        //        else
        //        {
        //            Console.WriteLine("Invalid choice. Please try again.");
        //        }
        //    }

        //    List<object> parameters = new List<object>();

        //    float maxAirPressure;

        //    switch (chosenType)
        //    {
        //        case eVehicleType.RegularMotorcycle:
        //        case eVehicleType.ElectricMotorcycle:
        //            maxAirPressure = 32;
        //            break;
        //        case eVehicleType.RegularCar:
        //        case eVehicleType.ElectricCar:
        //            maxAirPressure = 34;
        //            break;
        //        case eVehicleType.Truck:
        //            maxAirPressure = 29;
        //            break;
        //        default:
        //            throw new ArgumentOutOfRangeException();
        //    }

        //    Console.Write("Enter the model name of the vehicle: ");
        //    string modelName = Console.ReadLine();
        //    parameters.Add(modelName);
        //    Console.Write("Enter the manufacturer name for the wheels: ");
        //    string manufacturerWheelName = Console.ReadLine();
        //    Console.Write($"Enter the same air pressure for all wheels (Max: {maxAirPressure}): ");
        //    float wheelPressure;

        //    while (!float.TryParse(Console.ReadLine(), out wheelPressure) || wheelPressure <= 0 || wheelPressure > maxAirPressure)
        //    {
        //        Console.WriteLine($"Invalid air pressure. Please enter a positive number up to {maxAirPressure}.");
        //        Console.Write($"Enter the same air pressure for all wheels (Max: {maxAirPressure}): ");
        //    }

        //    switch (chosenType)
        //    {
        //        case eVehicleType.RegularMotorcycle:

        //            parameters.Add(getLicenseTypeFromUser());
        //            parameters.Add(getEngineVolumeFromUser());

        //            while (true)
        //            {
        //                Console.Write("Enter current fuel amount (liters, Max: 6.2): ");
        //                string input = Console.ReadLine();
        //                bool isValid = float.TryParse(input, out float fuelAmount) && fuelAmount >= 0 && fuelAmount <= 6.2f;
        //                if (isValid)
        //                {
        //                    parameters.Add(fuelAmount);
        //                    break;
        //                }
        //                else
        //                {
        //                    Console.WriteLine("Invalid fuel amount. Please enter a value between 0 and 6.2 liters.");
        //                }
        //            }
        //            break;

        //        case eVehicleType.ElectricMotorcycle:
        //            parameters.Add(getLicenseTypeFromUser());
        //            parameters.Add(getEngineVolumeFromUser());

        //            while (true)
        //            {
        //                Console.Write("Enter battery time in hours (Max: 2.9): ");
        //                string input = Console.ReadLine();
        //                bool isValid = float.TryParse(input, out float batteryTime) && batteryTime >= 0 && batteryTime <= 2.9f;
        //                if (isValid)
        //                {
        //                    parameters.Add(batteryTime);
        //                    break;
        //                }
        //                else
        //                {
        //                    Console.WriteLine("Invalid battery time. Please enter a value between 0 and 2.9 hours.");
        //                }
        //            }
        //            break;


        //        case eVehicleType.RegularCar:
        //            parameters.Add(getCarColorFromUser());
        //            parameters.Add(getNumberOfDoorsFromUser());

        //            while (true)
        //            {
        //                Console.Write("Enter current fuel amount (liters, Max: 52): ");
        //                string input = Console.ReadLine();
        //                bool isValid = float.TryParse(input, out float fuelAmount) && fuelAmount >= 0 && fuelAmount <= 52f;
        //                if (isValid)
        //                {
        //                    parameters.Add(fuelAmount);
        //                    break;
        //                }
        //                else
        //                {
        //                    Console.WriteLine("Invalid fuel amount. Please enter a value between 0 and 52 liters.");
        //                }
        //            }
        //            break;

        //        case eVehicleType.ElectricCar:
        //            parameters.Add(getCarColorFromUser());
        //            parameters.Add(getNumberOfDoorsFromUser());

        //            while (true)
        //            {
        //                Console.Write("Enter battery time in hours (Max: 5.4): ");
        //                string input = Console.ReadLine();
        //                bool isValid = float.TryParse(input, out float batteryTime) && batteryTime >= 0 && batteryTime <= 5.4f;
        //                if (isValid)
        //                {
        //                    parameters.Add(batteryTime);
        //                    break;
        //                }
        //                else
        //                {
        //                    Console.WriteLine("Invalid battery time. Please enter a value between 0 and 5.4 hours.");
        //                }
        //            }
        //            break;

        //        case eVehicleType.Truck:
        //            while (true)
        //            {
        //                Console.Write("Is the truck carrying refrigerated materials? (true/false): ");
        //                string input = Console.ReadLine();
        //                if (bool.TryParse(input, out bool isRefrigerated))
        //                {
        //                    parameters.Add(isRefrigerated);
        //                    break;
        //                }
        //                else
        //                {
        //                    Console.WriteLine("Invalid input. Please enter true or false.");
        //                }
        //            }

        //            while (true)
        //            {
        //                Console.Write("Enter cargo volume (cubic meters): ");
        //                string input = Console.ReadLine();
        //                bool isValid = float.TryParse(input, out float cargoVolume) && cargoVolume > 0;
        //                if (isValid)
        //                {
        //                    parameters.Add(cargoVolume);
        //                    break;
        //                }
        //                else
        //                {
        //                    Console.WriteLine("Invalid cargo volume. Please enter a positive number.");
        //                }
        //            }

        //            while (true)
        //            {
        //                Console.Write("Enter current fuel amount (liters, Max: 125): ");
        //                string input = Console.ReadLine();
        //                bool isValid = float.TryParse(input, out float fuelAmount) && fuelAmount >= 0 && fuelAmount <= 125f;
        //                if (isValid)
        //                {
        //                    parameters.Add(fuelAmount);
        //                    break;
        //                }
        //                else
        //                {
        //                    Console.WriteLine("Invalid fuel amount. Please enter a value between 0 and 125 liters.");
        //                }
        //            }
        //            break;
        //    }

        //    Console.Write("Enter owner name: ");
        //    string ownerName = Console.ReadLine();

        //    Console.Write("Enter owner phone number: ");
        //    while (true)
        //    {
        //        string ownerPhone = Console.ReadLine();
        //        bool isValidPhone = true;

        //        foreach (char c in ownerPhone)
        //        {
        //            if (!char.IsDigit(c))
        //            {
        //                isValidPhone = false;
        //                break;
        //            }
        //        }

        //        if (!string.IsNullOrEmpty(ownerPhone) && isValidPhone)
        //        {
        //            try
        //            {
        //                Vehicle newVehicle = VehicleFactory.CreateVehicle(chosenType, parameters.ToArray());
        //                foreach (Wheel wheel in newVehicle.Wheels)
        //                {
        //                    if (wheelPressure > wheel.MaxAirPressure)
        //                    {
        //                        throw new ValueOutOfRangeException(0, wheel.MaxAirPressure, "Air pressure exceeds the maximum limit.");
        //                    }
        //                    wheel.CurrentAirPressure = wheelPressure;
        //                }
        //                r_MGarage.AddVehicle(licenseNumber, newVehicle, ownerName, ownerPhone, manufacturerWheelName);
        //                Console.WriteLine("Vehicle added successfully!");
        //                break;
        //            }
        //            catch (Exception ex)
        //            {
        //                Console.WriteLine($"Error adding vehicle: {ex.Message}");
        //            }
        //        }
        //        else
        //        {
        //            Console.WriteLine("Invalid phone number. Please enter a valid numeric phone number.");
        //        }
        //    }
        //}
        private void showVehicleList()
        {
            while (true)
            {
                Console.WriteLine("\nShow vehicles by state:");
                Console.WriteLine("1. In Repair");
                Console.WriteLine("2. Fixed");
                Console.WriteLine("3. Paid");
                Console.WriteLine("4. All");
                Console.Write("Choose an option: ");

                if (int.TryParse(Console.ReadLine(), out int choice) && choice >= 1 && choice <= 4)
                {
                    eVehicleState? stateFilter = choice < 4 ? (eVehicleState?)(choice - 1) : null;

                    var vehicles = stateFilter.HasValue
                        ? r_MGarage.GetVehiclesByState(stateFilter.Value)
                        : r_MGarage.GetAllVehicles();

                    if (vehicles.Count == 0)
                    {
                        Console.WriteLine("No vehicles found.");
                    }
                    else
                    {
                        Console.WriteLine("Vehicles:");
                        foreach (string licenseNumber in vehicles)
                        {
                            Console.WriteLine(licenseNumber);
                        }
                    }
                    break;
                }
                else
                {
                    Console.WriteLine("Invalid choice. Please try again.");
                }
            }
        }
        private void updateVehicleState()
        {
            while (true)
            {
                Console.Write("\nEnter license number: ");
                string licenseNumber = Console.ReadLine();

                Console.WriteLine("Choose new state:");
                Console.WriteLine("1. In Repair");
                Console.WriteLine("2. Fixed");
                Console.WriteLine("3. Paid");
                Console.Write("Enter your choice: ");

                if (int.TryParse(Console.ReadLine(), out int stateChoice) && stateChoice >= 1 && stateChoice <= 3)
                {
                    eVehicleState newState = (eVehicleState)(stateChoice - 1);

                    try
                    {
                        r_MGarage.UpdateVehicleState(licenseNumber, newState);
                        Console.WriteLine("Vehicle state updated successfully!");
                        break;
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"Error updating vehicle state: {ex.Message}");
                    }
                }
                else
                {
                    Console.WriteLine("Invalid choice. Please try again.");
                }
            }
        }

        private void inflateWheels()
        {
            while (true)
            {
                Console.Write("\nEnter license number: ");
                string licenseNumber = Console.ReadLine();

                try
                {
                    r_MGarage.InflateWheelsToMax(licenseNumber);
                    Console.WriteLine("Wheels inflated to maximum pressure successfully!");
                    break;
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error inflating wheels: {ex.Message}");
                }
            }
        }
        private void refuelVehicle()
        {
            while (true)
            {
                Console.Write("\nEnter license number: ");
                string licenseNumber = Console.ReadLine();

                Console.Write("Enter fuel type (Octan95, Octan98, Soler): ");
                string fuelType = Console.ReadLine();

                Console.Write("Enter amount of fuel to add: ");

                if (float.TryParse(Console.ReadLine(), out float amountToAdd) && amountToAdd > 0)
                {
                    try
                    {
                        r_MGarage.RefuelVehicle(licenseNumber, fuelType, amountToAdd);
                        Console.WriteLine("Vehicle refueled successfully!");
                        break;
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"Error refueling vehicle: {ex.Message}");
                    }
                }

                else
                {
                    Console.WriteLine("Invalid fuel amount. Please try again.");
                }
            }
        }

        private void rechargeVehicle()
        {
            while (true)
            {
                Console.Write("\nEnter license number: ");
                string licenseNumber = Console.ReadLine();

                Console.Write("Enter charge amount (in hours): ");

                if (float.TryParse(Console.ReadLine(), out float chargeAmount) && chargeAmount > 0)
                {
                    try
                    {
                        r_MGarage.RechargeVehicle(licenseNumber, chargeAmount);
                        Console.WriteLine("Vehicle recharged successfully!");
                        break;
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"Error recharging vehicle: {ex.Message}");
                    }
                }

                else
                {
                    Console.WriteLine("Invalid charge amount. Please try again.");
                }
            }
        }

        private void showVehicleDetails()
        {

            while (true)
            {
                Console.Write("\nEnter license number: ");
                string licenseNumber = Console.ReadLine();

                try
                {
                    string details = r_MGarage.GetVehicleDetails(licenseNumber);
                    Console.WriteLine($"\nVehicle Details:\n{details}");
                    break;
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error fetching vehicle details: {ex.Message}");
                }
            }
        }
    }

    //public class Program
    //{
    //    public static void Main()
    //    {
    //        ConsoleUi ui = new ConsoleUi();
    //        ui.Run();
    //    }
    //}
    //public class ConsoleUi
    //{
    //    private readonly Garage r_MGarage;

    //    public ConsoleUi()
    //    {
    //        r_MGarage = new Garage();

    //    }

    //    public void Run()
    //    {
    //        bool exit = false;
    //        while (!exit)
    //        {
    //            Console.WriteLine("\nGarage Management System");
    //            Console.WriteLine("1. Add a vehicle");
    //            Console.WriteLine("2. Show vehicle list");
    //            Console.WriteLine("3. Update vehicle state");
    //            Console.WriteLine("4. Inflate wheels to max");
    //            Console.WriteLine("5. Refuel vehicle");
    //            Console.WriteLine("6. Recharge electric vehicle");
    //            Console.WriteLine("7. Show vehicle details");
    //            Console.WriteLine("8. Exit");
    //            Console.Write("Choose an option: ");

    //            string choice = Console.ReadLine();

    //            switch (choice)
    //            {
    //                case "1":
    //                    addVehicle();
    //                    break;
    //                case "2":
    //                    showVehicleList();
    //                    break;
    //                case "3":
    //                    updateVehicleState();
    //                    break;
    //                case "4":
    //                    inflateWheels();
    //                    break;
    //                case "5":
    //                    refuelVehicle();
    //                    break;
    //                case "6":
    //                    rechargeVehicle();
    //                    break;
    //                case "7":
    //                    showVehicleDetails();
    //                    break;
    //                case "8":
    //                    exit = true;
    //                    Console.WriteLine("Exiting Garage Management System. Goodbye!");
    //                    break;
    //                default:
    //                    Console.WriteLine("Invalid option. Please try again.");
    //                    break;
    //            }
    //        }
    //    }

    //private void addVehicle()
    //{
    //    try
    //    {
    //        Console.Write("Enter license number: ");
    //        string licenseNumber = Console.ReadLine();

    //        if (r_MGarage.IsVehicleExists(licenseNumber))
    //        {
    //            Console.WriteLine("Vehicle already exists in the garage. Changing its state to 'In Repair'.");
    //            r_MGarage.UpdateVehicleState(licenseNumber, eVehicleState.InRepair);
    //            return;
    //        }

    //        Console.WriteLine("\nAdding a new vehicle...");
    //        Console.WriteLine("Available vehicle types:");

    //        var vehicleTypes = VehicleFactory.GetSupportedVehicleTypes();
    //        for (int i = 0; i < vehicleTypes.Count; i++)
    //        {
    //            Console.WriteLine($"{i + 1}. {vehicleTypes[i]}");
    //        }

    //        Console.Write("Choose a vehicle type (1-5): ");
    //        int vehicleTypeChoice = int.Parse(Console.ReadLine());
    //        eVehicleType chosenType = vehicleTypes[vehicleTypeChoice - 1];

    //        Dictionary<string, string> questions = VehicleFactory.GetVehicleQuestions(chosenType);
    //        List<object> parameters = new List<object>();
    //        foreach (var question in questions)
    //        {
    //            Console.Write(question.Value);
    //            string input = Console.ReadLine();
    //            parameters.Add(input);
    //        }

    //        Console.Write("Enter owner name: ");
    //        string ownerName = Console.ReadLine();

    //        Console.Write("Enter owner phone: ");
    //        string ownerPhone = Console.ReadLine();
    //        Vehicle newVehicle = VehicleFactory.CreateVehicle(chosenType, parameters[0].ToString(), parameters.Skip(1).ToArray());
    //        r_MGarage.AddVehicle(licenseNumber, newVehicle, ownerName, ownerPhone);

    //        Console.WriteLine("Vehicle added successfully!");
    //    }
    //    catch (Exception ex)
    //    {
    //        Console.WriteLine($"Error adding vehicle: {ex.Message}");
    //    }
    //}

    //    public void addVehicle()
    //    {
    //        try
    //        {
    //            string licenseNumber;
    //            do
    //            {
    //                Console.Write("Enter license number: ");
    //                licenseNumber = Console.ReadLine();
    //            } while (string.IsNullOrWhiteSpace(licenseNumber));

    //            if (r_MGarage.IsVehicleExists(licenseNumber))
    //            {
    //                Console.WriteLine("Vehicle already exists in the garage. Changing its state to 'In Repair'.");
    //                r_MGarage.UpdateVehicleState(licenseNumber, eVehicleState.InRepair);
    //                return;
    //            }

    //            Console.WriteLine("\nAdding a new vehicle...");
    //            Console.WriteLine("Available vehicle types:");

    //            var vehicleTypes = VehicleFactory.GetSupportedVehicleTypes();
    //            for (int i = 0; i < vehicleTypes.Count; i++)
    //            {
    //                Console.WriteLine($"{i + 1}. {vehicleTypes[i]}");
    //            }

    //            int vehicleTypeChoice;
    //            do
    //            {
    //                Console.Write("Choose a vehicle type (1-5): ");
    //            } while (!int.TryParse(Console.ReadLine(), out vehicleTypeChoice) || vehicleTypeChoice < 1 || vehicleTypeChoice > vehicleTypes.Count);

    //            eVehicleType chosenType = vehicleTypes[vehicleTypeChoice - 1];

    //            Dictionary<string, string> questions = VehicleFactory.GetVehicleQuestions(chosenType);
    //            List<object> parameters = new List<object>();
    //            foreach (var question in questions)
    //            {
    //                string input;
    //                do
    //                {
    //                    Console.Write(question.Value);
    //                    input = Console.ReadLine();
    //                } while (string.IsNullOrWhiteSpace(input));

    //                try
    //                {
    //                    if (question.Key.ToLower().Contains("fuel") || question.Key.ToLower().Contains("volume") || question.Key.ToLower().Contains("pressure"))
    //                    {
    //                        parameters.Add(Convert.ChangeType(input, typeof(float)));
    //                    }
    //                    else if (question.Key.ToLower().Contains("doors"))
    //                    {
    //                        parameters.Add(Convert.ChangeType(input, typeof(int)));
    //                    }
    //                    else if (question.Key.ToLower().Contains("cooling"))
    //                    {
    //                        parameters.Add(Convert.ChangeType(input, typeof(bool)));
    //                    }
    //                    else if (question.Key.ToLower().Contains("license type"))
    //                    {
    //                        if (Enum.TryParse<eLicenseType>(input, true, out eLicenseType licenseType))
    //                        {
    //                            parameters.Add(licenseType);
    //                        }
    //                        else
    //                        {
    //                            throw new FormatException("Invalid license type input.");
    //                        }
    //                    }
    //                    else
    //                    {
    //                        parameters.Add(input);
    //                    }
    //                }
    //                catch (Exception)
    //                {
    //                    Console.WriteLine($"Invalid input for {question.Key}. Please try again.");
    //                    continue;
    //                }
    //            }

    //            string ownerName;
    //            do
    //            {
    //                Console.Write("Enter owner name: ");
    //                ownerName = Console.ReadLine();
    //            } while (string.IsNullOrWhiteSpace(ownerName));

    //            string ownerPhone;
    //            do
    //            {
    //                Console.Write("Enter owner phone: ");
    //                ownerPhone = Console.ReadLine();
    //            } while (string.IsNullOrWhiteSpace(ownerPhone));

    //            Vehicle newVehicle = VehicleFactory.CreateVehicle(chosenType, parameters[0].ToString(), parameters.Skip(1).ToArray());
    //            r_MGarage.AddVehicle(licenseNumber, newVehicle, ownerName, ownerPhone);

    //            Console.WriteLine("Vehicle added successfully!");
    //        }
    //        catch (Exception ex)
    //        {
    //            Console.WriteLine($"Error adding vehicle: {ex.Message}");
    //        }
    //    }
    //    private void showVehicleList()
    //    {
    //        try
    //        {
    //            List<string> vehicles = r_MGarage.GetAllVehicles();
    //            if (vehicles.Count == 0)
    //            {
    //                Console.WriteLine("No vehicles found.");
    //            }
    //            else
    //            {
    //                Console.WriteLine("Vehicles:");
    //                foreach (string licenseNumber in vehicles)
    //                {
    //                    Console.WriteLine(licenseNumber);
    //                }
    //            }
    //        }
    //        catch (Exception ex)
    //        {
    //            Console.WriteLine($"Error showing vehicle list: {ex.Message}");
    //        }
    //    }

    //    private void updateVehicleState()
    //    {
    //        try
    //        {
    //            Console.Write("Enter license number: ");
    //            string licenseNumber = Console.ReadLine();

    //            Console.WriteLine("Choose new state: 1. In Repair 2. Fixed 3. Paid");
    //            int stateChoice = int.Parse(Console.ReadLine()) - 1;
    //            r_MGarage.UpdateVehicleState(licenseNumber, (eVehicleState)stateChoice);
    //            Console.WriteLine("Vehicle state updated successfully!");
    //        }
    //        catch (Exception ex)
    //        {
    //            Console.WriteLine($"Error updating vehicle state: {ex.Message}");
    //        }
    //    }

    //    private void inflateWheels()
    //    {
    //        try
    //        {
    //            Console.Write("Enter license number: ");
    //            string licenseNumber = Console.ReadLine();
    //            r_MGarage.InflateWheelsToMax(licenseNumber);
    //            Console.WriteLine("Wheels inflated successfully!");
    //        }
    //        catch (Exception ex)
    //        {
    //            Console.WriteLine($"Error inflating wheels: {ex.Message}");
    //        }
    //    }

    //    private void refuelVehicle()
    //    {
    //        try
    //        {
    //            Console.Write("Enter license number: ");
    //            string licenseNumber = Console.ReadLine();
    //            Console.Write("Enter fuel type: ");
    //            string fuelType = Console.ReadLine();
    //            Console.Write("Enter amount to refuel: ");
    //            float amount = float.Parse(Console.ReadLine());

    //            r_MGarage.RefuelVehicle(licenseNumber, fuelType, amount);
    //            Console.WriteLine("Vehicle refueled successfully!");
    //        }
    //        catch (Exception ex)
    //        {
    //            Console.WriteLine($"Error refueling vehicle: {ex.Message}");
    //        }
    //    }

    //    private void rechargeVehicle()
    //    {
    //        try
    //        {
    //            Console.Write("Enter license number: ");
    //            string licenseNumber = Console.ReadLine();
    //            Console.Write("Enter charge amount: ");
    //            float chargeAmount = float.Parse(Console.ReadLine());

    //            r_MGarage.RechargeVehicle(licenseNumber, chargeAmount);
    //            Console.WriteLine("Vehicle recharged successfully!");
    //        }
    //        catch (Exception ex)
    //        {
    //            Console.WriteLine($"Error recharging vehicle: {ex.Message}");
    //        }
    //    }

    //    private void showVehicleDetails()
    //    {
    //        try
    //        {
    //            Console.Write("Enter license number: ");
    //            string licenseNumber = Console.ReadLine();
    //            string details = r_MGarage.GetVehicleDetails(licenseNumber);
    //            Console.WriteLine(details);
    //        }
    //        catch (Exception ex)
    //        {
    //            Console.WriteLine($"Error fetching vehicle details: {ex.Message}");
    //        }
    //    }
    //}

}