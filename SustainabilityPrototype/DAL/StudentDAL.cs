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
    public class StudentDAL
    {
        private IConfiguration Configuration { get; }
        private SqlConnection conn;

        //Constructor
        public StudentDAL()
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
        public List<Student> GetAllStudent()
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
            List<Student> studentList = new List<Student>();
            while (reader.Read())
            {
                studentList.Add(
                    new Student
                    {
                        StudentId = reader.GetInt32(0),
                        Username = reader.GetString(1),
                        StudentName = reader.GetString(2),
                        Gender = reader.GetString(3),
                        DOB = reader.GetDateTime(4),
                        StudentPassword = reader.GetString(5),
                        StudentEmailAddr = !reader.IsDBNull(6) ?               // if not null
                                 reader.GetString(6) : (string)null
                    }
                );
            }
            //Close DataReader
            reader.Close();
            //Close the database connection
            conn.Close();

            return studentList;
        }

        public Student GetStudent(string username, string password)
        {
            SqlCommand cmd = conn.CreateCommand();
            cmd.CommandText = @"SELECT * FROM Student WHERE Username = @username AND Password = @password";
            cmd.Parameters.AddWithValue("@username", username);
            cmd.Parameters.AddWithValue("@password", password);
            conn.Open();
            SqlDataReader reader = cmd.ExecuteReader();
            Student student = new Student();
            if (reader.Read())
            {
                student.StudentId = reader.GetInt32(0);
                student.Username = reader.GetString(1);
                student.StudentName = reader.GetString(2);
                student.Gender = reader.GetString(3);
                student.DOB = reader.GetDateTime(4);
                student.StudentPassword = reader.GetString(5);
                student.StudentEmailAddr = reader.GetString(6);
            }
            reader.Close();
            conn.Close();
            return student;
        }
    }
}
