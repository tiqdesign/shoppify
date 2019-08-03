using Microsoft.EntityFrameworkCore;
using shp_f.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace shp_f.Func
{

    public class DbFunc
    {
        public static DbFunc func;
        List<Products> p_list;
        ShoppingDbContext _context = new ShoppingDbContext();

        #region Singleton
        private DbFunc()
        {

        }
        public static DbFunc getInstance()
        {
            if (func == null)
            {
                func = new DbFunc();
            }
            return func;
        }
        #endregion

        #region Giriş İşlemi
        public Users GetUser(string username, string password)
        {
            try
            {
                if (_context.Users.Any(u => u.Username == username && u.UserPassword == password))
                {
                    var user = _context.Users.First(u => u.Username == username && u.UserPassword == password);
                    return user;
                }
                else
                    return null;
            }
            catch (Exception)
            {
                throw;
            }
        }
        #endregion

        #region Bütün Ürünleri Listeleme
        public List<Products> GetAllProducts()
        {
            p_list = _context.Products.Where(p => p.ProductPiece > 0).ToList();
            return p_list;
        }
        #endregion

        #region  Kategoriye Göre Listeleme
        public List<CategoryList> GetListWithCategory(string category)
        {
            var p_listCat = _context.Products.Join(_context.Categories, product => product.CategoryId, cat => cat.Category.CategoryId, (product, cat) =>
            new
            {
                ProductID = product.ProductId,
                ProductName = product.ProductName,
                CategoryName = cat.CategoryName,
                ProductPiece = product.ProductPiece,
                ProductPrice = product.ProductPrice,
                ProductUrl = product.ProductUrl
            }).Select(p => new CategoryList { ProductID = p.ProductID, CategoryName = p.CategoryName, ProductName = p.ProductName, ProductPiece = p.ProductPiece, ProductPrice = p.ProductPrice, ProductUrl = p.ProductUrl }).Where(p => p.CategoryName == category).ToList();

            return p_listCat;
        }
        #endregion

        #region SQL Query
        /*
        Select CategoryName from Product p inner join Category c on p.CategoryID = c.CategoryID where CategoryName = category
        */
        #endregion

        #region ID ye Göre Ürün Getirme
        public Products GetProduct(int id)
        {
            //Url ile giriş  yaparken id 0 geliyor hata vermesin diye boş bir nesne gösterdim.
            if (id == 0)
            {
                var pdefault = new Products { Category = null, CategoryId = 0, ProductId = 0, ProductName = "", ProductPiece = 0, ProductPrice = 0, ProductUrl = "" };
                return pdefault;
            }
            else
            {
                var product = _context.Products.Where(p => p.ProductId == id).First();
                return product;
            }

        }
        #endregion

        #region AutoComplete için Kategoriler
        public List<Categories> GetCategory()
        {
            var category_list = _context.Categories.ToList();
            return category_list;
        }
        #endregion

    }
}
