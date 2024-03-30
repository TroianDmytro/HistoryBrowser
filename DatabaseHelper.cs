using Dapper;
using Microsoft.Data.Sqlite;
using System.Diagnostics;

namespace WinFormsApp1
{
    public class DatabaseHelper
    {
        private string connectionString;

        public DatabaseHelper(string dbFilePath)
        {
            connectionString = $"Data Source={dbFilePath}";
        }

        public List<MyData> GetMyData()
        {
            using (var connection = new SqliteConnection(connectionString))
            {
                connection.Open();
                string query = "SELECT * FROM [visited_links]";
                try
                {
                    return connection
                            .Query<MyData>(query)
                            .OrderByDescending(x => x.id)
                            .ToList();
                }
                catch (Exception)
                {
                    DialogResult result = MessageBox.Show("Loading error maybe open Chrom. Closed Chrom?", "",MessageBoxButtons.OKCancel);
                    if ( result == DialogResult.OK)
                    {
                        string processName = "chrome";
                        Process[] allSelectedProcesses =
                        Process.GetProcessesByName(processName);
                        foreach (Process process in allSelectedProcesses)
                        {
                            process.Kill();
                        }

                        return connection
                            .Query<MyData>(query)
                            .OrderByDescending(x => x.id)
                            .ToList();
                    }
                    else
                    {
                        return GetMyData();
                    }
                }
            }
        }

        //public void InsertMyData(MyData data)
        //{
        //    using (var connection = new SqliteConnection(connectionString))
        //    {
        //        connection.Open();
        //        string query = "INSERT INTO MyDataTable (Name) VALUES (@Name)";
        //        connection.Execute(query, data);
        //    }
        //}
    }
}
