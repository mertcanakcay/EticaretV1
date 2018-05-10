using EticaretV1.Core.Entity;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EticaretV1.Core.Map
{
   public class CoreMap<T>:EntityTypeConfiguration<T> where T:CoreEntity
    {
        public CoreMap()
        {
            Property(x => x.Id).HasColumnName("Id").HasDatabaseGeneratedOption(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity);
            Property(x => x.CreatedBy).IsOptional();
            Property(x => x.CreatedComputerName).HasColumnName("CreatedComputerName").HasMaxLength(50).IsOptional();
            Property(x => x.CreatedUserName).HasColumnName("CreatedUserName").HasMaxLength(50).IsOptional();
            Property(x => x.CreatedDate).HasColumnName("CreatedDate").IsOptional();
            Property(x => x.CreatedIp).HasColumnName("CreatedIp").HasMaxLength(50).IsOptional();

            Property(x => x.ModifiedBy).IsOptional();
            Property(x => x.ModifiedComputerName).HasColumnName("ModifiedComputerName").HasMaxLength(50).IsOptional();
            Property(x => x.ModifiedUserName).HasColumnName("ModifiedUserName").HasMaxLength(50).IsOptional();
            Property(x => x.ModifiedDate).HasColumnName("ModifiedDate").IsOptional();
            Property(x => x.ModifiedIp).HasColumnName("ModifiedIp").HasMaxLength(50).IsOptional();
        }
    }
}
