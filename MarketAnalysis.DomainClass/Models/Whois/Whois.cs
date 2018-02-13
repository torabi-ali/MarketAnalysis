namespace MarketAnalysis.DomainClass.Models
{
    public class Whois
    {
        public string CEO { get; set; }
        public string City { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }

        public string ToCSV()
        {
            var result = $"{CEO},{City},{PhoneNumber},{Email}";
            return result;
        }

        public string TitleCSV()
        {
            var result = $"مدیرعامل,شهر,تلفن,ایمیل";
            return result;
        }
    }
}
