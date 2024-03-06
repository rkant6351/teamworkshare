using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

using WebApiCaseStudyCFTry1.Controllers;
using WebApiCaseStudyCFTry1.Data;
using WebApiCaseStudyCFTry1.Models;

namespace CStest
{
    internal class UsersTest
    {
        private IConfiguration _config;
        private DbContextOptions<CaseStudyDbContext> _options;

        [SetUp]
        public void Setup()
        {
            _config = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build();
            _options = new DbContextOptionsBuilder<CaseStudyDbContext>()
                .UseSqlServer(_config.GetConnectionString("CaseStudyDbContext"))
                .Options;
        }

        [Test]
        public async Task PostUserTest()
        {
            using (var context = new CaseStudyDbContext(_options))
            {
                var userController = new UsersController(context);
                var newUser = new Users()
                {
                    FullName = "User Test",
                    Email = "usertest@gmail.com",
                    PhoneNumber = "9535905126",
                    Password = "Usertest@123",
                    Gender = "Male",
                    Address = "User Test Address"
                };
                await userController.PostUsers(newUser);
                var addedUser = context.Users.FirstOrDefault(u => u.Email == newUser.Email);
                Assert.IsNotNull(addedUser);
                Assert.AreEqual(newUser.Email, addedUser.Email);
                Assert.AreEqual(newUser.Password, addedUser.Password);
            }
        }

        [Test]
        public async Task GetUserByIdTest()
        {
            using (var context = new CaseStudyDbContext(_options))
            {
                var userController = new UsersController(context);
                var user1 = context.Users.FirstOrDefault(u => u.UserId == 1);
                Assert.IsNotNull(user1);
                Assert.AreEqual(user1.UserId, 1);
                Assert.AreEqual(user1.Password, "Gaurav@123");
            }
        }

        [Test]
        public async Task GetUserTest()
        {
            using (var context = new CaseStudyDbContext(_options))
            {
                var userController = new UsersController(context);
                var user1 = context.Users.FirstOrDefault();
                Assert.IsNotNull(user1);
                Assert.AreEqual(user1.UserId, 1);
                Assert.AreEqual(user1.Password, "Gaurav@123");
            }
        }

        [Test]
        public async Task PutUserTest()
        {
            using (var context = new CaseStudyDbContext(_options))
            {
                var userController = new UsersController(context);
                var updatedUser = new Users()
                {
                    UserId = 6,
                    FullName = "User Test",
                    Email = "usertest@gmail.com",
                    PhoneNumber = "9535905126",
                    Password = "Usertest@123",
                    Gender = "Male",
                    Address = "User Test Address"
                };
                await userController.PutUsers(6, updatedUser);
                var addedUser = context.Users.FirstOrDefault(u => u.Email == updatedUser.Email);
                Assert.IsNotNull(addedUser);
                Assert.AreEqual(updatedUser.Email, addedUser.Email);
                Assert.AreEqual(updatedUser.Password, addedUser.Password);
            }
        }

    }
}
