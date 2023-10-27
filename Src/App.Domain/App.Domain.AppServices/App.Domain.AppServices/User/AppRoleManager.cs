using App.Domain.Core.User.Contracts.AppServices;
using App.Domain.Core.User.Dtos;
using App.Domain.Core.User.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.AppServices.User
{
    public class AppRoleManager: RoleManager<AppRole>,IAppRoleManager
    {
        private readonly IdentityErrorDescriber _identityErrorDescriber;
        private readonly ILookupNormalizer _lookupNormalizer;
        private readonly ILogger<AppRoleManager> _logger;
        private readonly  IEnumerable< IRoleValidator<AppRole>> _roleValidators;
        private readonly IRoleStore<AppRole> _roleStore;
        public AppRoleManager(
            
             IRoleStore<AppRole> roleStore
            , IEnumerable<IRoleValidator<AppRole>> roleValidators
            , ILookupNormalizer lookupNormalizer
            ,IdentityErrorDescriber identityErrorDescriber
              , ILogger<AppRoleManager> logger) : base(roleStore, roleValidators, lookupNormalizer, identityErrorDescriber, logger)

        {
            _identityErrorDescriber = identityErrorDescriber;
            _lookupNormalizer = lookupNormalizer;
            _logger = logger;

            _roleValidators = roleValidators;
            _roleStore = roleStore;


        }
        public List<AppRole> GetAllRoles()
        {
            return Roles.ToList();
        }
        public List<RolesDto> GetAllRolesAndCountUser()
        {
            return Roles.Select(role => new RolesDto
            {
                RoleId = role.Id,
                RoleDescription = role.Description,
                RoleName = role.Name,
                CountUser = role.Users.Count


            }).ToList();

        }

    }
}
