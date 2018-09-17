namespace MarketAnalysis.Model
{
    public class GTmetrix
    {
        public int? PageSpeed { get; set; }
        public int? YSlow { get; set; }
        public decimal? PageLoad { get; set; }
        public decimal? PageSize { get; set; }

        public string ToCSV()
        {
            var result = $"{PageSpeed},{YSlow},{PageLoad},{PageSize}";
            return result;
        }

        public string TitleCSV()
        {
            var result = $"سرعت صفحه (گوگل),سرعت صفحه (یاهو),زمان بارگذاری صفحه,حجم صفحه";
            return result;
        }
    }
}
