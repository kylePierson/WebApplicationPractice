using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BlueChipTSA.Models;
using System.Configuration;
using System.Data.SqlClient;

namespace BlueChipTSA.Data_Access
{
    public class MailingListSqlDAL : IMailingListDAL
    {
        private string connectionString;
        private const string SQL_GetAllEmailAddresses = @"SELECT * FROM mailinglist;";
        private const string SQL_AddEmail = @"INSERT INTO mailinglist VALUES (@firstname, @lastname, @emailAddress, @phoneNumber, @address);";

        public MailingListSqlDAL()
            : this(ConfigurationManager.ConnectionStrings["BlueChipTSADatabaseConnection"].ConnectionString)
        {
        }

        public MailingListSqlDAL(string databaseconnectionString)
        {
            connectionString = databaseconnectionString;
        }
        public bool AddEmail(NewEmail newEmail)
        {
            int rowsAffected = 0;
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    SqlCommand cmd = new SqlCommand(SQL_AddEmail, conn);
                    cmd.Parameters.AddWithValue("@firstname", newEmail.FirstName);
                    cmd.Parameters.AddWithValue("@lastname", newEmail.LastName);
                    cmd.Parameters.AddWithValue("@emailAddress", newEmail.EmailAddress);
                    cmd.Parameters.AddWithValue("@phoneNumber", newEmail.PhoneNumber);
                    cmd.Parameters.AddWithValue("@address", newEmail.Address);

                    rowsAffected = cmd.ExecuteNonQuery();
                }
            }
            catch (SqlException ex)
            {
                //log exception
            }

            return rowsAffected > 0;
        }

        public List<NewEmail> GetAllEmailAddresses()
        {
            throw new NotImplementedException();
        }
    }
}