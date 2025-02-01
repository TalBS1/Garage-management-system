using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic
{
    //public class RegularMotorcycle : Motorcycle
    //{
    //    public float CurrentFuelAmount { get; set; }
    //    public float MaxFuelCapacity { get; }

    //    public RegularMotorcycle(string i_ModelName, eLicenseType i_LicenseType, int i_EngineVolume, float i_CurrentFuelAmount)
    //        : base(i_ModelName, i_LicenseType, i_EngineVolume, 2, 32)
    //    {
    //        MaxFuelCapacity = 6.2f;
    //        CurrentFuelAmount = i_CurrentFuelAmount;
    //        CurrentEnergy = CurrentFuelAmount / MaxFuelCapacity * 100;
    //    }
    //    public override float GetMaxAirPressure()
    //    {
    //        return 32;
    //    }
    //    public override void Refuel(double i_AmountToAdd, string i_EnergyType)
    //    {

    //        if (i_EnergyType != "Octan98")
    //        {
    //            throw new ArgumentException("Regular motorcycles can only use Octan98 fuel.");
    //        }

    //        if (CurrentFuelAmount + i_AmountToAdd > MaxFuelCapacity)
    //        {
    //            throw new ValueOutOfRangeException(0, MaxFuelCapacity, "Fuel amount exceeds the tank capacity.");
    //        }

    //        CurrentFuelAmount += (float)i_AmountToAdd;
    //        CurrentEnergy = CurrentFuelAmount / MaxFuelCapacity * 100;
    //    }
    //}

    public class RegularMotorcycle : Motorcycle
    {
        public float CurrentFuelAmount { get; set; }
        public float MaxFuelCapacity { get; }

        public RegularMotorcycle(string i_ModelName, eLicenseType i_LicenseType, int i_EngineVolume, float i_CurrentFuelAmount)
            : base(i_ModelName, i_LicenseType, i_EngineVolume, 2, 32)
        {
            MaxFuelCapacity = 6.2f;
            CurrentFuelAmount = i_CurrentFuelAmount;
            CurrentEnergy = CurrentFuelAmount / MaxFuelCapacity * 100;
        }

        public override Dictionary<string, string> GetVehicleQuestions()
        {
            Dictionary<string, string> vehicleQuestions = new Dictionary<string, string>();
            vehicleQuestions.Add("CurrentFuelAmount", "Enter current fuel amount (Max: 6.2):");
            vehicleQuestions.Add("LicenseType", "Enter license type (A1, A2, B1, B2):");
            vehicleQuestions.Add("EngineVolume", "Enter engine volume (cc):");
            vehicleQuestions.Add("WheelPressure", "Enter air pressure for all wheels (Max: 32):");
            vehicleQuestions.Add("WheelManufacturer", "Enter wheel manufacturer name:");
            return vehicleQuestions;
        }

        public override float GetMaxAirPressure()
        {
            return 32;
        }

        public override void Refuel(double i_AmountToFuel, string i_FuelType)
        {
            if (i_FuelType != "Octan98")
            {
                throw new ArgumentException("Regular motorcycles can only use Octan98 fuel.");
            }
            if (CurrentFuelAmount + i_AmountToFuel > MaxFuelCapacity)
            {
                throw new ValueOutOfRangeException(0, MaxFuelCapacity, "Fuel amount exceeds the tank capacity.");
            }
            CurrentFuelAmount += (float)i_AmountToFuel;
            CurrentEnergy = CurrentFuelAmount / MaxFuelCapacity * 100;
        }
    }
}
