using DDD.NetCore.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace DDD.NetCore.Infrastructure.Data.Mappings
{
    public class StudentMap : IEntityTypeConfiguration<Student>
    {
        /// <summary>
        /// 实体属性配置
        /// </summary>
        /// <param name="builder"></param>
        public void Configure(EntityTypeBuilder<Student> builder)
        {
            builder.Property(c => c.Id).HasColumnName("Id");
            builder.Property(c => c.Name).HasColumnType("varchar(100)").HasMaxLength(100).IsRequired();
            builder.Property(c => c.Email).HasColumnType("varchar(100)").HasMaxLength(11).IsRequired();
            // 处理值对象配置，否则会被视为实体
            builder.OwnsOne(p => p.Address);
            // 如果想忽略当前值对象，可直接 Ignore
            //builder.Ignore(c => c.Address);
        }
    }

}
