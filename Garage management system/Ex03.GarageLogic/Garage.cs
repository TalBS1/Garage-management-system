using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic
{
    public class Garage
    {
        private readonly Dictionary<string, Vehicle> r_Vehicles = new Dictionary<string, Vehicle>(); // Stores vehicles by license number.
        private readonly Dictionary<string, eVehicleState> r_VehicleStates = new Dictionary<string, eVehicleState>(); // Tracks vehicle states.
        private readonly Dictionary<string, (string OwnerName, string OwnerPhone)> r_OwnerDetails = new Dictionary<string, (string, string)>(); // Tracks owner details.

        // Adds a vehicle to the garage or updates its state if it already exists.
        public void AddVehicle(string i_LicenseNumber, Vehicle i_Vehicle, string i_OwnerName, string i_OwnerPhone)
        {

            if (r_Vehicles.ContainsKey(i_LicenseNumber))
            {
                r_VehicleStates[i_LicenseNumber] = eVehicleState.InRepair;
                Console.WriteLine($"Vehicle with license number {i_LicenseNumber} already exists. Its state has been updated to InRepair.");
            }

            else
            {
                r_Vehicles[i_LicenseNumber] = i_Vehicle;
                r_VehicleStates[i_LicenseNumber] = eVehicleState.InRepair;
                r_OwnerDetails[i_LicenseNumber] = (i_OwnerName, i_OwnerPhone);
            }

        }
        public List<string> GetVehiclesByState(eVehicleState i_State)
        {
            List<string> vehicles = new List<string>();
            foreach (var vehicle in r_VehicleStates)
            {
                if (vehicle.Value == i_State)
                {
                    vehicles.Add(vehicle.Key);
                }
            }
            return vehicles;
        }
        public List<string> GetAllVehicles()
        {
            return new List<string>(r_Vehicles.Keys);
        }
        public bool IsVehicleExists(string i_LicenseNumber)
        {
            return r_Vehicles.ContainsKey(i_LicenseNumber);
        }
        public void UpdateVehicleState(string i_LicenseNumber, eVehicleState i_NewState)
        {
            if (!r_Vehicles.ContainsKey(i_LicenseNumber))
            {
                throw new ArgumentException("Vehicle not found in the garage.");
            }
            r_VehicleStates[i_LicenseNumber] = i_NewState;
        }
        public void InflateWheelsToMax(string i_LicenseNumber)
        {
            if (!r_Vehicles.ContainsKey(i_LicenseNumber))
            {
                throw new ArgumentException("Vehicle not found in the garage.");
            }

            Vehicle vehicle = r_Vehicles[i_LicenseNumber];
            foreach (Wheel wheel in vehicle.Wheels)
            {
                wheel.Inflate(wheel.MaxAirPressure - wheel.CurrentAirPressure);
            }
        }

        public void RefuelVehicle(string i_LicenseNumber, string i_FuelType, float i_AmountToFuel)
        {
            if (!r_Vehicles.ContainsKey(i_LicenseNumber))
            {
                throw new ArgumentException("Vehicle not found in the garage.");
            }

            Vehicle vehicle = r_Vehicles[i_LicenseNumber];
            vehicle.Refuel(i_AmountToFuel, i_FuelType);
        }
        public void RechargeVehicle(string i_LicenseNumber, float i_ChargeAmount)
        {
            if (!r_Vehicles.ContainsKey(i_LicenseNumber))
            {
                throw new ArgumentException("Vehicle not found in the garage.");
            }

            Vehicle vehicle = r_Vehicles[i_LicenseNumber];
            vehicle.Refuel(i_ChargeAmount, "Electric");
        }
        public string GetVehicleDetails(string i_LicenseNumber)
        {
            if (!r_Vehicles.ContainsKey(i_LicenseNumber))
            {
                throw new ArgumentException("Vehicle not found in the garage.");
            }

            Vehicle vehicle = r_Vehicles[i_LicenseNumber];
            (string ownerName, string ownerPhone) = r_OwnerDetails[i_LicenseNumber];
            eVehicleState state = r_VehicleStates[i_LicenseNumber];

            List<string> wheelsDetailsList = new List<string>();
            foreach (Wheel wheel in vehicle.Wheels)
            {
                wheelsDetailsList.Add($"Manufacturer: {wheel.ManufacturerName}, Current Pressure: {wheel.CurrentAirPressure}, Max Pressure: {wheel.MaxAirPressure}");
            }

            string wheelsDetails = string.Join("\n", wheelsDetailsList);

            // Details specific to the type of vehicle
            string specificDetails = string.Empty;

            if (vehicle is RegularCar regularCar)
            {
                specificDetails = $"Color: {regularCar.Color}, Doors: {regularCar.NumberOfDoors}";
            }

            else if (vehicle is ElectricCar electricCar)
            {
                specificDetails = $"Color: {electricCar.Color}, Doors: {electricCar.NumberOfDoors}";
            }

            else if (vehicle is RegularMotorcycle regularMotorcycle)
            {
                specificDetails = $"License Type: {regularMotorcycle.LicenseType}, Engine Volume: {regularMotorcycle.EngineVolume}cc";
            }

            else if (vehicle is ElectricMotorcycle electricMotorcycle)
            {
                specificDetails = $"License Type: {electricMotorcycle.LicenseType}, Engine Volume: {electricMotorcycle.EngineVolume}cc";
            }

            else if (vehicle is Truck truck)
            {
                specificDetails = $"Refrigerated: {truck.IsCarryingRefrigeratedMaterials}, Cargo Volume: {truck.CargoVolume} cubic meters";
            }

            string fuelDetails = string.Empty;

            if (vehicle is RegularCar || vehicle is RegularMotorcycle || vehicle is Truck)
            {
                fuelDetails = $"Fuel Type: {(vehicle is RegularCar ? "Octan95" : vehicle is RegularMotorcycle ? "Octan98" : "Soler")}";
            }

            return $"License Number: {i_LicenseNumber}\n" +
                   $"Owner: {ownerName}, Phone: {ownerPhone}\n" +
                   $"State: {state}\n" +
                   $"Model: {vehicle.ModelName}\n" +
                   $"Energy: {vehicle.CurrentEnergy.ToString("F3")}%\n" +
                   $"Wheels:\n{wheelsDetails}\n" +
                   specificDetails + "\n" +
                   fuelDetails;
        }
    }
}

