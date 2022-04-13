using System.Collections.Generic;
using Dataframework.Entities;

namespace ServiceFramework.Interface
{
    public interface IUserService
    {
        List<User> GetAllUser();
        bool RegisterUser(User user);

        User GetFirst(string emailAddress);
        void Update(User user);

    }
}