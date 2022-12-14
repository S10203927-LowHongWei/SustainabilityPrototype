using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using System.IO;
using System.Data.SqlClient;
using SustainabilityPrototype.Models;


namespace SustainabilityPrototype.DAL
{
    public class CanteenDAL
    {
        private IConfiguration Configuration { get; }
        private SqlConnection conn;

        //Constructor
        public CanteenDAL()
        {
            //Read ConnectionString from appsettings.json file
            var builder = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json");
            Configuration = builder.Build();
            string strConn = Configuration.GetConnectionString(
            "SustainabilityPFD");

            //Instantiate a SqlConnection object with the 
            //Connection String read. 
            conn = new SqlConnection(strConn);
        }

        //Get Student details
        public List<Canteen> GetAllCanteen()
        {
            //Create a SqlCommand object from connection object
            SqlCommand cmd = conn.CreateCommand();
            //Specify the SELECT SQL statement 
            cmd.CommandText = @"SELECT * FROM Canteen ORDER BY CanteenID";
            //Open a database connection
            conn.Open();
            //Execute the SELECT SQL through a DataReader
            SqlDataReader reader = cmd.ExecuteReader();
            //Read all records until the end, save data into a staff list
            List<Canteen> canteenList = new List<Canteen>();
            while (reader.Read())
            {
                canteenList.Add(
                    new Canteen
                    {
                        CanteenId = reader.GetInt32(0),
                        CanteenName = reader.GetString(1),
                        Location = reader.GetString(2),
                    }
                );
            }
            //Close DataReader
            reader.Close();
            //Close the database connection
            conn.Close();

            return canteenList;
        }
    }
}
