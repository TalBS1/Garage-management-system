using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic
{
    public class ElectricMotorcycle : Motorcycle
    {
        public float BatteryTimeLeft { get; set; }
        public float MaxBatteryTime { get; }
        public ElectricMotorcycle(string i_ModelName, eLicenseType i_LicenseType, int i_EngineVolume, float i_BatteryTimeLeft)
            : base(i_ModelName, i_LicenseType, i_EngineVolume, 2, 32)
        {
            MaxBatteryTime = 2.9f;
            BatteryTimeLeft = i_BatteryTimeLeft;
            CurrentEnergy = BatteryTimeLeft / MaxBatteryTime * 100;
        }

        public override void Refuel(double i_AmountToAdd, string i_EnergyType)
        {

            if (i_EnergyType != "Electric")
            {
                throw new ArgumentException("Electric motorcycles can only be charged.");
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
