using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic
{
    public interface IProductLogic
    {
        List<ProductVM> GetAllProducts();
        int SaveProduct(ProductVM product);
        int UpdateProduct(ProductVM product);
        void DeleteProduct(int id);
    }
}
