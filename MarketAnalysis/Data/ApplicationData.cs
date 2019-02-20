using LiteDB;
using MarketAnalysis.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace MarketAnalysis.Data
{
    public class ApplicationData
    {
        private const string DbFileName = "MarketAnalysis.db";
        private const string DataFileName = "MarketAnalysis.csv";
        private string DataFolder;
        private string DataFile;
        private string DbFile;

        public ApplicationData()
        {
            DataFolder = Properties.Settings.Default.DefaultPath;
            DataFile = $"{DataFolder}{DataFileName}";
            DbFile = $"{DataFolder}{DbFileName}";
        }

        public void Insert(Company company)
        {
            using (var db = new LiteDatabase(DbFile))
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
            using (var db = new LiteDatabase(DbFile))
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
            using (var db = new LiteDatabase(DbFile))
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
            using (var db = new LiteDatabase(DbFile))
            {
                var companies = db.GetCollection<Company>("Companies");
                return companies.FindAll().ToArray();
            }
        }

        public void SaveToCSV(List<Company> companies)
        {
            var data = new Company().TitleCSV();
            foreach (var item in companies)
            {
                data += item.CompanyToCSV();
            }

            if (!File.Exists(DataFile))
            {
                try
                {
                    FileStream fs = File.Create(DataFile);
                    fs.Close();
                }
                catch (Exception)
                {
                }
            }
            File.WriteAllText(DataFile, data, Encoding.UTF8);
        }
    }
}
