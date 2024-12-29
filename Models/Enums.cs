using System.Runtime.Serialization;

namespace MasterClassTestAutomation.Models
{
    public enum Label
    {
        [EnumMember(Value = "Id")]
        Id,
        [EnumMember(Value = "Url")]
        Url,
        [EnumMember(Value = "TextInput")]
        TextInput,
        [EnumMember(Value = "TextArea")]
        TextArea,
        [EnumMember(Value = "DropDown")]
        DropDown,
        [EnumMember(Value = "DataList")]
        DataList,
        [EnumMember(Value = "Range")]
        Range
    }

    public enum Num
    {
        [EnumMember(Value = "0")]
        Zero,
        [EnumMember(Value = "1")]
        One,
        [EnumMember(Value = "2")]
        Two,
        [EnumMember(Value = "3")]
        Three,
        [EnumMember(Value = "4")]
        Four,
        [EnumMember(Value = "5")]
        Five,
        [EnumMember(Value = "6")]
        Six,
        [EnumMember(Value = "7")]
        Seven,
    }
}
