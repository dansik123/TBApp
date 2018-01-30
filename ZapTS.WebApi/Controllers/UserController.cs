using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using ZapTS.WebApi.Models;
using System.Web.Http.Cors;

namespace ZapTS.WebApi.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class UserController : ApiController
    {
        [HttpPost]
        public UserSessionViewModel Login(LoginViewModel model)
        {
            return new UserSessionViewModel()
            {
                SessionId = Guid.NewGuid().ToString()
            };
        }

        [HttpPost]
        public ResgisterIdUserModel Register(RegisterViewModel model)
        {
            return new ResgisterIdUserModel()
            {
                IdUser=12
            };
        }
    }
}
