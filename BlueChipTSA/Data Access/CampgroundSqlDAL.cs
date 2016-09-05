using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BlueChipTSA.Models;
using System.Configuration;
using System.Data.SqlClient;

namespace BlueChipTSA.Data_Access
{
    public class CampgroundSqlDAL : ICampgroundDAL
    {
        private string connectionString;
        private const string SQL_GetCampground = @"SELECT * FROM campground WHERE campground_id=@campgroundId;";
        private const string SQL_GetCampgroundsForPark = @"SELECT * FROM campground WHERE park_id=@parkId;";

        public CampgroundSqlDAL()
            : this(ConfigurationManager.ConnectionStrings["BlueChipTSADatabaseConnection"].ConnectionString)
        {
        }

        public CampgroundSqlDAL(string databaseconnectionString)
        {
            connectionString = databaseconnectionString;
        }
        public Campground GetCampground(int campgroundId)
        {
            Campground output = null;

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    SqlCommand cmd = new SqlCommand(SQL_GetCampground, conn);
                    cmd.Parameters.AddWithValue("@campgroundId", campgroundId);

                    SqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        output = new Campground();
                        output.ParkId = Convert.ToInt32(reader["park_id"]);
                        output.CampgroundId = Convert.ToInt32(reader["campground_id"]);
                        output.Name = Convert.ToString(reader["name"]);
                        output.Location = Convert.ToString(reader["location"]); ;
                        output.UtilityHookup = Convert.ToString(reader["utility_hookup"]);
                        output.DumpStation = Convert.ToString(reader["dump_station"]);
                    }
                }
            }
            catch (SqlException ex)
            {
                throw;
            }

            return output;
        }

        public List<Campground> GetCampgroundsForPark(int parkId)
        {
            List<Campground> output = new List<Campground>();


            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    SqlCommand cmd = new SqlCommand(SQL_GetCampgroundsForPark, conn);
                    cmd.Parameters.AddWithValue("@parkId", parkId);


                    SqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        Campground c = new Campground()
                        {
                            CampgroundId=Convert.ToInt32(reader["campground_id"]),
                            ParkId=Convert.ToInt32(reader["park_id"]),
                            Name=Convert.ToString(reader["name"]),
                            Location=Convert.ToString(reader["location"]),
                            UtilityHookup=Convert.ToString(reader["utility_hookup"]),
                            DumpStation=Convert.ToString(reader["dump_station"])
                        };

                        output.Add(c);
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