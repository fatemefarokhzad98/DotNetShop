using App.Domain.Core.Product.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Core.Product.Contracts.Repositories
{
    public interface ICategoryRepository
    {
        List<Category> GetAllCategory();
        Category ExitCategory(int Id);
        void RemoveCategory(int Id);
        void UpdateCategory(Category category);
        void CreateCategory(Category category);

       
    }
}
