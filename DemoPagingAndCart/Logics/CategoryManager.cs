using DemoPagingAndCart.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DemoPagingAndCart.Logics
{
    public class CategoryManager
    {
        public PRN211DemoPagingAndCartContext context;
        public List<Category> GetCategories()
        {
            using(context = new PRN211DemoPagingAndCartContext())
            {
                return context.Categories.ToList();
            }
        }
    }
}
