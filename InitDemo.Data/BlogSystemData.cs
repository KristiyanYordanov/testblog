﻿namespace InitDemo.Data
{
using System;
using System.Collections.Generic;
using System.Data.Entity;
using InitDemo.Data.Repositories;
using InitDemo.Models;
using Data;
public class BlogSystemData : IBlogSystemData
{
        private DbContext context;
        private Dictionary<Type, object> repositories;

        public BlogSystemData()
            : this(new BlockSystemBdContext())
        {
        }

        public BlogSystemData(DbContext context)
        {
            this.context = context;
            this.repositories = new Dictionary<Type, object>();
        }

        public IRepository<ApplicationUser> Users
        {
            get
            {
                return this.GetRepository<ApplicationUser>();
            }
        }

        public IRepository<Post> Posts
        {
            get
            {
                return this.GetRepository<Post>();
            }
        }

        public IRepository<T> GetRepository<T>() where T : class
        {
            var typeOfRepository = typeof(T);
            if (!this.repositories.ContainsKey(typeOfRepository))
            {
                var newRepository = Activator.CreateInstance(typeof(Repository<T>), context);
                this.repositories.Add(typeOfRepository, newRepository);
            }

            return (IRepository<T>) this.repositories[typeOfRepository];
        }

        public int SaveChanges()
        {
            return this.context.SaveChanges();
        }
    }
}
