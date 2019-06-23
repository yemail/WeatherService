using System.Runtime.Serialization;

namespace Weather.Model.Enum
{
    [DataContract(Name = "WindDirectionsEnum")]
    public enum WindDirectionsEnum
    {
        [EnumMember(Value = "N")]
        N = 10,

        [EnumMember(Value = "S")]
        S = 20,

        [EnumMember(Value = "NNE")]
        NNE = 30,
    }
}