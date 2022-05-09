using ClientRegister.Support.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace ClientRegister.Data.Seeds
{
    public class ClientSeed : IEntityTypeConfiguration<Client>
    {
        public void Configure(EntityTypeBuilder<Client> builder)
        {
            var gender = "";
            for (int i = 1; i < 9; i++)
            {                
                if (i % 2 == 0)
                {
                    gender = "Male";
                }
                else
                {
                    gender = "Female";
                }
                builder.HasData(
                    new Client
                    {
                        Id = i,
                        FullName = "Client Name" + i,
                        DNI = 12345671+i,
                        Age = 20 + i,
                        Gender = gender,
                        DriverLicense = false,
                        UseGlasses = true,
                        IsDiabetic = false,
                        OtherDisease = false,
                        Disease = null,
                        IsActive = true,
                        Properties = null,
                        ModifiedAt = DateTime.Now
                    });
            }
        }
    }
}