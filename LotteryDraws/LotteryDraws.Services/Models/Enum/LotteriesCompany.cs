using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace LotteryDraws.Models.Enum
{
    /// <summary>
    /// Enum values for the lottery company.
    /// </summary>
    [JsonConverter(typeof(StringEnumConverter))]
    public enum LotteriesCompany
    {
        None,
        Tattersalls,
        GoldenCasket,
        NSWLotteries,
        NTLotteries,
        SALotteries
    }
}
