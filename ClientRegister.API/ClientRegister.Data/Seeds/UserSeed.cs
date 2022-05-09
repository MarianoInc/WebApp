using ClientRegister.Support.Encrypt;
using ClientRegister.Support.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace ClientRegister.Data.Seeds
{
    public class UserSeed : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            for (int i = 1; i < 6; i++)
            {
                builder.HasData(
                    new User
                    {
                        Id = i,
                        UserName = "Admin " + i,
                        Password = EncryptSha256.Encrypt("Password"),
                        IsActive = true,
                        RolesId = 1,
                        ModifiedAt = DateTime.Now
                    });
            }
        }
    }
}
