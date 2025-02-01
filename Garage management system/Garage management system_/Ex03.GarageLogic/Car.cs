using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic
{
    public abstract class Car : Vehicle
    {
        public eCarColor Color { get; }
        public int NumberOfDoors { get; }
        protected Car(string i_ModelName, eCarColor i_Color, int i_NumberOfDoors, int i_NumOfWheels, float i_MaxAirPressure)
            : base(i_ModelName, i_NumOfWheels, i_MaxAirPressure)
        {

            if (!Enum.IsDefined(typeof(eCarColor), i_Color))
            {
                throw new ArgumentException($"Invalid car color. Allowed colors are: {string.Join(", ", Enum.GetNames(typeof(eCarColor)))}.");
            }

            if (i_NumberOfDoors < 2 || i_NumberOfDoors > 5)
            {
                throw new ArgumentException("Number of doors must be between 2 and 5.");
            }

            Color = i_Color;
            NumberOfDoors = i_NumberOfDoors;
        }
    }
}
