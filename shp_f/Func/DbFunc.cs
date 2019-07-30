using shp_f.Models;
using System;
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

        //singleton 
        #region
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

        public Users GetUser(string username , string password)
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

        public  List<Products> GetAllProducts()
        {
            p_list = _context.Products.Where(p => p.ProductPiece > 0).ToList();
            return p_list;
        }

        public Products GetProduct(int id)
        {
            var product = _context.Products.Where(p => p.ProductId == id).First();
            return product;
        }
    }
}
