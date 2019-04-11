using DataAccessLibrary.DataAccess;
using DataAccessLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLibrary.Logic
{
    public static class ContactProcessor
    {
        public static int CreateContact(string firstName, string lastName, string phoneNumber, string emailAddress)
        {
            ContactModel data = new ContactModel
            {
                FirstName = firstName,
                LastName = lastName,
                PhoneNumber = phoneNumber,
                EmailAddress = emailAddress
            };

            string sql = @"insert into dbo.ContactTable(FirstName, LastName, PhoneNumber, EmailAddress)
                            values (@FirstName, @LastName, @PhoneNumber, @EmailAddress);";

            return SqlDataAccess.ExecuteDate(sql, data);
        }

        public static List<ContactModel> LoadContacts()
        {
            string sql = @"select * from dbo.ContactTable;";

            return SqlDataAccess.LoadData<ContactModel>(sql);
        }

        public static void DeleteContact(int id)
        {

            ContactModel data = new ContactModel
            {
                Id = id
            };

            string sql = @"delete from dbo.ContactTable where Id = @Id;";

            SqlDataAccess.ExecuteDate(sql, data);
        }

        public static void UpdateContact(int id, string firstName, string lastName, string phoneNumber, string emailAddress)
        {
            ContactModel data = new ContactModel
            {
                Id = id,
                FirstName = firstName,
                LastName = lastName,
                PhoneNumber = phoneNumber,
                EmailAddress = emailAddress
            };

            string sql = @"update dbo.ContactTable set FirstName = @FirstName, LastName = @LastName, 
                           PhoneNumber = @PhoneNumber, EmailAddress = @EmailAddress where Id = @Id;";

            SqlDataAccess.ExecuteDate(sql, data);
        }
    }
}
