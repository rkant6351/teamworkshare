using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApiCaseStudyCFTry1.Controllers;
using WebApiCaseStudyCFTry1.Data;
using WebApiCaseStudyCFTry1.Models;

namespace CStest
{
    internal class CategoriesTest
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
        public async Task PostCategoryTest()
        {
            using (var context = new CaseStudyDbContext(_options))
            {
                var category = new CategoriesController(context);
                var newcategory = new Categories()
                {
                    CategoryName="Test6"
                };
                await category.PostCategories(newcategory);
                var addedcat = context.Categories.FirstOrDefault(c => c.CategoryName == newcategory.CategoryName);
                Assert.IsNotNull(addedcat);
                Assert.AreEqual(newcategory.CategoryName, addedcat.CategoryName);
                Assert.AreEqual(newcategory.CategoryId, addedcat.CategoryId);
            }
        }

        [Test]
        public async Task GetCategoryByIdTest()
        {
            using (var context = new CaseStudyDbContext(_options))
            {
                var category = new CategoriesController(context);
                var cat1 = context.Categories.FirstOrDefault(c=>c.CategoryId==1);
                Assert.IsNotNull(cat1);
                Assert.AreEqual(cat1.CategoryName, "Electronics");
            }
        }

        [Test]
        public async Task GetCategoryTest()
        {
            using (var context = new CaseStudyDbContext(_options))
            {
                var category = new CategoriesController(context);
                var cat1 = context.Categories.FirstOrDefault();
                Assert.IsNotNull(cat1);
                Assert.AreEqual(cat1.CategoryName, "Electronics");
            }
        }

        [Test]
        public async Task PutCategoryTest()
        {
            using (var context = new CaseStudyDbContext(_options))
            {
                var category = new CategoriesController(context);
                var newcategory = new Categories()
                {
                    CategoryId=4,
                    CategoryName = "Updated Test"
                };
                await category.PutCategories(4,newcategory);
                var addedcat = context.Categories.FirstOrDefault(c => c.CategoryName == newcategory.CategoryName);
                Assert.IsNotNull(addedcat);
                Assert.AreEqual(newcategory.CategoryName, addedcat.CategoryName);
                Assert.AreEqual(newcategory.CategoryId, addedcat.CategoryId);
            }
        }
    }
}
