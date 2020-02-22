using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MongoDB.Driver;
using project_v._2.Models;

namespace project_v._2.Controllers
{
    public class HomeController : Controller
    {
        private IMongoCollection<register> Collectionregis;
        public HomeController()
        {
            var dbcilent = new MongoClient("mongodb://Beeradmin:beer8640@cluster0-shard-00-00-pqdfa.azure.mongodb.net:27017,cluster0-shard-00-01-pqdfa.azure.mongodb.net:27017,cluster0-shard-00-02-pqdfa.azure.mongodb.net:27017/test?replicaSet=Cluster0-shard-0&ssl=true&authSource=admin");
            var database = dbcilent.GetDatabase("DATAHUB");
            Collectionregis = database.GetCollection<register>("REGISTER");
        }

        public IActionResult Index()
        {
            var result = Collectionregis.Find(it => true).ToList();

            return View(result);
        }

        public IActionResult register()
        {

            return View();
        }

        [HttpPost]
        public IActionResult register(register data)
        {
            var item = new register
            {
                _id = Guid.NewGuid().ToString(),
                username = data.username,
                password = data.password,
                name = data.name,
                pictruejob1 = data.pictruejob1,
                pictruejob2 = data.pictruejob2,
                pictruejob3 = data.pictruejob3,
                namejob = data.namejob,
                detail = data.detail,
                address = data.address,
                price = data.price,
                phone = data.phone,
                line = data.line
            };
            Collectionregis.InsertOne(item);

            return RedirectToAction("Index");
        }

        public IActionResult details(string id)
        {
            var item = Collectionregis.Find(it => it._id == id).ToList().FirstOrDefault();

            return View(item);
        }

        public IActionResult myjob()
        {

            return View();
        }

        [HttpPost]
        public IActionResult myjob(login data)
        {
            var item = Collectionregis.Find(it => it.username == data.username && it.password == data.password).FirstOrDefault();

            if (item != null)
            {
                return RedirectToAction("edit", new { id = item._id });
            }
            else
            {
                return View();
            }

        }

        public IActionResult edit(string id)
        {
            var item = Collectionregis.Find(it => it._id == id).ToList().FirstOrDefault();

            return View(item);
        }

        public IActionResult profile(string id)
        {
            var item = Collectionregis.Find(it => it._id == id).ToList().FirstOrDefault();

            return View(item);
        }

        [HttpPost]
        public IActionResult profile(register data)
        {
            var item = Builders<register>.Update
                .Set(it => it.name, data.name)
                .Set(it => it.pictruejob1, data.pictruejob1)
                .Set(it => it.pictruejob2, data.pictruejob2)
                .Set(it => it.pictruejob3, data.pictruejob3)
                .Set(it => it.namejob, data.namejob)
                .Set(it => it.detail, data.detail)
                .Set(it => it.address, data.address)
                .Set(it => it.price, data.price)
                .Set(it => it.phone, data.phone)
                .Set(it => it.line, data.line);

            Collectionregis.UpdateOne(it => it._id == data._id, item);

            return RedirectToAction("Index");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
