using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic
{
    //public class ElectricCar : Car
    //{
    //    public float BatteryTimeLeft { get; set; }
    //    public float MaxBatteryTime { get; }
    //    public ElectricCar(string i_ModelName, eCarColor i_Color, int i_NumberOfDoors, float i_BatteryTimeLeft)
    //        : base(i_ModelName, i_Color, i_NumberOfDoors, 4, 34)
    //    {
    //        MaxBatteryTime = 5.4f;
    //        BatteryTimeLeft = i_BatteryTimeLeft;
    //        CurrentEnergy = BatteryTimeLeft / MaxBatteryTime * 100;
    //    }
    //    public override float GetMaxAirPressure()
    //    {
    //         return 34; 
    //    }
    //    public override void Refuel(double i_AmountToAdd, string i_EnergyType)
    //    {
    //        if (i_EnergyType != "Electric")
    //        {
    //            throw new ArgumentException("Electric cars can only be charged.");
    //        }

    //        if (BatteryTimeLeft + i_AmountToAdd > MaxBatteryTime)
    //        {
    //            throw new ValueOutOfRangeException(0, MaxBatteryTime, "Charge amount exceeds the battery capacity.");
    //        }

    //        BatteryTimeLeft += (float)i_AmountToAdd;
    //        CurrentEnergy = BatteryTimeLeft / MaxBatteryTime * 100;
    //    }
    //}


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

        public override Dictionary<string, string> GetVehicleQuestions()
        {
            Dictionary<string, string> vehicleQuestions = new Dictionary<string, string>();
            vehicleQuestions.Add("BatteryTimeLeft", "Enter remaining battery hours (Max: 5.4):");
            vehicleQuestions.Add("CarColor", "Enter car color (Black, White, Gray, Blue):");
            vehicleQuestions.Add("NumberOfDoors", "Enter number of doors (2-5):");
            vehicleQuestions.Add("WheelPressure", "Enter air pressure for all wheels (Max: 34):");
            vehicleQuestions.Add("WheelManufacturer", "Enter wheel manufacturer name:");
            return vehicleQuestions;
        }

        public override float GetMaxAirPressure()
        {
            return 34;
        }

        public override void Refuel(double i_AmountToFuel, string i_FuelType)
        {
            if (i_FuelType != "Electric")
            {
                throw new ArgumentException("Electric cars can only be charged.");
            }
            if (BatteryTimeLeft + i_AmountToFuel > MaxBatteryTime)
            {
                throw new ValueOutOfRangeException(0, MaxBatteryTime, "Charge amount exceeds the battery capacity.");
            }
            BatteryTimeLeft += (float)i_AmountToFuel;
            CurrentEnergy = BatteryTimeLeft / MaxBatteryTime * 100;
        }
    }

}
