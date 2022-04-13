using System.Linq;
using Dataframework;
using Dataframework.Entities;
using Dataframework.Interface;
using NUnit.Framework;
using ServiceFramework;
using ServiceFramework.Services;

namespace TimeLog.Test.ServiceFramework
{
    [TestFixture]
    public class TestUserServiceFramework
    {
        private IRepository<User> repo;
        [SetUp]
        public void setUp()
        {
            repo = new Repository<User>();
        }

        [Test]
        public void CanInstatiateClass()
        {
            Assert.That(new UserService(repo), Is.Not.Null);
        }


        [Test]
        public void test_get_all_users_return_more_than_one_raws()
        {
            var service = new UserService(repo);
            var data = service.GetAllUser();
            Assert.IsTrue(data != null && data.Any());
        }


        [Test]
        public void test_new_user_registration_return_successfully()
        {
            var service = new UserService(repo);
            var thami = new User
            {
                FullName = "Mr T",
                Email = "mrt@example.com",
                Address = "101 Love day",
                SupervisorId = 1,
                RoleId = 1,
                IsActive = false
            };
            bool isSaved = service.RegisterUser(thami);
            Assert.IsTrue(isSaved);
        }
    }
}