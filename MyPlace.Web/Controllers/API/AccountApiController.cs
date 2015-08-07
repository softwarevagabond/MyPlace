using MyPlace.Web.Core;
using MyPlace.Web.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace MyPlace.Web.Controllers.API
{
    [Export]
    [PartCreationPolicy(CreationPolicy.NonShared)]
    [RoutePrefix("api/account")]
    public class AccountApiController : ApiControllerBase
    {
        ISecurityAdapter _SecurityAdapter;

        [ImportingConstructor]
        public AccountApiController(ISecurityAdapter securityAdapter)
        {
            _SecurityAdapter = securityAdapter;
        }

        [HttpPost]
        [Route("login")]
        public HttpResponseMessage Login(HttpRequestMessage request,
            [FromBody]AccountLoginModel accountModel)
        {
            return GetHttpResponse(request, () =>
            {
                HttpResponseMessage response = null;
                bool success = _SecurityAdapter.Login(accountModel.Login, accountModel.Password, accountModel.RememberMe);

                if (success)
                {
                    response = request.CreateResponse(HttpStatusCode.OK);
                }
                else
                {
                    response = request.CreateErrorResponse(HttpStatusCode.Unauthorized, "UnAuthorized Login");
                }

                return response;
            });
        }
    }
}
