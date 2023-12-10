using credit_wizard_api.Models;
using credit_wizard_api.Services;
using Microsoft.EntityFrameworkCore;

namespace credit_wizard_api.Tests.Component.Unit.Services
{
    public class SemesterTimeSlotServiceFixture
    {
        private DbContextOptions<ApplicationDbContext> dbContextOptions;
        private readonly int _amount = 3;


        public SemesterTimeSlotServiceFixture()
        {
            var dbName = $"SemesterTimeSlotService_{DateTime.Now.ToFileTimeUtc()}";
            dbContextOptions = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase(dbName)
                .Options;
        }

        [Fact]
        public async Task GetAllBySemesterTimeSlots_ShouldReturn()
        {

            //Arrange
            var context = new ApplicationDbContext(dbContextOptions);
            await GenerateDataAsync(context, _amount);
            var service = new SemesterTimeSlotService(context);

            //Act
            var result = await service.GetAsync();


            //Assert
            result.Should().NotBeNull();
            result.Count.Should().Be(_amount);
        }

        [Fact]
        public async Task GetAllBySemesterTimeSlots_ShouldReturnEmptyList()
        {

            //Arrange
            var context = new ApplicationDbContext(dbContextOptions);
            var service = new SemesterTimeSlotService(context);

            //Act
            var result = await service.GetAsync();


            //Assert
            result.Should().NotBeNull();
            result.Count.Should().Be(0);
        }

        [Fact]
        public async void GetByIdAsync_ShouldBeNull()
        {
            // Arrange
            var context = new ApplicationDbContext(dbContextOptions);
            var service = new SemesterTimeSlotService(context);
            // Act
            var act = await service.GetByIdAsync(Guid.NewGuid());

            // Act & Assert
            act.Should().BeNull();
        }

        [Fact]
        public async void GetByIdAsync_ShouldReturn()
        {
            // Arrange
            var context = new ApplicationDbContext(dbContextOptions);
            var team = await CreateTeamAsync(context);
            var service = new SemesterTimeSlotService(context);

            // Act
            var act = await service.GetByIdAsync(team.Id);

            // Act & Assert
            act.Should().NotBeNull();
            act.Id.Should().Be(team.Id);
            act.Timeslot.Should().Be(team.Timeslot);
        }

        private async Task<SemesterTimeSlot> CreateTeamAsync(ApplicationDbContext context)
        {
            var id = Guid.NewGuid();
            var entry = new SemesterTimeSlot
            {
                Id = id,
                Timeslot = $"Test_{id}"
            };
            context.SemesterTimeSlots.Add(entry);
            await context.SaveChangesAsync();
            return entry;
        }

        private async Task GenerateDataAsync(ApplicationDbContext context, int amountEntries)
        {
            var data = new List<SemesterTimeSlot>();
            for (var i = 0; i < amountEntries; i++)
            {
                var id = Guid.NewGuid();
                data.Add(new SemesterTimeSlot
                {
                    Id = id,
                    Timeslot = $"Test_{id}"
                });
            }
            context.SemesterTimeSlots.AddRange(data);
            await context.SaveChangesAsync();
        }
    }
}
