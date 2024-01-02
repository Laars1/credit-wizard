using credit_wizard_api.Models;
using credit_wizard_api.Services;
using credit_wizard_api.Settings;
using credit_wizard_api.Tests.Component.Unit.Mock.Manager;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using System.Security.Claims;

namespace credit_wizard_api.Tests.Component.Unit.Services
{
    public class AuthenticationServiceFixture
    {
        private DbContextOptions<ApplicationDbContext> dbContextOptions;
        private readonly JwtSettings _jwtSettings;

        public AuthenticationServiceFixture()
        {
            var dbName = $"AuthenticationService_{DateTime.Now.ToFileTimeUtc()}";
            dbContextOptions = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase(dbName)
                .Options;

            _jwtSettings = new JwtSettings
            {
                ValidIssuer = "https://localhost:44379/",
                ValidAudience = "*",
                JwtSecret = "xy"
            };
        }

        [Theory]
        [InlineData("Password1", false)]
        [InlineData("asdf", false)]
        [InlineData("Test@12", false)]
        [InlineData("Test@123", true)]
        public async Task CheckPasswordAsnyc(string value, bool succeded)
        {
            //Arrange
            var user = new User
            {
                Id = Guid.Parse("88fb78eb-7c6e-4d97-a8f9-8300cad558c5"),
                Email = "hans.mustermann@email.ch",
                UserName = "hans.mustermann@email.ch",
                NormalizedUserName = "hans.mustermann@email.ch".ToUpper(),
                NormalizedEmail = "hans.mustermann@email.ch".ToUpper(),
                EmailConfirmed = true,
                PhoneNumberConfirmed = true,
                MatriculationNumber = "11-111-11",
                DegreeId = Guid.Parse("4b6feabb-8f23-4c91-83d2-1c9b8df465ce"),
                Prename = "Hans",
                Lastname = "Mustermann",
                PasswordHash = new PasswordHasher<User>().HashPassword(null, "Test@123"),
            };

            var userManagerMock = UserManagerMock.MockUserManager<User>(succeded);
            var options = Substitute.For<IOptions<JwtSettings>>();
            options.Value.Returns(_jwtSettings);

            var service = new AuthenticationService(options, userManagerMock);

            //Act
            var act = await service.CheckPasswordAsync(user, value);

            //Assert
            act.Should().Be(succeded);
        }

        [Fact]
        public void GenerateToken_ClaimsShouldBeEmpty()
        {
            //Arrange
            var userManagerMock = UserManagerMock.MockUserManager<User>(true);
            var options = Substitute.For<IOptions<JwtSettings>>();
            options.Value.Returns(_jwtSettings);

            var service = new AuthenticationService(options, userManagerMock);

            //Act
            var act = service.GenerateToken(Guid.NewGuid(), new List<string>());

            //Assert
            act.Claims.Any(x => x.Type == ClaimTypes.Role).Should().BeFalse();
        }

    }
}
