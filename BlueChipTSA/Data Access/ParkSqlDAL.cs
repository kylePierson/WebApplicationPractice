using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BlueChipTSA.Models;
using System.Configuration;
using System.Data.SqlClient;

namespace BlueChipTSA.Data_Access
{
    public class ParkSqlDAL : IParkDAL
    {
        private string connectionString;
        private const string SQL_GetPark = @"SELECT * FROM park WHERE park_id=@parkId;";

        public ParkSqlDAL()
            : this(ConfigurationManager.ConnectionStrings["BlueChipTSADatabaseConnection"].ConnectionString)
        {
        }

        //Constructor
        public ParkSqlDAL(string databaseconnectionString)
        {
            connectionString = databaseconnectionString;
        }
        public Park GetPark(int parkId)
        {
            Park output = null;

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    SqlCommand cmd = new SqlCommand(SQL_GetPark, conn);
                    cmd.Parameters.AddWithValue("@parkId", parkId);

                    SqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        output = new Park();
                        output.ParkId = Convert.ToInt32(reader["park_id"]);
                        output.Name = Convert.ToString(reader["name"]);
                        output.Location = Convert.ToString(reader["location"]);
                        output.EstablishDate = Convert.ToDateTime(reader["establish_date"]);
                        output.Area = Convert.ToInt32(reader["area"]);
                        output.Description = Convert.ToString(reader["description"]);
                        output.AnnualVisitors = Convert.ToInt32(reader["visitors"]);
                    }
                }
            }
            catch (SqlException ex)
            {
                throw;
            }

            return output;
        }
    }
}