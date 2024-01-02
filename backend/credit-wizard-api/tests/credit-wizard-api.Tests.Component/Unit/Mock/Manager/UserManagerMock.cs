using credit_wizard_api.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Moq;
using NSubstitute;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace credit_wizard_api.Tests.Component.Unit.Mock.Manager
{
    public static class UserManagerMock
    {
        public static UserManager<TUser> MockUserManager<TUser>(bool correctPassword = true) where TUser : class
        {
            var userPasswordStore = new Mock<IUserPasswordStore<TUser>>();
            userPasswordStore.Setup(s => s.CreateAsync(It.IsAny<TUser>(), It.IsAny<CancellationToken>()))
                .Returns(Task.FromResult(IdentityResult.Success));

            var options = new Mock<IOptions<IdentityOptions>>();
            var idOptions = new IdentityOptions();
            var userValidators = new List<IUserValidator<TUser>>();
            UserValidator<TUser> validator = new UserValidator<TUser>();
            userValidators.Add(validator);

            var passValidator = new PasswordValidator<TUser>();
            var pwdValidators = new List<IPasswordValidator<TUser>>();
            pwdValidators.Add(passValidator);

            var userManager = new Mock<UserManager<TUser>>(userPasswordStore.Object, options.Object, new PasswordHasher<TUser>(),
                userValidators, pwdValidators, new UpperInvariantLookupNormalizer(),
                new IdentityErrorDescriber(), null,
                new Mock<ILogger<UserManager<TUser>>>().Object);

            userManager.Setup(manager => manager.CheckPasswordAsync(It.IsAny<TUser>(), It.IsAny<string>()))
                .Returns(correctPassword ? Task.FromResult(true) : Task.FromResult(false));


            return userManager.Object;
        }
    }
}
