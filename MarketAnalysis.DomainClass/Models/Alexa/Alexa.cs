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

        public string ToCSV()
        {
            var result = $"{GlobalRank},{IranRank},{RankDiffernce},{ImagePath},{BounceRate},{DailyPageView},{DailyTime},{Keyword1},{Keyword2},{Keyword3},{Keyword4},{Keyword5},{Backlinks}";
            return result;
        }

        public string TitleCSV()
        {
            var result = $"رتبه جهانی,رتبه ایران,اختلاف رتبه,آدرس تصویر,نرخ خروجی,بازدید در روز,زمان در روز,کلمه کلیدی۱,کلمه کلیدی۲,کلمه کلیدی۳,کلمه کلیدی۴,کلمه کلیدی۵,تعداد ارجاعات";
            return result;
        }
    }
}
