using Logic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;

namespace TestAPI.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class ProductController : ApiController
    {
        private IProductLogic _productLogic;
        public ProductController()
        {
            this._productLogic = new ProductLogic();
        }

        [HttpGet()]
        [ActionName("GetAllProducts")]
        public IHttpActionResult GetAllProducts()
        {
            try
            {
                var productList = _productLogic.GetAllProducts();
                return Json(new
                {
                    status = true,
                    data = productList
                });
            }
            catch (Exception ex)
            {
                return Json(new { status = false, message = "Unknown error occurred" });
            }
        }

        [HttpPost()]
        [ActionName("AddProduct")]
        public IHttpActionResult AddProduct(ProductVM product)
        {
            try
            {
                var empId = _productLogic.SaveProduct(product);
                return Json(new
                {
                    status = true,
                    data = empId
                });
            }
            catch (Exception ex)
            {
                return Json(new { status = false, message = "Unknown error occurred" });
            }
        }

        [HttpPut()]
        [ActionName("EditProduct")]
        public IHttpActionResult EditProduct(ProductVM product)
        {
            try
            {
                var empId = _productLogic.UpdateProduct(product);
                return Json(new
                {
                    status = true,
                    data = empId
                });
            }
            catch (Exception ex)
            {
                return Json(new { status = false, message = "Unknown error occurred" });
            }
        }

        [HttpDelete()]
        [ActionName("RemoveProduct")]
        public IHttpActionResult RemoveProduct(int id)
        {
            try
            {
                _productLogic.DeleteProduct(id);
                return Json(new
                {
                    status = true
                });
            }
            catch (Exception ex)
            {
                return Json(new { status = false, message = "Unknown error occurred" });
            }
        }
    }
}
