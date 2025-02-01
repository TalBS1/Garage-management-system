using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic
{
    public abstract class Vehicle
    {
        public string ModelName { get; set; } 
        public string LicenseNumber { get; set; } 
        public double CurrentEnergy { get; set; } 
        public List<Wheel> Wheels { get; set; } 
        public double MaxEnergyCapacity { get; protected set; }
        public double MaxFuelCapacity { get; protected set; }
        public double MaxBatteryTime { get; protected set; }
        protected Vehicle(string i_ModelName, int i_NumOfWheels, float i_MaxAirPressure)
        {
            ModelName = i_ModelName;
            Wheels = new List<Wheel>(i_NumOfWheels);

            for (int i = 0; i < i_NumOfWheels; i++)
            {
                Wheels.Add(new Wheel(i_MaxAirPressure));
            }
        }

        public void SetAllWheelsPressure(float i_Pressure)
        {

            foreach (Wheel wheel in Wheels)
            {

                if (i_Pressure > wheel.MaxAirPressure)
                {
                    throw new ValueOutOfRangeException(0, wheel.MaxAirPressure, "Pressure exceeds the maximum allowed value.");
                }
                wheel.CurrentAirPressure = i_Pressure;
            }
        }
        public abstract void Refuel(double i_AmountToFuel, string i_FuelType);
    }
}
