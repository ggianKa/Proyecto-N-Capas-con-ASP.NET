using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DataAccess;

namespace BussinessLayer
{
    public class OrderService
    {
        private readonly OrderData _orderData;

        public OrderService(string connectionString)
        {
            _orderData = new OrderData(connectionString);

        }

        public List<Order> GetAllOrders(){
            return _orderData.GetAllOrders();
        }


        public List<Order> GetAllOrdersDetails(int OrderID)
        {
            return _orderData.GetAllOrdersDetails(OrderID);
        }

        public Order GetOrderById(int OrderID)
        {
            return _orderData.GetOrderById(OrderID);
        }

        public void UpdateOrder(OrderUpdate order)
        {
            _orderData.UpdateOrder(order);
        }
    }
}