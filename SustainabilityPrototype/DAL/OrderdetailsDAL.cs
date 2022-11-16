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
    public class OrderdetailsDAL
    {
        private IConfiguration Configuration { get; }
        private SqlConnection conn;
        //Constructor
        public OrderdetailsDAL()
        {
            //Read ConnectionString from appsettings.json file
            var builder = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json");
            Configuration = builder.Build();
            string strConn = Configuration.GetConnectionString("NPBookConnectionString");
            //Instantiate a SqlConnection object with the 
            //Connection String read. 
            conn = new SqlConnection(strConn);
        }

        public int Add(Orderdetails orderdetails)
        {
            //Create a SqlCommand object from connection object
            SqlCommand cmd = conn.CreateCommand();
            //Specify an INSERT SQL statement which will
            //return the auto-generated StaffID after insertion
            cmd.CommandText = @"INSERT INTO Customer (OrderDetailID, OrderID, FoodID, SpecialRequest, OrderQty)
                                VALUES(@orderdetailid,@orderid, @foodid, @specailrequest, @orderqty)";
            //Define the parameters used in SQL statement, value for each parameter
            //is retrieved from respective class's property.
            cmd.Parameters.AddWithValue("@orderdetailid", orderdetails.OrderId);
            cmd.Parameters.AddWithValue("@orderid", orderdetails.OrderId);
            cmd.Parameters.AddWithValue("@foodid", orderdetails.FoodId);
            cmd.Parameters.AddWithValue("@specialrequest", orderdetails.SpecialRequest);
            cmd.Parameters.AddWithValue("@orderqty", orderdetails.OrderQty);
            //A connection to database must be opened before any operations made.
            conn.Open();
            //ExecuteScalar is used to retrieve the auto-generated
            //StaffID after executing the INSERT SQL statement
            //This helps to return the staffID
            //If non scaler, will execute query but would not return staffID
            orderdetails.OrderDetailsId = (int)cmd.ExecuteScalar();
            //A connection should be closed after operations.
            conn.Close();
            //Return id when no error occurs.
            return orderdetails.OrderDetailsId;
        }
    }
}
