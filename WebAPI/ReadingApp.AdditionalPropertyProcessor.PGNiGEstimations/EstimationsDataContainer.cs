using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReadingApp.AdditionalPropertyProcessor.PGNiGEstimations
{
    internal class EstimationsDataContainer
    {
        [DisplayName("Dzienne zużycie")]
        public Decimal? DailyValue { get; set; }
        [DisplayName("Dzienny koszt")]
        public Decimal? DailyCost { get; set; }
        [DisplayName("Zużycie w okresie")]
        public Decimal? PeriodValue { get; set; }
        [DisplayName("Koszt pod koniec okresu")]
        public Decimal? PeriodCost { get; set; }
    }
}
