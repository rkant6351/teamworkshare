using Ecom_Application.DAO;
using Ecom_Application.Entity;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace UnitTestProject1
{
    [TestClass]
    public class UnitTest1
    {
        private OrderProcessorRepository _processorRepository;
        
        public void Setup()
        {
            AppDomain.CurrentDomain.SetData("APP_CONFIG_FILE", string.Format("{0}\\app.config", AppDomain.CurrentDomain.BaseDirectory));
            _processorRepository = new OrderProcessorRepositoryImpl();
        }

        [TestMethod]
        public void Test1()
        {
            Customers customers = new Customers() { Name = "Test", Email = "Test Email", Password = "test password" };
            bool actual = _processorRepository.createCustomer(customers);
            Assert.AreEqual(true, actual);
        }
    }
}
