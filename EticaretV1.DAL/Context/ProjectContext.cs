using EticaretV1.Core.Entity;
using EticaretV1.Map.Option;
using EticaretV1.Model.Option;
using EticaretV1.Utility;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace EticaretV1.DAL.Context
{
   public class ProjectContext:DbContext
    {
        public ProjectContext()
        {
            Database.Connection.ConnectionString = "Server=Naso;Database=ETicaretV1.1;Integrated Security=True;";
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new AppUserMap());
            modelBuilder.Configurations.Add(new CategoryMap());
            modelBuilder.Configurations.Add(new CommentMap());
        
            modelBuilder.Configurations.Add(new ImagesForProductsMap());
            modelBuilder.Configurations.Add(new LikeMap());
            modelBuilder.Configurations.Add(new OrderDetailsMap());
            modelBuilder.Configurations.Add(new OrderMap());
            modelBuilder.Configurations.Add(new ProductMap());
            modelBuilder.Configurations.Add(new TreeCommentMap());

            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();

            base.OnModelCreating(modelBuilder);
        }
        public DbSet<AppUser> Users { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Comment> Comments { get; set; }
    
        public DbSet<ImagesForProducts> ImagesForProducts { get; set; }
        public DbSet<Like> Likes { get; set; }
        public DbSet<OrderDetails> OrderDetails { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<TreeComment> TreeComments { get; set; }
        public DbSet<DisLike> DisLikes { get; set; }

        public Guid UserID { get; set; }

        public override int SaveChanges()
        {
            var modifiedEntries = ChangeTracker.Entries().Where(x => x.State == EntityState.Modified || x.State == EntityState.Added).ToList();
            string identity = WindowsIdentity.GetCurrent().Name;
            string computerName = Environment.MachineName;
            DateTime dateTime = DateTime.Now;

            string GetIp = RemoteIp.GetIpAddress();
            foreach (var item in modifiedEntries)
            {
                CoreEntity entity = item.Entity as CoreEntity;
                if (item != null)
                {
                    if (item.State == EntityState.Added)
                    {
                        entity.CreatedUserName = identity;
                        entity.CreatedComputerName = computerName;
                        entity.CreatedDate = dateTime;

                        entity.CreatedIp = GetIp;
                    }
                    else if (item.State == EntityState.Modified)
                    {
                        entity.ModifiedUserName = identity;
                        entity.ModifiedComputerName = computerName;
                        entity.ModifiedDate = dateTime;

                        entity.ModifiedIp = GetIp;

                    }

                }
            }


            return base.SaveChanges();
        }

    }
}
