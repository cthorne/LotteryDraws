using System;
using LotteryDraws.Models.Enum;

namespace LotteryDraws.Models
{
    public class OpenLotteriesDraw
    {
        public LotteriesProduct ProductId { get; set; }
        public int DrawNumber { get; set; }
        public string DrawDisplayName { get; set; }
        public DateTime DrawDate { get; set; }
        /// <summary>
        /// Deprecated.
        /// </summary>
        public string DrawLogoUrl { get; set; }

        public DrawTypes DrawType { get; set; }
        public Decimal Div1Amount { get; set; }
        public bool IsDiv1Estimated { get; set; }
        public bool IsDiv1Unknown { get; set; }
        public DateTime DrawCloseDateTimeUTC { get; set; }
        public DateTime DrawEndSellDateTimeUTC { get; set; }
        public Double DrawCountDownTimerSeconds { get; set; } // Utc time
    }
}
