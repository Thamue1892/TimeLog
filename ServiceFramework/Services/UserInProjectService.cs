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
    public class UserInProjectService : IUserInProjectService
    {
        private IRepository<UserInProject> projRepository;
        public UserInProjectService()
        {
            projRepository = new Repository<UserInProject>();
        }
        public List<UserInProject> GetAll()
        {
            return projRepository.GetAll().ToList();
        }

        public bool Insert(UserInProject userInProject)
        {
            throw new NotImplementedException();
        }

        public List<UserInProject> GetWhere(int Id)
        {
            return projRepository.GetWhere(x => x.UserId == Id).ToList();
        }

        public bool Delete(int key)
        {
            throw new NotImplementedException();
        }
    }
}
