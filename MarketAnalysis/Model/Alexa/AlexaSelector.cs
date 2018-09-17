namespace MarketAnalysis.Model
{
    public class AlexaSelector
    {
        public static string GlobalRank = "//*[@id=\"traffic-rank-content\"]/div/span[2]/div[1]/span/span/div/strong";
        public static string IranRank = "//*[@id=\"traffic-rank-content\"]/div/span[2]/div[2]/span/span/div/strong";
        public static string RankDiffernce = "//*[@id=\"traffic-rank-content\"]/div/span[2]/div[1]/span/span/div/span";
        public static string ImagePath = "//*[@id=\"traffic-rank-content\"]/div/span[1]/div[2]/img";
        public static string BounceRate = "//*[@id=\"engagement-content\"]/span[1]/span/span/div/strong";
        public static string DailyPageView = "//*[@id=\"engagement-content\"]/span[2]/span/span/div/strong";
        public static string DailyTime = "//*[@id=\"engagement-content\"]/span[3]/span/span/div/strong";
        public static string Keyword1 = "//*[@id=\"keywords_top_keywords_table\"]/tbody/tr[1]/td[1]/span[2]";
        public static string Keyword2 = "//*[@id=\"keywords_top_keywords_table\"]/tbody/tr[2]/td[1]/span[2]";
        public static string Keyword3 = "//*[@id=\"keywords_top_keywords_table\"]/tbody/tr[3]/td[1]/span[2]";
        public static string Keyword4 = "//*[@id=\"keywords_top_keywords_table\"]/tbody/tr[4]/td[1]/span[2]";
        public static string Keyword5 = "//*[@id=\"keywords_top_keywords_table\"]/tbody/tr[5]/td[1]/span[2]";
        public static string Backlinks = "//*[@id=\"linksin-panel-content\"]/div[1]/span/div/span";
    }
}
