namespace MarketAnalysis.DomainClass.Models
{
    public class SiteRankDataSelector
    {
        public static string DailyUniqueVisitors = "//*[@id=\"data-blocks\"]/div[1]/div/div[2]/div/div[1]/h3";
        public static string CurrentAlexaRank = "/html/body/div/div[3]/div/div/div[2]/div/div[1]/div[2]/h1";
    }
}
