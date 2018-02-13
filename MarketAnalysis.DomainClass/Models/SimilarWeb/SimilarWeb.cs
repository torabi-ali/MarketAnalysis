namespace MarketAnalysis.DomainClass.Models
{
    public class SimilarWeb
    {
        public int? Direct { get; set; }
        public int? Referral { get; set; }
        public int? Search { get; set; }
        public int? Social { get; set; }
        public int? Mail { get; set; }
        public int? Display { get; set; }
        public string TopReferringSites1 { get; set; }
        public string TopReferringSites2 { get; set; }
        public string TopReferringSites3 { get; set; }
        public string TopReferringSites4 { get; set; }
        public string TopReferringSites5 { get; set; }
        public string TopDestinationSites1 { get; set; }
        public string TopDestinationSites2 { get; set; }
        public string TopDestinationSites3 { get; set; }
        public string TopDestinationSites4 { get; set; }
        public string TopDestinationSites5 { get; set; }
        public string TopOrganicKeywords1 { get; set; }
        public string TopOrganicKeywords2 { get; set; }
        public string TopOrganicKeywords3 { get; set; }
        public string TopOrganicKeywords4 { get; set; }
        public string TopOrganicKeywords5 { get; set; }
    }
}
