using LiteDB;
using MarketAnalysis.Model;
using System.Collections.Generic;
using System.IO;
using System.Text;
using static System.Environment;

namespace MarketAnalysis.Data
{
    public class ApplicationData
    {
        private string DbPath;

        public ApplicationData()
        {
            DbPath = $"{GetFolderPath(SpecialFolder.Desktop)}/MarketAnalysis.db";
        }

        public void Insert(Company company)
        {
            using (var db = new LiteDatabase(DbPath))
            {
                var companies = db.GetCollection<Company>("Companies");
                companies.Insert(company);
            }
        }

        public void Insert(List<Company> companies)
        {
            foreach (var item in companies)
            {
                Insert(item);
            }
        }

        public void Update(Company company)
        {
            using (var db = new LiteDatabase(DbPath))
            {
                var companies = db.GetCollection<Company>("Companies");
                companies.Update(company);
            }
        }

        public void Update(List<Company> companies)
        {
            foreach (var item in companies)
            {
                Update(item);
            }
        }

        public IEnumerable<Company> GetAll()
        {
            using (var db = new LiteDatabase(DbPath))
            {
                var companies = db.GetCollection<Company>("Companies");
                return companies.FindAll();
            }
        }

        public void SaveToCSV(List<Company> companies)
        {
            var csv = new Company().TitleCSV();
            foreach (var item in companies)
            {
                csv += item.CompanyToCSV();
            }

            var filepath = $"{DbPath}\\Output.csv";
            using (StreamWriter writer = new StreamWriter(filepath, true, Encoding.UTF8))
            {
                writer.WriteLine(csv);
            }
        }
    }
}
