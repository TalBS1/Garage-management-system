using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic
{
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

        public override void Refuel(double i_AmountToAdd, string i_EnergyType)
        {

            if (i_EnergyType != "Octan98")
            {
                throw new ArgumentException("Regular motorcycles can only use Octan98 fuel.");
            }

            if (CurrentFuelAmount + i_AmountToAdd > MaxFuelCapacity)
            {
                throw new ValueOutOfRangeException(0, MaxFuelCapacity, "Fuel amount exceeds the tank capacity.");
            }

            CurrentFuelAmount += (float)i_AmountToAdd;
            CurrentEnergy = CurrentFuelAmount / MaxFuelCapacity * 100;
        }
    }
}
