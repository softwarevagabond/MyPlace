﻿using MyPlace.Web.Core;
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


        [HttpPost]
        [Route("register/validate1")]
        public HttpResponseMessage ValidateRegistrationStep1(HttpRequestMessage request, [FromBody]AccountRegisterModel accountModel)
        {
            return GetHttpResponse(request, () =>
            {
                HttpResponseMessage response = null;

                List<string> errors = new List<string>();

                // TODO: validate other fields here in case smart-ass user tries to access this API outside of the site

                //List<State> states = UIHelper.GetStates();
                //State state = states.Where(item => item.Abbrev.ToUpper() == accountModel.State.ToUpper()).FirstOrDefault();
                //if (state == null)
                //    errors.Add("Invalid state.");

                //Match matchZipCode = Regex.Match(accountModel.ZipCode, @"^\d{5}(?:[-\s]\d{4})?$");
                //if (!matchZipCode.Success)
                //    errors.Add("Zip code is in an invalid format.");

                if (errors.Count == 0)
                    response = request.CreateResponse(HttpStatusCode.OK);
                else
                    response = request.CreateResponse<string[]>(HttpStatusCode.BadRequest, errors.ToArray());

                return response;
            });
        }


        [HttpPost]
        [Route("register/validate2")]
        public HttpResponseMessage ValidateRegistrationStep2(HttpRequestMessage request, [FromBody]AccountRegisterModel accountModel)
        {
            return GetHttpResponse(request, () =>
            {
                HttpResponseMessage response = null;

                // TODO: validate other fields here in case smart-ass user tries to access this API outside of the site
                //ToDO:Change the Email to UserId --since for us the loginid is userId
                if (!_SecurityAdapter.UserExists(accountModel.LoginEmail))
                    response = request.CreateResponse(HttpStatusCode.OK);
                else
                    response = request.CreateResponse<string[]>(HttpStatusCode.BadRequest, new List<string>() { "An account is already registered with this email address." }.ToArray());

                return response;
            });
        }

        [HttpPost]
        [Route("register/validate3")]
        public HttpResponseMessage ValidateRegistrationStep3(HttpRequestMessage request, [FromBody]AccountRegisterModel accountModel)
        {
            return GetHttpResponse(request, () =>
            {
                HttpResponseMessage response = null;

                List<string> errors = new List<string>();

                // TODO: validate other fields here in case smart-ass user tries to access this API outside of the site

                //if (accountModel.CreditCard.Length != 16)
                //    errors.Add("Credit card number is in an invalid format.");

                //Match matchExpDate = Regex.Match(accountModel.ExpDate, @"(0[1-9]|1[0-2])\/[0-9]{2}", RegexOptions.IgnoreCase);
                //if (!matchExpDate.Success)
                //    errors.Add("Expiration date is invalid.");

                //if (errors.Count == 0)
                //    response = request.CreateResponse(HttpStatusCode.OK);
                //else
                //    response = request.CreateResponse<string[]>(HttpStatusCode.BadRequest, errors.ToArray());

                return response;
            });
        }

        [HttpPost]
        [Route("register")]
        public HttpResponseMessage CreateAccount(HttpRequestMessage request, [FromBody]AccountRegisterModel accountModel)
        {
            return GetHttpResponse(request, () =>
            {
                HttpResponseMessage response = null;

                // revalidate all steps to ensure this operation is secure against hacks
                if (ValidateRegistrationStep1(request, accountModel).IsSuccessStatusCode &&
                    ValidateRegistrationStep2(request, accountModel).IsSuccessStatusCode &&
                    ValidateRegistrationStep3(request, accountModel).IsSuccessStatusCode)
                {
                    _SecurityAdapter.Register(accountModel.LoginEmail, accountModel.Password,
                        propertyValues: new
                        {
                            FirstName = accountModel.FirstName,
                            LastName = accountModel.LastName,
                            Address = accountModel.Address,
                            City = accountModel.City,
                            State = accountModel.State,
                            ZipCode = accountModel.ZipCode,
                            CreditCard = accountModel.CreditCard,
                            ExpDate = accountModel.ExpDate.Substring(0, 2) + accountModel.ExpDate.Substring(3, 2)
                        });
                    _SecurityAdapter.Login(accountModel.LoginEmail, accountModel.Password, false);

                    response = request.CreateResponse(HttpStatusCode.OK);
                }

                return response;
            });
        }
    }
}
