using HtmlAgilityPack;
using MarketAnalysis.Helpers;
using System.Threading;

namespace MarketAnalysis.Model
{
    public class Analyze
    {
        private static Company Company;
        private static Alexa Alexa;
        private static SiteRankData SiteRankData;
        private static SimilarWeb SimilarWeb;
        private static GTmetrix GTmetrix;
        private static Whois Whois;

        public Company FullAnalyze(string inputSite)
        {
            Company = new Company();

            Company.Name = inputSite.Split('.')[0].Trim();
            Company.Url = inputSite;

            Thread alexaThread = new Thread(new ThreadStart(AlexaAnalyze));
            alexaThread.Start();
            Thread siteRankDataThread = new Thread(new ThreadStart(SiteRankDataAnalyze));
            siteRankDataThread.Start();
            Thread similarWebThread = new Thread(new ThreadStart(SimilarWebAnalyze));
            similarWebThread.Start();
            Thread gtmetrixThread = new Thread(new ThreadStart(GTmetrixAnalyze));
            gtmetrixThread.Start();
            Thread whoisThread = new Thread(new ThreadStart(WhoisAnalyze));
            whoisThread.Start();

            alexaThread.Join();
            siteRankDataThread.Join();
            similarWebThread.Join();
            gtmetrixThread.Join();
            whoisThread.Join();

            Company.Alexa = Alexa;
            Company.SiteRankData = SiteRankData;
            Company.SimilarWeb = SimilarWeb;
            Company.GTmetrix = GTmetrix;
            Company.Whois = Whois;

            return Company;
        }

        private static void WhoisAnalyze()
        {
            var uri = @"https://www.whois.com/whois/" + Company.Url;

            HtmlWeb web = new HtmlWeb();
            HtmlDocument doc = web.Load(uri);

            var ceo = doc.DocumentNode.SelectSingleNode(WhoisSelector.CEO)?.InnerText.ToString();
            var city = doc.DocumentNode.SelectSingleNode(WhoisSelector.City)?.InnerText.ToString();
            var PhoneNumber = doc.DocumentNode.SelectSingleNode(WhoisSelector.PhoneNumber)?.InnerText.ToString();
            var Email = doc.DocumentNode.SelectSingleNode(WhoisSelector.Email)?.InnerText.ToString();

            var whois = new Whois
            {
                CEO = ceo,
                City = city,
                PhoneNumber = PhoneNumber,
                Email = Email
            };

            Whois = whois;
        }

        private static void GTmetrixAnalyze()
        {
            var uri = @"https://gtmetrix.com/reports/" + Company.Url;

            HtmlWeb web = new HtmlWeb();
            HtmlDocument doc = web.Load(uri);

            var pageSpeed = doc.DocumentNode.SelectSingleNode(GTmetrixSelector.PageSpeed)?.InnerText.RemoveNumericFormat().TryToInt();
            var yslow = doc.DocumentNode.SelectSingleNode(GTmetrixSelector.YSlow)?.InnerText.RemoveNumericFormat().TryToInt();
            var pageLoad = doc.DocumentNode.SelectSingleNode(GTmetrixSelector.PageLoad)?.InnerText.RemoveNumericFormat().Replace("s", "").TryToDecimal();
            var pageSize = doc.DocumentNode.SelectSingleNode(GTmetrixSelector.PageSize)?.InnerText.RemoveNumericFormat().Replace("MB", "").TryToDecimal();

            var gtmetrix = new GTmetrix
            {
                PageSpeed = pageSpeed,
                YSlow = yslow,
                PageLoad = pageLoad,
                PageSize = pageSize
            };

            GTmetrix = gtmetrix;
        }

        private static void SimilarWebAnalyze()
        {
            var uri = @"https://www.similarweb.com/Company.Url/" + Company.Url;

            HtmlWeb web = new HtmlWeb();
            HtmlDocument doc = web.Load(uri);

            var direct = doc.DocumentNode.SelectSingleNode(SimilarWebSelector.Direct)?.InnerText.RemoveNumericFormat().TryToInt();
            var display = doc.DocumentNode.SelectSingleNode(SimilarWebSelector.Display)?.InnerText.RemoveNumericFormat().TryToInt();
            var mail = doc.DocumentNode.SelectSingleNode(SimilarWebSelector.Mail)?.InnerText.RemoveNumericFormat().TryToInt();
            var referral = doc.DocumentNode.SelectSingleNode(SimilarWebSelector.Referral)?.InnerText.RemoveNumericFormat().TryToInt();
            var search = doc.DocumentNode.SelectSingleNode(SimilarWebSelector.Search)?.InnerText.RemoveNumericFormat().TryToInt();
            var social = doc.DocumentNode.SelectSingleNode(SimilarWebSelector.Social)?.InnerText.RemoveNumericFormat().TryToInt();
            var topDestinationSites1 = doc.DocumentNode.SelectSingleNode(SimilarWebSelector.TopDestinationSites1)?.InnerText.ToString();
            var topDestinationSites2 = doc.DocumentNode.SelectSingleNode(SimilarWebSelector.TopDestinationSites2)?.InnerText.ToString();
            var topDestinationSites3 = doc.DocumentNode.SelectSingleNode(SimilarWebSelector.TopDestinationSites3)?.InnerText.ToString();
            var topDestinationSites4 = doc.DocumentNode.SelectSingleNode(SimilarWebSelector.TopDestinationSites4)?.InnerText.ToString();
            var topDestinationSites5 = doc.DocumentNode.SelectSingleNode(SimilarWebSelector.TopDestinationSites5)?.InnerText.ToString();
            var topReferringSites1 = doc.DocumentNode.SelectSingleNode(SimilarWebSelector.TopReferringSites1)?.InnerText.ToString();
            var topReferringSites2 = doc.DocumentNode.SelectSingleNode(SimilarWebSelector.TopReferringSites2)?.InnerText.ToString();
            var topReferringSites3 = doc.DocumentNode.SelectSingleNode(SimilarWebSelector.TopReferringSites3)?.InnerText.ToString();
            var topReferringSites4 = doc.DocumentNode.SelectSingleNode(SimilarWebSelector.TopReferringSites4)?.InnerText.ToString();
            var topReferringSites5 = doc.DocumentNode.SelectSingleNode(SimilarWebSelector.TopReferringSites5)?.InnerText.ToString();
            var topOrganicKeywords1 = doc.DocumentNode.SelectSingleNode(SimilarWebSelector.TopOrganickeywords1)?.InnerText.ToString();
            var topOrganicKeywords2 = doc.DocumentNode.SelectSingleNode(SimilarWebSelector.TopOrganickeywords2)?.InnerText.ToString();
            var topOrganicKeywords3 = doc.DocumentNode.SelectSingleNode(SimilarWebSelector.TopOrganickeywords3)?.InnerText.ToString();
            var topOrganicKeywords4 = doc.DocumentNode.SelectSingleNode(SimilarWebSelector.TopOrganickeywords4)?.InnerText.ToString();
            var topOrganicKeywords5 = doc.DocumentNode.SelectSingleNode(SimilarWebSelector.TopOrganickeywords5)?.InnerText.ToString();

            var similarWeb = new SimilarWeb
            {
                Direct = direct,
                Display = display,
                Mail = mail,
                Referral = referral,
                Search = search,
                Social = social,
                TopDestinationSites1 = topDestinationSites1,
                TopDestinationSites2 = topDestinationSites2,
                TopDestinationSites3 = topDestinationSites3,
                TopDestinationSites4 = topDestinationSites4,
                TopDestinationSites5 = topDestinationSites5,
                TopReferringSites1 = topReferringSites1,
                TopReferringSites2 = topReferringSites2,
                TopReferringSites3 = topReferringSites3,
                TopReferringSites4 = topReferringSites4,
                TopReferringSites5 = topReferringSites5,
                TopOrganicKeywords1 = topOrganicKeywords1,
                TopOrganicKeywords2 = topOrganicKeywords2,
                TopOrganicKeywords3 = topOrganicKeywords3,
                TopOrganicKeywords4 = topOrganicKeywords4,
                TopOrganicKeywords5 = topOrganicKeywords5
            };

            SimilarWeb = similarWeb;
        }

        private static void SiteRankDataAnalyze()
        {
            var uri = @"https://siterankdata.com/" + Company.Url;

            HtmlWeb web = new HtmlWeb();
            HtmlDocument doc = web.Load(uri);

            var dailyUniqueVisitors = doc.DocumentNode.SelectSingleNode(SiteRankDataSelector.DailyUniqueVisitors)?.InnerText.RemoveNumericFormat().TryToInt();
            var currentAlexaRank = doc.DocumentNode.SelectSingleNode(SiteRankDataSelector.CurrentAlexaRank)?.InnerText.RemoveNumericFormat().TryToInt();

            var siteRankData = new SiteRankData
            {
                DailyUniqueVisitors = dailyUniqueVisitors,
                CurrentAlexaRank = currentAlexaRank
            };

            SiteRankData = siteRankData;
        }

        private static void AlexaAnalyze()
        {
            var uri = @"https://www.alexa.com/siteinfo/" + Company.Url;

            HtmlWeb web = new HtmlWeb();
            HtmlDocument doc = web.Load(uri);

            var globalRank = doc.DocumentNode.SelectSingleNode(AlexaSelector.GlobalRank)?.InnerText.RemoveNumericFormat().TryToInt();
            var iranRank = doc.DocumentNode.SelectSingleNode(AlexaSelector.IranRank)?.InnerText.RemoveNumericFormat().TryToInt();
            var rankDiffernce = doc.DocumentNode.SelectSingleNode(AlexaSelector.RankDiffernce)?.InnerText.RemoveNumericFormat().TryToInt();
            var imagePath = doc.DocumentNode.SelectSingleNode(AlexaSelector.ImagePath)?.InnerText.Trim();
            var bounceRate = doc.DocumentNode.SelectSingleNode(AlexaSelector.BounceRate)?.InnerText.RemoveNumericFormat().TryToDecimal();
            var dailyPageView = doc.DocumentNode.SelectSingleNode(AlexaSelector.DailyPageView)?.InnerText.TryToDecimal();
            var dailyTime = doc.DocumentNode.SelectSingleNode(AlexaSelector.DailyTime)?.InnerText.Split(':')[0].TryToInt();
            var keyword1 = doc.DocumentNode.SelectSingleNode(AlexaSelector.Keyword1)?.InnerText.Trim();
            var keyword2 = doc.DocumentNode.SelectSingleNode(AlexaSelector.Keyword2)?.InnerText.Trim();
            var keyword3 = doc.DocumentNode.SelectSingleNode(AlexaSelector.Keyword3)?.InnerText.Trim();
            var keyword4 = doc.DocumentNode.SelectSingleNode(AlexaSelector.Keyword4)?.InnerText.Trim();
            var keyword5 = doc.DocumentNode.SelectSingleNode(AlexaSelector.Keyword5)?.InnerText.Trim();
            var backlinks = doc.DocumentNode.SelectSingleNode(AlexaSelector.Backlinks)?.InnerText.RemoveNumericFormat().TryToInt();

            var alexa = new Alexa
            {
                GlobalRank = globalRank,
                IranRank = iranRank,
                RankDiffernce = rankDiffernce,
                ImagePath = imagePath,
                BounceRate = bounceRate,
                DailyPageView = dailyPageView,
                DailyTime = dailyTime,
                Keyword1 = keyword1,
                Keyword2 = keyword2,
                Keyword3 = keyword3,
                Keyword4 = keyword4,
                Keyword5 = keyword5,
                Backlinks = backlinks
            };

            Alexa = alexa;
        }
    }
}
