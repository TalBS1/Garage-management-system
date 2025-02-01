using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic
{
    public class RegularCar : Car
    {
        public float CurrentFuelAmount { get; set; }
        public float MaxFuelCapacity { get; }
        public RegularCar(string i_ModelName, eCarColor i_Color, int i_NumberOfDoors, float i_CurrentFuelAmount)
            : base(i_ModelName, i_Color, i_NumberOfDoors, 4, 34)
        {
            MaxFuelCapacity = 52f;
            CurrentFuelAmount = i_CurrentFuelAmount;
            CurrentEnergy = CurrentFuelAmount / MaxFuelCapacity * 100;
        }

        public override void Refuel(double i_AmountToFuel, string i_FuelType)
        {

            if (i_FuelType != "Octan95")
            {
                throw new ArgumentException("Regular cars can only use Octan95 fuel.");
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
