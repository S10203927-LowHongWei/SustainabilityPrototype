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
    public class FoodDAL
    {
        private IConfiguration Configuration { get; }
        private SqlConnection conn;

        public FoodDAL()
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

        //Get Food details
        public List<Food> GetAllFood()
        {
            //Create a SqlCommand object from connection object
            SqlCommand cmd = conn.CreateCommand();
            //Specify the SELECT SQL statement 
            cmd.CommandText = @"SELECT * FROM Student ORDER BY StudentID";
            //Open a database connection
            conn.Open();
            //Execute the SELECT SQL through a DataReader
            SqlDataReader reader = cmd.ExecuteReader();
            //Read all records until the end, save data into a staff list
            List<Food> foodList = new List<Food>();
            while (reader.Read())
            {
                foodList.Add(
                    new Food
                    {
                        FoodId = reader.GetInt32(0),
                        StoreId = reader.GetInt32(1),
                        Name = reader.GetString(2),
                        
                    }
                );
            }
            //Close DataReader
            reader.Close();
            //Close the database connection
            conn.Close();

            return foodList;
        }

        public List<Food> foodListByStoreId(int storeId)
        {
            List<Food> foodList = GetAllFood();
            List<Food> foodListByStoreId = new List<Food>();

            foreach (Food item in foodList)
            {
                if(item.StoreId == storeId)
                {
                    foodList.Add(item);
                }
            }

            return foodListByStoreId;
            
        }

    }
}
