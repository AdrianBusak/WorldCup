using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace WorldCup.DataAccess.Enums
{
    public enum Description
    {
        [EnumMember(Value = "Clear Night")]
        ClearNight,
        Cloudy,
        [EnumMember(Value = "Partly Cloudy")]
        PartlyCloudy,
        [EnumMember(Value = "Partly Cloudy Night")]
        PartlyCloudyNight,
        Sunny,
        [EnumMember(Value = "Cloudy Night")]
        CloudyNight
    };

}
