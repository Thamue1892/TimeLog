using System.Collections.Generic;
using System.Collections.ObjectModel;
using Dataframework.Interface;

namespace Dataframework.Entities
{
    public class User : IUser
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public int SupervisorId { get; set; }
        public int RoleId { get; set; }
        public bool IsActive { get; set; }

        public IList<UserInProject> UserInProject { get; set; }
    }
}