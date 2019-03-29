using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication3.Data;
using WebApplication3.Models;

namespace WebApplication3.Filters
{
    public class UserLoggerFilter : IActionFilter
    {
        private UserManager<IdentityUser> _mgr;
        private IHttpContextAccessor _IHttpContextAccessor;
        private ApplicationDbContext _db;
        private IEmailSender _emailSender;

        public UserLoggerFilter(UserManager<IdentityUser> mgr, IHttpContextAccessor IHttpContextAccesso, ApplicationDbContext db, IEmailSender emailSender)
        {
            _db = db;
            _mgr = mgr;
            _IHttpContextAccessor = IHttpContextAccesso;
            _emailSender = emailSender;

        }

        public void OnActionExecuted(ActionExecutedContext context)
        {
            throw new NotImplementedException();
        }

        public void OnActionExecuting(ActionExecutingContext context)
        {
            string c;
            context.HttpContext.Request.Cookies.TryGetValue(".AspNetCore.Identity.Application", out c); //to jest taka metoda outer string więc ten string c sam zostanie wypełniony, tak na podpowiedziało w nawiasi "out string value"

            UserLogger userLogged = new UserLogger();

            userLogged.DateExecuted = DateTime.Now;
            userLogged.Message = context.Controller.ToString();
            userLogged.CookieInfo = c;
            userLogged.UserId = _mgr.GetUserId(_IHttpContextAccessor.HttpContext.User);

            _db.Add(userLogged);
            _db.SaveChanges();

            var view = context.ActionDescriptor.RouteValues.ElementAt(0).Value;

            if( view == "About")
            {
                context.Result = new ViewResult { ViewName = "AccesDenied" };
            }

            _emailSender.SendEmailAsync("jakismail@gmail.com", "title", "helloMessage");

            
        }
    }
}
