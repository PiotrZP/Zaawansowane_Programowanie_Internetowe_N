using System.Reflection;
using System.Reflection.Metadata;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebStore.DAL.DatabaseContext;
using WebStore.Model.DataModels;
using WebStore.Services.Interfaces;
using WebStore.ViewModels.VM;
using Xunit;
namespace WebStore.Tests.UnitTests
{
  public class OrderServiceUnitTests : BaseUnitTests
  {
    private readonly IOrderService _orderService;
    public OrderServiceUnitTests(WSDbContext dbContext,
      IOrderService orderService) : base(dbContext)
    {
      _orderService = orderService;
    }
    [Fact]
    public void GetOrderTest()
    {
      var order = _orderService.GetOrder(o => o.TotalAmount == 1000);
      Assert.NotNull(order);
    }
    [Fact]
    public void GetMultipleOrdersTest()
    {
      var orders = _orderService.GetOrders(o => o.Id >= 1 && o.Id <= 2);
      Assert.NotNull(orders);
      Assert.NotEmpty(orders);
      Assert.Equal(2, orders.Count());
    }
    [Fact]
    public void GetAllOrdersTest()
    {
      var orders = _orderService.GetOrders();
      Assert.NotNull(orders);
      Assert.NotEmpty(orders);
      Assert.Equal(orders.Count(), orders.Count());
    }
    [Fact]
    public void AddNewOrderTest()
    {
      var newOrderVm = new AddOrUpdateOrderVm()
      {
        TrackingNumber = 123456789,
        DeliveryDate = new DateTime(2022, 11, 11),
        OrderDate = new DateTime(2022, 11, 11),
        StationaryStoreId = 1,
        CustomerId = 1,
        Invoiceid = 1,
      };
      var createdOrder = _orderService.AddOrUpdateOrder(newOrderVm);
      Assert.NotNull(createdOrder);
      Assert.Equal(123456789, createdOrder.TrackingNumber);
    }
    [Fact]
    public void UpdateOrderTest()
    {
      var updateOrderVm = new AddOrUpdateOrderVm()
      {
        Id = 2,
        TrackingNumber = 000000000,
        DeliveryDate = new DateTime(2022, 11, 11),
        OrderDate = new DateTime(2022, 11, 11),
        StationaryStoreId = 1,
        CustomerId = 2,
        Invoiceid = 1,
      };
      var editedOrderVm = _orderService.AddOrUpdateOrder(updateOrderVm);
      Assert.NotNull(editedOrderVm);
      Assert.Equal(000000000, editedOrderVm.TrackingNumber);
      Assert.Equal(new DateTime(2022, 11, 11), editedOrderVm.DeliveryDate);
    }
  }
}