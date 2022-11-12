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
                        StudentId = reader.GetString(0),
                        StudentName = reader.GetString(1),
                        Gender = reader.GetString(2),
                        DOB = reader.GetDateTime(3),
                        StudentPassword = reader.GetString(4),
                        StudentEmailAddr = !reader.IsDBNull(5) ?               // if not null
                                 reader.GetString(5) : (string)null
                    }
                );
            }
            //Close DataReader
            reader.Close();
            //Close the database connection
            conn.Close();

            return studentList;
        }

        public Student GetStudent(string studentId, string password)
        {
            SqlCommand cmd = conn.CreateCommand();
            cmd.CommandText = @"SELECT * FROM Student WHERE StudentID = @studentId AND Password = @password";
            cmd.Parameters.AddWithValue("@studentId", studentId);
            cmd.Parameters.AddWithValue("@password", password);
            conn.Open();
            SqlDataReader reader = cmd.ExecuteReader();
            Student student = new Student();
            if (reader.Read())
            {
                student.StudentId = reader.GetString(0);
                student.StudentName = reader.GetString(1);
                student.Gender = reader.GetString(2);
                student.DOB = reader.GetDateTime(3);
                student.StudentPassword = reader.GetString(4);
                student.StudentEmailAddr = reader.GetString(5);
            }
            reader.Close();
            conn.Close();
            return student;
        }
    }
}
