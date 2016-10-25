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
using Microsoft.AspNet.Identity.EntityFramework;

namespace GoGreenV3.Controllers
{
    public class AccountAPIController : ApiController
    {
        public UserManager<ApplicationUser> UserManager { get; private set; }
        private AgencyDbContext db = new AgencyDbContext();

        [System.Web.Http.Route("api/accountapi/register")]
        [System.Web.Http.HttpPost]
        [ResponseType(typeof(RegisterViewModel))]
        public async Task<IHttpActionResult> Register(RegisterViewModel model)
        {
            var context = new ApplicationDbContext();
            UserManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(context));

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
                    //try
                    //{
                    //    // Sets account's role to Default upon registration
                    //    await UserManager.AddToRoleAsync(user.Email, "Default");
                    //}
                    //catch
                    //{
                    //    return BadRequest(ModelState);
                    //}

                    //string code = await UserManager.GenerateEmailConfirmationTokenAsync(user.Id);
                    //var callbackUrl = Url.Action("ConfirmEmail", "Account", new { userId = user.Id, code = code }, protocol: Request.Url.Scheme);
                    //await UserManager.SendEmailAsync(user.Id, "Confirm your account", "Please confirm your account by clicking: " + callbackUrl);

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
