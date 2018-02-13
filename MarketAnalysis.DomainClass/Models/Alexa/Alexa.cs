namespace MarketAnalysis.DomainClass.Models
{
    public class Alexa
    {
        public int? GlobalRank { get; set; }
        public int? IranRank { get; set; }
        public int? RankDiffernce { get; set; }
        public string ImagePath { get; set; }
        public decimal? BounceRate { get; set; }
        public decimal? DailyPageView { get; set; }
        public int? DailyTime { get; set; }
        public string Keyword1 { get; set; }
        public string Keyword2 { get; set; }
        public string Keyword3 { get; set; }
        public string Keyword4 { get; set; }
        public string Keyword5 { get; set; }
        public int? Backlinks { get; set; }
    }
}
