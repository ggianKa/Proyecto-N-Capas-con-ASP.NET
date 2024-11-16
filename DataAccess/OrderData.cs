using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace DataAccess
{
    public class OrderData(string connectionString)
    {
        private readonly string _connectionString = connectionString;

        public List<Order> GetAllOrders(){
            List<Order> orders = [];

            using(SqlConnection connection = new(_connectionString)){
                string query = "SELECT OrderID, ShipName, OrderDate, Phone, Estado FROM Orders AS o JOIN Customers AS c ON o.CustomerID = c.CustomerID";
                SqlCommand command = new(query, connection);
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                while(reader.Read())
                {
                    orders.Add(
                    new Order
                    {
                        OrderID= reader.GetInt32(0),
                        ShipName = reader.GetString(1),
                        OrderDate= reader.GetDateTime(2),
                        Phone = reader.GetString(3),
                        Estado = reader.GetString(4),
                    }
                    );
                }
            }
            return orders;
        }


        public List<Order> GetAllOrdersDetails(int OrderID)
        {
            List<Order> orders = [];

            using (SqlConnection connection = new(_connectionString))
            {
                string query = "SELECT OrderID, p.ProductID, ProductName, Quantity, p.UnitPrice, (p.UnitPrice * Quantity) AS Total  FROM [Order Details] AS od JOIN Products AS p ON od.ProductID = p.ProductID WHERE OrderID=@OrderID";
                SqlCommand command = new(query, connection);
                command.Parameters.AddWithValue("@OrderID", OrderID);
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    orders.Add(
                    new Order
                    {
                        OrderID = reader.GetInt32(0),
                        ProductID = reader.GetInt32(1),
                        ProductName = reader.GetString(2),
                        Quantity = reader.GetInt16(3), 
                        UnitPrice = Math.Round(reader.GetDecimal(4), 2), 
                        Total = Math.Round(reader.GetDecimal(5), 2) 
                    }
                    );
                }
            }
            return orders;
        }

        public Order GetOrderById(int OrderID)
        {
            Order order = new();

            using (SqlConnection connection = new(_connectionString))
            {
                string query = "SELECT OrderID, p.ProductID, ProductName, Quantity, p.UnitPrice, (p.UnitPrice * Quantity) AS Total  FROM [Order Details] AS od JOIN Products AS p ON od.ProductID = p.ProductID WHERE OrderID=@OrderID";
                SqlCommand command = new(query, connection);
                command.Parameters.AddWithValue("@OrderID", OrderID);
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    order =
                        new Order
                        {

                            OrderID = reader.GetInt32(0), 
                            ProductID = reader.GetInt32(1), 
                            ProductName = reader.GetString(2),
                            Quantity = reader.GetInt16(3), 
                            UnitPrice = reader.GetDecimal(4), 
                            Total = reader.GetDecimal(5) 
                        };
                }
            }
            return order;
        }


        public void UpdateOrder(OrderUpdate order)
        {
            using SqlConnection connection = new(_connectionString);
            string query = "UPDATE Orders SET ConfirmationDate = @ConfirmationDate, Estado = @Estado, Commments = @Commments WHERE OrderID=@OrderID";
            SqlCommand command = new(query, connection);
           

            // Agregar los parámetros a la consulta
            command.Parameters.AddWithValue("@OrderID", order.OrderID);
            command.Parameters.AddWithValue("@ConfirmationDate", order.ConfirmationDate); 
            command.Parameters.AddWithValue("@Estado", order.Estado); 
            command.Parameters.AddWithValue("@Commments", order.Commments ?? (object)DBNull.Value); // Handle null comments
            // Abrir la conexión y ejecutar la consulta
            connection.Open();
            command.ExecuteNonQuery();
        }

    }
}