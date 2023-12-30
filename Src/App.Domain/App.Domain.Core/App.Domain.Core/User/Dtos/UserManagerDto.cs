using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Core.User.Dtos
{
    public class UserManagerDto
    {
        public int Id { get; set; }
        public string FirstName { get; set; } = null!;
        public string? Email { get; set; }
        public string PhonNumber { get; set; }
        public string UserName { get; set; } = null!;
        public string LastName { get; set; } = null!;
        public DateTime? BrithDay { get; set; }
        public DateTime RigesterDate { get; set; }
        public DateTime? LastVisitDate { get; set; }
        public bool IsActive { get; set; }
        public string? ProfileImgUrl { get; set; }
        public IEnumerable<string> Roles { get; set; }
        //تایید شمااره موبایل
        public bool PhonNumberConfirmed { get; set; }
        //تایید ایمیل
        public bool EmailConfirmed { get; set; }
        //تایید دو مرحله ای
        public bool TwoFactorEnabled { get; set; }
       //حساب کاربری قفل است یا نه
        public bool LockOutEnabled { get; set; }
        //تلاشهای ناموفق کاربر
        public int AccessFailedCount { get; set; }
        public DateTimeOffset? LockOutEnd { get; set; }


    }
}
