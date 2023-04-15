using Entities.Models.Owners;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Repository.Configuration;

public class OwnerConfiguration : IEntityTypeConfiguration<Owner>
{
    public void Configure(EntityTypeBuilder<Owner> builder)
    {
        builder.HasData(
            new Owner
            {
                Id = Guid.NewGuid(),
                Name = "José",
                SurNames = "Pérez Lopez",
                Dni = "12345678A",
                Gender = GenderEnum.Male,
                Nationality = NationalityEnum.Brazil,
                TramitNumber = "12345678A",
                BirthDate = DateTime.Now,
                PhoneCode = "123",
                PhoneNumber = "12345678A",
                MaritalStatus = MaritalStatusEnum.Soltero,
                Pep = false
            }
        );
    }
}