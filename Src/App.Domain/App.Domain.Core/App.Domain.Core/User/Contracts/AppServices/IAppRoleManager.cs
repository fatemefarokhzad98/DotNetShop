﻿using App.Domain.Core.User.Dtos;
using App.Domain.Core.User.Entities;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Core.User.Contracts.AppServices
{
    public interface IAppRoleManager
    {
        #region CustomMethod
        public List<AppRole> GetAllRoles();
        public List<RolesDto> GetAllRolesAndCountUser();
        #endregion
        #region BaseClass
        IQueryable<AppRole> Roles { get; }
        ILookupNormalizer KeyNormalizer { get; set; }
        IdentityErrorDescriber ErrorDescriber { get; set; }
        IList<IRoleValidator<AppRole>> RoleValidators { get; }
        bool SupportsQueryableRoles { get; }
        bool SupportsRoleClaims { get; }
        Task<IdentityResult> CreateAsync(AppRole role);
        Task<IdentityResult> DeleteAsync(AppRole role);
        Task<AppRole> FindByIdAsync(string roleId);
        Task<AppRole> FindByNameAsync(string roleName);
        string NormalizeKey(string key);
        Task<bool> RoleExistsAsync(string roleName);
        Task<IdentityResult> UpdateAsync(AppRole role);
        Task UpdateNormalizedRoleNameAsync(AppRole role);
        Task<string> GetRoleNameAsync(AppRole role);
        Task<IdentityResult> SetRoleNameAsync(AppRole role, string name);




        #endregion



    }
}
