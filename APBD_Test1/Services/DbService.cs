using APBD_Test1.DTOs;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
//using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
//using Lecture6.Helpers;

namespace Apbd_Test1.Services
{
    public class DbService : IDbService
    {
        private const string connectionString = @"Server=localhost\SQLEXPRESS01;Integrated Security=true;";

        public DbService() 
        {

        }

        public List<TeamTask> GetTasks(int teamMemberId, ControllerBase cBase, ref IActionResult actionResult) 
        {
            List<TeamTask> result = new List<TeamTask>();

            string sqlString = "Select * From Task Where IdCreator = @teamMemberId;";
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                using (var com = new SqlCommand(sqlString))
                {
                    com.Connection = con;
                    com.CommandText = sqlString;
                    com.Parameters.AddWithValue("teamMemberId", teamMemberId);

                    con.Open();
                    var dr = com.ExecuteReader();
                    while (dr.Read())
                    {
                        TeamTask teamTask = new TeamTask();
                        teamTask.name = dr["Name"].ToString();
                        teamTask.description = dr["Description"].ToString();
                        teamTask.deadline = dr["Deadline"].ToString();
                        teamTask.taskType = dr["IdTaskType"].ToString();


                        //teamTask.projectName = dr["projectName"].ToString();

                        result.Add(teamTask);
                        //id = int.Parse(dr["Id"].ToString()) + 1;
                    }
                }
            }

            if (result.Count == 0)
            {
                actionResult = cBase.NotFound("Not found");
            }

            return result;
        }

        public void DeleteProject(int projectId, ControllerBase cBase, ref IActionResult actionResult)
        {
            {
                string sqlString = "delete from Project Where IdTeam = @IdTeam";
                try
                {
                    using (SqlConnection con = new SqlConnection(connectionString))
                    {
                        using (var com = new SqlCommand(sqlString))
                        {
                            com.Connection = con;
                            com.CommandText = sqlString;
                            com.Parameters.AddWithValue("IdTeam", projectId);

                            con.Open();
                            com.ExecuteNonQuery();
                        }
                    }
                }
                catch (SqlException e) {
                    actionResult = cBase.Problem();
                }
            }

            {
                string sqlString = "delete from Task Where IdTeam = @IdTeam";
                try
                {
                    using (SqlConnection con = new SqlConnection(connectionString))
                    {
                        using (var com = new SqlCommand(sqlString))
                        {
                            com.Connection = con;
                            com.CommandText = sqlString;
                            com.Parameters.AddWithValue("IdTeam", projectId);

                            con.Open();
                            com.ExecuteNonQuery();
                        }
                    }
                }
                catch (SqlException e) {
                    actionResult = cBase.Problem();
                }
            }
        }


        //public void ClearLog() 
        //{
        //    DataLogger.ClearLog(DataLogger.requestsLogFile);

        //    {
        //        string sqlString = "delete from RequestsLog";
        //        try
        //        {
        //            using (SqlConnection con = new SqlConnection(connectionString))
        //            {
        //                using (var com = new SqlCommand(sqlString))
        //                {
        //                    com.Connection = con;
        //                    com.CommandText = sqlString;
        //                    con.Open();
        //                    com.ExecuteNonQuery();
        //                }
        //            }
        //        }
        //        catch (SqlException e) { }
        //    }

        //    {
        //        string sqlString = "Insert into RequestsLog values (0, 'start');";
        //        using (SqlConnection con = new SqlConnection(connectionString))
        //        {
        //            using (var com = new SqlCommand(sqlString))
        //            {
        //                com.Connection = con;
        //                com.CommandText = sqlString;
        //                con.Open();
        //                com.ExecuteNonQuery();
        //            }
        //        }
        //    }
        //}

        //private void InsertInto_RequestsLog(string data)
        //{
        //    int id = 0;

        //    {
        //        string sqlString = "Select MAX(Id) as Id From RequestsLog;";
        //        using (SqlConnection con = new SqlConnection(connectionString))
        //        {
        //            using (var com = new SqlCommand(sqlString))
        //            {
        //                com.Connection = con;
        //                com.CommandText = sqlString;

        //                con.Open();
        //                var dr = com.ExecuteReader();
        //                while (dr.Read())
        //                {
        //                    id = int.Parse(dr["Id"].ToString()) + 1;
        //                }
        //            }
        //        }
        //    }

        //    {
        //        string sqlString = "Insert into RequestsLog values (@id, @data);";

        //        using (SqlConnection con = new SqlConnection(connectionString))
        //        {
        //            using (var com = new SqlCommand(sqlString))
        //            {
        //                com.Connection = con;
        //                com.CommandText = sqlString;
        //                com.Parameters.AddWithValue("id", id);
        //                com.Parameters.AddWithValue("data", data);
        //                con.Open();
        //                com.ExecuteNonQuery();
        //            }
        //        }
        //    }
        //}

        //public void SaveLogData(string data)
        //{
        //    DataLogger.WriteToLogFile(DataLogger.requestsLogFile, data);

        //    InsertInto_RequestsLog(data);
        //}

        //public Student GetStudentByIndex(string index)
        //{
        //    return null;
        //}

        //public IEnumerable<Student> GetStudents()
        //{
        //    List<Student> _students = new List<Student>();

        //    using (SqlConnection con = new SqlConnection(connectionString))
        //    {
        //        using (var com = new SqlCommand("Select * From Student"))
        //        {
        //            com.Connection = con;

        //            con.Open();
        //            var dr = com.ExecuteReader();
        //            while (dr.Read())
        //            {
        //                var st = new Student();
        //                st.FirstName = dr["FirstName"].ToString();
        //                st.LastName = dr["LastName"].ToString();
        //                st.IndexNumber = dr["IndexNumber"].ToString();
        //                //...
        //                _students.Add(st);
        //            }
        //        }
        //    }

        //    return _students;
        //}

        //public Student GetStudentBy_IndexNumber(string IndexNumber)
        //{
        //    using (SqlConnection con = new SqlConnection(connectionString))
        //    {
        //        using (var com = new SqlCommand($"Select * From Student Where IndexNumber Like @IndexNumber"))
        //        {
        //            com.Connection = con;
        //            com.Parameters.AddWithValue("IndexNumber", IndexNumber);

        //            con.Open();
        //            var dr = com.ExecuteReader();
        //            while (dr.Read())
        //            {
        //                var st = new Student();
        //                st.FirstName = dr["FirstName"].ToString();
        //                st.LastName = dr["LastName"].ToString();
        //                st.IndexNumber = dr["IndexNumber"].ToString();

        //                return st;
        //            }
        //        }
        //    }

        //    return null;
        //}

        //public Student GetStudent(string name) 
        //{
        //    using (SqlConnection con = new SqlConnection(connectionString))
        //    {
        //        using (var com = new SqlCommand($"Select * From Student Where FirstName Like @name"))
        //        {
        //            com.Connection = con;
        //            com.Parameters.AddWithValue("name", name);

        //            con.Open();
        //            var dr = com.ExecuteReader();
        //            while (dr.Read())
        //            {
        //                var st = new Student();
        //                st.FirstName = dr["FirstName"].ToString();
        //                st.LastName = dr["LastName"].ToString();
        //                st.IndexNumber = dr["IndexNumber"].ToString();

        //                return st;
        //            }
        //        }
        //    }

        //    return null;
        //}

        //public List<int> GetSemesterEntries(int studentId)
        //{
        //    string sqlString = "Select e.Semester" + 
        //                        " From Enrollment e" +
        //                        " Where e.idEnrollment = (Select s.idEnrollment" +
        //                        " From Student s" +
        //                        $" Where s.IndexNumber = @studentId)";

        //    using (SqlConnection con = new SqlConnection(connectionString))
        //    {
        //        using (var com = new SqlCommand(sqlString))
        //        {
        //            com.Connection = con;
        //            com.CommandText = sqlString;
        //            com.Parameters.AddWithValue("studentId", studentId);

        //            con.Open();
        //            var dr = com.ExecuteReader();
        //            List<int> semesterEntries = new List<int>();
        //            while (dr.Read())
        //            {
        //                semesterEntries.Add(int.Parse(dr["Semester"].ToString()));
        //            }
        //            return semesterEntries;
        //        }
        //    }

        //    return null;
        //}
    }
}