using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic
{
    public class ValueOutOfRangeException : Exception
    {
        public double MaxValue { get; }
        public double MinValue { get; }

        public ValueOutOfRangeException(double i_MinValue, double i_MaxValue, string i_Message)
            : base(i_Message)
        {
            MinValue = i_MinValue;
            MaxValue = i_MaxValue;
        }

        public override string ToString()
        {
            return $"{Message} Allowed range: {MinValue} - {MaxValue}."; // Custom error message.
        }
    }
}

