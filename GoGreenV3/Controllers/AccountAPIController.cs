using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using GoGreenV3.Models;
using Microsoft.AspNet.Identity;
using System.Diagnostics;
using System.Web.Mvc;
using System.Security.Policy;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security.DataProtection;
using System.Web;
using System.Web.Routing;
using System.Net.Mail;
using Microsoft.Owin;
using Microsoft.Owin.Host.SystemWeb;
using Microsoft.Owin.Security;
using Microsoft.Owin.Security.Cookies;
using Microsoft.Owin.Security.OAuth;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Globalization;

namespace GoGreenV3.Controllers
{
    public class AccountAPIController : ApiController
    {
        public UserManager<ApplicationUser> UserManager { get; private set; }
        private ApplicationSignInManager SignInManager;

        private AgencyDbContext db = new AgencyDbContext();

        public AccountAPIController()
        {
        }

        [System.Web.Http.Route("api/accountapi/register")]
        [System.Web.Http.HttpPost]
        [ResponseType(typeof(RegisterViewModel))]
        public async Task<IHttpActionResult> Register(RegisterViewModel model)
        {
            var provider = new DpapiDataProtectionProvider("EmailConfirm");
            var context = new ApplicationDbContext();
            UserManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(context));
            UserManager.UserTokenProvider = new DataProtectorTokenProvider<ApplicationUser>(provider.Create("EmailConfirmation"));

            var types = GetAllTypes();
            var agencies = GetAllAgencies();

            model.Types = GetSelectListItems(types);
            model.Agencies = GetSelectListItems(agencies);

            if (ModelState.IsValid)
            {
                var user = new ApplicationUser
                {
                    UserName = model.Email,
                    Email = model.Email,
                    FirstName = model.FirstName,
                    LastName = model.LastName,
                    BirthDate = model.BirthDate,
                    CellphoneNumber = model.CellphoneNumber,
                    TelephoneNumber = model.TelephoneNumber,
                    Type = model.Type,
                    Agency = model.Agency,
                    MemberSince = DateTime.Now,
                    LastActive = DateTime.Now,
                    AvatarUrl = model.AvatarUrl
                };

                var result = await UserManager.CreateAsync(user, model.Password);
                if (result.Succeeded)
                {
                    try
                    {
                        // sets account's role to default upon registration
                        await UserManager.AddToRoleAsync(user.Id, "Default");
                    }
                    catch
                    {
                        return BadRequest(ModelState);
                    }
                    
                    string code = await UserManager.GenerateEmailConfirmationTokenAsync(user.Id);
                    var callbackUrl = new Uri(Url.Link("ConfirmEmailRoute", new { userId = user.Id, code = code }));
                    //var callbackUrl = Url.Link("AccountApi", new { Controller = "Account", Action = "ConfirmEmail" });
                    //await UserManager.SendEmailAsync(user.Id, "Confirm your account", "Please confirm your account by clicking: " + callbackUrl);
                    Debug.WriteLine(callbackUrl);
                    SendEmailViaWebApi(user.Email, "Confirm your Go Green account", "Please confirm your account by clicking: ", callbackUrl);
                    
                    return Ok(user);
                }
            }

            // If we got this far, something failed, redisplay form
            return BadRequest(ModelState);
        }

        private void SendEmailViaWebApi(string emailToAddress, string msgSubject, string msgBody, Uri callbackUrl)
        {
            MailMessage mail = new MailMessage();
            mail.From = new MailAddress("GoGreenETMS@gmail.com", msgSubject);
            mail.To.Add(emailToAddress);
            mail.Subject = msgSubject;
            mail.Body = msgBody + "<a href='" + callbackUrl + "' class='btn btn-default'>Confirm Email</a>";
            mail.IsBodyHtml = true;

            SmtpClient client = new SmtpClient("smtp.gmail.com");
            client.Port = 587;
            client.Credentials = new System.Net.NetworkCredential("GoGreenETMS@gmail.com", "gogreengo");
            client.EnableSsl = true;
            client.Send(mail);
        }

        [System.Web.Http.AllowAnonymous]
        [System.Web.Http.HttpGet]
        [System.Web.Http.Route("api/accountapi/confirmemail", Name = "ConfirmEmailRoute")]
        public async Task<IHttpActionResult> ConfirmEmail(string userId, string code)
        {
            if (userId == null || code == null)
            {
                ModelState.AddModelError("", "User Id and Code are required");
                return BadRequest(ModelState);
            }
            var provider = new DpapiDataProtectionProvider("EmailConfirm");
            var context = new ApplicationDbContext();
            UserManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(context));
            UserManager.UserTokenProvider = new DataProtectorTokenProvider<ApplicationUser>(provider.Create("EmailConfirmation"));

            IdentityResult result = await UserManager.ConfirmEmailAsync(userId, code);

            if (result.Succeeded)
            {
                var currentUser = await UserManager.FindByIdAsync(userId);
                var roleresult = await UserManager.AddToRoleAsync(userId, "Rescuer");

                return Ok();
            }
            else
            {
                ModelState.AddModelError("", "Error on confirming email");
                return BadRequest(ModelState);
            }
        }

        [System.Web.Http.HttpGet]
        [System.Web.Http.AllowAnonymous]
        [System.Web.Http.Route("api/markerapi/login", Name = "Login")]
        public async Task<IHttpActionResult> Login(LoginViewModel model)
        {
            var provider = new DpapiDataProtectionProvider("LoginAPI");
            var context = new ApplicationDbContext();
            UserManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(context));
            UserManager.UserTokenProvider = new DataProtectorTokenProvider<ApplicationUser>(provider.Create("LoginAPIs"));

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            // Require the user to have a confirmed email before they can log on.
            var user = await UserManager.FindByNameAsync(model.Email);
            if (user != null)
            {
                return BadRequest(ModelState);
            }

            // This doesn't count login failures towards account lockout
            // To enable password failures to trigger account lockout, change to shouldLockout: true
            var result = await SignInManager.PasswordSignInAsync(model.Email, model.Password, model.RememberMe, shouldLockout: false);
            switch (result)
            {
                case SignInStatus.Success:
                    var currentUser = await UserManager.FindByEmailAsync(model.Email);
                    currentUser.LastActive = DateTime.Now;
                    IdentityResult iresult = await UserManager.UpdateAsync(currentUser);

                    return Ok(model);
                case SignInStatus.LockedOut:
                    return BadRequest();
                case SignInStatus.RequiresVerification:
                    return BadRequest();
                case SignInStatus.Failure:
                default:
                    ModelState.AddModelError("", "Invalid login attempt.");
                    return BadRequest(ModelState);
            }
        }

        [System.Web.Http.Authorize]
        [ValidateAntiForgeryToken]
        [System.Web.Http.HttpPut]
        [System.Web.Http.Route("api/markerapi/editprofile", Name = "EditProfile")]
        public async Task<IHttpActionResult> EditProfile(EditProfileViewModel model)
        {
            var types = GetAllTypes();
            var agencies = GetAllAgencies();

            model.Types = GetSelectListItems(types);
            model.Agencies = GetSelectListItems(agencies);

            if (ModelState.IsValid)
            {
                ApplicationUser user = await UserManager.FindByIdAsync(User.Identity.GetUserId());

                user.FirstName = model.FirstName;
                user.LastName = model.LastName;
                user.BirthDate = model.BirthDate;
                user.CellphoneNumber = model.CellphoneNumber;
                user.TelephoneNumber = model.TelephoneNumber;
                user.Type = model.Type;
                user.Agency = model.Agency;
                user.LastActive = DateTime.Now;

                IdentityResult result = await UserManager.UpdateAsync(user);
                if (result.Succeeded)
                {
                    return Ok(model);
                }
            }

            // If we got this far, something failed, redisplay form
            return BadRequest(ModelState);
        }

        private IEnumerable<string> GetAllTypes()
        {
            return new List<string>
            {
                "Hospital",
                "Police Department",
                "Fire Station"
            };
        }

        private IEnumerable<string> GetAllAgencies()
        {
            var agencies = from a in db.Agencies select a.Name;

            return agencies;
        }

        private IEnumerable<SelectListItem> GetSelectListItems(IEnumerable<string> elements)
        {
            var selectList = new List<SelectListItem>();

            foreach (var element in elements)
            {
                selectList.Add(new SelectListItem
                {
                    Value = element,
                    Text = element
                });
            }

            return selectList;
        }
    }
}
