using HtmlAgilityPack;
using MarketAnalysis.Helpers;
using MarketAnalysis.Utility;
using System;
using System.Threading;

namespace MarketAnalysis.Model
{
    public static class Analyse
    {
        public static Company FullAnalyse(this Company company)
        {
            var alexaThread = new Thread(
                () =>
                {
                    company.Alexa = AlexaAnalyse(company.Url);
                });
            alexaThread.Start();

            var siteRankDataThread = new Thread(
                () =>
                {
                    company.SiteRankData = SiteRankDataAnalyse(company.Url);
                });
            siteRankDataThread.Start();

            var similarWebThread = new Thread(
                () =>
                {
                    company.SimilarWeb = SimilarWebAnalyse(company.Url);
                });
            similarWebThread.Start();

            var gtmetrixThread = new Thread(
                () =>
                {
                    company.GTmetrix = GTmetrixAnalyse(company.Url);
                });
            gtmetrixThread.Start();

            var whoisThread = new Thread(
                () =>
                {
                    company.Whois = WhoisAnalyse(company.Url);
                });
            whoisThread.Start();

            alexaThread.Join();
            siteRankDataThread.Join();
            similarWebThread.Join();
            gtmetrixThread.Join();
            whoisThread.Join();

            return company;
        }

        private static Whois WhoisAnalyse(string companyUrl)
        {
            var uri = @"https://www.whois.com/whois/" + companyUrl;

            HtmlWeb web = new HtmlWeb();
            HtmlDocument doc = new HtmlDocument();

            try
            {
                doc = web.Load(uri);
            }
            catch (Exception)
            {
            }

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

            return whois;
        }

        private static GTmetrix GTmetrixAnalyse(string companyUrl)
        {
            var uri = @"https://gtmetrix.com/reports/" + companyUrl;

            HtmlWeb web = new HtmlWeb();
            HtmlDocument doc = new HtmlDocument();

            try
            {
                doc = web.Load(uri);
            }
            catch (Exception)
            {
            }

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

            return gtmetrix;
        }

        private static SimilarWeb SimilarWebAnalyse(string companyUrl)
        {
            var uri = @"https://www.similarweb.com/" + companyUrl;

            HtmlWeb web = new HtmlWeb();
            HtmlDocument doc = new HtmlDocument();

            try
            {
                doc = web.Load(uri);
            }
            catch (Exception)
            {
            }

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

            return similarWeb;
        }

        private static SiteRankData SiteRankDataAnalyse(string companyUrl)
        {
            var uri = @"https://siterankdata.com/" + companyUrl;

            HtmlWeb web = new HtmlWeb();
            HtmlDocument doc = new HtmlDocument();

            try
            {
                doc = web.Load(uri);
            }
            catch (Exception)
            {
            }

            var dailyUniqueVisitors = doc.DocumentNode.SelectSingleNode(SiteRankDataSelector.DailyUniqueVisitors)?.InnerText.RemoveNumericFormat().TryToInt();
            var currentAlexaRank = doc.DocumentNode.SelectSingleNode(SiteRankDataSelector.CurrentAlexaRank)?.InnerText.RemoveNumericFormat().TryToInt();

            var siteRankData = new SiteRankData
            {
                DailyUniqueVisitors = dailyUniqueVisitors,
                CurrentAlexaRank = currentAlexaRank
            };

            return siteRankData;
        }

        private static Alexa AlexaAnalyse(string companyUrl)
        {
            var uri = @"https://www.alexa.com/siteinfo/" + companyUrl;

            HtmlWeb web = new HtmlWeb();
            HtmlDocument doc = new HtmlDocument();

            try
            {
                doc = web.Load(uri);
            }
            catch (Exception)
            {
            }

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

            return alexa;
        }
    }
}
