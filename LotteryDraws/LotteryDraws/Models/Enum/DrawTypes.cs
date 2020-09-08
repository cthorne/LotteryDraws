using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace LotteryDraws.Models.Enum
{
    [JsonConverter(typeof(StringEnumConverter))]
    public enum DrawTypes
    {
        Undefined = 1,
        BaseWeek,
        Jackpot,
        Superdraw,
        Megadraw,
        DoubleDivs,
        TripleDivs,
        FourTimesDivs,
        DoubleDivsPlus1,
        TripleDivsPlus1,
        FourTimesDivsPlus1,
        CashCadeNextDiv,
        CashCadeAllDivs
    }
}
