using LiteDB;
using MarketAnalysis.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using static System.Environment;

namespace MarketAnalysis.Data
{
    public class ApplicationData
    {
        private string DataFolder;
        private const string DbName = "MarketAnalysis.db";
        private const string CsvName = "MarketAnalysis.csv";
        private string DbPath;

        public ApplicationData()
        {
            DataFolder = GetFolderPath(SpecialFolder.Desktop);
            DbPath = $"{DataFolder}\\{DbName}";
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

        public void UpdateOrInsert(Company company)
        {
            using (var db = new LiteDatabase(DbPath))
            {
                var companies = db.GetCollection<Company>("Companies");
                var update = companies.Update(company);
                if (!update)
                    companies.Insert(company);
            }
        }

        public void UpdateOrInsert(List<Company> companies)
        {
            foreach (var item in companies)
            {
                UpdateOrInsert(item);
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
            var data = new Company().TitleCSV();
            foreach (var item in companies)
            {
                data += item.CompanyToCSV();
            }

            var filepath = $"{DataFolder}\\{CsvName}";

            if (!File.Exists(filepath))
            {
                try
                {
                    FileStream fs = File.Create(filepath);
                    fs.Close();
                }
                catch (Exception)
                {
                }
            }
            File.WriteAllText(filepath, data, Encoding.UTF8);


            using (StreamWriter writer = new StreamWriter(filepath, true, Encoding.UTF8))
            {
                writer.WriteLine(data);
            }
        }
    }
}
