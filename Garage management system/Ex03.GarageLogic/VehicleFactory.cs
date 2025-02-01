using System;
using System.Collections.Generic;

namespace Ex03.GarageLogic
{
    //public static class VehicleFactory
    //{
    //    // creates a new vehicle based on the type and additional parameters.
    //    public static Vehicle CreateVehicle(eVehicleType i_VehicleType, params object[] i_Args)
    //    {
    //        switch (i_VehicleType)
    //        {
    //            case eVehicleType.RegularMotorcycle:
    //                return new RegularMotorcycle((string)i_Args[0], (eLicenseType)i_Args[1], (int)i_Args[2], (float)i_Args[3]);
    //            case eVehicleType.ElectricMotorcycle:
    //                return new ElectricMotorcycle((string)i_Args[0], (eLicenseType)i_Args[1], (int)i_Args[2], (float)i_Args[3]);
    //            case eVehicleType.RegularCar:
    //                return new RegularCar((string)i_Args[0], (eCarColor)i_Args[1], (int)i_Args[2], (float)i_Args[3]);
    //            case eVehicleType.ElectricCar:
    //                return new ElectricCar((string)i_Args[0], (eCarColor)i_Args[1], (int)i_Args[2], (float)i_Args[3]);
    //            case eVehicleType.Truck:
    //                return new Truck((string)i_Args[0], (bool)i_Args[1], (float)i_Args[2], (float)i_Args[3]);
    //            default:
    //                throw new ArgumentException("Unsupported vehicle type.");
    //        }
    //    }

    //    // returns a list of all supported vehicle types.
    //    public static List<eVehicleType> GetSupportedVehicleTypes()
    //    {
    //        return new List<eVehicleType>((eVehicleType[])Enum.GetValues(typeof(eVehicleType)));
    //    }
    //}



    public static class VehicleFactory
    {
        public static Vehicle CreateVehicle(eVehicleType i_VehicleType, string i_ModelName, params object[] i_Args)
        {
            switch (i_VehicleType)
            {
                case eVehicleType.ElectricMotorcycle:
                    return new ElectricMotorcycle(i_ModelName, (eLicenseType)i_Args[0], (int)i_Args[1], (float)i_Args[2]);
                case eVehicleType.RegularMotorcycle:
                    return new RegularMotorcycle(i_ModelName, (eLicenseType)i_Args[0], (int)i_Args[1], (float)i_Args[2]);
                case eVehicleType.ElectricCar:
                    return new ElectricCar(i_ModelName, (eCarColor)i_Args[0], (int)i_Args[1], (float)i_Args[2]);
                case eVehicleType.RegularCar:
                    return new RegularCar(i_ModelName, (eCarColor)i_Args[0], (int)i_Args[1], (float)i_Args[2]);
                case eVehicleType.Truck:
                    return new Truck(i_ModelName, (bool)i_Args[0], (float)i_Args[1], (float)i_Args[2]);
                default:
                    throw new ArgumentException("Unsupported vehicle type.");
            }
        }

        public static List<eVehicleType> GetSupportedVehicleTypes()
        {
            return new List<eVehicleType>((eVehicleType[])Enum.GetValues(typeof(eVehicleType)));
        }

        public static Dictionary<string, string> GetVehicleQuestions(eVehicleType i_VehicleType)
        {
            switch (i_VehicleType)
            {
                case eVehicleType.ElectricMotorcycle:
                    return new ElectricMotorcycle("mzada", eLicenseType.A1, 200, 5).GetVehicleQuestions();
                case eVehicleType.RegularMotorcycle:
                    return new RegularMotorcycle("mzada", eLicenseType.A1, 200, 5).GetVehicleQuestions();
                case eVehicleType.ElectricCar:
                    return new ElectricCar("mzada", eCarColor.Black, 4, 20).GetVehicleQuestions();
                case eVehicleType.RegularCar:
                    return new RegularCar("mzada", eCarColor.Black, 4, 20).GetVehicleQuestions();
                case eVehicleType.Truck:
                    return new Truck("mzada", true, 200, 50).GetVehicleQuestions();
                default:
                    throw new ArgumentException("Unsupported vehicle type.");
            }
        }
    }
}
