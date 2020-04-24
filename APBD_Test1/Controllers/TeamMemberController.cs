using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Apbd_Test1.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using APBD_Test1.DTOs;

namespace APBD_Test1.Controllers
{
    [ApiController]
    [Route("api/teamMembers")]
    public class TeamMemberController : ControllerBase
    {
        private readonly IDbService _dbService;

        public TeamMemberController(IDbService dbService)
        {
            _dbService = dbService;
        }

        [HttpGet]
        public IActionResult GetDefault() { return Ok("default response"); }

        [HttpGet("{teamMemberId}")]
        //name of the task, description, deadline, name of the project this task is a part of and the task type
        public IActionResult GetTeamMember_Tasks(int teamMemberId)
        {
            IActionResult actionResult = null;
            List<TeamTask> result = _dbService.GetTasks(teamMemberId, this, ref actionResult);
            if (actionResult != null)
                return actionResult;
            return Ok(result);
        }

        [HttpDelete("deleteProject/{projectId}")]
        public IActionResult DeleteProject(int projectId)
        {
            //DeleteProject
            IActionResult actionResult = null;
            _dbService.DeleteProject(projectId, this, ref actionResult);
            if (actionResult != null)
                return actionResult;
            return Ok($"Project  {projectId} deleted.");
        }
    }
}