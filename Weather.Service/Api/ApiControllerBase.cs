using System;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Weather.Service
{
    public class ApiControllerBase : ApiController
    {
        protected HttpResponseMessage GetHttpResponse(Func<HttpResponseMessage> codeToExecute)
        {
            HttpResponseMessage response;

            try
            {
                response = codeToExecute.Invoke();
            }
            catch (Exception ex)
            {
                response = Request.CreateResponse(HttpStatusCode.InternalServerError, ex.Message);
            }

            return response;
        }
    }
}