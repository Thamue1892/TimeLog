using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dataframework;
using Dataframework.Interface;
using Microsoft.AspNetCore.Http;
using ServiceFramework.Interface;
using ServiceFramework.Services;
using TimeLog.API.Models;

namespace TimeLog.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class DashboardController : Controller
    {
        private readonly IUserInProjectService userInProjectService;
        private readonly IProjectService projectService;
        private readonly IUserService userService;
        private readonly ITimeTrackerService timeTrackerService;
        private readonly IProjectTime projectTimeService;
        private IRepository<Dataframework.Entities.User> repository;


        public DashboardController()
        {
            projectService = new ProjectServices();
            userInProjectService = new UserInProjectService();
            repository = new Repository<Dataframework.Entities.User>();
            userService = new UserService(repository);
            timeTrackerService = new TimeTrackerService();
            projectTimeService = new ProjectTimeService();
        }

        [HttpGet]
        [Route("/Dashboard/UserProjects")]
        public List<ProjectModel> UserProjects(string? source)
        {
            //TODO session USer
            var user = Convert.ToInt32(HttpContext.Session.Get("Id"));

            List<ProjectModel> model = new List<ProjectModel>();
            var projects = projectService.GetAll().ToList();
            var projLogUser = userInProjectService.GetWhere(7).ToList();
            var projectTime = projectTimeService.GetUserTime(7).ToList();

            foreach (var proj in projects)
            {
                foreach (var userInProject in projLogUser)
                {
                    // foreach (var _timeProject in projectTime)
                    // {
                        if (proj.Id == userInProject.ProjectId)
                        {
                            ProjectModel mod = new ProjectModel
                            {
                                Id = proj.Id,
                                Name = proj.Name,
                                Time = "14:10"
                            };
                            model.Add(mod);
                        }
                    // }
                }
            }

            if (source is not null)
            {
                //return View(model);
            }

            return model;
        }


        [HttpGet]
        [Route("/Dashboard/EditTime")]
        public ProjectModel EditTime(int projectId)
        {
            return new ProjectModel();
        }
    }
}