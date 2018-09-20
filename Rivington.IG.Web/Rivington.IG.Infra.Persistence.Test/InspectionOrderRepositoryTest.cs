using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Rivington.IG.Domain.Models;
using Rivington.IG.Infrastructure.Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.Text;
using Rivington.IG.Domain.Models.OrderManagement;

namespace Rivington.IG.Infrastructure.Persistence.Test
{
    [TestClass]
    public class InspectionOrderRepositoryTest
    {
        private InspectionOrderRepository sut;
        private InspectionOrder inspectionOrder;
        private string connectionString;
        private DbContextOptions<RivingtonContext> dbOptions;
        private RivingtonContext dbContext;

        //[TestInitialize]
        //public void Initialize()
        //{

        //    inspectionOrder = new InspectionOrder
        //    {
        //        OrderId = Guid.NewGuid(),
        //        Item = 001,
        //        Policy = "Policy 123",
        //        InsuredName = "John Karl Matencio",
        //        Location = "location",
        //        DateAssigned = DateTime.Now,
        //        OrderReceived = DateTime.Now,
        //        Inspector = "Blanche",
        //        Status = "Pending Assignment"
        //    };

        //    connectionString = @"Data Source=.;Database=InspectorGadget;Integrated Security=true;";

        //    dbOptions = new DbContextOptionsBuilder<RivingtonContext>()
        //        .UseSqlServer(connectionString)
        //        .Options;

        //    dbContext = new RivingtonContext(dbOptions);

        //    sut = new InspectionOrderRepository(dbContext);

        //}

        //[TestCleanup]
        //public void Cleanup()
        //{
        //    dbContext.Dispose();
        //    dbContext = null;
        //}

        //[TestMethod]
        //[TestProperty("TestType", "Integration")]
        //public void Create_WithValidData_SavesRecordToTheDatabase()
        //{
        //    //Arrange

        //    //Act
        //    var newInspectionOrder = sut.Create(inspectionOrder);
        //    //Assert
        //    Assert.IsNotNull(inspectionOrder);
        //    Assert.IsTrue(inspectionOrder.OrderId != Guid.Empty);
        //    //Cleanup
        //    sut.Delete(inspectionOrder.OrderId);
        //}

        //[TestMethod]
        //[TestProperty("TestType", "Integration")]
        //public void Retrieve_WithValidData_GetsRecordFromTheDatabase()
        //{
        //    //Arrange
        //    var newInspectionOrder = sut.Create(inspectionOrder);
        //    //Act
        //    var found = sut.Retrieve(inspectionOrder.OrderId);
        //    //Assert
        //    Assert.IsNotNull(found);
        //    //Cleanup
        //    sut.Delete(inspectionOrder.OrderId);
        //}

        //[TestMethod]
        //[TestProperty("TestType", "Integration")]
        //public void Update_WithValidData_UpdatesRecordFromTheDatabase()
        //{
        //    //Arrange
        //    var newInspectionOrder = sut.Create(inspectionOrder);
        //    var expectedInsuredName = "Alvin Terible";

        //    newInspectionOrder.InsuredName = expectedInsuredName;
        //    //Act
        //    sut.Update(newInspectionOrder.OrderId, newInspectionOrder);
        //    //Assert
        //    var updatedInspectionOrder = sut.Retrieve(newInspectionOrder.OrderId);
        //    Assert.AreEqual(updatedInspectionOrder.InsuredName, newInspectionOrder.InsuredName);
        //    //Cleanup
        //    sut.Delete(newInspectionOrder.OrderId);
        //}

        //[TestMethod]
        //[TestProperty("TestType", "Integration")]
        //public void Delete_WithValidData_DeletesRecordFromTheDatabase()
        //{
        //    //Arrange
        //    var newInspectionOrder = sut.Create(inspectionOrder);
        //    //Act
        //    sut.Delete(inspectionOrder.OrderId);
        //    //Assert
        //    var order = sut.Retrieve(inspectionOrder.OrderId);
        //    Assert.IsNull(order);
        //    //Cleanup
        //}
    }
}
