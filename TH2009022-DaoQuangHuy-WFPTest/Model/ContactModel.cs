using Microsoft.Data.Sqlite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TH2009022_DaoQuangHuy_WFPTest.Entities;

namespace TH2009022_DaoQuangHuy_WFPTest.Model
{
    class ContactModel
    {
        private static string _selectStatementWithConditionTemplate = "SELECT * FROM contacts WHERE Name like @keyword";
        public ContactModel()
        {
            DatabaseMigration.UpdateDatabase();
        }
        public bool Save(Contact contact)
        {
            try
            {
                using (SqliteConnection cnn = new SqliteConnection($"Filename={DatabaseMigration._databasePath}"))
                {
                    cnn.Open();
                    SqliteCommand command = new SqliteCommand("INSERT INTO contacts (PhoneNumber, Name)" +
                " values (@phoneNumber, @name)", cnn);
                    command.Parameters.AddWithValue("@phoneNumber", contact.phoneNumber);
                    command.Parameters.AddWithValue("@name", contact.name);
                    command.ExecuteNonQuery();
                    return true;
                }
            }
            catch (Exception)
            {
                return false;
            }
        }



        public List<Contact> FindAll()
        {
            List<Contact> result = new List<Contact>();
            try
            {
                using (SqliteConnection cnn = new SqliteConnection($"Filename={DatabaseMigration._databasePath}"))
                {
                    cnn.Open();
                    SqliteCommand command = new SqliteCommand("SELECT * FROM contacts", cnn);
                    var reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        var phoneNumber = reader.GetString(0);
                        var name = reader.GetString(1);
                        var contact = new Contact()
                        {
                            phoneNumber = phoneNumber,
                            name = name
                        };
                        result.Add(contact);
                    }
                }
            }
            catch (Exception e)
            {

                Console.WriteLine(e.Message);
            }
            return result;
        }


        public List<Contact> SearchByKeyword(string keyword)
        {
            List<Contact> contacts = new List<Contact>();
            try
            {
                //
                using (SqliteConnection cnn = new SqliteConnection($"Filename={DatabaseMigration._databasePath}"))
                {
                    cnn.Open();
                    //Tạo câu lệnh
                    SqliteCommand cmd = new SqliteCommand(_selectStatementWithConditionTemplate, cnn);

                    cmd.Parameters.AddWithValue("@keyword", "%" + keyword + "%");
                    //Bắn lệnh vào và lấy dữ liệu.
                    var reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        var phoneNumber = Convert.ToString(reader["PhoneNumber"]);
                        var name = Convert.ToString(reader["Name"]);
                        var contact = new Contact()
                        {
                            phoneNumber = phoneNumber,
                            name = name
                        };
                        contacts.Add(contact);
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            return contacts;
        }
    }
}
