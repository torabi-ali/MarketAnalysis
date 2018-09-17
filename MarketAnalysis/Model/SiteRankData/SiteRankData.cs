namespace MarketAnalysis.Model
{
    public class SiteRankData
    {
        public int? DailyUniqueVisitors { get; set; }
        public int? CurrentAlexaRank { get; set; }

        public string ToCSV()
        {
            var result = $"{DailyUniqueVisitors},{CurrentAlexaRank}";
            return result;
        }

        public string TitleCSV()
        {
            var result = $"بازدید در روز,رتبه اکسا کنونی";
            return result;
        }
    }
}
