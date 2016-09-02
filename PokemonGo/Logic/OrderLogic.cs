using PokemonGo.DbModel;
using PokemonGo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PokemonGo.Logic
{
    public class OrderLogic
    {
        public object SendOrder(OrderPokemonModel order)
        {
            try {
                ApplicationDbContext repo = new ApplicationDbContext();
                var newOrder = new Orders() {
                    Name=order.Name,
                    Email=order.Email,
                    Phone=order.Phone,
                    Date=DateTime.Now
                };
                repo.Orders.Add(newOrder);
                repo.SaveChanges();
                return new { success = true };

            }
            catch (Exception ex)
            {
                var message = ex.Message;
                return new { success = false, message = message };
            }
        }
        
              public object GetOrders()
        {
            try
            {
                ApplicationDbContext repo = new ApplicationDbContext();
                var orders = repo.Orders.GroupBy(x =>new { Email = x.Email}).Select(x => new
                {
                    date = x.Max(y => y.Date),
                    email = x.Key.Email,
                    name=x.Max(y => y.Name),
                    count=x.Count()
                }).OrderByDescending(x=>x.date).ToList();
                return new { success = true , orders = orders };

            }
            catch (Exception ex)
            {
                var message = ex.Message;
                return new { success = false, message = message };
            }
        }
    }
}