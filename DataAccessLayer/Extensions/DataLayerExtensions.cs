using BlogProject1.DataAccessLayer.Abstract;
using BlogProject1.DataAccessLayer.Concrete.EntityFramework;
using BlogProject1.DataAccessLayer.Repository;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogProject1.DataAccessLayer.Extensions
{
    public static class DataLayerExtensions
    {
        public static IServiceCollection LoadDataLayerExtension(this IServiceCollection services)
        {
            //services.AddScoped(typeof(IGenericRepository<>),typeof(GenericRepository<>));
            services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
            services.AddScoped<IAboutRepository, EfAboutRepository>();
            services.AddScoped<IWriterTaskRepository, EfWriterTaskRepository>();
            services.AddScoped<IBlogRepository, EfBlogRepository>();
            services.AddScoped<ICommentRepository, EfCommentRepository>();
            services.AddScoped<IWriterMessageRepository, EfWriterMessageRepository>();
            services.AddScoped<ICategoryRepository, EfCategoryRepository>();
            

            //services.AddScoped<ICategoryRepository, EfCategoryRepository>();

            //services.AddScoped<IBlogRepository, EfBlogRepository>();

            //services.AddScoped<ICommentRepository, EfCommentRepository>();

            //services.AddScoped<IContactRepository, EfContactRepository>();

            //services.AddScoped<IMessageRepository, EfMessageRepository>();

            //services.AddScoped<INewsLetterRepository, EfNewsLetterRepository>();

            //services.AddScoped<INotificationRepository, EfNotificationRepository>();

            //services.AddScoped<IWriterMessageRepository, EfWriterMessageRepository>();

            return services;


        }
    }
}
