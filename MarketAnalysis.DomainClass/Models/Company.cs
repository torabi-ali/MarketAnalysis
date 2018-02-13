using MarketAnalysis.Utility;
using System;

namespace MarketAnalysis.DomainClass.Models
{
    public class Company
    {
        public Company()
        {
            Alexa = new Alexa();
            SiteRankData = new SiteRankData();
            SimilarWeb = new SimilarWeb();
            GTmetrix = new GTmetrix();
            Whois = new Whois();
        }
        public string Name { get; set; }
        public string Url { get; set; }
        public Alexa Alexa { get; set; }
        public SiteRankData SiteRankData { get; set; }
        public SimilarWeb SimilarWeb { get; set; }
        public GTmetrix GTmetrix { get; set; }
        public Whois Whois { get; set; }

        public string CompanyToCSV()
        {
            var result = $"{Name},{Url},{Alexa.ToCSV()},{SiteRankData.ToCSV()},{SimilarWeb.ToCSV()},{GTmetrix.ToCSV()},{Whois.ToCSV()}{Environment.NewLine}";
            return result;
        }

        public string TitleCSV()
        {
            var result = $"نام شرکت,آدرس,{Alexa.TitleCSV()},{SiteRankData.TitleCSV()},{SimilarWeb.TitleCSV()},{GTmetrix.TitleCSV()},{Whois.TitleCSV()}{Environment.NewLine}";
            return result;
        }
    }
}
