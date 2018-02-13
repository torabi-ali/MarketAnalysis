namespace MarketAnalysis.DomainClass.Models
{
    public class Company
    {
        public string Name { get; set; }
        public string Url { get; set; }
        public Alexa Alexa { get; set; }
        public SiteRankData SiteRankData { get; set; }
        public SimilarWeb SimilarWeb { get; set; }
        public GTmetrix GTmetrix { get; set; }
        public Whois Whois { get; set; }
    }
}
