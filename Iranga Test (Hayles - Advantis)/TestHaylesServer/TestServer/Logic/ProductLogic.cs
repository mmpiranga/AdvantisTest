using Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic
{
    public class ProductLogic : IProductLogic
    {
        private IGenericRepository<tblProduct> _productRepository;
        public ProductLogic()
        {
            this._productRepository = new GenericRepository<tblProduct>();
        }

        public List<ProductVM> GetAllProducts()
        {
            try
            {
                List<ProductVM> productList = new List<ProductVM>();

                var productData = _productRepository.GetAll().ToList();

                foreach (var emp in productData)
                {
                    ProductVM productVM = new ProductVM();
                    productVM.Id = emp.id;
                    productVM.Name = emp.name;
                    productVM.Discount = emp.discount;
                    productVM.Quantity = emp.quantity;
                    productVM.TotalAmount = emp.totalAmount;
                    productVM.BalanceAmount = emp.balanceAmount;

                    productList.Add(productVM);
                }

                return productList;
            }
            catch (Exception ex)
            {

                throw;
            }
        }


        public int SaveProduct(ProductVM product)
        {
            try
            {
                tblProduct productObj = new tblProduct();
                productObj.id = product.Id;
                productObj.name = product.Name;
                productObj.discount = product.Discount;
                productObj.quantity = product.Quantity;
                productObj.totalAmount = product.TotalAmount;
                productObj.balanceAmount = product.BalanceAmount;

                _productRepository.Insert(productObj);
                _productRepository.Save();

                return productObj.id;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public int UpdateProduct(ProductVM product)
        {
            try
            {
                tblProduct productObj = _productRepository.GetByID(product.Id);
                productObj.id = product.Id;
                productObj.name = product.Name;
                productObj.discount = product.Discount;
                productObj.quantity = product.Quantity;
                productObj.totalAmount = product.TotalAmount;
                productObj.balanceAmount = product.BalanceAmount;

                _productRepository.Update(productObj);
                _productRepository.Save();

                return productObj.id;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void DeleteProduct(int id)
        {
            try
            {
                _productRepository.Delete(id);
                _productRepository.Save();
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
