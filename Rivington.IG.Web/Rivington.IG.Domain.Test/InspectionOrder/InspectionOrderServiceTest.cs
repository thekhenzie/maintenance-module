using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Rivington.IG.Domain.Models;
using System;

namespace Rivington.IG.Domain.Test.InspectionOrders
{
    //[TestClass]
    //public class InspectionOrderServiceTest
    //{
    //    private Mock<IInspectionOrderRepository> mockManagementRepository;
    //    private InspectionOrderService sut;

    //    private OrderManagement orderManagement;
    //    private Guid existingId;

    //    [TestInitialize]
    //    public void Initialize()
    //    {
    //        mockManagementRepository = new Mock<IInspectionOrderRepository>();
    //        sut = new InspectionOrderService(mockManagementRepository.Object);
    //        orderManagement = new OrderManagement
    //        {
    //            OrderId = Guid.NewGuid(),
    //            Item = 001,
    //            Policy = "Policy 123",
    //            InsuredName = "John Karl Matencio",
    //            Location = "location",
    //            DateAssigned = DateTime.Now,
    //            OrderReceived = DateTime.Now,
    //            Inspector = "Blanche",
    //            Status = "Pending Assignment"
    //        };
    //        existingId = Guid.NewGuid();

    //        mockManagementRepository
    //            .Setup(c => c.Retrieve(existingId))
    //            .Returns(orderManagement);

    //    }
    //    [TestCleanup]
    //    public void Cleanup()
    //    {

    //    }

    //    [TestMethod]
    //    public void Save_WithvalidData_ShouldCallRepositoryCreate()
    //    {
    //        //Arrange

    //        //Act
    //        var result = sut.Save(orderManagement.OrderId, orderManagement);
    //        //Assert
    //        mockManagementRepository.Verify(x => x.Create(orderManagement), Times.Once);
    //    }

    //    [TestMethod]
    //    public void Save_WithNullItem_ThrowsItemIsRequiredException()
    //    {
    //        //Arrange
    //        orderManagement.Item = 0;
    //        //Act

    //        //Assert
    //        Assert.ThrowsException<ItemIsRequiredException>(() => sut.Save(orderManagement.OrderId, orderManagement));
    //        mockManagementRepository.Verify(c => c.Create(orderManagement), Times.Never());
    //    }

    //    [TestMethod]
    //    public void Save_WithNullPolicy_ThrowsPolicyIsRequiredException()
    //    {
    //        //Arrange
    //        orderManagement.Policy = "";
    //        //Act

    //        //Assert
    //        Assert.ThrowsException<PolicyIsRequiredException>(() => sut.Save(orderManagement.OrderId, orderManagement));
    //        mockManagementRepository.Verify(c => c.Create(orderManagement), Times.Never());
    //    }

    //    [TestMethod]
    //    public void Save_WithNullInsuredName_ThrowsInsuredNameIsRequired()
    //    {
    //        //Arrange
    //        orderManagement.InsuredName = "";
    //        //Act

    //        //Assert
    //        Assert.ThrowsException<InsuredNameIsRequiredException>(() => sut.Save(orderManagement.OrderId, orderManagement));
    //        mockManagementRepository.Verify(c => c.Create(orderManagement), Times.Never());
    //    }

    //    [TestMethod]
    //    public void Save_WithNullInspector_ThrowsInpsectorIsRequiredException()
    //    {
    //        //Arrange
    //        orderManagement.Inspector = "";
    //        //Assert

    //        //Act
    //        Assert.ThrowsException<InspectorIsRequiredException>(() => sut.Save(orderManagement.OrderId, orderManagement));
    //        mockManagementRepository.Verify(c => c.Create(orderManagement), Times.Never());
    //    }

    //    [TestMethod]
    //    public void Save_NullLocation_ThrowsLocatiomIsRequiredException()
    //    {
    //        //Arrange
    //        orderManagement.Location = "";
    //        //Act

    //        //Assert
    //        Assert.ThrowsException<LocationIsRequiredException>(() => sut.Save(orderManagement.OrderId, orderManagement));
    //        mockManagementRepository.Verify(c => c.Create(orderManagement), Times.Never());
    //    }

    //    [TestMethod]
    //    public void Save_WithNullPendingStatus_ThrowsPendingStatusIsRequiredException()
    //    {
    //        //Arrange
    //        orderManagement.Status = "";
    //        //Act

    //        //Assert
    //        Assert.ThrowsException<PendingStatusIsRequiredException>(() => sut.Save(orderManagement.OrderId, orderManagement));
    //        mockManagementRepository.Verify(c => c.Create(orderManagement), Times.Never());
    //    }

    //    [TestMethod]
    //    public void Save_WithExistingId_ShouldCallRepositoryUpdate()
    //    {
    //        //Arrange
    //        orderManagement.OrderId = existingId;
    //        //Act
    //        var result = sut.Save(orderManagement.OrderId, orderManagement);
    //        //Assert
    //        mockManagementRepository.Verify(c => c.Retrieve(orderManagement.OrderId), Times.Once());
    //        mockManagementRepository.Verify(x => x.Update(orderManagement.OrderId, orderManagement), Times.Once);
    //    }

    //}
}
