using FlowersWebApi.Models;
using FlowersWebApi.Models.ResourceModels;
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
            var managers = DbContext.Managers.ToList().Select(m => new ManagerResourceModel(m));
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

            return Content(HttpStatusCode.OK, new { manager = new ManagerResourceModel(manager) });
        }

        [HttpPost]
        public IHttpActionResult Post(ManagerResourceModel manager)
        {
            if (manager == null)
            {
                return BadRequest("Менеджер не был передан");
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (DbContext.Managers.Any(m => m.FirstName == manager.FirstName && m.LastName == manager.LastName))
            {
                return Content(HttpStatusCode.Conflict, new { Message = "Менеджер с таким именем и фамилией уже существует" });
            }

            DbContext.Managers.Add(manager.ConvertToEnity());
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

        [HttpPut]
        public IHttpActionResult UpdateManagers(int id, ManagerResourceModel manager)
        {
            if (manager == null)
            {
                return BadRequest("Менеджер не был передан");
            }

            var entity = DbContext.Managers.Find(id);
            if (entity == null)
            {
                return Content(HttpStatusCode.NotFound, new { Message = $"Менеджер с id = {id} не найден"});
            }

            entity.Bdate = manager.Birthdate;
            entity.FirstName = manager.FirstName;
            entity.LastName = manager.LastName;
            DbContext.SaveChanges();
            
            return Content(HttpStatusCode.OK, new { Message = $"Данные о менеджеру с id = {id} обновлены." });
        }

    }
}