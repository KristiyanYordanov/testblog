using InitDemo.Data;
using InitDemo.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace InitDemo.Controllers
{
    [Authorize]
    public class RolesController : Controller
    {
             
            private BlockSystemBdContext context = new BlockSystemBdContext();



            /// <summary>
            /// Get All Roles
            /// </summary>
            /// <returns></returns>
            public ActionResult Index()
            {

                if (User.Identity.IsAuthenticated)
                {


                    if (!isAdminUser())
                    {
                        return RedirectToAction("Index", "Home");
                    }
                }
                else
                {
                    return RedirectToAction("Index", "Home");
                }

                var Roles = context.Roles.ToList();
                return View(Roles);

            }
            public Boolean isAdminUser()
            {
                if (User.Identity.IsAuthenticated)
                {
                    var user = User.Identity;

                var UserManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(context));



                var s = UserManager.GetRoles(user.GetUserId());
                var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(context));
                var roles = roleManager.Roles;
                //var Roles = context.Roles.ToList();


                foreach (var item in roles)
                {
                    Console.WriteLine(item.Name);
                    
                    if (item.Name.ToString() == "Admin")
                    {
                       // if (item.Users.Contains(user)) {

                        
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
               
                   
                }
                return false;
            }
            /// <summary>
            /// Create  a New role
            /// </summary>
            /// <returns></returns>
            public ActionResult Create()
            {
                if (User.Identity.IsAuthenticated)
                {


                    if (!isAdminUser())
                    {
                        return RedirectToAction("Index", "Home");
                    }
                }
                else
                {
                    return RedirectToAction("Index", "Home");
                }

                var Role = new IdentityRole();
                return View(Role);
            }

            /// <summary>
            /// Create a New Role
            /// </summary>
            /// <param name="Role"></param>
            /// <returns></returns>
            [HttpPost]
            public ActionResult Create(IdentityRole Role)
            {
                if (User.Identity.IsAuthenticated)
                {
                    if (!isAdminUser())
                    {
                        return RedirectToAction("Index", "Home");
                    }
                }
                else
                {
                    return RedirectToAction("Index", "Home");
                }

                context.Roles.Add(Role);
                context.SaveChanges();
                return RedirectToAction("Index");
            }
        }
    }
