using App.Infrastructure.DataBase.Data;
using App.Infrastructure.DataBase.Entities;
using System.Collections;

namespace App.EndPoint.AdminUi.Models
{
    public class Repository
    {
        private readonly AppDbContext Contaxtdb; 

        public Repository( AppDbContext appDbContext)
        {
         appDbContext = Contaxtdb;
        }
        
        public void InsertProduct(Product product)
        {
           product.Status  = Contaxtdb.Statuses.Where(x => x.Id == 11).FirstOrDefault();
           

            Contaxtdb.Products.Add(product);
            Contaxtdb.SaveChanges();
        }
        public void DeleteProduct(int Id)
        {
            var product=Contaxtdb.Products.Where(i=>i.Id==Id).FirstOrDefault();

            Contaxtdb.Products.Remove(product);
            Contaxtdb.SaveChanges();
        }
        public ICollection GetProduct()
        {
            var products = Contaxtdb.Products.ToList();


            return products;

        }
        public void UpdateProduct( Product product)
        {
            var product1 = Contaxtdb.Products.Where(x=>x.Id==product.Id).FirstOrDefault();   
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
            product1.Status = Contaxtdb.Statuses.Where(x => x.Id == 13).FirstOrDefault();
            product1.SubmitOperator = product.SubmitOperator;
            product1.IsActive = product.IsActive;
            product1.IsShowPrice = product.IsShowPrice;
            Contaxtdb.SaveChanges();

        }
        public void DeleteUser(int Id)
        {
            var user = Contaxtdb.Users.Where(x => x.Id == Id).FirstOrDefault();
            Contaxtdb.Users.Remove(user);
            Contaxtdb.SaveChanges();


        }
        public void UpdateUser(User user)
        {
            var user1 = Contaxtdb.Users.Where(x => x.Id == user.Id).FirstOrDefault();
            user1.Role = user.Role;
            user1.Mobile = user.Mobile;
            user1.Email=user.Email;
            user1.FirstName = user.FirstName;
            user1.LastName = user.LastName;
            user1.PassWord = user.PassWord;
            user1.UserName= user.UserName;
            user1.BrithDay = user.BrithDay;
            user1.Status = Contaxtdb.Statuses.Where(x => x.Id == 7).FirstOrDefault();
            user1.Products = user.Products;


        }
        public ICollection ReadUsers()
        {
            var Users = Contaxtdb.Users.ToList();
            return Users;

        }
        public void ConfirmComment(int Id)
        {
            var com = Contaxtdb.Comments.Where(x => x.Id == Id).FirstOrDefault();
        
            com.Status = Contaxtdb.Statuses.Where(x => x.Id == 5).FirstOrDefault();
            Contaxtdb.SaveChanges();
         
        }
        public void RejectComment( int Id)
        {
            var com = Contaxtdb.Comments.Where(x => x.Id == Id).FirstOrDefault();
            com.Status = Contaxtdb.Statuses.Where(x=>x.Id==6).FirstOrDefault();
            Contaxtdb.SaveChanges();
        }
        public ICollection ReadComment()
        {

            var com = Contaxtdb.Comments.ToList();
            return com;
        }

        public Product GetIdProduct(int Id)
        {
            var product = Contaxtdb.Products.Where(x => x.Id == Id).FirstOrDefault();
            return product;

        }
        public User GetIdUser(int Id)
        {
            var User = Contaxtdb.Users.Where(x => x.Id == Id).FirstOrDefault();
            return User;
        }

       public Product DetailsProduct(int Id)
        {
            var product = Contaxtdb.Products.Where(x => x.Id == Id).FirstOrDefault();
            return product;
        }





    }
}
