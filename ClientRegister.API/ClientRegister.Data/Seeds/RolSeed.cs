using ClientRegister.Support.Models.Enums;
using ClientRegister.Support.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace ClientRegister.Data.Seeds
{
    public class RolSeed : IEntityTypeConfiguration<Rol>
    {
        public void Configure(EntityTypeBuilder<Rol> builder)
        {
            CreateSeed(builder, "Administrator", RoleTypes.Administrator);
        }
        private static void CreateSeed(EntityTypeBuilder<Rol> builder, string type, int value)
        {
            builder.HasData(
                new Rol
                {
                    Id = value,
                    Name = type,
                    Description = $"{type} rol type",
                    ModifiedAt = DateTime.Now,
                    IsActive = true
                });
        }
    }
}
