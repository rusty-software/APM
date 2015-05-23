using APM.WebAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;

namespace APM.WebAPI.Controllers
{
    [EnableCorsAttribute("http://localhost:49597", "*", "*")]
    public class ProductsController : ApiController
    {
        private IEnumerable<Product> AllProducts()
        {
            return (new ProductRepository()).FindAll();
        }

        // GET: api/Products
        public IEnumerable<Product> Get()
        {
            return AllProducts();
        }

        public IEnumerable<Product> Get(string search)
        {
            return AllProducts().Where(p => p.ProductCode.Contains(search));
        }

        // GET: api/Products/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Products
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/Products/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Products/5
        public void Delete(int id)
        {
        }
    }
}
