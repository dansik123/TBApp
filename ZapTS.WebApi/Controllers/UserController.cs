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
        public LoginSesionIdReturn Login(UserTable model)
        {
            var context = new ZapTBDataEntities();
            UserTable user = context.UserTable.First(r => r.Username == model.Username && r.Password == model.Password);
            IdentyficationTable identyficationTable = new IdentyficationTable
            {
                UserId = user.UserId,
                SessionId = Guid.NewGuid().ToString(),
                SessionTimeOut = DateTime.Now.AddMinutes(15)
            };
            context.IdentyficationTable.Add(identyficationTable);
            context.SaveChanges();
            return new LoginSesionIdReturn()
            {
                SessionId = identyficationTable.SessionId
            };
        }

        [HttpPost]
        public RegisterUserIdReturn Register(UserTable model)
        {
            var context = new ZapTBDataEntities();
            context.UserTable.Add(model);
            context.SaveChanges();
            UserTable userTable = context.UserTable.First(r => r.Username == model.Username && r.Password == model.Password);

            return new RegisterUserIdReturn()
            {
                UserId = userTable.UserId
            };
        }

        [Authorization]
        public HttpResponseMessage GetImportantData()
        {
            return Request.CreateResponse(HttpStatusCode.OK, true);
        }
    }
}
