using Microsoft.Data.Sqlite;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Storage;

namespace TH2009022_DaoQuangHuy_WFPTest.Model
{
    class DatabaseMigration
    {
        private static string _databaseFile = "mycontact.db";
        public static string _databasePath;
        private static string _createContactTable = "CREATE TABLE IF NOT EXISTS contacts " +
            "(PhoneNumber NVARCHAR(100) PRIMARY KEY," +
            "Name NVARCHAR(255) NOT NULL)";
        public async static void UpdateDatabase()
        {
            //Tạo đường dẫn.
            await ApplicationData.Current.LocalFolder.CreateFileAsync(_databaseFile, CreationCollisionOption.OpenIfExists);
            _databasePath = Path.Combine(ApplicationData.Current.LocalFolder.Path, _databaseFile);
            using (SqliteConnection cnn = new SqliteConnection($"Filename = {_databasePath}"))
            {
                cnn.Open();
                SqliteCommand command = new SqliteCommand(_createContactTable, cnn);
                command.ExecuteNonQuery();

            }
        }
    }
}
