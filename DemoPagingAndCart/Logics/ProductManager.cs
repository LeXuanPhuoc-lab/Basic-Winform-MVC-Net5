using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DemoPagingAndCart.Models;

namespace DemoPagingAndCart.Logics
{
    public class ProductManager
    {
        public List<Product> GetProducts(int CategoryId, int Offset, int Size)
        {
            using(var context = new PRN211DemoPagingAndCartContext())
            {
                if (CategoryId == 0)// get products in all categories
                    return context.Products.Skip(Offset - 1).Take(Size).ToList();
                else
                    return context.Products.Where(x => x.CategoryId ==CategoryId).Skip(Offset - 1).Take(Size).ToList();
            }
        }

        public int GetNumberOfProducts(int CategoryId)
        {
            using (var context = new PRN211DemoPagingAndCartContext()) { 
                if (CategoryId == 0)// get products in all categories
                    return context.Products.Count();
                else
                    return context.Products.Where(x => x.CategoryId ==CategoryId).Count();
            }
        }
    }
}
