using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic
{
    public class Truck : Vehicle
    {
        public bool IsCarryingRefrigeratedMaterials { get; }
        public float CargoVolume { get; }
        public float CurrentFuelAmount { get; set; }

        public Truck(string i_ModelName, bool i_IsCarryingRefrigeratedMaterials, float i_CargoVolume, float i_CurrentFuelAmount)
            : base(i_ModelName, 14, 29)
        {
            IsCarryingRefrigeratedMaterials = i_IsCarryingRefrigeratedMaterials;
            CargoVolume = i_CargoVolume;
            CurrentFuelAmount = i_CurrentFuelAmount;

            MaxFuelCapacity = 125f;
            CurrentEnergy = CurrentFuelAmount / MaxFuelCapacity * 100;
        }

        public override void Refuel(double i_AmountToAdd, string i_EnergyType)
        {

            if (i_EnergyType != "Soler")
            {
                throw new ArgumentException("Trucks can only use Soler fuel.");
            }

            if (CurrentFuelAmount + i_AmountToAdd > MaxEnergyCapacity)
            {
                throw new ValueOutOfRangeException(0, MaxEnergyCapacity, "Fuel amount exceeds the tank capacity.");
            }

            CurrentFuelAmount += (float)i_AmountToAdd;
            CurrentEnergy = CurrentFuelAmount / MaxFuelCapacity * 100;
        }
    }
}
