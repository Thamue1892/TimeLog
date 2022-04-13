using System.Collections.Generic;
using Dataframework.Entities;

namespace ServiceFramework.Interface
{
    public interface IUserInProjectService
    {
        List<UserInProject> GetAll();
        bool Insert(UserInProject userInProject);
        List<UserInProject> GetWhere(int Id);
        bool Delete(int key);
    }
}