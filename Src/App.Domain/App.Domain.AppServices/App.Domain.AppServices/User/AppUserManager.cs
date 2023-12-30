using App.Domain.Core.User.Contracts.AppServices;
using App.Domain.Core.User.Dtos;
using App.Domain.Core.User.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.AppServices.User
{
    public class AppUserManager:UserManager<AppUser>,IAppUserManager
    {
        private readonly AppErrorDescriber _appErrorDescriber;
        private readonly ILookupNormalizer _lookupNormalizer;
        private readonly ILogger<AppUserManager> _logger;
        private readonly IOptions<IdentityOptions> _options;
        private readonly IPasswordHasher<AppUser> _passwordHasher;
        private readonly IEnumerable<IPasswordValidator<AppUser>> _passwordValidators;
        private readonly IServiceProvider _serviceProvider;
        private readonly IUserStore<AppUser> _userStore;
        private readonly IEnumerable<UserValidator<AppUser>> _userValidators;

        public AppUserManager(AppErrorDescriber appErrorDescriber
            ,ILookupNormalizer lookupNormalizer
            ,ILogger<AppUserManager> logger
            ,IOptions<IdentityOptions> options
            ,IPasswordHasher<AppUser> passwordHasher
            ,IEnumerable<IPasswordValidator<AppUser>> passwordValidators
            ,IServiceProvider serviceProvider
            ,IUserStore<AppUser> userStore
            ,IEnumerable<UserValidator<AppUser>> userValidators)
            :base(userStore,options,passwordHasher,userValidators,passwordValidators,lookupNormalizer,appErrorDescriber,serviceProvider,logger)
        {
            _appErrorDescriber = appErrorDescriber;
            _lookupNormalizer = lookupNormalizer;
            _logger = logger;
            _options = options;
            _passwordHasher = passwordHasher;
            _passwordValidators = passwordValidators;
            _serviceProvider = serviceProvider;
            _userStore = userStore;
            _userValidators = userValidators;
        }

        public async Task<List<AppUser>> GetAllUsers()
        {
            var users= await Users.ToListAsync();
            return users;
        }
   
        public async Task<List<UserManagerDto>> GetAllUserWithRoles()
        {
            var users= await Users.Select(u => new UserManagerDto()
            {
               
                BrithDay = u.BrithDay,
                Email = u.Email,
              
                FirstName = u.FirstName,
                Id = u.Id,
                IsActive = u.IsActive,
                LastName = u.LastName,
                LastVisitDate = u.LastVisitDate,
              
                ProfileImgUrl = u.ProfileImgUrl,
                RigesterDate = u.RigesterDate,
                PhonNumber=u.PhoneNumber,

                UserName = u.UserName,
                Roles = u.Roles.Select(x=>x.Role.Name)


            }).ToListAsync();
            return users;
        }

        public async Task<string> GetFullName(ClaimsPrincipal user)
        {
            var userInfo = await GetUserAsync(user);
           
           return userInfo.FirstName+"" + userInfo.LastName;
        }

        public async Task<UserManagerDto?> GetUserWithRolesById(int id)
        {
            return await Users.Where(x => x.Id == id).Select(u => new UserManagerDto()
            {
                AccessFailedCount = u.AccessFailedCount,
                BrithDay = u.BrithDay,
                Email = u.Email,
                EmailConfirmed = u.EmailConfirmed,
                FirstName = u.FirstName,
                Id = u.Id,
                IsActive = u.IsActive,
                LastName = u.LastName,
                LastVisitDate = u.LastVisitDate,
                LockOutEnabled = u.LockoutEnabled,
                LockOutEnd = u.LockoutEnd,
                PhonNumberConfirmed = u.PhoneNumberConfirmed,
                ProfileImgUrl = u.ProfileImgUrl,
                RigesterDate = u.RigesterDate,
                PhonNumber = u.PhoneNumber,

                TwoFactorEnabled = u.TwoFactorEnabled,
                UserName = u.UserName,
                Roles = u.Roles.Select(x => x.Role.Name)
            }).FirstOrDefaultAsync();
        }
       
     
    }
}
