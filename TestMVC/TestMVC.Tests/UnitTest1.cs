using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using System.Configuration;
using System.Collections.Generic;
using TestMVC.Models;
using System.Linq;
using System.Data.Entity.Core.Objects;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;

namespace TestMVC.Tests
{
    [TestClass]
    public class UnitTest1
    {
        public static ObjectContext ConvertContext(DbContext db)
        {
            return ((IObjectContextAdapter)db).ObjectContext;
        }

        [TestMethod]
        public void GetStudentWithDataAdapter()
        {
            // 
            int studentId = 3;
            DataSet studentData = new DataSet("StudentData");
            DataTable studentTable = new DataTable("Student");
            studentData.Tables.Add(studentTable);

            StringBuilder sql = new StringBuilder();
            sql.Append("SELECT FirstName, LastName, EnrollmentDate, studentId");
            sql.Append("  FROM [dbo].[Student] WHERE studentId = @studentId");

            // ACT
            //Assumes an app.config file has the connection string
            using (SqlConnection mainConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["TestDB"].ConnectionString))
            {
                using (SqlCommand studentQuery = new SqlCommand(sql.ToString(), mainConnection))
                {
                    studentQuery.Parameters.AddWithValue("@studentId", studentId);
                    using (SqlDataAdapter studentAdapter = new SqlDataAdapter(studentQuery))
                    {
                        try
                        {
                            studentAdapter.Fill(studentData, "Student");
                        }
                        finally
                        {
                            //This should already be closed because of the using statement even if we encounter an exception
                            //but making it explicit in code
                            if(mainConnection.State != ConnectionState.Closed)
                            {
                                mainConnection.Close();
                            }
                        }
                    }
                }
            }

            // ASSERT
            Assert.AreEqual(studentTable.Rows.Count, 1, "We expected exactly 1 record to be returned.");
            Assert.AreEqual(studentTable.Rows[0].ItemArray[studentTable.Columns["studentId"].Ordinal], studentId, "The record returned has an ID different than expected.");
        }

        /// <summary>
        ///   Essentially the same result as above, but shows that dataReader will run slightly faster
        ///   (Run test separately or connection pooling will make the second test appear MUCH faster)
        /// </summary>
        [TestMethod]
        public void GetCustomerWithDataReader()
        {
            // ARRANGE
            // A better data structure than a tuple should probably be used here
            int studentId = 3;
            List<Tuple<string, string, DateTime, int>> results = new List<Tuple<string, string, DateTime, int>>();

            StringBuilder sql = new StringBuilder();
            sql.Append("SELECT FirstName, LastName, EnrollmentDate, studentId");
            sql.Append("  FROM [dbo].[Student] WHERE studentId = @studentId");

            //ACT
            using (SqlConnection mainConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["TestDB"].ConnectionString))
            {
                using (SqlCommand studentQuery = new SqlCommand(sql.ToString(), mainConnection))
                {
                    studentQuery.Parameters.AddWithValue("@studentId", studentId);
                    mainConnection.Open();
                    using (SqlDataReader reader = studentQuery.ExecuteReader(CommandBehavior.CloseConnection))
                    {
                        try
                        {
                            int firstNameIndex = reader.GetOrdinal("FirstName");
                            int lastNameIndex = reader.GetOrdinal("LastName");
                            int enrollmentDateIndex = reader.GetOrdinal("EnrollmentDate");
                            int studentIdIndex = reader.GetOrdinal("StudentId");

                            while (reader.Read())
                            {
                                results.Add(new Tuple<string, string, DateTime, int>(
                                    (string)reader[firstNameIndex], (string)reader[lastNameIndex],
                                    (DateTime)reader[enrollmentDateIndex], (int)reader[studentIdIndex]));
                            }
                        }
                        finally
                        {
                            //This should already be closed because of the using statement even if we encounter an exception
                            //but making it explicit in code
                            if (mainConnection.State != ConnectionState.Closed)
                            {
                                mainConnection.Close();
                            }
                        }
                    }
                }
            }

            // ASSERT
            Assert.AreEqual(results.Count, 1, "We expected exactly 1 record to be returned.");
            Assert.AreEqual(results[0].Item4, studentId, "The record returned has an ID different than expected.");
        }

        [TestMethod]
        public void GetStudentById()
        {
            //ASSERT
            int studentId = 3;
            TestEntities database = new TestEntities();

            //ACT
            Student result = database.Students.SingleOrDefault(stu => stu.StudentID == studentId);

            //ASSERT 
            Assert.IsNotNull(result, "Expected a value. Null here indicates no record with this ID.");
            Assert.AreEqual(result.StudentID, studentId, "Uh oh!");
        }

        [TestMethod]
        public void GetCustomerByIdOnObjectContext()
        {
            // ARRANGE
            int studentId = 3;
            TestEntities database = new TestEntities();
            ObjectContext context = ConvertContext(database);

            // ACT
            ObjectSet<Student> students = context.CreateObjectSet<Student>("Students");
            Student result = students.SingleOrDefault(stu => stu.StudentID == studentId);
            //Student result = database.Students.SingleOrDefault(stu => stu.StudentID == studentId);

            // ASSERT 
            Assert.IsNotNull(result, "Expected a value. Null here indicates no record with this ID.");
            Assert.AreEqual(result.StudentID, studentId, "Uh oh!");
        }
    }

    
}
