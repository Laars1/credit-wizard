using credit_wizard_api.Models;
using credit_wizard_api.Services;
using Microsoft.EntityFrameworkCore;
using NUnit.Framework.Constraints;
using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace credit_wizard_api.Tests.Component.Unit.Services
{
    public class ModulServiceFixture
    {
        private DbContextOptions<ApplicationDbContext> dbContextOptions;
        private readonly int _amount = 3;

        public ModulServiceFixture()
        {
            var dbName = $"ModulService_{DateTime.Now.ToFileTimeUtc()}";
            dbContextOptions = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase(dbName)
                .Options;
        }

        [Fact]
        public async Task GetAllByModulAsync_ShouldReturn()
        {
            //Arrange
            var context = new ApplicationDbContext(dbContextOptions);
            await GenerateDataAsync(context, _amount);
            var service = new ModulService(context);

            //Act
            var act = await service.GetAsync();

            //Assert
            act.Should().NotBeNull();
            act.Should().HaveCount(_amount);
            act.ForEach(x =>
            {
                x.Id.Should().NotBeEmpty();
                x.SemesterTimeSlot.Should().HaveCount(1);
                x.Abbreviation.Should().NotBeEmpty();
                x.EtcsPoints.Should().BeOneOf(new[] { 2, 3, 6 });
                x.Name.Should().NotBeEmpty();
                x.DegreeModuls.Count().Should().Be(1);
            });
        }

        [Fact]
        public async Task GetAllByModulAsync_ShouldReturnEmptyList()
        {
            //Arrange
            var context = new ApplicationDbContext(dbContextOptions);
            var service = new ModulService(context);

            //Act
            var act = await service.GetAsync();

            //Assert
            act.Should().NotBeNull();
            act.Should().HaveCount(0);
        }

        [Fact]
        public async void GetByIdAsync_ShouldBeNull()
        {
            // Arrange
            var context = new ApplicationDbContext(dbContextOptions);
            var service = new ModulService(context);
            // Act
            var act = await service.GetByIdAsync(Guid.NewGuid());

            // Act & Assert
            act.Should().BeNull();
        }

        [Fact]
        public async void GetByIdAsync_ShouldReturnWithReferencedEntities()
        {
            // Arrange
            var context = new ApplicationDbContext(dbContextOptions);
            var modul = await CreateModulAsync(context);
            var service = new ModulService(context);

            // Act
            var act = await service.GetByIdAsync(modul.Id);

            // Act & Assert
            act.Should().NotBeNull();
            act.Id.Should().Be(modul.Id);
            act.Description.Should().Be(modul.Description);
            act.Name.Should().Be(modul.Name);
            act.DegreeModuls.Count.Should().Be(1);
            act.DegreeModuls.First().Degree.TotalEtcsPoints.Should().Be(180);
            act.SemesterTimeSlot.Should().HaveCount(1);
            act.Abbreviation.Should().NotBeEmpty();
            act.EtcsPoints.Should().BeOneOf(new[] { 2, 3, 6 });
            act.Name.Should().NotBeEmpty();
        }

        private async Task<Modul> CreateModulAsync(ApplicationDbContext context)
        {
            var id = Guid.NewGuid();
            var entry = new Modul
            {
                Id = id,
                Description = "Description_Modul",
                Abbreviation = "asdf",
                EtcsPoints = 6,
                Name = $"TestModul_{id}",
                SemesterTimeSlot = new List<SemesterTimeSlot>{
                        new SemesterTimeSlot
                        {
                            Id= Guid.NewGuid(),
                            Timeslot = $"Test_Semester_{id}"
                        }
                    },
                DegreeModuls = new List<DegreeModul>()
                    {
                        new()
                        {
                            DegreeId = Guid.NewGuid(),
                            IsRequired = false,
                            Degree = new Degree
                            {
                                Description = "TestDegree",
                                Name = "TestDegree",
                                TotalEtcsPoints = 180
                            }
                        }
                    }
            };
            context.Moduls.Add(entry);
            await context.SaveChangesAsync();
            return entry;
        }

        private async Task GenerateDataAsync(ApplicationDbContext context, int amountEntries)
        {
            var etcs = new int[3] { 2, 3, 6 };

            var data = new List<Modul>();
            var random = new Random();
            for (var i = 0; i < amountEntries; i++)
            {
                var id = Guid.NewGuid();
                data.Add(new Modul
                {
                    Id = id,
                    Description = "Description_Modul",
                    Abbreviation = "asdf",
                    EtcsPoints = etcs[random.Next(0, etcs.Length)],
                    Name = $"TestModul_{id}",
                    SemesterTimeSlot = new List<SemesterTimeSlot>{
                        new SemesterTimeSlot
                        {
                            Id= Guid.NewGuid(),
                            Timeslot = $"Test_Semester_{id}"
                        }
                    },
                    DegreeModuls = new List<DegreeModul>()
                    {
                        new()
                        {
                            DegreeId = Guid.NewGuid(),
                            IsRequired = random.NextDouble() >= 0.5,
                            Degree = new Degree
                            {
                                Description = "TestDegree",
                                Name = "TestDegree",
                                TotalEtcsPoints = 180
                            }
                        }
                    }
                }); ;
            }
            context.Moduls.AddRange(data);
            await context.SaveChangesAsync();
        }
    }
}
