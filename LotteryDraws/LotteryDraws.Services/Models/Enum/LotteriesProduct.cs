using System.Runtime.Serialization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace LotteryDraws.Models.Enum
{
    /// <summary>
    /// Lottery products.
    /// </summary>
    [JsonConverter(typeof(StringEnumConverter))]
    public enum LotteriesProduct
    {
        None,
        TattsLotto,
        OzLotto,
        Powerball,
        Super66,
        Pools,
        MonWedLotto,
        LuckyLotteries2,
        LuckyLotteries5,
        LottoStrike,
        WedLotto,
        Keno,
        CoinToss,
        [EnumMember(Value = "SetForLife744")]
        SetForLife,
        MultiProduct = 15,
        InstantScratchIts,
        TwoDollarCasket,
        BonusDraws
    }
}
