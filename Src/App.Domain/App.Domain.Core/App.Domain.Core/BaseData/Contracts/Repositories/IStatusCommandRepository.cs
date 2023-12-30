using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Core.BaseData.Contracts.Repositories
{
    public interface IStatusCommandRepository
    {
        public  Task CreateStatus(string title, bool forComment, bool forProduct,bool isDeleted, bool forOrder);
        public  Task RemoveStatus(int id);
        public  Task UpdateStatus(int id, string title, bool forComment, bool forProduct,bool forOrder);
    }
}
