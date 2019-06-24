using FlowersWebApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace FlowersWebApi.Controllers
{
    public class BaseApiController : ApiController
    {
        protected readonly FlowersDbContext DbContext;

        protected BaseApiController()
        {
            DbContext = new FlowersDbContext();
        }
    }
}