using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebApplication4.Models;

namespace WebApplication4.Controllers
{
    public class UserController : ApiController
    {
        private UserDBEntities db = new UserDBEntities();
        public IHttpActionResult Get()
        {
            //Console.Write("get api called");
            var obj = db.user1.ToList();
            return Ok(obj);
        }

        public IHttpActionResult Get(int id)
        {
            Console.WriteLine("This is C#");
            var obj = db.user1.Where(x => x.id == id).ToList().FirstOrDefault();
            return Ok(obj);
        }

        public IHttpActionResult Post(user1 u)
        {
           
            
                db.user1.Add(u);
                db.SaveChanges();
                return Ok();
           
        }

        public IHttpActionResult Put(user1 u)
        {

            var obj = db.user1.Where(x => x.id == u.id).ToList().FirstOrDefault();
            if (obj.id > 0)
            {

                obj.firstName = u.firstName;
                obj.lastName = u.lastName;
                db.SaveChanges();
                return Ok();
            }
            return NotFound();
        
        }

        public IHttpActionResult Delete(int id)
        {
            var obj = db.user1.Where(x => x.id == id).ToList().FirstOrDefault();
            db.user1.Remove(obj);
            db.SaveChanges();
            return Ok();
        }

    }
}
