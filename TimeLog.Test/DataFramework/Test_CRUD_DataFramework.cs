using System.Linq;
using Dataframework;
using Dataframework.Entities;
using Dataframework.Interface;
using NUnit.Framework;

namespace TimeLog.Test.DataFramework
{
    [TestFixture]
    public class Test_CRUD_DataFramework
    {
        private IRepository<User> repo;
        [SetUp]
        public void setUp()
        {
            repo = new Repository<User>();
        }


        [Test]
        public void test_getall_returns_null()
        {
            var users = repo.GetAll().ToList();
            Assert.That(users, Is.Not.InnerException);
            Assert.That(users.Count, Is.EqualTo(0));
        }

        [Test]
        public void test_getall_returns_list_of_users()
        {
            var users = repo.GetAll().ToList();
            Assert.That(users, Is.Not.InnerException);
            Assert.That(users.Count, Is.GreaterThanOrEqualTo(1));
        }


        [Test]
        public void test_user_insert_successfully()
        {
            User user = new User
            {
                FullName = "Mr T",
                Email = "mrt@example.com",
                Address = "sdsd",
                SupervisorId = 0,
                RoleId = 0
            };
            repo.Insert(user);
            Assert.That(() => repo.Insert(user), Is.Not.InnerException);
        }

        [Test]
        public void test_user_update_returns_successfully()
        {
            User user = new User
            {
                Id = 1,
                FullName = "Mr T -edit",
                Email = "mrt@example.com",
                Address = "sdsd",
                SupervisorId = 0,
                RoleId = 0
            };
            repo.Update(user);
            Assert.That(() => repo.Update(user), Is.Not.InnerException);
        }


        [Test]
        public void test_user_delete_successfully()
        {
            User user = new User
            {
                Id = 1,
                FullName = "Mr T -edit",
                Email = "mrt@example.com",
                Address = "sdsd",
                SupervisorId = 0,
                RoleId = 0
            };
            repo.Update(user);
            Assert.That(() => repo.Update(user), Is.Not.InnerException);
        }



        //[Test]
        //public void test_user_insert_user_allready_exist()
        //{
        //    User user = new User
        //    {
        //        FullName = "Mr T",
        //        Email = "mrt@example.com",
        //        Address = "sddfdfsd",
        //        SupervisorId = 0,
        //        RoleId = 0
        //    };
        //    Assert.That(() => repo.Insert(user), Throws.Exception);
        //}



    }
}