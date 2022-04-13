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
    public class ProjectServices : IProjectService
    {
        private List<Project> Projects { get; set; }
        private IRepository<Project> projRepository;

        public ProjectServices()
        {
            projRepository = new Repository<Project>();
        }

     //   public ProjectServices(IRepository<Project> projRepository) => this.projRepository = projRepository;
        public List<Project> GetAll()
        {
            return projRepository.GetAll().ToList();
        }
    }
}
