using FlowersWebApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Http;

namespace FlowersWebApi.Controllers
{
    public class ManagersController : BaseApiController
    {
        [HttpGet]
        public IHttpActionResult Get()
        {
            var managers = DbContext.Managers.ToList();
            return Content(HttpStatusCode.OK, new { managers });
        }

        [HttpGet]
        public IHttpActionResult Get(int id)
        {
            if (id < 1)
            {
                return Content(HttpStatusCode.BadRequest, new { Message = "Неправильно введённый id." });
            }

            var manager = DbContext.Managers.Find(id);

            if (manager == null)
            {
                return Content(HttpStatusCode.NotFound, new { Message = $"Менеджер с id = {id} не найден." });
            }

            return Content(HttpStatusCode.OK, new { manager }); ;
        }

        [HttpPost]
        public IHttpActionResult Post(string firstName, string lastName)
        {
            var manager = new Manager
            {
                FirstName = firstName,
                LastName = lastName,
                Bdate = DateTime.Now
            };

            DbContext.Managers.Add(manager);
            DbContext.SaveChanges();
            return Content(HttpStatusCode.OK, new { Message = "Менеджер добавлен!!" });
        }

        [HttpDelete]
        public IHttpActionResult Delete(int id)
        {
            var manager = DbContext.Managers.Find(id);
            if (manager == null)
            {
              return Content(HttpStatusCode.NotFound, new { Message = "Такой менеджер не найден." });  
            }
            DbContext.Managers.Remove(manager);
            DbContext.SaveChanges();
            return Content(HttpStatusCode.OK, new { Message = "Менеджер удалён!!" });
        }

        //[HttpPut]
        //public IHttpActionResult UpdateManagers()
        //{
        //    return ;
        //}

    }
}