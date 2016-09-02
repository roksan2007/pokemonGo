using Microsoft.AspNet.Identity;
using Newtonsoft.Json;
using PokemonGo.Helper;
using PokemonGo.Logic;
using PokemonGo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PokemonGo.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Timeline()
        {

            return View();
        }

        public string GetOrders()
        {
            var logic = new OrderLogic();
            var json = JsonConvert.SerializeObject(logic.GetOrders());
            return json;
        }
        public ActionResult SendOrder(OrderPokemonModel order)
        {
            var logic = new OrderLogic();
            var json = Json(logic.SendOrder(order), JsonRequestBehavior.AllowGet);
            json.MaxJsonLength = int.MaxValue;
            Mail.Send(order.Email, "Заказ покемона", "Уважаемый клиент. Спасибо что заказали покемона у нас.");

            return json;
        }
    }
}