using System;
using System.Collections.Generic;

namespace Ex03.GarageLogic
{
    public static class VehicleFactory
    {
        // creates a new vehicle based on the type and additional parameters.
        public static Vehicle CreateVehicle(eVehicleType i_VehicleType, params object[] i_Args)
        {
            switch (i_VehicleType)
            {
                case eVehicleType.RegularMotorcycle:
                    return new RegularMotorcycle((string)i_Args[0], (eLicenseType)i_Args[1], (int)i_Args[2], (float)i_Args[3]);
                case eVehicleType.ElectricMotorcycle:
                    return new ElectricMotorcycle((string)i_Args[0], (eLicenseType)i_Args[1], (int)i_Args[2], (float)i_Args[3]);
                case eVehicleType.RegularCar:
                    return new RegularCar((string)i_Args[0], (eCarColor)i_Args[1], (int)i_Args[2], (float)i_Args[3]);
                case eVehicleType.ElectricCar:
                    return new ElectricCar((string)i_Args[0], (eCarColor)i_Args[1], (int)i_Args[2], (float)i_Args[3]);
                case eVehicleType.Truck:
                    return new Truck((string)i_Args[0], (bool)i_Args[1], (float)i_Args[2], (float)i_Args[3]);
                default:
                    throw new ArgumentException("Unsupported vehicle type.");
            }
        }

        // returns a list of all supported vehicle types.
        public static List<eVehicleType> GetSupportedVehicleTypes()
        {
            return new List<eVehicleType>((eVehicleType[])Enum.GetValues(typeof(eVehicleType)));
        }
    }
}
