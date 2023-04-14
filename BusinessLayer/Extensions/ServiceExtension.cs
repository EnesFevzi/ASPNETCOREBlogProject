using BlogProject1.BusinessLayer.Abstract;
using BlogProject1.BusinessLayer.Concrete;
using BlogProject1.DataAccessLayer.Abstract;
using BlogProject1.DataAccessLayer.Repository;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogProject1.BusinessLayer.Extensions
{
    public static class ServiceExtensions
    {
        public static IServiceCollection LoadServiceLayerExtension(this IServiceCollection services)
        {
            services.AddScoped<IAboutService , AboutManager>();
            services.AddScoped<IContactService , ContactManager>();
            services.AddScoped<IWriterTaskService , WriterTaskManager>();
            services.AddScoped<IBlogService , BlogManager>();
            services.AddScoped<ICommentService , CommentManager>();
            services.AddScoped<ICategoryService , CategoryManager>();
            services.AddScoped<IWriterMessageService, WriterMessageManager>();
            services.AddScoped<IVideoService, VideoManager>();
            services.AddScoped<INewService, NewManager>();
            services.AddScoped<IMessageService, MessageManager>();
            services.AddScoped<INotificationService, NotificationManager>();

            //services.AddScoped<IAboutRepository, EfAboutRepository>();

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
