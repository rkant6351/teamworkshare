using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using WebApiCaseStudyCFTry1.Controllers;
using WebApiCaseStudyCFTry1.Data;
using WebApiCaseStudyCFTry1.Models;

namespace CStest
{
    public class Tests
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
        public async Task PostAdministratorTest()
        {
            using (var context = new CaseStudyDbContext(_options))
            {
                var adminController = new AdministratorsController(context);
                var newAdmin = new Administrators()
                {
                    AdminFullName = "Admin Test",
                    AdminEmail = "admintest@gmail.com",
                    AdminPhoneNumber = "9535905126",
                    AdminPassword = "Admintest@123",
                };
                await adminController.PostAdministrators(newAdmin);
                var addedAdmin = context.Administrators.FirstOrDefault(a => a.AdminId == 5);
                Assert.IsNotNull(addedAdmin);
                Assert.AreEqual(newAdmin.AdminEmail, addedAdmin.AdminEmail);
                Assert.AreEqual(newAdmin.AdminPassword, addedAdmin.AdminPassword);
            }
        }

        [Test]
        public async Task GetAdministratorByIdTest()
        {
            using (var context = new CaseStudyDbContext(_options))
            {
                var adminController = new AdministratorsController(context);
                var admin1 = context.Administrators.FirstOrDefault(a => a.AdminId == 1);
                Assert.IsNotNull(admin1);
                Assert.AreEqual(admin1.AdminFullName, "Admin 1");
                Assert.AreEqual(admin1.AdminPassword, "Admin1@123");
            }
        }

        [Test]
        public async Task GetAdministratorTest()
        {
            using (var context = new CaseStudyDbContext(_options))
            {
                var adminController = new AdministratorsController(context);
                var admin1 = context.Administrators.FirstOrDefault();
                Assert.IsNotNull(admin1);
                Assert.AreEqual(admin1.AdminFullName, "Admin 1");
                Assert.AreEqual(admin1.AdminPassword, "Admin1@123");
            }
        }

        [Test]
        public async Task PutAdministratorTest()
        {
            using (var context = new CaseStudyDbContext(_options))
            {
                var adminController = new AdministratorsController(context);
                var updatedAdmin = new Administrators()
                {
                    AdminId = 5,
                    AdminFullName = "Admin Test",
                    AdminEmail = "admintest@gmail.com",
                    AdminPhoneNumber = "9535905126",
                    AdminPassword = "UpAdmintest@123"
                };
                await adminController.PutAdministrators(5, updatedAdmin);
                var addedAdmin = context.Administrators.FirstOrDefault(a => a.AdminId == updatedAdmin.AdminId);
                Assert.IsNotNull(addedAdmin);
                Assert.AreEqual(updatedAdmin.AdminEmail, addedAdmin.AdminEmail);
                Assert.AreEqual(updatedAdmin.AdminPassword, addedAdmin.AdminPassword);
            }
        }





    }
}