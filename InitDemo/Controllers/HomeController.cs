using InitDemo.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using InitDemo.Data;
using System.Data.Entity.Infrastructure;
using InitDemo.Services.Contracts;

namespace InitDemo.Controllers
{
    public class HomeController : Controller
    {

        IPostService postService;
        public HomeController(IPostService postService)
        {
            this.postService = postService;
        }
        public ActionResult Index()
        {
            IEnumerable<Post> posts = null;
            var ctx = new BlockSystemBdContext();
            posts = ctx.Post.ToList<Post>();
            return View(posts);
        }

        public ActionResult Comments(int postId)
        {
            var ctx = new BlockSystemBdContext();
            var post = ctx.Post.Find(postId);
            IEnumerable<Comment> comments = post.Comments.ToList<Comment>();
            return View(comments);
        }

        public ActionResult Edit(int postId)
        {
            var ctx = new BlockSystemBdContext();
            var post = ctx.Post.Find(postId);
           
            return View(post);
        }


        public ActionResult Post(int? id)
        {
            var ctx = new BlockSystemBdContext();
            var post = ctx.Post.Find(id);
            Console.WriteLine(" public ActionResult Post(int? id)");
            return View(post);
        }

        public ActionResult Create()
        {
            var post = new Post();
            return View(post);
        }

        [HttpPost]
        public ActionResult Create(Post post)
        {
            var ctx = new BlockSystemBdContext();
            post.DateCreated = DateTime.Now;
            ctx.Post.Add(post);
            ctx.SaveChanges();
            return View(post);
        }

        [HttpPost]
        public ActionResult Save(Post post)
        {
            var ctx = new BlockSystemBdContext();
            post.DateCreated = DateTime.Now;
            //ctx.Post.Add(post);
            if (TryUpdateModel(post, "",
                new string[] { "name", "content" }))
            {
                try
                {
                    ctx.SaveChanges();
                                        return RedirectToAction("Post/" + post.Id, "Home");
                }
                catch (RetryLimitExceededException /* dex */)
                {
                    //Log the error (uncomment dex variable name and add a line here to write a log.
                    ModelState.AddModelError("", "Unable to save changes. Try again, and if the problem persists, see your system administrator.");
                }
            }
          
            return RedirectToAction("Index");
        }

        [HttpPost]
        public ActionResult Comment( Comment comment)
        {
            var ctx = new BlockSystemBdContext();
            var post = ctx.Post.Find(comment.PostId);
            comment.DateCreated = DateTime.Now;
            post.Comments.Add(comment);
            ctx.SaveChanges();
            return RedirectToAction("Post/"+comment.PostId, "Home");
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";
            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";
            return View();
        }
    }
}