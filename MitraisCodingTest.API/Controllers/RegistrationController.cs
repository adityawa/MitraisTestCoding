using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;
using MitraisCodingTest.Service.Features;
using MitraisCodingTest.Service.Models;
namespace MitraisCodingTest.API.Controllers
{
    public class RegistrationController : ApiController
    {
        [HttpPost]
        [EnableCors(origins: "https://localhost:44339", headers: "*", methods: "*")]
        public HttpResponseMessage Post([FromBody]RegistrationModel reg)
        {
            var response = new ResponseMessageModel();
            if (ModelState.IsValid)
            {
                response = new RegistrationHandler().Save(reg);
                if (response.Code == "E")
                {
                    return Request.CreateResponse(HttpStatusCode.NotAcceptable, response);
                }
                else if (response.Code == "S")
                {
                    return Request.CreateResponse(HttpStatusCode.OK, response);
                }
                else
                {
                    return Request.CreateResponse(HttpStatusCode.NotFound);
                }
            }
            else
            {
                response.Code = "E";
                response.Message = "An Error Occured";
                response.Description = ModelState.Values.FirstOrDefault().Errors.FirstOrDefault().Exception.Message;
                return Request.CreateResponse(HttpStatusCode.BadRequest, response) ;
            }
        }

        [HttpGet]
        public List<RegistrationModel> GetRegisteredData()
        {
            return new RegistrationHandler().GetData();
        }
    }
}
