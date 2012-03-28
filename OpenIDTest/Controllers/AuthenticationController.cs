using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DotNetOpenAuth.OpenId.RelyingParty;
using DotNetOpenAuth.OpenId;
using DotNetOpenAuth.Messaging;
using System.Web.Security;
using DotNetOpenAuth.OpenId.Extensions.AttributeExchange;

namespace OpenIDTest.Controllers
{
    public class AuthenticationController : Controller
    {
        private static OpenIdRelyingParty openid = new OpenIdRelyingParty();

        /// <summary>
        /// Authentication/Login post action.
        /// Original code concept from
        /// DotNetOpenAuth/Samples/OpenIdRelyingPartyMvc/Controller/UserController
        /// for demo purposes I took out the returnURL, for this demo I
        /// always want to login to the home page.
        /// </summary>
        [ValidateInput(false)]
        public ActionResult Authenticate()
        {
            var response = openid.GetResponse();
            var statusMessage = "";
            if (response == null)
            {
                Identifier id;
                //make sure your users openid_identifier is valid.
                if (Identifier.TryParse(Request.Form["openid_identifier"], out id))
                {
                    try
                    {
                        IAuthenticationRequest request = openid.CreateRequest(Request.Form["openid_identifier"]);

                        var fetch = new FetchRequest();
                        fetch.Attributes.AddRequired(WellKnownAttributes.Name.First);
                        fetch.Attributes.AddRequired(WellKnownAttributes.Name.Last);
                        fetch.Attributes.AddRequired(WellKnownAttributes.Contact.Email);
                        fetch.Attributes.AddRequired(WellKnownAttributes.Contact.Web.Blog);
                        request.AddExtension(fetch);

                        //request openid_identifier
                        return request.RedirectingResponse.AsActionResult();
                    }
                    catch (ProtocolException ex)
                    {
                        statusMessage = ex.Message;
                        return View("Login", statusMessage);
                    }
                }
                else
                {
                    statusMessage = "Invalid identifier";
                    return View("Login", statusMessage);
                }
            }
            else
            {
                //check the response status
                switch (response.Status)
                {
                    //success status
                    case AuthenticationStatus.Authenticated:

                        string firstName, lastName, email, blog = null;
                        var fetch =response.GetExtension<FetchResponse>();
                        if (fetch != null)
                        {
                            firstName = fetch.GetAttributeValue(WellKnownAttributes.Name.First);
                            lastName = fetch.GetAttributeValue(WellKnownAttributes.Name.Last);
                            email = fetch.GetAttributeValue(WellKnownAttributes.Contact.Email);
                            blog = fetch.GetAttributeValue(WellKnownAttributes.Contact.Web.Blog);
                        }

                        Session["FriendlyIdentifier"] = response.FriendlyIdentifierForDisplay;

                        //FormsAuthentication.SetAuthCookie(response.ClaimedIdentifier.ToString(), false);
                        Response.Cookies.Add(new HttpCookie("commenter", response.ClaimedIdentifier.ToString()) );

                        //TODO: response.ClaimedIdentifier, to login or create new account 

                        return RedirectToAction("Index", "Home");

                    case AuthenticationStatus.Canceled:
                        statusMessage = "Canceled at provider";
                        return View("Login", statusMessage);

                    case AuthenticationStatus.Failed:
                        statusMessage = response.Exception.Message;
                        return View("Login", statusMessage);
                }
            }
            return new EmptyResult();
        }

        public ActionResult Login()
        {
            return View();
        }

        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();

            // 로그아웃 후에는 반드시 리다이렉트해야함, return View() 쓰면 곧바로 리프레쉬가 안됨. 즉 Request.IsAuthenticated가 여전히 true임
            return Redirect("~/Home/Index");
        }

    }
}
