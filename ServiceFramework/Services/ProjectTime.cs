using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dataframework;
using Dataframework.Entities;
using Dataframework.Interface;
using ServiceFramework.Interface;

namespace ServiceFramework.Services
{
    public class ProjectTimeService: IProjectTime
    {
        private IRepository<TimeInProject> projectTimeRepository;
        public ProjectTimeService()
        {
            this.projectTimeRepository = new Repository<TimeInProject>();
        }
        public List<TimeInProject> GetUserTime(int id) => 
            projectTimeRepository.GetWhere(x => x.ProjectId == id).ToList();


        public List<TimeInProject> UserTimePerProject(int id)
            =>
                projectTimeRepository.GetWhere(x => x.TimeTrackerId == id).ToList();
    }
}
