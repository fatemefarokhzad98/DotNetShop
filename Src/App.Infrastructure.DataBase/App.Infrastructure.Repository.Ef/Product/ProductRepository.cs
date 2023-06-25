using ProductEntities = App.Domain.Core.Product.Entities;
using UserEntities = App.Domain.Core.User.Entities;
using App.Infrastructure.DataBase.Data;
using System.Collections;

namespace App.Infrastructure.Repository.Ef.Product
{
    public class ProductRepository
    {
        private readonly AppDbContext _appDbContext; 

        public ProductRepository( AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }
        
        public void InsertProduct(ProductEntities.Product product)
        {
           product.Status  = _appDbContext.Statuses.Where(x => x.Id == 11).FirstOrDefault();


            _appDbContext.Products.Add(product);
            _appDbContext.SaveChanges();
        }
        public void DeleteProduct(int Id)
        {
            var product= _appDbContext.Products.Where(i=>i.Id==Id).FirstOrDefault();

            _appDbContext.Products.Remove(product);
            _appDbContext.SaveChanges();
        }
        public ICollection GetProduct()
        {
            var products = _appDbContext.Products.ToList();


            return products;

        }
        public void UpdateProduct(ProductEntities.Product product)
        {
            var product1 = _appDbContext.Products.Where(x=>x.Id==product.Id).FirstOrDefault();   
            product1.Brand = product.Brand;
            product1.Name = product.Name;
            product1.Description = product.Description;
            product1.Model = product.Model;
            product1.Category = product.Category;
            product1.CollectionProducts = product.CollectionProducts;
            product1.Count=product.Count;
            product1.Price = product.Price;
            product1.ProductColors = product.ProductColors;
            product1.ProductTags = product.ProductTags;
            product1.Status = _appDbContext.Statuses.Where(x => x.Id == 13).FirstOrDefault();
            product1.SubmitOperator = product.SubmitOperator;
            product1.IsActive = product.IsActive;
            product1.IsShowPrice = product.IsShowPrice;
            _appDbContext.SaveChanges();

        }
        public void DeleteUser(int Id)
        {
            var user = _appDbContext.Users.Where(x => x.Id == Id).FirstOrDefault();
            _appDbContext.Users.Remove(user);
            _appDbContext.SaveChanges();


        }
        public void UpdateUser(UserEntities.User user)
        {
            var user1 = _appDbContext.Users.Where(x => x.Id == user.Id).FirstOrDefault();
            user1.Role = user.Role;
            user1.Mobile = user.Mobile;
            user1.Email=user.Email;
            user1.FirstName = user.FirstName;
            user1.LastName = user.LastName;
            user1.PassWord = user.PassWord;
            user1.UserName= user.UserName;
            user1.BrithDay = user.BrithDay;
            user1.Status = _appDbContext.Statuses.Where(x => x.Id == 7).FirstOrDefault();
            user1.Products = user.Products;


        }
        public ICollection ReadUsers()
        {
            var Users = _appDbContext.Users.ToList();
            return Users;

        }
        public void ConfirmComment(int Id)
        {
            var com = _appDbContext.Comments.Where(x => x.Id == Id).FirstOrDefault();
        
            com.Status = _appDbContext.Statuses.Where(x => x.Id == 5).FirstOrDefault();
            _appDbContext.SaveChanges();
         
        }
        public void RejectComment( int Id)
        {
            var com = _appDbContext.Comments.Where(x => x.Id == Id).FirstOrDefault();
            com.Status = _appDbContext.Statuses.Where(x=>x.Id==6).FirstOrDefault();
            _appDbContext.SaveChanges();
        }
        public ICollection ReadComment()
        {

            var com = _appDbContext.Comments.ToList();
            return com;
        }

        public ProductEntities.Product GetIdProduct(int Id)
        {
            var product = _appDbContext.Products.Where(x => x.Id == Id).FirstOrDefault();
            return product;

        }
        public UserEntities.User GetIdUser(int Id)
        {
            var User = _appDbContext.Users.Where(x => x.Id == Id).FirstOrDefault();
            return User;
        }

       public ProductEntities.Product DetailsProduct(int Id)
        {
            var product = _appDbContext.Products.Where(x => x.Id == Id).FirstOrDefault();
            return product;
        }





    }
}
