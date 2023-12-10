using credit_wizard_api.Models;
using credit_wizard_api.Services;
using Microsoft.EntityFrameworkCore;
using NSubstitute.Routing.Handlers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace credit_wizard_api.Tests.Component.Unit.Services
{
    public class DegreeServiceFixture
    {
        private DbContextOptions<ApplicationDbContext> dbContextOptions;
        private readonly int _amount = 3;

        public DegreeServiceFixture()
        {
            var dbName = $"DegreeService_{DateTime.Now.ToFileTimeUtc()}";
            dbContextOptions = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase(dbName)
                .Options;
        }

        [Fact]
        public async Task GetAllByDegreeAsync_ShouldReturn()
        {
            //Arrange
            var context = new ApplicationDbContext(dbContextOptions);
            await GenerateDataAsync(context, _amount);
            var service = new DegreeService(context);

            //Act
            var act = await service.GetAsync();

            //Assert
            act.Should().NotBeNull();
            act.Should().HaveCount(_amount);
        }

        [Fact]
        public async Task GetAllByDegreeAsync_ShouldReturnEmptyList()
        {
            //Arrange
            var context = new ApplicationDbContext(dbContextOptions);
            var service = new DegreeService(context);

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
            var service = new DegreeService(context);
            // Act
            var act = await service.GetByIdAsync(Guid.NewGuid());

            // Act & Assert
            act.Should().BeNull();
        }

        [Fact]
        public async void GetByIdAsync_ShouldReturnWithoutReferencedEntities()
        {
            // Arrange
            var context = new ApplicationDbContext(dbContextOptions);
            var degree = await CreateDegreeAsync(context);
            var service = new DegreeService(context);

            // Act
            var act = await service.GetByIdAsync(degree.Id);

            // Act & Assert
            act.Should().NotBeNull();
            act.Id.Should().Be(degree.Id);
            act.Description.Should().Be(degree.Description);
            act.Name.Should().Be(degree.Name);
            act.DegreeModuls.Count.Should().Be(0);
            act.TotalEtcsPoints.Should().Be(degree.TotalEtcsPoints);
            act.Users.Count.Should().Be(0);
        }

        [Fact]
        public async void GetByIdWithModulesAsync_ShouldBeNull()
        {
            // Arrange
            var context = new ApplicationDbContext(dbContextOptions);
            var service = new DegreeService(context);
            // Act
            var act = await service.GetByIdWithModulesAsync(Guid.NewGuid());

            // Act & Assert
            act.Should().BeNull();
        }

        [Fact]
        public async void GetByIdWithModulesAsync_ShouldReturnWithReferencedEntities()
        {
            // Arrange
            var context = new ApplicationDbContext(dbContextOptions);
            var degree = await CreateDegreeAsync(context);
            var service = new DegreeService(context);

            // Act
            var act = await service.GetByIdWithModulesAsync(degree.Id);

            // Assert
            act.Should().NotBeNull();
            act.Id.Should().Be(degree.Id);
            act.Description.Should().Be(degree.Description);
            act.Name.Should().Be(degree.Name);
            act.TotalEtcsPoints.Should().Be(degree.TotalEtcsPoints);
            act.Users.Count.Should().Be(0);
            act.DegreeModuls.Count.Should().Be(1);
            act.DegreeModuls.FirstOrDefault().DegreeId.Should().Be(degree.Id);
            act.DegreeModuls.FirstOrDefault().ModulId.Should().NotBeEmpty();
            act.DegreeModuls.FirstOrDefault().Modul.Should().BeOfType<Modul>();
            act.DegreeModuls.FirstOrDefault().Modul.EtcsPoints.Should().Be(6);
            act.DegreeModuls.FirstOrDefault().Modul.SemesterTimeSlot.FirstOrDefault().Timeslot.Should().BeSameAs("Test_Semester");
        }

        [Fact]
        public async Task GetByIdWithModulesByTimeslotAsync_ShouldReturn()
        {
            // Arrange
            var context = new ApplicationDbContext(dbContextOptions);
            var degree = await CreateDegreeAsync(context);
            var service = new DegreeService(context);

            // Act
            var act = await service.GetByIdWithModulesByTimeslotAsync(degree.Id, degree.DegreeModuls.First().Modul.SemesterTimeSlot.First().Id);

            // Assert
            act.Should().NotBeNull();
            act.Count.Should().Be(1);
            act.Should().BeAssignableTo<List<DegreeModul>>();
        }

        [Fact]
        public async Task GetByIdWithModulesByTimeslotAsync_ShouldBeEmpty()
        {
            // Arrange
            var context = new ApplicationDbContext(dbContextOptions);
            var degree = await CreateDegreeAsync(context);
            var service = new DegreeService(context);

            // Act
            var act = await service.GetByIdWithModulesByTimeslotAsync(degree.Id, Guid.NewGuid());

            // Assert
            act.Should().NotBeNull();
            act.Count.Should().Be(0);
        }

        [Fact]
        public async Task IsModulPartOfDegreeAsync_ShouldRetrunFalse()
        {
            // Arrange
            var context = new ApplicationDbContext(dbContextOptions);
            var degree = await CreateDegreeAsync(context);
            var service = new DegreeService(context);

            // Act
            var act = await service.IsModulPartOfDegreeAsync(Guid.NewGuid(), degree.Id);

            // Assert
            act.Should().BeFalse();
        }
        [Fact]
        public async Task IsModulPartOfDegreeAsync_ShouldRetrunTrue()
        {
            // Arrange
            var context = new ApplicationDbContext(dbContextOptions);
            var degree = await CreateDegreeAsync(context);
            var service = new DegreeService(context);

            // Act
            var act = await service.IsModulPartOfDegreeAsync(degree.DegreeModuls.FirstOrDefault().Modul.Id, degree.Id);

            // Assert
            act.Should().BeTrue();
        }


        private async Task<Degree> CreateDegreeAsync(ApplicationDbContext context)
        {
            var id = Guid.NewGuid();
            var entry = new Degree
            {
                Id = id,
                Name = $"Test_{id}",
                Description = $"Test_Description{id}",
                TotalEtcsPoints = 90,
                DegreeModuls = new[]
                {
                    new DegreeModul
                    {
                        IsRequired = true,
                        Modul = new Modul
                        {
                            Id = Guid.NewGuid(),
                            Description = "Description_Modul",
                            Abbreviation = "asdf",
                            EtcsPoints = 6,
                            Name = "TestModul",
                            SemesterTimeSlot = new List<SemesterTimeSlot>{
                                new SemesterTimeSlot
                                {
                                    Id= Guid.NewGuid(),
                                    Timeslot = "Test_Semester"
                                }
                            }
                        }
                    }
                }
            };
            context.Degrees.Add(entry);
            await context.SaveChangesAsync();
            return entry;
        }

        private async Task GenerateDataAsync(ApplicationDbContext context, int amountEntries)
        {
            var etcs = new int[2] { 90, 180 };
            var data = new List<Degree>();
            var random = new Random();
            for (var i = 0; i < amountEntries; i++)
            {
                var id = Guid.NewGuid();
                data.Add(new Degree
                {
                    Id = id,
                    Name = $"Test_{id}",
                    Description = $"Test_Description{id}",
                    TotalEtcsPoints = etcs[random.Next(0, etcs.Length)]
                });
            }
            context.Degrees.AddRange(data);
            await context.SaveChangesAsync();
        }
    }
}
