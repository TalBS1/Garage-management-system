using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic
{
    public class ElectricCar : Car
    {
        public float BatteryTimeLeft { get; set; }
        public float MaxBatteryTime { get; }
        public ElectricCar(string i_ModelName, eCarColor i_Color, int i_NumberOfDoors, float i_BatteryTimeLeft)
            : base(i_ModelName, i_Color, i_NumberOfDoors, 4, 34)
        {
            MaxBatteryTime = 5.4f;
            BatteryTimeLeft = i_BatteryTimeLeft;
            CurrentEnergy = BatteryTimeLeft / MaxBatteryTime * 100;
        }

        public override void Refuel(double i_AmountToAdd, string i_EnergyType)
        {
            if (i_EnergyType != "Electric")
            {
                throw new ArgumentException("Electric cars can only be charged.");
            }

            if (BatteryTimeLeft + i_AmountToAdd > MaxBatteryTime)
            {
                throw new ValueOutOfRangeException(0, MaxBatteryTime, "Charge amount exceeds the battery capacity.");
            }

            BatteryTimeLeft += (float)i_AmountToAdd;
            CurrentEnergy = BatteryTimeLeft / MaxBatteryTime * 100;
        }
    }
}
