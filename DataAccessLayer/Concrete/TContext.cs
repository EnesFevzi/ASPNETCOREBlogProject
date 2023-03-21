﻿using BlogProject1.EntityLayer.Concrete;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogProject1.DataAccessLayer.Concrete
{
	public class TContext : IdentityDbContext<WriterUser, WriterRole, int>
	{
		//public TContext(DbContextOptions options) : base(options)
		//{

		//}
		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
			optionsBuilder.UseSqlServer("server=(localdb)\\MSSQLLocalDB;database=2ASPNETCOREBlogProjectDB;integrated security=true");
			//optionsBuilder.UseSqlServer("server=DESKTOP-QMOGCM6; database=Test; integrated security=true;Encrypt=False;");
			//"Data Source=DESKTOP-SM0VBLO;Initial Catalog =IsSureciDB;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False"

		}
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
			modelBuilder.Entity<WriterMessage>()
				.HasOne(x => x.WriterSender)
				.WithMany(y => y.WriterSender)
				.HasForeignKey(z => z.SenderId)
				.OnDelete(DeleteBehavior.ClientSetNull);


			modelBuilder.Entity<WriterMessage>()
				.HasOne(x => x.WriterReceiver)
				.WithMany(y => y.WriterReceiver)
				.HasForeignKey(z => z.ReceiverId)
				.OnDelete(DeleteBehavior.ClientSetNull);

            
                modelBuilder.Entity<Comment>()
                    .HasOne(c => c.Blog)
                    .WithMany(b => b.Comments)
                    .HasForeignKey(c => c.BlogID)
					.OnDelete(DeleteBehavior.ClientSetNull);


            base.OnModelCreating(modelBuilder);
		}

        public DbSet<About> Abouts { get; set; }
		public DbSet<Admin> Admins { get; set; }
		public DbSet<Blog> Blogs { get; set; }
		public DbSet<BlogRating> BlogRatings { get; set; }
		public DbSet<Contact> Contacts { get; set; }
		public DbSet<Category> Categories { get; set; }
		public DbSet<Comment> Comments { get; set; }
		public DbSet<Message> Messages { get; set; }
		public DbSet<WriterMessage> Message2s { get; set; }
		public DbSet<Notification> Notifications { get; set; }
		public DbSet<SocialMedia> SocialMedias { get; set; }
		public DbSet<NewsLetter> NewsLetters { get; set; }
		public DbSet<WriterUser> WriterUsers { get; set; }
		
	}
}
