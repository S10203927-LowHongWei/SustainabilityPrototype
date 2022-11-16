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
    public class VendorDAL
    {
        private IConfiguration Configuration { get; }
        private SqlConnection conn;

        //Constructor
        public VendorDAL()
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
        public Vendor GetVendor(string vendorUsername, string password)
        {
            //Create a SqlCommand object from connection object
            SqlCommand cmd = conn.CreateCommand();
            //Specify the SELECT SQL statement 
            cmd.CommandText = @"SELECT * FROM Vendor WHERE Username = @username AND Password = @password";
            cmd.Parameters.AddWithValue("@username", vendorUsername);
            cmd.Parameters.AddWithValue("@password", password);
            //Open a database connection
            conn.Open();
            //Execute the SELECT SQL through a DataReader
            SqlDataReader reader = cmd.ExecuteReader();
            //Read all records until the end, save data into a staff list
            Vendor v = new Vendor();
            if (reader.Read())
            {
                v.VendorID = reader.GetInt32(0);
                v.Username = reader.GetString(1);
                v.StallName = reader.GetString(2);
                v.Password = reader.GetString(3);
                v.CanteenID = reader.GetInt32(4);
            }
            reader.Close();
            conn.Close();
            return v;
        }

        public int getVendorPoints(int id)
        {

            //Create a SqlCommand object from connection object
            SqlCommand cmd = conn.CreateCommand();
            //Specify the SELECT SQL statement 
            cmd.CommandText = @"SELECT * FROM VendorPoints WHERE VendorID = @vendorID";
            cmd.Parameters.AddWithValue("@vendorID", id);
            //Open a database connection
            conn.Open();
            //Execute the SELECT SQL through a DataReader
            SqlDataReader reader = cmd.ExecuteReader();
            //Read all records until the end, save data into a staff list
            int result = 0;
            if (reader.Read())
            {
                result = reader.GetInt32(0);
               
            }
            reader.Close();
            conn.Close();
            return result;


        }
    }
}
