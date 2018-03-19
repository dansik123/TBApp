using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using ZapTS.WebApi.Models;
using System.Web.Http.Cors;
using ZapTS.WebApi.Annotations;

namespace ZapTS.WebApi.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class UserController : ApiController
    {
        [HttpPost]
        public LoginSesionIdReturn Login(Users model)
        {
            var context = new ZapTBDataEntities();
            Users user = context.Users.First(r => r.Username == model.Username && r.Password == model.Password);
            LogIn identyficationTable = new LogIn()
            {
                UserId = user.Id,
                SessionId = Guid.NewGuid().ToString(),
                SessionTimeOut = DateTime.Now.AddMinutes(15)
            };
            context.LogIn.Add(identyficationTable);
            context.SaveChanges();
            return new LoginSesionIdReturn()
            {
                SessionId = identyficationTable.SessionId
            };
        }

        [HttpPost]
        public RegisterUserIdReturn Register(Users model)
        {
            var context = new ZapTBDataEntities();
            context.Users.Add(model);
            context.SaveChanges();
            Users userTable = context.Users.First(r => r.Username == model.Username && r.Password == model.Password);

            return new RegisterUserIdReturn()
            {
                UserId = userTable.Id
            };
        }

        [Authorization]
        public HttpResponseMessage GetImportantData()
        {
            return Request.CreateResponse(HttpStatusCode.OK, true);
        }
    }
}
