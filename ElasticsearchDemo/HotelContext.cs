using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Pomelo.EntityFrameworkCore.MySql.Scaffolding.Internal;

namespace ElasticsearchDemo;

public partial class HotelContext : DbContext
{
    public HotelContext()
    {
    }

    public HotelContext(DbContextOptions<HotelContext> options)
        : base(options)
    {
    }

    public virtual DbSet<TbHotel> TbHotels { get; set; }


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder
            .UseCollation("utf8mb4_0900_ai_ci")
            .HasCharSet("utf8mb4");

        modelBuilder.Entity<TbHotel>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity
                .ToTable("tb_hotel")
                .UseCollation("utf8mb4_general_ci");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasComment("酒店id")
                .HasColumnName("id");
            entity.Property(e => e.Address)
                .HasMaxLength(255)
                .HasComment("酒店地址")
                .HasColumnName("address");
            entity.Property(e => e.Brand)
                .HasMaxLength(32)
                .HasComment("酒店品牌")
                .HasColumnName("brand");
            entity.Property(e => e.Business)
                .HasMaxLength(255)
                .HasComment("商圈")
                .HasColumnName("business");
            entity.Property(e => e.City)
                .HasMaxLength(32)
                .HasComment("所在城市")
                .HasColumnName("city");
            entity.Property(e => e.Latitude)
                .HasMaxLength(32)
                .HasComment("纬度")
                .HasColumnName("latitude");
            entity.Property(e => e.Longitude)
                .HasMaxLength(32)
                .HasComment("经度")
                .HasColumnName("longitude");
            entity.Property(e => e.Name)
                .HasMaxLength(255)
                .HasComment("酒店名称")
                .HasColumnName("name");
            entity.Property(e => e.Pic)
                .HasMaxLength(255)
                .HasComment("酒店图片")
                .HasColumnName("pic");
            entity.Property(e => e.Price)
                .HasComment("酒店价格")
                .HasColumnName("price");
            entity.Property(e => e.Score)
                .HasComment("酒店评分")
                .HasColumnName("score");
            entity.Property(e => e.StarName)
                .HasMaxLength(16)
                .HasComment("酒店星级，1星到5星，1钻到5钻")
                .HasColumnName("star_name");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
