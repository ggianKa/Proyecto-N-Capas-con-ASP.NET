using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BussinessLayer;
using DataAccess;
using Microsoft.AspNetCore.Mvc;

namespace PresentationLayer.Controllers
{
    public class OrderController(OrderService orderService) : Controller
    {
        private readonly OrderService _orderService = orderService;

        public IActionResult Index()
        {
            var orders = _orderService.GetAllOrders();
            return View(orders);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Edit(OrderUpdate order)
        {
            if (ModelState.IsValid) // Verificar que el modelo es válido
            {
                try
                {
                    // Actualizar el pedido con los datos recibidos
                    _orderService.UpdateOrder(order);
                    return RedirectToAction(nameof(Index)); // O cualquier otra acción de redirección
                }
                catch (Exception ex)
                {
                    // Si hay un error, devolverlo al cliente
                    ModelState.AddModelError(string.Empty, "Error al actualizar el pedido: " + ex.Message);
                }
            }

            // Si el modelo no es válido, regresar a la vista con los datos actuales
            return View(order);
        }


        public IActionResult Edit(int id)
        {
            var order = _orderService.GetOrderById(id);

            if (order == null)
            {
                return NotFound();
            }

            var orderUpdate = new OrderUpdate
            {
                OrderID = order.OrderID,
                Estado = order.Estado,
                ConfirmationDate = order.ConfirmationDate,
                Commments = order.Commments
            };

            return View(orderUpdate);
        }


        public IActionResult Tracking(int id)
        {
            var orders = _orderService.GetAllOrdersDetails(id);
            return View(orders);
        }

    }
}