using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace H8
{
    class OrderController
    {
        [ApiController]
        [Route("api/Icontroller")]
        public class OrderController : ControllerBase
        {
            private readonly OrderContext orderDb;

            public OrderController(OrderContext context)
            {
                this.orderDb = context;
            }

            [HttpGet]
            public ActionResult<List<Order>> GetOrders()
            {
                IQueryable<Order> query = orderDb.Orders;
                return query.ToList();
            }

            [HttpGet("{ID}")]
            public ActionResult<Order> GetOrder(int id)
            {
                var Order = orderDb.Orders.FirstOrDefault(o => o.ID == id);
                if (Order == null)
                {
                    return NotFound();
                }
                return Order;
            }

            [HttpGet("{ClientName}")]
            public ActionResult<Order> GetOrder(string s, bool k)
            {
                Order Order;
                if (k)
                    Order = orderDb.Orders.FirstOrDefault(o => o.ClientName == s);
                else
                    Order = orderDb.Orders.FirstOrDefault(o => o.Address == s);
                if (Order == null)
                {
                    return NotFound();
                }
                return Order;
            }

            [HttpPost]
            public ActionResult<Order> PostOrder(Order o)
            {
                try
                {
                    orderDb.Orders.Add(o);
                    orderDb.SaveChanges();
                }
                catch (Exception e)
                {
                    return BadRequest(e.InnerException.Message);
                }
                return o;
            }

            [HttpPut("{ID}")]
            public ActionResult<Order> PutOrder(int id, Order order)
            {
                if (id != order.ID)
                {
                    return BadRequest("ID cannot be modified");
                }
                try
                {
                    orderDb.Entry(order).State = EntityState.Modified;
                    orderDb.SaveChanges();
                }
                catch (Exception e)
                {
                    string error = e.Message;
                    if (e.InnerException != null)
                        error = e.InnerException.Message;
                    return BadRequest(error);
                }
                return NoContent();
            }

            [HttpDelete("{ID}")]
            public ActionResult DeleteOrder(int id)
            {
                try
                {
                    var order = orderDb.Orders.FirstOrDefault(o => o.ID == id);
                    if (order != null)
                    {
                        orderDb.Remove(order);
                        orderDb.SaveChanges();
                    }
                }
                catch (Exception e)
                {
                    return BadRequest(e.InnerException.Message);
                }
                return NoContent();
            }
        }
    }
}
