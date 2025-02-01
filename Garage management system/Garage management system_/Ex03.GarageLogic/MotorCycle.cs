using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic
{
    public abstract class Motorcycle : Vehicle
    {
        public eLicenseType LicenseType { get; }
        public int EngineVolume { get; }

        protected Motorcycle(string i_ModelName, eLicenseType i_LicenseType, int i_EngineVolume, int i_NumOfWheels, float i_MaxAirPressure)
            : base(i_ModelName, i_NumOfWheels, i_MaxAirPressure)
        {

            if (i_EngineVolume <= 0)
            {
                throw new ArgumentException("Engine volume must be greater than 0.");
            }

            LicenseType = i_LicenseType;
            EngineVolume = i_EngineVolume;
        }
    }
}
