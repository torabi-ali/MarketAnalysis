namespace MarketAnalysis.Model
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

        public string ToCSV()
        {
            var result = $"{Direct},{Referral},{Search},{Social},{Mail},{Display},";
            result += $"{TopReferringSites1},{TopReferringSites2},{TopReferringSites3},{TopReferringSites4},{TopReferringSites5},";
            result += $"{TopDestinationSites1},{TopDestinationSites2},{TopDestinationSites3},{TopDestinationSites4},{TopDestinationSites5},";
            result += $"{TopOrganicKeywords1},{TopOrganicKeywords2},{TopOrganicKeywords3},{TopOrganicKeywords4},{TopOrganicKeywords5}";

            return result;
        }

        public string TitleCSV()
        {
            var result = $"بازدید مستقیم,بازدید ارجاعی,موتورهای جستجو,شبکه‌های اجتماعی,ایمیل,Display,";
            result += $"برترین ارجاع دهنده۱,برترین ارجاع دهنده۲,برترین ارجاع دهنده۳,برترین ارجاع دهنده۴,برترین ارجاع دهنده۵,";
            result += $"برترین مقصد۱,برترین مقصد۲,برترین مقصد۳,برترین مقصد۴,برترین مقصد۵,";
            result += $"برترین کلمه کلیدی۱,برترین کلمه کلیدی۲,برترین کلمه کلیدی۳,برترین کلمه کلیدی۴,برترین کلمه کلیدی۵";

            return result;
        }
    }
}
