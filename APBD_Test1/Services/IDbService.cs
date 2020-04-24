using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using APBD_Test1.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace Apbd_Test1.Services
{
    public interface IDbService
    {
        public List<TeamTask> GetTasks(int teamMemberId, ControllerBase cBase, ref IActionResult actionResult);

        public void DeleteProject(int projectId, ControllerBase cBase, ref IActionResult actionResult);

        //public IEnumerable<Student> GetStudents();
        //public Student GetStudent(string name);
        //public List<int> GetSemesterEntries(int studentId);

        //public Student GetStudentByIndex(string index);

        //public void SaveLogData(string data);

        //public Student GetStudentBy_IndexNumber(string IndexNumber);

        //public void ClearLog();
    }
}
