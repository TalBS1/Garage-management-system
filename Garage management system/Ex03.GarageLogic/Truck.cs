using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic
{
    //public class Truck : Vehicle
    //{
    //    public bool IsCarryingRefrigeratedMaterials { get; }
    //    public float CargoVolume { get; }
    //    public float CurrentFuelAmount { get; set; }

    //    public Truck(string i_ModelName, bool i_IsCarryingRefrigeratedMaterials, float i_CargoVolume, float i_CurrentFuelAmount)
    //        : base(i_ModelName, 14, 29)
    //    {
    //        IsCarryingRefrigeratedMaterials = i_IsCarryingRefrigeratedMaterials;
    //        CargoVolume = i_CargoVolume;
    //        CurrentFuelAmount = i_CurrentFuelAmount;

    //        MaxFuelCapacity = 125f;
    //        CurrentEnergy = CurrentFuelAmount / MaxFuelCapacity * 100;
    //    }
    //    public override float GetMaxAirPressure()
    //    {
    //        return 29;
    //    }
    //    public override void Refuel(double i_AmountToAdd, string i_EnergyType)
    //    {

    //        if (i_EnergyType != "Soler")
    //        {
    //            throw new ArgumentException("Trucks can only use Soler fuel.");
    //        }

    //        if (CurrentFuelAmount + i_AmountToAdd > MaxEnergyCapacity)
    //        {
    //            throw new ValueOutOfRangeException(0, MaxEnergyCapacity, "Fuel amount exceeds the tank capacity.");
    //        }

    //        CurrentFuelAmount += (float)i_AmountToAdd;
    //        CurrentEnergy = CurrentFuelAmount / MaxFuelCapacity * 100;
    //    }
    //}



    public class Truck : Vehicle
    {
        public bool IsCarryingRefrigeratedMaterials { get; }
        public float CargoVolume { get; }

        public Truck(string i_ModelName, bool i_IsCarryingRefrigeratedMaterials, float i_CargoVolume, float i_CurrentFuelAmount)
            : base(i_ModelName, 14, 29)
        {
            IsCarryingRefrigeratedMaterials = i_IsCarryingRefrigeratedMaterials;
            CargoVolume = i_CargoVolume;
        }

        public override Dictionary<string, string> GetVehicleQuestions()
        {
            Dictionary<string, string> vehicleQuestions = new Dictionary<string, string>();
            vehicleQuestions.Add("CargoVolume", "Enter cargo volume:");
            vehicleQuestions.Add("IsCarryingRefrigeratedMaterials", "Is carrying refrigerated materials? (true/false):");
            vehicleQuestions.Add("CurrentFuelAmount", "Enter current fuel amount (Max: 125):");
            vehicleQuestions.Add("WheelPressure", "Enter air pressure for all wheels (Max: 29):");
            vehicleQuestions.Add("WheelManufacturer", "Enter wheel manufacturer name:");
            return vehicleQuestions;
        }

        public override float GetMaxAirPressure()
        {
            return 29;
        }

        public override void Refuel(double i_AmountToFuel, string i_FuelType)
        {
            if (i_FuelType != "Soler")
            {
                throw new ArgumentException("Trucks can only use Soler fuel.");
            }
        }
    }
}
