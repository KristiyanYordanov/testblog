namespace InitDemo.Data
{
    using InitDemo.Data.Repositories;
    using InitDemo.Models;

    public interface IBlogSystemData
    {
        IRepository<ApplicationUser> Users
        {
            get;
        }

        IRepository<Post> Posts
        {
            get;
        }

        IRepository<T> GetRepository<T>() where T:class;
    }
}
