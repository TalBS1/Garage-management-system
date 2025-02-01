using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic
{
    public class Wheel
    {
        public string ManufacturerName { get; set; } 
        public float CurrentAirPressure { get; set; }
        public float MaxAirPressure { get; private set; }
        public Wheel(float i_MaxAirPressure)
        {
            MaxAirPressure = i_MaxAirPressure;
            CurrentAirPressure = 0;
        }

        public void Inflate(float i_AirToAdd)
        {

            if (CurrentAirPressure + i_AirToAdd > MaxAirPressure)
            {
                throw new ValueOutOfRangeException(0, MaxAirPressure, "Air pressure exceeds maximum limit.");
            }

            CurrentAirPressure += i_AirToAdd;
        }
    }
}
